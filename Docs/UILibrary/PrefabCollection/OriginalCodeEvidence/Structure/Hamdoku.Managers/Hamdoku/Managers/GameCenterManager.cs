namespace Hamdoku.Managers;

[Token(Token = "0x20000A4")]
public static class GameCenterManager
{
	[CompilerGenerated]
	[Token(Token = "0x20000AA")]
	private sealed class <>c__DisplayClass56_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400037A")]
		public string id; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400037B")]
		public GcLeaderboard lb; //Field offset: 0x18

		[Address(RVA = "0x3301A78", Offset = "0x3301A78", Length = "0x8")]
		[Token(Token = "0x6000365")]
		public <>c__DisplayClass56_0() { }

		[Address(RVA = "0x3301AA8", Offset = "0x3301AA8", Length = "0x40")]
		[Token(Token = "0x6000366")]
		internal bool <Submit>b__0(PendingScore s) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000AB")]
	private sealed class <>c__DisplayClass57_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400037C")]
		public string id; //Field offset: 0x10

		[Address(RVA = "0x3301A8C", Offset = "0x3301A8C", Length = "0x8")]
		[Token(Token = "0x6000367")]
		public <>c__DisplayClass57_0() { }

		[Address(RVA = "0x3301AE8", Offset = "0x3301AE8", Length = "0x20")]
		[Token(Token = "0x6000368")]
		internal bool <RequeueFailedScore>b__0(PendingScore s) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000AC")]
	private sealed class <>c__DisplayClass58_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400037D")]
		public string id; //Field offset: 0x10

		[Address(RVA = "0x3301A94", Offset = "0x3301A94", Length = "0x8")]
		[Token(Token = "0x6000369")]
		public <>c__DisplayClass58_0() { }

