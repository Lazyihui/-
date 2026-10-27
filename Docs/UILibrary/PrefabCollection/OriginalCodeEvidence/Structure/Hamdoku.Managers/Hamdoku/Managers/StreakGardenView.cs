namespace Hamdoku.Managers;

[Token(Token = "0x20002B2")]
public static class StreakGardenView
{
	[Token(Token = "0x20002B3")]
	private sealed class FlapRunner : MonoBehaviour
	{
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40012C0")]
		public Image image; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40012C1")]
		public Sprite open; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40012C2")]
		public Sprite closed; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40012C3")]
		public float interval; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x40012C4")]
		private float _t; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40012C5")]
		private bool _open; //Field offset: 0x40

		[Address(RVA = "0x32F006C", Offset = "0x32F006C", Length = "0x1C")]
		[Token(Token = "0x600138C")]
		public FlapRunner() { }

		[Address(RVA = "0x32EFF84", Offset = "0x32EFF84", Length = "0xE8")]
		[Token(Token = "0x600138B")]
		private void Update() { }

	}

	[Token(Token = "0x40012BA")]
	private const float PlantBottomNy = -0.486; //Field offset: 0x0
	[Token(Token = "0x40012BB")]
	private const float SproutBottomNy = -0.48; //Field offset: 0x0
	[Token(Token = "0x40012BC")]
	private const float HeadNx = 0; //Field offset: 0x0
	[Token(Token = "0x40012BD")]
	private const float HeadNy = 0.034; //Field offset: 0x0
	[Token(Token = "0x40012BE")]
	private const float HeadRadius = 0.123; //Field offset: 0x0
	[Token(Token = "0x40012BF")]
	private const float FlapSeconds = 0.13; //Field offset: 0x0

	[Token(Token = "0x170002B1")]
	private static StreakPageConfig Cfg
	{
		[Address(RVA = "0x32EDDD0", Offset = "0x32EDDD0", Length = "0x8")]
		[Token(Token = "0x6001384")]
		 get { } //Length: 8
	}

	[Address(RVA = "0x32EDDD8", Offset = "0x32EDDD8", Length = "0xCCC")]
	[Token(Token = "0x6001385")]
	public static RectTransform Build(RectTransform parent, int streak, bool empty, float box, float groundY) { }

	[Address(RVA = "0x32EF15C", Offset = "0x32EF15C", Length = "0x7C8")]
	[Token(Token = "0x6001386")]
	private static void BuildPetals(RectTransform root, float box, int streak, StreakPageConfig c) { }

	[Address(RVA = "0x32EF924", Offset = "0x32EF924", Length = "0x660")]
	[Token(Token = "0x600138A")]
	private static void Butterfly(RectTransform root, float box, int index, float sizeFrac) { }

	[Address(RVA = "0x32EEBF8", Offset = "0x32EEBF8", Length = "0x418")]
	[Token(Token = "0x6001389")]
	private static void Companion(RectTransform root, string name, Sprite sprite, float box, float nx, float nscale, float bottomNy, bool flip, float lift, float groundOffset) { }

	[Address(RVA = "0x32EF010", Offset = "0x32EF010", Length = "0x14C")]
	[Token(Token = "0x6001387")]
	private static Sprite CutSprite(int cut) { }

	[Address(RVA = "0x32EDDD0", Offset = "0x32EDDD0", Length = "0x8")]
	[Token(Token = "0x6001384")]
	private static StreakPageConfig get_Cfg() { }

	[Address(RVA = "0x32EEAA4", Offset = "0x32EEAA4", Length = "0x154")]
	[Token(Token = "0x6001388")]
	private static Image MakePlant(string name, RectTransform root, Sprite sprite) { }

}

