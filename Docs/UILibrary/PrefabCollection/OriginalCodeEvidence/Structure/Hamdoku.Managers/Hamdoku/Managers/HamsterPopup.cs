namespace Hamdoku.Managers;

[Token(Token = "0x20001AB")]
public static class HamsterPopup
{
	[CompilerGenerated]
	[Token(Token = "0x20001B0")]
	private sealed class <>c__DisplayClass15_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A8A")]
		public bool consumed; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000A8B")]
		public Options o; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000A8C")]
		public Entry entry; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000A8D")]
		public GameObject canvasGo; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000A8E")]
		public RectTransform frameRt; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000A8F")]
		public Image dimImg; //Field offset: 0x38

		[Address(RVA = "0x32304F8", Offset = "0x32304F8", Length = "0x8")]
		[Token(Token = "0x6000C25")]
		public <>c__DisplayClass15_0() { }

		[Address(RVA = "0x32326A8", Offset = "0x32326A8", Length = "0xC")]
		[Token(Token = "0x6000C27")]
		internal void <Show>b__1() { }

		[Address(RVA = "0x32326B4", Offset = "0x32326B4", Length = "0xC")]
		[Token(Token = "0x6000C28")]
		internal void <Show>b__2() { }

		[Address(RVA = "0x32326C0", Offset = "0x32326C0", Length = "0xC")]
		[Token(Token = "0x6000C29")]
		internal void <Show>b__3() { }

		[Address(RVA = "0x32326CC", Offset = "0x32326CC", Length = "0x8")]
		[Token(Token = "0x6000C2A")]
		internal void <Show>b__4(bool confirmed) { }

		[Address(RVA = "0x323258C", Offset = "0x323258C", Length = "0x11C")]
		[Token(Token = "0x6000C26")]
		internal void <Show>g__Close|0(bool confirmed, bool guarded = false) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001B1")]
	private sealed class <>c__DisplayClass17_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A90")]
		public Action onClick; //Field offset: 0x10

		[Address(RVA = "0x32314C0", Offset = "0x32314C0", Length = "0x8")]
		[Token(Token = "0x6000C2B")]
		public <>c__DisplayClass17_0() { }

		[Address(RVA = "0x32326D4", Offset = "0x32326D4", Length = "0x30")]
		[Token(Token = "0x6000C2C")]
		internal void <BuildClose>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001B2")]
	private sealed class <>c__DisplayClass25_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A91")]
		public Action<bool> close; //Field offset: 0x10

		[Address(RVA = "0x32318A4", Offset = "0x32318A4", Length = "0x8")]
		[Token(Token = "0x6000C2D")]
		public <>c__DisplayClass25_0() { }

		[Address(RVA = "0x3232704", Offset = "0x3232704", Length = "0x24")]
		[Token(Token = "0x6000C2E")]
		internal void <BuildButtons>b__0() { }

		[Address(RVA = "0x3232770", Offset = "0x3232770", Length = "0x24")]
		[Token(Token = "0x6000C31")]
		internal void <BuildButtons>b__1() { }

		[Address(RVA = "0x3232794", Offset = "0x3232794", Length = "0x24")]
		[Token(Token = "0x6000C32")]
		internal void <BuildButtons>b__2() { }

		[Address(RVA = "0x3232728", Offset = "0x3232728", Length = "0x24")]
		[Token(Token = "0x6000C2F")]
		internal void <BuildButtons>b__3() { }

		[Address(RVA = "0x323274C", Offset = "0x323274C", Length = "0x24")]
		[Token(Token = "0x6000C30")]
		internal void <BuildButtons>b__4() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001B3")]
	private sealed class <>c__DisplayClass27_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A92")]
		public Action onClick; //Field offset: 0x10

		[Address(RVA = "0x3231EC8", Offset = "0x3231EC8", Length = "0x8")]
		[Token(Token = "0x6000C33")]
		public <>c__DisplayClass27_0() { }

