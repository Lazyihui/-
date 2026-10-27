namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "ResultLayoutConfig", menuName = "Hamdoku/Result Layout Config")]
[Token(Token = "0x20000B0")]
public sealed class ResultLayoutConfig : ScriptableObject
{
	[Token(Token = "0x4000B06")]
	private static ResultLayoutConfig _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("그룹 전체")]
	[Range(-0.2, 0.2)]
	[Token(Token = "0x4000AC5")]
	[Tooltip("통계 문구와 4칸 통계를 함께 위(+)/아래(-)로 옮긴다. 화면 높이 비율(0.01 ≈ 화면의 1%)")]
	public float groupOffsetY; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Header("통계 문구 (플레이어 N%를 이겼어요)")]
	[Range(0.15, 0.6)]
	[Token(Token = "0x4000AC6")]
	[Tooltip("문구의 세로 위치(화면 비율)")]
	public float messageAnchorY; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Range(24, 72)]
	[Token(Token = "0x4000AC7")]
	[Tooltip("문구 글자 크기. 언어가 길면 이 값보다 작게 줄어든다")]
	public float messageFontSize; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Range(0.15, 0.6)]
	[Token(Token = "0x4000AC8")]
	[Tooltip("통계를 끄면(statMode=0) 칭찬 문구가 이 위치로 내려온다")]
	public float messageAnchorYNoStats; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Header("4칸 통계 (실수 · 씨앗 · 시간 · 최고 콤보)")]
	[Range(0.15, 0.6)]
	[Token(Token = "0x4000AC9")]
	[Tooltip("4칸 줄의 세로 위치(화면 비율)")]
	public float statRowAnchorY; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(400, 1000)]
	[Token(Token = "0x4000ACA")]
	[Tooltip("4칸이 나눠 쓰는 전체 가로 폭(px). 좁히면 칸 사이가 붙는다")]
	public float statRowWidth; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Range(14, 44)]
	[Token(Token = "0x4000ACB")]
	[Tooltip("라벨(실수·씨앗…) 글자 크기")]
	public float statLabelFontSize; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Range(20, 72)]
	[Token(Token = "0x4000ACC")]
	[Tooltip("값(숫자) 글자 크기")]
	public float statValueFontSize; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Range(-8, 24)]
	[Token(Token = "0x4000ACD")]
	[Tooltip("라벨과 값 사이 세로 간격(px)")]
	public float statCellGap; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Header("버튼")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x4000ACE")]
	[Tooltip("클리어 화면 [다음 레벨] 버튼의 세로 위치(화면 비율)")]
	public float clearButtonAnchorY; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Header("클리어 화면 위치")]
	[Range(0.6, 0.95)]
	[Token(Token = "0x4000ACF")]
	[Tooltip("타이틀(굉장해요!)의 세로 위치(화면 비율)")]
	public float clearTitleAnchorY; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Range(0, 0.2)]
	[Token(Token = "0x4000AD0")]
	[Tooltip("와이드 화면에서 타이틀을 추가로 올리는 양(화면 비율). 축소가 셀수록 많이 올라가고, 세로 화면에서는 0")]
	public float clearTitleWideLift; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[Token(Token = "0x4000AD1")]
	[Tooltip("와이드 화면에서 클리어 결과·실패 창의 세로 배치를 위아래로 펼치는 정도. 와이드는 창 전체가 축소돼 가운데로 몰리고 위아래가 빈다 — 크기는 축소 그대로 두고 위치만 벌린다. 0=펼치지 않음, 1=세로 화면과 같은 위치까지. 다른 팝업에는 영향 없음")]
	public float clearWideSpread; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(0.35, 0.8)]
	[Token(Token = "0x4000AD2")]
	[Tooltip("캐릭터(햄스터)와 뒤 후광의 세로 위치(화면 비율)")]
	public float clearHeroAnchorY; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Range(400, 1000)]
	[Token(Token = "0x4000AD3")]
	[Tooltip("캐릭터(햄스터) 크기(px)")]
	public float clearHeroSize; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Range(1, 1.3)]
	[Token(Token = "0x4000AD4")]
	[Tooltip("세로로 긴 캐릭터 그림(결과 일러스트 clear_a~f, 1080x1200)일 때 크기 배율. 같은 상자에 맞추면 정사각 그림보다 작아 보여서 키운다")]
	public float clearHeroTallScale; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Range(0, 120)]
	[Token(Token = "0x4000AD5")]
	[Tooltip("일러스트와 아래 글자(통계 문구·데일리 시간·실패 화면 남은 수) 사이 최소 간격(px). 공간이 모자라면 일러스트가 이 간격을 지키도록 줄어든다")]
	public float clearHeroTextGap; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Range(0, 160)]
	[Token(Token = "0x4000AD6")]
	[Tooltip("와이드 화면(가로/세로 0.65 이상)일 때의 위 간격. 와이드는 세로가 짧아 일러스트가 글자에 붙어 보인다")]
	public float clearHeroTextGapWide; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Header("캐릭터 뒤 후광 일렁임 (결과·실패 화면 공통)")]
	[Range(0, 0.25)]
	[Token(Token = "0x4000AD7")]
	[Tooltip("후광이 부풀었다 줄어드는 폭. 가로·세로가 다른 박자로 움직여 타원으로 출렁인다. 0이면 크기 고정")]
	public float glowShimmerScale; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Range(0, 1)]
	[Token(Token = "0x4000AD8")]
	[Tooltip("후광 밝기가 오르내리는 폭(기준 밝기 대비). 0이면 밝기 고정")]
	public float glowShimmerAlpha; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Range(0, 3)]
	[Token(Token = "0x4000AD9")]
	[Tooltip("일렁이는 속도 배율. 1이 기본, 클수록 빠르게")]
	public float glowShimmerSpeed; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Range(0, 60)]
	[Token(Token = "0x4000ADA")]
	[Tooltip("출렁이는 타원이 도는 속도(도/초). 0이면 돌지 않는다")]
	public float glowShimmerSpin; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Header("레벨 상자 보상 줄 (버튼 아래)")]
	[Range(0, 220)]
	[Token(Token = "0x4000ADB")]
	[Tooltip("[다음 레벨] 버튼 아래와 줄 묶음(문구 포함) 사이 여백(px)")]
	public float rewardGapFromButton; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Range(300, 900)]
	[Token(Token = "0x4000ADC")]
	[Tooltip("진행 줄(칸 묶음)의 가로 폭(px). 끝 상자는 이 폭 바깥 오른쪽에 걸친다")]
	public float rewardBarWidth; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Range(20, 90)]
	[Token(Token = "0x4000ADD")]
	[Tooltip("진행 줄의 높이(px)")]
	public float rewardBarHeight; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Range(60, 220)]
	[Token(Token = "0x4000ADE")]
	[Tooltip("줄 끝 상자의 크기(px)")]
	public float rewardGiftSize; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Range(-60, 120)]
	[Token(Token = "0x4000ADF")]
	[Tooltip("상자 중심을 줄 오른쪽 끝에서 얼마나 밀지(px). 0이면 끝에 반쯤 걸치고, 키우면 줄 바깥으로 나간다")]
	public float rewardGiftOffsetX; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Range(-80, 80)]
	[Token(Token = "0x4000AE0")]
	[Tooltip("상자를 줄 중심에서 위(+)/아래(-)로 옮긴다(px)")]
	public float rewardGiftOffsetY; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Range(0, 20)]
	[Token(Token = "0x4000AE1")]
	[Tooltip("칸 구분선 두께(px). 0이면 선을 긋지 않아 채움이 한 줄로 이어진다")]
	public float rewardCellGap; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4000AE2")]
	[Tooltip("채워진 구간의 칸 구분선 색. 홈과 같은 어두운 색이면 채움이 칸마다 끊겨 보인다")]
	public Color rewardTickColor; //Field offset: 0x8C
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x4000AE3")]
	[Tooltip("아직 비어 있는 구간의 칸 구분선 색. 홈보다 밝아야 눈금이 보인다")]
	public Color rewardTickColorEmpty; //Field offset: 0x9C
	[FieldOffset(Offset = "0xAC")]
	[Range(0, 28)]
	[Token(Token = "0x4000AE4")]
	[Tooltip("홈 안쪽 여백(px). 키우면 칸(캡슐)이 테두리 안에서 작아지고, 둥근 끝도 함께 작아진다")]
	public float rewardBarInset; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Range(0, 25)]
	[Token(Token = "0x4000AE5")]
	[Tooltip("아직 도착 전인 상자를 눌렀을 때 기우는 각도(도)")]
	public float rewardGiftShakeDeg; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Range(1, 10)]
	[Token(Token = "0x4000AE6")]
	[Tooltip("그 흔들림의 진동 횟수. 작을수록 좌우로 한 번 갸웃하고 멈춘다")]
	public int rewardGiftShakeVibrato; //Field offset: 0xB4
	[FieldOffset(Offset = "0xB8")]
	[Range(0, 15)]
	[Token(Token = "0x4000AE7")]
	[Tooltip("도착한 상자가 좌우로 기우는 각도(도). 0이면 흔들지 않는다")]
	public float rewardGiftWiggleDeg; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Range(0, 4)]
	[Token(Token = "0x4000AE8")]
	[Tooltip("도착한 상자 뒤 방사형 후광의 크기(상자 대비 배수). 0이면 후광 없음")]
	public float rewardGiftGlowScale; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000AE9")]
	[Tooltip("그 후광의 색과 진하기(알파). 상자보다 흰빛이어야 상자가 도드라진다")]
	public Color rewardGiftGlowColor; //Field offset: 0xC0
	[FieldOffset(Offset = "0xD0")]
	[Range(0, 12)]
	[Token(Token = "0x4000AEA")]
	[Tooltip("상자 주변 반짝이 개수. 0이면 반짝이지 않는다")]
	public int rewardGiftSparkleCount; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Range(0.8, 3)]
	[Token(Token = "0x4000AEB")]
	[Tooltip("반짝이가 흩어지는 범위(상자 대비 배수)")]
	public float rewardGiftSparkleSpread; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Range(0.05, 0.5)]
	[Token(Token = "0x4000AEC")]
	[Tooltip("반짝이 하나의 크기(상자 대비 비율)")]
	public float rewardGiftSparkleSize; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000AED")]
	[Tooltip("줄 위 문구에서 숫자만 쓰는 강조색. 금색은 베이지 본문과 붙어 보여 다른 색으로 둔다")]
	public Color rewardCaptionNumColor; //Field offset: 0xDC
	[FieldOffset(Offset = "0xEC")]
	[Range(20, 60)]
	[Token(Token = "0x4000AEE")]
	[Tooltip("줄 위 문구(다음 상자까지 N레벨)의 글자 크기")]
	public float rewardCaptionFontSize; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Range(10, 120)]
	[Token(Token = "0x4000AEF")]
	[Tooltip("줄과 그 위 문구 사이 간격(px)")]
	public float rewardCaptionGap; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Range(0, 0.12)]
	[Token(Token = "0x4000AF0")]
	[Tooltip("보상 줄이 함께 뜰 때 타이틀을 뺀 나머지(캐릭터·문구·통계·버튼)를 이만큼 위로 올린다")]
	public float rewardContentLiftY; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Range(0, 5)]
	[Token(Token = "0x4000AF1")]
	[Tooltip("보상 줄이 나타나는 시점(화면이 뜬 뒤 초) — 버튼보다 조금 늦게")]
	public float revealRewardAt; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Header("클리어 연출 시차 (화면이 뜬 뒤 초 — 탭하면 남은 단계 즉시 표시)")]
	[Range(0, 2)]
	[Token(Token = "0x4000AF2")]
	[Tooltip("캐릭터(햄스터) 등장 시점. 딤+타이틀은 화면과 동시에 뜬다")]
	public float revealHeroAt; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(0, 3)]
	[Token(Token = "0x4000AF3")]
	[Tooltip("색종이가 터지는 시점")]
	public float revealConfettiAt; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Range(0, 4)]
	[Token(Token = "0x4000AF4")]
	[Tooltip("통계(상대 비교 문구 + 4칸)가 나타나는 시점")]
	public float revealStatsAt; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Range(0, 2)]
	[Token(Token = "0x4000AF5")]
	[Tooltip("통계 숫자가 0에서 실제 값까지 차오르는 시간")]
	public float statCountUpDur; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Range(0, 5)]
	[Token(Token = "0x4000AF6")]
	[Tooltip("[다음 레벨] 버튼 등장 시점 — 이때부터 눌린다")]
	public float revealButtonAt; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Range(0.05, 1)]
	[Token(Token = "0x4000AF7")]
	[Tooltip("각 단계가 나타날 때의 페이드인 시간")]
	public float revealFadeDur; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Header("실패 화면 (해바라기씨 소진)")]
	[Range(0.15, 0.7)]
	[Token(Token = "0x4000AF8")]
	[Tooltip("'남은 수' 줄의 세로 위치")]
	public float failRemainingAnchorY; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Range(20, 72)]
	[Token(Token = "0x4000AF9")]
	[Tooltip("'남은 수' 글자 크기")]
	public float failRemainingFontSize; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4000AFA")]
	[Tooltip("'남은 수' 글자 외곽선 색 — 어두운 딤 위에서 흰 글자를 또렷하게 잡아 준다")]
	public Color failRemainingOutline; //Field offset: 0x11C
	[FieldOffset(Offset = "0x12C")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000AFB")]
	[Tooltip("'남은 수' 글자 외곽선 두께")]
	public float failRemainingOutlineWidth; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Range(0.15, 0.7)]
	[Token(Token = "0x4000AFC")]
	[Tooltip("'퍼즐은 계속돼요!' 줄의 세로 위치")]
	public float failMessageAnchorY; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Range(24, 72)]
	[Token(Token = "0x4000AFD")]
	[Tooltip("'퍼즐은 계속돼요!' 글자 크기")]
	public float failMessageFontSize; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x4000AFE")]
	[Tooltip("씨앗 받기(광고) 버튼의 세로 위치")]
	public float failContinueButtonAnchorY; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Range(0.02, 0.35)]
	[Token(Token = "0x4000AFF")]
	[Tooltip("다시 시작 버튼의 세로 위치")]
	public float failRestartButtonAnchorY; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Header("데일리 (시간 강조 — 4칸 통계 대신 시간 한 줄)")]
	[Range(0.15, 0.6)]
	[Token(Token = "0x4000B00")]
	[Tooltip("시간 줄의 세로 위치(화면 비율)")]
	public float dailyTimeAnchorY; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Range(36, 120)]
	[Token(Token = "0x4000B01")]
	[Tooltip("시간 값 글자 크기('완료 시간' 라벨은 이 값의 70%)")]
	public float dailyTimeFontSize; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Range(0.15, 0.6)]
	[Token(Token = "0x4000B02")]
	[Tooltip("시간 줄 아래 통계 문구(플레이어 N%…)의 세로 위치(화면 비율)")]
	public float dailyMessageAnchorY; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x4000B03")]
	[Tooltip("재도전(광고) 버튼이 함께 뜰 때 위 버튼(확인)의 세로 위치 — 혼자일 때는 clearButtonAnchorY")]
	public float dailyRetryTopButtonAnchorY; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Range(0.02, 0.35)]
	[Token(Token = "0x4000B04")]
	[Tooltip("재도전(광고) 버튼의 세로 위치")]
	public float dailyRetryButtonAnchorY; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Range(0, 0.12)]
	[Token(Token = "0x4000B05")]
	[Tooltip("재도전 버튼이 함께 뜰 때 시간·통계 줄을 이만큼 위로 올린다(버튼이 한 줄 더 생긴 만큼 자리를 비운다)")]
	public float dailyRetryContentLiftY; //Field offset: 0x154

	[Token(Token = "0x170000BB")]
	public static ResultLayoutConfig Instance
	{
		[Address(RVA = "0x34271D4", Offset = "0x34271D4", Length = "0xDC")]
		[Token(Token = "0x60004B2")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x34272B0", Offset = "0x34272B0", Length = "0x114")]
	[Token(Token = "0x60004B3")]
	public ResultLayoutConfig() { }

	[Address(RVA = "0x34271D4", Offset = "0x34271D4", Length = "0xDC")]
	[Token(Token = "0x60004B2")]
	public static ResultLayoutConfig get_Instance() { }

	[Address(RVA = "0x3426A4C", Offset = "0x3426A4C", Length = "0x788")]
	[Token(Token = "0x60004B1")]
	public int LayoutHash() { }

}

