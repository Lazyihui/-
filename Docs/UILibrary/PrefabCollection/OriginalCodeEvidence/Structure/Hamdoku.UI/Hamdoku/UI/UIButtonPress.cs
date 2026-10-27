namespace Hamdoku.UI;

[RequireComponent(typeof(RectTransform))]
[Token(Token = "0x20000D7")]
public sealed class UIButtonPress : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler
{
	[CompilerGenerated]
	[Token(Token = "0x20000D8")]
	private sealed class <ScaleTo>d__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D63")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D64")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D65")]
		public UIButtonPress <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D66")]
		public float dur; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000D67")]
		public bool bounce; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000D68")]
		public float tx; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000D69")]
		public float ty; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000D6A")]
		private float <fromX>5__2; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x4000D6B")]
		private float <fromY>5__3; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000D6C")]
		private float <t>5__4; //Field offset: 0x40

		[Token(Token = "0x170000DF")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x343B248", Offset = "0x343B248", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60005B8")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170000E0")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x343B288", Offset = "0x343B288", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60005BA")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x343AD94", Offset = "0x343AD94", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60005B5")]
		public <ScaleTo>d__24(int <>1__state) { }

		[Address(RVA = "0x343AFFC", Offset = "0x343AFFC", Length = "0x24C")]
		[Token(Token = "0x60005B7")]
		private bool MoveNext() { }

		[Address(RVA = "0x343B248", Offset = "0x343B248", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60005B8")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x343B288", Offset = "0x343B288", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60005BA")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x343B250", Offset = "0x343B250", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60005B9")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x343AFF8", Offset = "0x343AFF8", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60005B6")]
		private void System.IDisposable.Dispose() { }

	}

	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4000D57")]
	[Tooltip("눌렀을 때 줄어드는 배율(균일 모드)")]
	private float pressedScale; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	[Token(Token = "0x4000D58")]
	[Tooltip("눌려 들어가는 시간(초)")]
	private float downTime; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4000D59")]
	[Tooltip("탄력 있게 튀어 복귀하는 시간(초)")]
	private float upTime; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Header("스쿼시 모드(위아래 수축 → 뽀잉)")]
	[SerializeField]
	[Token(Token = "0x4000D5A")]
	[Tooltip("켜면 균일 축소 대신 세로 수축+가로 확장(스쿼시)으로 누른다")]
	private bool squash; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x4000D5B")]
	[Tooltip("눌렀을 때 세로 배율(작게=더 납작)")]
	private float squashY; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	[Token(Token = "0x4000D5C")]
	[Tooltip("눌렀을 때 가로 배율(크게=더 벌어짐)")]
	private float squashX; //Field offset: 0x34
	[CompilerGenerated]
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000D5D")]
	private Action Pressed; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000D5E")]
	private Vector3 _base; //Field offset: 0x40
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000D5F")]
	private RectTransform _rt; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000D60")]
	private Vector2 _basePos; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000D61")]
	private Coroutine _fx; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000D62")]
	private bool _down; //Field offset: 0x68

	[Token(Token = "0x1400000D")]
	public event Action Pressed
	{
		[Address(RVA = "0x343A680", Offset = "0x343A680", Length = "0x9C")]
		[CompilerGenerated]
		[Token(Token = "0x60005A5")]
		 add { } //Length: 156
		[Address(RVA = "0x343A71C", Offset = "0x343A71C", Length = "0x9C")]
		[CompilerGenerated]
		[Token(Token = "0x60005A6")]
		 remove { } //Length: 156
	}

	[Address(RVA = "0x343AF74", Offset = "0x343AF74", Length = "0x84")]
	[Token(Token = "0x60005B4")]
	public UIButtonPress() { }

	[Address(RVA = "0x343A680", Offset = "0x343A680", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x60005A5")]
	public void add_Pressed(Action value) { }

	[Address(RVA = "0x343ADBC", Offset = "0x343ADBC", Length = "0x17C")]
	[Token(Token = "0x60005B2")]
	private void ApplyPose(float sx, float sy) { }

	[Address(RVA = "0x343A934", Offset = "0x343A934", Length = "0xC8")]
	[Token(Token = "0x60005A9")]
	private void Awake() { }

	[Address(RVA = "0x343AF38", Offset = "0x343AF38", Length = "0x3C")]
	[Token(Token = "0x60005B3")]
	private static float EaseOutBack(float p) { }

	[Address(RVA = "0x343A7B8", Offset = "0x343A7B8", Length = "0xE8")]
	[Token(Token = "0x60005A7")]
	public static UIButtonPress Ensure(GameObject go) { }

	[Address(RVA = "0x343A8A0", Offset = "0x343A8A0", Length = "0x94")]
	[Token(Token = "0x60005A8")]
	public static UIButtonPress Ensure(GameObject go, bool squashMode) { }

	[Address(RVA = "0x343AA9C", Offset = "0x343AA9C", Length = "0xCC")]
	[Token(Token = "0x60005AB")]
	private void OnDisable() { }

	[Address(RVA = "0x343AB68", Offset = "0x343AB68", Length = "0xDC")]
	[Token(Token = "0x60005AC")]
	public void OnPointerDown(PointerEventData e) { }

	[Address(RVA = "0x343AD90", Offset = "0x343AD90", Length = "0x4")]
	[Token(Token = "0x60005AE")]
	public void OnPointerExit(PointerEventData e) { }

	[Address(RVA = "0x343AD50", Offset = "0x343AD50", Length = "0x4")]
	[Token(Token = "0x60005AD")]
	public void OnPointerUp(PointerEventData e) { }

	[Address(RVA = "0x343A9FC", Offset = "0x343A9FC", Length = "0xA0")]
	[Token(Token = "0x60005AA")]
	public void Rebase() { }

	[Address(RVA = "0x343AD54", Offset = "0x343AD54", Length = "0x3C")]
	[Token(Token = "0x60005AF")]
	private void Release() { }

	[Address(RVA = "0x343A71C", Offset = "0x343A71C", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x60005A6")]
	public void remove_Pressed(Action value) { }

	[Address(RVA = "0x343ACE8", Offset = "0x343ACE8", Length = "0x68")]
	[Token(Token = "0x60005B0")]
	private void Run(IEnumerator r) { }

	[Address(RVA = "0x343AC44", Offset = "0x343AC44", Length = "0xA4")]
	[IteratorStateMachine(typeof(<ScaleTo>d__24))]
	[Token(Token = "0x60005B1")]
	private IEnumerator ScaleTo(float tx, float ty, float dur, bool bounce) { }

}