		[Address(RVA = "0x32327B8", Offset = "0x32327B8", Length = "0x30")]
		[Token(Token = "0x6000C34")]
		internal void <MakeButton>b__0() { }

	}

	[Token(Token = "0x20001AE")]
	private sealed class ClickGuard : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x20001AF")]
		private sealed class <Run>d__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[FieldOffset(Offset = "0x10")]
			[Token(Token = "0x4000A86")]
			private int <>1__state; //Field offset: 0x10
			[FieldOffset(Offset = "0x18")]
			[Token(Token = "0x4000A87")]
			private object <>2__current; //Field offset: 0x18
			[FieldOffset(Offset = "0x20")]
			[Token(Token = "0x4000A88")]
			public GameObject canvasGo; //Field offset: 0x20
			[FieldOffset(Offset = "0x28")]
			[Token(Token = "0x4000A89")]
			private float <until>5__2; //Field offset: 0x28

			[Token(Token = "0x170001AE")]
			private object System.Collections.Generic.IEnumerator<System.Object>.Current
			{
				[Address(RVA = "0x3232544", Offset = "0x3232544", Length = "0x8")]
				[DebuggerHidden]
				[Token(Token = "0x6000C22")]
				 get { } //Length: 8
			}

			[Token(Token = "0x170001AF")]
			private object System.Collections.IEnumerator.Current
			{
				[Address(RVA = "0x3232584", Offset = "0x3232584", Length = "0x8")]
				[DebuggerHidden]
				[Token(Token = "0x6000C24")]
				 get { } //Length: 8
			}

			[Address(RVA = "0x32322DC", Offset = "0x32322DC", Length = "0x28")]
			[DebuggerHidden]
			[Token(Token = "0x6000C1F")]
			public <Run>d__2(int <>1__state) { }

			[Address(RVA = "0x3232418", Offset = "0x3232418", Length = "0x12C")]
			[Token(Token = "0x6000C21")]
			private bool MoveNext() { }

			[Address(RVA = "0x3232544", Offset = "0x3232544", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000C22")]
			private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

			[Address(RVA = "0x3232584", Offset = "0x3232584", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000C24")]
			private object System.Collections.IEnumerator.get_Current() { }

			[Address(RVA = "0x323254C", Offset = "0x323254C", Length = "0x38")]
			[DebuggerHidden]
			[Token(Token = "0x6000C23")]
			private void System.Collections.IEnumerator.Reset() { }

			[Address(RVA = "0x3232414", Offset = "0x3232414", Length = "0x4")]
			[DebuggerHidden]
			[Token(Token = "0x6000C20")]
			private void System.IDisposable.Dispose() { }

		}

		[Token(Token = "0x4000A85")]
		private const float MaxSeconds = 1; //Field offset: 0x0

		[Address(RVA = "0x323240C", Offset = "0x323240C", Length = "0x8")]
		[Token(Token = "0x6000C1E")]
		public ClickGuard() { }

		[Address(RVA = "0x3232028", Offset = "0x3232028", Length = "0x248")]
		[Token(Token = "0x6000C1B")]
		public static void Begin(GameObject canvasGo, RectTransform frame, Image dim) { }

		[Address(RVA = "0x3232304", Offset = "0x3232304", Length = "0x108")]
		[Token(Token = "0x6000C1D")]
		private static bool PointerHeld() { }

		[Address(RVA = "0x3232270", Offset = "0x3232270", Length = "0x6C")]
		[IteratorStateMachine(typeof(<Run>d__2))]
		[Token(Token = "0x6000C1C")]
		private static IEnumerator Run(GameObject canvasGo) { }

	}

	[Token(Token = "0x20001AD")]
	private sealed class Entry
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A81")]
		public GameObject Root; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000A82")]
		public string Tag; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000A83")]
		public Action Cancel; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000A84")]
		public bool Dismissible; //Field offset: 0x28

		[Address(RVA = "0x3230500", Offset = "0x3230500", Length = "0x10")]
		[Token(Token = "0x6000C1A")]
		public Entry() { }

	}

	[Token(Token = "0x20001AC")]
	public sealed class Options
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000A68")]
		public string titleKey; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000A69")]
		public string messageKey; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000A6A")]
		public string confirmKey; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000A6B")]
		public string cancelKey; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000A6C")]
		public string titleText; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000A6D")]
		public string messageText; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000A6E")]
		public string confirmText; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000A6F")]
		public string cancelText; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000A70")]
		public Action onConfirm; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000A71")]
		public Action onCancel; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x4000A72")]
		public bool showCloseButton; //Field offset: 0x60
		[FieldOffset(Offset = "0x61")]
		[Token(Token = "0x4000A73")]
		public bool closeOnDim; //Field offset: 0x61
		[FieldOffset(Offset = "0x62")]
		[Token(Token = "0x4000A74")]
		public bool dismissible; //Field offset: 0x62
		[FieldOffset(Offset = "0x64")]
		[Token(Token = "0x4000A75")]
		public float frameHeight; //Field offset: 0x64
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x4000A76")]
		public float boxHeight; //Field offset: 0x68
		[FieldOffset(Offset = "0x6C")]
		[Token(Token = "0x4000A77")]
		public float boxTop; //Field offset: 0x6C
		[FieldOffset(Offset = "0x70")]
		[Token(Token = "0x4000A78")]
		public bool confirmIsPrice; //Field offset: 0x70
		[FieldOffset(Offset = "0x74")]
		[Token(Token = "0x4000A79")]
		public float messageRaise; //Field offset: 0x74
		[FieldOffset(Offset = "0x78")]
		[Token(Token = "0x4000A7A")]
		public bool boxPlain; //Field offset: 0x78
		[FieldOffset(Offset = "0x80")]
		[Token(Token = "0x4000A7B")]
		public string footerText; //Field offset: 0x80
		[FieldOffset(Offset = "0x88")]
		[Token(Token = "0x4000A7C")]
		public bool stackedButtons; //Field offset: 0x88
		[FieldOffset(Offset = "0x90")]
		[Token(Token = "0x4000A7D")]
		public Func<bool, bool> closeGuard; //Field offset: 0x90
		[FieldOffset(Offset = "0x98")]
		[Token(Token = "0x4000A7E")]
		public Action<RectTransform, ShopPopupLayout> body; //Field offset: 0x98
		[FieldOffset(Offset = "0xA0")]
		[Token(Token = "0x4000A7F")]
		public Action<RectTransform, ShopPopupLayout, float> decor; //Field offset: 0xA0
		[FieldOffset(Offset = "0xA8")]
		[Token(Token = "0x4000A80")]
		public string tag; //Field offset: 0xA8

		[Address(RVA = "0x3231FC0", Offset = "0x3231FC0", Length = "0x68")]
		[Token(Token = "0x6000C19")]
		public Options() { }

	}

	[Token(Token = "0x4000A5D")]
	public const int BaseSortingOrder = 31000; //Field offset: 0x0
	[Token(Token = "0x4000A5E")]
	private const string FramePath = "UI/popup_frame"; //Field offset: 0x0
	[Token(Token = "0x4000A5F")]
	private const string BtnPath = "UI/popup_btn_pink"; //Field offset: 0x0
	[Token(Token = "0x4000A60")]
	private const string BtnCancelPath = "UI/popup_btn_gray"; //Field offset: 0x0
	[Token(Token = "0x4000A61")]
	private const string ClosePath = "UI/popup_btn_close"; //Field offset: 0x0
	[Token(Token = "0x4000A62")]
	private static readonly List<Entry> _stack; //Field offset: 0x0
	[Token(Token = "0x4000A64")]
	private const float BoxButtonGap = 52; //Field offset: 0x0
	[Token(Token = "0x4000A65")]
	private const float FooterH = 82; //Field offset: 0x0
	[Token(Token = "0x4000A66")]
	private const float FooterGap = 22; //Field offset: 0x0
	[Token(Token = "0x4000A67")]
	private const float FooterDrop = 18; //Field offset: 0x0
	[Token(Token = "0x4000A63")]
	private static readonly Dictionary<int, Sprite> _softCircles; //Field offset: 0x8

	[Token(Token = "0x170001AD")]
	public static bool IsOpen
	{
		[Address(RVA = "0x322EF38", Offset = "0x322EF38", Length = "0x58")]
		[Token(Token = "0x6000C0A")]
		 get { } //Length: 88
	}

	[Address(RVA = "0x3231ED0", Offset = "0x3231ED0", Length = "0xF0")]
	[Token(Token = "0x6000C18")]
	private static HamsterPopup() { }

	[Address(RVA = "0x322EF90", Offset = "0x322EF90", Length = "0x194")]
	[Token(Token = "0x6000C0D")]
	private static Entry Alive() { }

	[Address(RVA = "0x3230C8C", Offset = "0x3230C8C", Length = "0x2C4")]
	[Token(Token = "0x6000C12")]
	private static void BuildBox(RectTransform frame, ShopPopupLayout cfg, float creamY, float bodyW, float boxTop, float boxH, Action<RectTransform, ShopPopupLayout> body, bool plain = false) { }

	[Address(RVA = "0x3230F50", Offset = "0x3230F50", Length = "0x368")]
	[Token(Token = "0x6000C13")]
	private static void BuildButtons(RectTransform frame, ShopPopupLayout cfg, Options o, Action<bool> close) { }

	[Address(RVA = "0x32305D4", Offset = "0x32305D4", Length = "0x534")]
	[Token(Token = "0x6000C0F")]
	private static void BuildClose(RectTransform frame, ShopPopupLayout cfg, Action onClick) { }

	[Address(RVA = "0x32312B8", Offset = "0x32312B8", Length = "0x208")]
	[Token(Token = "0x6000C11")]
	private static void BuildFooter(RectTransform frame, ShopPopupLayout cfg, float bodyW, string text) { }

	[Address(RVA = "0x322F124", Offset = "0x322F124", Length = "0x80")]
	[Token(Token = "0x6000C0B")]
	public static bool CloseTop() { }

	[Address(RVA = "0x322F1A4", Offset = "0x322F1A4", Length = "0x1AC")]
	[Token(Token = "0x6000C0C")]
	public static int DiscardByTag(string tag) { }

	[Address(RVA = "0x32305A0", Offset = "0x32305A0", Length = "0x34")]
	[Token(Token = "0x6000C10")]
	private static float FooterOffset(Options o) { }

	[Address(RVA = "0x322EF38", Offset = "0x322EF38", Length = "0x58")]
	[Token(Token = "0x6000C0A")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x32314C8", Offset = "0x32314C8", Length = "0x3DC")]
	[Token(Token = "0x6000C17")]
	private static Sprite GetSoftCircle(float coreRatio) { }

	[Address(RVA = "0x32318AC", Offset = "0x32318AC", Length = "0x61C")]
	[Token(Token = "0x6000C15")]
	private static void MakeButton(RectTransform frame, ShopPopupLayout cfg, string label, Vector2 size, float x, float bottom, bool primary, Action onClick, bool priceFont = false) { }

	[Address(RVA = "0x3230B08", Offset = "0x3230B08", Length = "0x184")]
	[Token(Token = "0x6000C16")]
	private static TMP_Text MakeTop(RectTransform parent, string name, string text, float fs, Color col, float y, Vector2 size) { }

	[Address(RVA = "0x322EE80", Offset = "0x322EE80", Length = "0xB8")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000C09")]
	private static void ResetStatics() { }

	[Address(RVA = "0x322F350", Offset = "0x322F350", Length = "0x11A8")]
	[Token(Token = "0x6000C0E")]
	public static void Show(Options o) { }

	[Address(RVA = "0x3230510", Offset = "0x3230510", Length = "0x90")]
	[Token(Token = "0x6000C14")]
	private static string Text(string raw, string key) { }

}

