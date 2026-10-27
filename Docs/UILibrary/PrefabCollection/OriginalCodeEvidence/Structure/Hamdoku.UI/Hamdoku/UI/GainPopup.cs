namespace Hamdoku.UI;

[Token(Token = "0x200004E")]
public sealed class GainPopup : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x200004F")]
	private sealed class <Run>d__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004C0")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40004C1")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40004C2")]
		public RectTransform rt; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40004C3")]
		public CanvasGroup cg; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40004C4")]
		public GainPopup <>4__this; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40004C5")]
		private Vector2 <basePos>5__2; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40004C6")]
		private float <e>5__3; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x40004C7")]
		private float <total>5__4; //Field offset: 0x44

		[Token(Token = "0x1700004E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33F8AD4", Offset = "0x33F8AD4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000224")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700004F")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33F8B14", Offset = "0x33F8B14", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000226")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33F868C", Offset = "0x33F868C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000221")]
		public <Run>d__7(int <>1__state) { }

		[Address(RVA = "0x33F8798", Offset = "0x33F8798", Length = "0x33C")]
		[Token(Token = "0x6000223")]
		private bool MoveNext() { }

		[Address(RVA = "0x33F8AD4", Offset = "0x33F8AD4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000224")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33F8B14", Offset = "0x33F8B14", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000226")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33F8ADC", Offset = "0x33F8ADC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000225")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33F8794", Offset = "0x33F8794", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000222")]
		private void System.IDisposable.Dispose() { }

	}

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40004BE")]
	private Material _mainMat; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40004BF")]
	private Material _shadowMat; //Field offset: 0x28

	[Address(RVA = "0x33F878C", Offset = "0x33F878C", Length = "0x8")]
	[Token(Token = "0x6000220")]
	public GainPopup() { }

	[Address(RVA = "0x33F7FF8", Offset = "0x33F7FF8", Length = "0x3C8")]
	[Token(Token = "0x600021D")]
	internal static TMP_Text MakeText(RectTransform parent, string text, float size, Color color) { }

	[Address(RVA = "0x33F86B4", Offset = "0x33F86B4", Length = "0xD8")]
	[Token(Token = "0x600021F")]
	private void OnDestroy() { }

	[Address(RVA = "0x33F847C", Offset = "0x33F847C", Length = "0x9C")]
	[IteratorStateMachine(typeof(<Run>d__7))]
	[Token(Token = "0x600021E")]
	private IEnumerator Run(RectTransform rt, CanvasGroup cg) { }

	[Address(RVA = "0x33F7A44", Offset = "0x33F7A44", Length = "0x5B4")]
	[Token(Token = "0x6000219")]
	public static void Show(RectTransform around, string text, Color color, float fontSize, float outlineWidth = 0.28) { }

	[Address(RVA = "0x33F8468", Offset = "0x33F8468", Length = "0x14")]
	[Token(Token = "0x600021A")]
	internal static Material StyleOutline(TMP_Text t, float outlineWidth) { }

	[Address(RVA = "0x33F8518", Offset = "0x33F8518", Length = "0x174")]
	[Token(Token = "0x600021B")]
	public static Material StyleOutline(TMP_Text t, float outlineWidth, Color outlineColor) { }

	[Address(RVA = "0x33F83C0", Offset = "0x33F83C0", Length = "0xA8")]
	[Token(Token = "0x600021C")]
	internal static Material StyleShadow(TMP_Text t) { }

}

