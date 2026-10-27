namespace Hamdoku.Managers;

[Token(Token = "0x200020D")]
public sealed class RankRollSchedule
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000D33")]
	public readonly float[] PassTimes; //Field offset: 0x10

	[Token(Token = "0x17000211")]
	public float Duration
	{
		[Address(RVA = "0x3273CE4", Offset = "0x3273CE4", Length = "0x34")]
		[Token(Token = "0x6000EFE")]
		 get { } //Length: 52
	}

	[Token(Token = "0x17000212")]
	public EaseFunction Ease
	{
		[Address(RVA = "0x3273D18", Offset = "0x3273D18", Length = "0x7C")]
		[Token(Token = "0x6000F03")]
		 get { } //Length: 124
	}

	[Token(Token = "0x17000210")]
	public int Steps
	{
		[Address(RVA = "0x327B0E8", Offset = "0x327B0E8", Length = "0x18")]
		[Token(Token = "0x6000EFD")]
		 get { } //Length: 24
	}

	[Address(RVA = "0x327B100", Offset = "0x327B100", Length = "0x30")]
	[Token(Token = "0x6000EFF")]
	private RankRollSchedule(float[] passTimes) { }

	[Address(RVA = "0x327B244", Offset = "0x327B244", Length = "0x20")]
	[CompilerGenerated]
	[Token(Token = "0x6000F05")]
	private float <get_Ease>b__10_0(float time, float duration, float overshoot, float period) { }

	[Address(RVA = "0x3273AD8", Offset = "0x3273AD8", Length = "0x20C")]
	[Token(Token = "0x6000F00")]
	public static RankRollSchedule Build(int steps, float startGap, float endGap, int decelSteps, float minTotal, float maxTotal) { }

	[Address(RVA = "0x3273CE4", Offset = "0x3273CE4", Length = "0x34")]
	[Token(Token = "0x6000EFE")]
	public float get_Duration() { }

	[Address(RVA = "0x3273D18", Offset = "0x3273D18", Length = "0x7C")]
	[Token(Token = "0x6000F03")]
	public EaseFunction get_Ease() { }

	[Address(RVA = "0x327B0E8", Offset = "0x327B0E8", Length = "0x18")]
	[Token(Token = "0x6000EFD")]
	public int get_Steps() { }

	[Address(RVA = "0x327B130", Offset = "0x327B130", Length = "0x114")]
	[Token(Token = "0x6000F01")]
	public float Progress(float u) { }

	[Address(RVA = "0x3273ED4", Offset = "0x3273ED4", Length = "0x9C")]
	[Token(Token = "0x6000F04")]
	public bool ShouldTick(int step, int every, float minGap, ref float lastTick) { }

	[Address(RVA = "0x3273D94", Offset = "0x3273D94", Length = "0x140")]
	[Token(Token = "0x6000F02")]
	public float TimeAtProgress(float p) { }

}

