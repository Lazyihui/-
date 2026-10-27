namespace Hamdoku.UI;

[DisallowMultipleComponent]
[Token(Token = "0x200009C")]
public sealed class PopupFitWatcher : MonoBehaviour
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40007EC")]
	private RectTransform _content; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40007ED")]
	private Vector2 _contentSize; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40007EE")]
	private float _wideScale; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x40007EF")]
	private float _margin; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40007F0")]
	private Vector2Int _lastScreen; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40007F1")]
	private Rect _lastSafeArea; //Field offset: 0x40
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40007F2")]
	private int _countdown; //Field offset: 0x50

	[Address(RVA = "0x341B42C", Offset = "0x341B42C", Length = "0x14")]
	[Token(Token = "0x600042B")]
	public PopupFitWatcher() { }

	[Address(RVA = "0x341B0F4", Offset = "0x341B0F4", Length = "0x164")]
	[Token(Token = "0x6000427")]
	public static void Attach(GameObject root, RectTransform content, Vector2 contentSize, float wideScale, float margin) { }

	[Address(RVA = "0x341B2A4", Offset = "0x341B2A4", Length = "0x4")]
	[Token(Token = "0x6000428")]
	private void OnEnable() { }

	[Address(RVA = "0x341B258", Offset = "0x341B258", Length = "0x4C")]
	[Token(Token = "0x6000429")]
	private void Snapshot() { }

	[Address(RVA = "0x341B2A8", Offset = "0x341B2A8", Length = "0x184")]
	[Token(Token = "0x600042A")]
	private void Update() { }

}

