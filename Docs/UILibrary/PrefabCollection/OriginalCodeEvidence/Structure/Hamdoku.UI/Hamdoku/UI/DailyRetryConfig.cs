namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "DailyRetryConfig", menuName = "Hamdoku/Daily Retry Config")]
[Token(Token = "0x2000032")]
public sealed class DailyRetryConfig : ScriptableObject
{
	[Token(Token = "0x40001FD")]
	private static DailyRetryConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("패널(UI/PopupPanel). 내용은 850×1200 기준으로 조립하고 패널 크기에 맞춰 균일 축소")]
	[Token(Token = "0x40001CC")]
	public Vector2 panelSize; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40001CD")]
	public float panelPpum; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40001CE")]
	public float contentShiftY; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Header("제목")]
	[Token(Token = "0x40001CF")]
	public float titleY; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40001D0")]
	public float titleFontSize; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40001D1")]
	public Color titleColor; //Field offset: 0x30
	[FieldOffset(Offset = "0x40")]
	[Header("히어로(햄스터). 스프라이트는 Resources 경로 — 기본은 머리띠 햄스터(UI/DailyRetry/daily_retry_hamster, 없으면 Mascot). heroFrame을 켜면 뒤에 액자(UI/PopupPanelInner)")]
	[Token(Token = "0x40001D2")]
	public string heroSpritePath; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40001D3")]
	public bool heroFrame; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40001D4")]
	public Vector2 heroSize; //Field offset: 0x4C
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x40001D5")]
	public float heroY; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40001D6")]
	public Color heroBgColor; //Field offset: 0x58
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40001D7")]
	public float heroPpum; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40001D8")]
	public float heroHamsterHeight; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40001D9")]
	public Vector2 heroHamsterOffset; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Range(0, 0.08)]
	[Token(Token = "0x40001DA")]
	public float heroBreathAmount; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x40001DB")]
	public float heroBreathPeriod; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Range(0, 8)]
	[Token(Token = "0x40001DC")]
	public int heroSparkleCount; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x40001DD")]
	public float heroSparkleSize; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40001DE")]
	public Color heroSparkleColor; //Field offset: 0x88
	[FieldOffset(Offset = "0x98")]
	[Header("설명 — 최고 기록 줄(스톱워치 아이콘 + 시간) + 한마디")]
	[Token(Token = "0x40001DF")]
	public float recordY; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x40001E0")]
	public float recordFontSize; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40001E1")]
	public Color recordLabelColor; //Field offset: 0xA0
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40001E2")]
	public Color recordTimeColor; //Field offset: 0xB0
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40001E3")]
	public float recordIconSize; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x40001E4")]
	public float recordIconGap; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40001E5")]
	public float descY; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x40001E6")]
	public Vector2 descSize; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x40001E7")]
	public float descFontSize; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40001E8")]
	public Color descColor; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE8")]
	[Header("버튼(위=광고 보고 다시 시도, 아래=닫기)")]
	[Token(Token = "0x40001E9")]
	public Vector2 btnSize; //Field offset: 0xE8
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40001EA")]
	public Vector2 btnSize2; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40001EB")]
	public float btnY; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x40001EC")]
	public float btnGap; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x40001ED")]
	public float btnCornerScale; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x40001EE")]
	public float btnFontSize; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40001EF")]
	public Color btnTint; //Field offset: 0x108
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40001F0")]
	public Color btnTintAlt; //Field offset: 0x118
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40001F1")]
	public Color btnLabelColorAlt; //Field offset: 0x128
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40001F2")]
	public Color btnLabelGlow; //Field offset: 0x138
	[FieldOffset(Offset = "0x148")]
	[Range(0, 0.5)]
	[Token(Token = "0x40001F3")]
	public float btnShadowAlpha; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x40001F4")]
	public float btnShadowSpread; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40001F5")]
	public int btnShadowLayers; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x40001F6")]
	public Vector2 btnShadowOffset; //Field offset: 0x154
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40001F7")]
	public Vector2 adIconSize; //Field offset: 0x15C
	[FieldOffset(Offset = "0x164")]
	[Token(Token = "0x40001F8")]
	public float adIconInset; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40001F9")]
	public float adIconGap; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x40001FA")]
	public bool adBadge; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40001FB")]
	public Vector2 adBadgeSize; //Field offset: 0x170
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40001FC")]
	public Vector2 adBadgeOffset; //Field offset: 0x178

	[Address(RVA = "0x33EBAA4", Offset = "0x33EBAA4", Length = "0x1A0")]
	[Token(Token = "0x60001AD")]
	public DailyRetryConfig() { }

	[Address(RVA = "0x33EB960", Offset = "0x33EB960", Length = "0x144")]
	[Token(Token = "0x60001AC")]
	public static DailyRetryConfig Load() { }

}

