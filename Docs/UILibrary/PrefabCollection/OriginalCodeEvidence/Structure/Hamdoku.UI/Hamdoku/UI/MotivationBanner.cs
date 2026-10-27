namespace Hamdoku.UI;

[Token(Token = "0x2000097")]
public static class MotivationBanner
{
	[CompilerGenerated]
	[Token(Token = "0x200009A")]
	private sealed class <>c__DisplayClass11_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007EA")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3419198", Offset = "0x3419198", Length = "0x8")]
		[Token(Token = "0x6000423")]
		public <>c__DisplayClass11_0() { }

		[Address(RVA = "0x341AF5C", Offset = "0x341AF5C", Length = "0x90")]
		[Token(Token = "0x6000424")]
		internal void <Dismiss>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200009B")]
	private sealed class <>c__DisplayClass14_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007EB")]
		public GameObject canvasGo; //Field offset: 0x10

		[Address(RVA = "0x3419F10", Offset = "0x3419F10", Length = "0x8")]
		[Token(Token = "0x6000425")]
		public <>c__DisplayClass14_0() { }

		[Address(RVA = "0x341AFEC", Offset = "0x341AFEC", Length = "0x108")]
		[Token(Token = "0x6000426")]
		internal void <Show>b__0() { }

	}

	[Token(Token = "0x2000099")]
	private sealed class DismissWatcher : MonoBehaviour
	{
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40007E8")]
		public GameObject Owner; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40007E9")]
		private bool _armed; //Field offset: 0x28

		[Address(RVA = "0x341AF54", Offset = "0x341AF54", Length = "0x8")]
		[Token(Token = "0x6000422")]
		public DismissWatcher() { }

		[Address(RVA = "0x341AE34", Offset = "0x341AE34", Length = "0x120")]
		[Token(Token = "0x6000421")]
		private void Update() { }

	}

	[Token(Token = "0x2000098")]
	public struct Style
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40007DC")]
		public float Hold; //Field offset: 0x0
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x40007DD")]
		public float Fade; //Field offset: 0x4
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40007DE")]
		public float AnchorY; //Field offset: 0x8
		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x40007DF")]
		public float EdgeFade; //Field offset: 0xC
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007E0")]
		public float EdgeAlpha; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x40007E1")]
		public float Alpha; //Field offset: 0x14
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007E2")]
		public float LineSpacing; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40007E3")]
		public float PadY; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40007E4")]
		public float TitleScale; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x40007E5")]
		public float TitleGap; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40007E6")]
		public Color TitleTint; //Field offset: 0x28
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40007E7")]
		public bool TitleIconRaw; //Field offset: 0x38

		[Token(Token = "0x170000A8")]
		public static Style Default
		{
			[Address(RVA = "0x3419238", Offset = "0x3419238", Length = "0x2C")]
			[Token(Token = "0x6000420")]
			 get { } //Length: 44
		}

		[Address(RVA = "0x3419238", Offset = "0x3419238", Length = "0x2C")]
		[Token(Token = "0x6000420")]
		public static Style get_Default() { }

	}

	[Token(Token = "0x40007C9")]
	private const int BaseSortingOrder = 31000; //Field offset: 0x0
	[Token(Token = "0x40007D9")]
	private const float FontSizeMax = 56; //Field offset: 0x0
	[Token(Token = "0x40007D8")]
	private const float FontSizeMin = 30; //Field offset: 0x0
	[Token(Token = "0x40007D7")]
	private const float TitleIconScale = 1.05; //Field offset: 0x0
	[Token(Token = "0x40007D6")]
	private const float TitleIconGap = 10; //Field offset: 0x0
	[Token(Token = "0x40007D5")]
	public const string FlameIconPath = "UI/Icons/icon_flame"; //Field offset: 0x0
	[Token(Token = "0x40007DA")]
	private const float SidePad = 60; //Field offset: 0x0
	[Token(Token = "0x40007DB")]
	private const float MinHeight = 160; //Field offset: 0x0
	[Token(Token = "0x40007CA")]
	private static int _order; //Field offset: 0x0
	[Token(Token = "0x40007CB")]
	private static GameObject _current; //Field offset: 0x8
	[Token(Token = "0x40007CC")]
	private static CanvasGroup _currentGroup; //Field offset: 0x10
	[Token(Token = "0x40007CD")]
	private static Sequence _currentSeq; //Field offset: 0x18
	[Token(Token = "0x40007CE")]
	public static readonly Color HighlightColor; //Field offset: 0x20
	[Token(Token = "0x40007CF")]
	private static Sprite _fade; //Field offset: 0x30
	[Token(Token = "0x40007D0")]
	private static float _fadeEdge; //Field offset: 0x38
	[Token(Token = "0x40007D1")]
	private static float _fadeEdgeAlpha; //Field offset: 0x3C
	[Token(Token = "0x40007D2")]
	private static readonly Color BarColor; //Field offset: 0x40
	[Token(Token = "0x40007D3")]
	private static readonly Color TextColor; //Field offset: 0x50
	[Token(Token = "0x40007D4")]
	public static readonly Color TitleColor; //Field offset: 0x60

	[Token(Token = "0x170000A7")]
	public static bool IsShowing
	{
		[Address(RVA = "0x3418D0C", Offset = "0x3418D0C", Length = "0x8C")]
		[Token(Token = "0x6000416")]
		 get { } //Length: 140
	}

	[Address(RVA = "0x341ADA4", Offset = "0x341ADA4", Length = "0x90")]
	[Token(Token = "0x600041F")]
	private static MotivationBanner() { }

	[Address(RVA = "0x341A390", Offset = "0x341A390", Length = "0x20C")]
	[Token(Token = "0x600041C")]
	private static void ApplyFont(TextMeshProUGUI t) { }

	[Address(RVA = "0x341A59C", Offset = "0x341A59C", Length = "0x808")]
	[Token(Token = "0x600041D")]
	private static float BuildTitle(Transform bar, string title, Sprite icon, float scale, float gapBelow, float padY, Color titleColor, bool iconRaw) { }

	[Address(RVA = "0x3418EF0", Offset = "0x3418EF0", Length = "0x2A8")]
	[Token(Token = "0x6000418")]
	public static void Dismiss(float fade = 0.15) { }

	[Address(RVA = "0x3419F18", Offset = "0x3419F18", Length = "0x478")]
	[Token(Token = "0x600041E")]
	private static Sprite EdgeFadeSprite(float edge, float edgeAlpha) { }

	[Address(RVA = "0x3418D0C", Offset = "0x3418D0C", Length = "0x8C")]
	[Token(Token = "0x6000416")]
	public static bool get_IsShowing() { }

	[Address(RVA = "0x3418D98", Offset = "0x3418D98", Length = "0x158")]
	[Token(Token = "0x6000417")]
	public static void Hide() { }

	[Address(RVA = "0x3418C6C", Offset = "0x3418C6C", Length = "0xA0")]
	[Token(Token = "0x6000415")]
	public static string Highlight(object value) { }

	[Address(RVA = "0x34191A0", Offset = "0x34191A0", Length = "0x98")]
	[Token(Token = "0x6000419")]
	public static void Show(string message) { }

	[Address(RVA = "0x3419264", Offset = "0x3419264", Length = "0x6C")]
	[Token(Token = "0x600041A")]
	public static void Show(string message, in Style style) { }

	[Address(RVA = "0x34192D0", Offset = "0x34192D0", Length = "0xC40")]
	[Token(Token = "0x600041B")]
	public static void Show(string message, in Style style, string title, Sprite titleIcon) { }

}

