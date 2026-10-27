namespace Hamdoku.Puzzle.Generator;

[Token(Token = "0x200001F")]
public static class DemoPuzzles
{
	[Token(Token = "0x40000A9")]
	private static readonly int[,] Region5x5; //Field offset: 0x0

	[Address(RVA = "0x33CD6E0", Offset = "0x33CD6E0", Length = "0xC0")]
	[Token(Token = "0x6000085")]
	private static DemoPuzzles() { }

	[Address(RVA = "0x33CD658", Offset = "0x33CD658", Length = "0x88")]
	[Token(Token = "0x6000084")]
	public static Board Create5x5() { }

}

