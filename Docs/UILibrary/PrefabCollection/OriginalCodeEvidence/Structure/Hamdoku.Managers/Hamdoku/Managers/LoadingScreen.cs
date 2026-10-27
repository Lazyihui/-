namespace Hamdoku.Managers;

[Token(Token = "0x20001C4")]
public sealed class LoadingScreen : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20001C5")]
	private sealed class <>c__DisplayClass46_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B39")]
		public bool agreed; //Field offset: 0x10

		[Address(RVA = "0x323F078", Offset = "0x323F078", Length = "0x8")]
		[Token(Token = "0x6000CCC")]
		public <>c__DisplayClass46_0() { }

		[Address(RVA = "0x323F080", Offset = "0x323F080", Length = "0xC")]
		[Token(Token = "0x6000CCD")]
		internal void <Start>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001C6")]
	private sealed class <Start>d__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B3A")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000B3B")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000B3C")]
		public LoadingScreen <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000B3D")]
		private <>c__DisplayClass46_0 <>8__1; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000B3E")]
		private AsyncOperation <op>5__2; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000B3F")]
		private float <t>5__3; //Field offset: 0x38

		[Token(Token = "0x170001C5")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x323F530", Offset = "0x323F530", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000CD1")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170001C6")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x323F570", Offset = "0x323F570", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000CD3")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x323F08C", Offset = "0x323F08C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000CCE")]
		public <Start>d__46(int <>1__state) { }

		[Address(RVA = "0x323F0B8", Offset = "0x323F0B8", Length = "0x478")]
		[Token(Token = "0x6000CD0")]
		private bool MoveNext() { }

		[Address(RVA = "0x323F530", Offset = "0x323F530", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000CD1")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x323F570", Offset = "0x323F570", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000CD3")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x323F538", Offset = "0x323F538", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000CD2")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x323F0B4", Offset = "0x323F0B4", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000CCF")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000B21")]
	private const float DefaultSeedPopSeconds = 0.34; //Field offset: 0x0
	[Token(Token = "0x4000B1A")]
	private const float DefaultQuoteLineHeightPercent = 170; //Field offset: 0x0
	[Token(Token = "0x4000B19")]
	private const float DefaultQuoteBySizePercent = 70; //Field offset: 0x0
	[Token(Token = "0x4000B18")]
	private const float DefaultQuoteAnchorY = 0.37; //Field offset: 0x0
	[Token(Token = "0x4000B17")]
	private const float DefaultQuoteFontSizeMin = 24; //Field offset: 0x0
	[Token(Token = "0x4000B16")]
	private const float DefaultQuoteFontSize = 44; //Field offset: 0x0
	[Token(Token = "0x4000B1C")]
	private const int DefaultSeedCount = 5; //Field offset: 0x0
	[Token(Token = "0x4000B13")]
	private static readonly Color BgColor; //Field offset: 0x0
	[Token(Token = "0x4000B1D")]
	private const float DefaultSeedSize = 84; //Field offset: 0x0
	[Token(Token = "0x4000B1F")]
	private const float DefaultSeedAnchorY = 0.28; //Field offset: 0x0
	[Token(Token = "0x4000B20")]
	private const float DefaultSeedPopScale = 1.18; //Field offset: 0x0
	[Token(Token = "0x4000B22")]
	private const float DefaultSeedIdlePulse = 0.05; //Field offset: 0x0
	[Token(Token = "0x4000B23")]
	private const float DefaultSeedMarkScale = 0.92; //Field offset: 0x0
	[Token(Token = "0x4000B24")]
	private const float DefaultSeedMarkY = 0.88; //Field offset: 0x0
	[Token(Token = "0x4000B25")]
	private const float DefaultFinishHold = 0.3; //Field offset: 0x0
	[Token(Token = "0x4000B1E")]
	private const float DefaultSeedSpacing = 14; //Field offset: 0x0
	[Token(Token = "0x4000B14")]
	private static readonly Color DotColor; //Field offset: 0x10
	[Token(Token = "0x4000B15")]
	private static readonly Color QuoteColor; //Field offset: 0x20
	[Token(Token = "0x4000B1B")]
	private static readonly Vector2 DefaultQuoteBox; //Field offset: 0x30
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4000B0B")]
	[Tooltip("배경 스프라이트(MenuBackground)")]
	private Sprite background; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4000B0C")]
	[Tooltip("로고 스프라이트(Logo)")]
	private Sprite logo; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x4000B0D")]
	private string nextScene; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4000B0E")]
	[Tooltip("최소 표시 시간(초). 로딩이 빨라도 이만큼은 보여준다")]
	private float minShowSeconds; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Header("저작권 (CI 가이드 요건)")]
	[SerializeField]
	[Token(Token = "0x4000B0F")]
	[Tooltip("화면 최하단 중앙 표기. 비우면 표시하지 않는다")]
	private string copyrightText; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Token(Token = "0x4000B10")]
	private float copyrightFontSize; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[SerializeField]
	[Token(Token = "0x4000B11")]
	[Tooltip("크림 배경 위에 얹히므로 캣잼의 흰색 대신 어두운 갈색을 쓴다")]
	private Color copyrightColor; //Field offset: 0x4C
	[FieldOffset(Offset = "0x5C")]
	[SerializeField]
	[Token(Token = "0x4000B12")]
	[Tooltip("화면 하단에서 띄울 거리(px). 제스처바/노치 회피용 여백")]
	private float copyrightBottomOffset; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000B26")]
	private RectTransform _root; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000B27")]
	private RectTransform _logoRt; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000B28")]
	private CanvasGroup _logoCg; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000B29")]
	private RectTransform _seedRowParent; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000B2A")]
	private RectTransform[] _seedSlots; //Field offset: 0x80
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000B2B")]
	private Transform[] _seedOff; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000B2C")]
	private CanvasGroup[] _seedOffCg; //Field offset: 0x90
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000B2D")]
	private Transform[] _seedOn; //Field offset: 0x98
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000B2E")]
	private CanvasGroup[] _seedOnCg; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000B2F")]
	private Transform[] _seedPop; //Field offset: 0xA8
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000B30")]
	private CanvasGroup[] _seedPopCg; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000B31")]
	private float[] _seedPopAt; //Field offset: 0xB8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000B32")]
	private int _seedFilled; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x4000B33")]
	private float _progress; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000B34")]
	private float _fullAt; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000B35")]
	private TMP_Text _quote; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000B36")]
	private RectTransform _quoteRt; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000B37")]
	private string _quoteBody; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000B38")]
	private string _quoteBy; //Field offset: 0xE8

	[Token(Token = "0x170001C3")]
	private static float FinishHoldSeconds
	{
		[Address(RVA = "0x323CEA0", Offset = "0x323CEA0", Length = "0x88")]
		[Token(Token = "0x6000CC1")]
		 get { } //Length: 136
	}

	[Token(Token = "0x170001C4")]
	private static bool TuningHold
	{
		[Address(RVA = "0x323CF28", Offset = "0x323CF28", Length = "0x8")]
		[Token(Token = "0x6000CC2")]
		 get { } //Length: 8
	}

	[Address(RVA = "0x323EFF4", Offset = "0x323EFF4", Length = "0x84")]
	[Token(Token = "0x6000CCB")]
	private static LoadingScreen() { }

	[Address(RVA = "0x323EF48", Offset = "0x323EF48", Length = "0xAC")]
	[Token(Token = "0x6000CCA")]
	public LoadingScreen() { }

	[Address(RVA = "0x323DE64", Offset = "0x323DE64", Length = "0x61C")]
	[Token(Token = "0x6000CC7")]
	private void AnimateSeeds(float t) { }

	[Address(RVA = "0x323C900", Offset = "0x323C900", Length = "0x5A0")]
	[Token(Token = "0x6000CC0")]
	private void ApplyQuoteConfig() { }

	[Address(RVA = "0x323D8F4", Offset = "0x323D8F4", Length = "0x3F4")]
	[Token(Token = "0x6000CC5")]
	private void ApplySeedConfig() { }

	[Address(RVA = "0x323EC70", Offset = "0x323EC70", Length = "0x2D8")]
	[Token(Token = "0x6000CC9")]
	private void BuildCopyright(RectTransform root) { }

	[Address(RVA = "0x323CF30", Offset = "0x323CF30", Length = "0x748")]
	[Token(Token = "0x6000CC3")]
	private void BuildSeedRow(RectTransform root) { }

	[Address(RVA = "0x323E480", Offset = "0x323E480", Length = "0x7F0")]
	[Token(Token = "0x6000CC8")]
	private void BuildUI() { }

	[Address(RVA = "0x323CEA0", Offset = "0x323CEA0", Length = "0x88")]
	[Token(Token = "0x6000CC1")]
	private static float get_FinishHoldSeconds() { }

	[Address(RVA = "0x323CF28", Offset = "0x323CF28", Length = "0x8")]
	[Token(Token = "0x6000CC2")]
	private static bool get_TuningHold() { }

	[Address(RVA = "0x323D678", Offset = "0x323D678", Length = "0x27C")]
	[Token(Token = "0x6000CC4")]
	private GameObject MakeSeedLayer(RectTransform slot, string name, Sprite sprite, out CanvasGroup cg) { }

	[Address(RVA = "0x323DCE8", Offset = "0x323DCE8", Length = "0x17C")]
	[Token(Token = "0x6000CC6")]
	private void SetProgress(float p) { }

	[Address(RVA = "0x323C88C", Offset = "0x323C88C", Length = "0x74")]
	[IteratorStateMachine(typeof(<Start>d__46))]
	[Token(Token = "0x6000CBF")]
	private IEnumerator Start() { }

}

