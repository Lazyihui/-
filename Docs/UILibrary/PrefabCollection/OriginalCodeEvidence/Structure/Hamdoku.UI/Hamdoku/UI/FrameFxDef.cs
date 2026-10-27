namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "frame_0", menuName = "Hamdoku/Frame FX")]
[Token(Token = "0x200004B")]
public sealed class FrameFxDef : ScriptableObject
{
	[Token(Token = "0x200004C")]
	public enum Anim : int
	{
		Static = 0,
		Spin = 1,
		Pulse = 2,
		Bob = 3,
		Blink = 4,
		Peek = 5,
		Pass = 6,
		Firework = 7,
		Shimmer = 8,
		Sweep = 9,
	}

	[Token(Token = "0x200004D")]
	public sealed class Layer
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004AF")]
		public string name; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40004B0")]
		public Anim anim; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40004B1")]
		[Tooltip("Resources 경로(확장자 없이). 비면 Blink·Firework는 코드 반짝임, Peek·Pass는 skinId의 햄스터 등장 컷, 그 외는 건너뜀")]
		public string spritePath; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40004B2")]
		[Tooltip("보조 그림 Resources 경로 — Firework의 불꽃 가닥(꽃잎·씨앗). 비면 작은 원")]
		public string spritePath2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40004B3")]
		[Tooltip("0보다 크면 그 보드 햄스터 스킨(HamsterSkin)의 등장 컷을 그림으로 쓴다(Peek·Pass용)")]
		public int skinId; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x40004B4")]
		[Tooltip("프레임 렉트 안 위치(0~1, y는 위가 1). Peek·Pass는 창 기준 x만 쓴다")]
		public Vector2 anchor; //Field offset: 0x34
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x40004B5")]
		[Tooltip("크기 — 프레임 렉트 한 변 대비 비율(Peek·Pass는 창 한 변 대비)")]
		public float size; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40004B6")]
		[Tooltip("사진(판·아바타)과 프레임 전부의 뒤에 그릴지 — 뒷광용. Peek·Pass는 항상 판 위·프레임 뒤(창 안)")]
		public bool behindFrame; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x40004B7")]
		public Color tint; //Field offset: 0x44
		[FieldOffset(Offset = "0x54")]
		[Token(Token = "0x40004B8")]
		[Tooltip("반복 간격(초). Blink·Peek·Pass·Firework")]
		public float interval; //Field offset: 0x54
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x40004B9")]
		[Tooltip("동작 길이(초) — Anim 설명 참조")]
		public float duration; //Field offset: 0x58
		[FieldOffset(Offset = "0x5C")]
		[Token(Token = "0x40004BA")]
		[Tooltip("Anim별 보조값 — Spin 바퀴/초, Pulse 배율 폭, Bob 진폭, Pass 튀는 높이, Firework 가닥 수")]
		public float amount; //Field offset: 0x5C
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x40004BB")]
		[Tooltip("시작 지연(초) — 같은 종류 레이어가 동시에 터지지 않게")]
		public float delay; //Field offset: 0x60
		[FieldOffset(Offset = "0x64")]
		[Token(Token = "0x40004BC")]
		[Tooltip("Sweep: 한 바퀴 돈 뒤 쉬는 시간(초). 0 = 쉬지 않고 계속. 쉬는 동안 빛은 사라졌다가 다음 바퀴 시작에 다시 나타난다")]
		public float hold; //Field offset: 0x64
		[FieldOffset(Offset = "0x68")]
		[Range(0, 1)]
		[Token(Token = "0x40004BD")]
		[Tooltip("Sweep: 빛이 출발하는 자리(바퀴 비율, 0 = 오른쪽 가운데, 0.25 = 위, 0.375 = 왼쪽 위, 0.5 = 왼쪽)")]
		public float startTurn; //Field offset: 0x68

		[Address(RVA = "0x33F7980", Offset = "0x33F7980", Length = "0xC4")]
		[Token(Token = "0x6000218")]
		public Layer() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x40004A1")]
	private static Action<FrameFxDef> Edited; //Field offset: 0x0
	[Token(Token = "0x40004A2")]
	private static readonly Dictionary<int, FrameFxDef> _cache; //Field offset: 0x8
	[Token(Token = "0x40004A3")]
	private static readonly HashSet<int> _missing; //Field offset: 0x10
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000493")]
	[Tooltip("연출 전체 켜기(비상 차단)")]
	public bool enabled; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000494")]
	public Layer[] layers; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Header("지오메트리(프레임 렉트 대비)")]
	[Range(0.3, 1)]
	[Token(Token = "0x4000495")]
	[Tooltip("투명 창(개구부) 한 변 — Peek·Pass 마스크")]
	public float window; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(0.2, 0.6)]
	[Token(Token = "0x4000496")]
	[Tooltip("띠 중심선 반지름 — Firework가 터지는 자리")]
	public float ring; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Header("Shimmer(금빛 띠) — 레이어에 Shimmer가 있을 때")]
	[Range(0, 1)]
	[Token(Token = "0x4000497")]
	public float shimmerAlpha; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000498")]
	[Tooltip("바퀴/초")]
	public float shimmerSpeed; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Range(0, 1)]
	[Token(Token = "0x4000499")]
	public float shimmerHue; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Range(0, 1)]
	[Token(Token = "0x400049A")]
	public float shimmerHueRange; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Range(0, 1)]
	[Token(Token = "0x400049B")]
	public float shimmerSaturation; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Range(0, 2)]
	[Token(Token = "0x400049C")]
	public float shimmerValue; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[Token(Token = "0x400049D")]
	public float shimmerSweep; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(0.05, 1)]
	[Token(Token = "0x400049E")]
	public float shimmerSweepWidth; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400049F")]
	public int shimmerSweepCount; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Range(0.3, 4)]
	[Token(Token = "0x40004A0")]
	public float shimmerSpread; //Field offset: 0x54

	[Token(Token = "0x14000008")]
	public static event Action<FrameFxDef> Edited
	{
		[Address(RVA = "0x33F1638", Offset = "0x33F1638", Length = "0xF0")]
		[CompilerGenerated]
		[Token(Token = "0x6000212")]
		 add { } //Length: 240
		[Address(RVA = "0x33F17C8", Offset = "0x33F17C8", Length = "0xF0")]
		[CompilerGenerated]
		[Token(Token = "0x6000213")]
		 remove { } //Length: 240
	}

	[Address(RVA = "0x33F7898", Offset = "0x33F7898", Length = "0xE8")]
	[Token(Token = "0x6000217")]
	private static FrameFxDef() { }

	[Address(RVA = "0x33F77D4", Offset = "0x33F77D4", Length = "0xC4")]
	[Token(Token = "0x6000216")]
	public FrameFxDef() { }

	[Address(RVA = "0x33F1638", Offset = "0x33F1638", Length = "0xF0")]
	[CompilerGenerated]
	[Token(Token = "0x6000212")]
	public static void add_Edited(Action<FrameFxDef> value) { }

	[Address(RVA = "0x33F1BFC", Offset = "0x33F1BFC", Length = "0x204")]
	[Token(Token = "0x6000214")]
	public static FrameFxDef For(int frameId) { }

	[Address(RVA = "0x33F17C8", Offset = "0x33F17C8", Length = "0xF0")]
	[CompilerGenerated]
	[Token(Token = "0x6000213")]
	public static void remove_Edited(Action<FrameFxDef> value) { }

	[Address(RVA = "0x33F7714", Offset = "0x33F7714", Length = "0xC0")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000215")]
	private static void ResetStatics() { }

}

