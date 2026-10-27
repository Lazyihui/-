namespace Hamdoku.Managers;

[Token(Token = "0x20002A9")]
public static class ShopService
{
	[Token(Token = "0x400128D")]
	private static ShopPopup _popup; //Field offset: 0x0

	[Token(Token = "0x170002AC")]
	public static bool IsOpen
	{
		[Address(RVA = "0x32EBB50", Offset = "0x32EBB50", Length = "0xA8")]
		[Token(Token = "0x600135F")]
		 get { } //Length: 168
	}

	[Address(RVA = "0x32EB758", Offset = "0x32EB758", Length = "0x16C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	[Token(Token = "0x600135D")]
	private static void Bootstrap() { }

	[Address(RVA = "0x32EB8C4", Offset = "0x32EB8C4", Length = "0x230")]
	[Token(Token = "0x6001361")]
	private static void EnsureEventSystem() { }

	[Address(RVA = "0x32EBB50", Offset = "0x32EBB50", Length = "0xA8")]
	[Token(Token = "0x600135F")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x32EBBF8", Offset = "0x32EBBF8", Length = "0xC0")]
	[Token(Token = "0x6001360")]
	public static void Hide() { }

	[Address(RVA = "0x32EBAF4", Offset = "0x32EBAF4", Length = "0x5C")]
	[Token(Token = "0x600135E")]
	public static void Show() { }

}

