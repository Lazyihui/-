namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "RankPageConfig", menuName = "Hamdoku/Rank Page Config")]
[Token(Token = "0x20000A6")]
public sealed class RankPageConfig : ScriptableObject
{
	[Token(Token = "0x4000A8F")]
	private static RankPageConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("타이틀")]
	[Token(Token = "0x400091A")]
	public float titleY; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400091B")]
	[Tooltip("타이틀 리본(UI/Ranking/title_ribbon) 폭(0=끔). 높이는 원본 비율")]
	public float titleRibbonW; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400091C")]
	[Tooltip("리본 중심 y = 타이틀 텍스트 기준 px(음수=아래) — 배너 밴드 중심에 글자가 오도록(실측 -9)")]
	public float titleRibbonDy; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Range(0, 1)]
	[Token(Token = "0x400091D")]
	[Tooltip("타이틀 배너 아래 소프트 섀도 진하기(0=끔)")]
	public float titleShadowAlpha; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Range(0.5, 1.2)]
	[Token(Token = "0x400091E")]
	[Tooltip("배너 섀도 폭(배너 폭 대비 비율) — 꼬리/꽃 장식 여백을 뺀 본판 폭")]
	public float titleShadowWFrac; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(0.3, 1.2)]
	[Token(Token = "0x400091F")]
	[Tooltip("배너 섀도 높이(배너 높이 대비 비율)")]
	public float titleShadowHFrac; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000920")]
	[Tooltip("배너 섀도 y 오프셋(px, 음수=아래)")]
	public float titleShadowDy; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000921")]
	[Tooltip("타이틀 아웃 글로우 — 색(titleOutlineColor)을 배너보다 살짝 진하게 쓰면 메달 숫자처럼 도장 느낌(2026-08-19)")]
	public bool titleGlow; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000922")]
	public float titleFontSize; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000923")]
	public Color titleColor; //Field offset: 0x3C
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000924")]
	[Tooltip("타이틀 아웃라인(글로우) 색 — 배너색보다 살짝 진한 골드 톤")]
	public Color titleOutlineColor; //Field offset: 0x4C
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000925")]
	[Tooltip("타이틀 볼드 — 한글 TMP 가짜 볼드가 뭉툭해 보이면 끄기")]
	public bool titleBold; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Header("뒤로가기/인포 (chrome — 컬럼 축소와 무관하게 크기 유지)")]
	[Token(Token = "0x4000926")]
	public float backSize; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000927")]
	public float backInset; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Header("타이머 캡슐")]
	[Token(Token = "0x4000928")]
	public float timerY; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000929")]
	public float timerHeight; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400092A")]
	[Tooltip("시계 아이콘 한 변 = 캡슐 높이 × 이 배율")]
	public float timerIconScale; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400092B")]
	[Tooltip("타이머 폰트 크기(0=자동: 캡슐 높이 × 0.62). 지정하면 캡슐 폭도 다시 계산")]
	public float timerFontSize; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400092C")]
	public Color timerCapsuleColor; //Field offset: 0x78
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400092D")]
	public Color timerTextColor; //Field offset: 0x88
	[FieldOffset(Offset = "0x98")]
	[Range(-240, 400)]
	[Token(Token = "0x400092E")]
	[Tooltip("캡슐 추가 폭(px) — 자동 폭(아이콘+텍스트+패딩)에 더하거나 뺀다. 섀도도 함께 따라간다")]
	public float timerExtraWidth; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Range(0, 1)]
	[Token(Token = "0x400092F")]
	[Tooltip("타이머 캡슐 뒤 소프트 섀도 진하기(0=끔)")]
	public float timerShadowAlpha; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Header("포디움 (통짜 이미지 UI/Ranking/podium + 오버레이)")]
	[Token(Token = "0x4000930")]
	[Tooltip("포디움 이미지 폭(px). 높이는 원본 비율 자동")]
	public float podiumImageW; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000931")]
	[Tooltip("포디움 이미지 중심 y(컬럼 중앙 기준) — 1위 아바타 상단이 타이머와 겹치지 않는 값")]
	public float podiumImageCenterY; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000932")]
	[Tooltip("단상 상단 중심(아바타 바닥이 놓이는 점) — 이미지 정규화 좌표(0~1). 에셋 실측값")]
	public Vector2 podiumAnchor1; //Field offset: 0xA8
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000933")]
	public Vector2 podiumAnchor2; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000934")]
	public Vector2 podiumAnchor3; //Field offset: 0xB8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000935")]
	[Tooltip("선물상자 중심 — 이미지 정규화 좌표(1보다 크면 이미지 아래로 나감)")]
	public Vector2 podiumGift1; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000936")]
	public Vector2 podiumGift2; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000937")]
	public Vector2 podiumGift3; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000938")]
	[Tooltip("메달 뱃지 중심 = 단상 앵커에서 아래로 이 px만큼")]
	public float podiumMedalDrop; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000939")]
	[Tooltip("닉네임 중심 y = 단상 앵커 기준 px(음수=아래)")]
	public float podiumNameY; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400093A")]
	[Tooltip("닉네임 박스 폭(px) — 넘치면 말줄임")]
	public float podiumNameW; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x400093B")]
	[Tooltip("씨앗 pill 중심 y = 단상 앵커 기준 px(음수=아래)")]
	public float podiumPillY; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x400093C")]
	public float podiumAvatarSize; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x400093D")]
	public float podiumMedalSize; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x400093E")]
	public float podiumNameFontSize; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x400093F")]
	[Tooltip("닉네임 오토 사이징 하한 — 길면 이 크기까지 줄이고, 그래도 넘치면 말줄임")]
	public float podiumNameFontMin; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000940")]
	public Vector2 podiumPillSize; //Field offset: 0xF8
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000941")]
	public float podiumPillFontSize; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000942")]
	[Tooltip("단상 아래 선물상자 크기 - 순위별(0=끔). 가운데(1위) 크게, 양옆 작게(2026-08-19)")]
	public float podiumGiftSize1; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4000943")]
	public float podiumGiftSize2; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4000944")]
	public float podiumGiftSize3; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4000945")]
	[Tooltip("닉네임 색 = 단상 컬러보다 진한 톤(레퍼런스, 2026-08-19). 1=노랑, 2=파랑, 3=분홍 단상")]
	public Color podiumNameCol1; //Field offset: 0x110
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000946")]
	public Color podiumNameCol2; //Field offset: 0x120
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000947")]
	public Color podiumNameCol3; //Field offset: 0x130
	[FieldOffset(Offset = "0x140")]
	[Header("포디움 폴백(이미지 없을 때 코드 단상)")]
	[Token(Token = "0x4000948")]
	public float podiumBaseY; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x4000949")]
	public float podiumStandW; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x400094A")]
	public float podiumGap; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x400094B")]
	public float podiumH1; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x400094C")]
	public float podiumH2; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x400094D")]
	public float podiumH3; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x400094E")]
	public Color podiumCol1; //Field offset: 0x158
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x400094F")]
	public Color podiumCol2; //Field offset: 0x168
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x4000950")]
	public Color podiumCol3; //Field offset: 0x178
	[FieldOffset(Offset = "0x188")]
	[Header("메달 뱃지(UI/Ranking/medal_N) — 포디움/리스트 공용")]
	[Token(Token = "0x4000951")]
	[Tooltip("숫자는 에셋에 없어 TMP로 얹는다(2026-08-19 규격). 글자 = 흰색, 아래 글로우 색 = 뱃지 바탕보다 살짝 어두운 톤(가독성)")]
	public Color medalNumGlow1; //Field offset: 0x188
	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x4000952")]
	public Color medalNumGlow2; //Field offset: 0x198
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x4000953")]
	public Color medalNumGlow3; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x4000954")]
	[Tooltip("숫자 크기 = 뱃지 한 변 × 이 배율")]
	public float medalNumFontFrac; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Token(Token = "0x4000955")]
	[Tooltip("숫자 y 오프셋(뱃지 한 변 대비) — 메달리온 중심이 캔버스 중앙보다 살짝 아래")]
	public float medalNumOffsetY; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C0")]
	[Range(0, 1)]
	[Token(Token = "0x4000956")]
	[Tooltip("메달 뱃지 뒤 소프트 섀도 진하기(0=끔)")]
	public float medalShadowAlpha; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C4")]
	[Range(0, 1)]
	[Token(Token = "0x4000957")]
	[Tooltip("선물상자 바닥 접지 그림자 진하기(0=끔) — 상자 아래 깔리는 납작한 타원")]
	public float giftShadowAlpha; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x4000958")]
	[Tooltip("접지 그림자 폭 = 상자 크기 × 이 배율")]
	public float giftShadowWFrac; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1CC")]
	[Range(0.05, 0.6)]
	[Token(Token = "0x4000959")]
	[Tooltip("접지 그림자 높이 = 상자 크기 × 이 배율(납작하게)")]
	public float giftShadowHFrac; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Range(0, 0.8)]
	[Token(Token = "0x400095A")]
	[Tooltip("접지 그림자 y = 상자 중심에서 아래로 상자 크기 × 이 배율")]
	public float giftShadowDyFrac; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Range(0, 6)]
	[Token(Token = "0x400095B")]
	[Tooltip("포디움 선물상자 위 반짝임 개수(0=끔)")]
	public int giftSparkleCount; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x400095C")]
	public float giftSparkleSize; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Header("1위 단상 연출 (2026-08-19 — 스트릭 새싹 뒤 효과 이식)")]
	[Range(0, 1)]
	[Token(Token = "0x400095D")]
	[Tooltip("1위 아바타 뒤 후광 알파(0=끔) — 숨쉬듯 맥동. 노란 단상 위라 화이트 골드 + 높은 알파가 필요")]
	public float heroAuraAlpha; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x400095E")]
	[Tooltip("후광 지름 = 아바타 크기 × 이 배율 — 실린더 밖 배경까지 번져야 눈에 띈다")]
	public float heroAuraScale; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E4")]
	[Token(Token = "0x400095F")]
	public Color heroAuraColor; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1F4")]
	[Range(0, 12)]
	[Token(Token = "0x4000960")]
	[Tooltip("아바타 뒤에서 퐁퐁 떠오르는 빛 알갱이 개수(0=끔)")]
	public int heroMoteCount; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x4000961")]
	public float heroMoteRiseSeconds; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Range(0, 1)]
	[Token(Token = "0x4000962")]
	public float heroMoteAlpha; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x4000963")]
	[Tooltip("빛 알갱이 크기 = 아바타 크기 × 이 배율")]
	public float heroMoteSize; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Range(0, 6)]
	[Token(Token = "0x4000964")]
	[Tooltip("1위 메달 뱃지 주변 반짝임 개수(0=끔)")]
	public int medalSparkleCount; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x4000965")]
	public float medalSparkleSize; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Header("위클리 랭킹(왕관) 프레임 전용 반짝임")]
	[Range(0, 5)]
	[Token(Token = "0x4000966")]
	[Tooltip("왕관 주변 반짝임 개수(0=끔) — 왕관 프레임 착용자에게만 나온다")]
	public int crownSparkleCount; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x4000967")]
	[Tooltip("반짝임 크기 = 프레임 한 변 × 이 배율")]
	public float crownSparkleSizeFrac; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000968")]
	[Tooltip("왕관 중심에서 흩어지는 반경 = 프레임 한 변 × 이 배율")]
	public float crownSparkleSpreadFrac; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Header("포디움 꽃잎 휘날림 (UI/Ranking/petal)")]
	[Range(0, 20)]
	[Token(Token = "0x4000969")]
	public int petalCount; //Field offset: 0x218
	[FieldOffset(Offset = "0x21C")]
	[Token(Token = "0x400096A")]
	public float petalSize; //Field offset: 0x21C
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x400096B")]
	[Tooltip("낙하 시작 y(컬럼 중앙 기준) — 화면 위쪽")]
	public float petalTopY; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x400096C")]
	[Tooltip("낙하 끝 y(컬럼 중앙 기준) — 리스트 위에서 사라짐")]
	public float petalBottomY; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x400096D")]
	[Tooltip("낙하 시간 범위(초) — 꽃잎마다 랜덤. 천천히")]
	public Vector2 petalFallDur; //Field offset: 0x228
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x400096E")]
	[Tooltip("좌우 흔들림 폭(px)")]
	public float petalSwayX; //Field offset: 0x230
	[FieldOffset(Offset = "0x234")]
	[Range(0, 1)]
	[Token(Token = "0x400096F")]
	public float petalAlpha; //Field offset: 0x234
	[FieldOffset(Offset = "0x238")]
	[Header("메달 폴백 원반색(에셋 없을 때)")]
	[Token(Token = "0x4000970")]
	public Color medalCol1; //Field offset: 0x238
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x4000971")]
	public Color medalCol2; //Field offset: 0x248
	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x4000972")]
	public Color medalCol3; //Field offset: 0x258
	[FieldOffset(Offset = "0x268")]
	[Header("리스트 (1~50위 전량)")]
	[Token(Token = "0x4000973")]
	[Tooltip("리스트 패널(스크롤 배경) 색")]
	public Color listPanelColor; //Field offset: 0x268
	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x4000974")]
	[Tooltip("뷰포트 상단 y(컬럼 중앙 기준)")]
	public float listTopY; //Field offset: 0x278
	[FieldOffset(Offset = "0x27C")]
	[Token(Token = "0x4000975")]
	[Tooltip("뷰포트 하단 y(컬럼 중앙 기준)")]
	public float listBottomY; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x4000976")]
	public float listW; //Field offset: 0x280
	[FieldOffset(Offset = "0x284")]
	[Token(Token = "0x4000977")]
	public float rowH; //Field offset: 0x284
	[FieldOffset(Offset = "0x288")]
	[Token(Token = "0x4000978")]
	public float rowGap; //Field offset: 0x288
	[FieldOffset(Offset = "0x28C")]
	[Token(Token = "0x4000979")]
	[Tooltip("리스트 패널 안쪽 좌우 여백")]
	public float listSidePad; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x400097A")]
	public float rowAvatarSize; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Token(Token = "0x400097B")]
	public float rowRankFontSize; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x400097C")]
	public float rowMedalSize; //Field offset: 0x298
	[FieldOffset(Offset = "0x29C")]
	[Token(Token = "0x400097D")]
	public float rowNameFontSize; //Field offset: 0x29C
	[FieldOffset(Offset = "0x2A0")]
	[Token(Token = "0x400097E")]
	public Vector2 rowPillSize; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A8")]
	[Token(Token = "0x400097F")]
	public float rowPillFontSize; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Token(Token = "0x4000980")]
	[Tooltip("Top3 행 우측 선물상자 크기(0=끔). 일반 행도 같은 폭을 비워 pill 정렬 유지")]
	public float rowGiftSize; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Token(Token = "0x4000981")]
	[Tooltip("pill 왼쪽 에지 ~ 씨앗 아이콘 사이 여백(px)")]
	public float pillIconPadLeft; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Range(0, 1)]
	[Token(Token = "0x4000982")]
	[Tooltip("씨앗 pill 뒤 소프트 섀도 진하기(0=끔) — 포디움/리스트 공용")]
	public float pillShadowAlpha; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Range(0, 1)]
	[Token(Token = "0x4000983")]
	[Tooltip("플로팅 내 랭킹 카드(하단 고정) 아웃 글로우 진하기 — 떠 있는 느낌")]
	public float mePinShadowAlpha; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Range(4, 40)]
	[Token(Token = "0x4000984")]
	[Tooltip("플로팅 카드 아웃 글로우 번짐 범위(px)")]
	public float mePinShadowGrow; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2C0")]
	[Token(Token = "0x4000985")]
	public Color rowColor; //Field offset: 0x2C0
	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x4000986")]
	public Color rowMeColor; //Field offset: 0x2D0
	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x4000987")]
	public Color rowGoldColor; //Field offset: 0x2E0
	[FieldOffset(Offset = "0x2F0")]
	[Token(Token = "0x4000988")]
	public Color rowSilverColor; //Field offset: 0x2F0
	[FieldOffset(Offset = "0x300")]
	[Token(Token = "0x4000989")]
	public Color rowBronzeColor; //Field offset: 0x300
	[FieldOffset(Offset = "0x310")]
	[Token(Token = "0x400098A")]
	public Color textColor; //Field offset: 0x310
	[FieldOffset(Offset = "0x320")]
	[Range(0, 1)]
	[Token(Token = "0x400098B")]
	[Tooltip("아바타/프레임 뒤 앰비언트 섀도 진하기(0=끔)")]
	public float avatarShadowAlpha; //Field offset: 0x320
	[FieldOffset(Offset = "0x324")]
	[Range(0, 60)]
	[Token(Token = "0x400098C")]
	public float avatarShadowSpread; //Field offset: 0x324
	[FieldOffset(Offset = "0x328")]
	[Range(-40, 0)]
	[Token(Token = "0x400098D")]
	public float avatarShadowOffsetY; //Field offset: 0x328
	[FieldOffset(Offset = "0x32C")]
	[Header("CTA (수집하러 가기)")]
	[Token(Token = "0x400098E")]
	public Vector2 ctaSize; //Field offset: 0x32C
	[FieldOffset(Offset = "0x334")]
	[Token(Token = "0x400098F")]
	public float ctaY; //Field offset: 0x334
	[FieldOffset(Offset = "0x338")]
	[Token(Token = "0x4000990")]
	public float ctaFontSize; //Field offset: 0x338
	[FieldOffset(Offset = "0x33C")]
	[Token(Token = "0x4000991")]
	[Tooltip("btn_pill_cream에 곱하는 틴트(2026-08-19) — 크림 판은 밝아서 곱셈 틴트가 살아난다. 시안 톤 = 소프트 오렌지")]
	public Color ctaTint; //Field offset: 0x33C
	[FieldOffset(Offset = "0x34C")]
	[Token(Token = "0x4000992")]
	[Tooltip("라벨 글로우(흰 글자 뒤 어두운 외곽) 색")]
	public Color ctaLabelGlow; //Field offset: 0x34C
	[FieldOffset(Offset = "0x35C")]
	[Range(0, 1)]
	[Token(Token = "0x4000993")]
	public float ctaShadowAlpha; //Field offset: 0x35C
	[FieldOffset(Offset = "0x360")]
	[Token(Token = "0x4000994")]
	public float ctaShadowSpread; //Field offset: 0x360
	[FieldOffset(Offset = "0x364")]
	[Range(1, 8)]
	[Token(Token = "0x4000995")]
	public int ctaShadowLayers; //Field offset: 0x364
	[FieldOffset(Offset = "0x368")]
	[Token(Token = "0x4000996")]
	public Vector2 ctaShadowOffset; //Field offset: 0x368
	[FieldOffset(Offset = "0x370")]
	[Header("새 시즌 알림 팝업 (SeasonStartPopup, 2026-08-20)")]
	[Token(Token = "0x4000997")]
	[Tooltip("패널 크기(폭×높이)")]
	public Vector2 seasonPanelSize; //Field offset: 0x370
	[FieldOffset(Offset = "0x378")]
	[Token(Token = "0x4000998")]
	public float seasonTitleY; //Field offset: 0x378
	[FieldOffset(Offset = "0x37C")]
	[Token(Token = "0x4000999")]
	public float seasonTitleFontSize; //Field offset: 0x37C
	[FieldOffset(Offset = "0x380")]
	[Token(Token = "0x400099A")]
	public Color seasonTitleColor; //Field offset: 0x380
	[FieldOffset(Offset = "0x390")]
	[Token(Token = "0x400099B")]
	[Tooltip("히어로(포디움+햄스터) 액자 크기/위치 — 액자 배경색은 seasonHeroBgColor")]
	public Vector2 seasonHeroSize; //Field offset: 0x390
	[FieldOffset(Offset = "0x398")]
	[Token(Token = "0x400099C")]
	public float seasonHeroY; //Field offset: 0x398
	[FieldOffset(Offset = "0x39C")]
	[Token(Token = "0x400099D")]
	public Color seasonHeroBgColor; //Field offset: 0x39C
	[FieldOffset(Offset = "0x3AC")]
	[Token(Token = "0x400099E")]
	[Tooltip("판 9-slice 배율 — 설정창과 같은 값(0.6)이 기본. 크면 모서리 반경이 작아진다")]
	public float seasonPanelPpum; //Field offset: 0x3AC
	[FieldOffset(Offset = "0x3B0")]
	[Token(Token = "0x400099F")]
	[Tooltip("히어로 액자 9-slice 배율 — 설정창 내부 판과 같은 값(0.7)")]
	public float seasonHeroPpum; //Field offset: 0x3B0
	[FieldOffset(Offset = "0x3B4")]
	[Token(Token = "0x40009A0")]
	[Tooltip("액자 안 포디움 폭(px). 높이는 원본 비율. 액자 밖으로 나간 부분은 잘린다")]
	public float seasonPodiumW; //Field offset: 0x3B4
	[FieldOffset(Offset = "0x3B8")]
	[Token(Token = "0x40009A1")]
	[Tooltip("포디움 중심 y(액자 중심 기준, 음수=아래). 키워서 내리면 아래가 액자에 잘려 무대처럼 보인다")]
	public float seasonPodiumDy; //Field offset: 0x3B8
	[FieldOffset(Offset = "0x3BC")]
	[Range(0.3, 2)]
	[Token(Token = "0x40009A2")]
	[Tooltip("메달 뱃지 크기 배율 — 포디움 폭 비율로 환산한 값에 추가로 곱한다(1=랭킹 페이지와 같은 비례)")]
	public float seasonMedalScale; //Field offset: 0x3BC
	[FieldOffset(Offset = "0x3C0")]
	[Token(Token = "0x40009A3")]
	[Tooltip("액자 배경(무대 커튼) 스프라이트 경로. 비우면 배경 없이 판 색만 보인다")]
	public string seasonBgSpritePath; //Field offset: 0x3C0
	[FieldOffset(Offset = "0x3C8")]
	[Range(1, 2)]
	[Token(Token = "0x40009A4")]
	[Tooltip("배경 추가 확대 배율(1=액자를 딱 덮음). 키우면 확대되고 밖은 잘린다")]
	public float seasonBgScale; //Field offset: 0x3C8
	[FieldOffset(Offset = "0x3CC")]
	[Token(Token = "0x40009A5")]
	[Tooltip("배경 위치 보정(px) — 커튼 주름/장식이 보이는 지점을 맞춘다")]
	public Vector2 seasonBgOffset; //Field offset: 0x3CC
	[FieldOffset(Offset = "0x3D4")]
	[Token(Token = "0x40009A6")]
	public Color seasonBgTint; //Field offset: 0x3D4
	[FieldOffset(Offset = "0x3E4")]
	[Token(Token = "0x40009A7")]
	[Tooltip("액자 클립 여백(px) — 0이면 액자를 꽉 채운다. 판 테두리 선을 남기려면 6~10")]
	public float seasonHeroClipPad; //Field offset: 0x3E4
	[FieldOffset(Offset = "0x3E8")]
	[Range(0.4, 2)]
	[Token(Token = "0x40009A8")]
	[Tooltip("클립 모서리 반경 배율 — 1이면 액자 판과 같은 곡률. 귀퉁이가 남아 보이면 조금 낮춘다")]
	public float seasonHeroClipRadiusScale; //Field offset: 0x3E8
	[FieldOffset(Offset = "0x3F0")]
	[Token(Token = "0x40009A9")]
	[Tooltip("포디움 위에 올릴 햄스터 스프라이트 경로(Resources). 없으면 포디움만 나온다")]
	public string seasonHeroSpritePath; //Field offset: 0x3F0
	[FieldOffset(Offset = "0x3F8")]
	[Token(Token = "0x40009AA")]
	[Tooltip("햄스터 높이(px)와 중심 위치(액자 중심 기준)")]
	public float seasonHeroCharH; //Field offset: 0x3F8
	[FieldOffset(Offset = "0x3FC")]
	[Token(Token = "0x40009AB")]
	public Vector2 seasonHeroCharPos; //Field offset: 0x3FC
	[FieldOffset(Offset = "0x404")]
	[Range(0, 1)]
	[Token(Token = "0x40009AC")]
	[Tooltip("햄스터 뒤 원형 포커스 조명 진하기(0=끔) — 무대 조명이 주인공 한 명을 비추는 느낌")]
	public float seasonHeroFocusAlpha; //Field offset: 0x404
	[FieldOffset(Offset = "0x408")]
	[Token(Token = "0x40009AD")]
	[Tooltip("포커스 조명 지름 = 캐릭터 키 × 이 배율(x=가로, y=세로)")]
	public Vector2 seasonHeroFocusScale; //Field offset: 0x408
	[FieldOffset(Offset = "0x410")]
	[Token(Token = "0x40009AE")]
	[Tooltip("포커스 조명 중심 = 캐릭터 위치 + 이 오프셋")]
	public Vector2 seasonHeroFocusOffset; //Field offset: 0x410
	[FieldOffset(Offset = "0x418")]
	[Token(Token = "0x40009AF")]
	public Color seasonHeroFocusColor; //Field offset: 0x418
	[FieldOffset(Offset = "0x428")]
	[Range(0, 1)]
	[Token(Token = "0x40009B0")]
	[Tooltip("햄스터 발밑 바닥 그림자 진하기(0=끔) — 랭킹 카드 밑 그림자와 같은 소프트 타원")]
	public float seasonHeroShadowAlpha; //Field offset: 0x428
	[FieldOffset(Offset = "0x42C")]
	[Token(Token = "0x40009B1")]
	[Tooltip("바닥 그림자 크기 = 캐릭터 폭 × x, 캐릭터 키 × y")]
	public Vector2 seasonHeroShadowScale; //Field offset: 0x42C
	[FieldOffset(Offset = "0x434")]
	[Token(Token = "0x40009B2")]
	[Tooltip("발밑에서 더 내릴 거리(px) — 그림자가 발을 덮으면 키운다")]
	public float seasonHeroShadowDy; //Field offset: 0x434
	[FieldOffset(Offset = "0x438")]
	[Token(Token = "0x40009B3")]
	public Color seasonHeroShadowColor; //Field offset: 0x438
	[FieldOffset(Offset = "0x448")]
	[Range(0, 12)]
	[Token(Token = "0x40009B4")]
	[Tooltip("햄스터 목걸이(해바라기 메달) 반짝임 개수(0=끔)")]
	public int seasonHeroSparkleCount; //Field offset: 0x448
	[FieldOffset(Offset = "0x44C")]
	[Token(Token = "0x40009B5")]
	[Tooltip("반짝임 중심 — 캐릭터 스프라이트 정규화 좌표(좌상단 기준). 아트 교체 시 재측정")]
	public Vector2 seasonHeroSparkleAnchor; //Field offset: 0x44C
	[FieldOffset(Offset = "0x454")]
	[Token(Token = "0x40009B6")]
	[Tooltip("아래 px 값들을 맞춰 둔 기준 캐릭터 키. seasonHeroCharH가 이 값과 다르면 오프셋·별·반짝이 크기가 그 비율로 함께 스케일된다(포디움 메달의 kp와 같은 방식)")]
	public float seasonHeroSparkleRefH; //Field offset: 0x454
	[FieldOffset(Offset = "0x458")]
	[Token(Token = "0x40009B7")]
	[Tooltip("메달 중심에서 비켜 세울 거리(px) — 정중앙에서 반짝이면 메달이 가린다. 기본 = 오른쪽 위 대각선")]
	public Vector2 seasonHeroSparkleOffset; //Field offset: 0x458
	[FieldOffset(Offset = "0x460")]
	[Token(Token = "0x40009B8")]
	[Tooltip("반짝임이 도는 영역 지름 = 캐릭터 키 × 이 배율")]
	public float seasonHeroSparkleArea; //Field offset: 0x460
	[FieldOffset(Offset = "0x464")]
	[Range(0, 0.95)]
	[Token(Token = "0x40009B9")]
	[Tooltip("도넛 안쪽 반경 비율 — 0이면 중심까지 반짝인다. 올리면 가운데가 비어 뒤가 보인다")]
	public float seasonHeroSparkleInner; //Field offset: 0x464
	[FieldOffset(Offset = "0x468")]
	[Token(Token = "0x40009BA")]
	[Tooltip("반짝이 한 개 크기 범위(px)")]
	public Vector2 seasonHeroSparkleSize; //Field offset: 0x468
	[FieldOffset(Offset = "0x470")]
	[Token(Token = "0x40009BB")]
	public Color seasonHeroSparkleColor; //Field offset: 0x470
	[FieldOffset(Offset = "0x480")]
	[Token(Token = "0x40009BC")]
	[Tooltip("한 번 반짝인 뒤 쉬는 시간 범위(초) — 짧게 줄이면 훨씬 촘촘하게 반짝인다")]
	public Vector2 seasonHeroSparkleRest; //Field offset: 0x480
	[FieldOffset(Offset = "0x488")]
	[Token(Token = "0x40009BD")]
	[Tooltip("최대 밝기에서 머무는 시간 범위(초)")]
	public Vector2 seasonHeroSparkleHold; //Field offset: 0x488
	[FieldOffset(Offset = "0x490")]
	[Range(0, 1)]
	[Token(Token = "0x40009BE")]
	[Tooltip("메달 위 후광 진하기(0=끔) — 반짝이만으론 작아서 눈에 안 걸린다")]
	public float seasonHeroSparkleGlowAlpha; //Field offset: 0x490
	[FieldOffset(Offset = "0x494")]
	[Token(Token = "0x40009BF")]
	[Tooltip("후광 지름 = 반짝임 영역 × 이 배율")]
	public float seasonHeroSparkleGlowScale; //Field offset: 0x494
	[FieldOffset(Offset = "0x498")]
	[Token(Token = "0x40009C0")]
	[Tooltip("메달 정중앙에 상시 켜 두는 별 크기(px, 0=끔) — 깜빡임이 비는 순간을 메운다")]
	public float seasonHeroSparkleStarSize; //Field offset: 0x498
	[FieldOffset(Offset = "0x49C")]
	[Token(Token = "0x40009C1")]
	public Vector2 seasonHeroSparkleStarOffset; //Field offset: 0x49C
	[FieldOffset(Offset = "0x4A4")]
	[Range(0, 40)]
	[Token(Token = "0x40009C2")]
	[Tooltip("액자 안에 떨어지는 색종이 가루 개수(0=끔)")]
	public int seasonPaperCount; //Field offset: 0x4A4
	[FieldOffset(Offset = "0x4A8")]
	[Token(Token = "0x40009C3")]
	[Tooltip("색종이 한 조각 긴 변(px) — 개별은 0.7~1.25배 랜덤")]
	public float seasonPaperSize; //Field offset: 0x4A8
	[FieldOffset(Offset = "0x4AC")]
	[Token(Token = "0x40009C4")]
	[Tooltip("낙하 시간 범위(초, 최소~최대) — 꽃잎보다 짧게 두면 가루답게 빠르다")]
	public Vector2 seasonPaperFallDur; //Field offset: 0x4AC
	[FieldOffset(Offset = "0x4B4")]
	[Token(Token = "0x40009C5")]
	[Tooltip("좌우 흔들림 폭(px)")]
	public float seasonPaperSwayX; //Field offset: 0x4B4
	[FieldOffset(Offset = "0x4B8")]
	[Range(0, 1)]
	[Token(Token = "0x40009C6")]
	public float seasonPaperAlpha; //Field offset: 0x4B8
	[FieldOffset(Offset = "0x4BC")]
	[Token(Token = "0x40009C7")]
	[Tooltip("액자 상단 타이머 캡슐 — 시즌 남은 시간(0이면 숨김)")]
	public float seasonTimerHeight; //Field offset: 0x4BC
	[FieldOffset(Offset = "0x4C0")]
	[Token(Token = "0x40009C8")]
	public float seasonTimerDy; //Field offset: 0x4C0
	[FieldOffset(Offset = "0x4C4")]
	[Token(Token = "0x40009C9")]
	[Tooltip("설명 문구 위치/크기")]
	public float seasonDescY; //Field offset: 0x4C4
	[FieldOffset(Offset = "0x4C8")]
	[Token(Token = "0x40009CA")]
	public float seasonDescFontSize; //Field offset: 0x4C8
	[FieldOffset(Offset = "0x4CC")]
	[Token(Token = "0x40009CB")]
	public Vector2 seasonDescSize; //Field offset: 0x4CC
	[FieldOffset(Offset = "0x4D4")]
	[Token(Token = "0x40009CC")]
	public Color seasonDescColor; //Field offset: 0x4D4
	[FieldOffset(Offset = "0x4E4")]
	[Range(0, 2)]
	[Token(Token = "0x40009CD")]
	[Tooltip("문구 앞 씨앗 아이콘 크기 = 글자 크기 × 이 배율(0=아이콘 끔)")]
	public float seasonDescIconScale; //Field offset: 0x4E4
	[FieldOffset(Offset = "0x4E8")]
	[Range(0, 1)]
	[Token(Token = "0x40009CE")]
	[Tooltip("아이콘과 글자 사이 여백 = 글자 크기 × 이 배율")]
	public float seasonDescIconGap; //Field offset: 0x4E8
	[FieldOffset(Offset = "0x4EC")]
	[Range(-0.5, 0.5)]
	[Token(Token = "0x40009CF")]
	[Tooltip("아이콘 y 미세 조정 = 아이콘 크기 × 이 배율(글자 중심선과 눈높이 맞추기)")]
	public float seasonDescIconDy; //Field offset: 0x4EC
	[FieldOffset(Offset = "0x4F0")]
	[Range(-30, 40)]
	[Token(Token = "0x40009D0")]
	[Tooltip("줄 간격(TMP lineSpacing, %) — 2줄 문구가 답답하면 8~15 정도로 벌린다")]
	public float seasonDescLineSpacing; //Field offset: 0x4F0
	[FieldOffset(Offset = "0x4F4")]
	[Token(Token = "0x40009D1")]
	[Tooltip("확인 버튼 — 리더보드 CTA와 같은 알약 + 오렌지 틴트")]
	public Vector2 seasonBtnSize; //Field offset: 0x4F4
	[FieldOffset(Offset = "0x4FC")]
	[Token(Token = "0x40009D2")]
	public float seasonBtnY; //Field offset: 0x4FC
	[FieldOffset(Offset = "0x500")]
	[Token(Token = "0x40009D3")]
	public float seasonBtnFontSize; //Field offset: 0x500
	[FieldOffset(Offset = "0x504")]
	[Range(0, 1)]
	[Token(Token = "0x40009D4")]
	[Tooltip("확인 버튼 아래 소프트 섀도 진하기(0=끔) — 알약 실루엣을 여러 겹으로 번지게 한다")]
	public float seasonBtnShadowAlpha; //Field offset: 0x504
	[FieldOffset(Offset = "0x508")]
	[Token(Token = "0x40009D5")]
	public float seasonBtnShadowSpread; //Field offset: 0x508
	[FieldOffset(Offset = "0x50C")]
	[Range(1, 8)]
	[Token(Token = "0x40009D6")]
	public int seasonBtnShadowLayers; //Field offset: 0x50C
	[FieldOffset(Offset = "0x510")]
	[Token(Token = "0x40009D7")]
	public Vector2 seasonBtnShadowOffset; //Field offset: 0x510
	[FieldOffset(Offset = "0x518")]
	[Range(0, 16)]
	[Token(Token = "0x40009D8")]
	[Tooltip("액자 안 꽃가루/반짝임 개수(0=끔)")]
	public int seasonConfettiCount; //Field offset: 0x518
	[FieldOffset(Offset = "0x51C")]
	[Range(0, 1)]
	[Token(Token = "0x40009D9")]
	[Tooltip("단상 위 스포트라이트(원뿔 빛) 진하기(0=끔)")]
	public float seasonSpotlightAlpha; //Field offset: 0x51C
	[FieldOffset(Offset = "0x520")]
	[Token(Token = "0x40009DA")]
	[Tooltip("스포트라이트 폭/높이 = 액자 크기 × 이 배율. 꼭대기는 액자 위쪽 밖에서 시작한다")]
	public Vector2 seasonSpotlightScale; //Field offset: 0x520
	[FieldOffset(Offset = "0x528")]
	[Token(Token = "0x40009DB")]
	public Vector2 seasonSpotlightOffset; //Field offset: 0x528
	[FieldOffset(Offset = "0x530")]
	[Token(Token = "0x40009DC")]
	public Color seasonSpotlightColor; //Field offset: 0x530
	[FieldOffset(Offset = "0x540")]
	[Range(0, 20)]
	[Token(Token = "0x40009DD")]
	[Tooltip("액자 안에서 흩날리는 꽃잎 개수(0=끔)")]
	public int seasonPetalCount; //Field offset: 0x540
	[FieldOffset(Offset = "0x544")]
	[Token(Token = "0x40009DE")]
	[Tooltip("꽃잎 한 장 크기(px) — 개별은 0.7~1.3배 랜덤")]
	public float seasonPetalSize; //Field offset: 0x544
	[FieldOffset(Offset = "0x548")]
	[Token(Token = "0x40009DF")]
	[Tooltip("낙하 시간 범위(초, 최소~최대)")]
	public Vector2 seasonPetalFallDur; //Field offset: 0x548
	[FieldOffset(Offset = "0x550")]
	[Token(Token = "0x40009E0")]
	[Tooltip("좌우 흔들림 폭(px)")]
	public float seasonPetalSwayX; //Field offset: 0x550
	[FieldOffset(Offset = "0x554")]
	[Range(0, 1)]
	[Token(Token = "0x40009E1")]
	public float seasonPetalAlpha; //Field offset: 0x554
	[FieldOffset(Offset = "0x558")]
	[Header("주간 보상 수령 창 (RankRewardPopup)")]
	[Token(Token = "0x40009E2")]
	public float rewardTitleY; //Field offset: 0x558
	[FieldOffset(Offset = "0x55C")]
	[Token(Token = "0x40009E3")]
	public float rewardTitleFontSize; //Field offset: 0x55C
	[FieldOffset(Offset = "0x560")]
	[Range(0.3, 1)]
	[Token(Token = "0x40009E4")]
	[Tooltip("제목 둘째 줄(설명)의 크기 — 첫 줄 대비 비율")]
	public float rewardTitleSubScale; //Field offset: 0x560
	[FieldOffset(Offset = "0x564")]
	[Range(0, 1)]
	[Token(Token = "0x40009E5")]
	[Tooltip("제목 두 줄 사이 여백 — 첫 줄 대비 비율. 키우면 두 줄이 멀어진다")]
	public float rewardTitleLineGap; //Field offset: 0x564
	[FieldOffset(Offset = "0x568")]
	[Range(0.3, 2)]
	[Token(Token = "0x40009E6")]
	[Tooltip("제목 끝에 붙는 작은 그림(하트)의 크기 — 그 줄 높이 대비 배수")]
	public float rewardTitleIconScale; //Field offset: 0x568
	[FieldOffset(Offset = "0x56C")]
	[Token(Token = "0x40009E7")]
	public Color rewardTitleColor; //Field offset: 0x56C
	[FieldOffset(Offset = "0x57C")]
	[Token(Token = "0x40009E8")]
	[Tooltip("타이틀 아웃 글로우(0 알파면 끔)")]
	public Color rewardTitleGlow; //Field offset: 0x57C
	[FieldOffset(Offset = "0x58C")]
	[Token(Token = "0x40009E9")]
	[Tooltip("타이틀 안 숫자(1위 횟수 / 순위)만 다른 색으로 강조 — 알파 0이면 타이틀 색을 그대로 쓴다")]
	public Color rewardTitleNumColor; //Field offset: 0x58C
	[FieldOffset(Offset = "0x59C")]
	[Header("수령 후 레벨 버튼 반짝임")]
	[Range(0, 24)]
	[Token(Token = "0x40009EA")]
	[Tooltip("한 물결에 뜨는 별 개수(0=끔)")]
	public int shimmerCount; //Field offset: 0x59C
	[FieldOffset(Offset = "0x5A0")]
	[Range(1, 8)]
	[Token(Token = "0x40009EB")]
	[Tooltip("물결 반복 횟수 — 여러 번 겹쳐야 '연속으로 반짝'인다")]
	public int shimmerWaves; //Field offset: 0x5A0
	[FieldOffset(Offset = "0x5A4")]
	[Token(Token = "0x40009EC")]
	[Tooltip("물결 간격(초)")]
	public float shimmerWaveGap; //Field offset: 0x5A4
	[FieldOffset(Offset = "0x5A8")]
	[Token(Token = "0x40009ED")]
	[Tooltip("별 한 개 크기(px, 최소~최대 사이 랜덤)")]
	public Vector2 shimmerSize; //Field offset: 0x5A8
	[FieldOffset(Offset = "0x5B0")]
	[Token(Token = "0x40009EE")]
	[Tooltip("퍼지는 범위 = 버튼 크기 × 배율(가로/세로 각각)")]
	public Vector2 shimmerSpread; //Field offset: 0x5B0
	[FieldOffset(Offset = "0x5B8")]
	[Token(Token = "0x40009EF")]
	public Color shimmerColor; //Field offset: 0x5B8
	[FieldOffset(Offset = "0x5C8")]
	[Range(0, 1)]
	[Token(Token = "0x40009F0")]
	[Tooltip("버튼 뒤 후광 세기(0=끔) / 크기 = 버튼 폭 × 배율")]
	public float shimmerGlowAlpha; //Field offset: 0x5C8
	[FieldOffset(Offset = "0x5CC")]
	[Token(Token = "0x40009F1")]
	public float shimmerGlowScale; //Field offset: 0x5CC
	[FieldOffset(Offset = "0x5D0")]
	[Token(Token = "0x40009F2")]
	[Tooltip("상자 히어로 크기/위치")]
	public float rewardHeroSize; //Field offset: 0x5D0
	[FieldOffset(Offset = "0x5D4")]
	[Token(Token = "0x40009F3")]
	public float rewardHeroY; //Field offset: 0x5D4
	[FieldOffset(Offset = "0x5D8")]
	[Token(Token = "0x40009F4")]
	[Tooltip("히어로 뒤 후광/빛살 크기 = 히어로 크기 × 배율")]
	public float rewardGlowScale; //Field offset: 0x5D8
	[FieldOffset(Offset = "0x5DC")]
	[Token(Token = "0x40009F5")]
	public float rewardRayScale; //Field offset: 0x5DC
	[FieldOffset(Offset = "0x5E0")]
	[Range(0, 12)]
	[Token(Token = "0x40009F6")]
	[Tooltip("상자 주변 반짝임 개수(0=끔)")]
	public int rewardHeroSparkleCount; //Field offset: 0x5E0
	[FieldOffset(Offset = "0x5E4")]
	[Range(0.03, 0.4)]
	[Token(Token = "0x40009F7")]
	[Tooltip("반짝임 한 개 크기 = 히어로 크기 × 배율")]
	public float rewardHeroSparkleSizeFrac; //Field offset: 0x5E4
	[FieldOffset(Offset = "0x5E8")]
	[Range(0.6, 2)]
	[Token(Token = "0x40009F8")]
	[Tooltip("반짝임이 도는 범위 = 히어로 크기 × 배율(1보다 크면 상자 밖까지)")]
	public float rewardHeroSparkleSpread; //Field offset: 0x5E8
	[FieldOffset(Offset = "0x5EC")]
	[Range(0, 0.9)]
	[Token(Token = "0x40009F9")]
	[Tooltip("반짝임 안쪽 여백 비율 — 0.55면 상자 중앙은 비우고 가장자리~바깥에서만 반짝인다")]
	public float rewardHeroSparkleInner; //Field offset: 0x5EC
	[FieldOffset(Offset = "0x5F0")]
	[Token(Token = "0x40009FA")]
	public Color rewardHeroSparkleColor; //Field offset: 0x5F0
	[FieldOffset(Offset = "0x600")]
	[Token(Token = "0x40009FB")]
	[Tooltip("보상 셀(아이콘+수량) 간격/아이콘 크기/수량 글자 크기")]
	public float rewardCellGap; //Field offset: 0x600
	[FieldOffset(Offset = "0x604")]
	[Token(Token = "0x40009FC")]
	public float rewardCellY; //Field offset: 0x604
	[FieldOffset(Offset = "0x608")]
	[Token(Token = "0x40009FD")]
	public float rewardIconSize; //Field offset: 0x608
	[FieldOffset(Offset = "0x60C")]
	[Token(Token = "0x40009FE")]
	[Tooltip("보상 아이콘 뒤 후광의 색과 진하기(알파). 아이콘보다 흰빛이어야 아이콘이 또렷하다")]
	public Color rewardCellGlowColor; //Field offset: 0x60C
	[FieldOffset(Offset = "0x61C")]
	[Range(120, 500)]
	[Token(Token = "0x40009FF")]
	[Tooltip("그 후광의 크기(px)")]
	public float rewardCellGlowSize; //Field offset: 0x61C
	[FieldOffset(Offset = "0x620")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000A00")]
	[Tooltip("후광이 숨쉬듯 커졌다 작아지는 폭(배수). 0이면 일렁이지 않는다")]
	public float rewardCellGlowPulse; //Field offset: 0x620
	[FieldOffset(Offset = "0x624")]
	[Range(0.3, 4)]
	[Token(Token = "0x4000A01")]
	[Tooltip("그 일렁임 한 번에 걸리는 시간(초)")]
	public float rewardCellGlowPulseDur; //Field offset: 0x624
	[FieldOffset(Offset = "0x628")]
	[Token(Token = "0x4000A02")]
	public float rewardAmountFontSize; //Field offset: 0x628
	[FieldOffset(Offset = "0x62C")]
	[Token(Token = "0x4000A03")]
	public Color rewardAmountColor; //Field offset: 0x62C
	[FieldOffset(Offset = "0x63C")]
	[Header("주간 보상 창 — 버튼")]
	[Token(Token = "0x4000A04")]
	[Tooltip("버튼 크기(폭×높이)")]
	public Vector2 rewardBtnSize; //Field offset: 0x63C
	[FieldOffset(Offset = "0x644")]
	[Token(Token = "0x4000A05")]
	[Tooltip("1단계 '받기' 버튼 y")]
	public float rewardBtn1Y; //Field offset: 0x644
	[FieldOffset(Offset = "0x648")]
	[Token(Token = "0x4000A06")]
	[Tooltip("2단계 첫 버튼('2배로 받기') y — 광고 미준비 시엔 '받기'가 이 자리에 온다")]
	public float rewardBtnX2Y; //Field offset: 0x648
	[FieldOffset(Offset = "0x64C")]
	[Range(0, 200)]
	[Token(Token = "0x4000A07")]
	[Tooltip("두 버튼 사이 간격(px) — 아래 버튼 y는 이 간격으로 자동 계산된다")]
	public float rewardBtnGap; //Field offset: 0x64C
	[FieldOffset(Offset = "0x650")]
	[Token(Token = "0x4000A08")]
	public float rewardBtnFontSize; //Field offset: 0x650
	[FieldOffset(Offset = "0x654")]
	[Token(Token = "0x4000A09")]
	[Tooltip("btn_pill_cream에 곱하는 틴트(리더보드 CTA와 같은 소프트 오렌지)")]
	public Color rewardBtnTint; //Field offset: 0x654
	[FieldOffset(Offset = "0x664")]
	[Token(Token = "0x4000A0A")]
	[Tooltip("보조 버튼(기본 받기) 틴트 — 2배 버튼과 구분되는 밝은 톤")]
	public Color rewardBtnTintAlt; //Field offset: 0x664
	[FieldOffset(Offset = "0x674")]
	[Token(Token = "0x4000A0B")]
	public Color rewardBtnLabelColor; //Field offset: 0x674
	[FieldOffset(Offset = "0x684")]
	[Token(Token = "0x4000A0C")]
	[Tooltip("보조 버튼 라벨 색")]
	public Color rewardBtnLabelColorAlt; //Field offset: 0x684
	[FieldOffset(Offset = "0x694")]
	[Token(Token = "0x4000A0D")]
	[Tooltip("버튼 라벨 글로우(알파 0이면 끔)")]
	public Color rewardBtnLabelGlow; //Field offset: 0x694
	[FieldOffset(Offset = "0x6A4")]
	[Token(Token = "0x4000A0E")]
	[Tooltip("2단계 버튼 크기 — 0이면 rewardBtnSize를 그대로 쓴다")]
	public Vector2 rewardBtnX2Size; //Field offset: 0x6A4
	[FieldOffset(Offset = "0x6AC")]
	[Token(Token = "0x4000A0F")]
	public Vector2 rewardBtn2Size; //Field offset: 0x6AC
	[FieldOffset(Offset = "0x6B4")]
	[Token(Token = "0x4000A10")]
	[Tooltip("AD 뱃지 크기")]
	public Vector2 rewardAdBadgeSize; //Field offset: 0x6B4
	[FieldOffset(Offset = "0x6BC")]
	[Token(Token = "0x4000A11")]
	[Tooltip("AD 뱃지 위치 — 버튼 우상단 기준 오프셋(px)")]
	public Vector2 rewardAdBadgeOffset; //Field offset: 0x6BC
	[FieldOffset(Offset = "0x6C4")]
	[Header("진입 연출 (로딩 은폐 + 프로필 낙하 → 카드 차르륵)")]
	[Range(0, 2)]
	[Token(Token = "0x4000A12")]
	[Tooltip("데이터를 기다리는 동안 스피너를 띄우기까지의 유예(초). 이 안에 도착하면 로딩은 아예 보이지 않는다")]
	public float openLoadGrace; //Field offset: 0x6C4
	[FieldOffset(Offset = "0x6C8")]
	[Range(0, 300)]
	[Token(Token = "0x4000A13")]
	[Tooltip("직전 조회 스냅샷을 재사용하는 시간(초, 0=끔). 클리어 흐름에서 이미 받아 둔 보드를 그대로 열어 로딩이 사라진다")]
	public float openCacheSeconds; //Field offset: 0x6C8
	[FieldOffset(Offset = "0x6CC")]
	[Range(0, 1)]
	[Token(Token = "0x4000A14")]
	[Tooltip("배경(로비 덮개) 페이드 인 시간(초). 0=즉시")]
	public float openBgFade; //Field offset: 0x6CC
	[FieldOffset(Offset = "0x6D0")]
	[Token(Token = "0x4000A15")]
	[Tooltip("헤더(리본/타이틀/타이머)가 위에서 떨어지는 거리(px) / 시간 / 지연(초)")]
	public float openHeadDrop; //Field offset: 0x6D0
	[FieldOffset(Offset = "0x6D4")]
	[Token(Token = "0x4000A16")]
	public float openHeadDur; //Field offset: 0x6D4
	[FieldOffset(Offset = "0x6D8")]
	[Token(Token = "0x4000A17")]
	public float openHeadDelay; //Field offset: 0x6D8
	[FieldOffset(Offset = "0x6DC")]
	[Token(Token = "0x4000A18")]
	[Tooltip("포디움 바닥(단상+메달 뱃지+상자)은 움직이지 않고 자리에 있다 — 페이드 인 시간 / 지연(초)")]
	public float openPodiumDur; //Field offset: 0x6DC
	[FieldOffset(Offset = "0x6E0")]
	[Token(Token = "0x4000A19")]
	public float openPodiumDelay; //Field offset: 0x6E0
	[FieldOffset(Offset = "0x6E4")]
	[Token(Token = "0x4000A1A")]
	[Tooltip("프로필(아바타·닉네임·씨앗 pill)이 떨어지는 높이(px) — 높으면 어색, 살짝 위에서 툭(140→70, 2026-08-27 2차)")]
	public float openProfileDrop; //Field offset: 0x6E4
	[FieldOffset(Offset = "0x6E8")]
	[Token(Token = "0x4000A1B")]
	[Tooltip("낙하 시간(초) — 중력 가속(InQuad)으로 떨어진다. 높이를 낮추면 같이 줄여야 안 뜬다")]
	public float openProfileDur; //Field offset: 0x6E8
	[FieldOffset(Offset = "0x6EC")]
	[Token(Token = "0x4000A1C")]
	[Tooltip("프로필이 떨어지기 시작하는 시점(초) — 포디움 페이드가 끝난 뒤")]
	public float openProfileDelay; //Field offset: 0x6EC
	[FieldOffset(Offset = "0x6F0")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000A1D")]
	[Tooltip("프로필 사이 간격(초). 0=1·2·3위 동시 낙하(기본). 값을 주면 3위→2위→1위 순차")]
	public float openProfileStagger; //Field offset: 0x6F0
	[FieldOffset(Offset = "0x6F4")]
	[Token(Token = "0x4000A1E")]
	[Tooltip("착지 반동 높이(px, 0=끔) — 착지 후 살짝 튀어올랐다 다시 내려앉는다")]
	public float openProfileRebound; //Field offset: 0x6F4
	[FieldOffset(Offset = "0x6F8")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000A1F")]
	[Tooltip("반동 시간(초) — 튀어오르고 내려앉는 전체")]
	public float openProfileReboundDur; //Field offset: 0x6F8
	[FieldOffset(Offset = "0x6FC")]
	[Range(0, 20)]
	[Token(Token = "0x4000A20")]
	[Tooltip("낙하 기울기(도, 0=끔) — 우측 모서리가 먼저 닿게 기운 채 떨어지고, 착지 후 좌측 면이 떨어지며 좌우 진동이 잦아들어 수평을 찾는다(레퍼런스, 2026-08-27). 회전 피벗 = 단상 착지점")]
	public float openProfileTilt; //Field offset: 0x6FC
	[FieldOffset(Offset = "0x700")]
	[Range(0.1, 1.5)]
	[Token(Token = "0x4000A21")]
	[Tooltip("착지 후 수평을 찾는 록킹 시간(초)")]
	public float openProfileRockDur; //Field offset: 0x700
	[FieldOffset(Offset = "0x704")]
	[Range(0.05, 1)]
	[Token(Token = "0x4000A22")]
	[Tooltip("록킹 진동 주기(초) — 작을수록 자주 흔들린다")]
	public float openProfileRockPeriod; //Field offset: 0x704
	[FieldOffset(Offset = "0x708")]
	[Token(Token = "0x4000A23")]
	[Tooltip("리스트 판(크림 보드) 페이드 인 시간 / 지연(초) — 카드가 주인공이라 판은 움직이지 않고 뜬다")]
	public float openListDur; //Field offset: 0x708
	[FieldOffset(Offset = "0x70C")]
	[Token(Token = "0x4000A24")]
	public float openListDelay; //Field offset: 0x70C
	[FieldOffset(Offset = "0x710")]
	[Token(Token = "0x4000A25")]
	[Tooltip("랭킹 카드 한 장이 오른쪽에서 들어오는 거리(px) / 시간 / 카드 사이 간격(초) — 이 간격이 '차르륵'의 리듬")]
	public float openRowSlideX; //Field offset: 0x710
	[FieldOffset(Offset = "0x714")]
	[Token(Token = "0x4000A26")]
	public float openRowDur; //Field offset: 0x714
	[FieldOffset(Offset = "0x718")]
	[Range(0, 0.2)]
	[Token(Token = "0x4000A27")]
	public float openRowStagger; //Field offset: 0x718
	[FieldOffset(Offset = "0x71C")]
	[Token(Token = "0x4000A28")]
	[Tooltip("첫 카드가 들어오기 시작하는 시점(초) — 프로필 반동까지 끝난 뒤")]
	public float openRowDelay; //Field offset: 0x71C
	[FieldOffset(Offset = "0x720")]
	[Range(0, 30)]
	[Token(Token = "0x4000A29")]
	[Tooltip("차르륵으로 띄울 카드 수 상한(0=자동: 뷰포트에 보이는 만큼만). 화면 밖 카드는 연출하지 않는다")]
	public int openRowMax; //Field offset: 0x720
	[FieldOffset(Offset = "0x724")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000A2A")]
	[Tooltip("카드 착지 오버슈트(0=끔) — 왼쪽으로 살짝 지나쳤다 되돌아오는 양")]
	public float openRowOvershoot; //Field offset: 0x724
	[FieldOffset(Offset = "0x728")]
	[Token(Token = "0x4000A2B")]
	[Tooltip("CTA / 내 랭킹 카드가 아래에서 올라오는 거리(px) / 시간 / 지연(초)")]
	public float openCtaRise; //Field offset: 0x728
	[FieldOffset(Offset = "0x72C")]
	[Token(Token = "0x4000A2C")]
	public float openCtaDur; //Field offset: 0x72C
	[FieldOffset(Offset = "0x730")]
	[Token(Token = "0x4000A2D")]
	public float openCtaDelay; //Field offset: 0x730
	[FieldOffset(Offset = "0x734")]
	[Token(Token = "0x4000A2E")]
	[Tooltip("프로필 착지음(Sfx.Stamp 1회) + 카드 착지음(Sfx.Tile)")]
	public bool openSound; //Field offset: 0x734
	[FieldOffset(Offset = "0x738")]
	[Range(0, 12)]
	[Token(Token = "0x4000A2F")]
	[Tooltip("착지음을 울릴 카드 수(앞에서부터). 전부 울리면 소음이 된다")]
	public int openSoundRows; //Field offset: 0x738
	[FieldOffset(Offset = "0x73C")]
	[Header("로비 랭킹 카드 메달 뱃지 (UI/Ranking/medal_ribbon_N — 이번 주 1~3위만)")]
	[Token(Token = "0x4000A30")]
	[Tooltip("메달 크기(px, 0=끔)")]
	public float lobbyMedalSize; //Field offset: 0x73C
	[FieldOffset(Offset = "0x740")]
	[Token(Token = "0x4000A31")]
	[Tooltip("카드 우상단 모서리 기준 메달 중심 오프셋(px, +x=오른쪽 밖, +y=위 밖) — 시안 실측: 모서리에서 안쪽으로 (36, 28)")]
	public Vector2 lobbyMedalOffset; //Field offset: 0x740
	[FieldOffset(Offset = "0x748")]
	[Range(0.1, 0.6)]
	[Token(Token = "0x4000A32")]
	[Tooltip("숫자 크기 = 메달 크기 × 배율")]
	public float lobbyMedalNumFrac; //Field offset: 0x748
	[FieldOffset(Offset = "0x74C")]
	[Range(-0.4, 0.2)]
	[Token(Token = "0x4000A33")]
	[Tooltip("숫자 중심 y(메달 크기 대비) — 메달리온이 리본 아래라 음수")]
	public float lobbyMedalNumOffsetY; //Field offset: 0x74C
	[FieldOffset(Offset = "0x750")]
	[Range(-30, 30)]
	[Token(Token = "0x4000A34")]
	[Tooltip("메달 기울기(도, 0=수평)")]
	public float lobbyMedalTilt; //Field offset: 0x750
	[FieldOffset(Offset = "0x754")]
	[Range(0, 1)]
	[Token(Token = "0x4000A35")]
	[Tooltip("메달 뒤 소프트 섀도 진하기(0=끔) — 원반 그림자(SoftDiscShadow)")]
	public float lobbyMedalShadowAlpha; //Field offset: 0x754
	[FieldOffset(Offset = "0x758")]
	[Range(0, 6)]
	[Token(Token = "0x4000A36")]
	[Tooltip("메달 주변 반짝임 개수(0=끔)")]
	public int lobbyMedalSparkleCount; //Field offset: 0x758
	[FieldOffset(Offset = "0x75C")]
	[Token(Token = "0x4000A37")]
	[Tooltip("반짝임 한 개 크기(px)")]
	public float lobbyMedalSparkleSize; //Field offset: 0x75C
	[FieldOffset(Offset = "0x760")]
	[Header("순위 상승 연출 (오버레이 트윈 이식)")]
	[Token(Token = "0x4000A38")]
	public float swapUpDur; //Field offset: 0x760
	[FieldOffset(Offset = "0x764")]
	[Token(Token = "0x4000A39")]
	public float swapDownDur; //Field offset: 0x764
	[FieldOffset(Offset = "0x768")]
	[Token(Token = "0x4000A3A")]
	[Tooltip("상승 중 내 행 확대 배율. 착지하며 1로 복귀")]
	public float meRowSwapScale; //Field offset: 0x768
	[FieldOffset(Offset = "0x76C")]
	[Range(1, 4)]
	[Token(Token = "0x4000A3B")]
	[Tooltip("계단 소리·진동을 몇 칸마다 울릴지(1=매 칸). 4칸 이하 상승은 항상 매 칸")]
	public int rankUpTickEvery; //Field offset: 0x76C
	[FieldOffset(Offset = "0x770")]
	[Range(0.02, 0.2)]
	[Token(Token = "0x4000A3C")]
	[Tooltip("계단 틱 최소 간격(초). 크게 뛸수록 틱이 촘촘해져 '지익'으로 뭉개지는 걸 막는다")]
	public float rankUpTickMinGap; //Field offset: 0x770
	[FieldOffset(Offset = "0x774")]
	[Token(Token = "0x4000A3D")]
	[Tooltip("계단 틱에 진동을 함께 울릴지(소리만 원하면 끈다)")]
	public bool rankUpTickHaptic; //Field offset: 0x774
	[FieldOffset(Offset = "0x778")]
	[Header("순위 상승 연출 — 룰렛 스케줄 (2026-09-07, RankRollSchedule)")]
	[Token(Token = "0x4000A3E")]
	[Tooltip("첫 칸 간격(초) — 초반 '띠리리리' 속도. 간격은 칸마다 기하급수로 벌어져 마지막 간격에 닿는다")]
	public float rankUpTickStartGap; //Field offset: 0x778
	[FieldOffset(Offset = "0x77C")]
	[Token(Token = "0x4000A3F")]
	[Tooltip("마지막 칸 간격(초) — 멈추기 직전 '띡… 띡' 간격. 클수록 룰렛처럼 오래 끈다")]
	public float rankUpTickEndGap; //Field offset: 0x77C
	[FieldOffset(Offset = "0x780")]
	[Range(1, 12)]
	[Token(Token = "0x4000A40")]
	[Tooltip("감속에 쓰는 마지막 칸 수 — 이 앞까지는 첫 칸 간격 그대로 '띠리리리', 여기부터 마지막 간격까지 기하급수로 벌어진다")]
	public int rankUpDecelSteps; //Field offset: 0x780
	[FieldOffset(Offset = "0x784")]
	[Token(Token = "0x4000A41")]
	[Tooltip("총 상승 시간 하한(초) — 간격 합이 이보다 짧으면 비율을 유지한 채 늘린다")]
	public float rankUpRollMin; //Field offset: 0x784
	[FieldOffset(Offset = "0x788")]
	[Token(Token = "0x4000A42")]
	[Tooltip("총 상승 시간 상한(초) — 간격 합이 이보다 길면 비율을 유지한 채 줄인다(많이 오를 때)")]
	public float rankUpRollMax; //Field offset: 0x788
	[FieldOffset(Offset = "0x78C")]
	[Range(0, 40)]
	[Token(Token = "0x4000A43")]
	[Tooltip("최소 통과 칸 수(연출용 과장). 실제 상승이 이보다 적으면 내 행이 더 아래(뷰포트 밖)에서 출발해 이만큼의 행을 스치고 올라온다. 자리를 바꾸는 행은 실제 칸 수만. 0=끔")]
	public int rankUpMinVisualHops; //Field offset: 0x78C
	[FieldOffset(Offset = "0x790")]
	[Header("도움말 오버레이")]
	[Range(0.3, 1)]
	[Token(Token = "0x4000A44")]
	public float helpDimAlpha; //Field offset: 0x790
	[FieldOffset(Offset = "0x794")]
	[Token(Token = "0x4000A45")]
	public float helpFontSize; //Field offset: 0x794
	[FieldOffset(Offset = "0x798")]
	[Token(Token = "0x4000A46")]
	public Color helpTextColor; //Field offset: 0x798
	[FieldOffset(Offset = "0x7A8")]
	[Token(Token = "0x4000A47")]
	public float helpTapHintY; //Field offset: 0x7A8
	[FieldOffset(Offset = "0x7AC")]
	[Header("도움말 — 보드(1단계)")]
	[Token(Token = "0x4000A48")]
	public Vector2 helpBoardPos; //Field offset: 0x7AC
	[FieldOffset(Offset = "0x7B4")]
	[Token(Token = "0x4000A49")]
	public float helpBoardSize; //Field offset: 0x7B4
	[FieldOffset(Offset = "0x7B8")]
	[Token(Token = "0x4000A4A")]
	[Tooltip("일러스트 중심에서 라벨까지 거리(아래로)")]
	public float helpLabelDy; //Field offset: 0x7B8
	[FieldOffset(Offset = "0x7BC")]
	[Header("도움말 — 씨앗 보상")]
	[Token(Token = "0x4000A4B")]
	public Vector2 helpSeedPos; //Field offset: 0x7BC
	[FieldOffset(Offset = "0x7C4")]
	[Token(Token = "0x4000A4C")]
	public float helpSeedSize; //Field offset: 0x7C4
	[FieldOffset(Offset = "0x7C8")]
	[Header("도움말 — 미니 랭킹 리스트(2단계)")]
	[Token(Token = "0x4000A4D")]
	public Vector2 helpListPos; //Field offset: 0x7C8
	[FieldOffset(Offset = "0x7D0")]
	[Range(0.3, 1.2)]
	[Token(Token = "0x4000A4E")]
	public float helpListScale; //Field offset: 0x7D0
	[FieldOffset(Offset = "0x7D4")]
	[Header("도움말 — 프레임/보상(3단계)")]
	[Token(Token = "0x4000A4F")]
	public Vector2 helpGiftPos; //Field offset: 0x7D4
	[FieldOffset(Offset = "0x7DC")]
	[Token(Token = "0x4000A50")]
	public float helpGiftSize; //Field offset: 0x7DC
	[FieldOffset(Offset = "0x7E0")]
	[Header("도움말 — 화살표 3개(위치/회전/반전/크기)")]
	[Token(Token = "0x4000A51")]
	public Vector2 helpArrow1Pos; //Field offset: 0x7E0
	[FieldOffset(Offset = "0x7E8")]
	[Token(Token = "0x4000A52")]
	public float helpArrow1Rot; //Field offset: 0x7E8
	[FieldOffset(Offset = "0x7EC")]
	[Token(Token = "0x4000A53")]
	[Tooltip("좌우 반전 — 회전만으로는 곡선이 반대로 휘어 보일 때 켠다(반전 후 회전 적용)")]
	public bool helpArrow1Flip; //Field offset: 0x7EC
	[FieldOffset(Offset = "0x7F0")]
	[Token(Token = "0x4000A54")]
	public Vector2 helpArrow2Pos; //Field offset: 0x7F0
	[FieldOffset(Offset = "0x7F8")]
	[Token(Token = "0x4000A55")]
	[Tooltip("2번은 오른쪽에서 왼쪽 아래로 — 반전 + 회전 조합")]
	public float helpArrow2Rot; //Field offset: 0x7F8
	[FieldOffset(Offset = "0x7FC")]
	[Token(Token = "0x4000A56")]
	public bool helpArrow2Flip; //Field offset: 0x7FC
	[FieldOffset(Offset = "0x800")]
	[Token(Token = "0x4000A57")]
	public Vector2 helpArrow3Pos; //Field offset: 0x800
	[FieldOffset(Offset = "0x808")]
	[Token(Token = "0x4000A58")]
	public float helpArrow3Rot; //Field offset: 0x808
	[FieldOffset(Offset = "0x80C")]
	[Token(Token = "0x4000A59")]
	public bool helpArrow3Flip; //Field offset: 0x80C
	[FieldOffset(Offset = "0x80D")]
	[Token(Token = "0x4000A5A")]
	[Tooltip("상하 반전 — 세 화살표 공통(위로 휘는 곡선이 필요할 때)")]
	public bool helpArrowFlipY; //Field offset: 0x80D
	[FieldOffset(Offset = "0x810")]
	[Token(Token = "0x4000A5B")]
	public float helpArrowSize; //Field offset: 0x810
	[FieldOffset(Offset = "0x814")]
	[Header("도움말 — 방사형 글로우(보상 뒤, 회전)")]
	[Token(Token = "0x4000A5C")]
	[Tooltip("빛살 크기 = 보상 크기 × 배율")]
	public float helpRayScale; //Field offset: 0x814
	[FieldOffset(Offset = "0x818")]
	[Range(0, 1)]
	[Token(Token = "0x4000A5D")]
	public float helpRayAlpha; //Field offset: 0x818
	[FieldOffset(Offset = "0x81C")]
	[Token(Token = "0x4000A5E")]
	[Tooltip("빛살 한 바퀴에 걸리는 시간(초)")]
	public float helpRaySeconds; //Field offset: 0x81C
	[FieldOffset(Offset = "0x820")]
	[Token(Token = "0x4000A5F")]
	public float helpGlowScale; //Field offset: 0x820
	[FieldOffset(Offset = "0x824")]
	[Range(0, 1)]
	[Token(Token = "0x4000A60")]
	public float helpGlowAlpha; //Field offset: 0x824
	[FieldOffset(Offset = "0x828")]
	[Token(Token = "0x4000A61")]
	public Color helpGlowColor; //Field offset: 0x828
	[FieldOffset(Offset = "0x838")]
	[Range(0, 12)]
	[Token(Token = "0x4000A62")]
	[Tooltip("씨앗/보상 주변 반짝임 개수(0=끔)")]
	public int helpSparkleCount; //Field offset: 0x838
	[FieldOffset(Offset = "0x83C")]
	[Range(0.05, 0.5)]
	[Token(Token = "0x4000A63")]
	[Tooltip("반짝임 크기 = 보상 크기 × 이 배율")]
	public float helpSparkleSizeFrac; //Field offset: 0x83C
	[FieldOffset(Offset = "0x840")]
	[Range(0.6, 2.2)]
	[Token(Token = "0x4000A64")]
	[Tooltip("반짝임이 도는 범위 = 보상 크기 × 이 배율")]
	public float helpSparkleSpread; //Field offset: 0x840
	[FieldOffset(Offset = "0x844")]
	[Range(0, 0.9)]
	[Token(Token = "0x4000A65")]
	[Tooltip("안쪽 여백 비율 — 보상 중앙은 비우고 가장자리~바깥에서만 반짝인다")]
	public float helpSparkleInner; //Field offset: 0x844
	[FieldOffset(Offset = "0x848")]
	[Token(Token = "0x4000A66")]
	public Color helpSparkleColor; //Field offset: 0x848
	[FieldOffset(Offset = "0x858")]
	[Header("도움말 — 순차 등장")]
	[Token(Token = "0x4000A67")]
	[Tooltip("덩어리 하나가 뜨고 다음이 뜰 때까지 간격(초)")]
	public float helpRevealGap; //Field offset: 0x858
	[FieldOffset(Offset = "0x85C")]
	[Token(Token = "0x4000A68")]
	public float helpRevealDuration; //Field offset: 0x85C
	[FieldOffset(Offset = "0x860")]
	[Header("화단 말풍선 — 아바타 탭(2026-09-25)")]
	[Token(Token = "0x4000A69")]
	[Tooltip("말풍선 폭(1080 컬럼 기준)")]
	public float gardenBubbleW; //Field offset: 0x860
	[FieldOffset(Offset = "0x864")]
	[Token(Token = "0x4000A6A")]
	[Tooltip("화단 액자 높이")]
	public float gardenBubbleGardenH; //Field offset: 0x864
	[FieldOffset(Offset = "0x868")]
	[Token(Token = "0x4000A6B")]
	public float gardenBubblePad; //Field offset: 0x868
	[FieldOffset(Offset = "0x86C")]
	[Token(Token = "0x4000A6C")]
	[Tooltip("줄 사이 기본 여백. 화단 액자 아래는 1.5배")]
	public float gardenBubbleGap; //Field offset: 0x86C
	[FieldOffset(Offset = "0x870")]
	[Token(Token = "0x4000A6D")]
	[Tooltip("꼬리 폭(높이는 절반)")]
	public float gardenBubbleTailW; //Field offset: 0x870
	[FieldOffset(Offset = "0x874")]
	[Token(Token = "0x4000A6E")]
	[Tooltip("프로필 말풍선 닫기 X 버튼 크기(오른쪽 위 모서리에 걸침)")]
	public float gardenBubbleCloseSize; //Field offset: 0x874
	[FieldOffset(Offset = "0x878")]
	[Token(Token = "0x4000A6F")]
	[Tooltip("닫기 버튼 중심의 모서리 기준 오프셋 — x 양수 = 밖으로, y 양수 = 위로. 테두리에 걸치게 y 는 작게(리뷰 10-20)")]
	public float gardenBubbleCloseOffsetX; //Field offset: 0x878
	[FieldOffset(Offset = "0x87C")]
	[Token(Token = "0x4000A70")]
	public float gardenBubbleCloseOffsetY; //Field offset: 0x87C
	[FieldOffset(Offset = "0x880")]
	[Range(1, 1.6)]
	[Token(Token = "0x4000A71")]
	[Tooltip("프로필 팝업 회원증의 통계 숫자 배율(라벨·최고 기록 글자는 그대로) — 카드가 축소되어 숫자가 작아 보이는 것 보정(리뷰 10-20)")]
	public float gardenBubbleStatValueScale; //Field offset: 0x880
	[FieldOffset(Offset = "0x884")]
	[Range(0, 1)]
	[Token(Token = "0x4000A72")]
	public float gardenBubbleDimAlpha; //Field offset: 0x884
	[FieldOffset(Offset = "0x888")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000A73")]
	[Tooltip("말풍선 그림자 진하기·번짐(0=없음)")]
	public float gardenBubbleShadowAlpha; //Field offset: 0x888
	[FieldOffset(Offset = "0x88C")]
	[Token(Token = "0x4000A74")]
	public float gardenBubbleShadowSpread; //Field offset: 0x88C
	[FieldOffset(Offset = "0x890")]
	[Token(Token = "0x4000A75")]
	public Color gardenBubbleBgColor; //Field offset: 0x890
	[FieldOffset(Offset = "0x8A0")]
	[Token(Token = "0x4000A76")]
	public Color gardenBubbleLineColor; //Field offset: 0x8A0
	[FieldOffset(Offset = "0x8B0")]
	[Token(Token = "0x4000A77")]
	public Color gardenBubbleDaysColor; //Field offset: 0x8B0
	[FieldOffset(Offset = "0x8C0")]
	[Token(Token = "0x4000A78")]
	public Color gardenBubbleChipColor; //Field offset: 0x8C0
	[FieldOffset(Offset = "0x8D0")]
	[Token(Token = "0x4000A79")]
	public Color gardenBubbleMutedColor; //Field offset: 0x8D0
	[FieldOffset(Offset = "0x8E0")]
	[Range(0.5, 1.2)]
	[Token(Token = "0x4000A7A")]
	[Tooltip("본체 컷 박스 = 액자 높이 × 이 배율")]
	public float gardenBubblePlantFrac; //Field offset: 0x8E0
	[FieldOffset(Offset = "0x8E4")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000A7B")]
	[Tooltip("해 지름 = 액자 높이 × 이 배율(0=숨김)")]
	public float gardenBubbleSunFrac; //Field offset: 0x8E4
	[FieldOffset(Offset = "0x8E8")]
	[Range(0, 1)]
	[Token(Token = "0x4000A7C")]
	[Tooltip("해 뒤 햇빛(후광+햇살) 진하기. 0=없음")]
	public float gardenBubbleSunGlowAlpha; //Field offset: 0x8E8
	[FieldOffset(Offset = "0x8EC")]
	[Token(Token = "0x4000A7D")]
	public float gardenBubbleNameFs; //Field offset: 0x8EC
	[FieldOffset(Offset = "0x8F0")]
	[Token(Token = "0x4000A7E")]
	public float gardenBubbleDaysFs; //Field offset: 0x8F0
	[FieldOffset(Offset = "0x8F4")]
	[Token(Token = "0x4000A7F")]
	[Tooltip("일수 문구 자간(TMP characterSpacing). 굵은 숫자+작은 문구 조합이 벌어져 보여 음수로(09-25)")]
	public float gardenBubbleDaysSpacing; //Field offset: 0x8F4
	[FieldOffset(Offset = "0x8F8")]
	[Token(Token = "0x4000A80")]
	public float gardenBubbleMottoFs; //Field offset: 0x8F8
	[FieldOffset(Offset = "0x8FC")]
	[Token(Token = "0x4000A81")]
	public float gardenBubbleChipFs; //Field offset: 0x8FC
	[FieldOffset(Offset = "0x900")]
	[Token(Token = "0x4000A82")]
	public float gardenBubbleNoteFs; //Field offset: 0x900
	[FieldOffset(Offset = "0x904")]
	[Header("보상 팝업 — 코스튬 셀")]
	[Range(0.5, 2.5)]
	[Token(Token = "0x4000A83")]
	[Tooltip("코스튬 셀(내 아바타+코스튬)만의 크기 배율 — 전구·돋보기 등 다른 보상 아이콘(rewardIconSize)은 그대로")]
	public float rewardCostumeScale; //Field offset: 0x904
	[FieldOffset(Offset = "0x908")]
	[Token(Token = "0x4000A84")]
	[Tooltip("코스튬 셀 세로 위치 미세 조정(px, +면 위로)")]
	public float rewardCostumeDy; //Field offset: 0x908
	[FieldOffset(Offset = "0x90C")]
	[Header("보상 팝업 — 코스튬 하트 뿅뿅")]
	[Token(Token = "0x4000A85")]
	[Tooltip("코스튬 셀이 나타날 때 한 번에 터지는 하트 수·그 뒤 하나씩 뿅 솟는 간격(초, 0이면 첫 터짐만)")]
	public int rewardHeartBurst; //Field offset: 0x90C
	[FieldOffset(Offset = "0x910")]
	[Token(Token = "0x4000A86")]
	public float rewardHeartEvery; //Field offset: 0x910
	[FieldOffset(Offset = "0x914")]
	[Token(Token = "0x4000A87")]
	[Tooltip("첫 터짐 대기(초) — 셀 등장 팝 이후")]
	public float rewardHeartDelay; //Field offset: 0x914
	[FieldOffset(Offset = "0x918")]
	[Token(Token = "0x4000A88")]
	[Tooltip("하트가 나오는 높이 — 코스튬 아이콘 위 변 기준(px, +면 더 위). 코스튬에 붙어 보이지 않게")]
	public float rewardHeartOriginDy; //Field offset: 0x918
	[FieldOffset(Offset = "0x91C")]
	[Token(Token = "0x4000A89")]
	[Tooltip("하트 크기 범위(px)·솟는 높이(px)·퍼지는 좌우 폭(px)·떠오르는 시간(초)")]
	public Vector2 rewardHeartSize; //Field offset: 0x91C
	[FieldOffset(Offset = "0x924")]
	[Token(Token = "0x4000A8A")]
	public float rewardHeartRise; //Field offset: 0x924
	[FieldOffset(Offset = "0x928")]
	[Token(Token = "0x4000A8B")]
	public float rewardHeartSpread; //Field offset: 0x928
	[FieldOffset(Offset = "0x92C")]
	[Token(Token = "0x4000A8C")]
	public float rewardHeartDuration; //Field offset: 0x92C
	[FieldOffset(Offset = "0x930")]
	[Token(Token = "0x4000A8D")]
	[Tooltip("하트 색 두 가지(무작위 섞음)")]
	public Color rewardHeartColorA; //Field offset: 0x930
	[FieldOffset(Offset = "0x940")]
	[Token(Token = "0x4000A8E")]
	public Color rewardHeartColorB; //Field offset: 0x940

	[Address(RVA = "0x342189C", Offset = "0x342189C", Length = "0xA24")]
	[Token(Token = "0x6000470")]
	public RankPageConfig() { }

	[Address(RVA = "0x3420F70", Offset = "0x3420F70", Length = "0x144")]
	[Token(Token = "0x600046F")]
	public static RankPageConfig Load() { }

}

