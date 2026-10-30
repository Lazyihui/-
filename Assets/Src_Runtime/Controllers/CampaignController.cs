using System;
using System.Collections.Generic;
using System.IO;

namespace Hamdoku.Controllers {
    public static class CampaignController {
        public static void Initialize(GameContext ctx, PlayerSaveModel loaded) {
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            var campaignConfig = assets.GetCampaignConfig();
            var module = ctx.puzzleModule;
            var state = ctx.state_Game;
            int today = (int)(DateTime.Today.Ticks / TimeSpan.TicksPerDay);
            if (loaded != null && loaded.version >= 8) {
                save.campaign = loaded.campaign;
            } else {
                // The old save has no skill/history. Keep its board and progress; start new tracking.
                save.campaign = new CampaignSaveModel {
                    skill = campaignConfig.campaignInitialSkill,
                    cursorPositions = new int[campaignConfig.campaignCursorSlots],
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
            if (loaded == null || loaded.version < 11) {
                // Keep only a currently displayed won milestone pending. Do not invent past grants.
                var active = save.activePuzzle;
                int baseline = save.campaignClears;
                if (active != null && !active.isTutorial && active.status == GameStatus.Won) {
                    baseline = Math.Max(0, active.level - 1);
                }
                campaign.claimedRewardLevel = baseline / campaignConfig.campaignRewardStep * campaignConfig.campaignRewardStep;
                campaign.previousRecordedSkill = campaign.skill;
                campaign.previousLevel = 0;
                campaign.previousRetried = false;
                campaign.pendingDemotion = false;
            }
            if (loaded == null || loaded.version < 12) {
                campaign.cursorCycles = new int[campaignConfig.campaignCursorSlots];
                var active = save.activePuzzle;
                if (active != null) {
                    active.campaignTransform = 0;
                }
            }
            if (loaded == null || loaded.version < 13) {
                Array.Resize(ref campaign.cursorPositions, campaignConfig.campaignCursorSlots);
                Array.Resize(ref campaign.cursorCycles, campaignConfig.campaignCursorSlots);
                campaign.expertRelief = false;
            }
            module.ValidateCampaign(campaign, campaignConfig, config.tutorialPuzzleId, save.campaignClears);
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
            var campaignConfig = assets.GetCampaignConfig();
            var module = ctx.puzzleModule;
            int level = state.level;
            if (level >= campaignConfig.campaignTransformStartLevel && campaign.skill == campaignConfig.campaignInitialSkill) {
                campaign.skill = campaignConfig.campaignLaterMinimumSkill;
            }
            int grade = Math.Min(campaign.skill, campaignConfig.campaignGradeCeilings[level - 1]);
            bool hard = level >= campaignConfig.campaignHardStartLevel && level % campaignConfig.campaignHardInterval == 0;
            if (hard) {
                bool relief = campaign.expertRelief;
                if (level >= campaignConfig.campaignExpertStartLevel) {
                    campaign.expertRelief = false;
                }
                grade = level >= campaignConfig.campaignExpertStartLevel && campaign.skill == campaignConfig.campaignExpertGrade &&
                    !campaign.pendingDemotion && !relief ? campaignConfig.campaignExpertGrade : campaignConfig.campaignHardGrade;
            } else if (grade >= 3) {
                grade = UnityEngine.Random.Range(2, grade + 1);
            }
            bool firstGame = state.firstGameAvailable;
            if (firstGame) {
                grade = Math.Max(campaignConfig.campaignInitialSkill, grade - 1);
            }
            var selection = module.SelectCampaign(campaignConfig, campaign, level, grade);
            var puzzle = selection.puzzle;
            state.puzzle = module.Materialize(puzzle.id, selection.transform);
            state.campaignSelectionVersion = 1;
            state.campaignGrade = puzzle.grade;
            state.campaignFirstGame = firstGame;
            state.campaignTouched = false;
            state.campaignUsedItem = false;
            state.campaignFailures = 0;
            state.firstGameAvailable = false;
            if (selection.poolKey > 0) {
                campaign.cursorPositions[selection.poolKey] = selection.nextPosition;
                campaign.cursorCycles[selection.poolKey] = selection.nextCycle;
            }
            var history = campaign.recentPuzzleIds;
            history.Add(puzzle.id);
            if (history.Count > campaignConfig.campaignHistoryLimit) {
                history.RemoveRange(0, history.Count - campaignConfig.campaignHistoryLimit);
            }
        }

        public static void Touch(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.mode == GameModeType.Campaign && state.status == GameStatus.Playing) {
                state.campaignTouched = true;
            }
        }

        public static int PendingReward(GameContext ctx) {
            var save = ctx.playerSave;
            var campaign = save.campaign;
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            int milestone = save.campaignClears / campaignConfig.campaignRewardStep * campaignConfig.campaignRewardStep;
            return milestone > campaign.claimedRewardLevel ? milestone : 0;
        }

        public static bool ClaimReward(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isOpen || state.mode != GameModeType.Campaign || state.status != GameStatus.Won || state.dialog != GameDialogType.Reward) {
                return false;
            }
            int milestone = PendingReward(ctx);
            if (milestone == 0) {
                return false;
            }
            var save = ctx.playerSave;
            var campaign = save.campaign;
            var bonus = save.streak;
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            int hints = checked(bonus.bonusHints + campaignConfig.campaignRewardHints);
            int guides = checked(bonus.bonusGuides + campaignConfig.campaignRewardGuides);
            int previous = campaign.claimedRewardLevel;
            int oldHints = bonus.bonusHints;
            int oldGuides = bonus.bonusGuides;
            campaign.claimedRewardLevel = milestone;
            bonus.bonusHints = hints;
            bonus.bonusGuides = guides;
            try {
                HomeController.SaveProgress(ctx);
            } catch {
                campaign.claimedRewardLevel = previous;
                bonus.bonusHints = oldHints;
                bonus.bonusGuides = oldGuides;
                throw;
            }
            return true;
        }

