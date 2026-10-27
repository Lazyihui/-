namespace Hamdoku.UI;

[Token(Token = "0x2000012")]
public sealed class CellView : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
{
	[CompilerGenerated]
	[Token(Token = "0x2000013")]
	private sealed class <AppearRoutine>d__168 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000104")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000105")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000106")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000107")]
		public float delay; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000108")]
		private float <t>5__2; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000109")]
		private float <e>5__3; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x400010A")]
		private float <dur>5__4; //Field offset: 0x34

		[Token(Token = "0x17000020")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DF868", Offset = "0x33DF868", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60000FB")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000021")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DF8A8", Offset = "0x33DF8A8", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60000FD")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DDFDC", Offset = "0x33DDFDC", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60000F8")]
		public <AppearRoutine>d__168(int <>1__state) { }

		[Address(RVA = "0x33DF484", Offset = "0x33DF484", Length = "0x3E4")]
		[Token(Token = "0x60000FA")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DF868", Offset = "0x33DF868", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60000FB")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DF8A8", Offset = "0x33DF8A8", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60000FD")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DF870", Offset = "0x33DF870", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60000FC")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DF480", Offset = "0x33DF480", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60000F9")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000014")]
	private sealed class <AutoGlowIn>d__180 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400010B")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400010C")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400010D")]
		public bool sweepOnly; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400010E")]
		public CellView <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400010F")]
		public float delay; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000110")]
		private float <restGlow>5__2; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000111")]
		private float <restRim>5__3; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x4000112")]
		private float <d>5__4; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000113")]
		private float <t>5__5; //Field offset: 0x40

		[Token(Token = "0x17000022")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DFBE4", Offset = "0x33DFBE4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000101")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000023")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DFC24", Offset = "0x33DFC24", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000103")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DE6DC", Offset = "0x33DE6DC", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60000FE")]
		public <AutoGlowIn>d__180(int <>1__state) { }

		[Address(RVA = "0x33DF8B4", Offset = "0x33DF8B4", Length = "0x330")]
		[Token(Token = "0x6000100")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DFBE4", Offset = "0x33DFBE4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000101")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DFC24", Offset = "0x33DFC24", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000103")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DFBEC", Offset = "0x33DFBEC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000102")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DF8B0", Offset = "0x33DF8B0", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60000FF")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000015")]
	private sealed class <ConflictFlashRoutine>d__153 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000114")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000115")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000116")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000117")]
		private float <t>5__2; //Field offset: 0x28

		[Token(Token = "0x17000024")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DFD74", Offset = "0x33DFD74", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000107")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000025")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DFDB4", Offset = "0x33DFDB4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000109")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD528", Offset = "0x33DD528", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000104")]
		public <ConflictFlashRoutine>d__153(int <>1__state) { }

		[Address(RVA = "0x33DFC30", Offset = "0x33DFC30", Length = "0x144")]
		[Token(Token = "0x6000106")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DFD74", Offset = "0x33DFD74", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000107")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DFDB4", Offset = "0x33DFDB4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000109")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DFD7C", Offset = "0x33DFD7C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000108")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DFC2C", Offset = "0x33DFC2C", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000105")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000016")]
	private sealed class <DrawStroke>d__142 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000118")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000119")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400011A")]
		public RectTransform s; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400011B")]
		public CellView <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400011C")]
		private float <t>5__2; //Field offset: 0x30

		[Token(Token = "0x17000026")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DFEEC", Offset = "0x33DFEEC", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600010D")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000027")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DFF2C", Offset = "0x33DFF2C", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600010F")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD3E4", Offset = "0x33DD3E4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600010A")]
		public <DrawStroke>d__142(int <>1__state) { }

		[Address(RVA = "0x33DFDC0", Offset = "0x33DFDC0", Length = "0x12C")]
		[Token(Token = "0x600010C")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DFEEC", Offset = "0x33DFEEC", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600010D")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DFF2C", Offset = "0x33DFF2C", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600010F")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DFEF4", Offset = "0x33DFEF4", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600010E")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DFDBC", Offset = "0x33DFDBC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600010B")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000017")]
	private sealed class <DrawX>d__141 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400011D")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400011E")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400011F")]
		public CellView <>4__this; //Field offset: 0x20

		[Token(Token = "0x17000028")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E0050", Offset = "0x33E0050", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000113")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000029")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E0090", Offset = "0x33E0090", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000115")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD334", Offset = "0x33DD334", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000110")]
		public <DrawX>d__141(int <>1__state) { }

		[Address(RVA = "0x33DFF38", Offset = "0x33DFF38", Length = "0x118")]
		[Token(Token = "0x6000112")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E0050", Offset = "0x33E0050", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000113")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E0090", Offset = "0x33E0090", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000115")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E0058", Offset = "0x33E0058", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000114")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DFF34", Offset = "0x33DFF34", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000111")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000018")]
	private sealed class <FadeOutX>d__139 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000120")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000121")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000122")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000123")]
		private Color <a0>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000124")]
		private Color <b0>5__3; //Field offset: 0x38
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000125")]
		private Vector2 <posA>5__4; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000126")]
		private Vector2 <posB>5__5; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000127")]
		private float <t>5__6; //Field offset: 0x58

		[Token(Token = "0x1700002A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E05A4", Offset = "0x33E05A4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000119")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700002B")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E05E4", Offset = "0x33E05E4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600011B")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD248", Offset = "0x33DD248", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000116")]
		public <FadeOutX>d__139(int <>1__state) { }

		[Address(RVA = "0x33E009C", Offset = "0x33E009C", Length = "0x508")]
		[Token(Token = "0x6000118")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E05A4", Offset = "0x33E05A4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000119")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E05E4", Offset = "0x33E05E4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600011B")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E05AC", Offset = "0x33E05AC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600011A")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E0098", Offset = "0x33E0098", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000117")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000019")]
	private sealed class <HintPulse>d__184 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000128")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000129")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400012A")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400012B")]
		private float <t>5__2; //Field offset: 0x28

		[Token(Token = "0x1700002C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E06C4", Offset = "0x33E06C4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600011F")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700002D")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E0704", Offset = "0x33E0704", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000121")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DE8F4", Offset = "0x33DE8F4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600011C")]
		public <HintPulse>d__184(int <>1__state) { }

		[Address(RVA = "0x33E05F0", Offset = "0x33E05F0", Length = "0xD4")]
		[Token(Token = "0x600011E")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E06C4", Offset = "0x33E06C4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600011F")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E0704", Offset = "0x33E0704", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000121")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E06CC", Offset = "0x33E06CC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000120")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E05EC", Offset = "0x33E05EC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600011D")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001A")]
	private sealed class <LineWaveRoutine>d__194 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400012C")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400012D")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400012E")]
		public float delay; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400012F")]
		public CellView <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000130")]
		public float duration; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000131")]
		public float amplitude; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000132")]
		public float squash; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x4000133")]
		private float <t>5__2; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000134")]
		private float <e>5__3; //Field offset: 0x40

		[Token(Token = "0x1700002E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E09A4", Offset = "0x33E09A4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000125")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700002F")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E09E4", Offset = "0x33E09E4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000127")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DE9B4", Offset = "0x33DE9B4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000122")]
		public <LineWaveRoutine>d__194(int <>1__state) { }

		[Address(RVA = "0x33E0710", Offset = "0x33E0710", Length = "0x294")]
		[Token(Token = "0x6000124")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E09A4", Offset = "0x33E09A4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000125")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E09E4", Offset = "0x33E09E4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000127")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E09AC", Offset = "0x33E09AC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000126")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E070C", Offset = "0x33E070C", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000123")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001B")]
	private sealed class <MistakeRoutine>d__154 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000135")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000136")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000137")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000138")]
		private float <t>5__2; //Field offset: 0x28

		[Token(Token = "0x17000030")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E0E50", Offset = "0x33E0E50", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600012B")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000031")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E0E90", Offset = "0x33E0E90", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600012D")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD550", Offset = "0x33DD550", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000128")]
		public <MistakeRoutine>d__154(int <>1__state) { }

		[Address(RVA = "0x33E09F0", Offset = "0x33E09F0", Length = "0x460")]
		[Token(Token = "0x600012A")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E0E50", Offset = "0x33E0E50", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600012B")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E0E90", Offset = "0x33E0E90", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600012D")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E0E58", Offset = "0x33E0E58", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600012C")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E09EC", Offset = "0x33E09EC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000129")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001C")]
	private sealed class <PlaceRoutine>d__198 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000139")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400013A")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400013B")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400013C")]
		private float <t>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x400013D")]
		private float <dur>5__3; //Field offset: 0x2C

		[Token(Token = "0x17000032")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E0FF8", Offset = "0x33E0FF8", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000131")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000033")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E1038", Offset = "0x33E1038", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000133")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DEBB8", Offset = "0x33DEBB8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600012E")]
		public <PlaceRoutine>d__198(int <>1__state) { }

		[Address(RVA = "0x33E0E9C", Offset = "0x33E0E9C", Length = "0x15C")]
		[Token(Token = "0x6000130")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E0FF8", Offset = "0x33E0FF8", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000131")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E1038", Offset = "0x33E1038", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000133")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E1000", Offset = "0x33E1000", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000132")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E0E98", Offset = "0x33E0E98", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600012F")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001D")]
	private sealed class <PressRoutine>d__196 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400013E")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400013F")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000140")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000141")]
		private float <t>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000142")]
		private float <dur>5__3; //Field offset: 0x2C

		[Token(Token = "0x17000034")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E11A4", Offset = "0x33E11A4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000137")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000035")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E11E4", Offset = "0x33E11E4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000139")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DEB24", Offset = "0x33DEB24", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000134")]
		public <PressRoutine>d__196(int <>1__state) { }

		[Address(RVA = "0x33E1044", Offset = "0x33E1044", Length = "0x160")]
		[Token(Token = "0x6000136")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E11A4", Offset = "0x33E11A4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000137")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E11E4", Offset = "0x33E11E4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000139")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E11AC", Offset = "0x33E11AC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000138")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E1040", Offset = "0x33E1040", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000135")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001E")]
	private sealed class <PunchRoutine>d__156 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000143")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000144")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000145")]
		public float amp; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000146")]
		public float dur; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000147")]
		public CellView <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000148")]
		private float <t>5__2; //Field offset: 0x30

		[Token(Token = "0x17000036")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E1334", Offset = "0x33E1334", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600013D")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000037")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E1374", Offset = "0x33E1374", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600013F")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD6C4", Offset = "0x33DD6C4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600013A")]
		public <PunchRoutine>d__156(int <>1__state) { }

		[Address(RVA = "0x33E11F0", Offset = "0x33E11F0", Length = "0x144")]
		[Token(Token = "0x600013C")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E1334", Offset = "0x33E1334", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600013D")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E1374", Offset = "0x33E1374", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600013F")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E133C", Offset = "0x33E133C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600013E")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E11EC", Offset = "0x33E11EC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600013B")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200001F")]
	private sealed class <TintTo>d__155 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000149")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400014A")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400014B")]
		public CellView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400014C")]
		public Color target; //Field offset: 0x28
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400014D")]
		public float dur; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x400014E")]
		private Color <from>5__2; //Field offset: 0x3C
		[FieldOffset(Offset = "0x4C")]
		[Token(Token = "0x400014F")]
		private float <t>5__3; //Field offset: 0x4C

		[Token(Token = "0x17000038")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33E1528", Offset = "0x33E1528", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000143")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000039")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33E1568", Offset = "0x33E1568", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000145")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DD61C", Offset = "0x33DD61C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000140")]
		public <TintTo>d__155(int <>1__state) { }

		[Address(RVA = "0x33E1380", Offset = "0x33E1380", Length = "0x1A8")]
		[Token(Token = "0x6000142")]
		private bool MoveNext() { }

		[Address(RVA = "0x33E1528", Offset = "0x33E1528", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000143")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33E1568", Offset = "0x33E1568", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000145")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33E1530", Offset = "0x33E1530", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000144")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33E137C", Offset = "0x33E137C", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000141")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000103")]
	private const float WavePeakNorm = 1.965; //Field offset: 0x0
	[Token(Token = "0x4000102")]
	private const float WaveDecay = 3.2; //Field offset: 0x0
	[Token(Token = "0x40000D8")]
	private const float DragSampleRatio = 0.34; //Field offset: 0x0
	[Token(Token = "0x40000D9")]
	private const float DragActivateRatio = 0.45; //Field offset: 0x0
	[Token(Token = "0x40000DA")]
	private const int MaxDragSamples = 64; //Field offset: 0x0
	[Token(Token = "0x40000EC")]
	private const float CornerRefPixels = 180; //Field offset: 0x0
	[Token(Token = "0x40000EE")]
	private const float CornerBorderPixels = 22; //Field offset: 0x0
	[Token(Token = "0x40000F0")]
	private const float MistakeTintIn = 0.09; //Field offset: 0x0
	[Token(Token = "0x40000ED")]
	private const float CornerArcPixels = 22.75; //Field offset: 0x0
	[Token(Token = "0x40000F2")]
	private const float MistakeSplit = 0.3; //Field offset: 0x0
	[Token(Token = "0x40000F3")]
	private const float MistakeTintOut = 0.17; //Field offset: 0x0
	[Token(Token = "0x40000F4")]
	private const float HeartPivotY = 0.14; //Field offset: 0x0
	[Token(Token = "0x40000F5")]
	private const float HeartOpenAngle = 9; //Field offset: 0x0
	[Token(Token = "0x40000F6")]
	public const float MistakeSplitAt = 0.22; //Field offset: 0x0
	[Token(Token = "0x40000F7")]
	public const float MistakeFxDuration = 0.93; //Field offset: 0x0
	[Token(Token = "0x40000F8")]
	public const float AppearDuration = 0.32; //Field offset: 0x0
	[Token(Token = "0x40000F1")]
	private const float MistakePopTime = 0.13; //Field offset: 0x0
	[Token(Token = "0x40000C3")]
	private static CellView _tapCell; //Field offset: 0x0
	[Token(Token = "0x40000C4")]
	private static double _tapAt; //Field offset: 0x8
	[Token(Token = "0x40000C5")]
	private static bool _tapReleased; //Field offset: 0x10
	[Token(Token = "0x40000C6")]
	private static int _tapDeviceId; //Field offset: 0x14
	[Token(Token = "0x40000D6")]
	private static readonly List<RaycastResult> _rayResults; //Field offset: 0x18
	[Token(Token = "0x40000D7")]
	private static PointerEventData _probe; //Field offset: 0x20
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x40000A3")]
	[Tooltip("구역 색을 칠할 배경 이미지")]
	private Image background; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x40000A4")]
	[Tooltip("햄스터 표시용 라벨 (폴백: 애니메이터 없을 때만 'H' 표시)")]
	private TMP_Text label; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x40000A5")]
	[Tooltip("햄스터 스프라이트 애니메이터(등장/상시/틀림). 없으면 라벨 H로 폴백")]
	private HamsterAnimator hamster; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x40000A6")]
	[Tooltip("X 획 1 (둥근 막대)")]
	private RectTransform strokeA; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x40000A7")]
	[Tooltip("X 획 2 (둥근 막대)")]
	private RectTransform strokeB; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Token(Token = "0x40000A8")]
	private Color crossColor; //Field offset: 0x48
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	[Token(Token = "0x40000A9")]
	private Color mistakeColor; //Field offset: 0x58
	[FieldOffset(Offset = "0x68")]
	[Header("오답 연출")]
	[SerializeField]
	[Token(Token = "0x40000AA")]
	[Tooltip("실수한 칸이 잠깐 물드는 색(레퍼런스의 붉은 칸)")]
	private Color mistakeCellColor; //Field offset: 0x68
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	[Token(Token = "0x40000AB")]
	[Tooltip("원인이 된 기존 햄스터 칸이 잠깐 물드는 색(내 실수 칸과 구분되는 경고색)")]
	private Color conflictCellColor; //Field offset: 0x78
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	[Token(Token = "0x40000AC")]
	[Tooltip("쪼개지는 하트 반쪽 스프라이트(좌/우). 비우면 Resources/UI/Icons/icon_heart_break_l,_r 사용")]
	private Sprite heartBreakLeft; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	[Token(Token = "0x40000AD")]
	private Sprite heartBreakRight; //Field offset: 0x90
	[FieldOffset(Offset = "0x98")]
	[SerializeField]
	[Token(Token = "0x40000AE")]
	[Tooltip("하트 색(스프라이트가 흰 실루엣이라 이 색이 그대로 나온다)")]
	private Color heartBreakColor; //Field offset: 0x98
	[FieldOffset(Offset = "0xA8")]
	[Range(0.3, 1.2)]
	[SerializeField]
	[Token(Token = "0x40000AF")]
	[Tooltip("쪼개지는 하트 크기 = 칸 크기 대비 비율(1이면 칸을 꽉 채움)")]
	private float heartBreakScale; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Header("클리어 자동 X 강조 (테두리 + 안팎 발광)")]
	[SerializeField]
	[Token(Token = "0x40000B0")]
	[Tooltip("칸 경계에 놓이는 테두리 색")]
	private Color autoCrossRimColor; //Field offset: 0xAC
	[FieldOffset(Offset = "0xBC")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40000B1")]
	[Tooltip("테두리 진하기(0이면 테두리 없이 발광만)")]
	private float autoCrossRimAlpha; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[SerializeField]
	[Token(Token = "0x40000B2")]
	[Tooltip("테두리 안팎으로 번지는 빛 색")]
	private Color autoCrossGlowColor; //Field offset: 0xC0
	[FieldOffset(Offset = "0xD0")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40000B3")]
	[Tooltip("파동이 지나가는 순간의 빛 진하기(크레스트). 0이면 발광 없이 테두리만")]
	private float autoCrossGlowAlpha; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40000B4")]
	[Tooltip("파동이 지나간 뒤 남는 잔광 = 크레스트 × 이 배율. 1이면 안 잦아들어 파동이 안 느껴진다")]
	private float autoCrossGlowRest; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Range(0.02, 0.5)]
	[SerializeField]
	[Token(Token = "0x40000B5")]
	[Tooltip("빛이 크레스트까지 차오르는 시간(초). 짧아야 한 칸씩 '타닥' 하고 읽힌다")]
	private float autoCrossGlowFade; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Range(0.05, 1)]
	[SerializeField]
	[Token(Token = "0x40000B6")]
	[Tooltip("크레스트에서 잔광으로 잦아드는 시간(초)")]
	private float autoCrossGlowSettle; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Range(1, 1.4)]
	[SerializeField]
	[Token(Token = "0x40000B7")]
	[Tooltip("크레스트 순간 빛이 부풀는 정도(1이면 안 부품)")]
	private float autoCrossGlowPunch; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[SerializeField]
	[Token(Token = "0x40000B8")]
	[Tooltip("이 시간(초) 안에 두 번 누르면 더블탭으로 본다")]
	private float doubleTapThreshold; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[SerializeField]
	[Token(Token = "0x40000B9")]
	[Tooltip("한 획을 긋는 시간(초)")]
	private float strokeDrawTime; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40000BA")]
	[Tooltip("X를 해제할 때 흐려지며 사라지는 시간(초). 0이면 즉시 사라진다")]
	private float crossFadeOutTime; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Range(0.5, 1)]
	[SerializeField]
	[Token(Token = "0x40000BB")]
	[Tooltip("X가 사라지며 줄어드는 크기(1=그대로, 0.8=80%까지 작아짐)")]
	private float crossFadeOutScale; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Range(0.4, 1.1)]
	[SerializeField]
	[Token(Token = "0x40000BC")]
	[Tooltip("X 한 획의 길이 = 칸 크기 대비 비율. 대각선이라 X가 차지하는 폭은 이 값의 약 0.71배")]
	private float crossLengthRatio; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Range(0.06, 0.25)]
	[SerializeField]
	[Token(Token = "0x40000BD")]
	[Tooltip("X 획 두께 = 칸 크기 대비 비율")]
	private float crossThicknessRatio; //Field offset: 0xF8
	[CompilerGenerated]
	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x40000BE")]
	private int <Row>k__BackingField; //Field offset: 0xFC
	[CompilerGenerated]
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40000BF")]
	private int <Col>k__BackingField; //Field offset: 0x100
	[CompilerGenerated]
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40000C0")]
	private Action<CellView> Tapped; //Field offset: 0x108
	[CompilerGenerated]
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40000C1")]
	private Action<CellView> DoubleTapped; //Field offset: 0x110
	[CompilerGenerated]
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40000C2")]
	private Action<CellView, bool> DragPainted; //Field offset: 0x118
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40000C7")]
	private bool _pointerDown; //Field offset: 0x120
	[FieldOffset(Offset = "0x121")]
	[Token(Token = "0x40000C8")]
	private bool _routedPen; //Field offset: 0x121
	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x40000C9")]
	private int _pointerId; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40000CA")]
	private int _pointerDeviceId; //Field offset: 0x128
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40000CB")]
	private InputDevice _pressDevice; //Field offset: 0x130
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40000CC")]
	private TouchControl _pressTouch; //Field offset: 0x138
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40000CD")]
	private int _pressTouchId; //Field offset: 0x140
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40000CE")]
	private CellView _lastPaint; //Field offset: 0x148
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40000CF")]
	private bool _eraseMode; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x40000D0")]
	private Vector2 _dragFrom; //Field offset: 0x154
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40000D1")]
	private bool _hasDragFrom; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40000D2")]
	private Vector2 _pressPos; //Field offset: 0x160
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40000D3")]
	private bool _dragActive; //Field offset: 0x168
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40000D4")]
	private BoardView _boardView; //Field offset: 0x170
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40000D5")]
	private BoardPenInput _boardPen; //Field offset: 0x178
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40000DB")]
	private Image _imgA; //Field offset: 0x180
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40000DC")]
	private Image _imgB; //Field offset: 0x188
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40000DD")]
	private Image _hitArea; //Field offset: 0x190
	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x40000DE")]
	private RectTransform _visualRoot; //Field offset: 0x198
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x40000DF")]
	private CanvasGroup _cg; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x40000E0")]
	private float _cellWidth; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x40000E1")]
	private CellMark _mark; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x40000E2")]
	private Coroutine _xAnim; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x40000E3")]
	private Coroutine _mistakeFx; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x40000E4")]
	private Color _regionColor; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x40000E5")]
	private RectTransform _breakL; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x40000E6")]
	private RectTransform _breakR; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x40000E7")]
	private Image _breakImgL; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x40000E8")]
	private Image _breakImgR; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x40000E9")]
	private Coroutine _popFx; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x40000EA")]
	private Coroutine _hintFx; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x40000EB")]
	private Image _assistPattern; //Field offset: 0x200
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x40000EF")]
	private float _cornerScale; //Field offset: 0x208
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x40000F9")]
	private Image _autoGlow; //Field offset: 0x210
	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x40000FA")]
	private Image _autoRim; //Field offset: 0x218
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x40000FB")]
	private Coroutine _autoGlowFx; //Field offset: 0x220
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x40000FC")]
	private float _rimIntensity; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Token(Token = "0x40000FD")]
	private Color _rimGlowColor; //Field offset: 0x22C
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x40000FE")]
	private Coroutine _waveFx; //Field offset: 0x240
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x40000FF")]
	private bool _waveRunning; //Field offset: 0x248
	[FieldOffset(Offset = "0x24C")]
	[Token(Token = "0x4000100")]
	private float _waveDueTime; //Field offset: 0x24C
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x4000101")]
	private float _waveAmplitude; //Field offset: 0x250

	[Token(Token = "0x14000006")]
	public event Action<CellView> DoubleTapped
	{
		[Address(RVA = "0x33D4C44", Offset = "0x33D4C44", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A4")]
		 add { } //Length: 176
		[Address(RVA = "0x33DB414", Offset = "0x33DB414", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A5")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x14000007")]
	public event Action<CellView, bool> DragPainted
	{
		[Address(RVA = "0x33D4CF4", Offset = "0x33D4CF4", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A6")]
		 add { } //Length: 176
		[Address(RVA = "0x33DB4C4", Offset = "0x33DB4C4", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A7")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x14000005")]
	public event Action<CellView> Tapped
	{
		[Address(RVA = "0x33D4B94", Offset = "0x33D4B94", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A2")]
		 add { } //Length: 176
		[Address(RVA = "0x33DB364", Offset = "0x33DB364", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x60000A3")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x17000018")]
	public Color BackgroundColor
	{
		[Address(RVA = "0x33D8208", Offset = "0x33D8208", Length = "0x90")]
		[Token(Token = "0x6000099")]
		 get { } //Length: 144
	}

	[Token(Token = "0x17000016")]
	public int Col
	{
		[Address(RVA = "0x33DB328", Offset = "0x33DB328", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000096")]
		 get { } //Length: 8
		[Address(RVA = "0x33DB330", Offset = "0x33DB330", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000097")]
		private set { } //Length: 8
	}

	[Token(Token = "0x1700001F")]
	public float CornerRadiusRatio
	{
		[Address(RVA = "0x33D7F84", Offset = "0x33D7F84", Length = "0xE4")]
		[Token(Token = "0x60000BA")]
		 get { } //Length: 228
	}

	[Token(Token = "0x1700001C")]
	public float CrossLengthRatio
	{
		[Address(RVA = "0x33DB354", Offset = "0x33DB354", Length = "0x8")]
		[Token(Token = "0x600009D")]
		 get { } //Length: 8
	}

	[Token(Token = "0x1700001D")]
	public float CrossThicknessRatio
	{
		[Address(RVA = "0x33DB35C", Offset = "0x33DB35C", Length = "0x8")]
		[Token(Token = "0x600009E")]
		 get { } //Length: 8
	}

	[Token(Token = "0x1700001B")]
	public Sprite HamsterIdleSprite
	{
		[Address(RVA = "0x33D86EC", Offset = "0x33D86EC", Length = "0x88")]
		[Token(Token = "0x600009C")]
		 get { } //Length: 136
	}

	[Token(Token = "0x1700001E")]
	public RectTransform HamsterRect
	{
		[Address(RVA = "0x33D8820", Offset = "0x33D8820", Length = "0xB0")]
		[Token(Token = "0x600009F")]
		 get { } //Length: 176
	}

	[Token(Token = "0x1700001A")]
	public Sprite HamsterSprite
	{
		[Address(RVA = "0x33D8344", Offset = "0x33D8344", Length = "0x88")]
		[Token(Token = "0x600009B")]
		 get { } //Length: 136
	}

	[Token(Token = "0x17000017")]
	public CellMark Mark
	{
		[Address(RVA = "0x33DB338", Offset = "0x33DB338", Length = "0x8")]
		[Token(Token = "0x6000098")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000019")]
	public Color RegionColor
	{
		[Address(RVA = "0x33DB340", Offset = "0x33DB340", Length = "0x14")]
		[Token(Token = "0x600009A")]
		 get { } //Length: 20
	}

	[Token(Token = "0x17000015")]
	public int Row
	{
		[Address(RVA = "0x33DB318", Offset = "0x33DB318", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000094")]
		 get { } //Length: 8
		[Address(RVA = "0x33DB320", Offset = "0x33DB320", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000095")]
		private set { } //Length: 8
	}

	[Address(RVA = "0x33DF3E0", Offset = "0x33DF3E0", Length = "0xA0")]
	[Token(Token = "0x60000F7")]
	private static CellView() { }

	[Address(RVA = "0x33DF31C", Offset = "0x33DF31C", Length = "0xC4")]
	[Token(Token = "0x60000F6")]
	public CellView() { }

	[Address(RVA = "0x33D4C44", Offset = "0x33D4C44", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A4")]
	public void add_DoubleTapped(Action<CellView> value) { }

	[Address(RVA = "0x33D4CF4", Offset = "0x33D4CF4", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A6")]
	public void add_DragPainted(Action<CellView, bool> value) { }

	[Address(RVA = "0x33D4B94", Offset = "0x33D4B94", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A2")]
	public void add_Tapped(Action<CellView> value) { }

	[Address(RVA = "0x33DDF60", Offset = "0x33DDF60", Length = "0x7C")]
	[IteratorStateMachine(typeof(<AppearRoutine>d__168))]
	[Token(Token = "0x60000DB")]
	private IEnumerator AppearRoutine(float delay) { }

	[Address(RVA = "0x33DE704", Offset = "0x33DE704", Length = "0x184")]
	[Token(Token = "0x60000E3")]
	private void Apply(float glow, float rim) { }

	[Address(RVA = "0x33DCC14", Offset = "0x33DCC14", Length = "0x150")]
	[Token(Token = "0x60000BF")]
	private void ApplyAssistSizing() { }

	[Address(RVA = "0x33DE64C", Offset = "0x33DE64C", Length = "0x90")]
	[IteratorStateMachine(typeof(<AutoGlowIn>d__180))]
	[Token(Token = "0x60000E2")]
	private IEnumerator AutoGlowIn(float delay, bool sweepOnly = false) { }

	[Address(RVA = "0x33DB5FC", Offset = "0x33DB5FC", Length = "0x270")]
	[Token(Token = "0x60000A9")]
	private void Awake() { }

	[Address(RVA = "0x33D6F7C", Offset = "0x33D6F7C", Length = "0xB4")]
	[Token(Token = "0x60000B7")]
	public void CancelDoubleTapWindow() { }

	[Address(RVA = "0x33D3BB4", Offset = "0x33D3BB4", Length = "0x24")]
	[Token(Token = "0x60000B5")]
	internal void CancelPenContact() { }

	[Address(RVA = "0x33DBEC0", Offset = "0x33DBEC0", Length = "0x18")]
	[Token(Token = "0x60000B0")]
	private void CancelPointer() { }

	[Address(RVA = "0x33DD7C8", Offset = "0x33DD7C8", Length = "0xC0")]
	[Token(Token = "0x60000D2")]
	private float CellSize() { }

	[Address(RVA = "0x33DF074", Offset = "0x33DF074", Length = "0x2A8")]
	[Token(Token = "0x60000F5")]
	private static CellView CellUnder(Vector2 screenPos, PointerEventData src) { }

	[Address(RVA = "0x33DD0B0", Offset = "0x33DD0B0", Length = "0xD8")]
	[Token(Token = "0x60000C3")]
	private static void ConfigureStroke(RectTransform s, float deg, float len, float thick) { }

	[Address(RVA = "0x33DD4BC", Offset = "0x33DD4BC", Length = "0x6C")]
	[IteratorStateMachine(typeof(<ConflictFlashRoutine>d__153))]
	[Token(Token = "0x60000CD")]
	private IEnumerator ConflictFlashRoutine() { }

	[Address(RVA = "0x33DBF4C", Offset = "0x33DBF4C", Length = "0x100")]
	[Token(Token = "0x60000AF")]
	private bool ContactStillHeld() { }

	[Address(RVA = "0x33DCBE0", Offset = "0x33DCBE0", Length = "0x34")]
	[Token(Token = "0x60000BB")]
	public static float CornerPixelsPerUnit(float cellWidth, float radiusScale) { }

	[Address(RVA = "0x33DC094", Offset = "0x33DC094", Length = "0x84")]
	[Token(Token = "0x60000B2")]
	private static int DeviceId(PointerEventData e) { }

	[Address(RVA = "0x33DD35C", Offset = "0x33DD35C", Length = "0x88")]
	[IteratorStateMachine(typeof(<DrawStroke>d__142))]
	[Token(Token = "0x60000CA")]
	private IEnumerator DrawStroke(RectTransform s) { }

	[Address(RVA = "0x33DC9B4", Offset = "0x33DC9B4", Length = "0x6C")]
	[IteratorStateMachine(typeof(<DrawX>d__141))]
	[Token(Token = "0x60000C9")]
	private IEnumerator DrawX() { }

	[Address(RVA = "0x33DE004", Offset = "0x33DE004", Length = "0x3C")]
	[Token(Token = "0x60000DC")]
	private static float EaseOutBack(float p) { }

	[Address(RVA = "0x33DCD64", Offset = "0x33DCD64", Length = "0x34C")]
	[Token(Token = "0x60000BE")]
	private void EnsureAssistPattern() { }

	[Address(RVA = "0x33DD888", Offset = "0x33DD888", Length = "0x1B0")]
	[Token(Token = "0x60000D3")]
	private void EnsureBreakPieces() { }

	[Address(RVA = "0x33DE2FC", Offset = "0x33DE2FC", Length = "0x350")]
	[Token(Token = "0x60000E1")]
	private Image EnsureRimLayer(ref Image layer, string name, Sprite sprite, float side) { }

	[Address(RVA = "0x33DB86C", Offset = "0x33DB86C", Length = "0x63C")]
	[Token(Token = "0x60000AA")]
	private void EnsureVisualRoot() { }

	[Address(RVA = "0x33DCA60", Offset = "0x33DCA60", Length = "0x6C")]
	[IteratorStateMachine(typeof(<FadeOutX>d__139))]
	[Token(Token = "0x60000C7")]
	private IEnumerator FadeOutX() { }

	[Address(RVA = "0x33D8208", Offset = "0x33D8208", Length = "0x90")]
	[Token(Token = "0x6000099")]
	public Color get_BackgroundColor() { }

	[Address(RVA = "0x33DB328", Offset = "0x33DB328", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000096")]
	public int get_Col() { }

	[Address(RVA = "0x33D7F84", Offset = "0x33D7F84", Length = "0xE4")]
	[Token(Token = "0x60000BA")]
	public float get_CornerRadiusRatio() { }

	[Address(RVA = "0x33DB354", Offset = "0x33DB354", Length = "0x8")]
	[Token(Token = "0x600009D")]
	public float get_CrossLengthRatio() { }

	[Address(RVA = "0x33DB35C", Offset = "0x33DB35C", Length = "0x8")]
	[Token(Token = "0x600009E")]
	public float get_CrossThicknessRatio() { }

	[Address(RVA = "0x33D86EC", Offset = "0x33D86EC", Length = "0x88")]
	[Token(Token = "0x600009C")]
	public Sprite get_HamsterIdleSprite() { }

	[Address(RVA = "0x33D8820", Offset = "0x33D8820", Length = "0xB0")]
	[Token(Token = "0x600009F")]
	public RectTransform get_HamsterRect() { }

	[Address(RVA = "0x33D8344", Offset = "0x33D8344", Length = "0x88")]
	[Token(Token = "0x600009B")]
	public Sprite get_HamsterSprite() { }

	[Address(RVA = "0x33DB338", Offset = "0x33DB338", Length = "0x8")]
	[Token(Token = "0x6000098")]
	public CellMark get_Mark() { }

	[Address(RVA = "0x33DB340", Offset = "0x33DB340", Length = "0x14")]
	[Token(Token = "0x600009A")]
	public Color get_RegionColor() { }

	[Address(RVA = "0x33DB318", Offset = "0x33DB318", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000094")]
	public int get_Row() { }

	[Address(RVA = "0x33D3180", Offset = "0x33D3180", Length = "0x4C")]
	[Token(Token = "0x60000B4")]
	internal bool HasPenContact(Pen pen) { }

	[Address(RVA = "0x33DC374", Offset = "0x33DC374", Length = "0x100")]
	[Token(Token = "0x60000E4")]
	private void HideAutoCrossGlow() { }

	[Address(RVA = "0x33DD6EC", Offset = "0x33DD6EC", Length = "0xDC")]
	[Token(Token = "0x60000D7")]
	private void HideBreakPieces() { }

	[Address(RVA = "0x33DCACC", Offset = "0x33DCACC", Length = "0x114")]
	[Token(Token = "0x60000C5")]
	private void HideX() { }

	[Address(RVA = "0x33DE888", Offset = "0x33DE888", Length = "0x6C")]
	[IteratorStateMachine(typeof(<HintPulse>d__184))]
	[Token(Token = "0x60000E6")]
	private IEnumerator HintPulse() { }

	[Address(RVA = "0x33D4DF8", Offset = "0x33D4DF8", Length = "0x284")]
	[Token(Token = "0x60000B6")]
	public void Init(int row, int col, Color regionColor) { }

	[Address(RVA = "0x33DBF18", Offset = "0x33DBF18", Length = "0x34")]
	[Token(Token = "0x60000AE")]
	private void LateUpdate() { }

	[Address(RVA = "0x33DE91C", Offset = "0x33DE91C", Length = "0x98")]
	[IteratorStateMachine(typeof(<LineWaveRoutine>d__194))]
	[Token(Token = "0x60000EA")]
	private IEnumerator LineWaveRoutine(float delay, float amplitude, float duration, float squash) { }

	[Address(RVA = "0x33DD450", Offset = "0x33DD450", Length = "0x6C")]
	[IteratorStateMachine(typeof(<MistakeRoutine>d__154))]
	[Token(Token = "0x60000CE")]
	private IEnumerator MistakeRoutine() { }

	[Address(RVA = "0x33DDA38", Offset = "0x33DDA38", Length = "0x2E0")]
	[Token(Token = "0x60000D4")]
	private RectTransform NewBreakPiece(string name, Sprite sprite, out Image img) { }

	[Address(RVA = "0x33DBED8", Offset = "0x33DBED8", Length = "0x20")]
	[Token(Token = "0x60000AC")]
	private void OnApplicationFocus(bool focused) { }

	[Address(RVA = "0x33DBEF8", Offset = "0x33DBEF8", Length = "0x20")]
	[Token(Token = "0x60000AD")]
	private void OnApplicationPause(bool paused) { }

	[Address(RVA = "0x33DEEEC", Offset = "0x33DEEEC", Length = "0x4")]
	[Token(Token = "0x60000F1")]
	public void OnBeginDrag(PointerEventData eventData) { }

	[Address(RVA = "0x33DBEA8", Offset = "0x33DBEA8", Length = "0x18")]
	[Token(Token = "0x60000AB")]
	private void OnDisable() { }

	[Address(RVA = "0x33D3994", Offset = "0x33D3994", Length = "0x4")]
	[Token(Token = "0x60000F2")]
	public void OnDrag(PointerEventData eventData) { }

	[Address(RVA = "0x33D31FC", Offset = "0x33D31FC", Length = "0x664")]
	[Token(Token = "0x60000EF")]
	public void OnPointerDown(PointerEventData eventData) { }

	[Address(RVA = "0x33D3860", Offset = "0x33D3860", Length = "0x134")]
	[Token(Token = "0x60000F0")]
	public void OnPointerUp(PointerEventData eventData) { }

	[Address(RVA = "0x33DC118", Offset = "0x33DC118", Length = "0xE8")]
	[Token(Token = "0x60000B3")]
	private bool OwnsPointer(PointerEventData e) { }

	[Address(RVA = "0x33DEEF0", Offset = "0x33DEEF0", Length = "0x184")]
	[Token(Token = "0x60000F4")]
	private void PaintAt(Vector2 screenPos, Camera cam, PointerEventData eventData) { }

	[Address(RVA = "0x33DEBE0", Offset = "0x33DEBE0", Length = "0x30C")]
	[Token(Token = "0x60000F3")]
	private void PaintUnder(PointerEventData eventData) { }

	[Address(RVA = "0x33DEB4C", Offset = "0x33DEB4C", Length = "0x6C")]
	[IteratorStateMachine(typeof(<PlaceRoutine>d__198))]
	[Token(Token = "0x60000EE")]
	private IEnumerator PlaceRoutine() { }

	[Address(RVA = "0x33D5404", Offset = "0x33D5404", Length = "0xD0")]
	[Token(Token = "0x60000DA")]
	public void PlayAppear(float delay) { }

	[Address(RVA = "0x33D752C", Offset = "0x33D752C", Length = "0x2C")]
	[Token(Token = "0x60000DE")]
	public void PlayAutoCrossGlow(float delay = 0) { }

	[Address(RVA = "0x33D6CE4", Offset = "0x33D6CE4", Length = "0xB0")]
	[Token(Token = "0x60000CC")]
	public void PlayConflictFlash() { }

	[Address(RVA = "0x33D7C84", Offset = "0x33D7C84", Length = "0x90")]
	[Token(Token = "0x60000C1")]
	public void PlayHamsterCelebrate() { }

	[Address(RVA = "0x33D6D94", Offset = "0x33D6D94", Length = "0x90")]
	[Token(Token = "0x60000C0")]
	public void PlayHamsterWrong() { }

	[Address(RVA = "0x33D7800", Offset = "0x33D7800", Length = "0x150")]
	[Token(Token = "0x60000E7")]
	public void PlayLineWave(float delay, float amplitude, float duration, float squash) { }

	[Address(RVA = "0x33D6A34", Offset = "0x33D6A34", Length = "0x90")]
	[Token(Token = "0x60000CB")]
	public void PlayMistake() { }

	[Address(RVA = "0x33D72B4", Offset = "0x33D72B4", Length = "0xDC")]
	[Token(Token = "0x60000ED")]
	public void PlayPlace() { }

	[Address(RVA = "0x33DE9DC", Offset = "0x33DE9DC", Length = "0xDC")]
	[Token(Token = "0x60000EB")]
	public void PlayPress() { }

	[Address(RVA = "0x33DE044", Offset = "0x33DE044", Length = "0x2B8")]
	[Token(Token = "0x60000E0")]
	private void PlayRimGlow(float delay, bool sweepOnly, float intensity = 1, Nullable<Color> glowColor = null) { }

	[Address(RVA = "0x33D54D4", Offset = "0x33D54D4", Length = "0x30")]
	[Token(Token = "0x60000DF")]
	public void PlayRimSweep(float delay = 0, float intensity = 1, Nullable<Color> glowColor = null) { }

	[Address(RVA = "0x33DEAB8", Offset = "0x33DEAB8", Length = "0x6C")]
	[IteratorStateMachine(typeof(<PressRoutine>d__196))]
	[Token(Token = "0x60000EC")]
	private IEnumerator PressRoutine() { }

	[Address(RVA = "0x33DD644", Offset = "0x33DD644", Length = "0x80")]
	[IteratorStateMachine(typeof(<PunchRoutine>d__156))]
	[Token(Token = "0x60000D0")]
	private IEnumerator PunchRoutine(float dur, float amp) { }

	[Address(RVA = "0x33DC04C", Offset = "0x33DC04C", Length = "0x48")]
	[Token(Token = "0x60000B1")]
	private void ReleasePointer() { }

	[Address(RVA = "0x33DB414", Offset = "0x33DB414", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A5")]
	public void remove_DoubleTapped(Action<CellView> value) { }

	[Address(RVA = "0x33DB4C4", Offset = "0x33DB4C4", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A7")]
	public void remove_DragPainted(Action<CellView, bool> value) { }

	[Address(RVA = "0x33DB364", Offset = "0x33DB364", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x60000A3")]
	public void remove_Tapped(Action<CellView> value) { }

	[Address(RVA = "0x33DC474", Offset = "0x33DC474", Length = "0x2B4")]
	[Token(Token = "0x60000B9")]
	private void Render(CellMark mark, bool animateCross, bool fadeOutCross = false) { }

	[Address(RVA = "0x33DB574", Offset = "0x33DB574", Length = "0x88")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x60000A8")]
	private static void ResetTapState() { }

	[Address(RVA = "0x33DD188", Offset = "0x33DD188", Length = "0xC0")]
	[Token(Token = "0x60000C6")]
	private static void RestoreStrokeAlpha(Image img) { }

	[Address(RVA = "0x33DB330", Offset = "0x33DB330", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000097")]
	private void set_Col(int value) { }

	[Address(RVA = "0x33DB320", Offset = "0x33DB320", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000095")]
	private void set_Row(int value) { }

	[Address(RVA = "0x33DDE40", Offset = "0x33DDE40", Length = "0x120")]
	[Token(Token = "0x60000D6")]
	private void SetBreakAlpha(float a) { }

	[Address(RVA = "0x33DDD18", Offset = "0x33DDD18", Length = "0x128")]
	[Token(Token = "0x60000D5")]
	private void SetBreakPiece(RectTransform rt, float side) { }

	[Address(RVA = "0x33D9298", Offset = "0x33D9298", Length = "0x14C")]
	[Token(Token = "0x60000BD")]
	public void SetColorAssist(bool patternOn, int patternIndex, Color patternColor) { }

	[Address(RVA = "0x33D507C", Offset = "0x33D507C", Length = "0x164")]
	[Token(Token = "0x60000BC")]
	public void SetCornerScale(float cellWidth, float radiusScale = 1) { }

	[Address(RVA = "0x33DE040", Offset = "0x33DE040", Length = "0x4")]
	[Token(Token = "0x60000DD")]
	public void SetDimmed(bool dim) { }

	[Address(RVA = "0x33D898C", Offset = "0x33D898C", Length = "0x98")]
	[Token(Token = "0x60000A0")]
	public void SetHamsterVisible(bool visible) { }

	[Address(RVA = "0x33D7E04", Offset = "0x33D7E04", Length = "0xE8")]
	[Token(Token = "0x60000E5")]
	public void SetHint(bool on) { }

	[Address(RVA = "0x33D51E0", Offset = "0x33D51E0", Length = "0x9C")]
	[Token(Token = "0x60000A1")]
	public void SetHitPadding(float x, float y) { }

	[Address(RVA = "0x33DCA20", Offset = "0x33DCA20", Length = "0x40")]
	[Token(Token = "0x60000C4")]
	private static void SetLen(RectTransform s, float t) { }

	[Address(RVA = "0x33D53E0", Offset = "0x33D53E0", Length = "0x24")]
	[Token(Token = "0x60000B8")]
	public void SetMark(CellMark mark) { }

	[Address(RVA = "0x33DC728", Offset = "0x33DC728", Length = "0x28C")]
	[Token(Token = "0x60000C2")]
	private void SetupStrokes(Color color) { }

	[Address(RVA = "0x33D6E40", Offset = "0x33D6E40", Length = "0x120")]
	[Token(Token = "0x60000D9")]
	public void ShowMistakeStatic() { }

	[Address(RVA = "0x33DD270", Offset = "0x33DD270", Length = "0xC4")]
	[Token(Token = "0x60000C8")]
	private static void ShrinkStroke(RectTransform s, Vector2 basePos, float k) { }

	[Address(RVA = "0x33DC338", Offset = "0x33DC338", Length = "0x3C")]
	[Token(Token = "0x60000E9")]
	private void StopLineWave() { }

	[Address(RVA = "0x33DC200", Offset = "0x33DC200", Length = "0x108")]
	[Token(Token = "0x60000D1")]
	private void StopMistakeFx() { }

	[Address(RVA = "0x33DD40C", Offset = "0x33DD40C", Length = "0x44")]
	[Token(Token = "0x60000E8")]
	private void StopRunningLineWave() { }

	[Address(RVA = "0x33DC308", Offset = "0x33DC308", Length = "0x30")]
	[Token(Token = "0x60000D8")]
	private void StopXAnim() { }

	[Address(RVA = "0x33DD578", Offset = "0x33DD578", Length = "0xA4")]
	[IteratorStateMachine(typeof(<TintTo>d__155))]
	[Token(Token = "0x60000CF")]
	private IEnumerator TintTo(Color target, float dur) { }

}

