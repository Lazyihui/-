namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "LogoIntroConfig", menuName = "Hamdoku/Logo Intro Config")]
[Token(Token = "0x2000092")]
public sealed class LogoIntroConfig : ScriptableObject
{
	[Token(Token = "0x2000093")]
	public struct Piece
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40007B6")]
		public Sprite sprite; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40007B7")]
		[Tooltip("스프라이트 크기(px, 기준 캔버스)")]
		public Vector2 size; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007B8")]
		[Tooltip("기준 캔버스 중심 기준 오프셋(px, y 위가 +)")]
		public Vector2 center; //Field offset: 0x10

	}

	[Token(Token = "0x40007B4")]
	private static LogoIntroConfig _instance; //Field offset: 0x0
	[Token(Token = "0x40007B5")]
	private static bool _searched; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Header("재생")]
	[Token(Token = "0x400077C")]
	[Tooltip("끄면 인트로 없이 기존 로고 팝만 재생")]
	public bool playIntro; //Field offset: 0x18
	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x400077D")]
	[Tooltip("켜면 앱 세션당 1회만(로비 첫 진입). 꺼두면 로비 진입마다(첫 로딩 후 + 인게임→로비 복귀) 재생")]
	public bool oncePerSession; //Field offset: 0x19
	[FieldOffset(Offset = "0x1C")]
	[Range(0, 1)]
	[Token(Token = "0x400077E")]
	[Tooltip("씬이 뜬 뒤 시작까지 대기(초). 크림 페이드가 걷히는 초반에 묻히지 않게")]
	public float startDelay; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Header("기준 BI")]
	[Token(Token = "0x400077F")]
	[Tooltip("로고 Image가 이 스프라이트일 때만 인트로 재생(하드모드 로고 등 다른 스프라이트면 생략)")]
	public Sprite baseLogo; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Header("레이어 (기준 캔버스 px)")]
	[Token(Token = "0x4000780")]
	public Vector2 canvasSize; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000781")]
	public Piece hamsterMask; //Field offset: 0x30
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000782")]
	public Piece hamsterBody; //Field offset: 0x48
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000783")]
	public Piece eyesOpen; //Field offset: 0x60
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000784")]
	public Piece eyesBlink; //Field offset: 0x78
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000785")]
	public Piece boardBack; //Field offset: 0x90
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000786")]
	public Piece bellyOverlay; //Field offset: 0xA8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000787")]
	public Piece boardFront; //Field offset: 0xC0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000788")]
	public Piece xMark; //Field offset: 0xD8
	[FieldOffset(Offset = "0xF0")]
	[Header("햄스터 이동 (px, 기준 캔버스)")]
	[Token(Token = "0x4000789")]
	[Tooltip("완전히 숨는 시작 위치(아래로). 마스크 상단선 아래로 머리가 다 들어가는 값 이상")]
	public float hideOffset; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x400078A")]
	[Tooltip("2단계에서 귀가 보이는 높이")]
	public float earPeek; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Range(0, 0.5)]
	[Token(Token = "0x400078B")]
	[Tooltip("귀 빼꼼 뒤 잠깐 멈추는 시간(초). 망설이는 느낌")]
	public float earPeekHoldSeconds; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Range(0, 60)]
	[Token(Token = "0x400078C")]
	[Tooltip("튀어오르기 직전 살짝 웅크리는 깊이(px). 0이면 없음")]
	public float earDip; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(0, 0.3)]
	[Token(Token = "0x400078D")]
	[Tooltip("웅크리는 시간(초)")]
	public float earDipSeconds; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x400078E")]
	[Tooltip("3단계 오버슈트 높이(위로, px)")]
	public float overshoot; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Range(0, 0.3)]
	[Token(Token = "0x400078F")]
	[Tooltip("튀어오를 때 세로로 늘어나는 비율(0.10 = 10%). 스프링 느낌. 가로는 늘리지 않는다(이음선)")]
	public float riseStretch; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Header("타임라인 (초)")]
	[Token(Token = "0x4000790")]
	[Tooltip("1단계 로고판 팝")]
	public float boardPopSeconds; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Range(0.8, 1)]
	[Token(Token = "0x4000791")]
	public float boardPopFrom; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Range(1, 1.1)]
	[Token(Token = "0x4000792")]
	public float boardPopTo; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4000793")]
	[Tooltip("2단계 귀 빼꼼")]
	public float earPeekSeconds; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4000794")]
	[Tooltip("3단계 상승(오버슈트까지)")]
	public float riseSeconds; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000795")]
	[Tooltip("4단계 착지")]
	public float landSeconds; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Range(0.02, 0.3)]
	[Token(Token = "0x4000796")]
	[Tooltip("착지 충격으로 눌리는 시간(초). 짧을수록 '쿵'")]
	public float impactSeconds; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Range(0, 0.2)]
	[Token(Token = "0x4000797")]
	[Tooltip("착지 시 로고 전체(햄스터+판) 세로 압축 비율(판 바닥 기준, 0.08 = 8%). 햄스터와 판은 한 덩어리로만 변형된다(따로 변형하면 이음선이 드러남)")]
	public float landSquash; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Range(0, 1)]
	[Token(Token = "0x4000798")]
	[Tooltip("압축될 때 가로로 늘어나는 비율(세로 압축량 대비). 0이면 세로만 눌림")]
	public float squashStretchRatio; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Range(0, 0.3)]
	[Token(Token = "0x4000799")]
	[Tooltip("착지 시 배 부분(판에 걸치는 몸통) 페이드인 시간. 0 = 착지 순간 즉시(권장). 0보다 크면 페이드 중 햄스터와 덮개 경계가 가로선으로 보인다")]
	public float bellyFadeSeconds; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x400079A")]
	[Tooltip("5단계 말랑 바운스 — 눌린 상태에서 탄성 복원되는 시간(OutElastic). 길수록 잔진동이 오래 남는다")]
	public float bounceSeconds; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(1, 3)]
	[Token(Token = "0x400079B")]
	[Tooltip("바운스 진폭. 1이 가장 크게 튐(DOTween Elastic 규칙), 커질수록 오히려 작아진다")]
	public float bounceAmplitude; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Range(0.05, 1)]
	[Token(Token = "0x400079C")]
	[Tooltip("바운스 주기(초). 작을수록 띠용 횟수가 많아진다. 0.26 ≈ 0.6초 동안 2회 남짓(느릿한 젤리)")]
	public float bouncePeriod; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Range(0, 0.3)]
	[Token(Token = "0x400079D")]
	[Tooltip("머리 출렁임(젤리) 세기 — 착지 뒤 햄스터만 세로로 추가 압축되는 비율(판 상단선 피벗). 0이면 끔")]
	public float hamsterWobble; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Range(0, 0.3)]
	[Token(Token = "0x400079E")]
	[Tooltip("머리 출렁임이 전체 찌그러짐보다 늦게 시작하는 시간(초). 지연이 있어야 '따라 흔들리는' 느낌")]
	public float hamsterWobbleLag; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Range(0.1, 1.5)]
	[Token(Token = "0x400079F")]
	[Tooltip("머리 출렁임 복원 시간(초)")]
	public float hamsterWobbleSeconds; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Range(0.05, 1)]
	[Token(Token = "0x40007A0")]
	[Tooltip("머리 출렁임 주기(초). 전체 바운스보다 조금 느리게")]
	public float hamsterWobblePeriod; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40007A1")]
	[Tooltip("켜면 X가 '박히는' 순간을 착지 충격(쿵)에 맞춘다. X는 내려오는 동안 미리 커져 멈춰 있다가 쿵 직후 박힘. 눈 찡긋은 쿵에")]
	public bool xPunchAtImpact; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Range(0, 0.3)]
	[Token(Token = "0x40007A2")]
	[Tooltip("쿵(최대 찌그러짐) 뒤 X가 박히기까지(초). 0이면 완전히 동시. 살짝 늦춰야 쿵이 먼저 읽힌다")]
	public float xStampDelay; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Range(0, 1)]
	[Token(Token = "0x40007A3")]
	[Tooltip("(xPunchAtImpact 꺼졌을 때) 착지 뒤 X 톡을 시작하기까지(초)")]
	public float xPunchDelayAfterLand; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40007A4")]
	[Tooltip("6단계 X가 큰 크기로 나타나 1배까지 떨어지는(박히는) 시간(초). 짧을수록 도장처럼 쾅")]
	public float xPunchSeconds; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Range(1, 3)]
	[Token(Token = "0x40007A5")]
	[Tooltip("X가 나타나는 시작 크기(배). 이 크기에서 떨어져 1배에 박힌다")]
	public float xPunchScale; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Range(0, 0.4)]
	[Token(Token = "0x40007A6")]
	[Tooltip("박히는 순간 X가 눌리는 비율(0.12 = 12%)")]
	public float xLandSquash; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Range(0.05, 1)]
	[Token(Token = "0x40007A7")]
	[Tooltip("박힌 뒤 X가 탄성으로 되돌아오는 시간(초). 효과음 길이와 맞춘다. mark.wav는 트리거 후 210ms에 잦아들고, 눌림(0.034)+이 값 = 0.204초가 되는 0.17이 맞음")]
	public float xLandBounceSeconds; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Range(0, 0.3)]
	[Token(Token = "0x40007A8")]
	[Tooltip("음원 피크 보정(초) — 파일 시작이 무음일 때만 쓴다. mark.wav는 0ms부터 소리가 나므로(피크 대비 26%) 0. 피크(75ms)에 맞추면 들리는 시작이 그만큼 빨라져 어색하다")]
	public float xSfxLeadSeconds; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Range(0, 0.3)]
	[Token(Token = "0x40007A9")]
	[Tooltip("연출 지연(초) — 박히는 순간보다 소리를 이만큼 늦춘다. 취향 조절용")]
	public float xSfxDelaySeconds; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x40007AA")]
	[Tooltip("X 톡 때 눈웃음으로 표정 변화. 꺼두면 표정 하나(눈 뜬 상태)로 진행 — 2026-08-29 결정: 끔")]
	public bool useBlink; //Field offset: 0x174
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40007AB")]
	[Tooltip("6단계 눈웃음 유지(초)")]
	public float blinkSeconds; //Field offset: 0x178
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x40007AC")]
	[Tooltip("7단계 정지까지 여유")]
	public float settleSeconds; //Field offset: 0x17C
	[FieldOffset(Offset = "0x180")]
	[Header("효과음 (MainMenu가 큐를 받아 재생)")]
	[Token(Token = "0x40007AD")]
	[Tooltip("햄스터가 튀어오를 때 Sfx.Pop(Resources/Audio/pop.wav, 58ms 팝)")]
	public bool sfxRise; //Field offset: 0x180
	[FieldOffset(Offset = "0x184")]
	[Range(0, 1)]
	[Token(Token = "0x40007AE")]
	public float sfxRiseVolume; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Range(0, 0.2)]
	[Token(Token = "0x40007AF")]
	[Tooltip("음원 피크 보정(초) — 파일 시작부터 첫 피크까지의 거리. pop.wav는 7ms. 음원을 바꾸면 다시 측정")]
	public float riseSfxLeadSeconds; //Field offset: 0x188
	[FieldOffset(Offset = "0x18C")]
	[Range(0, 0.3)]
	[Token(Token = "0x40007B0")]
	[Tooltip("연출 지연(초) — 도약 시작보다 소리를 이만큼 늦춘다. 도약 시작 순간은 방향이 바뀌는 지점이라 화면상 아직 멈춘 듯 보여, 정확히 맞추면 소리가 먼저 난 것처럼 들린다. 0.05 ≈ 3프레임")]
	public float riseSfxDelaySeconds; //Field offset: 0x18C
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40007B1")]
	[Tooltip("착지 때 Sfx.Stamp. 기본 꺼짐 — X 박히는 소리만 남기기로 함(2026-08-29)")]
	public bool sfxLand; //Field offset: 0x190
	[FieldOffset(Offset = "0x191")]
	[Token(Token = "0x40007B2")]
	[Tooltip("X가 제자리에 박힐 때 Sfx.Mark(인게임 X 배치음)")]
	public bool sfxXPunch; //Field offset: 0x191
	[FieldOffset(Offset = "0x194")]
	[Range(0, 1)]
	[Token(Token = "0x40007B3")]
	[Tooltip("X 박힘 효과음 볼륨. 인게임 X 배치음(0.5)보다 조금 크게 두어 등장 연출을 살린다")]
	public float sfxXPunchVolume; //Field offset: 0x194

	[Token(Token = "0x170000A3")]
	public static LogoIntroConfig Instance
	{
		[Address(RVA = "0x34152A8", Offset = "0x34152A8", Length = "0x168")]
		[Token(Token = "0x6000403")]
		 get { } //Length: 360
	}

	[Token(Token = "0x170000A2")]
	public float TotalSeconds
	{
		[Address(RVA = "0x3417714", Offset = "0x3417714", Length = "0x150")]
		[Token(Token = "0x6000402")]
		 get { } //Length: 336
	}

	[Address(RVA = "0x3417910", Offset = "0x3417910", Length = "0xD4")]
	[Token(Token = "0x6000405")]
	public LogoIntroConfig() { }

	[Address(RVA = "0x34152A8", Offset = "0x34152A8", Length = "0x168")]
	[Token(Token = "0x6000403")]
	public static LogoIntroConfig get_Instance() { }

	[Address(RVA = "0x3417714", Offset = "0x3417714", Length = "0x150")]
	[Token(Token = "0x6000402")]
	public float get_TotalSeconds() { }

	[Address(RVA = "0x34178AC", Offset = "0x34178AC", Length = "0x64")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000404")]
	private static void ResetStatics() { }

}

