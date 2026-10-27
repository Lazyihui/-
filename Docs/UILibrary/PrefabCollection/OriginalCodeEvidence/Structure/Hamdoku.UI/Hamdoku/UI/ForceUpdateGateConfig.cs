namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "ForceUpdateGateConfig", menuName = "Hamdoku/Force Update Gate Config")]
[Token(Token = "0x2000040")]
public sealed class ForceUpdateGateConfig : ScriptableObject
{
	[Token(Token = "0x400045B")]
	private static ForceUpdateGateConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("패널(UI/PopupPanel)")]
	[Token(Token = "0x4000442")]
	public Vector2 panelSize; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000443")]
	public float panelPpum; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Header("타이틀")]
	[Token(Token = "0x4000444")]
	public float titleY; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000445")]
	public float titleFontSize; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000446")]
	public Color titleColor; //Field offset: 0x2C
	[FieldOffset(Offset = "0x3C")]
	[Header("마스코트(Resources/Mascot)")]
	[Token(Token = "0x4000447")]
	public float mascotY; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000448")]
	public float mascotHeight; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000449")]
	public Vector2 mascotOffset; //Field offset: 0x44
	[FieldOffset(Offset = "0x4C")]
	[Header("본문")]
	[Token(Token = "0x400044A")]
	public float bodyY; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400044B")]
	public Vector2 bodySize; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400044C")]
	public float bodyFontSize; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400044D")]
	public Color bodyColor; //Field offset: 0x5C
	[FieldOffset(Offset = "0x6C")]
	[Range(-30, 40)]
	[Token(Token = "0x400044E")]
	public float bodyLineSpacing; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Header("버튼(btn_pill_cream 틴트 — 스트릭/새시즌 팝업과 같은 오렌지)")]
	[Token(Token = "0x400044F")]
	public Vector2 btnSize; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000450")]
	public float btnY; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000451")]
	public float btnFontSize; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000452")]
	public float btnCornerScale; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000453")]
	public Color btnTint; //Field offset: 0x84
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000454")]
	public Color btnLabelColor; //Field offset: 0x94
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000455")]
	public Color btnLabelGlow; //Field offset: 0xA4
	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4000456")]
	public Color btnShadowColor; //Field offset: 0xB4
	[FieldOffset(Offset = "0xC4")]
	[Range(0, 1)]
	[Token(Token = "0x4000457")]
	public float btnShadowAlpha; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000458")]
	public float btnShadowSpread; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Range(1, 8)]
	[Token(Token = "0x4000459")]
	public int btnShadowLayers; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400045A")]
	public Vector2 btnShadowOffset; //Field offset: 0xD0

	[Address(RVA = "0x33F148C", Offset = "0x33F148C", Length = "0x10C")]
	[Token(Token = "0x60001D8")]
	public ForceUpdateGateConfig() { }

	[Address(RVA = "0x33F1000", Offset = "0x33F1000", Length = "0x48C")]
	[Token(Token = "0x60001D7")]
	public int LayoutHash() { }

	[Address(RVA = "0x33F0EBC", Offset = "0x33F0EBC", Length = "0x144")]
	[Token(Token = "0x60001D6")]
	public static ForceUpdateGateConfig Load() { }

}

