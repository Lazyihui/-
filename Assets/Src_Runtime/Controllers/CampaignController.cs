using System;
using System.Collections.Generic;
using System.IO;

namespace Hamdoku.Controllers {
    public static class CampaignController {
        public static void Initialize(GameContext ctx, PlayerSaveModel loaded) {
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var module = ctx.puzzleModule;
            var state = ctx.state_Game;
            int today = (int)(DateTime.Today.Ticks / TimeSpan.TicksPerDay);
            if (loaded != null && loaded.version >= 8) {
                save.campaign = loaded.campaign;
            } else {
                // The old save has no skill/history. Keep its board and progress; start new tracking.
                save.campaign = new CampaignSaveModel {
                    skill = config.campaignInitialSkill,
                    cursorPositions = new int[config.campaignCursorSlots],
                    recentPuzzleIds = new List<int>()
                };
                var history = save.campaign.recentPuzzleIds;
                if (save.previousPuzzleId > 0) {
                    history.Add(save.previousPuzzleId);
                }
                var active = save.activePuzzle;
                if (active != null && !active.isTutorial && active.puzzleId != save.previousPuzzleId) {
                    history.Add(active.puzzleId);
                }
                if (active != null && !active.isTutorial) {
                    active.campaignGrade = module.Get(active.puzzleId).grade;
                    active.campaignUsedItem = active.hints < config.hintsPerLevel || active.guides < config.guidesPerLevel;
                    active.campaignTouched = active.mistakes > 0 || active.campaignUsedItem ||
                        (active.cells != null && Array.Exists(active.cells, cell => cell != CellStatus.None));
                    var profile = save.profile;
                    active.campaignFailures = active.status == GameStatus.Failed || profile.retriedLevel == active.level ? 1 : 0;
                }
            }
            var campaign = save.campaign;
            module.ValidateCampaign(campaign, config, save.campaignClears);
            state.firstGameAvailable = today > campaign.sessionDay;
            if (state.firstGameAvailable) {
                var active = save.activePuzzle;
                if (active != null && !active.isTutorial && active.status != GameStatus.Won && active.campaignTouched) {
                    active.campaignFirstGame = false;
                    state.firstGameAvailable = false;
                }
                campaign.sessionDay = today;
            }
        }

        public static void Select(GameContext ctx) {
            var save = ctx.playerSave;
            var campaign = save.campaign;
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var module = ctx.puzzleModule;
            int level = state.level;
            int grade = Math.Min(campaign.skill, config.campaignGradeCeilings[level - 1]);
            bool firstGame = state.firstGameAvailable;
            if (firstGame) {
                grade = Math.Max(config.campaignInitialSkill, grade - 1);
            }
            var selection = module.SelectCampaign(config, campaign, level, grade);
            var puzzle = selection.puzzle;
            state.puzzle = puzzle;
            state.campaignSelectionVersion = 1;
            state.campaignGrade = puzzle.grade;
            state.campaignFirstGame = firstGame;
            state.campaignTouched = false;
            state.campaignUsedItem = false;
            state.campaignFailures = 0;
            state.firstGameAvailable = false;
            if (selection.poolKey > 0) {
                campaign.cursorPositions[selection.poolKey] = selection.nextPosition;
            }
            var history = campaign.recentPuzzleIds;
            history.Add(puzzle.id);
            if (history.Count > config.campaignHistoryLimit) {
                history.RemoveRange(0, history.Count - config.campaignHistoryLimit);
            }
        }

        public static void Touch(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dailyDay == 0 && !state.isTutorial && state.status == GameStatus.Playing) {
                state.campaignTouched = true;
            }
        }

        public static void Fail(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dailyDay > 0 || state.isTutorial || state.status == GameStatus.Won) {
                return;
            }
            state.campaignTouched = true;
            state.campaignFailures = checked(state.campaignFailures + 1);
            var save = ctx.playerSave;
            var campaign = save.campaign;
            campaign.cleanStreak = 0;
        }

        public static void UseItem(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dailyDay > 0 || state.isTutorial) {
                return;
            }
            state.campaignTouched = true;
            state.campaignUsedItem = true;
            var save = ctx.playerSave;
            var campaign = save.campaign;
            campaign.cleanStreak = 0;
        }

        public static void Complete(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dailyDay > 0 || state.isTutorial) {
                return;
            }
            var save = ctx.playerSave;
            if (state.level != save.campaignClears + 1) {
                throw new InvalidDataException("Campaign difficulty can only record the next clear once.");
            }
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var campaign = save.campaign;
            if (state.level < config.campaignAdaptiveStartLevel) {
                return;
            }
            if (state.campaignFailures == 0 && !state.campaignUsedItem) {
                campaign.cleanStreak++;
                if (campaign.cleanStreak >= config.campaignCleanClearsToPromote) {
                    campaign.skill = Math.Min(config.campaignSkillCeilings[state.level - 1], campaign.skill + 1);
                    campaign.cleanStreak = 0;
                }
            } else {
                campaign.cleanStreak = 0;
            }
            if (state.campaignFailures >= config.campaignFailureThreshold) {
                campaign.skill = Math.Max(config.campaignInitialSkill, campaign.skill - 1);
            }
        }
    }
}
