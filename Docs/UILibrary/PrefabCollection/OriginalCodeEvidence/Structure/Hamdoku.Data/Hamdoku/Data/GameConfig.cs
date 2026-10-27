namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Hamdoku/Game Config")]
[Token(Token = "0x2000013")]
public sealed class GameConfig : ScriptableObject
{
	[Token(Token = "0x40000FE")]
	private static GameConfig _instance; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x40000FF")]
	private static Action Changed; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Header("하트/아이템")]
	[Token(Token = "0x400004E")]
	public int maxHearts; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400004F")]
	public int hintsPerLevel; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000050")]
	public int autoCrossPerLevel; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000051")]
	public int startRevealLevels; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000052")]
	public int clearAutoCrossLevels; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Header("일일 퍼즐")]
	[Token(Token = "0x4000053")]
	public int dailySize; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Header("데일리 스트릭")]
	[Token(Token = "0x4000054")]
	public int streakCycleDays; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000055")]
	public int streakRewardDay1; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000056")]
	public int streakRewardDay1Bulb; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000057")]
	public int streakRewardDay1Glass; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000058")]
	public int streakRewardDay2; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000059")]
	public int streakRewardDay2Bulb; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400005A")]
	public int streakRewardDay2Glass; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x400005B")]
	public int streakRewardDay3; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400005C")]
	public int streakRewardDay3Bulb; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x400005D")]
	public int streakRewardDay3Glass; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400005E")]
	public int streakBloomSparkleDay; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400005F")]
	public int streakBloomSproutDay; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000060")]
	public int streakBloomSmallFlowerDay; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000061")]
	public int streakBloomGardenDay; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000062")]
	public int streakBloomBedDay; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000063")]
	public int streakBloomFullBedDay; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000064")]
	public int streakBloomBackRowDay; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000065")]
	public int streakBloomButterflyDay; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000066")]
	public int streakBloomButterfly2Day; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Header("레벨 상자 보상(캠페인 전용)")]
	[Token(Token = "0x4000067")]
	public int levelRewardEnabled; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000068")]
	public int levelRewardStepEarly; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000069")]
	public int levelRewardStepFrom; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400006A")]
	public int levelRewardStepLate; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x400006B")]
	public int levelRewardBulb; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400006C")]
	public int levelRewardGlass; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Header("씨앗 선물(로비 플로팅 햄스터 — 탭하면 그냥 받기/광고 보고 받기)")]
	[Token(Token = "0x400006D")]
	public int seedGiftEnabled; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400006E")]
	public int seedGiftFreeSeeds; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x400006F")]
	public int seedGiftAdSeeds; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000070")]
	public int seedGiftDailyMax; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000071")]
	public int seedGiftAppearClearsMin; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000072")]
	public int seedGiftAppearClearsMax; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Header("황금 해바라기씨 챌린지(캠페인 보너스 판)")]
	[Token(Token = "0x4000073")]
	public int goldenEnabled; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000074")]
	public int goldenStartLevel; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4000075")]
	public int goldenEvery; //Field offset: 0xB4
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000076")]
	public int goldenPerfectSeeds; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x4000077")]
	public int goldenAdSeeds; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Header("데일리 재도전(오늘 몫을 깬 뒤 광고를 보고 한 번 더 — 로비 카드·실패 화면 공용 팝업)")]
	[Token(Token = "0x4000078")]
	public int dailyRetryEnabled; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x4000079")]
	public int dailyRetryMaxPerDay; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Header("데일리 월간 도장판(시즌) + 놓친 날 보충 도전(광고) — 2026-10-11 기획")]
	[Token(Token = "0x400007A")]
	public int dailySeasonEnabled; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x400007B")]
	public int dailySeasonPieces; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400007C")]
	public int dailyMakeupEnabled; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x400007D")]
	public int dailySeasonLegacyPerfectBefore; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Header("햄덕 클럽 30일 멤버십 — 2026-10-16 기획")]
	[Token(Token = "0x400007E")]
	public int clubEnabled; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x400007F")]
	public int clubDays; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000080")]
	public int clubBonusHint; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x4000081")]
	public int clubBonusGuide; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000082")]
	public int clubBonusMax; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4000083")]
	public int clubEligibleStreak; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000084")]
	public int streakRecoverEnabled; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000085")]
	public int streakRecoverMaxGapDays; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000086")]
	public int streakRecoverMinStreak; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Header("무한 모드")]
	[Token(Token = "0x4000087")]
	public int endlessStartSize; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000088")]
	public int endlessMaxSize; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000089")]
	public int endlessStepEvery; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x400008A")]
	public int endlessUnlockClears; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Header("점수 (캠페인 HUD)")]
	[Token(Token = "0x400008B")]
	public int scoreBaseFlat; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400008C")]
	public int scoreBasePerCell; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x400008D")]
	public int scoreStepFlat; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400008E")]
	public int scoreStepPerCell; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x400008F")]
	public float scoreHardMult; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000090")]
	public int scoreGainMax; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x4000091")]
	public float scoreComboTimeout; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Header("결과 통계")]
	[Token(Token = "0x4000092")]
	public int statMode; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x4000093")]
	public bool statShowDetail; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000094")]
	public float statPctMid; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x4000095")]
	public float statPctSharp; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x4000096")]
	public float statPctFloor; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Token(Token = "0x4000097")]
	public float statPctCeil; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000098")]
	public float statPctJitter; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x4000099")]
	public int statMeasuredEnabled; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x400009A")]
	public float statTimeWeight; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x400009B")]
	public float statRankMid; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x400009C")]
	public float statRankSharp; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x400009D")]
	public int statHideAssisted; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x400009E")]
	public int statDailyDecimals; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Header("햄지수 (동기 부여 문구)")]
	[Token(Token = "0x400009F")]
	public int hamqEnabled; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40000A0")]
	public int hamqBase; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Token(Token = "0x40000A1")]
	public int hamqPerCell; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40000A2")]
	public int hamqHardBonus; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x40000A3")]
	public int hamqJitter; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40000A4")]
	public int hamqEnterEvery; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x40000A5")]
	public int hamqClearEnabled; //Field offset: 0x174
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40000A6")]
	public int hamqQuoteEvery; //Field offset: 0x178
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x40000A7")]
	public int hamqEasyBoardMax; //Field offset: 0x17C
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40000A8")]
	public int hamqSpecialWeight; //Field offset: 0x180
	[FieldOffset(Offset = "0x184")]
	[Token(Token = "0x40000A9")]
	public int hamqRateTop; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40000AA")]
	public float hamqRateSlope; //Field offset: 0x188
	[FieldOffset(Offset = "0x18C")]
	[Token(Token = "0x40000AB")]
	public int hamqRateHardPenalty; //Field offset: 0x18C
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40000AC")]
	public int hamqRateFloor; //Field offset: 0x190
	[FieldOffset(Offset = "0x194")]
	[Token(Token = "0x40000AD")]
	public int hamqGainMin; //Field offset: 0x194
	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x40000AE")]
	public int hamqGainMax; //Field offset: 0x198
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x40000AF")]
	public float hamqFastSecPerCell; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x40000B0")]
	public float hamqSlowSecPerCell; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Token(Token = "0x40000B1")]
	public float hamqBannerHold; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x40000B2")]
	public float hamqBannerY; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x40000B3")]
	public float hamqBannerFade; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x40000B4")]
	public float hamqBannerEdge; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B4")]
	[Token(Token = "0x40000B5")]
	public float hamqBannerLineGap; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x40000B6")]
	public float hamqBannerAlpha; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Token(Token = "0x40000B7")]
	public float hamqBannerEdgeAlpha; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x40000B8")]
	public float hamqBannerPadY; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x40000B9")]
	public int hamqBannerHardTitle; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x40000BA")]
	public float hamqBannerTitleScale; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x40000BB")]
	public float hamqBannerTitleGap; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x40000BC")]
	public int hamqBannerHardCheer; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Token(Token = "0x40000BD")]
	public float hamqBannerWaitMax; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x40000BE")]
	public float hamqStartLockSeconds; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x40000BF")]
	public int hamqOnlyMaxPct; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x40000C0")]
	public int hamqRateShowMax; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E4")]
	[Token(Token = "0x40000C1")]
	public float hamqTriesMin; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x40000C2")]
	public int hamqPrevEvery; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[Token(Token = "0x40000C3")]
	public int hamqRetryStatEvery; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x40000C4")]
	public int hamqRetryShareMin; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Header("결과 화면 문구")]
	[Token(Token = "0x40000C5")]
	public int resultCopyEnabled; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x40000C6")]
	public int resultNumberMinPct; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x40000C7")]
	public int resultBandHigh; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x40000C8")]
	public int resultBandMid; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x40000C9")]
	public int resultPraiseEvery; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x40000CA")]
	public int resultGrowthMinPct; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x40000CB")]
	public float resultFastSecPerCell; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x40000CC")]
	public float resultSlowSecPerCell; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Token(Token = "0x40000CD")]
	public int resultFeatureMinBoard; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Header("리더보드")]
	[Token(Token = "0x40000CE")]
	public int rankingDummyMaxLevel; //Field offset: 0x218
	[FieldOffset(Offset = "0x21C")]
	[Token(Token = "0x40000CF")]
	public int rankingDummyWeeklyMax; //Field offset: 0x21C
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x40000D0")]
	public int rankingDummyStreakMax; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x40000D1")]
	public int rankingDummyStreakLaunchDay; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x40000D2")]
	public int rankingGroupSize; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Token(Token = "0x40000D3")]
	public int rankingUnlockClears; //Field offset: 0x22C
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x40000D4")]
	public int dailyUnlockClears; //Field offset: 0x230
	[FieldOffset(Offset = "0x234")]
	[Token(Token = "0x40000D5")]
	public int rankOverlayEnabled; //Field offset: 0x234
	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x40000D6")]
	public int rankReward1Bulb; //Field offset: 0x238
	[FieldOffset(Offset = "0x23C")]
	[Token(Token = "0x40000D7")]
	public int rankReward1Glass; //Field offset: 0x23C
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x40000D8")]
	public int rankReward2Bulb; //Field offset: 0x240
	[FieldOffset(Offset = "0x244")]
	[Token(Token = "0x40000D9")]
	public int rankReward2Glass; //Field offset: 0x244
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x40000DA")]
	public int rankReward3Bulb; //Field offset: 0x248
	[FieldOffset(Offset = "0x24C")]
	[Token(Token = "0x40000DB")]
	public int rankReward3Glass; //Field offset: 0x24C
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x40000DC")]
	public int rankRewardEnabled; //Field offset: 0x250
	[FieldOffset(Offset = "0x258")]
	[Header("프로필")]
	[Token(Token = "0x40000DD")]
	public string profileAvatarUnlocks; //Field offset: 0x258
	[FieldOffset(Offset = "0x260")]
	[Token(Token = "0x40000DE")]
	public string profileFrameUnlocks; //Field offset: 0x260
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x40000DF")]
	public string profileFrameRank1WinUnlocks; //Field offset: 0x268
	[FieldOffset(Offset = "0x270")]
	[Header("사운드")]
	[Range(0, 1)]
	[Token(Token = "0x40000E0")]
	public float bgmVolume; //Field offset: 0x270
	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x40000E1")]
	public string comboSfxTheme; //Field offset: 0x278
	[FieldOffset(Offset = "0x280")]
	[Range(0.5, 1.5)]
	[Token(Token = "0x40000E2")]
	public float comboSfxPitch; //Field offset: 0x280
	[FieldOffset(Offset = "0x284")]
	[Header("성능(렌더링)")]
	[Token(Token = "0x40000E3")]
	public int perfIdleFrameInterval; //Field offset: 0x284
	[FieldOffset(Offset = "0x288")]
	[Token(Token = "0x40000E4")]
	public float perfActiveWindow; //Field offset: 0x288
	[FieldOffset(Offset = "0x28C")]
	[Token(Token = "0x40000E5")]
	public int perfTargetFrameRate; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Header("광고")]
	[Token(Token = "0x40000E6")]
	public int adUnlockClears; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Token(Token = "0x40000E7")]
	public int adUnlockClearsIos; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x40000E8")]
	public int adUnlockClearsAndroid; //Field offset: 0x298
	[FieldOffset(Offset = "0x29C")]
	[Token(Token = "0x40000E9")]
	public int adUnlockSession; //Field offset: 0x29C
	[FieldOffset(Offset = "0x2A0")]
	[Token(Token = "0x40000EA")]
	public int adInterstitialCooldown; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A4")]
	[Token(Token = "0x40000EB")]
	public int adRewardRefillCount; //Field offset: 0x2A4
	[FieldOffset(Offset = "0x2A8")]
	[Token(Token = "0x40000EC")]
	public float adRewardTapDebounce; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Header("화면")]
	[Token(Token = "0x40000ED")]
	public int screenSleepTimeoutSec; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Header("아이템 유도(무입력)")]
	[Token(Token = "0x40000EE")]
	public int itemNudgeIdleSec; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Token(Token = "0x40000EF")]
	public int itemNudgeIdleSecAfterMistake; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x40000F0")]
	public int itemNudgeRepeatSec; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Token(Token = "0x40000F1")]
	public int itemNudgeMaxPerPuzzle; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2C0")]
	[Token(Token = "0x40000F2")]
	public int itemNudgeMinLevel; //Field offset: 0x2C0
	[FieldOffset(Offset = "0x2C4")]
	[Token(Token = "0x40000F3")]
	public int itemNudgeTarget; //Field offset: 0x2C4
	[FieldOffset(Offset = "0x2C8")]
	[Token(Token = "0x40000F4")]
	public int itemNudgeMascot; //Field offset: 0x2C8
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x40000F5")]
	public int itemNudgeMascotCooldownHoursNew; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x40000F6")]
	public int itemNudgeMascotCooldownHours; //Field offset: 0x2D0
	[FieldOffset(Offset = "0x2D4")]
	[Token(Token = "0x40000F7")]
	public int itemNudgeMascotNoUsePuzzles; //Field offset: 0x2D4
	[FieldOffset(Offset = "0x2D8")]
	[Header("리뷰 유도")]
	[Token(Token = "0x40000F8")]
	public int reviewUnlockClears; //Field offset: 0x2D8
	[FieldOffset(Offset = "0x2DC")]
	[Token(Token = "0x40000F9")]
	public int reviewSoftAskIos; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x40000FA")]
	public int reviewSoftAskAndroid; //Field offset: 0x2E0
	[FieldOffset(Offset = "0x2E4")]
	[Token(Token = "0x40000FB")]
	public int reviewMinStarsForStore; //Field offset: 0x2E4
	[FieldOffset(Offset = "0x2E8")]
	[Token(Token = "0x40000FC")]
	public int reviewCooldownDays; //Field offset: 0x2E8
	[FieldOffset(Offset = "0x2EC")]
	[Token(Token = "0x40000FD")]
	public int reviewSuccessCooldownDays; //Field offset: 0x2EC

	[Token(Token = "0x14000001")]
	public static event Action Changed
	{
		[Address(RVA = "0x31E6654", Offset = "0x31E6654", Length = "0xBC")]
		[CompilerGenerated]
		[Token(Token = "0x6000043")]
		 add { } //Length: 188
		[Address(RVA = "0x31E6710", Offset = "0x31E6710", Length = "0xBC")]
		[CompilerGenerated]
		[Token(Token = "0x6000044")]
		 remove { } //Length: 188
	}

	[Token(Token = "0x17000013")]
	public static GameConfig Instance
	{
		[Address(RVA = "0x31E2B9C", Offset = "0x31E2B9C", Length = "0xDC")]
		[Token(Token = "0x6000042")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x31E6F5C", Offset = "0x31E6F5C", Length = "0x378")]
	[Token(Token = "0x6000046")]
	public GameConfig() { }

	[Address(RVA = "0x31E6654", Offset = "0x31E6654", Length = "0xBC")]
	[CompilerGenerated]
	[Token(Token = "0x6000043")]
	public static void add_Changed(Action value) { }

	[Address(RVA = "0x31E67CC", Offset = "0x31E67CC", Length = "0x790")]
	[Token(Token = "0x6000045")]
	public void ApplyKeyValues(IEnumerable<KeyValuePair<string, string>> rows) { }

	[Address(RVA = "0x31E2B9C", Offset = "0x31E2B9C", Length = "0xDC")]
	[Token(Token = "0x6000042")]
	public static GameConfig get_Instance() { }

	[Address(RVA = "0x31E6710", Offset = "0x31E6710", Length = "0xBC")]
	[CompilerGenerated]
	[Token(Token = "0x6000044")]
	public static void remove_Changed(Action value) { }

}

