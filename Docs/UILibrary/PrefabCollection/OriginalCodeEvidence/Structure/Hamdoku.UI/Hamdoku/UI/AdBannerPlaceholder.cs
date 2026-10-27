namespace Hamdoku.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
[Token(Token = "0x2000004")]
public sealed class AdBannerPlaceholder : MonoBehaviour
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000006")]
	[Tooltip("배너 높이(dp). AppLovin MAX 표준 배너=50, 태블릿=90")]
	public float bannerHeightDp; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000007")]
	[Tooltip("0보다 크면 자동 환산 대신 이 캔버스 픽셀 높이를 그대로 쓴다(미세 조정용)")]
	public float heightOverrideCanvasPx; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000008")]
	[Tooltip("밴드 색(반투명)")]
	public Color tint; //Field offset: 0x28
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000009")]
	private Image _img; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400000A")]
	private RectTransform _rt; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400000B")]
	private TMP_Text _label; //Field offset: 0x48

	[Address(RVA = "0x33D1F10", Offset = "0x33D1F10", Length = "0x1C")]
	[Token(Token = "0x6000009")]
	public AdBannerPlaceholder() { }

	[Address(RVA = "0x33D1AD8", Offset = "0x33D1AD8", Length = "0x2CC")]
	[Token(Token = "0x6000007")]
	private void Apply() { }

	[Address(RVA = "0x33D1548", Offset = "0x33D1548", Length = "0x84")]
	[Token(Token = "0x6000003")]
	private void Awake() { }

	[Address(RVA = "0x33D1E10", Offset = "0x33D1E10", Length = "0x100")]
	[Token(Token = "0x6000008")]
	private float DpToCanvasPixels(float dp) { }

	[Address(RVA = "0x33D1698", Offset = "0x33D1698", Length = "0x440")]
	[Token(Token = "0x6000006")]
	private void EnsureLabel() { }

	[Address(RVA = "0x33D15CC", Offset = "0x33D15CC", Length = "0xCC")]
	[Token(Token = "0x6000004")]
	private void OnEnable() { }

	[Address(RVA = "0x33D1DA4", Offset = "0x33D1DA4", Length = "0x6C")]
	[Token(Token = "0x6000005")]
	private void Update() { }

}

