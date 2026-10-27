namespace Hamdoku.Managers;

[Token(Token = "0x2000114")]
public sealed class PearlSkinDemo : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000115")]
	private sealed class <>c__DisplayClass20_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400062A")]
		public TMP_Text pillT; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400062B")]
		public Image face; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400062C")]
		public Sprite facePearl; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400062D")]
		public Image pillImg; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400062E")]
		public RectTransform pill; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400062F")]
		public Image[] hams; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000630")]
		public Sprite[] pearl; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000631")]
		public Sprite[] basic; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000632")]
		public float cell; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000633")]
		public Sprite faceBasic; //Field offset: 0x58

		[Address(RVA = "0x337C2E0", Offset = "0x337C2E0", Length = "0x8")]
		[Token(Token = "0x60006AE")]
		public <>c__DisplayClass20_0() { }

		[Address(RVA = "0x337C2E8", Offset = "0x337C2E8", Length = "0x218")]
		[Token(Token = "0x60006AF")]
		internal void <BuildStage>b__0() { }

		[Address(RVA = "0x337C500", Offset = "0x337C500", Length = "0x1F0")]
		[Token(Token = "0x60006B0")]
		internal void <BuildStage>b__1() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000116")]
	private sealed class <>c__DisplayClass20_1
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000634")]
		public int j; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000635")]
		public <>c__DisplayClass20_0 CS$<>8__locals1; //Field offset: 0x18

		[Address(RVA = "0x337C6F0", Offset = "0x337C6F0", Length = "0x8")]
		[Token(Token = "0x60006B1")]
		public <>c__DisplayClass20_1() { }

		[Address(RVA = "0x337C6F8", Offset = "0x337C6F8", Length = "0x338")]
		[Token(Token = "0x60006B2")]
		internal void <BuildStage>b__2() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000117")]
	private sealed class <>c__DisplayClass24_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000636")]
		public Image f; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000637")]
		public Image s; //Field offset: 0x18

		[Address(RVA = "0x337CA30", Offset = "0x337CA30", Length = "0x8")]
		[Token(Token = "0x60006B3")]
		public <>c__DisplayClass24_0() { }

		[Address(RVA = "0x337CA38", Offset = "0x337CA38", Length = "0x74")]
		[Token(Token = "0x60006B4")]
		internal void <Flash>b__0() { }

		[Address(RVA = "0x337CAAC", Offset = "0x337CAAC", Length = "0x74")]
		[Token(Token = "0x60006B5")]
		internal void <Flash>b__1() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000118")]
	private sealed class <>c__DisplayClass6_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000638")]
		public string source; //Field offset: 0x10

		[Address(RVA = "0x337CB20", Offset = "0x337CB20", Length = "0x8")]
		[Token(Token = "0x60006B6")]
		public <>c__DisplayClass6_0() { }

		[Address(RVA = "0x337CB28", Offset = "0x337CB28", Length = "0xDC")]
		[Token(Token = "0x60006B7")]
		internal void <AttachInfo>b__0() { }

	}

	[Token(Token = "0x4000620")]
	private const int N = 6; //Field offset: 0x0
	[Token(Token = "0x4000621")]
	private static readonly int[] Regions; //Field offset: 0x0
	[Token(Token = "0x4000622")]
	private static readonly Vector2Int[] Placements; //Field offset: 0x8
	[Token(Token = "0x4000623")]
	private static readonly Color BasicCol; //Field offset: 0x10
	[Token(Token = "0x4000624")]
	private static readonly Color GoldCol; //Field offset: 0x20
	[Token(Token = "0x4000625")]
	private static PearlSkinDemo _open; //Field offset: 0x30
	[Token(Token = "0x4000626")]
	private static readonly Vector2 RefPanel; //Field offset: 0x38
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000627")]
	private CanvasGroup _group; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000628")]
	private RectTransform _panel; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000629")]
	private RectTransform _content; //Field offset: 0x30

	[Token(Token = "0x170000B0")]
	public static bool IsOpen
	{
		[Address(RVA = "0x335633C", Offset = "0x335633C", Length = "0x8C")]
		[Token(Token = "0x600069D")]
		 get { } //Length: 140
	}

	[Address(RVA = "0x33596CC", Offset = "0x33596CC", Length = "0x18C")]
	[Token(Token = "0x60006AA")]
	private static PearlSkinDemo() { }

	[Address(RVA = "0x33596C4", Offset = "0x33596C4", Length = "0x8")]
	[Token(Token = "0x60006A9")]
	public PearlSkinDemo() { }

	[Address(RVA = "0x3359858", Offset = "0x3359858", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x60006AB")]
	private void <BuildCloseX>b__21_0() { }

	[Address(RVA = "0x3359874", Offset = "0x3359874", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x60006AC")]
	private void <BuildOkButton>b__22_0() { }

	[Address(RVA = "0x3359890", Offset = "0x3359890", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x60006AD")]
	private void <Close>b__23_0() { }

	[Address(RVA = "0x3355DA8", Offset = "0x3355DA8", Length = "0x3AC")]
	[Token(Token = "0x600069C")]
	public static void AttachInfo(RectTransform tile, float iconSide, float hitSide, Vector2 offset, string source) { }

	[Address(RVA = "0x335660C", Offset = "0x335660C", Length = "0x934")]
	[Token(Token = "0x60006A3")]
	private void Build() { }

	[Address(RVA = "0x3357328", Offset = "0x3357328", Length = "0x2D4")]
	[Token(Token = "0x60006A5")]
	private void BuildCloseX() { }

	[Address(RVA = "0x3358878", Offset = "0x3358878", Length = "0x838")]
	[Token(Token = "0x60006A6")]
	private void BuildOkButton(ShopPopupLayout cfg) { }

	[Address(RVA = "0x33575FC", Offset = "0x33575FC", Length = "0x127C")]
	[Token(Token = "0x60006A4")]
	private void BuildStage(ShopPopupLayout cfg) { }

	[Address(RVA = "0x3357258", Offset = "0x3357258", Length = "0xD0")]
	[Token(Token = "0x60006A2")]
	private static ShopPopupLayout Cfg() { }

	[Address(RVA = "0x3357004", Offset = "0x3357004", Length = "0x190")]
	[Token(Token = "0x60006A7")]
	private void Close() { }

	[Address(RVA = "0x3356F40", Offset = "0x3356F40", Length = "0xC4")]
	[Token(Token = "0x60006A0")]
	public static void CloseOpen() { }

	[Address(RVA = "0x33590B0", Offset = "0x33590B0", Length = "0x614")]
	[Token(Token = "0x60006A8")]
	private static void Flash(RectTransform cellRt, float cell) { }

	[Address(RVA = "0x335633C", Offset = "0x335633C", Length = "0x8C")]
	[Token(Token = "0x600069D")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x33562A8", Offset = "0x33562A8", Length = "0x94")]
	[Token(Token = "0x600069B")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x3357194", Offset = "0x3357194", Length = "0xC4")]
	[Token(Token = "0x60006A1")]
	private void OnDestroy() { }

	[Address(RVA = "0x33563C8", Offset = "0x33563C8", Length = "0x5C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x600069E")]
	private static void ResetStatics() { }

	[Address(RVA = "0x3356424", Offset = "0x3356424", Length = "0x1E8")]
	[Token(Token = "0x600069F")]
	public static void Show() { }

}

