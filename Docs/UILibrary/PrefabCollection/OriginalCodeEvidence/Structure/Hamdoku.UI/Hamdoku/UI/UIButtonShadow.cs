namespace Hamdoku.UI;

[Token(Token = "0x20000D9")]
public static class UIButtonShadow
{
	[Token(Token = "0x4000D6D")]
	private static readonly Vector2 DefaultOffset; //Field offset: 0x0

	[Address(RVA = "0x343B800", Offset = "0x343B800", Length = "0x50")]
	[Token(Token = "0x60005BD")]
	private static UIButtonShadow() { }

	[Address(RVA = "0x343B2F0", Offset = "0x343B2F0", Length = "0x510")]
	[Token(Token = "0x60005BC")]
	public static void Ensure(GameObject button, Vector2 offset) { }

	[Address(RVA = "0x343B290", Offset = "0x343B290", Length = "0x60")]
	[Token(Token = "0x60005BB")]
	public static void Ensure(GameObject button) { }

}

