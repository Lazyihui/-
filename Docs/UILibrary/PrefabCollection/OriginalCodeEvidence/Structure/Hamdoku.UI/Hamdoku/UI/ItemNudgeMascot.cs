namespace Hamdoku.UI;

[Token(Token = "0x2000078")]
public sealed class ItemNudgeMascot : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000079")]
	private sealed class <>c__DisplayClass31_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000690")]
		public ItemNudgeMascot <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000691")]
		public ItemNudgeFxConfig cfg; //Field offset: 0x18

		[Address(RVA = "0x340C340", Offset = "0x340C340", Length = "0x8")]
		[Token(Token = "0x600036F")]
		public <>c__DisplayClass31_0() { }

		[Address(RVA = "0x340CB6C", Offset = "0x340CB6C", Length = "0x18")]
		[Token(Token = "0x6000370")]
		internal float <Play>b__0() { }

		[Address(RVA = "0x340CB84", Offset = "0x340CB84", Length = "0x18")]
		[Token(Token = "0x6000371")]
		internal void <Play>b__1(float v) { }

		[Address(RVA = "0x340CB9C", Offset = "0x340CB9C", Length = "0x1C")]
		[Token(Token = "0x6000372")]
		internal void <Play>b__2() { }

		[Address(RVA = "0x340CBB8", Offset = "0x340CBB8", Length = "0x40")]
		[Token(Token = "0x6000373")]
		internal void <Play>b__3() { }

		[Address(RVA = "0x340CBF8", Offset = "0x340CBF8", Length = "0x80")]
		[Token(Token = "0x6000374")]
		internal void <Play>b__4() { }

		[Address(RVA = "0x340CC78", Offset = "0x340CC78", Length = "0x18")]
		[Token(Token = "0x6000375")]
		internal void <Play>b__5() { }

		[Address(RVA = "0x340CC90", Offset = "0x340CC90", Length = "0x18")]
		[Token(Token = "0x6000376")]
		internal float <Play>b__6() { }

		[Address(RVA = "0x340CCA8", Offset = "0x340CCA8", Length = "0x18")]
		[Token(Token = "0x6000377")]
		internal void <Play>b__7(float v) { }

		[Address(RVA = "0x340CCC0", Offset = "0x340CCC0", Length = "0xA8")]
		[Token(Token = "0x6000378")]
		internal void <Play>b__8() { }

	}

	[Token(Token = "0x4000676")]
	private const string SpriteDir = "UI/ItemNudge/"; //Field offset: 0x0
	[Token(Token = "0x4000677")]
	private const float EdgeFromBottom = 0.176; //Field offset: 0x0
	[Token(Token = "0x4000678")]
	private const float ContentWidth = 0.91; //Field offset: 0x0
	[Token(Token = "0x4000679")]
	private static Sprite _base; //Field offset: 0x0
	[Token(Token = "0x400067A")]
	private static Sprite _aha; //Field offset: 0x8
	[Token(Token = "0x400067B")]
	private static Sprite _question; //Field offset: 0x10
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400067C")]
	private RectTransform _ham; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400067D")]
	private RectTransform _mark; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400067E")]
	private Image _hamImg; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400067F")]
	private Image _markImg; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000680")]
	private Sprite _icon; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000681")]
	private float _iconSide; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000682")]
	private float _upY; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000683")]
	private float _offX; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000684")]
	private Sequence _seq; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000685")]
	private Sequence _markFx; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000686")]
	private bool _dismissed; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000687")]
	private float _swayAngle; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000688")]
	private float _breathe; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000689")]
	private float _breathePeriod; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400068A")]
	private float _liveT; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400068B")]
	private float _liveAmp; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400068C")]
	private float _liveTarget; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x400068D")]
	private float _spring; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400068E")]
	private float _springVel; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x400068F")]
	private float _appear; //Field offset: 0x8C

	[Address(RVA = "0x340C9C4", Offset = "0x340C9C4", Length = "0x8")]
	[Token(Token = "0x600036A")]
	public ItemNudgeMascot() { }

	[Address(RVA = "0x340CAC0", Offset = "0x340CAC0", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x600036C")]
	private float <Dismiss>b__38_0() { }

	[Address(RVA = "0x340CAC8", Offset = "0x340CAC8", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x600036D")]
	private void <Dismiss>b__38_1(float v) { }

	[Address(RVA = "0x340CAD0", Offset = "0x340CAD0", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x600036E")]
	private void <Dismiss>b__38_2() { }

	[Address(RVA = "0x340C9CC", Offset = "0x340C9CC", Length = "0xF4")]
	[CompilerGenerated]
	[Token(Token = "0x600036B")]
	private void <Reveal>b__36_0() { }

	[Address(RVA = "0x340B8D4", Offset = "0x340B8D4", Length = "0x36C")]
	[Token(Token = "0x6000360")]
	private void Build(Vector2 size, Sprite icon, float outerSign, ItemNudgeFxConfig cfg) { }

	[Address(RVA = "0x3408F94", Offset = "0x3408F94", Length = "0x150")]
	[Token(Token = "0x600035F")]
	public static ItemNudgeMascot Create(RectTransform frontHost, Vector2 buttonSize, Sprite icon, float outerSign, ItemNudgeFxConfig cfg) { }

	[Address(RVA = "0x3409224", Offset = "0x3409224", Length = "0x29C")]
	[Token(Token = "0x6000369")]
	public void Dismiss() { }

	[Address(RVA = "0x34090E4", Offset = "0x34090E4", Length = "0x20")]
	[Token(Token = "0x600035D")]
	public static float DurationOf(ItemNudgeFxConfig cfg) { }

	[Address(RVA = "0x340C534", Offset = "0x340C534", Length = "0xC")]
	[Token(Token = "0x6000364")]
	private void Kick(float amount) { }

	[Address(RVA = "0x340B690", Offset = "0x340B690", Length = "0x244")]
	[Token(Token = "0x600035E")]
	private static bool LoadSprites() { }

	[Address(RVA = "0x340BC40", Offset = "0x340BC40", Length = "0x150")]
	[Token(Token = "0x6000361")]
	private static RectTransform NewImage(string name, Sprite sprite, out Image img, RectTransform parent) { }

	[Address(RVA = "0x340BD90", Offset = "0x340BD90", Length = "0x5B0")]
	[Token(Token = "0x6000362")]
	private void Play(ItemNudgeFxConfig cfg) { }

	[Address(RVA = "0x340C5E8", Offset = "0x340C5E8", Length = "0x204")]
	[Token(Token = "0x6000366")]
	private void PopQuestion() { }

	[Address(RVA = "0x340C7EC", Offset = "0x340C7EC", Length = "0x1D8")]
	[Token(Token = "0x6000367")]
	private void Reveal() { }

	[Address(RVA = "0x340C540", Offset = "0x340C540", Length = "0xA8")]
	[Token(Token = "0x6000365")]
	private void Swap(Sprite s, float squash) { }

	[Address(RVA = "0x340AB3C", Offset = "0x340AB3C", Length = "0x11C")]
	[Token(Token = "0x6000368")]
	public bool TryGetBounds(out Vector2 center, out Vector2 half) { }

	[Address(RVA = "0x340C348", Offset = "0x340C348", Length = "0x1EC")]
	[Token(Token = "0x6000363")]
	private void Update() { }

}

