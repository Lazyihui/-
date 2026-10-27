namespace Hamdoku.UI;

[Token(Token = "0x20000AD")]
public static class RegionColorAssigner
{
	[CompilerGenerated]
	[Token(Token = "0x20000AE")]
	private sealed class <>c__DisplayClass8_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000AC0")]
		public float[] totalW; //Field offset: 0x10

		[Address(RVA = "0x3425C98", Offset = "0x3425C98", Length = "0x8")]
		[Token(Token = "0x60004A8")]
		public <>c__DisplayClass8_0() { }

		[Address(RVA = "0x3425DEC", Offset = "0x3425DEC", Length = "0x68")]
		[Token(Token = "0x60004A9")]
		internal int <GreedyAssign>b__0(int a, int b) { }

	}

	[Token(Token = "0x4000ABE")]
	private const float DiagonalContactWeight = 0.35; //Field offset: 0x0
	[Token(Token = "0x4000ABF")]
	private const int MaxImprovePasses = 64; //Field offset: 0x0

	[Address(RVA = "0x3425A2C", Offset = "0x3425A2C", Length = "0x94")]
	[Token(Token = "0x60004A1")]
	private static void AddContact(float[,] w, int a, int b, float amount) { }

	[Address(RVA = "0x3424DF4", Offset = "0x3424DF4", Length = "0xB4")]
	[Token(Token = "0x600049F")]
	public static int[] Assign(Board board, Color[] palette) { }

	[Address(RVA = "0x3424EA8", Offset = "0x3424EA8", Length = "0x1E0")]
	[Token(Token = "0x60004A0")]
	private static float[,] BuildAdjacencyWeights(Board board, out int layoutHash) { }

	[Address(RVA = "0x3425088", Offset = "0x3425088", Length = "0x250")]
	[Token(Token = "0x60004A2")]
	private static float[,] BuildPaletteDistances(Color[] palette) { }

	[Address(RVA = "0x3425C68", Offset = "0x3425C68", Length = "0x30")]
	[Token(Token = "0x60004A4")]
	private static float Cbrt(float v) { }

	[Address(RVA = "0x3425CA0", Offset = "0x3425CA0", Length = "0x14C")]
	[Token(Token = "0x60004A7")]
	private static void Evaluate(int[] map, float[,] weight, float[,] dist, out float minAdjacent, out float weightedSum) { }

	[Address(RVA = "0x34252D8", Offset = "0x34252D8", Length = "0x430")]
	[Token(Token = "0x60004A5")]
	private static int[] GreedyAssign(int n, int m, float[,] weight, float[,] dist, int layoutHash) { }

	[Address(RVA = "0x3425708", Offset = "0x3425708", Length = "0x324")]
	[Token(Token = "0x60004A6")]
	private static void ImproveByLocalSearch(int[] map, int m, float[,] weight, float[,] dist) { }

	[Address(RVA = "0x3425AC0", Offset = "0x3425AC0", Length = "0x1A8")]
	[Token(Token = "0x60004A3")]
	private static Vector3 ToOklab(Color c) { }

}

