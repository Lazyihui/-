namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "StreakPageConfig", menuName = "Hamdoku/Streak Page Config")]
[Token(Token = "0x20000CD")]
public sealed class StreakPageConfig : ScriptableObject
{
	[Token(Token = "0x4000D1D")]
	private static StreakPageConfig _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("꽃 — 인트로(등장) 화면")]
	[Token(Token = "0x4000C88")]
	[Tooltip("꽃/새싹이 그려지는 정사각 박스 한 변(px). 키우면 그만큼 크게 보인다")]
	public float plantIntroSize; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000C89")]
	[Tooltip("인트로 꽃 위치(화면 중앙 기준)")]
	public Vector2 plantIntroPos; //Field offset: 0x1C
	[FieldOffset(Offset = "0x24")]
	[Header("꽃 — 현황 화면")]
	[Token(Token = "0x4000C8A")]
	[Tooltip("현황 화면으로 넘어간 뒤의 꽃 박스 한 변(px)")]
	public float plantStatusSize; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000C8B")]
	[Tooltip("현황 화면 꽃 위치(화면 중앙 기준)")]
	public Vector2 plantStatusPos; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Header("주간 줄(요일 · 체크 · 선물)")]
	[Token(Token = "0x4000C8C")]
	[Tooltip("칸 사이 가로 간격(px)")]
	public float slotSpacing; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000C8D")]
	[Tooltip("칸 하나의 크기(px). 선물은 이 값보다 조금 크게 그려진다")]
	public float slotSize; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000C8E")]
	[Tooltip("주간 줄 위치(화면 중앙 기준)")]
	public Vector2 weekPos; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000C8F")]
	[Tooltip("완료 체크 원반 색")]
	public Color checkDiscColor; //Field offset: 0x40
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000C90")]
	[Tooltip("체크가 박힌 뒤 오늘 칸에 남는 후광 색")]
	public Color todayGlowColor; //Field offset: 0x50
	[FieldOffset(Offset = "0x60")]
	[Range(0, 1)]
	[Token(Token = "0x4000C91")]
	[Tooltip("오늘 칸 후광 진하기(0이면 없음). 코어가 평평한 스프라이트라 원반 바로 밖이 이 값 그대로다")]
	public float todayGlowAlpha; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Range(1.1, 4)]
	[Token(Token = "0x4000C92")]
	[Tooltip("오늘 칸 후광 크기 = 원반 × 이 배율. 원반 밖 폭 전체가 감쇠 구간이다")]
	public float todayGlowScale; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Range(0, 12)]
	[Token(Token = "0x4000C93")]
	[Tooltip("오늘 칸 주변 반짝이 개수(0이면 없음)")]
	public int todaySparkleCount; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000C94")]
	[Tooltip("반짝이 한 개 최대 크기 = 원반 × 이 배율(이 값의 60%~100% 사이 랜덤)")]
	public float todaySparkleSize; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Range(1, 3)]
	[Token(Token = "0x4000C95")]
	[Tooltip("반짝이가 도는 범위 = 원반 × 이 배율")]
	public float todaySparkleSpread; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Range(0, 0.8)]
	[Token(Token = "0x4000C96")]
	[Tooltip("체크 원반 그림자 진하기(0이면 없음)")]
	public float checkShadowAlpha; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Range(0, 2)]
	[Token(Token = "0x4000C97")]
	[Tooltip("그림자가 원반 밖으로 번지는 폭 — 0.55면 원반보다 55% 크게. 이 폭 전체가 감쇠 구간이다")]
	public float checkShadowSpread; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000C98")]
	[Tooltip("그림자가 밀리는 방향/거리 — 원반 크기 대비 비율")]
	public Vector2 checkShadowOffset; //Field offset: 0x7C
	[FieldOffset(Offset = "0x84")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000C99")]
	[Tooltip("선물 상자 그림자 진하기(0이면 그림자 없음)")]
	public float giftShadowAlpha; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000C9A")]
	[Tooltip("선물 상자 그림자가 밀리는 방향/거리 — 칸 크기 대비 비율")]
	public Vector2 giftShadowOffset; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Header("텍스트 · 버튼 위치(화면 중앙 기준)")]
	[Token(Token = "0x4000C9B")]
	[Tooltip("연속 일수 숫자 크기 — 화면의 주인공이라 크게")]
	public float countFontSize; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000C9C")]
	[Tooltip("숫자 아래 한 줄('일째 연속 승리') 크기")]
	public float countLabelFontSize; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000C9D")]
	public Vector2 titlePos; //Field offset: 0x98
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000C9E")]
	public Vector2 countPos; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000C9F")]
	public Vector2 countLabelPos; //Field offset: 0xA8
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000CA0")]
	public Vector2 bestPillPos; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000CA1")]
	[Tooltip("최고 스트릭 알약 크기(px)")]
	public Vector2 bestPillSize; //Field offset: 0xB8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000CA2")]
	[Tooltip("최고 스트릭 글자 크기")]
	public float bestPillFontSize; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Range(0, 2)]
	[Token(Token = "0x4000CA3")]
	[Tooltip("현황 화면이 뜬 뒤 오늘 칸 체크가 박히기까지의 시간(초). 너무 짧으면 못 보고 지나간다")]
	public float stampDelay; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000CA4")]
	public Vector2 ctaPos; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000CA5")]
	public Vector2 ctaSize; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Header("계속하기 버튼")]
	[Token(Token = "0x4000CA6")]
	[Tooltip("버튼 아트에 곱해지는 색. 흰색이면 원본(연노랑), 주황빛을 섞으면 톤이 진해진다")]
	public Color ctaTint; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000CA7")]
	[Tooltip("버튼 글자(흰색) 뒤에 깔리는 글로우 색 — 판보다 어두운 톤이어야 테두리처럼 받쳐 준다")]
	public Color ctaLabelGlow; //Field offset: 0xE8
	[FieldOffset(Offset = "0xF8")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000CA8")]
	[Tooltip("버튼 아래 부드러운 그림자 진하기(0이면 없음)")]
	public float ctaShadowAlpha; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Range(1, 8)]
	[Token(Token = "0x4000CA9")]
	[Tooltip("그림자를 몇 겹으로 흐릴지. 많을수록 가장자리가 매끄럽지만 드로우콜이 늘어난다")]
	public int ctaShadowLayers; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(0, 60)]
	[Token(Token = "0x4000CAA")]
	[Tooltip("그림자가 버튼 밖으로 퍼지는 폭(px). 로비 레벨 버튼과 비슷하려면 16~20")]
	public float ctaShadowSpread; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000CAB")]
	[Tooltip("그림자 오프셋(px). 아래로 내리면 떠 보인다")]
	public Vector2 ctaShadowOffset; //Field offset: 0x104
	[FieldOffset(Offset = "0x10C")]
	[Header("뒤로가기 버튼")]
	[Token(Token = "0x4000CAC")]
	[Tooltip("버튼 한 변(px)")]
	public float backSize; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4000CAD")]
	[Tooltip("세이프에어리어(노치·라운드 베젤) 안쪽에서 더 띄우는 여백(px)")]
	public float backInset; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Header("바닥 빛 · 반딧불")]
	[Token(Token = "0x4000CAE")]
	[Tooltip("오오라·빛기둥·반딧불에 공통으로 쓰는 빛 색. 크림 배경이라 너무 옅으면 묻힌다")]
	public Color lightColor; //Field offset: 0x114
	[FieldOffset(Offset = "0x124")]
	[Range(0, 1)]
	[Token(Token = "0x4000CAF")]
	[Tooltip("숨 쉬는 오오라의 최대 밝기(0이면 오오라 끔)")]
	public float auraAlpha; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Range(0.5, 4)]
	[Token(Token = "0x4000CB0")]
	[Tooltip("오오라가 퍼지는 범위 = 꽃 박스 × 이 배율. 키우면 빛이 화면 쪽으로 넓게 번진다")]
	public float auraSize; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000CB1")]
	[Tooltip("오오라가 커졌다 작아지는 폭. 0.15 = ±15%로 숨쉰다")]
	public float auraBreath; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Range(0, 1)]
	[Token(Token = "0x4000CB2")]
	[Tooltip("흙에서 올라오는 빛기둥의 최대 밝기(0이면 빛기둥 끔)")]
	public float columnAlpha; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Range(0, 16)]
	[Token(Token = "0x4000CB3")]
	[Tooltip("반딧불 개수")]
	public int moteCount; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(1, 15)]
	[Token(Token = "0x4000CB4")]
	[Tooltip("반딧불 하나가 떠오르는 데 걸리는 시간(초). 클수록 은은하게 천천히 오른다")]
	public float moteRiseSeconds; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Range(0, 1)]
	[Token(Token = "0x4000CB5")]
	[Tooltip("반딧불 최대 밝기")]
	public float moteAlpha; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Range(0.02, 0.2)]
	[Token(Token = "0x4000CB6")]
	[Tooltip("반딧불 크기 = 꽃 박스 × 이 배율")]
	public float moteSize; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Header("나비 (주기를 넘겨 만개를 유지할 때)")]
	[Range(0, 3)]
	[Token(Token = "0x4000CB7")]
	[Tooltip("나비 마리 수(0이면 끔). 주기를 한 바퀴 넘겨 계속 만개일 때만 찾아온다")]
	public int butterflyCount; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Range(0.03, 0.2)]
	[Token(Token = "0x4000CB8")]
	[Tooltip("나비 크기 = 컬럼 폭(1080) × 이 배율")]
	public float butterflySize; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Range(0.1, 0.5)]
	[Token(Token = "0x4000CB9")]
	[Tooltip("좌우로 도는 폭 = 컬럼 폭 × 이 배율")]
	public float butterflyRangeX; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Range(0.03, 0.3)]
	[Token(Token = "0x4000CBA")]
	[Tooltip("위아래로 도는 폭 = 컬럼 높이 × 이 배율")]
	public float butterflyRangeY; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Range(5, 60)]
	[Token(Token = "0x4000CBB")]
	[Tooltip("한 바퀴 도는 데 걸리는 시간(초). 클수록 느긋하다")]
	public float butterflySeconds; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Range(0.05, 0.6)]
	[Token(Token = "0x4000CBC")]
	[Tooltip("날개를 한 번 접었다 펴는 시간(초). 두 컷을 번갈아 보여 준다")]
	public float butterflyFlapSeconds; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Range(0, 60)]
	[Token(Token = "0x4000CBD")]
	[Tooltip("둘째 나비가 뒤늦게 찾아오기까지의 시간(초)")]
	public float butterflySecondDelay; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Header("꽃 반짝임")]
	[Range(0, 10)]
	[Token(Token = "0x4000CBE")]
	[Tooltip("꽃 머리 주변에서 깜빡이는 반짝이 개수(0이면 끔). 씨방·만개 단계에서만 보인다")]
	public int sparkleCount; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Token(Token = "0x4000CBF")]
	[Tooltip("반짝이 색")]
	public Color sparkleColor; //Field offset: 0x164
	[FieldOffset(Offset = "0x174")]
	[Range(10, 90)]
	[Token(Token = "0x4000CC0")]
	[Tooltip("반짝이 한 개 크기(px). 이 값의 55%~100% 사이에서 랜덤. sparkleSizeFrac이 0보다 크면 무시된다")]
	public float sparkleSize; //Field offset: 0x174
	[FieldOffset(Offset = "0x178")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000CC1")]
	[Tooltip("반짝이 크기 = 꽃 머리 지름 × 이 배율(0=끔, 그때는 sparkleSize px 사용). 랭킹 페이지 선물상자 반짝임과 같은 체감 비율 = 0.28")]
	public float sparkleSizeFrac; //Field offset: 0x178
	[FieldOffset(Offset = "0x17C")]
	[Range(1, 3)]
	[Token(Token = "0x4000CC2")]
	[Tooltip("반짝이가 도는 범위 = 꽃 머리 지름 × 이 배율")]
	public float sparkleSpread; //Field offset: 0x17C
	[FieldOffset(Offset = "0x180")]
	[Header("만개 이후 성장 (새싹 · 작은 꽃 · 화단)")]
	[Range(1, 3)]
	[Token(Token = "0x4000CC3")]
	[Tooltip("반짝임 단계(10일)에서 반짝이 개수·범위에 곱할 배수")]
	public float bloomSparkleBoost; //Field offset: 0x180
	[FieldOffset(Offset = "0x184")]
	[Range(-0.6, 0.6)]
	[Token(Token = "0x4000CC4")]
	[Tooltip("새싹의 좌우 위치 — 꽃 박스 대비 비율(0이 박스 중심, +가 오른쪽)")]
	public float sproutX; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Range(0.05, 0.6)]
	[Token(Token = "0x4000CC5")]
	[Tooltip("새싹 크기 = 꽃 박스 × 이 배율")]
	public float sproutScale; //Field offset: 0x188
	[FieldOffset(Offset = "0x18C")]
	[Range(-0.6, 0.6)]
	[Token(Token = "0x4000CC6")]
	[Tooltip("작은 꽃으로 자랐을 때의 좌우 위치 — 꽃 박스 대비 비율")]
	public float smallFlowerX; //Field offset: 0x18C
	[FieldOffset(Offset = "0x190")]
	[Range(0.1, 0.8)]
	[Token(Token = "0x4000CC7")]
	[Tooltip("작은 꽃 크기 = 꽃 박스 × 이 배율")]
	public float smallFlowerScale; //Field offset: 0x190
	[FieldOffset(Offset = "0x194")]
	[Range(-0.6, 0.6)]
	[Token(Token = "0x4000CC8")]
	[Tooltip("화단 단계에서 왼쪽에 생기는 꽃의 좌우 위치 — 꽃 박스 대비 비율")]
	public float gardenLeftX; //Field offset: 0x194
	[FieldOffset(Offset = "0x198")]
	[Range(0.1, 0.8)]
	[Token(Token = "0x4000CC9")]
	[Tooltip("왼쪽 꽃 크기 = 꽃 박스 × 이 배율")]
	public float gardenLeftScale; //Field offset: 0x198
	[FieldOffset(Offset = "0x19C")]
	[Range(0.3, 0.9)]
	[Token(Token = "0x4000CCA")]
	[Tooltip("바깥 식구(더 풍성한 화단 단계)의 좌우 위치 — 꽃 박스 대비 비율. 좌우 대칭으로 놓인다")]
	public float outerX; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Range(0.1, 0.8)]
	[Token(Token = "0x4000CCB")]
	[Tooltip("바깥 꽃 크기 = 꽃 박스 × 이 배율. 안쪽 꽃보다 작아야 원근이 산다")]
	public float outerFlowerScale; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Range(1, 1.6)]
	[Token(Token = "0x4000CCC")]
	[Tooltip("바깥 새싹이 생기는 단계(45일)에서 안쪽 좌우 꽃에 곱할 크기 배수 — 안쪽도 함께 자란 느낌")]
	public float innerGrowth; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Range(1, 1.8)]
	[Token(Token = "0x4000CCD")]
	[Tooltip("화단이 완성되는 단계(60일)에서 좌우 꽃 전체에 곱할 크기 배수. innerGrowth보다 커야 단계가 구분된다")]
	public float fullBedGrowth; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Range(1, 1.5)]
	[Token(Token = "0x4000CCE")]
	[Tooltip("화단이 완성되는 단계(60일)에서 좌우 간격에 곱할 배수 — 꽃이 커진 만큼 벌려 준다")]
	public float fullBedSpread; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B0")]
	[Range(0.05, 0.8)]
	[Token(Token = "0x4000CCF")]
	[Tooltip("뒷줄 해바라기(90일)의 좌우 위치 — 꽃 박스 대비 비율. 좌우 대칭으로 놓인다. 너무 안쪽이면 본체에 가려 안 보인다")]
	public float backRowX; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B4")]
	[Range(0.1, 0.7)]
	[Token(Token = "0x4000CD0")]
	[Tooltip("뒷줄 해바라기 크기 = 꽃 박스 × 이 배율. 원경이라 앞줄보다 작지만, 너무 작으면 앞줄에 완전히 묻힌다")]
	public float backRowScale; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1B8")]
	[Range(0, 0.35)]
	[Token(Token = "0x4000CD1")]
	[Tooltip("뒷줄을 바닥선보다 띄우는 정도 — 꽃 박스 대비 비율. 클수록 멀리·높이 보인다. 앞줄 위로 머리가 나올 만큼은 띄워야 뒷줄이 있는 줄 안다")]
	public float backRowLift; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Range(0, 6)]
	[Token(Token = "0x4000CD2")]
	[Tooltip("뒷줄까지 다 자란 단계(90일)에서 꽃마다 얹히는 반짝이 개수(0=끔). 화단 전체를 하나로 덮으면 꽃 없는 빈 공간에도 뿌려져서 꽃마다 따로 붙인다")]
	public int bedSparkleCount; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C0")]
	[Range(-0.1, 0.1)]
	[Token(Token = "0x4000CD3")]
	[Tooltip("바닥선 미세 조정 — 꽃 박스 대비 비율. +면 위로, -면 아래로. 0이 본체 흙 바닥과 정확히 같은 선")]
	public float companionGroundOffset; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C4")]
	[Range(0, 8)]
	[Token(Token = "0x4000CD4")]
	[Tooltip("식구가 산들바람에 흔들리는 각도(도). 0이면 정지")]
	public float companionSwayDegrees; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Range(1, 8)]
	[Token(Token = "0x4000CD5")]
	[Tooltip("한 번 흔들리는 데 걸리는 시간(초)")]
	public float companionSwaySeconds; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1CC")]
	[Header("보상 수령 연출")]
	[Range(60, 260)]
	[Token(Token = "0x4000CD6")]
	[Tooltip("아이템 아이콘 크기(px)")]
	public float rewardIconSize; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Range(24, 90)]
	[Token(Token = "0x4000CD7")]
	[Tooltip("+N 수량 글자 크기")]
	public float rewardFontSize; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Token(Token = "0x4000CD8")]
	[Tooltip("후광·빛살 색(알파는 아래 두 값이 따로 정한다)")]
	public Color rewardGlowColor; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1E4")]
	[Range(1, 5)]
	[Token(Token = "0x4000CD9")]
	[Tooltip("부드러운 후광 크기 = 아이콘 × 이 배율")]
	public float rewardGlowScale; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1E8")]
	[Range(0, 1)]
	[Token(Token = "0x4000CDA")]
	[Tooltip("부드러운 후광 진하기(0이면 후광 없음)")]
	public float rewardGlowAlpha; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[Range(1, 5)]
	[Token(Token = "0x4000CDB")]
	[Tooltip("도는 빛살 크기 = 아이콘 × 이 배율")]
	public float rewardRayScale; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Range(0, 1)]
	[Token(Token = "0x4000CDC")]
	[Tooltip("도는 빛살 진하기(0이면 빛살 없이 후광만)")]
	public float rewardRayAlpha; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Range(2, 30)]
	[Token(Token = "0x4000CDD")]
	[Tooltip("빛살이 한 바퀴 도는 시간(초). 클수록 느긋하다")]
	public float rewardRaySeconds; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Range(0, 260)]
	[Token(Token = "0x4000CDE")]
	[Tooltip("튀어 오르는 높이(px). 등장 순간 한 번에 솟는 거리")]
	public float rewardRise; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Range(0, 260)]
	[Token(Token = "0x4000CDF")]
	[Tooltip("그 뒤 천천히 더 떠오르는 거리(px). 0이면 제자리에서 사라진다")]
	public float rewardDrift; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Range(0.3, 4)]
	[Token(Token = "0x4000CE0")]
	[Tooltip("천천히 떠오르며 사라지는 데 걸리는 시간(초)")]
	public float rewardHold; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Header("꽃잎 연출")]
	[Range(6, 24)]
	[Token(Token = "0x4000CE1")]
	[Tooltip("만개했을 때 꽃 뒤에 도는 꽃잎 수")]
	public int petalCount; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Range(0.1, 0.6)]
	[Token(Token = "0x4000CE2")]
	[Tooltip("꽃잎 길이 = 꽃 박스 × 이 배율")]
	public float petalLength; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Range(0.01, 0.3)]
	[Token(Token = "0x4000CE3")]
	[Tooltip("꽃잎이 한 장씩 심기는 간격(초)")]
	public float petalInterval; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Range(0.6, 1.6)]
	[Token(Token = "0x4000CE4")]
	[Tooltip("꽃잎 밑동을 덮는 꽃머리(씨방) 크기 배율. 1 = 성장 컷의 씨방과 같은 크기")]
	public float flowerHeadScale; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Range(0, 1)]
	[Token(Token = "0x4000CE5")]
	[Tooltip("꽃잎 밑동을 꽃머리 중심에서 바깥으로 밀어내는 정도. 0 = 중심(많이 가림), 1 = 씨방 가장자리(거의 다 보임). 낮으면 끝만 나와 뾰족해 보인다")]
	public float petalOutset; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Header("복구 팝업 — 판")]
	[Token(Token = "0x4000CE6")]
	[Tooltip("팝업 판 크기(px). 안의 내용은 이 크기에 맞춰 통째로 균일 축소된다")]
	public Vector2 recoverPanelSize; //Field offset: 0x218
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x4000CE7")]
	[Tooltip("판 9-slice 모서리 배율(작을수록 모서리가 둥글게 커진다)")]
	public float recoverPanelPpum; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x4000CE8")]
	[Tooltip("판 안에서 내용 전체를 위/아래로 민다(+가 위). 판 세로를 키운 뒤 이 값을 올리면 위쪽은 그대로 두고 버튼 아래 여백만 늘릴 수 있다")]
	public float recoverContentShiftY; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x4000CE9")]
	[Tooltip("제목 세로 위치 / 크기")]
	public float recoverTitleY; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Token(Token = "0x4000CEA")]
	public float recoverTitleFontSize; //Field offset: 0x22C
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x4000CEB")]
	public Color recoverTitleColor; //Field offset: 0x230
	[FieldOffset(Offset = "0x240")]
	[Header("복구 팝업 — 성장 컷 액자")]
	[Token(Token = "0x4000CEC")]
	[Tooltip("액자(현재 → 끊김 비교) 크기/위치")]
	public Vector2 recoverHeroSize; //Field offset: 0x240
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x4000CED")]
	public float recoverHeroY; //Field offset: 0x248
	[FieldOffset(Offset = "0x24C")]
	[Token(Token = "0x4000CEE")]
	public Color recoverHeroBgColor; //Field offset: 0x24C
	[FieldOffset(Offset = "0x25C")]
	[Token(Token = "0x4000CEF")]
	public float recoverHeroPpum; //Field offset: 0x25C
	[FieldOffset(Offset = "0x260")]
	[Range(1, 4)]
	[Token(Token = "0x4000CF0")]
	[Tooltip("왼쪽(쌓아 둔 쪽) 성장 단계 — 1=새싹, 2=꽃봉오리, 3=씨방, 4=만개")]
	public int recoverPlantNowStage; //Field offset: 0x260
	[FieldOffset(Offset = "0x264")]
	[Range(1, 4)]
	[Token(Token = "0x4000CF1")]
	[Tooltip("오른쪽(끊긴 쪽) 성장 단계 — 왼쪽보다 낮아야 '되돌아갔다'로 읽힌다")]
	public int recoverPlantLostStage; //Field offset: 0x264
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x4000CF2")]
	[Tooltip("성장 컷(StreakPlant1~4) 박스 한 변(px). 그림은 이 안에 비율대로 들어가고, 두 컷이 같은 캔버스라 흙 높이가 저절로 맞는다")]
	public float recoverFlowerSize; //Field offset: 0x268
	[FieldOffset(Offset = "0x26C")]
	[Token(Token = "0x4000CF3")]
	[Tooltip("두 컷이 액자 중앙에서 좌·우로 밀리는 거리(px)")]
	public float recoverFlowerGapX; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Token(Token = "0x4000CF4")]
	[Tooltip("성장 컷 세로 위치(액자 중앙 기준). 숫자는 이 아래에 놓인다")]
	public float recoverFlowerY; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Range(0.4, 1)]
	[Token(Token = "0x4000CF5")]
	[Tooltip("끊긴 쪽(오른쪽) 박스 배율. 두 컷이 같은 캔버스라 1이 기본 — 낮추면 흙 높이가 어긋난다")]
	public float recoverFadedScale; //Field offset: 0x274
	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x4000CF6")]
	[Tooltip("끊긴 쪽 틴트. Image 틴트는 곱셈이라 알파를 낮추면 판 색이 비쳐 바래 보인다")]
	public Color recoverFadedTint; //Field offset: 0x278
	[FieldOffset(Offset = "0x288")]
	[Range(0, 6)]
	[Token(Token = "0x4000CF7")]
	[Tooltip("가운데 화살표 개수 / 글자 크기 / 색. 오른쪽으로 갈수록 옅어진다")]
	public int recoverArrowCount; //Field offset: 0x288
	[FieldOffset(Offset = "0x28C")]
	[Token(Token = "0x4000CF8")]
	public float recoverArrowFontSize; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x4000CF9")]
	public Color recoverArrowColor; //Field offset: 0x290
	[FieldOffset(Offset = "0x2A0")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000CFA")]
	[Tooltip("맨 오른쪽 화살표의 진하기(왼쪽 1 → 오른쪽 이 값으로 옅어진다)")]
	public float recoverArrowTailAlpha; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A4")]
	[Range(0, 0.8)]
	[Token(Token = "0x4000CFB")]
	[Tooltip("화살표가 왼쪽부터 하나씩 켜지는 간격(초). 0이면 애니메이션 없이 전부 켜둔다")]
	public float recoverArrowStep; //Field offset: 0x2A4
	[FieldOffset(Offset = "0x2A8")]
	[Range(0.02, 0.8)]
	[Token(Token = "0x4000CFC")]
	[Tooltip("한 개가 켜지는 데 걸리는 시간(초)")]
	public float recoverArrowFade; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Range(0, 2)]
	[Token(Token = "0x4000CFD")]
	[Tooltip("전부 켜진 뒤 머무는 시간 / 다 같이 사라지는 시간(초). 그 뒤 처음부터 반복한다")]
	public float recoverArrowHold; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Range(0.05, 1.5)]
	[Token(Token = "0x4000CFE")]
	public float recoverArrowClear; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Token(Token = "0x4000CFF")]
	[Tooltip("꽃 아래 숫자 크기와 세로 위치(액자 중앙 기준)")]
	public float recoverCountFontSize; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x4000D00")]
	public float recoverCountY; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Token(Token = "0x4000D01")]
	public Color recoverCountColor; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x4000D02")]
	public Color recoverCountLostColor; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2DC")]
	[Token(Token = "0x4000D03")]
	[Tooltip("숫자 아래 캡션(끊기기 전 / 복구 안 하면) 크기와 색")]
	public float recoverCaptionFontSize; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x4000D04")]
	[Tooltip("숫자 칸 아래 변에서 캡션까지의 간격(px). 세로 위치를 고정값으로 두면 숫자 크기를 키웠을 때 숫자 칸에 파묻힌다 — 그래서 간격만 받는다")]
	public float recoverCaptionGap; //Field offset: 0x2E0
	[FieldOffset(Offset = "0x2E4")]
	[Token(Token = "0x4000D05")]
	public Color recoverCaptionColor; //Field offset: 0x2E4
	[FieldOffset(Offset = "0x2F4")]
	[Header("복구 팝업 — 안내 문구")]
	[Token(Token = "0x4000D06")]
	public Vector2 recoverDescSize; //Field offset: 0x2F4
	[FieldOffset(Offset = "0x2FC")]
	[Token(Token = "0x4000D07")]
	public float recoverDescY; //Field offset: 0x2FC
	[FieldOffset(Offset = "0x300")]
	[Token(Token = "0x4000D08")]
	public float recoverDescFontSize; //Field offset: 0x300
	[FieldOffset(Offset = "0x304")]
	[Token(Token = "0x4000D09")]
	public Color recoverDescColor; //Field offset: 0x304
	[FieldOffset(Offset = "0x314")]
	[Range(-30, 40)]
	[Token(Token = "0x4000D0A")]
	public float recoverDescLineSpacing; //Field offset: 0x314
	[FieldOffset(Offset = "0x318")]
	[Header("복구 팝업 — 버튼")]
	[Token(Token = "0x4000D0B")]
	[Tooltip("복구(광고) 버튼 크기/위치")]
	public Vector2 recoverBtnSize; //Field offset: 0x318
	[FieldOffset(Offset = "0x320")]
	[Token(Token = "0x4000D0C")]
	public float recoverBtnY; //Field offset: 0x320
	[FieldOffset(Offset = "0x324")]
	[Token(Token = "0x4000D0D")]
	[Tooltip("아래 '포기' 버튼과의 간격(px)")]
	public float recoverBtnGap; //Field offset: 0x324
	[FieldOffset(Offset = "0x328")]
	[Token(Token = "0x4000D0E")]
	public Vector2 recoverGiveUpSize; //Field offset: 0x328
	[FieldOffset(Offset = "0x330")]
	[Token(Token = "0x4000D0F")]
	public float recoverBtnFontSize; //Field offset: 0x330
	[FieldOffset(Offset = "0x334")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x4000D10")]
	[Tooltip("버튼 모서리 반경 배율. 1 = 알약 원본 비율(높이의 31%, 새 시즌 팝업과 동일), 낮출수록 각진다. 9-slice 보더를 줄이는 방식이라 알약 아래 입체 립도 함께 얇아진다")]
	public float recoverBtnCornerScale; //Field offset: 0x334
	[FieldOffset(Offset = "0x338")]
	[Token(Token = "0x4000D11")]
	[Tooltip("복구 버튼 틴트 / 라벨 글로우")]
	public Color recoverBtnTint; //Field offset: 0x338
	[FieldOffset(Offset = "0x348")]
	[Token(Token = "0x4000D12")]
	public Color recoverBtnLabelGlow; //Field offset: 0x348
	[FieldOffset(Offset = "0x358")]
	[Token(Token = "0x4000D13")]
	[Tooltip("포기 버튼 틴트 / 라벨 색")]
	public Color recoverGiveUpTint; //Field offset: 0x358
	[FieldOffset(Offset = "0x368")]
	[Token(Token = "0x4000D14")]
	public Color recoverGiveUpLabelColor; //Field offset: 0x368
	[FieldOffset(Offset = "0x378")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000D15")]
	[Tooltip("버튼 그림자 — 총 진하기 / 번지는 폭 / 겹 수 / 밀리는 방향. 새 시즌 팝업(RankPageConfig.seasonBtnShadow*)과 같은 값이 기본이다 — 진하게·넓게 잡으면 알약 테두리에 갈색 링이 생겨 겉이 지저분해진다")]
	public float recoverBtnShadowAlpha; //Field offset: 0x378
	[FieldOffset(Offset = "0x37C")]
	[Token(Token = "0x4000D16")]
	public float recoverBtnShadowSpread; //Field offset: 0x37C
	[FieldOffset(Offset = "0x380")]
	[Range(1, 8)]
	[Token(Token = "0x4000D17")]
	public int recoverBtnShadowLayers; //Field offset: 0x380
	[FieldOffset(Offset = "0x384")]
	[Token(Token = "0x4000D18")]
	public Vector2 recoverBtnShadowOffset; //Field offset: 0x384
	[FieldOffset(Offset = "0x38C")]
	[Token(Token = "0x4000D19")]
	[Tooltip("복구 버튼 안 재생 아이콘 크기(0,0이면 아이콘 없이 글자만)")]
	public Vector2 recoverAdIconSize; //Field offset: 0x38C
	[FieldOffset(Offset = "0x394")]
	[Token(Token = "0x4000D1A")]
	[Tooltip("버튼 왼쪽 끝에서 아이콘까지 / 아이콘과 글자 사이 간격(px). 남는 폭 안에서 글자가 가운데 정렬된다")]
	public float recoverAdIconInset; //Field offset: 0x394
	[FieldOffset(Offset = "0x398")]
	[Token(Token = "0x4000D1B")]
	public float recoverAdIconGap; //Field offset: 0x398
	[FieldOffset(Offset = "0x39C")]
	[Token(Token = "0x4000D1C")]
	[Tooltip("아이콘 미세 이동(px)")]
	public Vector2 recoverAdIconOffset; //Field offset: 0x39C

	[Token(Token = "0x170000D4")]
	public static StreakPageConfig Instance
	{
		[Address(RVA = "0x34351E8", Offset = "0x34351E8", Length = "0xDC")]
		[Token(Token = "0x6000565")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x3436564", Offset = "0x3436564", Length = "0x3F8")]
	[Token(Token = "0x600056D")]
	public StreakPageConfig() { }

	[Address(RVA = "0x34351E8", Offset = "0x34351E8", Length = "0xDC")]
	[Token(Token = "0x6000565")]
	public static StreakPageConfig get_Instance() { }

	[Address(RVA = "0x3435314", Offset = "0x3435314", Length = "0x380")]
	[Token(Token = "0x6000567")]
	private int HashPart1(int h) { }

	[Address(RVA = "0x3435694", Offset = "0x3435694", Length = "0x2F4")]
	[Token(Token = "0x6000568")]
	private int HashPart2(int h) { }

	[Address(RVA = "0x3435988", Offset = "0x3435988", Length = "0x240")]
	[Token(Token = "0x6000569")]
	private int HashPart3(int h) { }

	[Address(RVA = "0x3435BC8", Offset = "0x3435BC8", Length = "0x1B8")]
	[Token(Token = "0x600056C")]
	private int HashPart4(int h) { }

	[Address(RVA = "0x3435D80", Offset = "0x3435D80", Length = "0x3E0")]
	[Token(Token = "0x600056A")]
	private int HashPart5(int h) { }

	[Address(RVA = "0x3436160", Offset = "0x3436160", Length = "0x404")]
	[Token(Token = "0x600056B")]
	private int HashPart6(int h) { }

	[Address(RVA = "0x34352C4", Offset = "0x34352C4", Length = "0x50")]
	[Token(Token = "0x6000566")]
	public int LayoutHash() { }

}

