namespace Hamdoku.Managers;

[Token(Token = "0x20001C3")]
public static class LevelRewardService
{
	[Token(Token = "0x4000B07")]
	private const string ClaimedKey = "Hamdoku.LevelReward.ClaimedUpTo"; //Field offset: 0x0
	[Token(Token = "0x4000B08")]
	private const string BaselineKey = "Hamdoku.LevelReward.Baseline"; //Field offset: 0x0
	[Token(Token = "0x4000B09")]
	private const string LogReason = "LevelReward"; //Field offset: 0x0
	[Token(Token = "0x4000B0A")]
	public const string GiftSpritePath = "UI/StreakGift"; //Field offset: 0x0

	[Token(Token = "0x170001C2")]
	public static bool Active
	{
		[Address(RVA = "0x323C214", Offset = "0x323C214", Length = "0x3C")]
		[Token(Token = "0x6000CB4")]
		 get { } //Length: 60
	}

	[Token(Token = "0x170001BF")]
	public static int Bulb
	{
		[Address(RVA = "0x323C0AC", Offset = "0x323C0AC", Length = "0x90")]
		[Token(Token = "0x6000CB1")]
		 get { } //Length: 144
	}

	[Token(Token = "0x170001BA")]
	private static GameConfig Cfg
	{
		[Address(RVA = "0x323BE58", Offset = "0x323BE58", Length = "0x8")]
		[Token(Token = "0x6000CAC")]
		 get { } //Length: 8
	}

	[Token(Token = "0x170001C1")]
	public static int ClaimedUpTo
	{
		[Address(RVA = "0x323C1CC", Offset = "0x323C1CC", Length = "0x48")]
		[Token(Token = "0x6000CB3")]
		 get { } //Length: 72
	}

	[Token(Token = "0x170001BB")]
	public static bool Enabled
	{
		[Address(RVA = "0x323BE60", Offset = "0x323BE60", Length = "0x94")]
		[Token(Token = "0x6000CAD")]
		 get { } //Length: 148
	}

	[Token(Token = "0x170001C0")]
	public static int Glass
	{
		[Address(RVA = "0x323C13C", Offset = "0x323C13C", Length = "0x90")]
		[Token(Token = "0x6000CB2")]
		 get { } //Length: 144
	}

	[Token(Token = "0x170001BC")]
	public static int StepEarly
	{
		[Address(RVA = "0x323BEF4", Offset = "0x323BEF4", Length = "0x94")]
		[Token(Token = "0x6000CAE")]
		 get { } //Length: 148
	}

	[Token(Token = "0x170001BE")]
	public static int StepFrom
	{
		[Address(RVA = "0x323C01C", Offset = "0x323C01C", Length = "0x90")]
		[Token(Token = "0x6000CB0")]
		 get { } //Length: 144
	}

	[Token(Token = "0x170001BD")]
	public static int StepLate
	{
		[Address(RVA = "0x323BF88", Offset = "0x323BF88", Length = "0x94")]
		[Token(Token = "0x6000CAF")]
		 get { } //Length: 148
	}

	[Address(RVA = "0x323C3FC", Offset = "0x323C3FC", Length = "0xC4")]
	[Token(Token = "0x6000CB8")]
	public static void EnsureBaseline(int reachedLevel) { }

	[Address(RVA = "0x323C214", Offset = "0x323C214", Length = "0x3C")]
	[Token(Token = "0x6000CB4")]
	public static bool get_Active() { }

	[Address(RVA = "0x323C0AC", Offset = "0x323C0AC", Length = "0x90")]
	[Token(Token = "0x6000CB1")]
	public static int get_Bulb() { }

	[Address(RVA = "0x323BE58", Offset = "0x323BE58", Length = "0x8")]
	[Token(Token = "0x6000CAC")]
	private static GameConfig get_Cfg() { }

	[Address(RVA = "0x323C1CC", Offset = "0x323C1CC", Length = "0x48")]
	[Token(Token = "0x6000CB3")]
	public static int get_ClaimedUpTo() { }

	[Address(RVA = "0x323BE60", Offset = "0x323BE60", Length = "0x94")]
	[Token(Token = "0x6000CAD")]
	public static bool get_Enabled() { }

	[Address(RVA = "0x323C13C", Offset = "0x323C13C", Length = "0x90")]
	[Token(Token = "0x6000CB2")]
	public static int get_Glass() { }

	[Address(RVA = "0x323BEF4", Offset = "0x323BEF4", Length = "0x94")]
	[Token(Token = "0x6000CAE")]
	public static int get_StepEarly() { }

	[Address(RVA = "0x323C01C", Offset = "0x323C01C", Length = "0x90")]
	[Token(Token = "0x6000CB0")]
	public static int get_StepFrom() { }

	[Address(RVA = "0x323BF88", Offset = "0x323BF88", Length = "0x94")]
	[Token(Token = "0x6000CAF")]
	public static int get_StepLate() { }

	[Address(RVA = "0x323C5E4", Offset = "0x323C5E4", Length = "0x25C")]
	[Token(Token = "0x6000CBD")]
	public static bool Grant(int level, int bulb, int glass, bool doubled) { }

	[Address(RVA = "0x323C37C", Offset = "0x323C37C", Length = "0x34")]
	[Token(Token = "0x6000CB7")]
	public static int HighestMilestoneAtOrBefore(int level) { }

	[Address(RVA = "0x323C350", Offset = "0x323C350", Length = "0x2C")]
	[Token(Token = "0x6000CB6")]
	public static bool IsMilestone(int level) { }

	[Address(RVA = "0x323C250", Offset = "0x323C250", Length = "0x100")]
	[Token(Token = "0x6000CB5")]
	public static int NextMilestoneAtOrAfter(int level) { }

	[Address(RVA = "0x323C4C4", Offset = "0x323C4C4", Length = "0x60")]
	[Token(Token = "0x6000CBB")]
	public static int PendingMilestone(int reachedLevel) { }

	[Address(RVA = "0x323C840", Offset = "0x323C840", Length = "0x4C")]
	[Token(Token = "0x6000CBE")]
	public static void ResetForCheat() { }

	[Address(RVA = "0x323C4C0", Offset = "0x323C4C0", Length = "0x4")]
	[Token(Token = "0x6000CB9")]
	public static void RewindIfAheadForDev(int reachedLevel) { }

	[Address(RVA = "0x323C3B0", Offset = "0x323C3B0", Length = "0x4C")]
	[Token(Token = "0x6000CBA")]
	public static int SegmentStart(int milestone) { }

	[Address(RVA = "0x323C524", Offset = "0x323C524", Length = "0xC0")]
	[Token(Token = "0x6000CBC")]
	public static bool TryGetProgress(int reachedLevel, out int filled, out int total, out int remaining) { }

}

