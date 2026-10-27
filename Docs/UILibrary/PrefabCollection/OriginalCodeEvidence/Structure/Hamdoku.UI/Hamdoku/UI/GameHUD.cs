namespace Hamdoku.UI;

[Token(Token = "0x2000050")]
public sealed class GameHUD : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000052")]
	private sealed class <>c__DisplayClass96_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400051F")]
		public GameHUD <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000520")]
		public int seq; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000521")]
		public int placed; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000522")]
		public int total; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000523")]
		public Transform pill; //Field offset: 0x28

		[Address(RVA = "0x33FBEB4", Offset = "0x33FBEB4", Length = "0x8")]
		[Token(Token = "0x6000263")]
		public <>c__DisplayClass96_0() { }

		[Address(RVA = "0x33FEE20", Offset = "0x33FEE20", Length = "0xD4")]
		[Token(Token = "0x6000264")]
		internal void <PlayGainFly>b__0(bool last) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000053")]
	private sealed class <>c__DisplayClass97_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000524")]
		public GameHUD <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000525")]
		public int seq; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000526")]
		public int score; //Field offset: 0x1C

		[Address(RVA = "0x33FEEF4", Offset = "0x33FEEF4", Length = "0x8")]
		[Token(Token = "0x6000265")]
		public <>c__DisplayClass97_0() { }

		[Address(RVA = "0x33FEEFC", Offset = "0x33FEEFC", Length = "0xF0")]
		[Token(Token = "0x6000266")]
		internal void <DelayedStarFly>b__0(bool last) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000054")]
	private sealed class <DelayedStarFly>d__97 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000527")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000528")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000529")]
		public GameHUD <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400052A")]
		public int seq; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x400052B")]
		public int score; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400052C")]
		public RectTransform fromCell; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400052D")]
		private <>c__DisplayClass97_0 <>8__1; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x400052E")]
		public float cellW; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x400052F")]
		private float <e>5__2; //Field offset: 0x44

		[Token(Token = "0x17000056")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33FF374", Offset = "0x33FF374", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600026A")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000057")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33FF3B4", Offset = "0x33FF3B4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600026C")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FC170", Offset = "0x33FC170", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000267")]
		public <DelayedStarFly>d__97(int <>1__state) { }

		[Address(RVA = "0x33FEFF0", Offset = "0x33FEFF0", Length = "0x384")]
		[Token(Token = "0x6000269")]
		private bool MoveNext() { }

		[Address(RVA = "0x33FF374", Offset = "0x33FF374", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600026A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33FF3B4", Offset = "0x33FF3B4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600026C")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33FF37C", Offset = "0x33FF37C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600026B")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FEFEC", Offset = "0x33FEFEC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000268")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000055")]
	private sealed class <LoseLife>d__148 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000530")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000531")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000532")]
		public Image img; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000533")]
		public GameHUD <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000534")]
		public Vector3 baseScale; //Field offset: 0x30
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000535")]
		private Transform <t>5__2; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000536")]
		private Color <red>5__3; //Field offset: 0x48
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000537")]
		private float <e>5__4; //Field offset: 0x58
		[FieldOffset(Offset = "0x5C")]
		[Token(Token = "0x4000538")]
		private float <dA>5__5; //Field offset: 0x5C
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x4000539")]
		private float <dB>5__6; //Field offset: 0x60
		[FieldOffset(Offset = "0x64")]
		[Token(Token = "0x400053A")]
		private float <dC>5__7; //Field offset: 0x64

		[Token(Token = "0x17000058")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33FF784", Offset = "0x33FF784", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000270")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000059")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33FF7C4", Offset = "0x33FF7C4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000272")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FEBA0", Offset = "0x33FEBA0", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600026D")]
		public <LoseLife>d__148(int <>1__state) { }

		[Address(RVA = "0x33FF3C0", Offset = "0x33FF3C0", Length = "0x3C4")]
		[Token(Token = "0x600026F")]
		private bool MoveNext() { }

		[Address(RVA = "0x33FF784", Offset = "0x33FF784", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000270")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33FF7C4", Offset = "0x33FF7C4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000272")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33FF78C", Offset = "0x33FF78C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000271")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FF3BC", Offset = "0x33FF3BC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600026E")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000056")]
	private sealed class <PunchScale>d__105 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400053B")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400053C")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400053D")]
		public Transform t; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400053E")]
		public Vector3 baseScale; //Field offset: 0x28
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x400053F")]
		private float <e>5__2; //Field offset: 0x34

		[Token(Token = "0x1700005A")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33FF980", Offset = "0x33FF980", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000276")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700005B")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33FF9C0", Offset = "0x33FF9C0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000278")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FC71C", Offset = "0x33FC71C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000273")]
		public <PunchScale>d__105(int <>1__state) { }

		[Address(RVA = "0x33FF7D0", Offset = "0x33FF7D0", Length = "0x1B0")]
		[Token(Token = "0x6000275")]
		private bool MoveNext() { }

		[Address(RVA = "0x33FF980", Offset = "0x33FF980", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000276")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33FF9C0", Offset = "0x33FF9C0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000278")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33FF988", Offset = "0x33FF988", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000277")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FF7CC", Offset = "0x33FF7CC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000274")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000057")]
	private sealed class <RollScore>d__84 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000540")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000541")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000542")]
		public GameHUD <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000543")]
		public int target; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000544")]
		private int <from>5__2; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000545")]
		private float <dur>5__3; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000546")]
		private float <e>5__4; //Field offset: 0x34

		[Token(Token = "0x1700005C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33FFC64", Offset = "0x33FFC64", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600027C")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700005D")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33FFCA4", Offset = "0x33FFCA4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600027E")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FB850", Offset = "0x33FB850", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000279")]
		public <RollScore>d__84(int <>1__state) { }

		[Address(RVA = "0x33FF9CC", Offset = "0x33FF9CC", Length = "0x298")]
		[Token(Token = "0x600027B")]
		private bool MoveNext() { }

		[Address(RVA = "0x33FFC64", Offset = "0x33FFC64", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600027C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33FFCA4", Offset = "0x33FFCA4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600027E")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33FFC6C", Offset = "0x33FFC6C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600027D")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FF9C8", Offset = "0x33FF9C8", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600027A")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000058")]
	private sealed class <ScoreColorTween>d__90 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000547")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000548")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000549")]
		public float dur; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400054A")]
		public GameHUD <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400054B")]
		public Color from; //Field offset: 0x30
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x400054C")]
		private float <e>5__2; //Field offset: 0x40

		[Token(Token = "0x1700005E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33FFE94", Offset = "0x33FFE94", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000282")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700005F")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33FFED4", Offset = "0x33FFED4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000284")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FBA20", Offset = "0x33FBA20", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600027F")]
		public <ScoreColorTween>d__90(int <>1__state) { }

		[Address(RVA = "0x33FFCB0", Offset = "0x33FFCB0", Length = "0x1E4")]
		[Token(Token = "0x6000281")]
		private bool MoveNext() { }

		[Address(RVA = "0x33FFE94", Offset = "0x33FFE94", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000282")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33FFED4", Offset = "0x33FFED4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000284")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33FFE9C", Offset = "0x33FFE9C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000283")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FFCAC", Offset = "0x33FFCAC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000280")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000059")]
	private sealed class <Shake>d__149 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400054D")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400054E")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400054F")]
		public float dur; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000550")]
		public float mag; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000551")]
		public Transform t; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000552")]
		public GameHUD <>4__this; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000553")]
		private float <e>5__2; //Field offset: 0x38

		[Token(Token = "0x17000060")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3400018", Offset = "0x3400018", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000288")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000061")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3400058", Offset = "0x3400058", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600028A")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33FEBC8", Offset = "0x33FEBC8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000285")]
		public <Shake>d__149(int <>1__state) { }

		[Address(RVA = "0x33FFEE0", Offset = "0x33FFEE0", Length = "0x138")]
		[Token(Token = "0x6000287")]
		private bool MoveNext() { }

		[Address(RVA = "0x3400018", Offset = "0x3400018", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000288")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3400058", Offset = "0x3400058", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600028A")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3400020", Offset = "0x3400020", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000289")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33FFEDC", Offset = "0x33FFEDC", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000286")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x2000051")]
	private enum HeaderMode : int
	{
		Campaign = 0,
		Daily = 1,
	}

	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x40004C8")]
	private TMP_Text levelText; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x40004C9")]
	private TMP_Text hamsterCountText; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Header("상단 정보 헤더 (레벨/점수/난이도) — 코드 생성")]
	[SerializeField]
	[Token(Token = "0x40004CA")]
	[Tooltip("켜면 캠페인에서 LevelText 자리에 3열 헤더를 코드로 만들어 표시")]
	private bool useHeaderInfo; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	[Token(Token = "0x40004CB")]
	[Tooltip("열 하나의 폭(px)")]
	private float headerColumnWidth; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x40004CC")]
	[Tooltip("열 사이 간격(px)")]
	private float headerColumnGap; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[SerializeField]
	[Token(Token = "0x40004CD")]
	[Tooltip("난이도 열이 보일 때 헤더 열 그룹을 왼쪽으로 밀어 우측 상점 버튼과 겹침 회피(px, 음수=왼쪽)")]
	private float headerHardShiftX; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x40004CE")]
	[Tooltip("열 안쪽 값 텍스트 좌우 여백(px) — 긴 값(날짜)이 옆 열 글자와 붙어 보이지 않게")]
	private float headerValuePadX; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[SerializeField]
	[Token(Token = "0x40004CF")]
	[Tooltip("점수 값 자간(TMP Character Spacing)")]
	private float scoreCharSpacing; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Token(Token = "0x40004D0")]
	[Tooltip("제목(레벨/점수) 글자 크기")]
	private float headerTitleFontSize; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[SerializeField]
	[Token(Token = "0x40004D1")]
	[Tooltip("값(숫자) 글자 크기 — 제목보다 크게, 볼드")]
	private float headerValueFontSize; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	[Token(Token = "0x40004D2")]
	[Tooltip("제목 색")]
	private Color headerTitleColor; //Field offset: 0x50
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	[Token(Token = "0x40004D3")]
	[Tooltip("값 색")]
	private Color headerValueColor; //Field offset: 0x60
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	[Token(Token = "0x40004D4")]
	[Tooltip("난이도(어려움) 글자 색")]
	private Color headerHardColor; //Field offset: 0x70
	[FieldOffset(Offset = "0x80")]
	[Range(0.4, 1.2)]
	[SerializeField]
	[Token(Token = "0x40004D5")]
	[Tooltip("난이도(어려움) 글자 크기 = 값 크기 × 이 배율")]
	private float headerHardLabelScale; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Header("획득 플라이 연출 (별→점수 / 햄스터→카운터)")]
	[SerializeField]
	[Token(Token = "0x40004D6")]
	[Tooltip("배치 시 별이 점수로, 햄스터 아이콘이 카운터로 날아가 박히는 연출")]
	private bool flyGainEffects; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Range(1, 8)]
	[SerializeField]
	[Token(Token = "0x40004D7")]
	[Tooltip("점수로 날아가는 별 개수")]
	private int scoreStarCount; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Range(0.2, 2.5)]
	[SerializeField]
	[Token(Token = "0x40004D8")]
	[Tooltip("별 크기 = 셀 폭 × 이 배율")]
	private float flyStarScale; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Range(0.2, 1.2)]
	[SerializeField]
	[Token(Token = "0x40004D9")]
	[Tooltip("햄스터 아이콘 크기 = 셀 폭 × 이 배율")]
	private float flyIconScale; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[SerializeField]
	[Token(Token = "0x40004DA")]
	[Tooltip("별똥별 꼬리 색(발광 골드)")]
	private Color flyTailColor; //Field offset: 0x94
	[FieldOffset(Offset = "0xA4")]
	[SerializeField]
	[Token(Token = "0x40004DB")]
	[Tooltip("별 머리 발광 후광 색")]
	private Color flyHaloColor; //Field offset: 0xA4
	[FieldOffset(Offset = "0xB4")]
	[SerializeField]
	[Token(Token = "0x40004DC")]
	[Tooltip("획득 점수 팝업(+600) 색. 흰 아웃라인/그림자는 자동")]
	private Color gainTextColor; //Field offset: 0xB4
	[FieldOffset(Offset = "0xC4")]
	[Range(20, 120)]
	[SerializeField]
	[Token(Token = "0x40004DD")]
	[Tooltip("획득 점수 글자 크기(px, 고정) — 보드/셀 크기와 무관")]
	private float gainFontSize; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40004DE")]
	[Tooltip("획득 점수 흰 아웃라인 두께(0~1). 최대치는 폰트 아틀라스 padding에 제한됨")]
	private float gainOutlineWidth; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x40004DF")]
	[Tooltip("점수 팝업을 먼저 보여준 뒤 별이 출발하기까지 지연(초)")]
	private float starFlyDelay; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[SerializeField]
	[Token(Token = "0x40004E0")]
	[Tooltip("카운터로 날아갈 햄스터 아이콘. 비우면 카운터 텍스트 옆에서 자동 탐색")]
	private Image hamsterCounterIcon; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[SerializeField]
	[Token(Token = "0x40004E1")]
	[Tooltip("생명력(해바라기씨) 아이콘들 — 왼쪽부터 순서대로")]
	private Image[] lifeIcons; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE0")]
	[SerializeField]
	[Token(Token = "0x40004E2")]
	[Tooltip("생명력이 남은 아이콘 색")]
	private Color fullLifeColor; //Field offset: 0xE0
	[FieldOffset(Offset = "0xF0")]
	[Range(1, 1.6)]
	[SerializeField]
	[Token(Token = "0x40004E3")]
	[Tooltip("황금 해바라기씨 챌린지: 한 알만 남는 황금 씨앗의 크기 배율(평소 씨앗 크기 기준)")]
	private float goldenLifeScale; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[SerializeField]
	[Token(Token = "0x40004E4")]
	[Tooltip("생명력이 소진된 아이콘 색(반투명)")]
	private Color emptyLifeColor; //Field offset: 0xF4
	[FieldOffset(Offset = "0x104")]
	[SerializeField]
	[Token(Token = "0x40004E5")]
	[Tooltip("햄스터 카운터에서 '찾은 수' 강조색 ('/전체'는 텍스트 기본색 유지)")]
	private Color placedCountColor; //Field offset: 0x104
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40004E6")]
	private RectTransform _headerRoot; //Field offset: 0x118
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40004E7")]
	private readonly RectTransform[] _headerCols; //Field offset: 0x120
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40004E8")]
	private TMP_Text _levelTitle; //Field offset: 0x128
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40004E9")]
	private TMP_Text _levelValue; //Field offset: 0x130
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40004EA")]
	private TMP_Text _scoreTitle; //Field offset: 0x138
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40004EB")]
	private TMP_Text _scoreValue; //Field offset: 0x140
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40004EC")]
	private TMP_Text _hardLabel; //Field offset: 0x148
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40004ED")]
	private ScoreSparkleFx _scoreFx; //Field offset: 0x150
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40004EE")]
	private bool _hardShown; //Field offset: 0x158
	[FieldOffset(Offset = "0x159")]
	[Token(Token = "0x40004EF")]
	private bool _levelHidden; //Field offset: 0x159
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40004F0")]
	private HeaderMode _headerMode; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40004F1")]
	private DateTime _dailyDate; //Field offset: 0x160
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40004F2")]
	private bool _timerRunning; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x40004F3")]
	private float _timerStart; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40004F4")]
	private float _timerFrozen; //Field offset: 0x170
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40004F5")]
	private Func<float> _timerSource; //Field offset: 0x178
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40004F6")]
	private int _timerShownSec; //Field offset: 0x180
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40004F7")]
	private RectTransform _timerCapsule; //Field offset: 0x188
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40004F8")]
	private TMP_Text _timerText; //Field offset: 0x190
	[FieldOffset(Offset = "0x198")]
	[SerializeField]
	[Token(Token = "0x40004F9")]
	[Tooltip("데일리 시계 캡슐 위치 미세 조정(자동 배치 위치 기준 오프셋)")]
	private Vector2 timerCapsuleOffset; //Field offset: 0x198
	[FieldOffset(Offset = "0x1A0")]
	[Range(0.05, 1.5)]
	[SerializeField]
	[Token(Token = "0x40004FA")]
	[Tooltip("[카운터][씨앗][시계] 사이 간격 = 알약 높이 × 이 배율")]
	private float hudRowGapScale; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Range(0.5, 1.2)]
	[SerializeField]
	[Token(Token = "0x40004FB")]
	[Tooltip("[카운터][씨앗][시계] 그룹 전체 크기 배율(1 = 씬 원래 크기)")]
	private float hudRowScale; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Range(0.4, 1.2)]
	[SerializeField]
	[Token(Token = "0x40004FC")]
	[Tooltip("시계 아이콘 크기 = 캡슐 높이 × 이 배율")]
	private float timerIconScale; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x40004FD")]
	private Vector3 _timerCapsuleBasePos; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x40004FE")]
	private bool _timerCapsulePlaced; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x40004FF")]
	private RectTransform _rowCounter; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x4000500")]
	private RectTransform _rowSeeds; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x4000501")]
	private Vector3[] _rowBaseScales; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D8")]
	[SerializeField]
	[Token(Token = "0x4000502")]
	[Tooltip("점수 카운트업 시간(초) — 별 도착 후 표시값이 목표까지 굴러가는 시간")]
	private float scoreRollDuration; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x4000503")]
	private int _shownScore; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x4000504")]
	private Coroutine _scoreRoll; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x4000505")]
	private bool _scoreHighlighted; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[Token(Token = "0x4000506")]
	private Color _scoreColorTarget; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x4000507")]
	private Coroutine _scoreColorCo; //Field offset: 0x200
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x4000508")]
	private int _gainSeq; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x4000509")]
	private int _appliedCountSeq; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x400050A")]
	private int _appliedScoreSeq; //Field offset: 0x210
	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x400050B")]
	private readonly Dictionary<Transform, Coroutine> _punches; //Field offset: 0x218
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x400050C")]
	private readonly Dictionary<Transform, Vector3> _punchBase; //Field offset: 0x220
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x400050D")]
	private Sprite _counterIconBase; //Field offset: 0x228
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x400050E")]
	private int _placed; //Field offset: 0x230
	[FieldOffset(Offset = "0x234")]
	[Token(Token = "0x400050F")]
	private int _total; //Field offset: 0x234
	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x4000510")]
	private int _lastRemaining; //Field offset: 0x238
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x4000511")]
	private Vector3[] _lifeBaseScale; //Field offset: 0x240
	[CompilerGenerated]
	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x4000512")]
	private bool <GoldenLife>k__BackingField; //Field offset: 0x248
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x4000513")]
	private Sprite _normalLifeSprite; //Field offset: 0x250
	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x4000514")]
	private Color _normalFullLifeColor; //Field offset: 0x258
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x4000515")]
	private Vector2 _normalLifePos0; //Field offset: 0x268
	[FieldOffset(Offset = "0x270")]
	[Token(Token = "0x4000516")]
	private Vector3 _normalLifeScale0; //Field offset: 0x270
	[FieldOffset(Offset = "0x27C")]
	[Token(Token = "0x4000517")]
	private bool _normalLifeCached; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x4000518")]
	private GoldenSparkleFx _goldenFx; //Field offset: 0x280
	[FieldOffset(Offset = "0x288")]
	[Token(Token = "0x4000519")]
	private Coroutine _shakeCo; //Field offset: 0x288
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x400051A")]
	private Transform _shakeTarget; //Field offset: 0x290
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x400051B")]
	private Vector3 _shakeRest; //Field offset: 0x298

	[Token(Token = "0x17000050")]
	public RectTransform BottomRow
	{
		[Address(RVA = "0x33F8B1C", Offset = "0x33F8B1C", Length = "0x148")]
		[Token(Token = "0x6000227")]
		 get { } //Length: 328
	}

	[Token(Token = "0x17000052")]
	public Sprite CounterIconSprite
	{
		[Address(RVA = "0x33FC2BC", Offset = "0x33FC2BC", Length = "0x88")]
		[Token(Token = "0x6000242")]
		 get { } //Length: 136
	}

	[Token(Token = "0x17000051")]
	public float ElapsedSeconds
	{
		[Address(RVA = "0x33FAA98", Offset = "0x33FAA98", Length = "0x4C")]
		[Token(Token = "0x6000231")]
		 get { } //Length: 76
	}

	[Token(Token = "0x17000053")]
	public bool GoldenLife
	{
		[Address(RVA = "0x33FDF38", Offset = "0x33FDF38", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000257")]
		 get { } //Length: 8
		[Address(RVA = "0x33FDF40", Offset = "0x33FDF40", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000258")]
		private set { } //Length: 8
	}

	[Token(Token = "0x17000055")]
	public Sprite LifeIconSprite
	{
		[Address(RVA = "0x33FE838", Offset = "0x33FE838", Length = "0xB0")]
		[Token(Token = "0x600025D")]
		 get { } //Length: 176
	}

	[Token(Token = "0x17000054")]
	public Sprite NormalLifeSprite
	{
		[Address(RVA = "0x33FE7B4", Offset = "0x33FE7B4", Length = "0x84")]
		[Token(Token = "0x600025B")]
		 get { } //Length: 132
	}

	[Address(RVA = "0x33FEBF0", Offset = "0x33FEBF0", Length = "0x230")]
	[Token(Token = "0x6000262")]
	public GameHUD() { }

	[Address(RVA = "0x33FA9C4", Offset = "0x33FA9C4", Length = "0xB0")]
	[Token(Token = "0x6000233")]
	private void ApplyElapsed(int seconds) { }

	[Address(RVA = "0x33FE3E4", Offset = "0x33FE3E4", Length = "0x118")]
	[Token(Token = "0x600025A")]
	private void ApplyGoldenLifeScale() { }

	[Address(RVA = "0x33FC198", Offset = "0x33FC198", Length = "0x124")]
	[Token(Token = "0x6000254")]
	private void ApplyHamsterCount() { }

	[Address(RVA = "0x33FC0A4", Offset = "0x33FC0A4", Length = "0x20")]
	[Token(Token = "0x6000241")]
	private void ApplyHamsterCountSeq(int seq, int placed, int total) { }

	[Address(RVA = "0x33FB3F4", Offset = "0x33FB3F4", Length = "0x268")]
	[Token(Token = "0x600023C")]
	private void ApplyScoreColor(int from, int to, bool instant = false) { }

	[Address(RVA = "0x33FC344", Offset = "0x33FC344", Length = "0x1AC")]
	[Token(Token = "0x6000243")]
	private void ApplySkinCounterIcon() { }

	[Address(RVA = "0x33FB344", Offset = "0x33FB344", Length = "0xB0")]
	[Token(Token = "0x6000237")]
	private void ApplyTimerCapsuleOffset() { }

	[Address(RVA = "0x33FD02C", Offset = "0x33FD02C", Length = "0x110")]
	[Token(Token = "0x6000249")]
	private void ApplyValuePad(TMP_Text value) { }

	[Address(RVA = "0x33FC8CC", Offset = "0x33FC8CC", Length = "0x37C")]
	[Token(Token = "0x600024A")]
	private RectTransform BuildDifficultyColumn() { }

	[Address(RVA = "0x33FC744", Offset = "0x33FC744", Length = "0x188")]
	[Token(Token = "0x6000248")]
	private RectTransform BuildHeaderColumn(string name, out TMP_Text title, out TMP_Text value, Color valueColor) { }

	[Address(RVA = "0x33FD720", Offset = "0x33FD720", Length = "0x194")]
	[Token(Token = "0x6000255")]
	private void CacheLifeBaseScales() { }

	[Address(RVA = "0x33FC0C4", Offset = "0x33FC0C4", Length = "0xAC")]
	[IteratorStateMachine(typeof(<DelayedStarFly>d__97))]
	[Token(Token = "0x6000240")]
	private IEnumerator DelayedStarFly(RectTransform fromCell, int score, int seq, float cellW) { }

	[Address(RVA = "0x33F900C", Offset = "0x33F900C", Length = "0x374")]
	[Token(Token = "0x6000247")]
	private void EnsureHeader() { }

	[Address(RVA = "0x33F9C68", Offset = "0x33F9C68", Length = "0xD5C")]
	[Token(Token = "0x6000235")]
	private void EnsureTimerCapsule() { }

	[Address(RVA = "0x33FD3F0", Offset = "0x33FD3F0", Length = "0x228")]
	[Token(Token = "0x6000251")]
	private void FitDateColumn() { }

	[Address(RVA = "0x33FAB98", Offset = "0x33FAB98", Length = "0x17C")]
	[Token(Token = "0x6000234")]
	private static string FormatElapsed(int s) { }

	[Address(RVA = "0x33F8B1C", Offset = "0x33F8B1C", Length = "0x148")]
	[Token(Token = "0x6000227")]
	public RectTransform get_BottomRow() { }

	[Address(RVA = "0x33FC2BC", Offset = "0x33FC2BC", Length = "0x88")]
	[Token(Token = "0x6000242")]
	public Sprite get_CounterIconSprite() { }

	[Address(RVA = "0x33FAA98", Offset = "0x33FAA98", Length = "0x4C")]
	[Token(Token = "0x6000231")]
	public float get_ElapsedSeconds() { }

	[Address(RVA = "0x33FDF38", Offset = "0x33FDF38", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000257")]
	public bool get_GoldenLife() { }

	[Address(RVA = "0x33FE838", Offset = "0x33FE838", Length = "0xB0")]
	[Token(Token = "0x600025D")]
	public Sprite get_LifeIconSprite() { }

	[Address(RVA = "0x33FE7B4", Offset = "0x33FE7B4", Length = "0x84")]
	[Token(Token = "0x600025B")]
	public Sprite get_NormalLifeSprite() { }

	[Address(RVA = "0x33F95FC", Offset = "0x33F95FC", Length = "0x134")]
	[Token(Token = "0x600024D")]
	private void LayoutHeaderColumns() { }

	[Address(RVA = "0x33FAD14", Offset = "0x33FAD14", Length = "0x530")]
	[Token(Token = "0x6000236")]
	private void LayoutHudRow() { }

	[Address(RVA = "0x33FE8E8", Offset = "0x33FE8E8", Length = "0xF8")]
	[Token(Token = "0x600025C")]
	public RectTransform LifeIconRect(int index) { }

	[Address(RVA = "0x33FDD78", Offset = "0x33FDD78", Length = "0xAC")]
	[IteratorStateMachine(typeof(<LoseLife>d__148))]
	[Token(Token = "0x6000260")]
	private IEnumerator LoseLife(Image img, Vector3 baseScale) { }

	[Address(RVA = "0x33FCD3C", Offset = "0x33FCD3C", Length = "0x2F0")]
	[Token(Token = "0x600024C")]
	private static TMP_Text MakeHeaderText(RectTransform parent, string name, Vector2 aMin, Vector2 aMax, float size, Color color, TextAlignmentOptions align, bool bold = false) { }

	[Address(RVA = "0x33FB244", Offset = "0x33FB244", Length = "0x100")]
	[Token(Token = "0x6000238")]
	private static void MoveCenterX(RectTransform rt, float centerX, RectTransform parent) { }

	[Address(RVA = "0x33FCC48", Offset = "0x33FCC48", Length = "0xF4")]
	[Token(Token = "0x600024B")]
	private RectTransform NewColumn(string name) { }

	[Address(RVA = "0x33FD250", Offset = "0x33FD250", Length = "0x1A0")]
	[Token(Token = "0x600024F")]
	private void OnDisable() { }

	[Address(RVA = "0x33FD13C", Offset = "0x33FD13C", Length = "0x114")]
	[Token(Token = "0x600024E")]
	private void OnEnable() { }

	[Address(RVA = "0x33FBA48", Offset = "0x33FBA48", Length = "0x46C")]
	[Token(Token = "0x600023F")]
	public void PlayGainFly(RectTransform fromCell, int placed, int total, int score, int gain, bool hasScore) { }

	[Address(RVA = "0x33FC4F0", Offset = "0x33FC4F0", Length = "0x19C")]
	[Token(Token = "0x6000245")]
	private void Punch(Transform t) { }

	[Address(RVA = "0x33FC68C", Offset = "0x33FC68C", Length = "0x90")]
	[IteratorStateMachine(typeof(<PunchScale>d__105))]
	[Token(Token = "0x6000246")]
	private IEnumerator PunchScale(Transform t, Vector3 baseScale) { }

	[Address(RVA = "0x33F9380", Offset = "0x33F9380", Length = "0x27C")]
	[Token(Token = "0x6000250")]
	private void RefreshHeaderLoc() { }

	[Address(RVA = "0x33FBEBC", Offset = "0x33FBEBC", Length = "0x1D4")]
	[Token(Token = "0x6000244")]
	private void ResolveCounterIcon() { }

	[Address(RVA = "0x33FAAE4", Offset = "0x33FAAE4", Length = "0x38")]
	[Token(Token = "0x6000230")]
	public void ResumeTimer() { }

	[Address(RVA = "0x33FB7D4", Offset = "0x33FB7D4", Length = "0x7C")]
	[IteratorStateMachine(typeof(<RollScore>d__84))]
	[Token(Token = "0x600023B")]
	private IEnumerator RollScore(int target) { }

	[Address(RVA = "0x33FB65C", Offset = "0x33FB65C", Length = "0x178")]
	[Token(Token = "0x600023A")]
	private void RollScoreTo(int target) { }

	[Address(RVA = "0x33FB97C", Offset = "0x33FB97C", Length = "0xA4")]
	[IteratorStateMachine(typeof(<ScoreColorTween>d__90))]
	[Token(Token = "0x600023E")]
	private IEnumerator ScoreColorTween(Color from, float dur) { }

	[Address(RVA = "0x33FDF40", Offset = "0x33FDF40", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000258")]
	private void set_GoldenLife(bool value) { }

	[Address(RVA = "0x33F99C0", Offset = "0x33F99C0", Length = "0x25C")]
	[Token(Token = "0x600022C")]
	public void SetDailyInfo(DateTime date) { }

	[Address(RVA = "0x33FDF48", Offset = "0x33FDF48", Length = "0x49C")]
	[Token(Token = "0x6000259")]
	public void SetGoldenLife(bool on, Sprite icon = null, Color tint = null) { }

	[Address(RVA = "0x33FC090", Offset = "0x33FC090", Length = "0x14")]
	[Token(Token = "0x6000253")]
	public void SetHamsterCount(int placed, int total) { }

	[Address(RVA = "0x33F8F04", Offset = "0x33F8F04", Length = "0x108")]
	[Token(Token = "0x6000229")]
	public void SetLabel(string text) { }

	[Address(RVA = "0x33F8C64", Offset = "0x33F8C64", Length = "0x8")]
	[Token(Token = "0x6000228")]
	public void SetLevel(int level) { }

	[Address(RVA = "0x33F8C6C", Offset = "0x33F8C6C", Length = "0x298")]
	[Token(Token = "0x600022A")]
	public void SetLevelInfo(int level, bool hard) { }

	[Address(RVA = "0x33FD8B4", Offset = "0x33FD8B4", Length = "0x370")]
	[Token(Token = "0x6000256")]
	public void SetLife(int remaining) { }

	[Address(RVA = "0x33F9730", Offset = "0x33F9730", Length = "0xF4")]
	[Token(Token = "0x6000239")]
	public void SetScore(int score) { }

	[Address(RVA = "0x33F9824", Offset = "0x33F9824", Length = "0x19C")]
	[Token(Token = "0x600022B")]
	public void SetScoreOnlyInfo() { }

	[Address(RVA = "0x33F9C1C", Offset = "0x33F9C1C", Length = "0x10")]
	[Token(Token = "0x600022D")]
	public void SetTimerSource(Func<float> source) { }

	[Address(RVA = "0x33FEB04", Offset = "0x33FEB04", Length = "0x9C")]
	[IteratorStateMachine(typeof(<Shake>d__149))]
	[Token(Token = "0x6000261")]
	private IEnumerator Shake(Transform t, float mag, float dur) { }

	[Address(RVA = "0x33FDE24", Offset = "0x33FDE24", Length = "0x114")]
	[Token(Token = "0x600025F")]
	private void StartShake(Transform t, float mag, float dur) { }

	[Address(RVA = "0x33F9C2C", Offset = "0x33F9C2C", Length = "0x3C")]
	[Token(Token = "0x600022E")]
	public void StartTimer() { }

	[Address(RVA = "0x33FAA74", Offset = "0x33FAA74", Length = "0x24")]
	[Token(Token = "0x600022F")]
	public void StopTimer() { }

	[Address(RVA = "0x33FD618", Offset = "0x33FD618", Length = "0x108")]
	[Token(Token = "0x6000252")]
	private void SyncValueFontSizes() { }

	[Address(RVA = "0x33FE9E0", Offset = "0x33FE9E0", Length = "0x124")]
	[Token(Token = "0x600025E")]
	public void TintLifeSpent(int index) { }

	[Address(RVA = "0x33FB878", Offset = "0x33FB878", Length = "0x104")]
	[Token(Token = "0x600023D")]
	private void TweenScoreColor(Color target, float dur) { }

	[Address(RVA = "0x33FAB1C", Offset = "0x33FAB1C", Length = "0x7C")]
	[Token(Token = "0x6000232")]
	private void Update() { }

}

