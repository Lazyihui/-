namespace Hamdoku.Managers;

[Token(Token = "0x200008D")]
public static class FirebaseBootstrap
{
	[CompilerGenerated]
	[Token(Token = "0x200008F")]
	private sealed class <>c
	{
		[Token(Token = "0x40002D4")]
		public static readonly <>c <>9; //Field offset: 0x0
		[Token(Token = "0x40002D5")]
		public static Action<Task<DependencyStatus>> <>9__15_0; //Field offset: 0x8
		[Token(Token = "0x40002D6")]
		public static Action<Task<AuthResult>> <>9__18_0; //Field offset: 0x10
		[Token(Token = "0x40002D7")]
		public static Action<Task> <>9__44_0; //Field offset: 0x18

		[Address(RVA = "0x32227DC", Offset = "0x32227DC", Length = "0x68")]
		[Token(Token = "0x60002D6")]
		private static <>c() { }

		[Address(RVA = "0x3222844", Offset = "0x3222844", Length = "0x8")]
		[Token(Token = "0x60002D7")]
		public <>c() { }

		[Address(RVA = "0x3222A60", Offset = "0x3222A60", Length = "0x1A8")]
		[Token(Token = "0x60002D9")]
		internal void <InitAuth>b__18_0(Task<AuthResult> task) { }

		[Address(RVA = "0x322284C", Offset = "0x322284C", Length = "0x214")]
		[Token(Token = "0x60002D8")]
		internal void <Initialize>b__15_0(Task<DependencyStatus> task) { }

