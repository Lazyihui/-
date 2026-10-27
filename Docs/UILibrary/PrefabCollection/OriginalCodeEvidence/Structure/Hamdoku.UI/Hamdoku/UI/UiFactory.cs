namespace Hamdoku.UI;

[Token(Token = "0x20000DB")]
public static class UiFactory
{
	[CompilerGenerated]
	[Token(Token = "0x20000DC")]
	private sealed class <PopIn>d__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D88")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D89")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D8A")]
		public float dur; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D8B")]
		public Transform target; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000D8C")]
		private float <t>5__2; //Field offset: 0x30

		[Token(Token = "0x170000E3")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x343F270", Offset = "0x343F270", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60005DE")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170000E4")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x343F2B0", Offset = "0x343F2B0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60005E0")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x343D5C4", Offset = "0x343D5C4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60005DB")]
		public <PopIn>d__22(int <>1__state) { }

		[Address(RVA = "0x343F118", Offset = "0x343F118", Length = "0x158")]
		[Token(Token = "0x60005DD")]
		private bool MoveNext() { }

		[Address(RVA = "0x343F270", Offset = "0x343F270", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60005DE")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x343F2B0", Offset = "0x343F2B0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60005E0")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x343F278", Offset = "0x343F278", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60005DF")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x343F114", Offset = "0x343F114", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60005DC")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000D74")]
	public const float RefWidth = 1080; //Field offset: 0x0
	[Token(Token = "0x4000D85")]
	public const float ShadowBlurPx = 28; //Field offset: 0x0
	[Token(Token = "0x4000D82")]
	public const float SoftShadowBlurPx = 32; //Field offset: 0x0
	[Token(Token = "0x4000D86")]
	public const float ShadowEdgeInsetPx = 32; //Field offset: 0x0
	[Token(Token = "0x4000D7C")]
	public const float CellRimFrac = 0.7; //Field offset: 0x0
	[Token(Token = "0x4000D7D")]
	public const float CellRimDefaultCorner = 0.2; //Field offset: 0x0
	[Token(Token = "0x4000D76")]
	public static readonly Color DimOverlay; //Field offset: 0x0
	[Token(Token = "0x4000D75")]
	public const float RefHeight = 1920; //Field offset: 0x0
	[Token(Token = "0x4000D77")]
	private static Sprite _rounded; //Field offset: 0x10
	[Token(Token = "0x4000D78")]
	private static Sprite _copyIcon; //Field offset: 0x18
	[Token(Token = "0x4000D79")]
	private static Sprite _sunburst; //Field offset: 0x20
	[Token(Token = "0x4000D7A")]
	private static Sprite _glow; //Field offset: 0x28
	[Token(Token = "0x4000D7B")]
	private static readonly Dictionary<int, Sprite> _shadowDiscs; //Field offset: 0x30
	[Token(Token = "0x4000D7E")]
	private static readonly Dictionary<int, Sprite> _cellRim; //Field offset: 0x38
	[Token(Token = "0x4000D7F")]
	private static readonly Dictionary<int, Sprite> _cellRimGlow; //Field offset: 0x40
	[Token(Token = "0x4000D80")]
	private static Sprite _dimCorner; //Field offset: 0x48
	[Token(Token = "0x4000D81")]
	private static Sprite _softRect; //Field offset: 0x50
	[Token(Token = "0x4000D83")]
	private static Sprite _glowRing; //Field offset: 0x58
	[Token(Token = "0x4000D84")]
	private static Sprite _outerShadow; //Field offset: 0x60
	[Token(Token = "0x4000D87")]
	private static Sprite _sparkle; //Field offset: 0x68

	[Token(Token = "0x170000E2")]
	public static Sprite CopyIcon
	{
		[Address(RVA = "0x343B960", Offset = "0x343B960", Length = "0xDC")]
		[Token(Token = "0x60005BF")]
		 get { } //Length: 220
	}

	[Token(Token = "0x170000E1")]
	public static Sprite Rounded
	{
		[Address(RVA = "0x343B850", Offset = "0x343B850", Length = "0x110")]
		[Token(Token = "0x60005BE")]
		 get { } //Length: 272
	}

	[Address(RVA = "0x343F020", Offset = "0x343F020", Length = "0xF4")]
	[Token(Token = "0x60005DA")]
	private static UiFactory() { }

	[Address(RVA = "0x343E25C", Offset = "0x343E25C", Length = "0x254")]
	[Token(Token = "0x60005D4")]
	private static Sprite BuildCellRim(float cornerRatio, float spread, float falloff) { }

	[Address(RVA = "0x343BA3C", Offset = "0x343BA3C", Length = "0x1A4")]
	[Token(Token = "0x60005C0")]
	private static Sprite BuildCopyIcon() { }

	[Address(RVA = "0x343DFE0", Offset = "0x343DFE0", Length = "0x208")]
	[Token(Token = "0x60005D3")]
	private static Sprite CachedCellRim(Dictionary<int, Sprite> cache, float cornerRatio, float spread, float falloff) { }

	[Address(RVA = "0x343E1E8", Offset = "0x343E1E8", Length = "0x74")]
	[Token(Token = "0x60005D2")]
	public static Sprite CellRimGlowSprite(float cornerRatio = 0.2) { }

	[Address(RVA = "0x343DF6C", Offset = "0x343DF6C", Length = "0x74")]
	[Token(Token = "0x60005D1")]
	public static Sprite CellRimSprite(float cornerRatio = 0.2) { }

	[Address(RVA = "0x343D450", Offset = "0x343D450", Length = "0xF8")]
	[Token(Token = "0x60005CC")]
	public static Canvas ConfigureOverlayCanvas(GameObject go, int sortingOrder) { }

	[Address(RVA = "0x343DCFC", Offset = "0x343DCFC", Length = "0x270")]
	[Token(Token = "0x60005D0")]
	public static Sprite DimCornerSprite() { }

	[Address(RVA = "0x343BBE0", Offset = "0x343BBE0", Length = "0x1D8")]
	[Token(Token = "0x60005C1")]
	private static void DrawRectOutline(Texture2D tex, int x0, int y0, int x1, int y1, Color c, int thickness) { }

	[Address(RVA = "0x343CCBC", Offset = "0x343CCBC", Length = "0x54")]
	[Token(Token = "0x60005C9")]
	private static void EnableCapsuleAutoShrink(TMP_Text t, float size) { }

	[Address(RVA = "0x343CD10", Offset = "0x343CD10", Length = "0x208")]
	[Token(Token = "0x60005C7")]
	public static void FitTimeCapsule(TMP_Text text, RectTransform capsule, string widthTemplate, float height, float fontSize, float iconScale = 0.62) { }

	[Address(RVA = "0x343B960", Offset = "0x343B960", Length = "0xDC")]
	[Token(Token = "0x60005BF")]
	public static Sprite get_CopyIcon() { }

	[Address(RVA = "0x343B850", Offset = "0x343B850", Length = "0x110")]
	[Token(Token = "0x60005BE")]
	public static Sprite get_Rounded() { }

	[Address(RVA = "0x34385C8", Offset = "0x34385C8", Length = "0x294")]
	[Token(Token = "0x60005D7")]
	public static Sprite GlowRingSprite() { }

	[Address(RVA = "0x343E4B0", Offset = "0x343E4B0", Length = "0x2A4")]
	[Token(Token = "0x60005D5")]
	public static Sprite GlowSprite() { }

	[Address(RVA = "0x343D18C", Offset = "0x343D18C", Length = "0x2C4")]
	[Token(Token = "0x60005CB")]
	public static GameObject MakeAdBadge(RectTransform parent, Vector2 size) { }

	[Address(RVA = "0x343BEAC", Offset = "0x343BEAC", Length = "0x314")]
	[Token(Token = "0x60005C5")]
	public static RectTransform MakeDashedLine(RectTransform parent, float width, float dashLength, float gap, float thickness, Color color) { }

	[Address(RVA = "0x343CF18", Offset = "0x343CF18", Length = "0x274")]
	[Token(Token = "0x60005CA")]
	public static TMP_Text MakeText(string name, RectTransform parent, string text, float size, Color color, Vector2 pos, Vector2 sizeDelta) { }

	[Address(RVA = "0x343C1C0", Offset = "0x343C1C0", Length = "0x9C4")]
	[Token(Token = "0x60005C6")]
	public static TMP_Text MakeTimeCapsule(string name, RectTransform parent, TMP_Text fontSource, float height, Color capsuleColor, Color textColor, string widthTemplate, out RectTransform capsule, float iconScale = 0.62, string iconPath = "icon_timer") { }

	[Address(RVA = "0x343CB84", Offset = "0x343CB84", Length = "0x138")]
	[Token(Token = "0x60005C8")]
	private static float MeasureCapsuleText(TMP_Text t, string template) { }

	[Address(RVA = "0x3438488", Offset = "0x3438488", Length = "0x140")]
	[Token(Token = "0x60005C2")]
	public static GameObject NewRect(string name, RectTransform parent) { }

	[Address(RVA = "0x343EA04", Offset = "0x343EA04", Length = "0x2C0")]
	[Token(Token = "0x60005D8")]
	public static Sprite OuterShadowSprite() { }

	[Address(RVA = "0x343D548", Offset = "0x343D548", Length = "0x7C")]
	[IteratorStateMachine(typeof(<PopIn>d__22))]
	[Token(Token = "0x60005CD")]
	public static IEnumerator PopIn(Transform target, float dur = 0.2) { }

	[Address(RVA = "0x3437DC0", Offset = "0x3437DC0", Length = "0x134")]
	[Token(Token = "0x60005C4")]
	public static void SetRounded(Image img, Color color) { }

	[Address(RVA = "0x343D924", Offset = "0x343D924", Length = "0x3D8")]
	[Token(Token = "0x60005CF")]
	public static Sprite SoftDiscShadow(float coreRatio) { }

	[Address(RVA = "0x343E754", Offset = "0x343E754", Length = "0x2B0")]
	[Token(Token = "0x60005D6")]
	public static Sprite SoftRectShadowSprite() { }

	[Address(RVA = "0x343ECC4", Offset = "0x343ECC4", Length = "0x35C")]
	[Token(Token = "0x60005D9")]
	public static Sprite SparkleSprite() { }

	[Address(RVA = "0x343BDB8", Offset = "0x343BDB8", Length = "0xF4")]
	[Token(Token = "0x60005C3")]
	public static void Stretch(RectTransform rt) { }

	[Address(RVA = "0x343D5EC", Offset = "0x343D5EC", Length = "0x338")]
	[Token(Token = "0x60005CE")]
	public static Sprite SunburstSprite(int spokes = 12) { }

}