        public static void Fail(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.mode != GameModeType.Campaign || state.status == GameStatus.Won) {
                return;
            }
            state.campaignTouched = true;
            state.campaignFailures = checked(state.campaignFailures + 1);
            var save = ctx.playerSave;
            var campaign = save.campaign;
            campaign.cleanStreak = 0;
            if (state.campaignGrade == CampaignConfigGrade(ctx)) {
                campaign.expertRelief = true;
            }
        }

        static int CampaignConfigGrade(GameContext ctx) {
            var assets = ctx.assetModule;
            return assets.GetCampaignConfig().campaignExpertGrade;
        }

        public static void UseItem(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.mode != GameModeType.Campaign) {
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
            if (state.mode != GameModeType.Campaign) {
                return;
            }
            var save = ctx.playerSave;
            if (state.level != save.campaignClears + 1) {
                throw new InvalidDataException("Campaign difficulty can only record the next clear once.");
            }
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            var campaign = save.campaign;
            int minimum = state.level >= campaignConfig.campaignMinimumSkillStartLevel ? campaignConfig.campaignLaterMinimumSkill : campaignConfig.campaignInitialSkill;
            campaign.skill = Math.Max(minimum, campaign.skill);
            if (state.level < campaignConfig.campaignAdaptiveStartLevel) {
                return;
            }
            if (state.campaignFailures == 0 && !state.campaignUsedItem) {
                if (campaign.cleanStreak < int.MaxValue) {
                    campaign.cleanStreak++;
                }
                int promotionThreshold = state.level >= campaignConfig.campaignLaterPromotionStartLevel ?
                    campaignConfig.campaignLaterCleanClearsToPromote : campaignConfig.campaignCleanClearsToPromote;
                if (campaign.cleanStreak >= promotionThreshold && campaign.skill < campaignConfig.campaignSkillCeilings[state.level - 1]) {
                    campaign.skill++;
                    campaign.cleanStreak = 0;
                }
            } else {
                campaign.cleanStreak = 0;
            }
            int threshold = state.level >= campaignConfig.campaignReliefStartLevel ? campaignConfig.campaignLaterFailureThreshold : campaignConfig.campaignFailureThreshold;
            if (state.campaignFailures >= threshold) {
                campaign.skill = Math.Max(minimum, campaign.skill - 1);
                RecordPrevious(campaign, state);
                return;
            }
            if (state.level >= campaignConfig.campaignReliefStartLevel && state.campaignFailures > 0 && campaign.previousRetried &&
                campaign.previousLevel == state.level - 1 && campaign.previousRecordedSkill == campaign.skill) {
                campaign.skill = Math.Max(minimum, campaign.skill - 1);
            }
            RecordPrevious(campaign, state);
            if (state.campaignFirstGame) {
                return;
            }
            if (campaign.pendingDemotion) {
                campaign.skill = Math.Max(minimum, campaign.skill - 1);
                campaign.pendingDemotion = false;
            } else if (state.campaignFailures > 0) {
                int nextLevel = state.level + 1;
                var home = assets.GetHomeConfig();
                bool hard = nextLevel >= home.hardLevelStart && nextLevel % home.hardLevelInterval == 0;
                if (hard || Array.IndexOf(campaignConfig.campaignFixedLevels, nextLevel) >= 0) {
                    campaign.pendingDemotion = true;
                } else {
                    campaign.skill = Math.Max(minimum, campaign.skill - 1);
                }
            }
        }
        static void RecordPrevious(CampaignSaveModel campaign, GameState state) {
            campaign.previousLevel = state.level;
            campaign.previousRetried = state.campaignFailures > 0;
            campaign.previousRecordedSkill = campaign.skill;
        }
    }
}
