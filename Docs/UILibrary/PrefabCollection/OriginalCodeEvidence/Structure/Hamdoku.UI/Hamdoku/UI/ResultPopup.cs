namespace Hamdoku.UI;

[Token(Token = "0x20000B1")]
public sealed class ResultPopup : MonoBehaviour
{
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4000B07")]
	[Tooltip("팝업 전체 루트(오버레이+패널). 켜고 끈다")]
	private GameObject root; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4000B08")]
	[Tooltip("확대 연출을 줄 패널 RectTransform")]
	private RectTransform panel; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x4000B09")]
	private TMP_Text titleText; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4000B0A")]
	private Button actionButton; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x4000B0B")]
	private TMP_Text actionLabel; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000B0C")]
	private Action _onAction; //Field offset: 0x48

	[Address(RVA = "0x34278E4", Offset = "0x34278E4", Length = "0x8")]
	[Token(Token = "0x60004B8")]
	public ResultPopup() { }

	[Address(RVA = "0x34278EC", Offset = "0x34278EC", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x60004B9")]
	private void <Awake>b__6_0() { }

	[Address(RVA = "0x34273C4", Offset = "0x34273C4", Length = "0x128")]
	[Token(Token = "0x60004B4")]
	private void Awake() { }

	[Address(RVA = "0x34274EC", Offset = "0x34274EC", Length = "0x184")]
	[Token(Token = "0x60004B5")]
	private void EnsureOverlaySorting() { }

	[Address(RVA = "0x342785C", Offset = "0x342785C", Length = "0x88")]
	[Token(Token = "0x60004B7")]
	public void Hide() { }

	[Address(RVA = "0x3427670", Offset = "0x3427670", Length = "0x1EC")]
	[Token(Token = "0x60004B6")]
	public void Show(string title, string buttonLabel, Action onAction) { }

}

