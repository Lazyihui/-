namespace Hamdoku.UI;

[RequireComponent(typeof(RectTransform))]
[Token(Token = "0x20000C7")]
public sealed class SoftShadow : MonoBehaviour
{
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4000C5F")]
	[Tooltip("블러 라운드 스프라이트. 비우면 Resources/ui_soft_shadow 사용")]
	private Sprite shadowSprite; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4000C60")]
	[Tooltip("그림자 색(알파 포함). 씬에 SoftShadowController가 있으면 그쪽 색이 우선")]
	private Color color; //Field offset: 0x28
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4000C61")]
	[Tooltip("패널 가장자리 밖으로 퍼지는 폭(px). 컨트롤러의 spreadScale이 곱해진다")]
	private float spread; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[SerializeField]
	[Token(Token = "0x4000C62")]
	[Tooltip("그림자 오프셋(px). (0,0)=사방 균일")]
	private Vector2 offset; //Field offset: 0x3C
	[FieldOffset(Offset = "0x44")]
	[SerializeField]
	[Token(Token = "0x4000C63")]
	[Tooltip("씬의 SoftShadowController(색/퍼짐 배율)를 무시하고 이 컴포넌트 값만 쓴다. 씬마다 그림자 톤이 달라지면 안 되는 화면(상점 등)에서 켠다")]
	private bool overrideGlobal; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000C64")]
	private RectTransform _shadow; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000C65")]
	private Image _img; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000C66")]
	private CanvasGroup _cg; //Field offset: 0x58

	[Address(RVA = "0x3433218", Offset = "0x3433218", Length = "0x6C")]
	[Token(Token = "0x600054A")]
	public SoftShadow() { }

	[Address(RVA = "0x3432730", Offset = "0x3432730", Length = "0x170")]
	[Token(Token = "0x6000544")]
	public static SoftShadow Attach(GameObject go, float spread, Nullable<Color> color = null, Nullable<Vector2> offset = null, bool overrideGlobal = false) { }

	[Address(RVA = "0x34328B8", Offset = "0x34328B8", Length = "0x448")]
	[Token(Token = "0x6000548")]
	private void EnsureShadow() { }

	[Address(RVA = "0x3433214", Offset = "0x3433214", Length = "0x4")]
	[Token(Token = "0x6000547")]
	private void LateUpdate() { }

	[Address(RVA = "0x343313C", Offset = "0x343313C", Length = "0xD8")]
	[Token(Token = "0x6000546")]
	private void OnDisable() { }

	[Address(RVA = "0x34328A0", Offset = "0x34328A0", Length = "0x18")]
	[Token(Token = "0x6000545")]
	private void OnEnable() { }

	[Address(RVA = "0x3432D00", Offset = "0x3432D00", Length = "0x43C")]
	[Token(Token = "0x6000549")]
	private void Sync() { }

}

