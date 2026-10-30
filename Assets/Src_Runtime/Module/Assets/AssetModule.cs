using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Hamdoku {
    public sealed class AssetModule {
        readonly Dictionary<PanelType, GameObject> panels = new Dictionary<PanelType, GameObject>();
        readonly List<L10NSO> texts = new List<L10NSO>();
        readonly List<L10NFontSO> fonts = new List<L10NFontSO>();
        AsyncOperationHandle<IList<UnityEngine.Object>> defaultHandle;
        EndlessConfigSO endlessConfig;
        DailyConfigSO dailyConfig;
        HomeConfigSO homeConfig;
        GameConfigSO gameConfig;
        PuzzleRulesSO puzzleRules;
        CampaignConfigSO campaignConfig;
        PuzzlePresentationSO puzzlePresentation;
        ResultConfigSO resultConfig;
        readonly Dictionary<int, PuzzleSO> puzzleById = new Dictionary<int, PuzzleSO>();
        readonly List<PuzzleSO> puzzleList = new List<PuzzleSO>();
        RankingConfigSO rankingConfig;
        StreakConfigSO streakConfig;
        ProfileConfigSO profileConfig;
        SettingsConfigSO settingsConfig;
        ShopConfigSO shopConfig;
        bool registered;

        public void BeginLoadAll() {
            if (defaultHandle.IsValid()) {
                throw new InvalidOperationException("Default assets are already loading.");
            }
            defaultHandle = Addressables.LoadAssetsAsync<UnityEngine.Object>(AAConst.LABEL_DEFAULT, null);
        }

        public float GetLoadProgress() {
            if (!defaultHandle.IsValid()) {
                throw new InvalidOperationException("Default asset loading has not started.");
            }
            return defaultHandle.PercentComplete;
        }

        public bool IsLoadDone() {
            return defaultHandle.IsDone;
        }

        public void CompleteLoadAll() {
            if (registered) {
                return;
            }
            if (defaultHandle.Status != AsyncOperationStatus.Succeeded) {
                throw new InvalidOperationException("Failed to load default assets.", defaultHandle.OperationException);
            }
            foreach (var asset in defaultHandle.Result) {
                if (asset is GameObject prefab) {
                    var panel = prefab.GetComponent<IPanelAsset>();
                    if (panel != null) {
                        panels.Add(panel.Type, prefab);
                    }
                } else if (asset is PuzzleSO puzzle) {
                    puzzleById.Add(puzzle.id, puzzle);
                    puzzleList.Add(puzzle);
                } else if (asset is PuzzleRulesSO rules) {
                    if (puzzleRules != null) {
                        throw new InvalidOperationException("Duplicate PuzzleRulesSO.");
                    }
                    puzzleRules = rules;
                } else if (asset is CampaignConfigSO campaign) {
                    if (campaignConfig != null) {
                        throw new InvalidOperationException("Duplicate CampaignConfigSO.");
                    }
                    campaignConfig = campaign;
                } else if (asset is PuzzlePresentationSO presentation) {
                    if (puzzlePresentation != null) {
                        throw new InvalidOperationException("Duplicate PuzzlePresentationSO.");
                    }
                    puzzlePresentation = presentation;
                } else if (asset is ResultConfigSO result) {
                    if (resultConfig != null) {
                        throw new InvalidOperationException("Duplicate ResultConfigSO.");
                    }
                    resultConfig = result;
                } else if (asset is EndlessConfigSO endless) {
                    if (endlessConfig != null) {
                        throw new InvalidOperationException("Duplicate EndlessConfigSO.");
                    }
                    endlessConfig = endless;
                } else if (asset is DailyConfigSO daily) {
                    if (dailyConfig != null) {
                        throw new InvalidOperationException("Duplicate DailyConfigSO.");
                    }
                    dailyConfig = daily;
                } else if (asset is HomeConfigSO config) {
                    if (homeConfig != null) {
                        throw new InvalidOperationException("More than one HomeConfigSO has the default label.");
                    }
                    homeConfig = config;
                } else if (asset is GameConfigSO game) {
                    if (gameConfig != null) {
                        throw new InvalidOperationException("Duplicate GameConfigSO.");
                    }
                    gameConfig = game;
                } else if (asset is StreakConfigSO streak) {
                    if (streakConfig != null) {
                        throw new InvalidOperationException("Duplicate StreakConfigSO.");
                    }
                    streakConfig = streak;
                } else if (asset is RankingConfigSO ranking) {
                    if (rankingConfig != null) {
                        throw new InvalidOperationException("Duplicate RankingConfigSO.");
                    }
                    rankingConfig = ranking;
                } else if (asset is ProfileConfigSO profile) {
                    if (profileConfig != null) {
                        throw new InvalidOperationException("Duplicate ProfileConfigSO.");
                    }
                    profileConfig = profile;
                } else if (asset is ShopConfigSO shop) {
                    if (shopConfig != null) {
                        throw new InvalidOperationException("Duplicate ShopConfigSO.");
                    }
                    shopConfig = shop;
                } else if (asset is SettingsConfigSO settings) {
                    if (settingsConfig != null) {
                        throw new InvalidOperationException("Duplicate SettingsConfigSO.");
                    }
                    settingsConfig = settings;
                } else if (asset is L10NSO text) {
                    texts.Add(text);
                } else if (asset is L10NFontSO font) {
                    fonts.Add(font);
                }
            }
            puzzleList.Sort((left, right) => left.id.CompareTo(right.id));
            registered = true;
        }

        public PuzzleSO Puzzle_Get(int id) {
            return puzzleById[id];
        }

        public IReadOnlyList<PuzzleSO> Puzzle_GetAll() {
            return puzzleList;
        }

        public PuzzleRulesSO GetPuzzleRules() {
            if (puzzleRules == null) {
                throw new InvalidOperationException("PuzzleRulesSO is missing from default assets.");
            }
            return puzzleRules;
        }

        public CampaignConfigSO GetCampaignConfig() {
            if (campaignConfig == null) {
                throw new InvalidOperationException("CampaignConfigSO is missing from default assets.");
            }
            return campaignConfig;
        }

        public PuzzlePresentationSO GetPuzzlePresentation() {
            if (puzzlePresentation == null) {
                throw new InvalidOperationException("PuzzlePresentationSO is missing from default assets.");
            }
            return puzzlePresentation;
        }

        public ResultConfigSO GetResultConfig() {
            if (resultConfig == null) {
                throw new InvalidOperationException("ResultConfigSO is missing from default assets.");
            }
            return resultConfig;
        }

        public bool Panel_TryGet(PanelType type, out GameObject prefab) {
            return panels.TryGetValue(type, out prefab);
        }

        public EndlessConfigSO GetEndlessConfig() {
            if (endlessConfig == null) {
                throw new InvalidOperationException("EndlessConfigSO is missing from default assets.");
            }
            return endlessConfig;
        }
        public DailyConfigSO GetDailyConfig() {
            if (dailyConfig == null) {
                throw new InvalidOperationException("DailyConfigSO is missing from default assets.");
            }
            return dailyConfig;
        }

        public HomeConfigSO GetHomeConfig() {
            if (homeConfig == null) {
                throw new InvalidOperationException("HomeConfigSO is missing from the default assets.");
            }
            return homeConfig;
        }

        public GameConfigSO GetGameConfig() {
            if (gameConfig == null) {
                throw new InvalidOperationException("GameConfigSO is missing from default assets.");
            }
            return gameConfig;
        }

        public StreakConfigSO GetStreakConfig() {
            if (streakConfig == null) {
                throw new InvalidOperationException("StreakConfigSO is missing from default assets.");
            }
            return streakConfig;
        }

        public RankingConfigSO GetRankingConfig() {
            if (rankingConfig == null) {
                throw new InvalidOperationException("RankingConfigSO is missing from default assets.");
            }
            return rankingConfig;
        }

        public ProfileConfigSO GetProfileConfig() {
            if (profileConfig == null) {
                throw new InvalidOperationException("ProfileConfigSO is missing from default assets.");
            }
            return profileConfig;
        }

        public ShopConfigSO GetShopConfig() {
            if (shopConfig == null) {
                throw new InvalidOperationException("ShopConfigSO is missing from default assets.");
            }
            return shopConfig;
        }

        public SettingsConfigSO GetSettingsConfig() {
            if (settingsConfig == null) {
                throw new InvalidOperationException("SettingsConfigSO is missing from default assets.");
            }
            return settingsConfig;
        }
        public IReadOnlyList<L10NSO> L10N_GetAll() {
            return texts;
        }

        public IReadOnlyList<L10NFontSO> L10NFont_GetAll() {
            return fonts;
        }

        public void Release() {
            panels.Clear();
            texts.Clear();
            fonts.Clear();
            endlessConfig = null;
            dailyConfig = null;
            homeConfig = null;
            gameConfig = null;
            puzzleRules = null;
            campaignConfig = null;
            puzzlePresentation = null;
            resultConfig = null;
            puzzleById.Clear();
            puzzleList.Clear();
            rankingConfig = null;
            streakConfig = null;
            profileConfig = null;
            settingsConfig = null;
            shopConfig = null;
            registered = false;
            if (defaultHandle.IsValid()) {
                Addressables.Release(defaultHandle);
                defaultHandle = default;
            }
        }
    }
}
