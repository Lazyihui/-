namespace Hamdoku.Managers;

[Token(Token = "0x20000DA")]
public static class ServerTime
{
	[CompilerGenerated]
	[Token(Token = "0x20000DD")]
	private sealed class <SyncLoop>d__50 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000493")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000494")]
		private object <>2__current; //Field offset: 0x18

		[Token(Token = "0x1700007A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33202A0", Offset = "0x33202A0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004AF")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700007B")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33202E0", Offset = "0x33202E0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004B1")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x331FAF4", Offset = "0x331FAF4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60004AC")]
		public <SyncLoop>d__50(int <>1__state) { }

		[Address(RVA = "0x3320068", Offset = "0x3320068", Length = "0x238")]
		[Token(Token = "0x60004AE")]
		private bool MoveNext() { }

		[Address(RVA = "0x33202A0", Offset = "0x33202A0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004AF")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33202E0", Offset = "0x33202E0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004B1")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33202A8", Offset = "0x33202A8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60004B0")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3320064", Offset = "0x3320064", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60004AD")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000DE")]
	private sealed class <SyncOnce>d__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000495")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000496")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000497")]
		private string[] <>7__wrap1; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000498")]
		private int <>7__wrap2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000499")]
		private UnityWebRequest <req>5__4; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400049A")]
		private double <t0>5__5; //Field offset: 0x38

		[Token(Token = "0x1700007C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3320710", Offset = "0x3320710", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004B6")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700007D")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3320750", Offset = "0x3320750", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004B8")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x331FB74", Offset = "0x331FB74", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60004B2")]
		public <SyncOnce>d__51(int <>1__state) { }

		[Address(RVA = "0x3320660", Offset = "0x3320660", Length = "0xB0")]
		[Token(Token = "0x60004B5")]
		private void <>m__Finally1() { }

		[Address(RVA = "0x3320304", Offset = "0x3320304", Length = "0x35C")]
		[Token(Token = "0x60004B4")]
		private bool MoveNext() { }

		[Address(RVA = "0x3320710", Offset = "0x3320710", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004B6")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3320750", Offset = "0x3320750", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004B8")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3320718", Offset = "0x3320718", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60004B7")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33202E8", Offset = "0x33202E8", Length = "0x1C")]
		[DebuggerHidden]
		[Token(Token = "0x60004B3")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x20000DC")]
	private class Runner : MonoBehaviour
	{
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000492")]
		private float _saveTimer; //Field offset: 0x20

		[Address(RVA = "0x332005C", Offset = "0x332005C", Length = "0x8")]
		[Token(Token = "0x60004AB")]
		public Runner() { }

		[Address(RVA = "0x331FF1C", Offset = "0x331FF1C", Length = "0x68")]
		[Token(Token = "0x60004A8")]
		private void OnApplicationPause(bool paused) { }

		[Address(RVA = "0x331FF84", Offset = "0x331FF84", Length = "0x4C")]
		[Token(Token = "0x60004A9")]
		private void OnApplicationQuit() { }

		[Address(RVA = "0x331FFD0", Offset = "0x331FFD0", Length = "0x8C")]
		[Token(Token = "0x60004AA")]
		private void Update() { }

	}

	[Token(Token = "0x20000DB")]
	public enum TimeTrust : int
	{
		LocalOnly = 0,
		CachedFallback = 1,
		Synced = 2,
	}

	[Token(Token = "0x4000478")]
	private static readonly string[] Endpoints; //Field offset: 0x0
	[Token(Token = "0x4000479")]
	private const string KEY_OFFSET = "ServerTime_OffsetTicks"; //Field offset: 0x0
	[Token(Token = "0x400047A")]
	private const string KEY_LASTKNOWN = "ServerTime_LastKnownUtc"; //Field offset: 0x0
	[Token(Token = "0x400047B")]
	private const string KEY_SYNCED_EVER = "ServerTime_SyncedEver"; //Field offset: 0x0
	[Token(Token = "0x400047C")]
	private const int RequestTimeoutSec = 6; //Field offset: 0x0
	[Token(Token = "0x400047D")]
	private const float ResyncIntervalSec = 300; //Field offset: 0x0
	[Token(Token = "0x4000488")]
	private const string KEY_CALENDAR_OFFSET = "ServerTime_CalendarOffsetMinutes"; //Field offset: 0x0
	[Token(Token = "0x4000487")]
	private const string KEY_CALENDAR_ZONE_ID = "ServerTime_CalendarZoneId"; //Field offset: 0x0
	[Token(Token = "0x4000486")]
	private const string KEY_CALENDAR_ZONE = "ServerTime_CalendarZone"; //Field offset: 0x0
	[Token(Token = "0x400047E")]
	private static bool _synced; //Field offset: 0x8
	[Token(Token = "0x400047F")]
	private static bool _syncedEver; //Field offset: 0x9
	[Token(Token = "0x4000480")]
	private static long _syncServerUtcTicks; //Field offset: 0x10
	[Token(Token = "0x4000481")]
	private static double _syncRealtime; //Field offset: 0x18
	[Token(Token = "0x4000482")]
	private static long _offsetTicks; //Field offset: 0x20
	[Token(Token = "0x4000483")]
	private static long _lastKnownUtcTicks; //Field offset: 0x28
	[Token(Token = "0x4000484")]
	private static Runner _runner; //Field offset: 0x30
	[Token(Token = "0x4000485")]
	private static double _nextUserResync; //Field offset: 0x38
	[Token(Token = "0x4000489")]
	private static TimeZoneInfo _calendarZone; //Field offset: 0x40
	[Token(Token = "0x400048A")]
	private static Nullable<int> _calendarOffsetMinutes; //Field offset: 0x48
	[CompilerGenerated]
	[Token(Token = "0x400048B")]
	private static Action OnSynced; //Field offset: 0x50
	[Token(Token = "0x400048C")]
	private static bool _initialSyncAttempted; //Field offset: 0x58
	[CompilerGenerated]
	[Token(Token = "0x400048D")]
	private static Action<bool> OnInitialSyncCompleted; //Field offset: 0x60

	[Token(Token = "0x14000008")]
	public static event Action<bool> OnInitialSyncCompleted
	{
		[Address(RVA = "0x331F488", Offset = "0x331F488", Length = "0xF4")]
		[CompilerGenerated]
		[Token(Token = "0x600049B")]
		 add { } //Length: 244
		[Address(RVA = "0x331F57C", Offset = "0x331F57C", Length = "0xF4")]
		[CompilerGenerated]
		[Token(Token = "0x600049C")]
		 remove { } //Length: 244
	}

	[Token(Token = "0x14000007")]
	public static event Action OnSynced
	{
		[Address(RVA = "0x331F278", Offset = "0x331F278", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000498")]
		 add { } //Length: 220
		[Address(RVA = "0x331F354", Offset = "0x331F354", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000499")]
		 remove { } //Length: 220
	}

	[Token(Token = "0x17000077")]
	public static int CalendarOffsetMinutes
	{
		[Address(RVA = "0x331EABC", Offset = "0x331EABC", Length = "0x164")]
		[Token(Token = "0x6000495")]
		 get { } //Length: 356
	}

	[Token(Token = "0x17000075")]
	public static DateTime CalendarToday
	{
		[Address(RVA = "0x331E6AC", Offset = "0x331E6AC", Length = "0x1B4")]
		[Token(Token = "0x6000493")]
		 get { } //Length: 436
	}

	[Token(Token = "0x17000076")]
	public static string CalendarZoneId
	{
		[Address(RVA = "0x331EA3C", Offset = "0x331EA3C", Length = "0x80")]
		[Token(Token = "0x6000494")]
		 get { } //Length: 128
	}

	[Token(Token = "0x17000078")]
	public static bool InitialSyncAttempted
	{
		[Address(RVA = "0x331F430", Offset = "0x331F430", Length = "0x58")]
		[Token(Token = "0x600049A")]
		 get { } //Length: 88
	}

	[Token(Token = "0x17000072")]
	public static bool IsSynced
	{
		[Address(RVA = "0x331E298", Offset = "0x331E298", Length = "0x58")]
		[Token(Token = "0x600048F")]
		 get { } //Length: 88
	}

	[Token(Token = "0x17000074")]
	public static bool IsTimeTrusted
	{
		[Address(RVA = "0x331E36C", Offset = "0x331E36C", Length = "0x58")]
		[Token(Token = "0x6000491")]
		 get { } //Length: 88
	}

	[Token(Token = "0x17000073")]
	public static TimeTrust Trust
	{
		[Address(RVA = "0x331E2F0", Offset = "0x331E2F0", Length = "0x7C")]
		[Token(Token = "0x6000490")]
		 get { } //Length: 124
	}

	[Token(Token = "0x17000079")]
	public static DateTime UtcNow
	{
		[Address(RVA = "0x331E860", Offset = "0x331E860", Length = "0x1DC")]
		[Token(Token = "0x600049D")]
		 get { } //Length: 476
	}

	[Address(RVA = "0x331FE04", Offset = "0x331FE04", Length = "0x118")]
	[Token(Token = "0x60004A7")]
	private static ServerTime() { }

	[Address(RVA = "0x331F488", Offset = "0x331F488", Length = "0xF4")]
	[CompilerGenerated]
	[Token(Token = "0x600049B")]
	public static void add_OnInitialSyncCompleted(Action<bool> value) { }

	[Address(RVA = "0x331F278", Offset = "0x331F278", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000498")]
	public static void add_OnSynced(Action value) { }

	[Address(RVA = "0x331FB9C", Offset = "0x331FB9C", Length = "0x268")]
	[Token(Token = "0x60004A4")]
	private static void ApplySync(DateTime serverUtc, double realtimeAtResponse, double halfRttSec) { }

	[Address(RVA = "0x331F724", Offset = "0x331F724", Length = "0x250")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	[Token(Token = "0x600049F")]
	private static void AutoBoot() { }

	[Address(RVA = "0x331EF8C", Offset = "0x331EF8C", Length = "0x2EC")]
	[Token(Token = "0x6000497")]
	private static void EnsureCalendarZone(DateTime serverUtc) { }

	[Address(RVA = "0x331EABC", Offset = "0x331EABC", Length = "0x164")]
	[Token(Token = "0x6000495")]
	public static int get_CalendarOffsetMinutes() { }

	[Address(RVA = "0x331E6AC", Offset = "0x331E6AC", Length = "0x1B4")]
	[Token(Token = "0x6000493")]
	public static DateTime get_CalendarToday() { }

	[Address(RVA = "0x331EA3C", Offset = "0x331EA3C", Length = "0x80")]
	[Token(Token = "0x6000494")]
	public static string get_CalendarZoneId() { }

	[Address(RVA = "0x331F430", Offset = "0x331F430", Length = "0x58")]
	[Token(Token = "0x600049A")]
	public static bool get_InitialSyncAttempted() { }

	[Address(RVA = "0x331E298", Offset = "0x331E298", Length = "0x58")]
	[Token(Token = "0x600048F")]
	public static bool get_IsSynced() { }

	[Address(RVA = "0x331E36C", Offset = "0x331E36C", Length = "0x58")]
	[Token(Token = "0x6000491")]
	public static bool get_IsTimeTrusted() { }

	[Address(RVA = "0x331E2F0", Offset = "0x331E2F0", Length = "0x7C")]
	[Token(Token = "0x6000490")]
	public static TimeTrust get_Trust() { }

	[Address(RVA = "0x331E860", Offset = "0x331E860", Length = "0x1DC")]
	[Token(Token = "0x600049D")]
	public static DateTime get_UtcNow() { }

	[Address(RVA = "0x331EC20", Offset = "0x331EC20", Length = "0x36C")]
	[Token(Token = "0x6000496")]
	private static void LoadCalendarZone() { }

	[Address(RVA = "0x331F974", Offset = "0x331F974", Length = "0x78")]
	[Token(Token = "0x60004A5")]
	private static long LoadLong(string key, long fallback) { }

	[Address(RVA = "0x331FA84", Offset = "0x331FA84", Length = "0x70")]
	[Token(Token = "0x60004A1")]
	internal static void PersistLastKnown() { }

	[Address(RVA = "0x331F57C", Offset = "0x331F57C", Length = "0xF4")]
	[CompilerGenerated]
	[Token(Token = "0x600049C")]
	public static void remove_OnInitialSyncCompleted(Action<bool> value) { }

	[Address(RVA = "0x331F354", Offset = "0x331F354", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000499")]
	public static void remove_OnSynced(Action value) { }

	[Address(RVA = "0x331E5C0", Offset = "0x331E5C0", Length = "0xEC")]
	[Token(Token = "0x60004A0")]
	internal static void RequestResync() { }

	[Address(RVA = "0x331E3C4", Offset = "0x331E3C4", Length = "0x1FC")]
	[Token(Token = "0x6000492")]
	public static bool RequireTrustedTime() { }

	[Address(RVA = "0x331F670", Offset = "0x331F670", Length = "0xB4")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x600049E")]
	private static void ResetStatics() { }

	[Address(RVA = "0x331F9EC", Offset = "0x331F9EC", Length = "0x40")]
	[Token(Token = "0x60004A6")]
	private static void SaveLong(string key, long value) { }

	[Address(RVA = "0x331FA2C", Offset = "0x331FA2C", Length = "0x58")]
	[IteratorStateMachine(typeof(<SyncLoop>d__50))]
	[Token(Token = "0x60004A2")]
	private static IEnumerator SyncLoop() { }

	[Address(RVA = "0x331FB1C", Offset = "0x331FB1C", Length = "0x58")]
	[IteratorStateMachine(typeof(<SyncOnce>d__51))]
	[Token(Token = "0x60004A3")]
	private static IEnumerator SyncOnce() { }

}

