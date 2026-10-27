namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "RankFxConfig", menuName = "Hamdoku/Rank Fx Config")]
[Token(Token = "0x20000A3")]
public sealed class RankFxConfig : ScriptableObject
{
	[Token(Token = "0x4000910")]
	private static RankFxConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("오버레이 — 공통")]
	[Range(0.3, 1)]
	[Token(Token = "0x40008A8")]
	[Tooltip("딤 알파(프로젝트 전면 딤 표준 = 0.98). 뒤 HUD 겹침은 상단 chrome 숨김으로 처리한다")]
	public float dimAlpha; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(0.6, 1)]
	[Token(Token = "0x40008A9")]
	[Tooltip("와이드 화면(태블릿·폴드 펼침)에서 랭킹 화면 배율 상한. 다른 팝업은 0.8 — 랭킹은 위아래가 많이 비어 조금 더 크게 둔다. 맨 위 말풍선·아래 '탭하여 계속'이 화면 밖으로 나가면 그만큼만 자동으로 덜 키운다")]
	public float overlayWideScale; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Header("오버레이 — 탭하여 계속(자동 닫힘 없음)")]
	[Token(Token = "0x40008AA")]
	public float tapHintY; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40008AB")]
	public float tapHintFontSize; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40008AC")]
	public Color tapHintColor; //Field offset: 0x28
	[FieldOffset(Offset = "0x38")]
	[Header("오버레이 — 순위 상승 알림 말풍선(레퍼런스, 2026-08-20)")]
	[Token(Token = "0x40008AD")]
	[Tooltip("상승 연출이 끝난 뒤 상단에 뜨는 말풍선. 0 알파 배경이면 글자만 남는다")]
	public float rankUpMsgY; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40008AE")]
	public float rankUpMsgFontSize; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40008AF")]
	[Tooltip("말풍선 최소 크기(폭×높이) — 문구가 길면 폭은 자동으로 늘어난다. 단상(폭 ~707)과 나란히 보여 720 이상이어야 좁아 보이지 않는다(2026-10-04)")]
	public Vector2 rankUpMsgMinSize; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40008B0")]
	[Tooltip("문구 좌우 여백 합(px) — 자동 폭 계산에 더해진다(한쪽 = 절반)")]
	public float rankUpMsgPadX; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40008B1")]
	public Color rankUpMsgBgColor; //Field offset: 0x4C
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x40008B2")]
	public Color rankUpMsgTextColor; //Field offset: 0x5C
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40008B3")]
	[Tooltip("숫자만 다른 색으로 강조(알파 0이면 본문 색 그대로)")]
	public Color rankUpMsgNumColor; //Field offset: 0x6C
	[FieldOffset(Offset = "0x7C")]
	[Range(0, 1)]
	[Token(Token = "0x40008B4")]
	[Tooltip("말풍선 뒤 소프트 섀도 진하기(0=끔)")]
	public float rankUpMsgShadowAlpha; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40008B5")]
	[Tooltip("타이틀과 최소로 벌릴 간격(px) — 이 값 덕분에 titleY를 바꿔도 말풍선이 타이틀을 덮지 않는다")]
	public float rankUpMsgTitleGap; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Range(0, 1)]
	[Token(Token = "0x40008B6")]
	[Tooltip("말풍선 뒤 따뜻한 후광 진하기(0=끔) / 크기 = 말풍선 크기 × 배율(시안)")]
	public float rankUpMsgGlowAlpha; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40008B7")]
	public Vector2 rankUpMsgGlowScale; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40008B8")]
	public Color rankUpMsgGlowColor; //Field offset: 0x90
	[FieldOffset(Offset = "0xA0")]
	[Range(0, 6)]
	[Token(Token = "0x40008B9")]
	[Tooltip("양옆 반짝임 개수(한쪽당, 0=끔) — 시안처럼 말풍선 좌우 끝에서 반짝인다")]
	public int rankUpMsgSparkleCount; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40008BA")]
	[Tooltip("반짝임 크기(px) — 최소~최대 사이 랜덤")]
	public Vector2 rankUpMsgSparkleSize; //Field offset: 0xA4
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x40008BB")]
	[Tooltip("반짝임이 흩어지는 영역 한 변(px)")]
	public float rankUpMsgSparkleArea; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40008BC")]
	[Tooltip("말풍선 좌우 끝에서 반짝임 중심까지 거리(px, 음수=안쪽)")]
	public float rankUpMsgSparkleInset; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x40008BD")]
	public Color rankUpMsgSparkleColor; //Field offset: 0xB4
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x40008BE")]
	[Tooltip("등장 시간(초) / 이후 위아래로 살짝 둥실")]
	public float rankUpMsgPopDur; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40008BF")]
	public float rankUpMsgBob; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Header("오버레이 — 타이틀")]
	[Token(Token = "0x40008C0")]
	public float titleY; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40008C1")]
	public float titleFontSize; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x40008C2")]
	public Color titleColor; //Field offset: 0xD4
	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x40008C3")]
	[Tooltip("타이틀 아웃라인(글로우) 색")]
	public Color titleOutlineColor; //Field offset: 0xE4
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x40008C4")]
	[Tooltip("타이틀 볼드 — 한글 TMP 가짜 볼드가 뭉툭해 보이면 끄기")]
	public bool titleBold; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Header("오버레이 — 타이머 캡슐")]
	[Token(Token = "0x40008C5")]
	public float timerY; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x40008C6")]
	[Tooltip("캡슐 높이 — 글자/아이콘/여백이 모두 여기 비례")]
	public float timerHeight; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40008C7")]
	[Tooltip("시계 아이콘 한 변 = 캡슐 높이 × 이 배율")]
	public float timerIconScale; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x40008C8")]
	public Color timerCapsuleColor; //Field offset: 0x104
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x40008C9")]
	public Color timerTextColor; //Field offset: 0x114
	[FieldOffset(Offset = "0x124")]
	[Range(-120, 240)]
	[Token(Token = "0x40008CA")]
	[Tooltip("캡슐 추가 폭(px) — 자동 폭에 더하거나 뺀다")]
	public float timerExtraWidth; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Header("오버레이 — 상단 포디움(현재 1~3위 단상, 리더보드 이식 · 선물 상자 없음, 2026-10-04)")]
	[Token(Token = "0x40008CB")]
	[Tooltip("클리어 후 랭킹 판 위쪽에 현재 1~3위 단상(아바타·닉네임·씨앗)을 보여 줄지. 끄면 예전 레이아웃(rowsTopY) 그대로")]
	public bool podiumShow; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Range(0.3, 1)]
	[Token(Token = "0x40008CC")]
	[Tooltip("단상 배율 — 리더보드 포디움 노브(RankPageConfig 앵커·크기·폰트)를 그대로 쓰고 이 배율로 줄인다")]
	public float podiumScale; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40008CD")]
	[Tooltip("타이머 캡슐 아래 ~ 단상 블록 꼭대기(1위 아바타 상단) 간격(px). 왕관 프레임은 아바타 위로 더 솟으니 넉넉히(2026-10-04 실기 16→34)")]
	public float podiumTopGap; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x40008CE")]
	[Tooltip("단상 이미지 바닥 ~ 첫 행 상단 간격(px). 포디움을 켜면 행 밴드는 rowsTopY 대신 단상 아래에서 시작한다(자동 하향)")]
	public float podiumRowsGap; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(0, 1)]
	[Token(Token = "0x40008CF")]
	[Tooltip("1위 아바타 뒤 후광 진하기(0=끔) — 리더보드 heroAura 축약판(빛 알갱이 없음)")]
	public float podiumHeroGlowAlpha; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Token(Token = "0x40008D0")]
	[Tooltip("상승 연출이 끝난 뒤 단상을 최종 상태로 갱신(내가 3위 안에 들어가거나 단상 위 내 씨앗 값이 바뀐 경우). 끄면 처음부터 최종 상태")]
	public bool podiumUpdateOnLand; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40008D1")]
	[Tooltip("행 밴드 바닥 ~ '탭하여 계속' 사이 최소 간격(px) — 밴드가 내려가면 힌트도 그만큼 밀려 내려간다(tapHintY는 상한)")]
	public float tapHintMinGap; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Header("오버레이 — 행")]
	[Token(Token = "0x40008D2")]
	public float rowW; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40008D3")]
	[Tooltip("행 높이 — 레퍼런스처럼 도톰하게")]
	public float rowH; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x40008D4")]
	public float rowGap; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40008D5")]
	[Tooltip("첫 행 중심 y(캔버스 중앙 기준)")]
	public float rowsTopY; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x40008D6")]
	public float rankFontSize; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40008D7")]
	public float nameFontSize; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40008D8")]
	public float avatarSize; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Range(0, 1)]
	[Token(Token = "0x40008D9")]
	[Tooltip("아바타/프레임 뒤 앰비언트 섀도 진하기(0=끔)")]
	public float avatarShadowAlpha; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Range(0, 60)]
	[Token(Token = "0x40008DA")]
	[Tooltip("섀도가 프레임 바깥으로 번지는 폭(px) — 크면 사방 테두리처럼 보이니 작게")]
	public float avatarShadowSpread; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Range(-40, 0)]
	[Token(Token = "0x40008DB")]
	[Tooltip("섀도 세로 오프셋(px, 음수=아래) — 아래로 내릴수록 드롭 섀도 느낌")]
	public float avatarShadowOffsetY; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x40008DC")]
	public Color rowColor; //Field offset: 0x16C
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x40008DD")]
	public Color rowMeColor; //Field offset: 0x17C
	[FieldOffset(Offset = "0x18C")]
	[Token(Token = "0x40008DE")]
	public Color textColor; //Field offset: 0x18C
	[FieldOffset(Offset = "0x19C")]
	[Range(0.2, 1)]
	[Token(Token = "0x40008DF")]
	[Tooltip("맨 위 행이 '위가 더 있음' 암시로 잘려 보일 때 하단 노출 비율 — 레퍼런스처럼 살짝만 걸치게 작게")]
	public float peekVisibleFrac; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Range(0.05, 1)]
	[Token(Token = "0x40008E0")]
	[Tooltip("잘린 맨 위 행의 알파")]
	public float peekAlpha; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Range(0, 150)]
	[Token(Token = "0x40008E1")]
	[Tooltip("잘린 경계의 페더(px) — 0이면 칼같이 잘리고, 클수록 위로 부드럽게 사라진다(레퍼런스 톤)")]
	public float peekSoftness; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x40008E2")]
	[Tooltip("어두운 그라데이션 덮기(보조) — 밝은 행 위에서 띠처럼 보일 수 있어 기본 끔")]
	public bool peekDarkOverlay; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Range(0.5, 3)]
	[Token(Token = "0x40008E3")]
	[Tooltip("페이드 곡선 지수(peekDarkOverlay 전용) — 1=균등 램프")]
	public float peekFadeExponent; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B0")]
	[Header("씨앗 비행(배지/랭킹 판 공통)")]
	[Token(Token = "0x40008E4")]
	[Tooltip("날아가는 씨앗 크기(px)")]
	public float seedFlySize; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B4")]
	[Range(0.03, 0.6)]
	[Token(Token = "0x40008E5")]
	[Tooltip("씨앗 발사 간격(초) = 착지 간격. 0.08~0.10이면 '타타탕' 연타 느낌")]
	public float seedFlyInterval; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1B8")]
	[Range(0.5, 2.5)]
	[Token(Token = "0x40008E6")]
	[Tooltip("씨앗 비행 배속(1=기본, 클수록 빠르게 박힘) — 배지/랭킹 판 공통, 뿅 등장 구간도 함께 빨라짐")]
	public float seedFlySpeed; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Header("오버레이 — 씨앗 pill")]
	[Token(Token = "0x40008E7")]
	public Vector2 pillSize; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x40008E8")]
	public float pillValueFontSize; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x40008E9")]
	[Tooltip("pill 왼쪽 에지 ~ 씨앗 아이콘 사이 여백(px)")]
	public float pillIconPadLeft; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1CC")]
	[Range(0, 1)]
	[Token(Token = "0x40008EA")]
	[Tooltip("pill 뒤 소프트 섀도 진하기(0=끔)")]
	public float pillShadowAlpha; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Header("오버레이 — 순위 상승 연출")]
	[Range(1, 24)]
	[Token(Token = "0x40008EB")]
	[Tooltip("한 번에 보여 줄 최대 계단 수 — 상승 폭이 이보다 크면 숫자 롤다운/알림 문구가 남은 폭을 전한다")]
	public int rankUpMaxHops; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Token(Token = "0x40008EC")]
	[Tooltip("첫 칸 간격(초) — 초반 '띠리리리' 속도. 간격은 칸마다 기하급수로 벌어져 마지막 간격에 닿는다(RankRollSchedule)")]
	public float rankUpTickStartGap; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x40008ED")]
	[Tooltip("마지막 칸 간격(초) — 멈추기 직전 '띡… 띡' 간격. 클수록 룰렛처럼 오래 끈다")]
	public float rankUpTickEndGap; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Range(1, 12)]
	[Token(Token = "0x40008EE")]
	[Tooltip("감속에 쓰는 마지막 칸 수 — 이 앞까지는 첫 칸 간격 그대로 '띠리리리', 여기부터 마지막 간격까지 기하급수로 벌어진다")]
	public int rankUpDecelSteps; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x40008EF")]
	[Tooltip("총 롤링 시간 하한/상한(초) — 간격 합이 범위를 벗어나면 비율을 유지한 채 늘리거나 줄인다")]
	public float rankUpRollMin; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E4")]
	[Token(Token = "0x40008F0")]
	public float rankUpRollMax; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1E8")]
	[Range(0, 40)]
	[Token(Token = "0x40008F1")]
	[Tooltip("최소로 흘러가는 칸 수(연출용 과장, 2026-09-07). 실제 상승이 이보다 적으면 내 옛 자리 아래 실제 행들(상한에 걸린 추월 행 → 옛 순위 아래 행)을 활주로로 붙여 이만큼 스치게 하고, 시작 순위 표시를 그만큼 아래로 잡는다. 자리를 내주는 행은 실제 칸 수만. 0=끔")]
	public int rankUpMinVisualHops; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[HideInInspector]
	[Token(Token = "0x40008F2")]
	public bool bandTapCloses; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Range(1, 4)]
	[Token(Token = "0x40008F3")]
	[Tooltip("계단 소리를 몇 홉마다 낼지 — 1=매 홉. 홉이 많을 때 매번 울리면 시끄럽다")]
	public int rankUpTickEvery; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Range(3, 8)]
	[Token(Token = "0x40008F4")]
	[Tooltip("행 밴드에 '보일' 최대 행 수 — 상승용으로 늘어난 아래쪽 행은 이 밖에서 잘린다")]
	public int rowsVisibleMax; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x40008F5")]
	public float swapUpDur; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x40008F6")]
	public float swapDownDur; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x40008F7")]
	[Tooltip("상승 중 내 행 확대 배율(레퍼런스). 착지하며 1로 복귀")]
	public float meRowSwapScale; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x40008F8")]
	[Tooltip("상승 중 내 행 주위로 떠오르는 위 화살표 개수(0=끔). 에셋 UI/Ranking/arrow_up 우선, 없으면 절차 생성")]
	public int swapArrowCount; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x40008F9")]
	[Tooltip("화살표 기준 높이(px) — 개별 화살표는 0.75~1.15배 랜덤")]
	public float swapArrowSize; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x40008FA")]
	public Color swapArrowColor; //Field offset: 0x20C
	[FieldOffset(Offset = "0x21C")]
	[Range(0, 1)]
	[Token(Token = "0x40008FB")]
	[Tooltip("착지 순간 내 행 외곽 테두리 글로우 진하기(0=끔)")]
	public float rowGlowAlpha; //Field offset: 0x21C
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x40008FC")]
	[Tooltip("글로우가 행 바깥으로 번지는 폭(px)")]
	public float rowGlowSpread; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x40008FD")]
	[Tooltip("번쩍인 뒤 잦아드는 시간(초)")]
	public float rowGlowFade; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x40008FE")]
	public Color rowGlowColor; //Field offset: 0x228
	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x40008FF")]
	[Tooltip("씨앗이 내 행에 착지할 때마다 터지는 반짝 개수(0=끔)")]
	public int seedSparkleCount; //Field offset: 0x238
	[FieldOffset(Offset = "0x23C")]
	[Token(Token = "0x4000900")]
	public float seedSparkleSize; //Field offset: 0x23C
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x4000901")]
	[Tooltip("좌측 배지 반짝/꼬리 색 — 밝은 크림 배경 위라 진한 오렌지가 아니면 묻힌다")]
	public Color badgeSparkleColor; //Field offset: 0x240
	[FieldOffset(Offset = "0x250")]
	[Header("씨앗 배지(좌측)")]
	[Token(Token = "0x4000902")]
	[Tooltip("알약 표시 크기 — 원본 비율(902x256) 유지 렌더")]
	public Vector2 badgeSize; //Field offset: 0x250
	[FieldOffset(Offset = "0x258")]
	[Range(0, 1)]
	[Token(Token = "0x4000903")]
	[Tooltip("배지 뒤 소프트 섀도 진하기(0=끔) — 밝은 보드 위에 얹히는 접지감")]
	public float badgeShadowAlpha; //Field offset: 0x258
	[FieldOffset(Offset = "0x25C")]
	[Token(Token = "0x4000904")]
	[Tooltip("섀도가 배지 바깥으로 번지는 폭(px)")]
	public float badgeShadowSpread; //Field offset: 0x25C
	[FieldOffset(Offset = "0x260")]
	[Token(Token = "0x4000905")]
	[Tooltip("섀도 오프셋(px, 음수 y=아래)")]
	public Vector2 badgeShadowOffset; //Field offset: 0x260
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x4000906")]
	public Color badgeShadowColor; //Field offset: 0x268
	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x4000907")]
	[Tooltip("화면 안으로 들어오는 우측 폭")]
	public float badgeVisibleW; //Field offset: 0x278
	[FieldOffset(Offset = "0x27C")]
	[Range(0, 1)]
	[Token(Token = "0x4000908")]
	[Tooltip("세로 위치(0=하단 1=상단). 보드 상단 부근")]
	public float badgeAnchorY; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x4000909")]
	public float badgeSlideDur; //Field offset: 0x280
	[FieldOffset(Offset = "0x284")]
	[Token(Token = "0x400090A")]
	public float badgeIconSize; //Field offset: 0x284
	[FieldOffset(Offset = "0x288")]
	[Token(Token = "0x400090B")]
	[Tooltip("씨앗 아이콘 x(알약 우측 에지 기준 음수)")]
	public float badgeIconX; //Field offset: 0x288
	[FieldOffset(Offset = "0x28C")]
	[Token(Token = "0x400090C")]
	[Tooltip("숫자 영역 우측 x(우측 에지 기준 음수) — 외곽에 붙지 않게 여유")]
	public float badgeValueX; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x400090D")]
	public float badgeValueW; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Token(Token = "0x400090E")]
	public float badgeValueFontSize; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x400090F")]
	public Color badgeValueColor; //Field offset: 0x298

	[Address(RVA = "0x34206DC", Offset = "0x34206DC", Length = "0x270")]
	[Token(Token = "0x6000464")]
	public RankFxConfig() { }

	[Address(RVA = "0x3420598", Offset = "0x3420598", Length = "0x144")]
	[Token(Token = "0x6000463")]
	public static RankFxConfig Load() { }

}

