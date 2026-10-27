namespace Hamdoku.UI;

[Token(Token = "0x2000039")]
public sealed class DragSparkleTrail : MonoBehaviour
{
	[Token(Token = "0x200003B")]
	private sealed class Piece
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000402")]
		public RectTransform rt; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000403")]
		public Image img; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000404")]
		public Image halo; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000405")]
		public Image core; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000406")]
		public Color color; //Field offset: 0x30
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000407")]
		public float glow; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x4000408")]
		public float core01; //Field offset: 0x44
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000409")]
		public Vector2 from; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x400040A")]
		public Vector2 vel; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x400040B")]
		public float born; //Field offset: 0x58
		[FieldOffset(Offset = "0x5C")]
		[Token(Token = "0x400040C")]
		public float life; //Field offset: 0x5C
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x400040D")]
		public float size; //Field offset: 0x60
		[FieldOffset(Offset = "0x64")]
		[Token(Token = "0x400040E")]
		public float spin; //Field offset: 0x64
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x400040F")]
		public float rot0; //Field offset: 0x68
		[FieldOffset(Offset = "0x6C")]
		[Token(Token = "0x4000410")]
		public float twinkle; //Field offset: 0x6C
		[FieldOffset(Offset = "0x70")]
		[Token(Token = "0x4000411")]
		public float twFreq; //Field offset: 0x70
		[FieldOffset(Offset = "0x74")]
		[Token(Token = "0x4000412")]
		public float twPhase; //Field offset: 0x74
		[FieldOffset(Offset = "0x78")]
		[Token(Token = "0x4000413")]
		public bool alive; //Field offset: 0x78

		[Address(RVA = "0x33EE0B8", Offset = "0x33EE0B8", Length = "0x8")]
		[Token(Token = "0x60001C3")]
		public Piece() { }

	}

	[Token(Token = "0x200003A")]
	public struct Spec
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40003F7")]
		public float size; //Field offset: 0x0
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x40003F8")]
		public float life; //Field offset: 0x4
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40003F9")]
		public float drift; //Field offset: 0x8
		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x40003FA")]
		public float rise; //Field offset: 0xC
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003FB")]
		public float age; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x40003FC")]
		public Vector2 push; //Field offset: 0x14
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40003FD")]
		public float twinkle; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40003FE")]
		public float glow; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x40003FF")]
		public float glowScale; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000400")]
		public float core; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000401")]
		public bool dot; //Field offset: 0x2C

	}

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40003F3")]
	private readonly List<Piece> _pieces; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40003F4")]
	private int _maxPieces; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40003F5")]
	private int _next; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40003F6")]
	private int _aliveCount; //Field offset: 0x30

	[Token(Token = "0x17000045")]
	public RectTransform Rect
	{
		[Address(RVA = "0x33ED1C8", Offset = "0x33ED1C8", Length = "0x64")]
		[Token(Token = "0x60001B8")]
		 get { } //Length: 100
	}

	[Address(RVA = "0x33EE398", Offset = "0x33EE398", Length = "0x90")]
	[Token(Token = "0x60001C2")]
	public DragSparkleTrail() { }

	[Address(RVA = "0x33ED6FC", Offset = "0x33ED6FC", Length = "0x448")]
	[Token(Token = "0x60001BC")]
	private Piece Acquire() { }

	[Address(RVA = "0x33EDBFC", Offset = "0x33EDBFC", Length = "0x90")]
	[Token(Token = "0x60001BB")]
	public void Clear() { }

	[Address(RVA = "0x33ECEC4", Offset = "0x33ECEC4", Length = "0x304")]
	[Token(Token = "0x60001B7")]
	public static DragSparkleTrail Create(Canvas rootCanvas, int sortingOrder) { }

	[Address(RVA = "0x33EE368", Offset = "0x33EE368", Length = "0x30")]
	[Token(Token = "0x60001C1")]
	private static float EaseOutBack(float p, float s) { }

	[Address(RVA = "0x33ED240", Offset = "0x33ED240", Length = "0x4BC")]
	[Token(Token = "0x60001BA")]
	public void Emit(Vector2 pos, Color color, Spec spec) { }

	[Address(RVA = "0x33ED1C8", Offset = "0x33ED1C8", Length = "0x64")]
	[Token(Token = "0x60001B8")]
	public RectTransform get_Rect() { }

	[Address(RVA = "0x33EDC8C", Offset = "0x33EDC8C", Length = "0xB4")]
	[Token(Token = "0x60001BF")]
	private void Kill(Piece pc) { }

	[Address(RVA = "0x33EDD40", Offset = "0x33EDD40", Length = "0x378")]
	[Token(Token = "0x60001BD")]
	private static Image Layer(RectTransform parent, string name, Sprite sprite) { }

	[Address(RVA = "0x33EDB44", Offset = "0x33EDB44", Length = "0xB8")]
	[Token(Token = "0x60001BE")]
	private static void SetAlpha(Piece pc, float a) { }

	[Address(RVA = "0x33ED22C", Offset = "0x33ED22C", Length = "0x14")]
	[Token(Token = "0x60001B9")]
	public void SetMaxPieces(int max) { }

	[Address(RVA = "0x33EE0C0", Offset = "0x33EE0C0", Length = "0x2A8")]
	[Token(Token = "0x60001C0")]
	private void Update() { }

}

