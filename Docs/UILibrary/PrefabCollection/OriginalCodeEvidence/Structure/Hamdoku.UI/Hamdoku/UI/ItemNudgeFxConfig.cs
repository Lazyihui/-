namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "ItemNudgeFxConfig", menuName = "Hamdoku/Item Nudge Fx Config")]
[Token(Token = "0x2000077")]
public sealed class ItemNudgeFxConfig : ScriptableObject
{
	[Token(Token = "0x4000675")]
	private static ItemNudgeFxConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("흔들림(버튼 기울기)")]
	[Range(0, 30)]
	[Token(Token = "0x4000650")]
	[Tooltip("첫 기울기 각도(도). 이후 왕복마다 wobbleDecay배로 줄어든다")]
	public float wobbleAngle; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(1, 6)]
	[Token(Token = "0x4000651")]
	[Tooltip("한 번 흔들 때 좌우 왕복 횟수")]
	public int wobbleSwings; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Range(0.2, 1)]
	[Token(Token = "0x4000652")]
	[Tooltip("왕복마다 각도 감쇠 배율(작을수록 빨리 잦아든다)")]
	public float wobbleDecay; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Range(0.2, 2)]
	[Token(Token = "0x4000653")]
	[Tooltip("한 번 흔드는 데 걸리는 시간(초)")]
	public float wobbleDuration; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Range(1, 1.4)]
	[Token(Token = "0x4000654")]
	[Tooltip("흔들 때 버튼이 커지는 배율(1=안 커짐). 앞부분에 빠르게 커져 커진 채로 흔들리고, 끝에 원래 크기로")]
	public float wobbleScale; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(1, 1.4)]
	[Token(Token = "0x4000655")]
	[Tooltip("햄스터 동반일 때 커지는 배율. 카드 위 햄스터와 어긋나지 않게 작게, 흔들림 중간에 한순간만 커진다")]
	public float wobbleScaleMascot; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Range(1, 4)]
	[Token(Token = "0x4000656")]
	[Tooltip("한 번의 유도에서 흔드는 횟수")]
	public int wobbleRepeats; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Range(0, 1.5)]
	[Token(Token = "0x4000657")]
	[Tooltip("흔들기 사이 쉬는 시간(초)")]
	public float wobbleGap; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Header("후광(버튼 뒤)")]
	[Token(Token = "0x4000658")]
	[Tooltip("후광 색(알파 = 최대 세기). 0이면 후광 없음")]
	public Color haloColor; //Field offset: 0x38
	[FieldOffset(Offset = "0x48")]
	[Range(0.5, 2)]
	[Token(Token = "0x4000659")]
	[Tooltip("후광 시작 지름(버튼 폭 배수)")]
	public float haloStartScale; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(1, 3)]
	[Token(Token = "0x400065A")]
	[Tooltip("후광 끝 지름(버튼 폭 배수)")]
	public float haloEndScale; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Range(0.3, 2)]
	[Token(Token = "0x400065B")]
	[Tooltip("후광 한 번이 퍼져 사라지는 시간(초). 흔들기마다 한 번씩 번진다")]
	public float haloDuration; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Header("반짝이(버튼 둘레)")]
	[Range(0, 16)]
	[Token(Token = "0x400065C")]
	[Tooltip("흔들기 한 번당 반짝이 수(0=없음)")]
	public int sparkleCount; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400065D")]
	[Tooltip("반짝이 크기 범위(px)")]
	public Vector2 sparkleSize; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400065E")]
	[Tooltip("반짝이가 놓이는 타원 반경(버튼 폭·높이 배수)")]
	public Vector2 sparkleSpread; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400065F")]
	public Color sparkleColor; //Field offset: 0x68
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000660")]
	[Tooltip("햄스터가 떠 있을 때 반짝이 거리(햄스터 반폭·반높이 배수, 최소~최대). 1보다 커야 얼굴 밖. 머리 위·양옆 반원에만 뿌린다")]
	public Vector2 sparkleMascotGap; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[Header("햄스터(카드 윗변에 팔을 걸치고 고민 → 아하). 크기·위치는 버튼 폭 배수")]
	[Range(0.4, 1.2)]
	[Token(Token = "0x4000661")]
	[Tooltip("햄스터 폭(버튼 폭 배수). 카드 폭보다 넓으면 올라오기 전 모습이 옆으로 비친다")]
	public float mascotWidth; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Range(-0.3, 0.3)]
	[Token(Token = "0x4000662")]
	[Tooltip("햄스터 가로 위치(버튼 폭 배수, -면 왼쪽). 오른쪽 위 개수 뱃지와 오른발이 겹치지 않게 기본은 살짝 왼쪽. 물음표·반짝이도 함께 옮겨진다")]
	public float mascotOffsetX; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000663")]
	[Tooltip("카드 윗변 위치(버튼 중심에서, 버튼 높이 배수). 카드 그림은 버튼 rect보다 작다(ItemHint/ItemGuide 실측 0.42)")]
	public float cardTop; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Range(-0.1, 0.2)]
	[Token(Token = "0x4000664")]
	[Tooltip("몸통 잘린 선을 카드 윗변보다 얼마나 아래에 둘지(햄스터 폭 배수, -면 위). 0=잘린 선이 카드 윗변과 일치, 팔만 카드에 걸친다")]
	public float mascotSink; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000665")]
	[Tooltip("나타나는 시간(초) — 바닥 기준으로 통 커지며 등장")]
	public float riseDuration; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000666")]
	[Tooltip("사라지는 시간(초)")]
	public float sinkDuration; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Range(0, 2)]
	[Token(Token = "0x4000667")]
	[Tooltip("숨겼던 수량·AD 뱃지를 햄스터가 사라지기 시작하기 몇 초 전부터 다시 보일지(0=사라지기 시작할 때)")]
	public float badgeReturnLead; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Range(0, 0.08)]
	[Token(Token = "0x4000668")]
	[Tooltip("숨쉬기 세기(세로 배율 변화). 바닥 기준으로 통통하게 늘었다 줄어든다")]
	public float breatheAmount; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Range(0.5, 4)]
	[Token(Token = "0x4000669")]
	[Tooltip("숨쉬기 한 번 시간(초)")]
	public float breathePeriod; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Range(0, 0.2)]
	[Token(Token = "0x400066A")]
	[Tooltip("\"?\"가 뜰 때 통 늘어나는 세기(세로 배율). 스프링으로 튕기며 돌아온다")]
	public float hopQuestion; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Range(0, 0.2)]
	[Token(Token = "0x400066B")]
	[Tooltip("\"아하\" 때 통 늘어나는 세기(세로 배율)")]
	public float hopAha; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Range(0, 15)]
	[Token(Token = "0x400066C")]
	[Tooltip("몸 기울임 각도(도). 몸 전체가 기울어 어색하다는 피드백으로 기본 0(2026-10-09)")]
	public float swayAngle; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Range(0, 0.1)]
	[Token(Token = "0x400066D")]
	[Tooltip("프레임이 바뀔 때 살짝 눌리는 정도(세로 배율 감소). 이음매를 가린다")]
	public float swapSquash; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Range(0, 2)]
	[Token(Token = "0x400066E")]
	[Tooltip("나타난 뒤 물음표가 뜨기까지(초). 이 동안과 이후 revealAt까지 고민 컷")]
	public float questionDelay; //Field offset: 0xB4
	[FieldOffset(Offset = "0xB8")]
	[Range(0.5, 6)]
	[Token(Token = "0x400066F")]
	[Tooltip("고민 컷이 아하 컷으로, 물음표가 아이템 아이콘으로 바뀌는 시각(시작부터, 초). 이때 버튼이 흔들리기 시작한다")]
	public float revealAt; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Range(0.3, 6)]
	[Token(Token = "0x4000670")]
	[Tooltip("'아하' 표정을 유지하는 시간(초). 끝나면 내려간다")]
	public float ahaHold; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000671")]
	[Tooltip("물음표 크기(버튼 폭 배수)")]
	public float questionSize; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000672")]
	[Tooltip("아이템 아이콘 크기(버튼 폭 배수)")]
	public float iconSize; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000673")]
	[Tooltip("물음표·아이콘 위치(버튼 중심 기준, 버튼 폭 배수). 기본은 오른쪽 위")]
	public Vector2 bubbleOffset; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000674")]
	[Tooltip("켜면 x를 다른 버튼 반대편(바깥쪽)으로 뒤집는다. 끄면(기본) 항상 오른쪽 — 왼쪽은 어색하다는 피드백(2026-10-09)")]
	public bool bubbleOuterSide; //Field offset: 0xD0

	[Address(RVA = "0x340B5C8", Offset = "0x340B5C8", Length = "0xC8")]
	[Token(Token = "0x600035C")]
	public ItemNudgeFxConfig() { }

	[Address(RVA = "0x34089B8", Offset = "0x34089B8", Length = "0x144")]
	[Token(Token = "0x600035B")]
	public static ItemNudgeFxConfig Load() { }

}

