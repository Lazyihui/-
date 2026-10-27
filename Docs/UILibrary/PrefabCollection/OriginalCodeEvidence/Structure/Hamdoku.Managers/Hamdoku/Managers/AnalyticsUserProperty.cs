namespace Hamdoku.Managers;

[Token(Token = "0x200006B")]
public static class AnalyticsUserProperty
{
	[Token(Token = "0x4000232")]
	private const string PP_PREFIX = "up."; //Field offset: 0x0
	[Token(Token = "0x4000233")]
	private static readonly TimeZoneInfo Kst; //Field offset: 0x0
	[Token(Token = "0x4000235")]
	private const string PP_USER_ID_FALLBACK = "analytics.user_id_fallback"; //Field offset: 0x0
	[Token(Token = "0x4000236")]
	private const string PP_FIREBASE_AUTH_UID = "firebase.auth.uid"; //Field offset: 0x0
	[Token(Token = "0x4000234")]
	private static readonly CultureInfo Inv; //Field offset: 0x8
	[Token(Token = "0x4000237")]
	private static string _cachedUserId; //Field offset: 0x10
	[CompilerGenerated]
	[Token(Token = "0x4000238")]
	private static bool <IsAuthReady>k__BackingField; //Field offset: 0x18

	[Token(Token = "0x17000039")]
	public static string CachedAuthUid
	{
		[Address(RVA = "0x3211F08", Offset = "0x3211F08", Length = "0x5C")]
		[Token(Token = "0x60001FB")]
		 get { } //Length: 92
	}

	[Token(Token = "0x1700003A")]
	public static string InstallDate
	{
		[Address(RVA = "0x32122E0", Offset = "0x32122E0", Length = "0x5C")]
		[Token(Token = "0x6000205")]
		 get { } //Length: 92
	}

	[Token(Token = "0x17000038")]
	public static bool IsAuthReady
	{
		[Address(RVA = "0x3211DC0", Offset = "0x3211DC0", Length = "0x58")]
		[CompilerGenerated]
		[Token(Token = "0x60001F8")]
		 get { } //Length: 88
		[Address(RVA = "0x3211E18", Offset = "0x3211E18", Length = "0x60")]
		[CompilerGenerated]
		[Token(Token = "0x60001F9")]
		private set { } //Length: 96
	}

	[Address(RVA = "0x3212408", Offset = "0x3212408", Length = "0x128")]
	[Token(Token = "0x600020B")]
	private static AnalyticsUserProperty() { }

	[Address(RVA = "0x320EC00", Offset = "0x320EC00", Length = "0x8C")]
	[Token(Token = "0x60001F1")]
	public static void AddAdRevenue(double usdRevenue) { }

	[Address(RVA = "0x3211498", Offset = "0x3211498", Length = "0x90")]
	[Token(Token = "0x60001ED")]
	public static void AddPlaytime(long seconds) { }

	[Address(RVA = "0x320FDA0", Offset = "0x320FDA0", Length = "0xA8")]
	[Token(Token = "0x60001EB")]
	public static void BeforeLogTick() { }

	[Address(RVA = "0x3210928", Offset = "0x3210928", Length = "0x2A0")]
	[Token(Token = "0x60001EA")]
	public static void EnsureFirstInstall(string serverChannel) { }

	[Address(RVA = "0x320C258", Offset = "0x320C258", Length = "0x1FC")]
	[Token(Token = "0x60001FD")]
	public static string EnsureUserId() { }

	[Address(RVA = "0x32111E8", Offset = "0x32111E8", Length = "0x2B0")]
	[Token(Token = "0x6000207")]
	public static void FlushAll() { }

	[Address(RVA = "0x3211F08", Offset = "0x3211F08", Length = "0x5C")]
	[Token(Token = "0x60001FB")]
	public static string get_CachedAuthUid() { }

	[Address(RVA = "0x32122E0", Offset = "0x32122E0", Length = "0x5C")]
	[Token(Token = "0x6000205")]
	public static string get_InstallDate() { }

	[Address(RVA = "0x3211DC0", Offset = "0x3211DC0", Length = "0x58")]
	[CompilerGenerated]
	[Token(Token = "0x60001F8")]
	public static bool get_IsAuthReady() { }

	[Address(RVA = "0x321173C", Offset = "0x321173C", Length = "0x6C")]
	[Token(Token = "0x60001EF")]
	public static int GetBestStage() { }

