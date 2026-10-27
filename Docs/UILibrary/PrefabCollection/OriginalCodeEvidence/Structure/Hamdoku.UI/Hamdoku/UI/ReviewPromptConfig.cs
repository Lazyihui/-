namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "ReviewPromptConfig", menuName = "Hamdoku/Review Prompt Config")]
[Token(Token = "0x20000B2")]
public sealed class ReviewPromptConfig : ScriptableObject
{
	[Token(Token = "0x4000B47")]
	private static ReviewPromptConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("패널(UI/PopupPanel)")]
	[Token(Token = "0x4000B0D")]
	public Vector2 panelSize; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000B0E")]
	public float panelPpum; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Header("타이틀 탭(상단 노란 알약)")]
	[Token(Token = "0x4000B0F")]
	public Vector2 tabSize; //Field offset: 0x24
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000B10")]
	public float tabHeightScale; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000B11")]
	public float tabOverhang; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000B12")]
	public Color tabColor; //Field offset: 0x34
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000B13")]
	public float titleFontSize; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000B14")]
	public Color titleColor; //Field offset: 0x48
	[FieldOffset(Offset = "0x58")]
	[Header("닫기 X")]
	[Token(Token = "0x4000B15")]
	public float closeSize; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000B16")]
	public Vector2 closeOffset; //Field offset: 0x5C
	[FieldOffset(Offset = "0x64")]
	[Header("햄스터(UI/review_hamster) — 별점 카드 위에 얹힌다")]
	[Token(Token = "0x4000B17")]
	public float hamsterHeight; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000B18")]
	public float hamsterBodyScale; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000B19")]
	public float hamsterOverlap; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000B1A")]
	public Vector2 hamsterOffset; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Header("히어로 등장 애니 — 분리 레이어(UI/review_hamster_body + review_petal + review_bubble)가 있을 때만")]
	[Token(Token = "0x4000B1B")]
	public int petalCount; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000B1C")]
	public float petalFanAngle; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000B1D")]
	public float petalLength; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000B1E")]
	public float petalCenterScale; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000B1F")]
	public float petalRingRadius; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4000B20")]
	public Vector2 petalRingStretch; //Field offset: 0x8C
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000B21")]
	public Vector2 petalCenter; //Field offset: 0x94
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x4000B22")]
	public float petalStagger; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000B23")]
	public float bubbleSize; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000B24")]
	public Vector2 bubbleOffset; //Field offset: 0xA4
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4000B25")]
	public float bubbleDelay; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Header("별점 카드(UI/PopupPanelInner)")]
	[Token(Token = "0x4000B26")]
	public Vector2 boxSize; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000B27")]
	public float boxY; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x4000B28")]
	public float boxPpum; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000B29")]
	public Color boxColor; //Field offset: 0xC0
	[FieldOffset(Offset = "0xD0")]
	[Header("별(UI/star_on, 없으면 회색 틴트로 off 상태)")]
	[Token(Token = "0x4000B2A")]
	public float starSize; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x4000B2B")]
	public float starGap; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000B2C")]
	public float starTopPad; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000B2D")]
	public Color starOffTint; //Field offset: 0xDC
	[FieldOffset(Offset = "0xEC")]
	[Header("본문")]
	[Token(Token = "0x4000B2E")]
	public float bodyFontSize; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000B2F")]
	public float bodyBottomPad; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000B30")]
	public Color bodyColor; //Field offset: 0xF4
	[FieldOffset(Offset = "0x104")]
	[Range(-30, 40)]
	[Token(Token = "0x4000B31")]
	public float bodyLineSpacing; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Header("별 탭 스파클")]
	[Token(Token = "0x4000B32")]
	public int starBurstCount; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4000B33")]
	public float starBurstSpread; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Header("별 자동 채움(등장 연출) — 1~4 빠르게, 5번째 쾅")]
	[Token(Token = "0x4000B34")]
	public float starAutoFillDelay; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4000B35")]
	public float starAutoFillStep; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4000B36")]
	public float starAutoFillPause; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4000B37")]
	public float starFinalPunch; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Header("CTA 버튼(btn_pill_cream 틴트 — 새시즌 팝업과 같은 오렌지)")]
	[Token(Token = "0x4000B38")]
	public Vector2 btnSize; //Field offset: 0x120
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000B39")]
	public float btnBottomPad; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x4000B3A")]
	public float btnFontSize; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000B3B")]
	public Color btnTint; //Field offset: 0x130
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000B3C")]
	public Color btnLabelGlow; //Field offset: 0x140
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x4000B3D")]
	public Color btnShadowColor; //Field offset: 0x150
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x4000B3E")]
	public float btnShadowAlpha; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Token(Token = "0x4000B3F")]
	public float btnShadowSpread; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x4000B40")]
	public int btnShadowLayers; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x4000B41")]
	public Vector2 btnShadowOffset; //Field offset: 0x16C
	[FieldOffset(Offset = "0x174")]
	[Header("피드백 스텝(저평점)")]
	[Token(Token = "0x4000B42")]
	public Vector2 fieldSize; //Field offset: 0x174
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x4000B43")]
	public float fieldY; //Field offset: 0x17C
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x4000B44")]
	public float step2TitleTopPad; //Field offset: 0x180
	[FieldOffset(Offset = "0x184")]
	[Token(Token = "0x4000B45")]
	public float step2TitleFontSize; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x4000B46")]
	public float panelLift; //Field offset: 0x188

	[Address(RVA = "0x3427A4C", Offset = "0x3427A4C", Length = "0x1C8")]
	[Token(Token = "0x60004BB")]
	public ReviewPromptConfig() { }

	[Address(RVA = "0x3427908", Offset = "0x3427908", Length = "0x144")]
	[Token(Token = "0x60004BA")]
	public static ReviewPromptConfig Load() { }

}

