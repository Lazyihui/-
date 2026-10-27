namespace Hamdoku.UI;

[ExecuteAlways]
[Token(Token = "0x200007D")]
public sealed class LobbyLayout : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x200007E")]
	private sealed class <Start>d__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006C2")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006C3")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40006C4")]
		public LobbyLayout <>4__this; //Field offset: 0x20

		[Token(Token = "0x17000091")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x341026C", Offset = "0x341026C", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000398")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000092")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x34102AC", Offset = "0x34102AC", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600039A")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x340E4F4", Offset = "0x340E4F4", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000395")]
		public <Start>d__18(int <>1__state) { }

		[Address(RVA = "0x34101B8", Offset = "0x34101B8", Length = "0xB4")]
		[Token(Token = "0x6000397")]
		private bool MoveNext() { }

		[Address(RVA = "0x341026C", Offset = "0x341026C", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000398")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x34102AC", Offset = "0x34102AC", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600039A")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3410274", Offset = "0x3410274", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000399")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x34101B4", Offset = "0x34101B4", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000396")]
		private void System.IDisposable.Dispose() { }

	}

	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x40006B0")]
	[Tooltip("레이아웃 튜닝값 에셋. 비우면 Resources/LobbyLayoutConfig 자동 로드")]
	private LobbyLayoutConfig config; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Header("참조(비우면 이름으로 자동 연결)")]
	[SerializeField]
	[Token(Token = "0x40006B1")]
	private RectTransform cardsGroup; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x40006B2")]
	private RectTransform dailyCard; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x40006B3")]
	private RectTransform dailyIcon; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x40006B4")]
	private RectTransform dailyTitle; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Token(Token = "0x40006B5")]
	private RectTransform dailyDate; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	[Token(Token = "0x40006B6")]
	private RectTransform dailyCapsule; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	[Token(Token = "0x40006B7")]
	private RectTransform dailyPill; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	[Token(Token = "0x40006B8")]
	private RectTransform dailyPillLabel; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[SerializeField]
	[Token(Token = "0x40006B9")]
	private RectTransform streakCard; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	[Token(Token = "0x40006BA")]
	private RectTransform streakIcon; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	[Token(Token = "0x40006BB")]
	private RectTransform streakValue; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[SerializeField]
	[Token(Token = "0x40006BC")]
	private RectTransform rankCard; //Field offset: 0x80
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	[Token(Token = "0x40006BD")]
	private RectTransform rankIcon; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	[Token(Token = "0x40006BE")]
	private RectTransform rankGlow; //Field offset: 0x90
	[FieldOffset(Offset = "0x98")]
	[SerializeField]
	[Token(Token = "0x40006BF")]
	private RectTransform rankCapsule; //Field offset: 0x98
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	[Token(Token = "0x40006C0")]
	private RectTransform levelButton; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA8")]
	[SerializeField]
	[Token(Token = "0x40006C1")]
	private RectTransform levelLabel; //Field offset: 0xA8

	[Address(RVA = "0x34101AC", Offset = "0x34101AC", Length = "0x8")]
	[Token(Token = "0x6000394")]
	public LobbyLayout() { }

	[Address(RVA = "0x340E544", Offset = "0x340E544", Length = "0x8FC")]
	[Token(Token = "0x600038C")]
	public void Apply() { }

	[Address(RVA = "0x340F000", Offset = "0x340F000", Length = "0xA84")]
	[Token(Token = "0x600038D")]
	private void AutoWire() { }

	[Address(RVA = "0x340EF50", Offset = "0x340EF50", Length = "0xB0")]
	[Token(Token = "0x600038B")]
	private LobbyLayoutConfig Config() { }

	[Address(RVA = "0x34100D0", Offset = "0x34100D0", Length = "0xDC")]
	[Token(Token = "0x600038E")]
	private RectTransform FindByName(string n) { }

	[Address(RVA = "0x340FD80", Offset = "0x340FD80", Length = "0x2A0")]
	[Token(Token = "0x6000392")]
	private static void FitCapsule(RectTransform cap) { }

	[Address(RVA = "0x340EE40", Offset = "0x340EE40", Length = "0x110")]
	[Token(Token = "0x600038A")]
	private void OnEnable() { }

	[Address(RVA = "0x340E51C", Offset = "0x340E51C", Length = "0x28")]
	[Token(Token = "0x6000389")]
	private void OnRectTransformDimensionsChange() { }

	[Address(RVA = "0x340FB84", Offset = "0x340FB84", Length = "0xD8")]
	[Token(Token = "0x6000390")]
	private static void Set(RectTransform rt, Vector2 pos, Vector2 size) { }

	[Address(RVA = "0x3410020", Offset = "0x3410020", Length = "0xB0")]
	[Token(Token = "0x6000391")]
	private static void Set(RectTransform rt, Vector2 size) { }

	[Address(RVA = "0x340FC5C", Offset = "0x340FC5C", Length = "0x124")]
	[Token(Token = "0x6000393")]
	private static void SetFont(RectTransform rt, float max, bool wrap) { }

	[Address(RVA = "0x340FA84", Offset = "0x340FA84", Length = "0x100")]
	[Token(Token = "0x600038F")]
	private static void SetLocal(RectTransform rt, Vector2 pos, Vector2 size) { }

	[Address(RVA = "0x340E488", Offset = "0x340E488", Length = "0x6C")]
	[IteratorStateMachine(typeof(<Start>d__18))]
	[Token(Token = "0x6000388")]
	private IEnumerator Start() { }

}

