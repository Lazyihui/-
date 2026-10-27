namespace Hamdoku.Managers;

[Token(Token = "0x20002B7")]
public sealed class TipPopup : MonoBehaviour
{
	[Token(Token = "0x40012E0")]
	private static readonly Color Overlay; //Field offset: 0x0
	[Token(Token = "0x40012E1")]
	private static readonly Color PanelCol; //Field offset: 0x10
	[Token(Token = "0x40012E2")]
	private static readonly Color TitleCol; //Field offset: 0x20
	[Token(Token = "0x40012E3")]
	private static readonly Color RowBg; //Field offset: 0x30
	[Token(Token = "0x40012E4")]
	private static readonly Color RowText; //Field offset: 0x40
	[Token(Token = "0x40012E5")]
	private static readonly Color CtrlText; //Field offset: 0x50
	[Token(Token = "0x40012E6")]
	private static readonly Color Divider; //Field offset: 0x60
	[Token(Token = "0x40012E7")]
	private static readonly Color GrayBtn; //Field offset: 0x70
	[Token(Token = "0x40012E8")]
	private static readonly Color BarCol; //Field offset: 0x80
	[Token(Token = "0x40012E9")]
	private static readonly Color OkBtn; //Field offset: 0x90
	[Token(Token = "0x40012EA")]
	private static readonly Color Dot1; //Field offset: 0xA0
	[Token(Token = "0x40012EB")]
	private static readonly Color Dot2; //Field offset: 0xB0
	[Token(Token = "0x40012EC")]
	private static readonly Color Dot3; //Field offset: 0xC0
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40012DD")]
	private GameObject _root; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40012DE")]
	private RectTransform _panel; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40012DF")]
	private RectTransform _canvas; //Field offset: 0x30

	[Token(Token = "0x170002B7")]
	public bool IsOpen
	{
		[Address(RVA = "0x32F4C58", Offset = "0x32F4C58", Length = "0x88")]
		[Token(Token = "0x60013B9")]
		 get { } //Length: 136
	}

	[Address(RVA = "0x32F6E18", Offset = "0x32F6E18", Length = "0x134")]
	[Token(Token = "0x60013C7")]
	private static TipPopup() { }

	[Address(RVA = "0x32F6E10", Offset = "0x32F6E10", Length = "0x8")]
	[Token(Token = "0x60013C6")]
	public TipPopup() { }

	[Address(RVA = "0x32F6F4C", Offset = "0x32F6F4C", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x60013C8")]
	private void <Build>b__22_0() { }

	[Address(RVA = "0x32F6F68", Offset = "0x32F6F68", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x60013C9")]
	private void <BuildCloseX>b__25_0() { }

	[Address(RVA = "0x32F4EE4", Offset = "0x32F4EE4", Length = "0x8FC")]
	[Token(Token = "0x60013BD")]
	private void Build() { }

	[Address(RVA = "0x32F5B40", Offset = "0x32F5B40", Length = "0x37C")]
	[Token(Token = "0x60013C0")]
	private void BuildCloseX() { }

	[Address(RVA = "0x32F4C58", Offset = "0x32F4C58", Length = "0x88")]
	[Token(Token = "0x60013B9")]
	public bool get_IsOpen() { }

	[Address(RVA = "0x32F4D08", Offset = "0x32F4D08", Length = "0x88")]
	[Token(Token = "0x60013BC")]
	public void Hide() { }

	[Address(RVA = "0x32F4C50", Offset = "0x32F4C50", Length = "0x8")]
	[Token(Token = "0x60013B8")]
	public void Init(RectTransform canvas) { }

	[Address(RVA = "0x32F63D4", Offset = "0x32F63D4", Length = "0x1A8")]
	[Token(Token = "0x60013C1")]
	private static void MakeBar(RectTransform parent, float deg) { }

	[Address(RVA = "0x32F6268", Offset = "0x32F6268", Length = "0x16C")]
	[Token(Token = "0x60013BF")]
	private void MakeCtrlLine(string text, float y) { }

	[Address(RVA = "0x32F5EBC", Offset = "0x32F5EBC", Length = "0x3AC")]
	[Token(Token = "0x60013BE")]
	private void MakeRuleRow(string text, Color dotColor, float y) { }

	[Address(RVA = "0x32F57E0", Offset = "0x32F57E0", Length = "0x360")]
	[Token(Token = "0x60013C2")]
	private void RefreshText() { }

	[Address(RVA = "0x32F6A64", Offset = "0x32F6A64", Length = "0x3AC")]
	[Token(Token = "0x60013C3")]
	private void SetCtrl(int index, string value) { }

	[Address(RVA = "0x32F6688", Offset = "0x32F6688", Length = "0x3DC")]
	[Token(Token = "0x60013C5")]
	private void SetRule(int index, string value) { }

	[Address(RVA = "0x32F657C", Offset = "0x32F657C", Length = "0x10C")]
	[Token(Token = "0x60013C4")]
	private void SetText(string childName, string value) { }

	[Address(RVA = "0x32F4D90", Offset = "0x32F4D90", Length = "0x154")]
	[Token(Token = "0x60013BB")]
	public void Show() { }

	[Address(RVA = "0x32F4CE0", Offset = "0x32F4CE0", Length = "0x28")]
	[Token(Token = "0x60013BA")]
	public void Toggle() { }

}

