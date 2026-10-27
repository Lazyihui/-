namespace Hamdoku.Managers;

[CreateAssetMenu(fileName = "ShopPopupLayout", menuName = "Hamdoku/Shop Popup Layout")]
[Token(Token = "0x20002A7")]
public sealed class ShopPopupLayout : ScriptableObject
{
	[Token(Token = "0x20002A8")]
	public sealed class ProductColor
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400128B")]
		[Tooltip("ShopData의 product_id (예: starter_pack, special_offer)")]
		public string productId; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400128C")]
		public Color color; //Field offset: 0x18

		[Address(RVA = "0x32EB748", Offset = "0x32EB748", Length = "0x10")]
		[Token(Token = "0x600135C")]
		public ProductColor() { }

	}

	[FieldOffset(Offset = "0x18")]
	[Header("배경")]
	[Token(Token = "0x4001171")]
	[Tooltip("메인 배경(MenuBackground) 위에 얹는 틴트. 흰색 = 원본 그대로(무틴트)")]
	public Color bgTint; //Field offset: 0x18
	[FieldOffset(Offset = "0x28")]
	[Header("컬럼(콘텐츠 폭/여백)")]
	[Token(Token = "0x4001172")]
	[Tooltip("카드 컬럼 폭 — 920은 20:9 세로 기기 캔버스 가로에 안전")]
	public float columnWidth; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001173")]
	public float padSide; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001174")]
	public float padTop; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001175")]
	public float padBottom; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Header("헤더(타이틀/닫기)")]
	[Token(Token = "0x4001176")]
	public float titleFs; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001177")]
	public float titleH; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001178")]
	public float closeSize; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001179")]
	[Tooltip("간판 배너(UI/Shop/shop_title_banner) 표시 폭 — 높이는 원본 비율로 따라옴")]
	public float titleBannerWidth; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[Token(Token = "0x400117A")]
	[Tooltip("배너 위 타이틀 텍스트의 세로 위치(배너 높이 비율, 0=위 1=아래) — 간판 보드 중심에 맞춘다")]
	public float titleTextYFrac; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Header("수량/기간 패드(카드 안 3개짜리)")]
	[Token(Token = "0x400117B")]
	[Tooltip("1 = 스프라이트 원본 비율(밴드 두께·코너가 패드 크기에 자동 비례). 키우면 밴드·코너가 얇아지고, 줄이면 두꺼워진다")]
	public float padPpumScale; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400117C")]
	[Tooltip("밴드 문구 색 — 밴드가 진한 컬러라 흰색이 기본")]
	public Color padBandTextCol; //Field offset: 0x50
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400117D")]
	[Tooltip("패드 스프라이트가 없을 때 코드로 그리는 폴백 밴드 높이(px)")]
	public float padFallbackBandH; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Header("오퍼 카드 — 좌상단 탭(마케팅 문구)")]
	[Token(Token = "0x400117E")]
	[Tooltip("탭 문구 글자 크기. 탭 표시 크기는 스프라이트 9-slice border ÷ offerFramePpum으로 정해진다")]
	public float offerTabFs; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400117F")]
	[Tooltip("탭 왼쪽 여백(px) — 아이콘이 있으면 아이콘 왼쪽까지")]
	public float offerTabPadL; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001180")]
	public float offerTabPadR; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Range(0.3, 1)]
	[Token(Token = "0x4001181")]
	[Tooltip("탭 아이콘(UI/Shop/badge_tab[_상품id]) 크기 = 탭 높이 × 이 값. 에셋 없으면 문구만")]
	public float offerTabIconScale; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001182")]
	public float offerTabIconGap; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001183")]
	[Tooltip("탭 문구 색 — 탭이 진한 컬러라 흰색이 기본")]
	public Color offerTabTextCol; //Field offset: 0x78
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001184")]
	[Tooltip("카드 좌변 → 탭 그림 왼쪽 끝(px). 탭은 좌 보더 영역 안에서 들여쓰여 그려져 있어서, 이 값이 있어야 문구를 '보이는 탭' 중앙에 맞출 수 있다")]
	public float offerTabInsetL; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001185")]
	[Tooltip("좌 보더 끝 → 탭 그림 오른쪽 끝(px). 보더를 탭보다 살짝 넉넉히 잡은 만큼")]
	public float offerTabInsetR; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Header("오퍼 카드 — 상품명 타이틀")]
	[Token(Token = "0x4001186")]
	public float offerTitleFs; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4001187")]
	[Tooltip("카드 좌변 → 타이틀 왼쪽 끝(px)")]
	public float offerTitleLeft; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001188")]
	[Tooltip("카드 위 변 → 타이틀 중심(px). 탭 아래로 내려와야 한다")]
	public float offerTitleTop; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Header("오퍼 카드 — 일러스트/타일 눈높이")]
	[Token(Token = "0x4001189")]
	[Tooltip("카드 위 변 → 구성 타일 행 중심(px). 타이틀 아래로 내려와야 겹치지 않는다")]
	public float offerRowTop; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400118A")]
	[Tooltip("카드 위 변 → 좌측 일러스트 중심(px). 타일과 따로 잡는다(시안은 타이틀 아래 큰 그림)")]
	public float offerArtTop; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x400118B")]
	[Tooltip("좌측 일러스트 한 변 상한(px). 카드 높이×0.62와 비교해 작은 쪽을 쓴다")]
	public float offerArtSize; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400118C")]
	[Tooltip("카드 좌변 → 일러스트 중심(px)")]
	public float offerArtX; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x400118D")]
	[Tooltip("일러스트 드롭 섀도 색(알파 포함). 알파 0이면 그림자 없음. 스프라이트 실루엣을 겹쳐 만들기 때문에 일러스트 모양을 그대로 따라간다")]
	public Color offerArtShadowCol; //Field offset: 0xAC
	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x400118E")]
	[Tooltip("일러스트 드롭 섀도 오프셋(px) — 살짝 아래가 자연스러움")]
	public Vector2 offerArtShadowOffset; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x400118F")]
	[Tooltip("번짐 반경(px). 0이면 실루엣 한 장이라 또렷한 그림자")]
	public float offerArtShadowSpread; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Range(0, 12)]
	[Token(Token = "0x4001190")]
	[Tooltip("번짐 샘플 수. 클수록 부드럽지만 드로우콜이 늘어난다(카드당 이 값+1장)")]
	public int offerArtShadowSteps; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Header("오퍼 카드 — 일러스트 뒤 방사형 후광")]
	[Token(Token = "0x4001191")]
	[Tooltip("후광 기본색(알파 포함). 알파 0이면 후광 없음. 카드 바탕이 크림이라 흰끼 도는 색은 묻힌다 — 채도가 있어야 보인다. 번들별로 바꾸려면 아래 haloOverrides 사용")]
	public Color offerHaloCol; //Field offset: 0xCC
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4001192")]
	[Tooltip("번들(오퍼)별 후광색. product_id로 찾고, 없는 상품은 위의 offerHaloCol")]
	public List<ProductColor> haloOverrides; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4001193")]
	[Tooltip("후광 지름 = 일러스트 한 변 × 이 값")]
	public float offerHaloScale; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4001194")]
	[Tooltip("일러스트 중심 기준 후광 위치 미세 조정(px)")]
	public Vector2 offerHaloOffset; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF4")]
	[Range(4, 24)]
	[Token(Token = "0x4001195")]
	[Tooltip("빛살 개수")]
	public int offerHaloSpokes; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4001196")]
	[Tooltip("한 바퀴 도는 데 걸리는 시간(초). 0이면 회전 없이 고정")]
	public float offerHaloSpinSeconds; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Header("오퍼 카드 — 안내 문구")]
	[Token(Token = "0x4001197")]
	[Tooltip("오퍼 카드 타일 아래 안내 문구 크기(광고 제거 범위 등)")]
	public float offerNoteFs; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001198")]
	[Tooltip("구성 타일 바닥 → 안내 문구 박스 위 변 간격(px)")]
	public float offerNoteGap; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001199")]
	[Tooltip("안내 문구 박스 높이(px). 가격 버튼과 겹치면 자동으로 줄어드니, 여유가 필요하면 offerRowTop을 줄이거나 offerCardH를 키운다")]
	public float offerNoteH; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x400119A")]
	[Tooltip("카드 좌변 → 안내 문구 왼쪽 끝(px). 0이면 구성 타일 블록 좌변에 맞춘다")]
	public float offerNoteLeft; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x400119B")]
	[Tooltip("안내 문구 오른쪽 정렬(시안 기준). 끄면 왼쪽 정렬")]
	public bool offerNoteRightAlign; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400119C")]
	[Tooltip("2줄일 때 행 간격. TMP 기준 글자 크기 대비 %(10 = 글자 크기의 10%만큼 벌림). 0 = 폰트 기본")]
	public float offerNoteLineSpacing; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Header("오퍼 가격 버튼")]
	[Token(Token = "0x400119D")]
	[Tooltip("버튼 스프라이트(UI/Shop/shop_btn_pink) 9-slice 코너 배율 — 클수록 코너가 작아짐")]
	public float offerBtnPpum; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400119E")]
	public Vector2 offerBtnSize; //Field offset: 0x118
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x400119F")]
	public float offerBtnFs; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Header("오퍼 타이머 뱃지")]
	[Token(Token = "0x40011A0")]
	public float timerHeight; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Range(0.3, 1.1)]
	[Token(Token = "0x40011A1")]
	[Tooltip("뱃지 안 시계 아이콘 크기 = 뱃지 높이 × 이 값")]
	public float timerIconScale; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x40011A2")]
	[Tooltip("카드 위 변에서 뱃지 중심까지의 거리(px). 클수록 아래로 내려온다")]
	public float timerTopOffset; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40011A3")]
	[Tooltip("뱃지 스프라이트(UI/Shop/shop_timer_badge) 사용 시 시간 텍스트 색")]
	public Color timerTextCol; //Field offset: 0x130
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40011A4")]
	[Tooltip("뱃지 스프라이트가 없을 때의 폴백 캡슐 색")]
	public Color timerFallbackCol; //Field offset: 0x140
	[FieldOffset(Offset = "0x150")]
	[Header("청약철회 안내(한국어 노출 시에만)")]
	[Token(Token = "0x40011A5")]
	[Tooltip("전자상거래법 고지. 한국어일 때만 상점 맨 아래에 붙는다 — 안내 문구 영역 높이")]
	public float refundNoticeH; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x40011A6")]
	public float refundNoticeFs; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40011A7")]
	public float refundLinkFs; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40011A8")]
	[Tooltip("하단 링크 색. 밑줄로 탭 가능함을 알리므로 본문과 같은 톤이 이 아트에 어울린다")]
	public Color refundLinkCol; //Field offset: 0x15C
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x40011A9")]
	[Tooltip("[구매 복원] ↔ [청약철회 상세보기] 사이 간격")]
	public float bottomLinkGap; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Header("푸터 장식")]
	[Token(Token = "0x40011AA")]
	[Tooltip("복원 안내 좌우 하트(UI/Shop/shop_heart_deco) 크기. 0이면 숨김")]
	public float footerHeartSize; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Header("카드 크기/간격")]
	[Token(Token = "0x40011AB")]
	public float cardGap; //Field offset: 0x174
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40011AC")]
	[Tooltip("카드 뒤 소프트 섀도 퍼짐 폭(px). 0이면 그림자 없음")]
	public float cardShadowSpread; //Field offset: 0x178
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x40011AD")]
	[Tooltip("카드 섀도 오프셋(px) — 살짝 아래가 자연스러움")]
	public Vector2 cardShadowOffset; //Field offset: 0x17C
	[FieldOffset(Offset = "0x184")]
	[Token(Token = "0x40011AE")]
	[Tooltip("카드 섀도 색(알파 포함). 크림 배경 위라 알파가 낮으면 거의 안 보인다")]
	public Color cardShadowCol; //Field offset: 0x184
	[FieldOffset(Offset = "0x194")]
	[Token(Token = "0x40011AF")]
	public float offerCardH; //Field offset: 0x194
	[FieldOffset(Offset = "0x198")]
	[Header("햄덕 클럽 GOLD 배너(자격 충족·비회원일 때 맨 위, 2026-10-20)")]
	[Token(Token = "0x40011B0")]
	[Tooltip("배너 카드 높이(스타터/스페셜 오퍼와 같은 높이 권장)")]
	public float clubCardH; //Field offset: 0x198
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x40011B1")]
	[Tooltip("배너 바탕 — 프로필 골드 회원증 그림(UI/Club/club_card_gold + 광택)을 그대로 쓴다. 이 색은 그림이 없을 때 폴백(#FFE078)")]
	public Color clubCardCol; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x40011B2")]
	[Tooltip("배너 테두리 폴백(#E6A52B) — 그림이 있으면 그림 테두리")]
	public Color clubCardLine; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1BC")]
	[Token(Token = "0x40011B3")]
	[Tooltip("신청 가능 태그 색(진한 허니 골드 #D99328 — 골드 바탕과 경계가 서고 흰 글씨가 또렷, 리뷰 10-20)")]
	public Color clubTagCol; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x40011B4")]
	[Tooltip("30일 이용권 배지 색(구매 팝업 배지와 같은 오렌지 골드)")]
	public Color clubDaysBadgeCol; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x40011B5")]
	[Tooltip("제목 글자 크기(햄덕 클럽 GOLD)")]
	public float clubTitleFs; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x40011B6")]
	[Tooltip("부제 글자 크기(현재 미사용)")]
	public float clubSubFs; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E4")]
	[Token(Token = "0x40011B7")]
	[Tooltip("제목 줄 ~ 혜택 칩 사이 여백")]
	public float clubTitleGap; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x40011B8")]
	[Tooltip("제목 왼쪽 들여쓰기(카드 왼쪽 변 기준) — 스타터 팩 제목(offerTitleLeft)과 맞추면 세로선이 정렬된다")]
	public float clubTitleLeft; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[Token(Token = "0x40011B9")]
	[Tooltip("제목 위 여백(카드 위 변 기준) — 태그가 위 변에 걸치므로 그 아래로")]
	public float clubTitleTop; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x40011BA")]
	[Tooltip("혜택 칩 높이(오른쪽 2×2)")]
	public float clubChipH; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Token(Token = "0x40011BB")]
	[Tooltip("혜택 칩 라벨 글자 크기(아래 줄 설명은 이 값의 78%)")]
	public float clubChipFs; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x40011BC")]
	[Tooltip("혜택 칩 안 바깥 여백(왼쪽 그림 앞·위아래) — 그림 상자 = 칩 높이 − 2×이 값")]
	public float clubChipPad; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x40011BD")]
	[Tooltip("혜택 칩 안 그림~글자 간격")]
	public float clubChipIconGap; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x40011BE")]
	[Tooltip("신청 가능 태그 글자 크기")]
	public float clubTagFs; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x40011BF")]
	[Tooltip("혜택 칩 바탕(#FFF9ED — 순백보다 연한 크림, 골드와 어우러지게)")]
	public Color clubChipCol; //Field offset: 0x204
	[FieldOffset(Offset = "0x214")]
	[Token(Token = "0x40011C0")]
	[Tooltip("캐릭터(건배 햄스터) 높이 — 다른 패키지의 선물상자와 비슷한 시각 크기(리뷰 10-20)")]
	public float clubArtH; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x40011C1")]
	[Tooltip("캐릭터 중심 — 카드 왼쪽 위 모서리 기준(x 오른쪽으로, y 아래로). 다른 패키지처럼 왼쪽에 둔다")]
	public Vector2 clubArtOffset; //Field offset: 0x218
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x40011C2")]
	[Tooltip("하단 요약 줄(돋보기, 힌트 각 최대 n개) 글자 크기")]
	public float clubTotalFs; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x40011C3")]
	[Tooltip("샴페인 잔 반짝이 개수(0이면 끔, 최대 = 점 개수)")]
	public int clubGlassSparkles; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x40011C4")]
	[Tooltip("반짝이 위치들 — 캐릭터 그림 비율(왼쪽 위 0,0 ~ 오른쪽 아래 1,1). 기본: 잔 테두리 위·음료·잔 위쪽")]
	public Vector2[] clubGlassPoints; //Field offset: 0x228
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x40011C5")]
	[Tooltip("반짝이 한 개 크기 범위 — 캐릭터 폭 대비(최소, 최대)")]
	public Vector2 clubGlassSparkleSize; //Field offset: 0x230
	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x40011C6")]
	[Tooltip("오팔 반짝이 색들 — 반짝일 때마다 하나를 고른다(무지갯빛 파스텔)")]
	public Color[] clubGlassOpal; //Field offset: 0x238
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x40011C7")]
	[Tooltip("가격 버튼 크기")]
	public Vector2 clubBtnSize; //Field offset: 0x240
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x40011C8")]
	[Tooltip("오퍼 카드 프레임(9-slice) 코너/탭 배율 — 클수록 탭이 작아짐. 1.2 = 원본 비율")]
	public float offerFramePpum; //Field offset: 0x248
	[FieldOffset(Offset = "0x24C")]
	[Token(Token = "0x40011C9")]
	public float itemCardH; //Field offset: 0x24C
	[FieldOffset(Offset = "0x250")]
	[Header("아이템 팩 카드 — 본문")]
	[Token(Token = "0x40011CA")]
	public float itemDescFs; //Field offset: 0x250
	[FieldOffset(Offset = "0x254")]
	[Token(Token = "0x40011CB")]
	[Tooltip("카드 위 변 → 설명 중심(px)")]
	public float itemDescTop; //Field offset: 0x254
	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x40011CC")]
	[Tooltip("카드 좌변 → 설명 왼쪽 끝(px)")]
	public float itemDescLeft; //Field offset: 0x258
	[FieldOffset(Offset = "0x25C")]
	[Token(Token = "0x40011CD")]
	[Tooltip("카드 오른 변 → 설명 오른쪽 끝(px). 설명은 수량 패드 위 줄이라 카드 폭을 거의 다 쓴다")]
	public float itemDescRightPad; //Field offset: 0x25C
	[FieldOffset(Offset = "0x260")]
	[Token(Token = "0x40011CE")]
	[Tooltip("설명 박스 높이(px). 긴 언어에서 2줄이 되어도 잘리지 않게 여유를 준다")]
	public float itemDescH; //Field offset: 0x260
	[FieldOffset(Offset = "0x264")]
	[Token(Token = "0x40011CF")]
	[Tooltip("좌측 일러스트 한 변(px)")]
	public float itemArtSize; //Field offset: 0x264
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x40011D0")]
	[Tooltip("카드 좌변 → 일러스트 중심(px)")]
	public float itemArtX; //Field offset: 0x268
	[FieldOffset(Offset = "0x26C")]
	[Token(Token = "0x40011D1")]
	[Tooltip("카드 위 변 → 일러스트 중심(px)")]
	public float itemArtTop; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Range(0, 16)]
	[Token(Token = "0x40011D2")]
	[Tooltip("썸네일 주변 반짝이 개수. 0이면 없음")]
	public int itemSparkleCount; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Token(Token = "0x40011D3")]
	[Tooltip("반짝이 색(알파 포함). 크림 카드 위에도 얹히므로 흰색보다 따뜻한 색이 잘 보인다")]
	public Color itemSparkleCol; //Field offset: 0x274
	[FieldOffset(Offset = "0x284")]
	[Token(Token = "0x40011D4")]
	[Tooltip("반짝이 크기 범위(px) — x=최소, y=최대")]
	public Vector2 itemSparkleSizeRange; //Field offset: 0x284
	[FieldOffset(Offset = "0x28C")]
	[Token(Token = "0x40011D5")]
	[Tooltip("반짝이 안쪽 반경 = 일러스트 반지름 × 이 값(이 안쪽에는 안 뜬다)")]
	public float itemSparkleInnerScale; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x40011D6")]
	[Tooltip("반짝이 바깥 반경 = 일러스트 반지름 × 이 값")]
	public float itemSparkleAreaScale; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Header("아이템 팩 카드 — 수량 패드 3개")]
	[Token(Token = "0x40011D7")]
	[Tooltip("패드 폭 상한(px). 카드가 좁으면 자동으로 줄어든다")]
	public float itemPadW; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x40011D8")]
	public float itemPadH; //Field offset: 0x298
	[FieldOffset(Offset = "0x29C")]
	[Token(Token = "0x40011D9")]
	public float itemPadGap; //Field offset: 0x29C
	[FieldOffset(Offset = "0x2A0")]
	[Token(Token = "0x40011DA")]
	[Tooltip("카드 아래 변 → 패드 바닥(px)")]
	public float itemPadBottom; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A4")]
	[Token(Token = "0x40011DB")]
	[Tooltip("패드 블록 왼쪽에 남길 폭(px) — 좌측 일러스트 자리. 패드 폭 계산에 쓰인다")]
	public float itemPadBlockLeft; //Field offset: 0x2A4
	[FieldOffset(Offset = "0x2A8")]
	[Token(Token = "0x40011DC")]
	[Tooltip("카드 오른 변 → 패드 블록 오른쪽 끝(px). 블록은 우측 정렬이라 이 값이 가로 위치를 정한다")]
	public float itemPadRightPad; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Token(Token = "0x40011DD")]
	[Tooltip("밴드 문구(\"5개\") 글자 크기")]
	public float itemBandFs; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Token(Token = "0x40011DE")]
	[Tooltip("패드 중앙 아이템 아이콘 한 변(px)")]
	public float itemPadIconSize; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Token(Token = "0x40011DF")]
	[Tooltip("아이콘 → 수량 텍스트 사이 여백(px)")]
	public float itemPadIconGap; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x40011E0")]
	[Tooltip("[아이콘+수량] 덩어리가 쓸 수 있는 패드 좌우 여백(px). 좁으면 글자가 오토사이즈로 줄어든다")]
	public float itemPadContentPad; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Token(Token = "0x40011E1")]
	[Tooltip("×N 글자 크기")]
	public float itemCountFs; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2C0")]
	[Token(Token = "0x40011E2")]
	public float itemPriceFs; //Field offset: 0x2C0
	[FieldOffset(Offset = "0x2C4")]
	[Token(Token = "0x40011E3")]
	[Tooltip("가격 버튼 높이(px)")]
	public float itemPricePillH; //Field offset: 0x2C4
	[FieldOffset(Offset = "0x2C8")]
	[Token(Token = "0x40011E4")]
	[Tooltip("가격 버튼 좌우 여백(px) — 버튼 폭 = 패드 폭 - 이 값×2")]
	public float itemPricePillSidePad; //Field offset: 0x2C8
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x40011E5")]
	[Tooltip("패드 아래 변 → 가격 필 바닥(px)")]
	public float itemPricePillBottom; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x40011E6")]
	public float headerPillH; //Field offset: 0x2D0
	[FieldOffset(Offset = "0x2D4")]
	[Token(Token = "0x40011E7")]
	public float restoreH; //Field offset: 0x2D4
	[FieldOffset(Offset = "0x2D8")]
	[Header("광고 제거 카드")]
	[Token(Token = "0x40011E8")]
	public float adsCardH; //Field offset: 0x2D8
	[FieldOffset(Offset = "0x2DC")]
	[Token(Token = "0x40011E9")]
	[Tooltip("영구 보유해서 살 기간이 없을 때의 카드 높이(px) — 패드 자리가 비므로 줄인다")]
	public float adsCardOwnedH; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x40011EA")]
	[Tooltip("ADS 아이콘 한 변(px)")]
	public float adsIconSize; //Field offset: 0x2E0
	[FieldOffset(Offset = "0x2E4")]
	[Token(Token = "0x40011EB")]
	[Tooltip("카드 좌변 → 아이콘 중심 거리(px)")]
	public float adsIconX; //Field offset: 0x2E4
	[FieldOffset(Offset = "0x2E8")]
	[Token(Token = "0x40011EC")]
	[Tooltip("카드 위 변 → 아이콘 중심 거리(px). 클수록 아이콘이 내려온다")]
	public float adsIconTop; //Field offset: 0x2E8
	[FieldOffset(Offset = "0x2EC")]
	[Token(Token = "0x40011ED")]
	[Tooltip("카드 좌변 → 제목/설명 텍스트 왼쪽 끝(px). 아이콘 폭보다 커야 겹치지 않는다")]
	public float adsTextLeft; //Field offset: 0x2EC
	[FieldOffset(Offset = "0x2F0")]
	[Token(Token = "0x40011EE")]
	public float adsTitleFs; //Field offset: 0x2F0
	[FieldOffset(Offset = "0x2F4")]
	[Token(Token = "0x40011EF")]
	[Tooltip("카드 위 변 → 제목 중심(px)")]
	public float adsTitleTop; //Field offset: 0x2F4
	[FieldOffset(Offset = "0x2F8")]
	[Token(Token = "0x40011F0")]
	public float adsDescFs; //Field offset: 0x2F8
	[FieldOffset(Offset = "0x2FC")]
	[Token(Token = "0x40011F1")]
	[Tooltip("카드 위 변 → 설명 중심(px)")]
	public float adsDescTop; //Field offset: 0x2FC
	[FieldOffset(Offset = "0x300")]
	[Token(Token = "0x40011F2")]
	[Tooltip("설명 박스 높이(px) — 2줄 시안 기준")]
	public float adsDescH; //Field offset: 0x300
	[FieldOffset(Offset = "0x304")]
	[Token(Token = "0x40011F3")]
	[Tooltip("2줄일 때 행 간격. TMP 기준 글자 크기 대비 %(10 = 글자 크기의 10%만큼 벌림). 0 = 폰트 기본")]
	public float adsDescLineSpacing; //Field offset: 0x304
	[FieldOffset(Offset = "0x308")]
	[Token(Token = "0x40011F4")]
	[Tooltip("적용 중 뱃지 크기(px)")]
	public Vector2 adsOwnedPillSize; //Field offset: 0x308
	[FieldOffset(Offset = "0x310")]
	[Token(Token = "0x40011F5")]
	[Tooltip("카드 오른 변 → 뱃지 오른쪽 끝(px)")]
	public float adsOwnedPillRight; //Field offset: 0x310
	[FieldOffset(Offset = "0x314")]
	[Token(Token = "0x40011F6")]
	[Tooltip("카드 위 변 → 뱃지 중심(px)")]
	public float adsOwnedPillTop; //Field offset: 0x314
	[FieldOffset(Offset = "0x318")]
	[Token(Token = "0x40011F7")]
	[Tooltip("체크 원판 → 문구 간격(px)")]
	public float adsOwnedIconGap; //Field offset: 0x318
	[FieldOffset(Offset = "0x31C")]
	[Token(Token = "0x40011F8")]
	[Tooltip("문구 오른쪽 여백(px)")]
	public float adsOwnedPillPadR; //Field offset: 0x31C
	[FieldOffset(Offset = "0x320")]
	[Token(Token = "0x40011F9")]
	public float adsOwnedFs; //Field offset: 0x320
	[FieldOffset(Offset = "0x324")]
	[Token(Token = "0x40011FA")]
	[Tooltip("뱃지 아래 남은 기간 글자 크기(px). 영구 보유면 표시 안 함")]
	public float adsOwnedRemainFs; //Field offset: 0x324
	[FieldOffset(Offset = "0x328")]
	[Token(Token = "0x40011FB")]
	[Tooltip("뱃지 아래 변 → 남은 기간 줄 간격(px)")]
	public float adsOwnedRemainGap; //Field offset: 0x328
	[FieldOffset(Offset = "0x32C")]
	[Token(Token = "0x40011FC")]
	[Tooltip("뱃지 스프라이트가 없을 때의 폴백 알약 색")]
	public Color adsOwnedPillBg; //Field offset: 0x32C
	[FieldOffset(Offset = "0x33C")]
	[Token(Token = "0x40011FD")]
	[Tooltip("폴백 알약일 때 문구 시작 위치(px)")]
	public float adsOwnedPillPadL; //Field offset: 0x33C
	[FieldOffset(Offset = "0x340")]
	[Token(Token = "0x40011FE")]
	[Tooltip("기간 버튼 크기(px). x는 상한이고, 컬럼이 좁으면 자동으로 줄어든다")]
	public Vector2 adsBtnSize; //Field offset: 0x340
	[FieldOffset(Offset = "0x348")]
	[Token(Token = "0x40011FF")]
	public float adsBtnGap; //Field offset: 0x348
	[FieldOffset(Offset = "0x34C")]
	[Token(Token = "0x4001200")]
	[Tooltip("카드 아래 변 → 버튼 바닥(px)")]
	public float adsBtnBottom; //Field offset: 0x34C
	[FieldOffset(Offset = "0x350")]
	[Token(Token = "0x4001201")]
	public float adsBandFs; //Field offset: 0x350
	[FieldOffset(Offset = "0x354")]
	[Token(Token = "0x4001202")]
	public float adsPriceFs; //Field offset: 0x354
	[FieldOffset(Offset = "0x358")]
	[Token(Token = "0x4001203")]
	[Tooltip("기간 아이콘(달력/무한대) 정사각 렉트 한 변(px). 무한대는 가로로 넓어 이보다 납작하게 들어간다. 0이면 아이콘 없이 가격만")]
	public float adsDurIconSize; //Field offset: 0x358
	[FieldOffset(Offset = "0x35C")]
	[Token(Token = "0x4001204")]
	[Tooltip("버튼 밴드 아래 → 아이콘 위 간격(px)")]
	public float adsDurIconTop; //Field offset: 0x35C
	[FieldOffset(Offset = "0x360")]
	[Token(Token = "0x4001205")]
	[Tooltip("기간 버튼 패드 뒤 그림자 퍼짐 폭(px). 0이면 그림자 없음 — 아이템 타일과 별개로 조정된다")]
	public float adsBtnShadowSpread; //Field offset: 0x360
	[FieldOffset(Offset = "0x364")]
	[Token(Token = "0x4001206")]
	[Tooltip("기간 버튼 패드 그림자 오프셋(px)")]
	public Vector2 adsBtnShadowOffset; //Field offset: 0x364
	[FieldOffset(Offset = "0x36C")]
	[Token(Token = "0x4001207")]
	[Tooltip("기간 버튼 패드 그림자 색(알파 포함)")]
	public Color adsBtnShadowCol; //Field offset: 0x36C
	[FieldOffset(Offset = "0x37C")]
	[Header("아이템 타일(구성 아이콘/수량 컬럼)")]
	[Range(0.4, 1.1)]
	[Token(Token = "0x4001208")]
	[Tooltip("타일 안 아이콘 크기 = 타일 폭 × 이 값")]
	public float tileIconScale; //Field offset: 0x37C
	[FieldOffset(Offset = "0x380")]
	[Token(Token = "0x4001209")]
	[Tooltip("타일 폭 상한(px). 카드가 좁으면 자동으로 줄어든다")]
	public float offerTileW; //Field offset: 0x380
	[FieldOffset(Offset = "0x384")]
	[Token(Token = "0x400120A")]
	[Tooltip("타일 높이 = 타일 폭 × 이 값")]
	public float offerTileHRatio; //Field offset: 0x384
	[FieldOffset(Offset = "0x388")]
	[Token(Token = "0x400120B")]
	public float offerTileGap; //Field offset: 0x388
	[FieldOffset(Offset = "0x38C")]
	[Token(Token = "0x400120C")]
	[Tooltip("카드 좌변에서 비워 둘 폭(px) — 좌측 일러스트 자리. 타일 폭 계산에 쓰인다")]
	public float offerTileLeftReserve; //Field offset: 0x38C
	[FieldOffset(Offset = "0x390")]
	[Token(Token = "0x400120D")]
	[Tooltip("카드 오른 변 → 타일 블록 오른쪽 끝(px)")]
	public float offerTileRightPad; //Field offset: 0x390
	[FieldOffset(Offset = "0x394")]
	[Token(Token = "0x400120E")]
	[Tooltip("타일 아래 수량 라벨(10 / 영구 / AUTO) 글자 크기")]
	public float offerTileLabelFs; //Field offset: 0x394
	[FieldOffset(Offset = "0x398")]
	[Token(Token = "0x400120F")]
	[Tooltip("타일 아래 변 → 라벨 중심(px). 아이콘 세로 위치도 이 값에 맞춰 따라간다")]
	public float offerTileLabelBottom; //Field offset: 0x398
	[FieldOffset(Offset = "0x39C")]
	[Token(Token = "0x4001210")]
	[Tooltip("타일 뒤 소프트 섀도 퍼짐 폭(px). 0이면 그림자 없음")]
	public float tileShadowSpread; //Field offset: 0x39C
	[FieldOffset(Offset = "0x3A0")]
	[Token(Token = "0x4001211")]
	[Tooltip("타일 섀도 오프셋(px)")]
	public Vector2 tileShadowOffset; //Field offset: 0x3A0
	[FieldOffset(Offset = "0x3A8")]
	[Token(Token = "0x4001212")]
	[Tooltip("타일 섀도 색(알파 포함)")]
	public Color tileShadowCol; //Field offset: 0x3A8
	[FieldOffset(Offset = "0x3B8")]
	[Header("Auto X 인포 뱃지 (오퍼 카드 AUTO 타일 우상단, 2026-08-28)")]
	[Token(Token = "0x4001213")]
	[Tooltip("보이는 아이콘(UI/Icons/icon_help) 한 변(px)")]
	public float autoXInfoSize; //Field offset: 0x3B8
	[FieldOffset(Offset = "0x3BC")]
	[Token(Token = "0x4001214")]
	[Tooltip("터치 영역 한 변(px) — 아이콘보다 넉넉하게. 아이콘은 이 영역 중앙에 놓인다")]
	public float autoXInfoHitSize; //Field offset: 0x3BC
	[FieldOffset(Offset = "0x3C0")]
	[Token(Token = "0x4001215")]
	[Tooltip("타일 우상단 코너 → 터치 영역 중심(px). +x 오른쪽, +y 위 = 코너 밖으로 걸친다")]
	public Vector2 autoXInfoOffset; //Field offset: 0x3C0
	[FieldOffset(Offset = "0x3C8")]
	[Header("Auto X 데모 팝업 (AutoXDemoPopup) — 판/타이틀")]
	[Token(Token = "0x4001216")]
	[Tooltip("팝업 판 크기(px). 내용은 880×1360 기준으로 조립되고, 판이 그보다 작아지면 통째로 균일 축소된다. 판만 키우면 남는 공간이 위아래(좌우)에 똑같이 나뉘므로, 아래 여백만 늘리려면 autoXDemoContentY로 내용을 올린다")]
	public Vector2 autoXDemoPanelSize; //Field offset: 0x3C8
	[FieldOffset(Offset = "0x3D0")]
	[Token(Token = "0x4001217")]
	[Tooltip("내용 컬럼 전체의 세로 오프셋(px, +면 위로). 타이틀~버튼이 한 덩어리로 움직여 버튼 아래 여백을 조절한다")]
	public float autoXDemoContentY; //Field offset: 0x3D0
	[FieldOffset(Offset = "0x3D4")]
	[Token(Token = "0x4001218")]
	[Tooltip("판 스프라이트(UI/PopupPanel) 9-slice 배율 — 새 시즌 팝업과 같은 값")]
	public float autoXDemoPanelPpum; //Field offset: 0x3D4
	[FieldOffset(Offset = "0x3D8")]
	[Token(Token = "0x4001219")]
	public float autoXDemoTitleY; //Field offset: 0x3D8
	[FieldOffset(Offset = "0x3DC")]
	[Token(Token = "0x400121A")]
	public float autoXDemoTitleFs; //Field offset: 0x3DC
	[FieldOffset(Offset = "0x3E0")]
	[Token(Token = "0x400121B")]
	public Color autoXDemoTitleColor; //Field offset: 0x3E0
	[FieldOffset(Offset = "0x3F0")]
	[Header("Auto X 데모 — 무대(액자 + 미니 보드)")]
	[Token(Token = "0x400121C")]
	[Tooltip("액자(UI/PopupPanelInner) 크기/세로 위치/배경색/9-slice 배율")]
	public Vector2 autoXDemoHeroSize; //Field offset: 0x3F0
	[FieldOffset(Offset = "0x3F8")]
	[Token(Token = "0x400121D")]
	public float autoXDemoHeroY; //Field offset: 0x3F8
	[FieldOffset(Offset = "0x3FC")]
	[Token(Token = "0x400121E")]
	public Color autoXDemoHeroBgColor; //Field offset: 0x3FC
	[FieldOffset(Offset = "0x40C")]
	[Token(Token = "0x400121F")]
	public float autoXDemoHeroPpum; //Field offset: 0x40C
	[FieldOffset(Offset = "0x410")]
	[Token(Token = "0x4001220")]
	[Tooltip("액자 안쪽 여백 → 보드 판(px). 작을수록 칸이 커진다")]
	public float autoXDemoBoardPad; //Field offset: 0x410
	[FieldOffset(Offset = "0x414")]
	[Range(0, 0.15)]
	[Token(Token = "0x4001221")]
	[Tooltip("보드 판 안쪽 여백 = 판 크기 × 이 비율. 인게임은 그리드 패딩 0 + 프레임 테두리만 있어 얇게 둔다")]
	public float autoXDemoBoardInset; //Field offset: 0x414
	[FieldOffset(Offset = "0x418")]
	[Range(0, 0.1)]
	[Token(Token = "0x4001222")]
	[Tooltip("칸 사이 간격 = 판 크기 × 이 비율. 인게임 그리드 spacing 7px(칸 100 기준 7%) ≈ 판 기준 1%")]
	public float autoXDemoCellGap; //Field offset: 0x418
	[FieldOffset(Offset = "0x41C")]
	[Token(Token = "0x4001223")]
	public Color autoXDemoBoardColor; //Field offset: 0x41C
	[FieldOffset(Offset = "0x42C")]
	[Range(0.5, 1.1)]
	[Token(Token = "0x4001224")]
	[Tooltip("햄스터 크기 = 칸 × 이 비율. Cell 프리팹의 Hamster 앵커(0.05~0.95)와 같은 0.9")]
	public float autoXDemoHamsterScale; //Field offset: 0x42C
	[FieldOffset(Offset = "0x430")]
	[Token(Token = "0x4001225")]
	[Tooltip("구역 색 5종 — 인게임 BoardView.regionColors 앞 5색과 같은 값(Game 씬)")]
	public Color[] autoXDemoPalette; //Field offset: 0x430
	[FieldOffset(Offset = "0x438")]
	[Token(Token = "0x4001226")]
	[Tooltip("자동 X 칸 발광 색(알파 = 정점 진하기). CellView.autoCrossGlowColor와 같은 톤")]
	public Color autoXDemoGlowColor; //Field offset: 0x438
	[FieldOffset(Offset = "0x448")]
	[Range(0, 1)]
	[Token(Token = "0x4001227")]
	[Tooltip("정점을 찍은 뒤 남는 잔광 = 정점 × 이 배율")]
	public float autoXDemoGlowRest; //Field offset: 0x448
	[FieldOffset(Offset = "0x44C")]
	[Header("Auto X 데모 — 타이밍(초)")]
	[Token(Token = "0x4001228")]
	[Tooltip("빈 판이 보인 뒤 손가락이 나올 때까지")]
	public float autoXDemoStartDelay; //Field offset: 0x44C
	[FieldOffset(Offset = "0x450")]
	[Token(Token = "0x4001229")]
	[Tooltip("손가락 더블탭이 보이는 시간(따닥 한 사이클 ≈ 0.4초 + 여유)")]
	public float autoXDemoFingerTime; //Field offset: 0x450
	[FieldOffset(Offset = "0x454")]
	[Token(Token = "0x400122A")]
	[Tooltip("햄스터가 등장한 뒤 X가 찍히기 시작할 때까지")]
	public float autoXDemoPlaceHold; //Field offset: 0x454
	[FieldOffset(Offset = "0x458")]
	[Token(Token = "0x400122B")]
	[Tooltip("X 한 칸과 다음 칸 사이 시차")]
	public float autoXDemoCrossGap; //Field offset: 0x458
	[FieldOffset(Offset = "0x45C")]
	[Token(Token = "0x400122C")]
	[Tooltip("한 마리 분량의 X가 다 찍힌 뒤 다음 마리로 넘어가기까지")]
	public float autoXDemoStepHold; //Field offset: 0x45C
	[FieldOffset(Offset = "0x460")]
	[Token(Token = "0x400122D")]
	[Tooltip("두 마리 모두 끝난 뒤 판을 걷어내기까지")]
	public float autoXDemoLoopPause; //Field offset: 0x460
	[FieldOffset(Offset = "0x464")]
	[Header("Auto X 데모 — 설명/버튼")]
	[Token(Token = "0x400122E")]
	public float autoXDemoDescY; //Field offset: 0x464
	[FieldOffset(Offset = "0x468")]
	[Token(Token = "0x400122F")]
	public float autoXDemoDescFs; //Field offset: 0x468
	[FieldOffset(Offset = "0x46C")]
	[Token(Token = "0x4001230")]
	public Vector2 autoXDemoDescSize; //Field offset: 0x46C
	[FieldOffset(Offset = "0x474")]
	[Token(Token = "0x4001231")]
	public Color autoXDemoDescColor; //Field offset: 0x474
	[FieldOffset(Offset = "0x484")]
	[Token(Token = "0x4001232")]
	[Tooltip("설명 줄 간격(TMP 규격, 퍼센트)")]
	public float autoXDemoDescLineSpacing; //Field offset: 0x484
	[FieldOffset(Offset = "0x488")]
	[Token(Token = "0x4001233")]
	[Tooltip("설정 안내 한 줄(autox_demo_settings_note, 2026-10-08) — 설명 아래 보조 문구. 설명보다 작고 옅게, 한 줄 고정(길면 자동 축소)")]
	public float autoXDemoNoteY; //Field offset: 0x488
	[FieldOffset(Offset = "0x48C")]
	[Token(Token = "0x4001234")]
	public float autoXDemoNoteFs; //Field offset: 0x48C
	[FieldOffset(Offset = "0x490")]
	[Token(Token = "0x4001235")]
	public Vector2 autoXDemoNoteSize; //Field offset: 0x490
	[FieldOffset(Offset = "0x498")]
	[Token(Token = "0x4001236")]
	public Color autoXDemoNoteColor; //Field offset: 0x498
	[FieldOffset(Offset = "0x4A8")]
	[Token(Token = "0x4001237")]
	public Vector2 autoXDemoBtnSize; //Field offset: 0x4A8
	[FieldOffset(Offset = "0x4B0")]
	[Token(Token = "0x4001238")]
	[Tooltip("버튼 중심 Y. 판 아래 변까지의 여백 = 판 절반 높이 - |이 값| - 버튼 절반 높이(기본 680-540-70 = 70px)")]
	public float autoXDemoBtnY; //Field offset: 0x4B0
	[FieldOffset(Offset = "0x4B4")]
	[Token(Token = "0x4001239")]
	public float autoXDemoBtnFs; //Field offset: 0x4B4
	[FieldOffset(Offset = "0x4B8")]
	[Token(Token = "0x400123A")]
	[Tooltip("크림 알약(btn_pill_cream) 틴트 — 리더보드/새 시즌 CTA와 같은 오렌지")]
	public Color autoXDemoBtnTint; //Field offset: 0x4B8
	[FieldOffset(Offset = "0x4C8")]
	[Token(Token = "0x400123B")]
	public Color autoXDemoBtnLabelGlow; //Field offset: 0x4C8
	[FieldOffset(Offset = "0x4D8")]
	[Range(0, 1)]
	[Token(Token = "0x400123C")]
	public float autoXDemoBtnShadowAlpha; //Field offset: 0x4D8
	[FieldOffset(Offset = "0x4DC")]
	[Token(Token = "0x400123D")]
	public float autoXDemoBtnShadowSpread; //Field offset: 0x4DC
	[FieldOffset(Offset = "0x4E0")]
	[Token(Token = "0x400123E")]
	public Vector2 autoXDemoBtnShadowOffset; //Field offset: 0x4E0
	[FieldOffset(Offset = "0x4E8")]
	[Header("색 — 공통")]
	[Token(Token = "0x400123F")]
	public Color cardCol; //Field offset: 0x4E8
	[FieldOffset(Offset = "0x4F8")]
	[Token(Token = "0x4001240")]
	public Color titleCol; //Field offset: 0x4F8
	[FieldOffset(Offset = "0x508")]
	[Token(Token = "0x4001241")]
	public Color subCol; //Field offset: 0x508
	[FieldOffset(Offset = "0x518")]
	[Token(Token = "0x4001242")]
	public Color packBgCol; //Field offset: 0x518
	[FieldOffset(Offset = "0x528")]
	[Token(Token = "0x4001243")]
	public Color ownedCol; //Field offset: 0x528
	[FieldOffset(Offset = "0x538")]
	[Token(Token = "0x4001244")]
	[Tooltip("번들(오퍼)마다 구성 타일 바탕색을 다르게 쓰고 싶을 때. product_id로 찾고, 없는 상품은 위의 packBgCol을 쓴다. 상품명이 아니라 ID로 매칭하므로 시트 순서/이름 변경에 안전")]
	public List<ProductColor> packBgOverrides; //Field offset: 0x538
	[FieldOffset(Offset = "0x540")]
	[Header("색 — 섹션 액센트")]
	[Token(Token = "0x4001245")]
	public Color offerCol; //Field offset: 0x540
	[FieldOffset(Offset = "0x550")]
	[Token(Token = "0x4001246")]
	public Color magnifierCol; //Field offset: 0x550
	[FieldOffset(Offset = "0x560")]
	[Token(Token = "0x4001247")]
	public Color hintCol; //Field offset: 0x560
	[FieldOffset(Offset = "0x570")]
	[Token(Token = "0x4001248")]
	public Color adsCol; //Field offset: 0x570
	[FieldOffset(Offset = "0x580")]
	[Header("구매 결과 팝업 — 프레임")]
	[Token(Token = "0x4001249")]
	[Tooltip("팝업 가로. 프레임 텍스처를 이 폭에 딱 맞춰 그리므로 어닝/햄스터가 가로로 늘어나지 않는다")]
	public float resultW; //Field offset: 0x580
	[FieldOffset(Offset = "0x584")]
	[Token(Token = "0x400124A")]
	[Tooltip("프레임 전체 세로 — 위로 튀어나온 햄스터까지 포함한다(현재 아트에서 햄스터가 약 158). 카드 본체만 보면 이 값에서 158을 뺀 크기. 어닝+바닥 보더 합(약 353)보다는 커야 한다")]
	public float resultH; //Field offset: 0x584
	[FieldOffset(Offset = "0x588")]
	[Token(Token = "0x400124B")]
	[Tooltip("화면 중앙 대비 위아래 이동. 햄스터가 위로 튀어나온 만큼 카드가 내려 보이면 +로 올린다")]
	public float resultYOffset; //Field offset: 0x588
	[FieldOffset(Offset = "0x58C")]
	[Range(0, 1)]
	[Token(Token = "0x400124C")]
	[Tooltip("딤 농도. 색은 다른 팝업과 같은 웜 블랙(UiFactory.DimOverlay)을 쓰고 알파만 여기서 조정")]
	public float resultDimAlpha; //Field offset: 0x58C
	[FieldOffset(Offset = "0x590")]
	[Token(Token = "0x400124D")]
	public float resultCloseSize; //Field offset: 0x590
	[FieldOffset(Offset = "0x594")]
	[Token(Token = "0x400124E")]
	[Tooltip("닫기 버튼 위치 — 버튼 우상단 모서리를 프레임 우상단에서 얼마나 옮길지(왼쪽/아래가 음수). 기본값은 어닝 띠 세로 중앙")]
	public Vector2 resultClosePos; //Field offset: 0x594
	[FieldOffset(Offset = "0x59C")]
	[Token(Token = "0x400124F")]
	[Tooltip("닫기 버튼 뒤 앰비언트 섀도가 밖으로 퍼지는 폭. 0이면 그림자 없음")]
	public float resultCloseShadowSpread; //Field offset: 0x59C
	[FieldOffset(Offset = "0x5A0")]
	[Token(Token = "0x4001250")]
	public Color resultCloseShadowCol; //Field offset: 0x5A0
	[FieldOffset(Offset = "0x5B0")]
	[Token(Token = "0x4001251")]
	[Tooltip("그림자 오프셋. (0,0)이면 사방 균일")]
	public Vector2 resultCloseShadowOffset; //Field offset: 0x5B0
	[FieldOffset(Offset = "0x5B8")]
	[Header("구매 결과 팝업 — 문구")]
	[Token(Token = "0x4001252")]
	public float resultTitleFs; //Field offset: 0x5B8
	[FieldOffset(Offset = "0x5BC")]
	[Token(Token = "0x4001253")]
	public float resultTitleTop; //Field offset: 0x5BC
	[FieldOffset(Offset = "0x5C0")]
	[Token(Token = "0x4001254")]
	public float resultTitleH; //Field offset: 0x5C0
	[FieldOffset(Offset = "0x5C4")]
	[Token(Token = "0x4001255")]
	public float resultMsgFs; //Field offset: 0x5C4
	[FieldOffset(Offset = "0x5C8")]
	[Token(Token = "0x4001256")]
	public float resultMsgTop; //Field offset: 0x5C8
	[FieldOffset(Offset = "0x5CC")]
	[Token(Token = "0x4001257")]
	public float resultMsgH; //Field offset: 0x5CC
	[FieldOffset(Offset = "0x5D0")]
	[Token(Token = "0x4001258")]
	[Tooltip("두 줄 사이 간격(폰트 크기 대비 %). TMP lineSpacing")]
	public float resultMsgLineSpacing; //Field offset: 0x5D0
	[FieldOffset(Offset = "0x5D4")]
	[Token(Token = "0x4001259")]
	public float resultTextSidePad; //Field offset: 0x5D4
	[FieldOffset(Offset = "0x5D8")]
	[Header("구매 결과 팝업 — 안내 박스")]
	[Token(Token = "0x400125A")]
	public float resultBoxTop; //Field offset: 0x5D8
	[FieldOffset(Offset = "0x5DC")]
	[Token(Token = "0x400125B")]
	public float resultBoxH; //Field offset: 0x5DC
	[FieldOffset(Offset = "0x5E0")]
	[Token(Token = "0x400125C")]
	public float resultBoxRadiusPpum; //Field offset: 0x5E0
	[FieldOffset(Offset = "0x5E4")]
	[Token(Token = "0x400125D")]
	public Color resultBoxBg; //Field offset: 0x5E4
	[FieldOffset(Offset = "0x5F4")]
	[Token(Token = "0x400125E")]
	public Color resultBoxLine; //Field offset: 0x5F4
	[FieldOffset(Offset = "0x604")]
	[Token(Token = "0x400125F")]
	public float resultBoxLineW; //Field offset: 0x604
	[FieldOffset(Offset = "0x608")]
	[Token(Token = "0x4001260")]
	public float resultBoxIconSize; //Field offset: 0x608
	[FieldOffset(Offset = "0x60C")]
	[Token(Token = "0x4001261")]
	public float resultBoxIconLeft; //Field offset: 0x60C
	[FieldOffset(Offset = "0x610")]
	[Token(Token = "0x4001262")]
	public float resultBoxIconGap; //Field offset: 0x610
	[FieldOffset(Offset = "0x614")]
	[Token(Token = "0x4001263")]
	public float resultBoxFs; //Field offset: 0x614
	[FieldOffset(Offset = "0x618")]
	[Token(Token = "0x4001264")]
	public float resultBoxLineSpacing; //Field offset: 0x618
	[FieldOffset(Offset = "0x61C")]
	[Token(Token = "0x4001265")]
	public float resultBoxTextRightPad; //Field offset: 0x61C
	[FieldOffset(Offset = "0x620")]
	[Header("구매 결과 팝업 — 성공 지급 내역")]
	[Token(Token = "0x4001266")]
	[Tooltip("성공 팝업 박스 안의 지급 아이콘 한 변")]
	public float resultRewardIconSize; //Field offset: 0x620
	[FieldOffset(Offset = "0x624")]
	[Token(Token = "0x4001267")]
	public float resultRewardGap; //Field offset: 0x624
	[FieldOffset(Offset = "0x628")]
	[Token(Token = "0x4001268")]
	public float resultRewardFs; //Field offset: 0x628
	[FieldOffset(Offset = "0x62C")]
	[Token(Token = "0x4001269")]
	public float resultRewardLabelTop; //Field offset: 0x62C
	[FieldOffset(Offset = "0x630")]
	[Token(Token = "0x400126A")]
	[Tooltip("지급 항목이 하나뿐이면 아이콘 아래가 아니라 오른쪽에 수량을 크게 붙인다 (아이템 팩 구매는 대부분 이 경우 — 아래로 깔면 허전하고 작아 보인다)")]
	public float resultRewardSoloIconSize; //Field offset: 0x630
	[FieldOffset(Offset = "0x634")]
	[Token(Token = "0x400126B")]
	public float resultRewardSoloFs; //Field offset: 0x634
	[FieldOffset(Offset = "0x638")]
	[Token(Token = "0x400126C")]
	public float resultRewardSoloGap; //Field offset: 0x638
	[FieldOffset(Offset = "0x63C")]
	[Header("구매 결과 팝업 — 확인 버튼")]
	[Token(Token = "0x400126D")]
	public Vector2 resultBtnSize; //Field offset: 0x63C
	[FieldOffset(Offset = "0x644")]
	[Token(Token = "0x400126E")]
	public float resultBtnBottom; //Field offset: 0x644
	[FieldOffset(Offset = "0x648")]
	[Token(Token = "0x400126F")]
	public float resultBtnFs; //Field offset: 0x648
	[FieldOffset(Offset = "0x64C")]
	[Token(Token = "0x4001270")]
	public Color resultBtnTextCol; //Field offset: 0x64C
	[FieldOffset(Offset = "0x65C")]
	[Header("공용 팝업 — 2버튼(종료 확인 등)")]
	[Token(Token = "0x4001271")]
	[Tooltip("버튼이 [취소][확인] 두 개일 때 각 버튼 폭. 높이는 위의 resultBtnSize.y를 쓴다")]
	public float resultBtnPairW; //Field offset: 0x65C
	[FieldOffset(Offset = "0x660")]
	[Token(Token = "0x4001272")]
	public float resultBtnGap; //Field offset: 0x660
	[FieldOffset(Offset = "0x664")]
	[Token(Token = "0x4001273")]
	[Tooltip("취소 버튼 틴트. UI/popup_btn_gray 스프라이트가 있으면 그걸 쓰고, 없으면 핑크 버튼에 이 색을 곱한다(Image 틴트는 곱셈이라 원본보다 밝게는 못 만든다)")]
	public Color resultCancelTint; //Field offset: 0x664
	[FieldOffset(Offset = "0x674")]
	[Token(Token = "0x4001274")]
	[Tooltip("취소 버튼 글자색 — 회색 버튼이 밝아서 확인(흰색)과 달리 진한 잉크를 쓴다")]
	public Color resultCancelTextCol; //Field offset: 0x674
	[FieldOffset(Offset = "0x684")]
	[Token(Token = "0x4001275")]
	[Tooltip("안내 박스가 없는 확인 팝업(종료 확인 등)의 프레임 높이. 위로 튀어나온 햄스터 포함")]
	public float resultConfirmH; //Field offset: 0x684
	[FieldOffset(Offset = "0x688")]
	[Token(Token = "0x4001276")]
	[Tooltip("버튼을 세로 2단으로 쌓을 때(라벨이 길어 가로로 안 들어가는 경우) 각 버튼 폭")]
	public float resultBtnStackedW; //Field offset: 0x688
	[FieldOffset(Offset = "0x68C")]
	[Header("약관 동의 팝업 — 프레임/박스")]
	[Token(Token = "0x4001277")]
	[Tooltip("프레임 전체 세로. 체크 항목 3줄 + 세로 2단 버튼이 들어갈 만큼 결과 팝업보다 높다")]
	public float termsFrameH; //Field offset: 0x68C
	[FieldOffset(Offset = "0x690")]
	[Token(Token = "0x4001278")]
	[Tooltip("체크 항목을 담는 안내 박스 높이. 항목 수가 바뀌면 여기와 termsRowH를 같이 본다 (= 여백×2 + 줄높이×줄수 + 줄간격×(줄수-1) + 테두리×2)")]
	public float termsBoxH; //Field offset: 0x690
	[FieldOffset(Offset = "0x694")]
	[Token(Token = "0x4001279")]
	[Tooltip("박스 안쪽 상하좌우 여백")]
	public float termsBoxPad; //Field offset: 0x694
	[FieldOffset(Offset = "0x698")]
	[Header("약관 동의 팝업 — 문구 옆 하트 장식")]
	[Token(Token = "0x400127A")]
	[Tooltip("프레임 중앙에서 하트까지의 좌우 거리. 0이면 하트를 그리지 않는다")]
	public float termsHeartX; //Field offset: 0x698
	[FieldOffset(Offset = "0x69C")]
	[Token(Token = "0x400127B")]
	public Vector2 termsHeartSize; //Field offset: 0x69C
	[FieldOffset(Offset = "0x6A4")]
	[Token(Token = "0x400127C")]
	[Tooltip("안내 문구 블록 중심 기준 위아래 이동(+면 위)")]
	public float termsHeartYOffset; //Field offset: 0x6A4
	[FieldOffset(Offset = "0x6A8")]
	[Token(Token = "0x400127D")]
	[Tooltip("바깥쪽으로 기울이는 각도. 0이면 똑바로")]
	public float termsHeartTilt; //Field offset: 0x6A8
	[FieldOffset(Offset = "0x6AC")]
	[Header("약관 동의 팝업 — 항목 줄")]
	[Token(Token = "0x400127E")]
	public float termsRowH; //Field offset: 0x6AC
	[FieldOffset(Offset = "0x6B0")]
	[Token(Token = "0x400127F")]
	public float termsRowGap; //Field offset: 0x6B0
	[FieldOffset(Offset = "0x6B4")]
	[Token(Token = "0x4001280")]
	[Tooltip("항목 줄 바탕. 박스 배경(연핑크) 위에 얹히는 밝은 카드")]
	public Color termsRowBg; //Field offset: 0x6B4
	[FieldOffset(Offset = "0x6C4")]
	[Token(Token = "0x4001281")]
	public float termsCheckSize; //Field offset: 0x6C4
	[FieldOffset(Offset = "0x6C8")]
	[Token(Token = "0x4001282")]
	[Tooltip("줄 좌변 → 체크박스 좌변")]
	public float termsCheckLeft; //Field offset: 0x6C8
	[FieldOffset(Offset = "0x6CC")]
	[Token(Token = "0x4001283")]
	[Tooltip("체크박스 안쪽 체크 아이콘 여백(클수록 체크가 작아진다)")]
	public float termsCheckInset; //Field offset: 0x6CC
	[FieldOffset(Offset = "0x6D0")]
	[Token(Token = "0x4001284")]
	[Tooltip("체크 안 된 상태의 체크박스 바탕")]
	public Color termsCheckOff; //Field offset: 0x6D0
	[FieldOffset(Offset = "0x6E0")]
	[Token(Token = "0x4001285")]
	[Tooltip("체크된 상태의 체크박스 바탕. 아이콘(icon_check)은 원본 색 그대로 얹힌다")]
	public Color termsCheckOn; //Field offset: 0x6E0
	[FieldOffset(Offset = "0x6F0")]
	[Token(Token = "0x4001286")]
	[Tooltip("체크박스 우변 → 라벨 좌변")]
	public float termsLabelGap; //Field offset: 0x6F0
	[FieldOffset(Offset = "0x6F4")]
	[Token(Token = "0x4001287")]
	[Tooltip("항목 라벨 크기(상한). 폭이 모자라면 줄바꿈 대신 자동으로 줄어드니, 키워도 안 커 보이면 termsLinkW/termsCheckSize를 줄여 폭을 내준다")]
	public float termsLabelFs; //Field offset: 0x6F4
	[FieldOffset(Offset = "0x6F8")]
	[Token(Token = "0x4001288")]
	[Tooltip("'전문보기' 링크 폭. 줄마다 글자 크기가 달라지지 않도록 링크가 없는 항목도 이 폭을 비워 둔다")]
	public float termsLinkW; //Field offset: 0x6F8
	[FieldOffset(Offset = "0x6FC")]
	[Token(Token = "0x4001289")]
	public float termsLinkFs; //Field offset: 0x6FC
	[FieldOffset(Offset = "0x700")]
	[Token(Token = "0x400128A")]
	public Color termsLinkCol; //Field offset: 0x700

	[Address(RVA = "0x32EAE50", Offset = "0x32EAE50", Length = "0x8F8")]
	[Token(Token = "0x600135B")]
	public ShopPopupLayout() { }

	[Address(RVA = "0x32EAC44", Offset = "0x32EAC44", Length = "0x1F8")]
	[Token(Token = "0x600135A")]
	private static Color Resolve(List<ProductColor> list, string productId, Color fallback) { }

	[Address(RVA = "0x32EAE3C", Offset = "0x32EAE3C", Length = "0x14")]
	[Token(Token = "0x6001359")]
	public Color ResolveHalo(string productId) { }

	[Address(RVA = "0x32EAC28", Offset = "0x32EAC28", Length = "0x1C")]
	[Token(Token = "0x6001358")]
	public Color ResolvePackBg(string productId) { }

}

