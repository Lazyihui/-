namespace Hamdoku.Managers;

[Token(Token = "0x20002AD")]
public sealed class StageSelect : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20002AF")]
	private sealed class <>c
	{
		[Token(Token = "0x40012B3")]
		public static readonly <>c <>9; //Field offset: 0x0
		[Token(Token = "0x40012B4")]
		public static UnityAction <>9__30_0; //Field offset: 0x8

		[Address(RVA = "0x32EDC58", Offset = "0x32EDC58", Length = "0x68")]
		[Token(Token = "0x6001379")]
		private static <>c() { }

		[Address(RVA = "0x32EDCC0", Offset = "0x32EDCC0", Length = "0x8")]
		[Token(Token = "0x600137A")]
		public <>c() { }

		[Address(RVA = "0x32EDCC8", Offset = "0x32EDCC8", Length = "0x8")]
		[Token(Token = "0x600137B")]
		internal void <Awake>b__30_0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20002B0")]
	private sealed class <>c__DisplayClass37_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40012B5")]
		public Cell cell; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40012B6")]
		public StageSelect <>4__this; //Field offset: 0x18

		[Address(RVA = "0x32EDAD8", Offset = "0x32EDAD8", Length = "0x8")]
		[Token(Token = "0x600137C")]
		public <>c__DisplayClass37_0() { }

		[Address(RVA = "0x32EDCD0", Offset = "0x32EDCD0", Length = "0x30")]
		[Token(Token = "0x600137D")]
		internal void <CreateCell>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20002B1")]
	private sealed class <Start>d__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40012B7")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40012B8")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40012B9")]
		public StageSelect <>4__this; //Field offset: 0x20

		[Token(Token = "0x170002AF")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32EDD88", Offset = "0x32EDD88", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6001381")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170002B0")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32EDDC8", Offset = "0x32EDDC8", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6001383")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32EC888", Offset = "0x32EC888", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600137E")]
		public <Start>d__31(int <>1__state) { }

		[Address(RVA = "0x32EDD04", Offset = "0x32EDD04", Length = "0x84")]
		[Token(Token = "0x6001380")]
		private bool MoveNext() { }

		[Address(RVA = "0x32EDD88", Offset = "0x32EDD88", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6001381")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32EDDC8", Offset = "0x32EDDC8", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6001383")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32EDD90", Offset = "0x32EDD90", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6001382")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32EDD00", Offset = "0x32EDD00", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600137F")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x20002AE")]
	private sealed class Cell
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40012AE")]
		public RectTransform rt; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40012AF")]
		public Image img; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40012B0")]
		public Button btn; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40012B1")]
		public TextMeshProUGUI label; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40012B2")]
		public int index; //Field offset: 0x30

		[Address(RVA = "0x32EDAE0", Offset = "0x32EDAE0", Length = "0x10")]
		[Token(Token = "0x6001378")]
		public Cell() { }

	}

	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4001293")]
	private GameSession session; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4001294")]
	[Tooltip("세션에 팩이 없을 때 사용할 팩")]
	private LevelPack pack; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x4001295")]
	[Tooltip("셀이 생성될 그리드 컨텐츠(RectTransform). ScrollRect의 Content")]
	private RectTransform content; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4001296")]
	private Button backButton; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x4001297")]
	[Tooltip("셀 배경 스프라이트(둥근 사각형 9-slice). 인스펙터에서 지정")]
	private Sprite cellSprite; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Header("셀 색")]
	[SerializeField]
	[Token(Token = "0x4001298")]
	private Color clearedColor; //Field offset: 0x48
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	[Token(Token = "0x4001299")]
	private Color currentColor; //Field offset: 0x58
	[FieldOffset(Offset = "0x68")]
	[SerializeField]
	[Token(Token = "0x400129A")]
	private Color lockedColor; //Field offset: 0x68
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	[Token(Token = "0x400129B")]
	private Color numberColor; //Field offset: 0x78
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400129C")]
	private int _cols; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x400129D")]
	private float _cellW; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400129E")]
	private float _cellH; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x400129F")]
	private float _spaceX; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40012A0")]
	private float _spaceY; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x40012A1")]
	private float _padL; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40012A2")]
	private float _padR; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40012A3")]
	private float _padT; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40012A4")]
	private float _padB; //Field offset: 0xA8
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40012A5")]
	private ScrollRect _scroll; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40012A6")]
	private RectTransform _viewport; //Field offset: 0xB8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40012A7")]
	private float _leftStart; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x40012A8")]
	private int _count; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40012A9")]
	private int _rowCount; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x40012AA")]
	private int _current; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40012AB")]
	private float _stepY; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40012AC")]
	private readonly List<Cell> _pool; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40012AD")]
	private int _lastFirstRow; //Field offset: 0xE0

	[Token(Token = "0x170002AE")]
	private LevelPack ActivePack
	{
		[Address(RVA = "0x32EC60C", Offset = "0x32EC60C", Length = "0xB4")]
		[Token(Token = "0x600136D")]
		 get { } //Length: 180
	}

	[Address(RVA = "0x32EDB80", Offset = "0x32EDB80", Length = "0xD8")]
	[Token(Token = "0x6001377")]
	public StageSelect() { }

	[Address(RVA = "0x32ED9E4", Offset = "0x32ED9E4", Length = "0xF4")]
	[Token(Token = "0x6001374")]
	private void ApplyVisual(Cell cell, int index) { }

	[Address(RVA = "0x32EC6C0", Offset = "0x32EC6C0", Length = "0x15C")]
	[Token(Token = "0x600136E")]
	private void Awake() { }

	[Address(RVA = "0x32ECB80", Offset = "0x32ECB80", Length = "0x534")]
	[Token(Token = "0x6001371")]
	private void Build() { }

	[Address(RVA = "0x32ED0B4", Offset = "0x32ED0B4", Length = "0x6AC")]
	[Token(Token = "0x6001375")]
	private Cell CreateCell() { }

	[Address(RVA = "0x32EC60C", Offset = "0x32EC60C", Length = "0xB4")]
	[Token(Token = "0x600136D")]
	private LevelPack get_ActivePack() { }

	[Address(RVA = "0x32ED9DC", Offset = "0x32ED9DC", Length = "0x8")]
	[Token(Token = "0x6001372")]
	private void OnScroll(Vector2 _) { }

	[Address(RVA = "0x32EDAF0", Offset = "0x32EDAF0", Length = "0x90")]
	[Token(Token = "0x6001376")]
	private void Play(int index) { }

	[Address(RVA = "0x32EC8B0", Offset = "0x32EC8B0", Length = "0x2D0")]
	[Token(Token = "0x6001370")]
	private void ReadGridSpec() { }

	[Address(RVA = "0x32ED760", Offset = "0x32ED760", Length = "0x27C")]
	[Token(Token = "0x6001373")]
	private void Refresh(bool force) { }

	[Address(RVA = "0x32EC81C", Offset = "0x32EC81C", Length = "0x6C")]
	[IteratorStateMachine(typeof(<Start>d__31))]
	[Token(Token = "0x600136F")]
	private IEnumerator Start() { }

}

