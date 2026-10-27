namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "SeedGiftConfig", menuName = "Hamdoku/Seed Gift Config")]
[Token(Token = "0x20000C0")]
public sealed class SeedGiftConfig : ScriptableObject
{
	[Token(Token = "0x20000C1")]
	public struct Slot
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000C56")]
		[Tooltip("로고 중심 기준 오프셋 — x는 로고 폭, y는 로고 높이의 배수")]
		public Vector2 offset; //Field offset: 0x0

	}

	[Token(Token = "0x4000C55")]
	private static SeedGiftConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("로비 아이콘 — 자리(로고 기준 슬롯, 카드·버튼·로고 아트와 겹치는 슬롯은 자동 제외·직전 슬롯 회피)")]
	[Token(Token = "0x4000BEB")]
	public Slot[] slots; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Range(0.1, 0.6)]
	[Token(Token = "0x4000BEC")]
	public float iconWidthOfLogo; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000BED")]
	[Tooltip("로고 rect 안에서 실제 그림(햄스터 머리+글자)이 차지하는 비율(가로, 세로) — 이 영역만 장애물로 본다. 실기 캡처 기준 가로 0.64")]
	public Vector2 logoArtFraction; //Field offset: 0x24
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000BEE")]
	public float obstacleMargin; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000BEF")]
	public float edgeMargin; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000BF0")]
	public float gapMargin; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Header("로비 아이콘 — 연잎(얼굴을 가린 채 오물오물, 탭하면 우산처럼 든다). 팝업에는 없다")]
	[Token(Token = "0x4000BF1")]
	public bool iconLeaf; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Range(0.6, 2)]
	[Token(Token = "0x4000BF2")]
	public float leafWidthOfBody; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000BF3")]
	public float leafPivotY; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000BF4")]
	[Tooltip("줄기 밑동(잎 pivot)이 놓이는 자리 — 몸통 왼쪽 아래 원점, 폭·높이 비율. 기본은 오른쪽 앞발(0.71, 0.36) → 줄기를 손에 쥔 것처럼 보이고 잎이 눈을 가린다")]
	public Vector2 leafStemAt; //Field offset: 0x44
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000BF5")]
	public bool leafMirrorOnRight; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Range(0, 10)]
	[Token(Token = "0x4000BF6")]
	public float leafChewWobble; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Range(0, 120)]
	[Token(Token = "0x4000BF7")]
	public float tapLiftAngle; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000BF8")]
	public float tapLiftDuration; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Header("로비 아이콘 — 뒷모습 모드(UI/seed_gift_hamster_back). 등장 때 이 확률로 등을 돌리고 앉아 움찔거리다 탭하면 홱 돌아선다")]
	[Range(0, 1)]
	[Token(Token = "0x4000BF9")]
	public float backViewChance; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000BFA")]
	public float fidgetChewInterval; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000BFB")]
	public float fidgetIntervalMin; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000BFC")]
	public float fidgetIntervalMax; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Range(0, 20)]
	[Token(Token = "0x4000BFD")]
	public float fidgetWobble; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Range(0, 0.2)]
	[Token(Token = "0x4000BFE")]
	public float fidgetSquash; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Range(0, 0.3)]
	[Token(Token = "0x4000BFF")]
	public float fidgetHop; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Range(0, 1)]
	[Token(Token = "0x4000C00")]
	public float fidgetHopChance; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Range(0, 0.2)]
	[Token(Token = "0x4000C01")]
	public float fidgetShuffle; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000C02")]
	public float turnDuration; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Range(0.2, 0.9)]
	[Token(Token = "0x4000C03")]
	public float turnMinScaleX; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Range(0.6, 1)]
	[Token(Token = "0x4000C04")]
	public float turnSideScaleX; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Range(0, 0.25)]
	[Token(Token = "0x4000C05")]
	public float turnCrossfade; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Header("로비 아이콘 — 연출")]
	[Range(0, 0.1)]
	[Token(Token = "0x4000C06")]
	public float breathAmount; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000C07")]
	public float breathPeriod; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000C08")]
	public float entranceDuration; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x4000C09")]
	public float tapDuration; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Header("오물오물(아이콘·팝업 공용) — 홀쭉(1컷)·볼록(2컷) 교대 + 부스러기")]
	[Token(Token = "0x4000C0A")]
	public float chewInterval; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000C0B")]
	public int chewCountMin; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000C0C")]
	public int chewCountMax; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4000C0D")]
	public float chewPauseMin; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000C0E")]
	public float chewPauseMax; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Range(0, 0.08)]
	[Token(Token = "0x4000C0F")]
	public float chewCheekPulse; //Field offset: 0xB4
	[FieldOffset(Offset = "0xB8")]
	[Range(0, 4)]
	[Token(Token = "0x4000C10")]
	public int crumbPerChew; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Range(0, 1)]
	[Token(Token = "0x4000C11")]
	public float crumbChance; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Range(0, 4)]
	[Token(Token = "0x4000C12")]
	public int crumbPauseBurstMin; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Range(0, 4)]
	[Token(Token = "0x4000C13")]
	public int crumbPauseBurstMax; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000C14")]
	[Tooltip("부스러기가 생기는 입 자리 — 몸통 rect 기준 정규화(x, y 왼쪽 아래 원점, w, h)")]
	public Rect mouthRect; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000C15")]
	public float crumbSize; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000C16")]
	public float crumbFall; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000C17")]
	public float crumbSpread; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x4000C18")]
	public float crumbDuration; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000C19")]
	public Color crumbColorA; //Field offset: 0xE8
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000C1A")]
	public Color crumbColorB; //Field offset: 0xF8
	[FieldOffset(Offset = "0x108")]
	[Header("팝업 — 패널(UI/PopupPanel). 내용은 850×1200 기준으로 조립하고 패널 크기에 맞춰 균일 축소")]
	[Token(Token = "0x4000C1B")]
	public Vector2 panelSize; //Field offset: 0x108
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4000C1C")]
	public float panelPpum; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4000C1D")]
	public float contentShiftY; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Header("팝업 — 제목")]
	[Token(Token = "0x4000C1E")]
	public float titleY; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4000C1F")]
	public float titleFontSize; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000C20")]
	public Color titleColor; //Field offset: 0x120
	[FieldOffset(Offset = "0x130")]
	[Header("팝업 — 히어로(햄스터). heroFrame을 켜면 뒤에 액자(UI/PopupPanelInner)가 깔린다")]
	[Token(Token = "0x4000C21")]
	public bool heroFrame; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x4000C22")]
	public Vector2 heroSize; //Field offset: 0x134
	[FieldOffset(Offset = "0x13C")]
	[Token(Token = "0x4000C23")]
	public float heroY; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000C24")]
	public Color heroBgColor; //Field offset: 0x140
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x4000C25")]
	public float heroPpum; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x4000C26")]
	public float heroHamsterHeight; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x4000C27")]
	public Vector2 heroHamsterOffset; //Field offset: 0x158
	[FieldOffset(Offset = "0x160")]
	[Header("팝업 — 햄스터 뒤 씨앗 더미 한 무더기. UI/seed_gift_pile(일러스트)이 있으면 그걸 햄스터 뒤 가운데에, 없으면 icon_life를 코드로 흩어 쌓는다")]
	[Token(Token = "0x4000C28")]
	public bool seedPile; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Range(0.5, 3)]
	[Token(Token = "0x4000C29")]
	public float pileImageWidth; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Range(-0.6, 0.6)]
	[Token(Token = "0x4000C2A")]
	public float pileImageCenterX; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Range(-0.8, 0.2)]
	[Token(Token = "0x4000C2B")]
	public float pileImageBottomY; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x4000C2C")]
	public bool pileImageMirror; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x4000C2D")]
	public Color pileImageTint; //Field offset: 0x174
	[FieldOffset(Offset = "0x184")]
	[Range(0, 20)]
	[Token(Token = "0x4000C2E")]
	public int seedPileCount; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Range(0, 6)]
	[Token(Token = "0x4000C2F")]
	public int seedPileFrontCount; //Field offset: 0x188
	[FieldOffset(Offset = "0x18C")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x4000C30")]
	public float seedPileSeedSize; //Field offset: 0x18C
	[FieldOffset(Offset = "0x190")]
	[Range(0.2, 1.2)]
	[Token(Token = "0x4000C31")]
	public float seedPileCenterX; //Field offset: 0x190
	[FieldOffset(Offset = "0x194")]
	[Range(0.1, 1.2)]
	[Token(Token = "0x4000C32")]
	public float seedPileWidth; //Field offset: 0x194
	[FieldOffset(Offset = "0x198")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000C33")]
	public float seedPileHeight; //Field offset: 0x198
	[FieldOffset(Offset = "0x19C")]
	[Range(-0.8, 0.2)]
	[Token(Token = "0x4000C34")]
	public float seedPileBaseY; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Range(0, 60)]
	[Token(Token = "0x4000C35")]
	public float seedPileTilt; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Token(Token = "0x4000C36")]
	public Color seedPileBackTint; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1B4")]
	[Token(Token = "0x4000C37")]
	public int seedPileSeed; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1B8")]
	[Header("팝업 — 설명(햄스터 대사, 3종 중 랜덤)")]
	[Token(Token = "0x4000C38")]
	public float descY; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Token(Token = "0x4000C39")]
	public Vector2 descSize; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x4000C3A")]
	public float descFontSize; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x4000C3B")]
	public Color descColor; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1D8")]
	[Range(-30, 40)]
	[Token(Token = "0x4000C3C")]
	public float descLineSpacing; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Header("팝업 — 버튼(위=광고 보고 3개, 아래=그냥 1개)")]
	[Token(Token = "0x4000C3D")]
	public Vector2 btnSize; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E4")]
	[Token(Token = "0x4000C3E")]
	public Vector2 btnSize2; //Field offset: 0x1E4
	[FieldOffset(Offset = "0x1EC")]
	[Token(Token = "0x4000C3F")]
	public float btnY; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x4000C40")]
	public float btnGap; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x4000C41")]
	public float btnCornerScale; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x4000C42")]
	public float btnFontSize; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x4000C43")]
	public Color btnTint; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x4000C44")]
	public Color btnTintAlt; //Field offset: 0x20C
	[FieldOffset(Offset = "0x21C")]
	[Token(Token = "0x4000C45")]
	public Color btnLabelColorAlt; //Field offset: 0x21C
	[FieldOffset(Offset = "0x22C")]
	[Token(Token = "0x4000C46")]
	public Color btnLabelGlow; //Field offset: 0x22C
	[FieldOffset(Offset = "0x23C")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000C47")]
	public float btnShadowAlpha; //Field offset: 0x23C
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x4000C48")]
	public float btnShadowSpread; //Field offset: 0x240
	[FieldOffset(Offset = "0x244")]
	[Token(Token = "0x4000C49")]
	public int btnShadowLayers; //Field offset: 0x244
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x4000C4A")]
	public Vector2 btnShadowOffset; //Field offset: 0x248
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x4000C4B")]
	public Vector2 adIconSize; //Field offset: 0x250
	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x4000C4C")]
	public float adIconInset; //Field offset: 0x258
	[FieldOffset(Offset = "0x25C")]
	[Token(Token = "0x4000C4D")]
	public float adIconGap; //Field offset: 0x25C
	[FieldOffset(Offset = "0x260")]
	[Token(Token = "0x4000C4E")]
	public float seedIconSize; //Field offset: 0x260
	[FieldOffset(Offset = "0x264")]
	[Token(Token = "0x4000C4F")]
	public float seedCountFontSize; //Field offset: 0x264
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x4000C50")]
	public float seedInset; //Field offset: 0x268
	[FieldOffset(Offset = "0x26C")]
	[Token(Token = "0x4000C51")]
	public float seedGap; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Header("팝업 — 수령 연출(씨앗이 랭킹 카드로 날아간다)")]
	[Token(Token = "0x4000C52")]
	public float flySeedSize; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Range(0.3, 2.5)]
	[Token(Token = "0x4000C53")]
	public float flySpeed; //Field offset: 0x274
	[FieldOffset(Offset = "0x278")]
	[Range(0, 1)]
	[Token(Token = "0x4000C54")]
	public float flyCloseDelay; //Field offset: 0x278

	[Address(RVA = "0x3430DCC", Offset = "0x3430DCC", Length = "0x348")]
	[Token(Token = "0x6000537")]
	public SeedGiftConfig() { }

	[Address(RVA = "0x3430C88", Offset = "0x3430C88", Length = "0x144")]
	[Token(Token = "0x6000536")]
	public static SeedGiftConfig Load() { }

}