		[Address(RVA = "0x3301B08", Offset = "0x3301B08", Length = "0x20")]
		[Token(Token = "0x600036A")]
		internal bool <Report>b__0(PendingAch a) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000AD")]
	private sealed class <AuthenticateAfter>d__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400037E")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400037F")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000380")]
		public float delay; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000381")]
		private float <t>5__2; //Field offset: 0x24

		[Token(Token = "0x17000059")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3301BB0", Offset = "0x3301BB0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600036E")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700005A")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3301BF0", Offset = "0x3301BF0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000370")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32FFF24", Offset = "0x32FFF24", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600036B")]
		public <AuthenticateAfter>d__30(int <>1__state) { }

		[Address(RVA = "0x3301B2C", Offset = "0x3301B2C", Length = "0x84")]
		[Token(Token = "0x600036D")]
		private bool MoveNext() { }

		[Address(RVA = "0x3301BB0", Offset = "0x3301BB0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600036E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3301BF0", Offset = "0x3301BF0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000370")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3301BB8", Offset = "0x3301BB8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600036F")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3301B28", Offset = "0x3301B28", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600036C")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x20000A5")]
	public struct ClearInfo
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000366")]
		public bool campaign; //Field offset: 0x0
		[FieldOffset(Offset = "0x1")]
		[Token(Token = "0x4000367")]
		public bool daily; //Field offset: 0x1
		[FieldOffset(Offset = "0x2")]
		[Token(Token = "0x4000368")]
		public bool dailyFirstToday; //Field offset: 0x2
		[FieldOffset(Offset = "0x3")]
		[Token(Token = "0x4000369")]
		public bool dailyNewBest; //Field offset: 0x3
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x400036A")]
		public int clearsWithThis; //Field offset: 0x4
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400036B")]
		public int boardSize; //Field offset: 0x8
		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x400036C")]
		public bool usedHelp; //Field offset: 0xC
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400036D")]
		public int faults; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x400036E")]
		public int bestCombo; //Field offset: 0x14
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400036F")]
		public float timeSec; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000370")]
		public int streakDays; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000371")]
		public bool hard; //Field offset: 0x20

	}

	[Token(Token = "0x20000A9")]
	private static class Native
	{

		[Address(RVA = "0x32FFF78", Offset = "0x32FFF78", Length = "0x4")]
		[Token(Token = "0x600035C")]
		public static void Authenticate() { }

		[Address(RVA = "0x33001D8", Offset = "0x33001D8", Length = "0x40")]
		[Token(Token = "0x600035D")]
		public static string PlayerAlias() { }

		[Address(RVA = "0x3301A9C", Offset = "0x3301A9C", Length = "0x4")]
		[Token(Token = "0x600035F")]
		public static void ReportAchievement(string id, double p, bool b) { }

		[Address(RVA = "0x3301694", Offset = "0x3301694", Length = "0x4")]
		[Token(Token = "0x6000364")]
		public static void ResetAchievements() { }

		[Address(RVA = "0x32FFF7C", Offset = "0x32FFF7C", Length = "0x4")]
		[Token(Token = "0x6000363")]
		public static void SetAccessPoint(bool a, int loc, bool h) { }

		[Address(RVA = "0x32FFF20", Offset = "0x32FFF20", Length = "0x4")]
		[Token(Token = "0x600035B")]
		public static void SetReceiver(string n) { }

		[Address(RVA = "0x3301508", Offset = "0x3301508", Length = "0x4")]
		[Token(Token = "0x6000361")]
		public static void ShowAchievements() { }

		[Address(RVA = "0x3301538", Offset = "0x3301538", Length = "0x4")]
		[Token(Token = "0x6000362")]
		public static void ShowDashboard() { }

		[Address(RVA = "0x33014D8", Offset = "0x33014D8", Length = "0x4")]
		[Token(Token = "0x6000360")]
		public static void ShowLeaderboard(string id) { }

		[Address(RVA = "0x3301A80", Offset = "0x3301A80", Length = "0x4")]
		[Token(Token = "0x600035E")]
		public static void SubmitScore(string id, long s, long ctx) { }

	}

	[Token(Token = "0x20000A7")]
	private class PendingAch
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000375")]
		public string id; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000376")]
		public double percent; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000377")]
		public bool banner; //Field offset: 0x20

		[Address(RVA = "0x3301AA0", Offset = "0x3301AA0", Length = "0x8")]
		[Token(Token = "0x6000359")]
		public PendingAch() { }

	}

	[Token(Token = "0x20000A8")]
	private class PendingBag
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000378")]
		public List<PendingScore> scores; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000379")]
		public List<PendingAch> achs; //Field offset: 0x18

		[Address(RVA = "0x330187C", Offset = "0x330187C", Length = "0xDC")]
		[Token(Token = "0x600035A")]
		public PendingBag() { }

	}

	[Token(Token = "0x20000A6")]
	private class PendingScore
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000372")]
		public string id; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000373")]
		public long score; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000374")]
		public long context; //Field offset: 0x20

		[Address(RVA = "0x3301A84", Offset = "0x3301A84", Length = "0x8")]
		[Token(Token = "0x6000358")]
		public PendingScore() { }

	}

	[Token(Token = "0x4000359")]
	private const string ReceiverName = "GameCenterReceiver"; //Field offset: 0x0
	[Token(Token = "0x400035A")]
	private const string PendingKey = "Hamdoku.GC.Pending"; //Field offset: 0x0
	[Token(Token = "0x400035B")]
	private const string BestLevelSentKey = "Hamdoku.GC.BestLevelSent"; //Field offset: 0x0
	[Token(Token = "0x400035C")]
	private const string AchPrefix = "Hamdoku.GC.Ach."; //Field offset: 0x0
	[Token(Token = "0x400035D")]
	private const int PendingCap = 40; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x400035E")]
	private static bool <IsAuthenticated>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x400035F")]
	private static string <PlayerAlias>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[Token(Token = "0x4000360")]
	private static Action<bool> AuthChanged; //Field offset: 0x10
	[Token(Token = "0x4000361")]
	private static GameCenterReceiver _receiver; //Field offset: 0x18
	[Token(Token = "0x4000362")]
	private static bool _authRequested; //Field offset: 0x20
	[Token(Token = "0x4000363")]
	private static bool _dashboardOpen; //Field offset: 0x21
	[Token(Token = "0x4000364")]
	private static int _accessPointHolds; //Field offset: 0x24
	[Token(Token = "0x4000365")]
	private static bool _stateSynced; //Field offset: 0x28

	[Token(Token = "0x14000006")]
	public static event Action<bool> AuthChanged
	{
		[Address(RVA = "0x32FFA70", Offset = "0x32FFA70", Length = "0xD0")]
		[CompilerGenerated]
		[Token(Token = "0x6000336")]
		 add { } //Length: 208
		[Address(RVA = "0x32FFB40", Offset = "0x32FFB40", Length = "0xD0")]
		[CompilerGenerated]
		[Token(Token = "0x6000337")]
		 remove { } //Length: 208
	}

	[Token(Token = "0x17000054")]
	public static bool IsAuthenticated
	{
		[Address(RVA = "0x32FF940", Offset = "0x32FF940", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x6000332")]
		 get { } //Length: 72
		[Address(RVA = "0x32FF988", Offset = "0x32FF988", Length = "0x50")]
		[CompilerGenerated]
		[Token(Token = "0x6000333")]
		private set { } //Length: 80
	}

	[Token(Token = "0x17000058")]
	public static bool IsDashboardOpen
	{
		[Address(RVA = "0x32FFCE0", Offset = "0x32FFCE0", Length = "0x48")]
		[Token(Token = "0x600033B")]
		 get { } //Length: 72
	}

	[Token(Token = "0x17000057")]
	public static bool IsEnabled
	{
		[Address(RVA = "0x32FFC60", Offset = "0x32FFC60", Length = "0x80")]
		[Token(Token = "0x600033A")]
		 get { } //Length: 128
	}

	[Token(Token = "0x17000056")]
	public static bool IsSupported
	{
		[Address(RVA = "0x32FFC58", Offset = "0x32FFC58", Length = "0x8")]
		[Token(Token = "0x6000339")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000055")]
	public static string PlayerAlias
	{
		[Address(RVA = "0x32FF9D8", Offset = "0x32FF9D8", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x6000334")]
		 get { } //Length: 72
		[Address(RVA = "0x32FFA20", Offset = "0x32FFA20", Length = "0x50")]
		[CompilerGenerated]
		[Token(Token = "0x6000335")]
		private set { } //Length: 80
	}

	[Address(RVA = "0x32FFA70", Offset = "0x32FFA70", Length = "0xD0")]
	[CompilerGenerated]
	[Token(Token = "0x6000336")]
	public static void add_AuthChanged(Action<bool> value) { }

	[Address(RVA = "0x32FFF4C", Offset = "0x32FFF4C", Length = "0x2C")]
	[Token(Token = "0x600033F")]
	public static void Authenticate() { }

	[Address(RVA = "0x32FFEB8", Offset = "0x32FFEB8", Length = "0x68")]
	[IteratorStateMachine(typeof(<AuthenticateAfter>d__30))]
	[Token(Token = "0x600033E")]
	private static IEnumerator AuthenticateAfter(float delay) { }

	[Address(RVA = "0x32FFD28", Offset = "0x32FFD28", Length = "0x5C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	[Token(Token = "0x600033C")]
	private static void Boot() { }

	[Address(RVA = "0x33011F8", Offset = "0x33011F8", Length = "0x26C")]
	[Token(Token = "0x6000348")]
	private static int DailyClearCount() { }

	[Address(RVA = "0x32FFD84", Offset = "0x32FFD84", Length = "0x134")]
	[Token(Token = "0x600033D")]
	private static void EnsureReceiver() { }

	[Address(RVA = "0x3300218", Offset = "0x3300218", Length = "0x300")]
	[Token(Token = "0x6000357")]
	private static void FlushPending() { }

	[Address(RVA = "0x32FF940", Offset = "0x32FF940", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x6000332")]
	public static bool get_IsAuthenticated() { }

	[Address(RVA = "0x32FFCE0", Offset = "0x32FFCE0", Length = "0x48")]
	[Token(Token = "0x600033B")]
	public static bool get_IsDashboardOpen() { }

	[Address(RVA = "0x32FFC60", Offset = "0x32FFC60", Length = "0x80")]
	[Token(Token = "0x600033A")]
	public static bool get_IsEnabled() { }

	[Address(RVA = "0x32FFC58", Offset = "0x32FFC58", Length = "0x8")]
	[Token(Token = "0x6000339")]
	public static bool get_IsSupported() { }

	[Address(RVA = "0x32FF9D8", Offset = "0x32FF9D8", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x6000334")]
	public static string get_PlayerAlias() { }

	[Address(RVA = "0x330101C", Offset = "0x330101C", Length = "0x150")]
	[Token(Token = "0x6000344")]
	internal static void HandleAchievementReported(string payload) { }

	[Address(RVA = "0x32FFFD0", Offset = "0x32FFFD0", Length = "0x208")]
	[Token(Token = "0x6000341")]
	internal static void HandleAuthChanged(string payload) { }

	[Address(RVA = "0x330116C", Offset = "0x330116C", Length = "0x48")]
	[Token(Token = "0x6000345")]
	internal static void HandleDashboardClosed() { }

	[Address(RVA = "0x3300CBC", Offset = "0x3300CBC", Length = "0xF0")]
	[Token(Token = "0x6000343")]
	internal static void HandleScoreSubmitted(string payload) { }

	[Address(RVA = "0x33016A8", Offset = "0x33016A8", Length = "0x60")]
	[Token(Token = "0x600034F")]
	public static void HoldAccessPoint(bool hold) { }

	[Address(RVA = "0x3301728", Offset = "0x3301728", Length = "0x154")]
	[Token(Token = "0x6000352")]
	private static PendingBag LoadPending() { }

	[Address(RVA = "0x32FF564", Offset = "0x32FF564", Length = "0x38")]
	[Token(Token = "0x6000340")]
	public static void OnConfigChanged() { }

	[Address(RVA = "0x33011B4", Offset = "0x33011B4", Length = "0x44")]
	[Token(Token = "0x6000346")]
	public static void OnPuzzleCleared(in ClearInfo c) { }

	[Address(RVA = "0x3301698", Offset = "0x3301698", Length = "0x10")]
	[Token(Token = "0x600034E")]
	private static void OnSceneChanged(Scene from, Scene to) { }

	[Address(RVA = "0x3300930", Offset = "0x3300930", Length = "0x9C")]
	[Token(Token = "0x6000349")]
	private static double Progress(int value, int target) { }

	[Address(RVA = "0x32FFF80", Offset = "0x32FFF80", Length = "0x50")]
	[Token(Token = "0x6000351")]
	private static void RefreshAccessPoint() { }

	[Address(RVA = "0x32FFB40", Offset = "0x32FFB40", Length = "0xD0")]
	[CompilerGenerated]
	[Token(Token = "0x6000337")]
	public static void remove_AuthChanged(Action<bool> value) { }

	[Address(RVA = "0x3300588", Offset = "0x3300588", Length = "0x3A8")]
	[Token(Token = "0x6000356")]
	private static void Report(GcAchievement kind, double percent) { }

	[Address(RVA = "0x3300C08", Offset = "0x3300C08", Length = "0xB4")]
	[Token(Token = "0x6000347")]
	private static void ReportDailyAndRank(GameCenterConfig cfg) { }

	[Address(RVA = "0x3300DAC", Offset = "0x3300DAC", Length = "0x270")]
	[Token(Token = "0x6000355")]
	private static void RequeueFailedScore(string id) { }

	[Address(RVA = "0x32FFC10", Offset = "0x32FFC10", Length = "0x48")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000338")]
	private static void ResetAccessPointHolds() { }

	[Address(RVA = "0x330153C", Offset = "0x330153C", Length = "0x158")]
	[Token(Token = "0x600034D")]
	public static void ResetAchievementsDebug() { }

	[Address(RVA = "0x3301958", Offset = "0x3301958", Length = "0x120")]
	[Token(Token = "0x6000353")]
	private static void SavePending(PendingBag bag) { }

	[Address(RVA = "0x32FF988", Offset = "0x32FF988", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x6000333")]
	private static void set_IsAuthenticated(bool value) { }

	[Address(RVA = "0x32FFA20", Offset = "0x32FFA20", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x6000335")]
	private static void set_PlayerAlias(string value) { }

	[Address(RVA = "0x3301708", Offset = "0x3301708", Length = "0x20")]
	[Token(Token = "0x6000350")]
	public static void SetAccessPointHold(ref bool held, bool hold) { }

	[Address(RVA = "0x33014DC", Offset = "0x33014DC", Length = "0x2C")]
	[Token(Token = "0x600034B")]
	public static void ShowAchievements() { }

	[Address(RVA = "0x330150C", Offset = "0x330150C", Length = "0x2C")]
	[Token(Token = "0x600034C")]
	public static void ShowDashboard() { }

	[Address(RVA = "0x33014AC", Offset = "0x33014AC", Length = "0x2C")]
	[Token(Token = "0x600034A")]
	public static void ShowLeaderboard(GcLeaderboard lb) { }

	[Address(RVA = "0x33009CC", Offset = "0x33009CC", Length = "0x23C")]
	[Token(Token = "0x6000354")]
	private static void Submit(GcLeaderboard lb, long score, long context) { }

	[Address(RVA = "0x3300518", Offset = "0x3300518", Length = "0x70")]
	[Token(Token = "0x6000342")]
	private static void SyncStateAchievements() { }

}

