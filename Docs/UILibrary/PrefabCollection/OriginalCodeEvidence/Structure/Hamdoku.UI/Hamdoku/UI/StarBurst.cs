namespace Hamdoku.UI;

[Token(Token = "0x20000C9")]
public sealed class StarBurst : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20000CC")]
	private sealed class <Run>d__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000C7B")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000C7C")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000C7D")]
		public float cellW; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000C7E")]
		public float spread; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000C7F")]
		public float sizeScale; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000C80")]
		public float innerRatio; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000C81")]
		public int count; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000C82")]
		public StarBurst <>4__this; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000C83")]
		public bool trail; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000C84")]
		private List<Piece> <pieces>5__2; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000C85")]
		private List<Ghost> <ghosts>5__3; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000C86")]
		private float[] <lastGhost>5__4; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x4000C87")]
		private float <t>5__5; //Field offset: 0x60

		[Token(Token = "0x170000D2")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x34351A0", Offset = "0x34351A0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000562")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170000D3")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x34351E0", Offset = "0x34351E0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000564")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x3433E60", Offset = "0x3433E60", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600055F")]
		public <Run>d__14(int <>1__state) { }

		[Address(RVA = "0x3434698", Offset = "0x3434698", Length = "0xB08")]
		[Token(Token = "0x6000561")]
		private bool MoveNext() { }

		[Address(RVA = "0x34351A0", Offset = "0x34351A0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000562")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x34351E0", Offset = "0x34351E0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000564")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x34351A8", Offset = "0x34351A8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000563")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3434694", Offset = "0x3434694", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000560")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x20000CB")]
	private sealed class Ghost
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000C77")]
		public RectTransform rt; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000C78")]
		public Image img; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000C79")]
		public float born; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000C7A")]
		public float scale; //Field offset: 0x24

		[Address(RVA = "0x3434328", Offset = "0x3434328", Length = "0x8")]
		[Token(Token = "0x600055E")]
		public Ghost() { }

	}

	[Token(Token = "0x20000CA")]
	private sealed class Piece
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000C71")]
		public RectTransform rt; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000C72")]
		public Image img; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000C73")]
		public Vector2 dir; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000C74")]
		public float inner; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000C75")]
		public float radius; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000C76")]
		public float spin; //Field offset: 0x30

		[Address(RVA = "0x343468C", Offset = "0x343468C", Length = "0x8")]
		[Token(Token = "0x600055D")]
		public Piece() { }

	}

	[Token(Token = "0x4000C6A")]
	private static Sprite _star; //Field offset: 0x0
	[Token(Token = "0x4000C6D")]
	private const float GhostEvery = 0.016; //Field offset: 0x0
	[Token(Token = "0x4000C6E")]
	private const float GhostLife = 0.3; //Field offset: 0x0
	[Token(Token = "0x4000C6F")]
	private const float GhostAlpha = 0.4; //Field offset: 0x0
	[Token(Token = "0x4000C6B")]
	private static Color _tint; //Field offset: 0x8
	[Token(Token = "0x4000C6C")]
	private static readonly Color StarColor; //Field offset: 0x18
	[Token(Token = "0x4000C70")]
	private static readonly Color GhostColor; //Field offset: 0x28

	[Token(Token = "0x170000D0")]
	public static Sprite StarSprite
	{
		[Address(RVA = "0x3433488", Offset = "0x3433488", Length = "0x5C")]
		[Token(Token = "0x6000552")]
		 get { } //Length: 92
	}

	[Token(Token = "0x170000D1")]
	public static Color StarTint
	{
		[Address(RVA = "0x3433920", Offset = "0x3433920", Length = "0x60")]
		[Token(Token = "0x6000553")]
		 get { } //Length: 96
	}

	[Address(RVA = "0x3434620", Offset = "0x3434620", Length = "0x6C")]
	[Token(Token = "0x600055C")]
	private static StarBurst() { }

	[Address(RVA = "0x3434618", Offset = "0x3434618", Length = "0x8")]
	[Token(Token = "0x600055B")]
	public StarBurst() { }

	[Address(RVA = "0x343452C", Offset = "0x343452C", Length = "0x30")]
	[Token(Token = "0x6000558")]
	private static float EaseOutBack(float p, float s) { }

	[Address(RVA = "0x34334E4", Offset = "0x34334E4", Length = "0x43C")]
	[Token(Token = "0x6000559")]
	private static void EnsureStar() { }

	[Address(RVA = "0x3433488", Offset = "0x3433488", Length = "0x5C")]
	[Token(Token = "0x6000552")]
	public static Sprite get_StarSprite() { }

	[Address(RVA = "0x3433920", Offset = "0x3433920", Length = "0x60")]
	[Token(Token = "0x6000553")]
	public static Color get_StarTint() { }

	[Address(RVA = "0x343455C", Offset = "0x343455C", Length = "0xBC")]
	[Token(Token = "0x600055A")]
	private static bool InPoly(Vector2 p, Vector2[] poly) { }

	[Address(RVA = "0x3433980", Offset = "0x3433980", Length = "0x430")]
	[Token(Token = "0x6000554")]
	public static void Play(RectTransform around, int count = 5, int sortingOrder = 3, float spread = 1, bool trail = false, float innerRatio = 0, float sizeScale = 1) { }

	[Address(RVA = "0x3433DB0", Offset = "0x3433DB0", Length = "0xB0")]
	[IteratorStateMachine(typeof(<Run>d__14))]
	[Token(Token = "0x6000555")]
	private IEnumerator Run(int count, float cellW, float spread, bool trail, float innerRatio, float sizeScale) { }

	[Address(RVA = "0x3433E88", Offset = "0x3433E88", Length = "0x4A0")]
	[Token(Token = "0x6000556")]
	private void SpawnGhost(List<Ghost> ghosts, Piece pc, float now) { }

	[Address(RVA = "0x3434330", Offset = "0x3434330", Length = "0x1FC")]
	[Token(Token = "0x6000557")]
	private static void UpdateGhosts(List<Ghost> ghosts, float now) { }

}

