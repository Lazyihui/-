namespace Hamdoku.Managers;

[Token(Token = "0x20002B4")]
public sealed class StreakRecoverPopup : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20002B5")]
	private sealed class <>c__DisplayClass36_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40012D1")]
		public StreakRecoverPopup <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40012D2")]
		public Action onClick; //Field offset: 0x18

		[Address(RVA = "0x32F407C", Offset = "0x32F407C", Length = "0x8")]
		[Token(Token = "0x60013B0")]
		public <>c__DisplayClass36_0() { }

		[Address(RVA = "0x32F47C8", Offset = "0x32F47C8", Length = "0x48")]
		[Token(Token = "0x60013B1")]
		internal void <MakePill>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20002B6")]
	private sealed class <ArrowLoop>d__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40012D3")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40012D4")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40012D5")]
		public StreakRecoverPopup <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40012D6")]
		private int <n>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x40012D7")]
		private float <step>5__3; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40012D8")]
		private float <fade>5__4; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x40012D9")]
		private float <clear>5__5; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40012DA")]
		private float <clearFrom>5__6; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x40012DB")]
		private float <cycle>5__7; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40012DC")]
		private float <t>5__8; //Field offset: 0x40

		[Token(Token = "0x170002B5")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32F4C08", Offset = "0x32F4C08", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60013B5")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170002B6")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32F4C48", Offset = "0x32F4C48", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60013B7")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32F3284", Offset = "0x32F3284", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60013B2")]
		public <ArrowLoop>d__33(int <>1__state) { }

		[Address(RVA = "0x32F4814", Offset = "0x32F4814", Length = "0x3F4")]
		[Token(Token = "0x60013B4")]
		private bool MoveNext() { }

		[Address(RVA = "0x32F4C08", Offset = "0x32F4C08", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60013B5")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32F4C48", Offset = "0x32F4C48", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60013B7")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32F4C10", Offset = "0x32F4C10", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60013B6")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32F4810", Offset = "0x32F4810", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60013B3")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x40012C6")]
	private static StreakRecoverPopup _open; //Field offset: 0x0
	[Token(Token = "0x40012C7")]
	private static readonly Vector2 RefPanel; //Field offset: 0x8
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40012C8")]
	private CanvasGroup _group; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40012C9")]
	private RectTransform _panel; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40012CA")]
	private RectTransform _content; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40012CB")]
	private int _missedDays; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40012CC")]
	private int _brokenStreak; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40012CD")]
	private bool _preview; //Field offset: 0x40
	[FieldOffset(Offset = "0x41")]
	[Token(Token = "0x40012CE")]
	private bool _busy; //Field offset: 0x41
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40012CF")]
	private readonly List<TMP_Text> _arrows; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40012D0")]
	private readonly List<float> _arrowAlpha; //Field offset: 0x50

	[Token(Token = "0x170002B3")]
	private static StreakPageConfig Cfg
	{
		[Address(RVA = "0x32F02D4", Offset = "0x32F02D4", Length = "0x8")]
		[Token(Token = "0x6001390")]
		 get { } //Length: 8
	}

	[Token(Token = "0x170002B2")]
	public static bool IsOpen
	{
		[Address(RVA = "0x32F0088", Offset = "0x32F0088", Length = "0x8C")]
		[Token(Token = "0x600138D")]
		 get { } //Length: 140
	}

	[Token(Token = "0x170002B4")]
	private static bool RewardedUsable
	{
		[Address(RVA = "0x32F03E0", Offset = "0x32F03E0", Length = "0xB4")]
		[Token(Token = "0x6001394")]
		 get { } //Length: 180
	}

	[Address(RVA = "0x32F45D4", Offset = "0x32F45D4", Length = "0x50")]
	[Token(Token = "0x60013AB")]
	private static StreakRecoverPopup() { }

	[Address(RVA = "0x32F44F8", Offset = "0x32F44F8", Length = "0xDC")]
	[Token(Token = "0x60013AA")]
	public StreakRecoverPopup() { }

	[Address(RVA = "0x32F4624", Offset = "0x32F4624", Length = "0x28")]
	[CompilerGenerated]
	[Token(Token = "0x60013AC")]
	private void <BuildCloseX>b__25_0() { }

	[Address(RVA = "0x32F472C", Offset = "0x32F472C", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x60013AF")]
	private void <Close>b__40_0() { }

	[Address(RVA = "0x32F464C", Offset = "0x32F464C", Length = "0x78")]
	[CompilerGenerated]
	[Token(Token = "0x60013AD")]
	private void <OnRecover>b__37_0() { }

	[Address(RVA = "0x32F46C4", Offset = "0x32F46C4", Length = "0x68")]
	[CompilerGenerated]
	[Token(Token = "0x60013AE")]
	private void <OnRecover>b__37_1() { }

	[Address(RVA = "0x32F3218", Offset = "0x32F3218", Length = "0x6C")]
	[IteratorStateMachine(typeof(<ArrowLoop>d__33))]
	[Token(Token = "0x60013A0")]
	private IEnumerator ArrowLoop() { }

	[Address(RVA = "0x32F0714", Offset = "0x32F0714", Length = "0x6E0")]
	[Token(Token = "0x6001396")]
	private void Build() { }

	[Address(RVA = "0x32F29BC", Offset = "0x32F29BC", Length = "0x4E8")]
	[Token(Token = "0x600139F")]
	private void BuildArrows(RectTransform parent, float y) { }

	[Address(RVA = "0x32F2248", Offset = "0x32F2248", Length = "0x328")]
	[Token(Token = "0x60013A2")]
	private void BuildButtons() { }

	[Address(RVA = "0x32F1148", Offset = "0x32F1148", Length = "0x2D4")]
	[Token(Token = "0x6001398")]
	private void BuildCloseX() { }

	[Address(RVA = "0x32F1EB0", Offset = "0x32F1EB0", Length = "0x398")]
	[Token(Token = "0x60013A1")]
	private void BuildDesc() { }

	[Address(RVA = "0x32F141C", Offset = "0x32F141C", Length = "0xA94")]
	[Token(Token = "0x6001399")]
	private void BuildHero() { }

	[Address(RVA = "0x32F0EC0", Offset = "0x32F0EC0", Length = "0x288")]
	[Token(Token = "0x6001397")]
	private void BuildTitle() { }

	[Address(RVA = "0x32F427C", Offset = "0x32F427C", Length = "0x214")]
	[Token(Token = "0x60013A7")]
	private void Close() { }

	[Address(RVA = "0x32F0114", Offset = "0x32F0114", Length = "0xB4")]
	[Token(Token = "0x600138E")]
	public static void CloseOpen() { }

	[Address(RVA = "0x32F2EA4", Offset = "0x32F2EA4", Length = "0x120")]
	[Token(Token = "0x600139C")]
	private static string Days(int n) { }

	[Address(RVA = "0x32F2604", Offset = "0x32F2604", Length = "0x70")]
	[Token(Token = "0x600139B")]
	private static void FitOneLine(TMP_Text t, float size, float minScale) { }

	[Address(RVA = "0x32F02D4", Offset = "0x32F02D4", Length = "0x8")]
	[Token(Token = "0x6001390")]
	private static StreakPageConfig get_Cfg() { }

	[Address(RVA = "0x32F0088", Offset = "0x32F0088", Length = "0x8C")]
	[Token(Token = "0x600138D")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x32F03E0", Offset = "0x32F03E0", Length = "0xB4")]
	[Token(Token = "0x6001394")]
	private static bool get_RewardedUsable() { }

	[Address(RVA = "0x32F01C8", Offset = "0x32F01C8", Length = "0xA8")]
	[Token(Token = "0x60013A6")]
	private void GiveUp() { }

	[Address(RVA = "0x32F4490", Offset = "0x32F4490", Length = "0x68")]
	[Token(Token = "0x60013A5")]
	private void Grant() { }

	[Address(RVA = "0x32F2570", Offset = "0x32F2570", Length = "0x94")]
	[Token(Token = "0x60013A8")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x32F3118", Offset = "0x32F3118", Length = "0x100")]
	[Token(Token = "0x60013A9")]
	private static string L(string key, string fallback, object[] args) { }

	[Address(RVA = "0x32F2FC4", Offset = "0x32F2FC4", Length = "0x154")]
	[Token(Token = "0x600139A")]
	private static void MakeCaption(string name, RectTransform parent, string text, float x, float y, float size, Color col) { }

	[Address(RVA = "0x32F2780", Offset = "0x32F2780", Length = "0x23C")]
	[Token(Token = "0x600139E")]
	private void MakeFlower(RectTransform parent, string name, Sprite sprite, Vector2 pos, float size, Color tint) { }

	[Address(RVA = "0x32F32AC", Offset = "0x32F32AC", Length = "0xDD0")]
	[Token(Token = "0x60013A3")]
	private void MakePill(string name, string label, bool primary, Vector2 size, float y, Action onClick, bool adIcon) { }

	[Address(RVA = "0x32F0DF4", Offset = "0x32F0DF4", Length = "0xCC")]
	[Token(Token = "0x6001395")]
	private void OnDestroy() { }

	[Address(RVA = "0x32F4084", Offset = "0x32F4084", Length = "0x1F8")]
	[Token(Token = "0x60013A4")]
	private void OnRecover() { }

	[Address(RVA = "0x32F2674", Offset = "0x32F2674", Length = "0x10C")]
	[Token(Token = "0x600139D")]
	private static Sprite PlantSprite(int stage) { }

	[Address(RVA = "0x32F0270", Offset = "0x32F0270", Length = "0x64")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x600138F")]
	private static void ResetStatics() { }

	[Address(RVA = "0x32F0494", Offset = "0x32F0494", Length = "0x210")]
	[Token(Token = "0x6001393")]
	private static void Show(int missedDays, int brokenStreak, bool preview) { }

	[Address(RVA = "0x32F06A4", Offset = "0x32F06A4", Length = "0x70")]
	[Token(Token = "0x6001392")]
	public static void ShowPreview(int missedDays = 1, int brokenStreak = 2) { }

	[Address(RVA = "0x32F02DC", Offset = "0x32F02DC", Length = "0x104")]
	[Token(Token = "0x6001391")]
	public static bool TryShow() { }

}

