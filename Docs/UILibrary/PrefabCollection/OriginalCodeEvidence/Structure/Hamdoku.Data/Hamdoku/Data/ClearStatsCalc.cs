namespace Hamdoku.Data;

[Token(Token = "0x200000B")]
public static class ClearStatsCalc
{
	[Token(Token = "0x400002E")]
	public static IScorePercentileSource MeasuredSource; //Field offset: 0x0

	[Address(RVA = "0x31E2C78", Offset = "0x31E2C78", Length = "0x538")]
	[Token(Token = "0x6000015")]
	public static ClearStats Build(int score, int boardSize, bool hard, int levelNumber, int faults, int seedsLeft, int bestCombo, float timeSec, bool daily = false, bool assisted = false) { }

	[Address(RVA = "0x31E31B0", Offset = "0x31E31B0", Length = "0x20")]
	[Token(Token = "0x6000019")]
	private static float Clamp(float v, float lo, float hi) { }

	[Address(RVA = "0x31E3494", Offset = "0x31E3494", Length = "0x118")]
	[Token(Token = "0x6000017")]
	private static float CurvePercentile(float ratio) { }

	[Address(RVA = "0x31E3740", Offset = "0x31E3740", Length = "0x194")]
	[Token(Token = "0x600001A")]
	public static string FormatTime(float sec) { }

	[Address(RVA = "0x31E3430", Offset = "0x31E3430", Length = "0x64")]
	[Token(Token = "0x6000018")]
	private static float Jitter(int levelNumber, int score) { }

	[Address(RVA = "0x31E28B4", Offset = "0x31E28B4", Length = "0x2E8")]
	[Token(Token = "0x6000014")]
	public static int MaxScore(int boardSize, bool hard) { }

	[Address(RVA = "0x31E31D0", Offset = "0x31E31D0", Length = "0x260")]
	[Token(Token = "0x6000016")]
	private static float ModelPercentile(int score, int maxScore, int boardSize, bool hard, bool daily, float timeSec, out bool timeApplied) { }

}

