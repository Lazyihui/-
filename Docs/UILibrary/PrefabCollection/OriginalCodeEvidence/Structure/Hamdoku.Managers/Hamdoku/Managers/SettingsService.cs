namespace Hamdoku.Managers;

[Token(Token = "0x2000278")]
public static class SettingsService
{
	[Token(Token = "0x400107B")]
	private static SettingsPopup _popup; //Field offset: 0x0

	[Address(RVA = "0x32CA6B8", Offset = "0x32CA6B8", Length = "0x16C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	[Token(Token = "0x60011FB")]
	private static void Bootstrap() { }

	[Address(RVA = "0x32CA824", Offset = "0x32CA824", Length = "0x230")]
	[Token(Token = "0x60011FE")]
	private static void EnsureEventSystem() { }

	[Address(RVA = "0x32CAAB0", Offset = "0x32CAAB0", Length = "0x5C")]
	[Token(Token = "0x60011FD")]
	public static void Hide() { }

	[Address(RVA = "0x32CAA54", Offset = "0x32CAA54", Length = "0x5C")]
	[Token(Token = "0x60011FC")]
	public static void Toggle() { }

}

