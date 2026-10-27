namespace Hamdoku.UI;

[Token(Token = "0x2000024")]
internal static class ColorAssistSprites
{
	[Token(Token = "0x4000158")]
	public const int PatternCount = 12; //Field offset: 0x0
	[Token(Token = "0x4000159")]
	private const int Size = 96; //Field offset: 0x0
	[Token(Token = "0x400015A")]
	private static readonly Dictionary<int, Sprite> _patterns; //Field offset: 0x0

	[Address(RVA = "0x33E3950", Offset = "0x33E3950", Length = "0x98")]
	[Token(Token = "0x600015A")]
	private static ColorAssistSprites() { }

	[Address(RVA = "0x33E2BC0", Offset = "0x33E2BC0", Length = "0x234")]
	[Token(Token = "0x6000152")]
	private static Sprite BuildGlyph(int index) { }

	[Address(RVA = "0x33E3814", Offset = "0x33E3814", Length = "0xB0")]
	[Token(Token = "0x6000159")]
	private static float Capsule(float x, float y, float x1, float y1, float x2, float y2, float half) { }

	[Address(RVA = "0x33E3574", Offset = "0x33E3574", Length = "0xBC")]
	[Token(Token = "0x6000155")]
	private static float Circle(float x, float y, float cx, float cy, float r) { }

	[Address(RVA = "0x33E38C4", Offset = "0x33E38C4", Length = "0x1C")]
	[Token(Token = "0x6000154")]
	private static float Dist(float x, float y, float cx, float cy) { }

	[Address(RVA = "0x33E38E0", Offset = "0x33E38E0", Length = "0x70")]
	[Token(Token = "0x6000158")]
	private static float EdgeSd(float x, float y, float ax, float ay, float bx, float by, float cx, float cy) { }

	[Address(RVA = "0x33E3518", Offset = "0x33E3518", Length = "0x5C")]
	[Token(Token = "0x6000156")]
	private static float Ellipse(float x, float y, float cx, float cy, float rx, float ry) { }

	[Address(RVA = "0x33E2DF4", Offset = "0x33E2DF4", Length = "0x724")]
	[Token(Token = "0x6000153")]
	private static float Glyph(int index, float x, float y) { }

	[Address(RVA = "0x33E29CC", Offset = "0x33E29CC", Length = "0x1F4")]
	[Token(Token = "0x6000151")]
	public static Sprite Pattern(int index) { }

	[Address(RVA = "0x33E3630", Offset = "0x33E3630", Length = "0x1E4")]
	[Token(Token = "0x6000157")]
	private static float Tri(float x, float y, float ax, float ay, float bx, float by, float cx, float cy) { }

}

