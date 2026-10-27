namespace Hamdoku.Managers;

[Token(Token = "0x20000EC")]
public static class CheatService
{
	[Token(Token = "0x4000500")]
	private static CheatPanel _panel; //Field offset: 0x0
	[Token(Token = "0x4000501")]
	private const string HideKey = "Hamdoku.Cheat.Hidden"; //Field offset: 0x0

	[Token(Token = "0x17000085")]
	public static bool Hidden
	{
		[Address(RVA = "0x334374C", Offset = "0x334374C", Length = "0x54")]
		[Token(Token = "0x6000588")]
		 get { } //Length: 84
		[Address(RVA = "0x33437A0", Offset = "0x33437A0", Length = "0x58")]
		[Token(Token = "0x6000589")]
		 set { } //Length: 88
	}

	[Address(RVA = "0x33437F8", Offset = "0x33437F8", Length = "0x6C")]
	[Token(Token = "0x600058A")]
	private static void Apply() { }

	[Address(RVA = "0x3343864", Offset = "0x3343864", Length = "0x1C4")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	[Token(Token = "0x600058B")]
	private static void Bootstrap() { }

	[Address(RVA = "0x3343A28", Offset = "0x3343A28", Length = "0x1EC")]
	[Token(Token = "0x600058D")]
	private static void EnsureEventSystem() { }

	[Address(RVA = "0x334374C", Offset = "0x334374C", Length = "0x54")]
	[Token(Token = "0x6000588")]
	public static bool get_Hidden() { }

	[Address(RVA = "0x33437A0", Offset = "0x33437A0", Length = "0x58")]
	[Token(Token = "0x6000589")]
	public static void set_Hidden(bool value) { }

	[Address(RVA = "0x3343C14", Offset = "0x3343C14", Length = "0x5C")]
	[Token(Token = "0x600058C")]
	public static void Toggle() { }

}