		[Address(RVA = "0x3222C08", Offset = "0x3222C08", Length = "0xD0")]
		[Token(Token = "0x60002DA")]
		internal void <InitMessaging>b__44_0(Task t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000090")]
	private sealed class <>c__DisplayClass19_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002D8")]
		public FirebaseUser user; //Field offset: 0x10

		[Address(RVA = "0x322077C", Offset = "0x322077C", Length = "0x8")]
		[Token(Token = "0x60002DB")]
		public <>c__DisplayClass19_0() { }

		[Address(RVA = "0x3222CD8", Offset = "0x3222CD8", Length = "0x58")]
		[Token(Token = "0x60002DC")]
		internal void <OnSignedIn>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000091")]
	private sealed class <>c__DisplayClass20_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002D9")]
		public FirebaseUser user; //Field offset: 0x10

		[Address(RVA = "0x3220958", Offset = "0x3220958", Length = "0x8")]
		[Token(Token = "0x60002DD")]
		public <>c__DisplayClass20_0() { }

		[Address(RVA = "0x3222D30", Offset = "0x3222D30", Length = "0xAC")]
		[Token(Token = "0x60002DE")]
		internal void <OnSignedInAfterPendingCheck>b__0(FirebaseUser final, bool switched) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000092")]
	private sealed class <>c__DisplayClass29_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002DA")]
		public FirebaseRemoteConfig rc; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40002DB")]
		public Action<Task> <>9__1; //Field offset: 0x18

		[Address(RVA = "0x322189C", Offset = "0x322189C", Length = "0x8")]
		[Token(Token = "0x60002DF")]
		public <>c__DisplayClass29_0() { }

		[Address(RVA = "0x3222DDC", Offset = "0x3222DDC", Length = "0x114")]
		[Token(Token = "0x60002E0")]
		internal void <InitRemoteConfig>b__0(Task _) { }

		[Address(RVA = "0x3222EF0", Offset = "0x3222EF0", Length = "0xF0")]
		[Token(Token = "0x60002E1")]
		internal void <InitRemoteConfig>b__1(Task __) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000093")]
	private sealed class <>c__DisplayClass34_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002DC")]
		public FirebaseRemoteConfig rc; //Field offset: 0x10

		[Address(RVA = "0x32219E0", Offset = "0x32219E0", Length = "0x8")]
		[Token(Token = "0x60002E2")]
		public <>c__DisplayClass34_0() { }

		[Address(RVA = "0x3222FE0", Offset = "0x3222FE0", Length = "0x228")]
		[Token(Token = "0x60002E3")]
		internal void <FetchAndApply>b__0(Task<bool> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000094")]
	private sealed class <>c__DisplayClass35_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002DD")]
		public FirebaseRemoteConfig rc; //Field offset: 0x10

		[Address(RVA = "0x3221BD4", Offset = "0x3221BD4", Length = "0x8")]
		[Token(Token = "0x60002E4")]
		public <>c__DisplayClass35_0() { }

		[Address(RVA = "0x3223208", Offset = "0x3223208", Length = "0x158")]
		[Token(Token = "0x60002E5")]
		internal void <RefreshForceUpdateOnForeground>b__0(Task<bool> t) { }

	}

	[Token(Token = "0x200008E")]
	private sealed class RemoteConfigRefresher : MonoBehaviour
	{
		[Token(Token = "0x40002D2")]
		private static RemoteConfigRefresher _instance; //Field offset: 0x0
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40002D3")]
		private bool _wasBackground; //Field offset: 0x20

		[Address(RVA = "0x32227D4", Offset = "0x32227D4", Length = "0x8")]
		[Token(Token = "0x60002D5")]
		public RemoteConfigRefresher() { }

		[Address(RVA = "0x3222620", Offset = "0x3222620", Length = "0x128")]
		[Token(Token = "0x60002D1")]
		public static void Ensure() { }

		[Address(RVA = "0x32227C8", Offset = "0x32227C8", Length = "0xC")]
		[Token(Token = "0x60002D3")]
		private void OnApplicationFocus(bool focused) { }

		[Address(RVA = "0x3222748", Offset = "0x3222748", Length = "0x4")]
		[Token(Token = "0x60002D2")]
		private void OnApplicationPause(bool paused) { }

		[Address(RVA = "0x322274C", Offset = "0x322274C", Length = "0x7C")]
		[Token(Token = "0x60002D4")]
		private void OnBackgroundChanged(bool background) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x40002C8")]
	private static bool <IsReady>k__BackingField; //Field offset: 0x0
	[Token(Token = "0x40002CD")]
	private const ulong ReleaseFetchIntervalMs = 3600000; //Field offset: 0x0
	[Token(Token = "0x40002CE")]
	private const double ForegroundRetryBackoffSeconds = 300; //Field offset: 0x0
	[Token(Token = "0x40002D1")]
	private const string ItemNudgeRcKey = "item_nudge_idle_sec"; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x40002C9")]
	private static bool <FreshInstall>k__BackingField; //Field offset: 0x1
	[CompilerGenerated]
	[Token(Token = "0x40002CA")]
	private static bool <IdentitySettled>k__BackingField; //Field offset: 0x2
	[Token(Token = "0x40002CB")]
	private static FirebaseApp _app; //Field offset: 0x8
	[Token(Token = "0x40002CC")]
	private static string _identityUid; //Field offset: 0x10
	[Token(Token = "0x40002CF")]
	private static bool _fetchInFlight; //Field offset: 0x18
	[Token(Token = "0x40002D0")]
	private static double _lastFetchAttemptRealtime; //Field offset: 0x20

	[Token(Token = "0x1700004A")]
	public static bool FreshInstall
	{
		[Address(RVA = "0x321FB90", Offset = "0x321FB90", Length = "0x58")]
		[CompilerGenerated]
		[Token(Token = "0x60002B1")]
		 get { } //Length: 88
		[Address(RVA = "0x321FBE8", Offset = "0x321FBE8", Length = "0x60")]
		[CompilerGenerated]
		[Token(Token = "0x60002B2")]
		private set { } //Length: 96
	}

	[Token(Token = "0x1700004B")]
	public static bool IdentitySettled
	{
		[Address(RVA = "0x321FC48", Offset = "0x321FC48", Length = "0x58")]
		[CompilerGenerated]
		[Token(Token = "0x60002B3")]
		 get { } //Length: 88
		[Address(RVA = "0x321FCA0", Offset = "0x321FCA0", Length = "0x60")]
		[CompilerGenerated]
		[Token(Token = "0x60002B4")]
		private set { } //Length: 96
	}

	[Token(Token = "0x17000049")]
	public static bool IsReady
	{
		[Address(RVA = "0x321FAD8", Offset = "0x321FAD8", Length = "0x58")]
		[CompilerGenerated]
		[Token(Token = "0x60002AF")]
		 get { } //Length: 88
		[Address(RVA = "0x321FB30", Offset = "0x321FB30", Length = "0x60")]
		[CompilerGenerated]
		[Token(Token = "0x60002B0")]
		private set { } //Length: 96
	}

	[Address(RVA = "0x32225D4", Offset = "0x32225D4", Length = "0x4C")]
	[Token(Token = "0x60002D0")]
	private static FirebaseBootstrap() { }

	[Address(RVA = "0x3221C68", Offset = "0x3221C68", Length = "0x12C")]
	[Token(Token = "0x60002C7")]
	private static void ApplyAccountRecoveryFlags(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x3222230", Offset = "0x3222230", Length = "0xE0")]
	[Token(Token = "0x60002CB")]
	private static void ApplyAdInterstitialCooldown(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x3222120", Offset = "0x3222120", Length = "0x110")]
	[Token(Token = "0x60002CA")]
	private static void ApplyComboSfxTheme(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x3221D94", Offset = "0x3221D94", Length = "0xA8")]
	[Token(Token = "0x60002C8")]
	private static void ApplyGameCenterFlag(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x3220960", Offset = "0x3220960", Length = "0x2A0")]
	[Token(Token = "0x60002BF")]
	private static void ApplyIdentity(FirebaseUser user) { }

	[Address(RVA = "0x3222310", Offset = "0x3222310", Length = "0xE0")]
	[Token(Token = "0x60002CC")]
	private static void ApplyItemNudge(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x321FE2C", Offset = "0x321FE2C", Length = "0xE4")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	[Token(Token = "0x60002B6")]
	private static void AutoBoot() { }

	[Address(RVA = "0x3220EC4", Offset = "0x3220EC4", Length = "0x230")]
	[Token(Token = "0x60002C0")]
	private static void CacheAccountStartDate(FirebaseUser user) { }

	[Address(RVA = "0x3221E3C", Offset = "0x3221E3C", Length = "0x114")]
	[Token(Token = "0x60002C9")]
	private static void EvaluateForceUpdate(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x32218A4", Offset = "0x32218A4", Length = "0x13C")]
	[Token(Token = "0x60002C5")]
	private static void FetchAndApply(FirebaseRemoteConfig rc) { }

	[Address(RVA = "0x321FB90", Offset = "0x321FB90", Length = "0x58")]
	[CompilerGenerated]
	[Token(Token = "0x60002B1")]
	public static bool get_FreshInstall() { }

	[Address(RVA = "0x321FC48", Offset = "0x321FC48", Length = "0x58")]
	[CompilerGenerated]
	[Token(Token = "0x60002B3")]
	public static bool get_IdentitySettled() { }

	[Address(RVA = "0x321FAD8", Offset = "0x321FAD8", Length = "0x58")]
	[CompilerGenerated]
	[Token(Token = "0x60002AF")]
	public static bool get_IsReady() { }

	[Address(RVA = "0x3220064", Offset = "0x3220064", Length = "0x12C")]
	[Token(Token = "0x60002B8")]
	private static void InitAppCheck() { }

	[Address(RVA = "0x3220378", Offset = "0x3220378", Length = "0x230")]
	[Token(Token = "0x60002BA")]
	private static void InitAuth() { }

	[Address(RVA = "0x3221368", Offset = "0x3221368", Length = "0x98")]
	[Token(Token = "0x60002C3")]
	private static void InitCrashlytics() { }

	[Address(RVA = "0x321FF10", Offset = "0x321FF10", Length = "0x154")]
	[Token(Token = "0x60002B7")]
	private static void Initialize() { }

	[Address(RVA = "0x32223F0", Offset = "0x32223F0", Length = "0x1A4")]
	[Token(Token = "0x60002CD")]
	private static void InitMessaging() { }

	[Address(RVA = "0x3221400", Offset = "0x3221400", Length = "0x49C")]
	[Token(Token = "0x60002C4")]
	private static void InitRemoteConfig() { }

	[Address(RVA = "0x3220190", Offset = "0x3220190", Length = "0x1E8")]
	[Token(Token = "0x60002B9")]
	private static void InitUserProperties() { }

	[Address(RVA = "0x3220E00", Offset = "0x3220E00", Length = "0xC4")]
	[Token(Token = "0x60002BE")]
	public static void NotifySignedInAfterAccountSwitch(FirebaseUser user) { }

	[Address(RVA = "0x32225AC", Offset = "0x32225AC", Length = "0x28")]
	[Token(Token = "0x60002CF")]
	private static void OnFcmMessageReceived(object sender, MessageReceivedEventArgs e) { }

	[Address(RVA = "0x3222594", Offset = "0x3222594", Length = "0x18")]
	[Token(Token = "0x60002CE")]
	private static void OnFcmTokenReceived(object sender, TokenReceivedEventArgs e) { }

	[Address(RVA = "0x32205A8", Offset = "0x32205A8", Length = "0x1D4")]
	[Token(Token = "0x60002BB")]
	private static void OnSignedIn(FirebaseUser user) { }

	[Address(RVA = "0x3220784", Offset = "0x3220784", Length = "0x1D4")]
	[Token(Token = "0x60002BC")]
	private static void OnSignedInAfterPendingCheck(FirebaseUser user) { }

	[Address(RVA = "0x3220C00", Offset = "0x3220C00", Length = "0xEC")]
	[Token(Token = "0x60002C2")]
	private static void PropagateCloud(FirebaseUser user, bool accountSwitched) { }

	[Address(RVA = "0x3221274", Offset = "0x3221274", Length = "0xF4")]
	[Token(Token = "0x60002C1")]
	public static void ReapplyIdentityAfterDeletionCancel(FirebaseUser user) { }

	[Address(RVA = "0x3220CEC", Offset = "0x3220CEC", Length = "0x114")]
	[Token(Token = "0x60002BD")]
	public static void RebootAuth() { }

	[Address(RVA = "0x32219E8", Offset = "0x32219E8", Length = "0x1EC")]
	[Token(Token = "0x60002C6")]
	private static void RefreshForceUpdateOnForeground() { }

	[Address(RVA = "0x321FD00", Offset = "0x321FD00", Length = "0x12C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x60002B5")]
	private static void ResetStatics() { }

	[Address(RVA = "0x321FBE8", Offset = "0x321FBE8", Length = "0x60")]
	[CompilerGenerated]
	[Token(Token = "0x60002B2")]
	private static void set_FreshInstall(bool value) { }

	[Address(RVA = "0x321FCA0", Offset = "0x321FCA0", Length = "0x60")]
	[CompilerGenerated]
	[Token(Token = "0x60002B4")]
	private static void set_IdentitySettled(bool value) { }

	[Address(RVA = "0x321FB30", Offset = "0x321FB30", Length = "0x60")]
	[CompilerGenerated]
	[Token(Token = "0x60002B0")]
	private static void set_IsReady(bool value) { }

}