	[Address(RVA = "0x32117A8", Offset = "0x32117A8", Length = "0xE0")]
	[Token(Token = "0x6000203")]
	private static double GetDouble(string key, double fallback) { }

	[Address(RVA = "0x321165C", Offset = "0x321165C", Length = "0xE0")]
	[Token(Token = "0x6000202")]
	private static long GetLong(string key, long fallback) { }

	[Address(RVA = "0x3212054", Offset = "0x3212054", Length = "0x28C")]
	[Token(Token = "0x60001FE")]
	private static string HashSha256(string input) { }

	[Address(RVA = "0x3210BC8", Offset = "0x3210BC8", Length = "0xA4")]
	[Token(Token = "0x6000204")]
	private static bool HasLocal(string key) { }

	[Address(RVA = "0x320EC8C", Offset = "0x320EC8C", Length = "0x78")]
	[Token(Token = "0x60001F2")]
	public static void IncrementAdViewCount() { }

	[Address(RVA = "0x3210C6C", Offset = "0x3210C6C", Length = "0x134")]
	[Token(Token = "0x6000209")]
	public static string NowKstString() { }

	[Address(RVA = "0x3211A74", Offset = "0x3211A74", Length = "0xDC")]
	[Token(Token = "0x6000206")]
	private static void Push(string key, string value) { }

	[Address(RVA = "0x321233C", Offset = "0x321233C", Length = "0xCC")]
	[Token(Token = "0x6000208")]
	private static void PushIfPresent(string key) { }

	[Address(RVA = "0x320FAFC", Offset = "0x320FAFC", Length = "0x174")]
	[Token(Token = "0x60001F0")]
	public static void RecordPurchase(double usd) { }

	[Address(RVA = "0x3211E78", Offset = "0x3211E78", Length = "0x90")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x60001FA")]
	private static void ResetStatics() { }

	[Address(RVA = "0x3211E18", Offset = "0x3211E18", Length = "0x60")]
	[CompilerGenerated]
	[Token(Token = "0x60001F9")]
	private static void set_IsAuthReady(bool value) { }

	[Address(RVA = "0x3211B50", Offset = "0x3211B50", Length = "0x138")]
	[Token(Token = "0x60001F5")]
	public static void SetAdCooldownVariant(string seconds) { }

	[Address(RVA = "0x3211888", Offset = "0x3211888", Length = "0xB4")]
	[Token(Token = "0x60001F3")]
	public static void SetAdRemoved(bool removed) { }

	[Address(RVA = "0x3210FE8", Offset = "0x3210FE8", Length = "0x108")]
	[Token(Token = "0x60001F7")]
	public static void SetAutoX(bool owned) { }

	[Address(RVA = "0x321193C", Offset = "0x321193C", Length = "0x138")]
	[Token(Token = "0x60001F4")]
	public static void SetComboSfxVariant(string theme) { }

	[Address(RVA = "0x3210F18", Offset = "0x3210F18", Length = "0xD0")]
	[Token(Token = "0x6000201")]
	private static void SetDouble(string key, double value) { }

	[Address(RVA = "0x3211F64", Offset = "0x3211F64", Length = "0xF0")]
	[Token(Token = "0x60001FC")]
	public static void SetFirebaseAuthUid(string uid) { }

	[Address(RVA = "0x3211C88", Offset = "0x3211C88", Length = "0x138")]
	[Token(Token = "0x60001F6")]
	public static void SetItemNudgeVariant(string variant) { }

	[Address(RVA = "0x3210E60", Offset = "0x3210E60", Length = "0xB8")]
	[Token(Token = "0x6000200")]
	private static void SetLong(string key, long value) { }

	[Address(RVA = "0x3210DA0", Offset = "0x3210DA0", Length = "0xC0")]
	[Token(Token = "0x60001FF")]
	private static void SetString(string key, string value) { }

	[Address(RVA = "0x3211528", Offset = "0x3211528", Length = "0x134")]
	[Token(Token = "0x600020A")]
	public static string TodayKstDate() { }

	[Address(RVA = "0x32110F0", Offset = "0x32110F0", Length = "0xF8")]
	[Token(Token = "0x60001EC")]
	private static void TouchDailyLogin() { }

	[Address(RVA = "0x320E3A0", Offset = "0x320E3A0", Length = "0xA0")]
	[Token(Token = "0x60001EE")]
	public static void UpdateBestStage(int stage) { }

}

