namespace Hamdoku.UI;

[Token(Token = "0x200007A")]
public static class LabelGlow
{
	[Token(Token = "0x4000692")]
	public const float DefaultWidth = 0.18; //Field offset: 0x0
	[Token(Token = "0x4000693")]
	public const float DefaultSoftness = 0.45; //Field offset: 0x0
	[Token(Token = "0x4000694")]
	public const float DefaultDilate = 0.22; //Field offset: 0x0
	[Token(Token = "0x4000695")]
	public const float MinFaceLuminance = 0.5; //Field offset: 0x0

	[Address(RVA = "0x340D058", Offset = "0x340D058", Length = "0x110")]
	[Token(Token = "0x600037B")]
	private static void AppendRun(StringBuilder sb, string run, Color color) { }

	[Address(RVA = "0x340D220", Offset = "0x340D220", Length = "0x398")]
	[Token(Token = "0x600037D")]
	public static TMP_Text Attach(TMP_Text src, Color color, float width = 0.18, float softness = 0.45, float dilate = 0.22, bool forceGlow = false) { }

	[Address(RVA = "0x340CD98", Offset = "0x340CD98", Length = "0x2C0")]
	[Token(Token = "0x600037A")]
	internal static string BuildVisibleGlowText(string src, Color baseColor) { }

	[Address(RVA = "0x340CD68", Offset = "0x340CD68", Length = "0x30")]
	[Token(Token = "0x6000379")]
	internal static float Luminance(Color c) { }

	[Address(RVA = "0x340D168", Offset = "0x340D168", Length = "0xB8")]
	[Token(Token = "0x600037C")]
	private static Color ParseColor(string tag, Color fallback) { }

}

