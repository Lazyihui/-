namespace Hamdoku.Managers;

[Token(Token = "0x20000C4")]
public class RankingManager
{
	[CompilerGenerated]
	[Token(Token = "0x20000C8")]
	private sealed class <>c__DisplayClass63_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400042C")]
		public int seq; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400042D")]
		public string uid; //Field offset: 0x18

		[Address(RVA = "0x33148A8", Offset = "0x33148A8", Length = "0x8")]
		[Token(Token = "0x6000446")]
		public <>c__DisplayClass63_0() { }

		[Address(RVA = "0x3319208", Offset = "0x3319208", Length = "0x1B8")]
		[Token(Token = "0x6000447")]
		internal void <SyncForcedName>b__0(Task<DocumentSnapshot> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000C9")]
	private sealed class <>c__DisplayClass74_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400042E")]
		public int level; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400042F")]
		public string uid; //Field offset: 0x18

		[Address(RVA = "0x33150E4", Offset = "0x33150E4", Length = "0x8")]
		[Token(Token = "0x6000448")]
		public <>c__DisplayClass74_0() { }

		[Address(RVA = "0x33193C0", Offset = "0x33193C0", Length = "0x68")]
		[Token(Token = "0x6000449")]
		internal bool <HasPendingClearReport>b__0(ReportItem item) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CA")]
	private sealed class <>c__DisplayClass76_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000430")]
		public string sessionUid; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000431")]
		public RankingManager <>4__this; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000432")]
		public ReportItem item; //Field offset: 0x20

		[Address(RVA = "0x3315B90", Offset = "0x3315B90", Length = "0x8")]
		[Token(Token = "0x600044A")]
		public <>c__DisplayClass76_0() { }

		[Address(RVA = "0x3319478", Offset = "0x3319478", Length = "0x254")]
		[Token(Token = "0x600044C")]
		internal void <SendNext>b__0(Task<HttpsCallableResult> t) { }

		[Address(RVA = "0x3319428", Offset = "0x3319428", Length = "0x50")]
		[Token(Token = "0x600044B")]
		internal bool <SendNext>b__1(ReportItem it) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CB")]
	private sealed class <>c__DisplayClass80_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000433")]
		public RankingManager <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000434")]
		public TaskCompletionSource<RankView> tcs; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000435")]
		public RankScope scope; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000436")]
		public string country; //Field offset: 0x28

		[Address(RVA = "0x3316948", Offset = "0x3316948", Length = "0x8")]
		[Token(Token = "0x600044D")]
		public <>c__DisplayClass80_0() { }

		[Address(RVA = "0x33196CC", Offset = "0x33196CC", Length = "0x46C")]
		[Token(Token = "0x600044E")]
		internal void <FetchPlayers>b__0(Task<QuerySnapshot> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CC")]
	private sealed class <>c__DisplayClass82_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000437")]
		public RankingManager <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000438")]
		public TaskCompletionSource<WeeklyView> tcs; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000439")]
		public string weekId; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400043A")]
		public string uid0; //Field offset: 0x28

		[Address(RVA = "0x33178D4", Offset = "0x33178D4", Length = "0x8")]
		[Token(Token = "0x600044F")]
		public <>c__DisplayClass82_0() { }

		[Address(RVA = "0x3319B38", Offset = "0x3319B38", Length = "0x4AC")]
		[Token(Token = "0x6000450")]
		internal void <FetchWeekly>b__0(Task<QuerySnapshot> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CD")]
	private sealed class <>c__DisplayClass83_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400043B")]
		public string uid; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400043C")]
		public string weekId; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400043D")]
		public TaskCompletionSource<WeeklyView> tcs; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400043E")]
		public RankingManager <>4__this; //Field offset: 0x28

		[Address(RVA = "0x3317EB0", Offset = "0x3317EB0", Length = "0x8")]
		[Token(Token = "0x6000451")]
		public <>c__DisplayClass83_0() { }

		[Address(RVA = "0x3319FE4", Offset = "0x3319FE4", Length = "0x3C4")]
		[Token(Token = "0x6000452")]
		internal void <FetchMyGroupThen>b__0(Task<DocumentSnapshot> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CE")]
	private sealed class <>c__DisplayClass84_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400043F")]
		public string uid0; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000440")]
		public RankingManager <>4__this; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000441")]
		public TaskCompletionSource<WeeklyView> tcs; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000442")]
		public string weekId; //Field offset: 0x28

		[Address(RVA = "0x33182E8", Offset = "0x33182E8", Length = "0x8")]
		[Token(Token = "0x6000453")]
		public <>c__DisplayClass84_0() { }

		[Address(RVA = "0x331A3A8", Offset = "0x331A3A8", Length = "0x4AC")]
		[Token(Token = "0x6000454")]
		internal void <QueryWeeklyGroup>b__0(Task<QuerySnapshot> t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000CF")]
	private sealed class <FlushWhenReady>d__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000443")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000444")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000445")]
		public RankingManager <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000446")]
		private WaitForSeconds <wait>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000447")]
		private int <rounds>5__3; //Field offset: 0x30

		[Token(Token = "0x17000068")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x331AA4C", Offset = "0x331AA4C", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000458")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000069")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x331AA8C", Offset = "0x331AA8C", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600045A")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x331A854", Offset = "0x331A854", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000455")]
		public <FlushWhenReady>d__28(int <>1__state) { }

		[Address(RVA = "0x331A880", Offset = "0x331A880", Length = "0x1CC")]
		[Token(Token = "0x6000457")]
		private bool MoveNext() { }

		[Address(RVA = "0x331AA4C", Offset = "0x331AA4C", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000458")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x331AA8C", Offset = "0x331AA8C", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600045A")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x331AA54", Offset = "0x331AA54", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000459")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x331A87C", Offset = "0x331A87C", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000456")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000D0")]
	private sealed class <SendNextAfter>d__77 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000448")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000449")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400044A")]
		public float seconds; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400044B")]
		public RankingManager <>4__this; //Field offset: 0x28

		[Token(Token = "0x1700006A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x331AC04", Offset = "0x331AC04", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600045E")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700006B")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x331AC44", Offset = "0x331AC44", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000460")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x331AA94", Offset = "0x331AA94", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600045B")]
		public <SendNextAfter>d__77(int <>1__state) { }

		[Address(RVA = "0x331AAC0", Offset = "0x331AAC0", Length = "0x144")]
		[Token(Token = "0x600045D")]
		private bool MoveNext() { }

		[Address(RVA = "0x331AC04", Offset = "0x331AC04", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600045E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x331AC44", Offset = "0x331AC44", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000460")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x331AC0C", Offset = "0x331AC0C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600045F")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x331AABC", Offset = "0x331AABC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600045C")]
		private void System.IDisposable.Dispose() { }

	}

	[IsReadOnly]
	[Token(Token = "0x20000C5")]
	private struct CrownRotation
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x400040D")]
		public readonly int FromIndex; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400040E")]
		public readonly int[] Ids; //Field offset: 0x8

		[Address(RVA = "0x33191F8", Offset = "0x33191F8", Length = "0x10")]
		[Token(Token = "0x6000443")]
		public CrownRotation(int fromIndex, int[] ids) { }

	}

	[Token(Token = "0x20000C6")]
	private class ReportItem
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400040F")]
		public int reachedLevel; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x4000410")]
		public int seedsLeft; //Field offset: 0x14
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000411")]
		public string country; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000412")]
		public string name; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000413")]
		public int avatarId; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000414")]
		public int frameId; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000415")]
		public int costumeId; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000416")]
		public string weekId; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000417")]
		public string clientKey; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000418")]
		public int itemBulb; //Field offset: 0x48
		[FieldOffset(Offset = "0x4C")]
		[Token(Token = "0x4000419")]
		public int itemGlass; //Field offset: 0x4C
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x400041A")]
		public bool adFree; //Field offset: 0x50
		[FieldOffset(Offset = "0x51")]
		[Token(Token = "0x400041B")]
		public bool autoX; //Field offset: 0x51
		[FieldOffset(Offset = "0x52")]
		[Token(Token = "0x400041C")]
		public bool hasItems; //Field offset: 0x52
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x400041D")]
		public string appVersion; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x400041E")]
		public int streakDays; //Field offset: 0x60
		[FieldOffset(Offset = "0x64")]
		[Token(Token = "0x400041F")]
		public int streakBest; //Field offset: 0x64
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x4000420")]
		public string streakLastWinDay; //Field offset: 0x68
		[FieldOffset(Offset = "0x70")]
		[Token(Token = "0x4000421")]
		public bool hasStreak; //Field offset: 0x70
		[FieldOffset(Offset = "0x74")]
		[Token(Token = "0x4000422")]
		public int mottoId; //Field offset: 0x74
		[FieldOffset(Offset = "0x78")]
		[Token(Token = "0x4000423")]
		public bool hasCard; //Field offset: 0x78
		[FieldOffset(Offset = "0x7C")]
		[Token(Token = "0x4000424")]
		public int cardWinStreak; //Field offset: 0x7C
		[FieldOffset(Offset = "0x80")]
		[Token(Token = "0x4000425")]
		public int cardBestWinStreak; //Field offset: 0x80
		[FieldOffset(Offset = "0x84")]
		[Token(Token = "0x4000426")]
		public int cardPerfect; //Field offset: 0x84
		[FieldOffset(Offset = "0x88")]
		[Token(Token = "0x4000427")]
		public int cardFirstTry; //Field offset: 0x88
		[FieldOffset(Offset = "0x8C")]
		[Token(Token = "0x4000428")]
		public int cardDailyPuzzles; //Field offset: 0x8C
		[FieldOffset(Offset = "0x90")]
		[Token(Token = "0x4000429")]
		public int cardStartDay; //Field offset: 0x90
		[FieldOffset(Offset = "0x98")]
		[Token(Token = "0x400042A")]
		public string ownerUid; //Field offset: 0x98

		[Address(RVA = "0x33140BC", Offset = "0x33140BC", Length = "0x8")]
		[Token(Token = "0x6000444")]
		public ReportItem() { }

	}

	[Token(Token = "0x20000C7")]
	private class ReportQueue
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400042B")]
		public List<ReportItem> items; //Field offset: 0x10

		[Address(RVA = "0x3314EF8", Offset = "0x3314EF8", Length = "0x88")]
		[Token(Token = "0x6000445")]
		public ReportQueue() { }

	}

	[Token(Token = "0x40003F7")]
	public const string FunctionRegion = "asia-northeast3"; //Field offset: 0x0
	[Token(Token = "0x4000406")]
	private static readonly DateTime CrownEpochMonday; //Field offset: 0x0
	[Token(Token = "0x4000405")]
	private const int BlockASplitDow = 4; //Field offset: 0x0
	[Token(Token = "0x4000403")]
	private const string MyRankValueKey = "Hamdoku.Rank.MyRankValue"; //Field offset: 0x0
	[Token(Token = "0x4000402")]
	private const string MyRankWeekKey = "Hamdoku.Rank.MyRankWeek"; //Field offset: 0x0
	[Token(Token = "0x4000400")]
	private const string WeeklyGroupIdKey = "RankingWeeklyGroupId"; //Field offset: 0x0
	[Token(Token = "0x40003FF")]
	private const string WeeklyGroupWeekKey = "RankingWeeklyGroupWeek"; //Field offset: 0x0
	[Token(Token = "0x4000401")]
	public const string MyRank1WinsKey = "Hamdoku.Rank.MyRank1Wins"; //Field offset: 0x0
	[Token(Token = "0x40003FD")]
	private const string WeeklyLocalWeekKey = "RankingWeeklyLocalWeek"; //Field offset: 0x0
	[Token(Token = "0x40003FC")]
	private const float SendGapSeconds = 5.5; //Field offset: 0x0
	[Token(Token = "0x40003FB")]
	private const int MaxQueued = 500; //Field offset: 0x0
	[Token(Token = "0x40003FA")]
	public const string ReportQueuePrefKey = "RankingReportQueue"; //Field offset: 0x0
	[Token(Token = "0x40003F9")]
	private const string CountryPrefKey = "CountryCode"; //Field offset: 0x0
	[Token(Token = "0x40003F8")]
	public const int PlayersTopN = 500; //Field offset: 0x0
	[Token(Token = "0x40003FE")]
	private const string WeeklyLocalValueKey = "RankingWeeklyLocalValue"; //Field offset: 0x0
	[Token(Token = "0x4000407")]
	private static readonly CrownRotation[] CrownRotations; //Field offset: 0x8
	[Token(Token = "0x4000408")]
	private static int _forcedNameSeq; //Field offset: 0x10
	[Token(Token = "0x400040A")]
	private static WeeklyView _weeklyCache; //Field offset: 0x18
	[Token(Token = "0x400040B")]
	private static string _weeklyCacheKey; //Field offset: 0x20
	[Token(Token = "0x400040C")]
	private static float _weeklyCacheAt; //Field offset: 0x28
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000404")]
	private bool _flushScheduled; //Field offset: 0x20
	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x4000409")]
	private bool _flushing; //Field offset: 0x21

	[Token(Token = "0x17000064")]
	public static int[] CrownFrameIds
	{
		[Address(RVA = "0x3313000", Offset = "0x3313000", Length = "0x58")]
		[Token(Token = "0x600040A")]
		 get { } //Length: 88
	}

	[Token(Token = "0x17000067")]
	private FirebaseFirestore Db
	{
		[Address(RVA = "0x3316950", Offset = "0x3316950", Length = "0x50")]
		[Token(Token = "0x600043C")]
		 get { } //Length: 80
	}

	[Token(Token = "0x17000065")]
	public static int FirstCrownFrameId
	{
		[Address(RVA = "0x330ECE8", Offset = "0x330ECE8", Length = "0xA8")]
		[Token(Token = "0x600040B")]
		 get { } //Length: 168
	}

	[Token(Token = "0x17000063")]
	public static int MyRank1Wins
	{
		[Address(RVA = "0x3301464", Offset = "0x3301464", Length = "0x48")]
		[Token(Token = "0x60003FB")]
		 get { } //Length: 72
	}

	[Token(Token = "0x17000066")]
	public static int UnlockClears
	{
		[Address(RVA = "0x3313058", Offset = "0x3313058", Length = "0x90")]
		[Token(Token = "0x600040C")]
		 get { } //Length: 144
	}

	[Token(Token = "0x17000062")]
	public static int WeeklyTopN
	{
		[Address(RVA = "0x330E934", Offset = "0x330E934", Length = "0x9C")]
		[Token(Token = "0x60003F7")]
		 get { } //Length: 156
	}

	[Address(RVA = "0x3319048", Offset = "0x3319048", Length = "0x1B0")]
	[Token(Token = "0x6000442")]
	private static RankingManager() { }

	[Address(RVA = "0x3319000", Offset = "0x3319000", Length = "0x48")]
	[Token(Token = "0x6000441")]
	public RankingManager() { }

	[Address(RVA = "0x3314D00", Offset = "0x3314D00", Length = "0x54")]
	[Token(Token = "0x6000421")]
	public static void AddBonusSeedsLocal(int seeds) { }

	[Address(RVA = "0x3313FB8", Offset = "0x3313FB8", Length = "0x104")]
	[Token(Token = "0x6000422")]
	private static void AddLocalWeekly(int seeds) { }

	[Address(RVA = "0x33148B0", Offset = "0x33148B0", Length = "0x2CC")]
	[Token(Token = "0x600041D")]
	public static void AdoptLegacyQueueOwner(string uid) { }

	[Address(RVA = "0x3313BCC", Offset = "0x3313BCC", Length = "0xA4")]
	[Token(Token = "0x6000418")]
	private static void ApplyMyStreak(RankEntry me) { }

	[Address(RVA = "0x3317384", Offset = "0x3317384", Length = "0x8C")]
	[Token(Token = "0x600043A")]
	private static void AssignRanks(List<RankEntry> list) { }

	[Address(RVA = "0x330FAA8", Offset = "0x330FAA8", Length = "0x80")]
	[Token(Token = "0x6000412")]
	public static int BlockDays(string blockId) { }

	[Address(RVA = "0x3312B64", Offset = "0x3312B64", Length = "0x170")]
	[Token(Token = "0x6000407")]
	public static string BlockIdAt(DateTime utc) { }

	[Address(RVA = "0x3312CD4", Offset = "0x3312CD4", Length = "0x32C")]
	[Token(Token = "0x6000408")]
	public static int BlockIndex(string blockId) { }

	[Address(RVA = "0x3312A34", Offset = "0x3312A34", Length = "0x130")]
	[Token(Token = "0x6000406")]
	private static void BlockRange(DateTime utc, out DateTime start, out DateTime end) { }

	[Address(RVA = "0x3312838", Offset = "0x3312838", Length = "0x40")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	[Token(Token = "0x6000400")]
	private static void Bootstrap() { }

	[Address(RVA = "0x3316D38", Offset = "0x3316D38", Length = "0x414")]
	[Token(Token = "0x6000435")]
	private RankEntry BuildMeEntry(bool weekly, List<RankEntry> merged, string countryFilter) { }

	[Address(RVA = "0x33169A0", Offset = "0x33169A0", Length = "0x254")]
	[Token(Token = "0x600042D")]
	private RankView BuildPlayersView(RankScope scope, string country, List<RankEntry> real) { }

	[Address(RVA = "0x3317B14", Offset = "0x3317B14", Length = "0x39C")]
	[Token(Token = "0x6000434")]
	private WeeklyView BuildWeeklyView(string weekId, List<RankEntry> real, bool cacheable) { }

	[Address(RVA = "0x3318490", Offset = "0x3318490", Length = "0x1CC")]
	[Token(Token = "0x6000433")]
	public static WeeklyView CachedWeekly(float maxAgeSeconds) { }

	[Address(RVA = "0x3314380", Offset = "0x3314380", Length = "0x4C")]
	[Token(Token = "0x600041A")]
	public void ClearReportQueue() { }

	[Address(RVA = "0x331865C", Offset = "0x331865C", Length = "0xE0")]
	[Token(Token = "0x6000439")]
	private static int Compare(RankEntry a, RankEntry b) { }

	[Address(RVA = "0x3312924", Offset = "0x3312924", Length = "0x110")]
	[Token(Token = "0x6000405")]
	private static string ComputeCountryCode() { }

	[Address(RVA = "0x33132BC", Offset = "0x33132BC", Length = "0x148")]
	[Token(Token = "0x6000410")]
	public static int CrownFrameIdForBlock(string blockId) { }

	[Address(RVA = "0x331326C", Offset = "0x331326C", Length = "0x50")]
	[Token(Token = "0x600040F")]
	public static int CurrentCrownFrameId() { }

	[Address(RVA = "0x331231C", Offset = "0x331231C", Length = "0x84")]
	[Token(Token = "0x6000409")]
	public static string CurrentWeekId() { }

	[Address(RVA = "0x3316BF4", Offset = "0x3316BF4", Length = "0x144")]
	[Token(Token = "0x6000436")]
	private void DedupeReal(List<RankEntry> list) { }

	[Address(RVA = "0x33138D4", Offset = "0x33138D4", Length = "0x168")]
	[Token(Token = "0x6000416")]
	public static string DefaultNameFor(string uid) { }

	[Address(RVA = "0x330D4FC", Offset = "0x330D4FC", Length = "0xE0")]
	[Token(Token = "0x6000404")]
	public static string DetectCountryCode() { }

	[Address(RVA = "0x33140C4", Offset = "0x33140C4", Length = "0x1E4")]
	[Token(Token = "0x6000423")]
	private void Enqueue(ReportItem item) { }

	[Address(RVA = "0x33178DC", Offset = "0x33178DC", Length = "0x238")]
	[Token(Token = "0x600042F")]
	private void FetchMyGroupThen(string weekId, TaskCompletionSource<WeeklyView> tcs) { }

	[Address(RVA = "0x3316524", Offset = "0x3316524", Length = "0x424")]
	[Token(Token = "0x600042C")]
	public Task<RankView> FetchPlayers(RankScope scope) { }

	[Address(RVA = "0x3317410", Offset = "0x3317410", Length = "0x4C4")]
	[Token(Token = "0x600042E")]
	public Task<WeeklyView> FetchWeekly() { }

	[Address(RVA = "0x33142A8", Offset = "0x33142A8", Length = "0xD8")]
	[Token(Token = "0x6000427")]
	public void FlushQueue() { }

	[Address(RVA = "0x33128B0", Offset = "0x33128B0", Length = "0x74")]
	[IteratorStateMachine(typeof(<FlushWhenReady>d__28))]
	[Token(Token = "0x6000403")]
	private IEnumerator FlushWhenReady() { }

	[Address(RVA = "0x3313000", Offset = "0x3313000", Length = "0x58")]
	[Token(Token = "0x600040A")]
	public static int[] get_CrownFrameIds() { }

	[Address(RVA = "0x3316950", Offset = "0x3316950", Length = "0x50")]
	[Token(Token = "0x600043C")]
	private FirebaseFirestore get_Db() { }

	[Address(RVA = "0x330ECE8", Offset = "0x330ECE8", Length = "0xA8")]
	[Token(Token = "0x600040B")]
	public static int get_FirstCrownFrameId() { }

	[Address(RVA = "0x3301464", Offset = "0x3301464", Length = "0x48")]
	[Token(Token = "0x60003FB")]
	public static int get_MyRank1Wins() { }

	[Address(RVA = "0x3313058", Offset = "0x3313058", Length = "0x90")]
	[Token(Token = "0x600040C")]
	public static int get_UnlockClears() { }

	[Address(RVA = "0x330E934", Offset = "0x330E934", Length = "0x9C")]
	[Token(Token = "0x60003F7")]
	public static int get_WeeklyTopN() { }

	[Address(RVA = "0x3318D9C", Offset = "0x3318D9C", Length = "0xFC")]
	[Token(Token = "0x600043F")]
	private static long GetLong(IDictionary<string, object> m, string k) { }

	[Address(RVA = "0x3318CB0", Offset = "0x3318CB0", Length = "0xEC")]
	[Token(Token = "0x600043E")]
	private static string GetStr(IDictionary<string, object> m, string k) { }

	[Address(RVA = "0x3318E98", Offset = "0x3318E98", Length = "0x168")]
	[Token(Token = "0x6000440")]
	private static long GetTicks(IDictionary<string, object> m, string k) { }

	[Address(RVA = "0x3314F80", Offset = "0x3314F80", Length = "0x164")]
	[Token(Token = "0x6000426")]
	internal static bool HasPendingClearReport(string uid, int level) { }

	[Address(RVA = "0x331714C", Offset = "0x331714C", Length = "0x198")]
	[Token(Token = "0x6000437")]
	private void InsertMe(List<RankEntry> merged, RankEntry me) { }

	[Address(RVA = "0x3316264", Offset = "0x3316264", Length = "0x2C0")]
	[Token(Token = "0x600042B")]
	private static bool IsPermanentFunctionsError(AggregateException agg) { }

	[Address(RVA = "0x331320C", Offset = "0x331320C", Length = "0x60")]
	[Token(Token = "0x600040E")]
	public static bool IsUnlocked(int clears) { }

	[Address(RVA = "0x33130E8", Offset = "0x33130E8", Length = "0x124")]
	[Token(Token = "0x600040D")]
	public static bool IsUnlocked() { }

	[Address(RVA = "0x3314D54", Offset = "0x3314D54", Length = "0x140")]
	[Token(Token = "0x6000424")]
	private ReportQueue LoadQueue() { }

	[Address(RVA = "0x330FBB8", Offset = "0x330FBB8", Length = "0xE0")]
	[Token(Token = "0x600041E")]
	public static int LocalWeeklySeeds() { }

	[Address(RVA = "0x3313A3C", Offset = "0x3313A3C", Length = "0xA4")]
	[Token(Token = "0x6000417")]
	public static string MyDisplayName() { }

	[Address(RVA = "0x3312690", Offset = "0x3312690", Length = "0xE0")]
	[Token(Token = "0x60003FE")]
	public static int MyKnownWeeklyRank() { }

	[Address(RVA = "0x3313AE0", Offset = "0x3313AE0", Length = "0xEC")]
	[Token(Token = "0x600043B")]
	internal static string MyUid() { }

	[Address(RVA = "0x331223C", Offset = "0x331223C", Length = "0xE0")]
	[Token(Token = "0x60003F8")]
	public static int MyWeeklyGroup() { }

	[Address(RVA = "0x331873C", Offset = "0x331873C", Length = "0x574")]
	[Token(Token = "0x600043D")]
	private RankEntry ParseEntry(DocumentSnapshot d, bool weekly) { }

	[Address(RVA = "0x331351C", Offset = "0x331351C", Length = "0xD8")]
	[Token(Token = "0x6000413")]
	public static string PreviousBlockId() { }

	[Address(RVA = "0x3317EB8", Offset = "0x3317EB8", Length = "0x430")]
	[Token(Token = "0x6000430")]
	private void QueryWeeklyGroup(string weekId, int group, TaskCompletionSource<WeeklyView> tcs, string uid0 = null) { }

	[Address(RVA = "0x3314BE8", Offset = "0x3314BE8", Length = "0x118")]
	[Token(Token = "0x6000420")]
	internal static void RaiseLocalWeeklyFloor(int serverValue) { }

	[Address(RVA = "0x33124A8", Offset = "0x33124A8", Length = "0xE0")]
	[Token(Token = "0x60003FC")]
	public static bool RaiseMyRank1Wins(int wins) { }

	[Address(RVA = "0x33135F4", Offset = "0x33135F4", Length = "0x1DC")]
	[Token(Token = "0x6000414")]
	public static List<string> RecentEndedBlockIds(int count) { }

	[Address(RVA = "0x3313C70", Offset = "0x3313C70", Length = "0x348")]
	[Token(Token = "0x6000419")]
	public void ReportLevelClear(int reachedLevel, int seedsLeft) { }

	[Address(RVA = "0x33143CC", Offset = "0x33143CC", Length = "0x228")]
	[Token(Token = "0x600041B")]
	public static void ResetLocalCachesForAccountChange() { }

	[Address(RVA = "0x3314B7C", Offset = "0x3314B7C", Length = "0x6C")]
	[Token(Token = "0x600041F")]
	public static void ResetLocalWeeklyForCheat() { }

	[Address(RVA = "0x331243C", Offset = "0x331243C", Length = "0x6C")]
	[Token(Token = "0x60003FA")]
	public static void ResetMyWeeklyGroupForCheat() { }

	[Address(RVA = "0x33145F4", Offset = "0x33145F4", Length = "0x80")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000431")]
	private static void ResetWeeklyCache() { }

	[Address(RVA = "0x33123A0", Offset = "0x33123A0", Length = "0x9C")]
	[Token(Token = "0x60003F9")]
	public static void SaveMyWeeklyGroup(string weekId, int group) { }

	[Address(RVA = "0x3314E94", Offset = "0x3314E94", Length = "0x64")]
	[Token(Token = "0x6000425")]
	private void SaveQueue(ReportQueue q) { }

	[Address(RVA = "0x331287C", Offset = "0x331287C", Length = "0x34")]
	[Token(Token = "0x6000402")]
	private void ScheduleFlush() { }

	[Address(RVA = "0x3313404", Offset = "0x3313404", Length = "0x118")]
	[Token(Token = "0x6000411")]
	public static long SecondsUntilWeekEnd() { }

	[Address(RVA = "0x33150EC", Offset = "0x33150EC", Length = "0xAA4")]
	[Token(Token = "0x6000428")]
	private void SendNext() { }

	[Address(RVA = "0x3315B98", Offset = "0x3315B98", Length = "0x84")]
	[IteratorStateMachine(typeof(<SendNextAfter>d__77))]
	[Token(Token = "0x6000429")]
	private IEnumerator SendNextAfter(float seconds) { }

	[Address(RVA = "0x3312588", Offset = "0x3312588", Length = "0x108")]
	[Token(Token = "0x60003FD")]
	public static void SetMyRank1WinsForCheat(int wins) { }

	[Address(RVA = "0x3312770", Offset = "0x3312770", Length = "0xC8")]
	[Token(Token = "0x60003FF")]
	public static void SetMyRankForCheat(int rank) { }

	[Address(RVA = "0x33172E4", Offset = "0x33172E4", Length = "0xA0")]
	[Token(Token = "0x6000438")]
	private static void SortDesc(List<RankEntry> list) { }

	[Address(RVA = "0x3312878", Offset = "0x3312878", Length = "0x4")]
	[Token(Token = "0x6000401")]
	private void Start() { }

	[Address(RVA = "0x3314674", Offset = "0x3314674", Length = "0x234")]
	[Token(Token = "0x600041C")]
	public static void SyncForcedName(string uid) { }

	[Address(RVA = "0x3315C1C", Offset = "0x3315C1C", Length = "0x648")]
	[Token(Token = "0x600042A")]
	private static void TryCacheGroupFromResult(HttpsCallableResult res) { }

	[Address(RVA = "0x33137D0", Offset = "0x33137D0", Length = "0x104")]
	[Token(Token = "0x6000415")]
	private static int WeekIndex() { }

	[Address(RVA = "0x33182F0", Offset = "0x33182F0", Length = "0x1A0")]
	[Token(Token = "0x6000432")]
	private static string WeeklyCacheKey(string weekId) { }

}

