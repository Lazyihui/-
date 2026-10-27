namespace Hamdoku.Managers;

[Token(Token = "0x200028D")]
public static class ReceiptVerifier
{
	[CompilerGenerated]
	[Token(Token = "0x2000293")]
	private sealed class <>c__DisplayClass14_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001112")]
		public Action<Result> done; //Field offset: 0x10

		[Address(RVA = "0x32D83C0", Offset = "0x32D83C0", Length = "0x8")]
		[Token(Token = "0x60012B0")]
		public <>c__DisplayClass14_0() { }

		[Address(RVA = "0x32D8804", Offset = "0x32D8804", Length = "0x20")]
		[Token(Token = "0x60012B1")]
		internal void <Verify>b__0(Result r, bool _, EntitlementStatus __) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000294")]
	private sealed class <>c__DisplayClass15_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001113")]
		public string idToken; //Field offset: 0x10

		[Address(RVA = "0x32D8824", Offset = "0x32D8824", Length = "0x8")]
		[Token(Token = "0x60012B2")]
		public <>c__DisplayClass15_0() { }

		[Address(RVA = "0x32D882C", Offset = "0x32D882C", Length = "0x8")]
		[Token(Token = "0x60012B3")]
		internal void <Verify>b__0(string t) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000295")]
	private sealed class <FetchIdToken>d__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001114")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001115")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001116")]
		public Action<string> done; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001117")]
		private Task<string> <task>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4001118")]
		private float <deadline>5__3; //Field offset: 0x30

		[Token(Token = "0x1700028A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32D8B64", Offset = "0x32D8B64", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60012B7")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700028B")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32D8BA4", Offset = "0x32D8BA4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60012B9")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32D845C", Offset = "0x32D845C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60012B4")]
		public <FetchIdToken>d__16(int <>1__state) { }

		[Address(RVA = "0x32D8838", Offset = "0x32D8838", Length = "0x32C")]
		[Token(Token = "0x60012B6")]
		private bool MoveNext() { }

		[Address(RVA = "0x32D8B64", Offset = "0x32D8B64", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60012B7")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32D8BA4", Offset = "0x32D8BA4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60012B9")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32D8B6C", Offset = "0x32D8B6C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60012B8")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32D8834", Offset = "0x32D8834", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60012B5")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000296")]
	private sealed class <Verify>d__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001119")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400111A")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400111B")]
		private <>c__DisplayClass15_0 <>8__1; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400111C")]
		public Product product; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400111D")]
		public Action<Result, bool, EntitlementStatus> done; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400111E")]
		private bool <hadAuth>5__2; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x400111F")]
		private UnityWebRequest <req>5__3; //Field offset: 0x40

		[Token(Token = "0x1700028C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32D9500", Offset = "0x32D9500", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60012BE")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700028D")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32D9540", Offset = "0x32D9540", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60012C0")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32D83C8", Offset = "0x32D83C8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60012BA")]
		public <Verify>d__15(int <>1__state) { }

		[Address(RVA = "0x32D9450", Offset = "0x32D9450", Length = "0xB0")]
		[Token(Token = "0x60012BD")]
		private void <>m__Finally1() { }

		[Address(RVA = "0x32D8BC8", Offset = "0x32D8BC8", Length = "0x888")]
		[Token(Token = "0x60012BC")]
		private bool MoveNext() { }

		[Address(RVA = "0x32D9500", Offset = "0x32D9500", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60012BE")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32D9540", Offset = "0x32D9540", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60012C0")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32D9508", Offset = "0x32D9508", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60012BF")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32D8BAC", Offset = "0x32D8BAC", Length = "0x1C")]
		[DebuggerHidden]
		[Token(Token = "0x60012BB")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x200028F")]
	public enum EntitlementStatus : int
	{
		Unknown = 0,
		Recorded = 1,
		Retry = 2,
		Blocked = 3,
		NotApplicable = 4,
		NoAuth = 5,
	}

	[Token(Token = "0x2000292")]
	private sealed class GoogleOrder
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001111")]
		public string purchaseToken; //Field offset: 0x10

		[Address(RVA = "0x32D87FC", Offset = "0x32D87FC", Length = "0x8")]
		[Token(Token = "0x60012AF")]
		public GoogleOrder() { }

	}

	[Token(Token = "0x2000291")]
	private sealed class GooglePayload
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001110")]
		public string json; //Field offset: 0x10

		[Address(RVA = "0x32D87F4", Offset = "0x32D87F4", Length = "0x8")]
		[Token(Token = "0x60012AE")]
		public GooglePayload() { }

	}

	[Token(Token = "0x200028E")]
	public enum Result : int
	{
		Ok = 0,
		Invalid = 1,
		Retry = 2,
		Unreachable = 3,
	}

	[Token(Token = "0x2000290")]
	private sealed class UnifiedReceipt
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400110F")]
		public string Payload; //Field offset: 0x10

		[Address(RVA = "0x32D87EC", Offset = "0x32D87EC", Length = "0x8")]
		[Token(Token = "0x60012AD")]
		public UnifiedReceipt() { }

	}

	[Token(Token = "0x40010FD")]
	private const string VerifyUrl = "https://asia-northeast3-mobirix-bi.cloudfunctions.net/hamdoku-receipt-verify"; //Field offset: 0x0
	[Token(Token = "0x40010FE")]
	private const int TimeoutSeconds = 15; //Field offset: 0x0
	[Token(Token = "0x40010FF")]
	private const float IdTokenTimeoutSeconds = 5; //Field offset: 0x0
	[Token(Token = "0x4001100")]
	private const string EntitlementHeader = "X-Hamdoku-Entitlement"; //Field offset: 0x0
	[Token(Token = "0x4001101")]
	private const string ClubHeader = "X-Hamdoku-Club"; //Field offset: 0x0
	[Token(Token = "0x4001102")]
	private static readonly Dictionary<string, long[]> _clubStates; //Field offset: 0x0

	[Address(RVA = "0x32D8754", Offset = "0x32D8754", Length = "0x98")]
	[Token(Token = "0x60012AC")]
	private static ReceiptVerifier() { }

	[Address(RVA = "0x32D8484", Offset = "0x32D8484", Length = "0x1F0")]
	[Token(Token = "0x60012A9")]
	private static WWWForm BuildForm(Product product, string idToken) { }

	[Address(RVA = "0x32D8174", Offset = "0x32D8174", Length = "0x15C")]
	[Token(Token = "0x60012AB")]
	private static string ExtractAndroidPurchaseToken(string receipt) { }

	[Address(RVA = "0x32D8674", Offset = "0x32D8674", Length = "0xE0")]
	[Token(Token = "0x60012AA")]
	private static string ExtractReceiptPayload(string receipt) { }

	[Address(RVA = "0x32D1CF8", Offset = "0x32D1CF8", Length = "0x90")]
	[Token(Token = "0x60012A5")]
	public static string ExtractTransactionId(Product product) { }

	[Address(RVA = "0x32D83F0", Offset = "0x32D83F0", Length = "0x6C")]
	[IteratorStateMachine(typeof(<FetchIdToken>d__16))]
	[Token(Token = "0x60012A8")]
	private static IEnumerator FetchIdToken(Action<string> done) { }

	[Address(RVA = "0x32D7C78", Offset = "0x32D7C78", Length = "0x1E8")]
	[Token(Token = "0x60012A2")]
	public static bool IsClubSku(string sku) { }

	[Address(RVA = "0x32D45AC", Offset = "0x32D45AC", Length = "0x18")]
	[Token(Token = "0x60012A0")]
	public static bool IsSettled(EntitlementStatus s) { }

	[Address(RVA = "0x32D801C", Offset = "0x32D801C", Length = "0x158")]
	[Token(Token = "0x60012A4")]
	private static EntitlementStatus ParseEntitlement(string header) { }

	[Address(RVA = "0x32D7A7C", Offset = "0x32D7A7C", Length = "0x1FC")]
	[Token(Token = "0x60012A1")]
	private static void RememberClubState(string sku, string header) { }

	[Address(RVA = "0x32D7E60", Offset = "0x32D7E60", Length = "0x1BC")]
	[Token(Token = "0x60012A3")]
	public static bool TryTakeClubState(string sku, out long untilMs, out long startMs, out int term, out int stamps, out int stampDay, out long rev) { }

	[Address(RVA = "0x32D82D0", Offset = "0x32D82D0", Length = "0xF0")]
	[Token(Token = "0x60012A6")]
	public static IEnumerator Verify(Product product, Action<Result> done) { }

	[Address(RVA = "0x32D4524", Offset = "0x32D4524", Length = "0x88")]
	[IteratorStateMachine(typeof(<Verify>d__15))]
	[Token(Token = "0x60012A7")]
	public static IEnumerator Verify(Product product, Action<Result, bool, EntitlementStatus> done) { }

}

