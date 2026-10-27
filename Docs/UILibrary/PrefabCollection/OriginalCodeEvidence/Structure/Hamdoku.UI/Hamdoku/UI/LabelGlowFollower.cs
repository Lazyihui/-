namespace Hamdoku.UI;

[Token(Token = "0x200007B")]
public sealed class LabelGlowFollower : MonoBehaviour
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000696")]
	public TMP_Text source; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000697")]
	public bool forceGlow; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000698")]
	private TMP_Text _self; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000699")]
	private Material _mat; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400069A")]
	private bool _rectSynced; //Field offset: 0x40

	[Token(Token = "0x1700008F")]
	internal TMP_Text Text
	{
		[Address(RVA = "0x340D81C", Offset = "0x340D81C", Length = "0x18")]
		[Token(Token = "0x600037E")]
		 get { } //Length: 24
	}

	[Address(RVA = "0x340E114", Offset = "0x340E114", Length = "0x8")]
	[Token(Token = "0x6000384")]
	public LabelGlowFollower() { }

	[Address(RVA = "0x340D834", Offset = "0x340D834", Length = "0x140")]
	[Token(Token = "0x600037F")]
	private void EnsureSelf() { }

	[Address(RVA = "0x340D81C", Offset = "0x340D81C", Length = "0x18")]
	[Token(Token = "0x600037E")]
	internal TMP_Text get_Text() { }

	[Address(RVA = "0x340E07C", Offset = "0x340E07C", Length = "0x8")]
	[Token(Token = "0x6000381")]
	private void LateUpdate() { }

	[Address(RVA = "0x340E084", Offset = "0x340E084", Length = "0x90")]
	[Token(Token = "0x6000383")]
	private void OnDestroy() { }

	[Address(RVA = "0x340D5B8", Offset = "0x340D5B8", Length = "0x264")]
	[Token(Token = "0x6000380")]
	internal void SetStyle(Color color, float width, float softness, float dilate) { }

	[Address(RVA = "0x340D974", Offset = "0x340D974", Length = "0x708")]
	[Token(Token = "0x6000382")]
	private void Sync(bool force) { }

}

