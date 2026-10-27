namespace Hamdoku.Managers;

[Token(Token = "0x20001B5")]
public sealed class HintPreview : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20001B6")]
	private sealed class <PulseLoop>d__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000AC3")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000AC4")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000AC5")]
		public HintPreview <>4__this; //Field offset: 0x20

		[Token(Token = "0x170001B2")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3236CC0", Offset = "0x3236CC0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000C5E")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170001B3")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3236D00", Offset = "0x3236D00", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000C60")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x323608C", Offset = "0x323608C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000C5B")]
		public <PulseLoop>d__59(int <>1__state) { }

		[Address(RVA = "0x3236AF8", Offset = "0x3236AF8", Length = "0x1C8")]
		[Token(Token = "0x6000C5D")]
		private bool MoveNext() { }

		[Address(RVA = "0x3236CC0", Offset = "0x3236CC0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000C5E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3236D00", Offset = "0x3236D00", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000C60")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3236CC8", Offset = "0x3236CC8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000C5F")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3236AF4", Offset = "0x3236AF4", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000C5C")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000AAE")]
	private const float BubbleSideMargin = 56; //Field offset: 0x0
	[Token(Token = "0x4000AAF")]
	private const float BubbleLineSpacing = 48; //Field offset: 0x0
	[Token(Token = "0x4000AB0")]
	private static readonly Color Backdrop; //Field offset: 0x0
	[Token(Token = "0x4000AC1")]
	private const float BubbleTopMargin = 16; //Field offset: 0x0
	[Token(Token = "0x4000AB7")]
	private const float PulsePeriod = 0.8; //Field offset: 0x0
	[Token(Token = "0x4000AB8")]
	private const float HypoFillRatio = 0.98; //Field offset: 0x0
	[Token(Token = "0x4000AB6")]
	private const float PulseAmp = 0.12; //Field offset: 0x0
	[Token(Token = "0x4000ABA")]
	private const float BubbleAnchorMin = 0.5; //Field offset: 0x0
	[Token(Token = "0x4000ABB")]
	private const float BubbleAnchorMax = 0.95; //Field offset: 0x0
	[Token(Token = "0x4000ABD")]
	private const float DefaultWideUiScale = 0.72; //Field offset: 0x0
	[Token(Token = "0x4000ABF")]
	private const float BubbleScaleBias = 1.08; //Field offset: 0x0
	[Token(Token = "0x4000AC0")]
	private const float BubbleBoardGap = 24; //Field offset: 0x0
	[Token(Token = "0x4000AB9")]
	private const float DefaultBubbleAnchorY = 0.8; //Field offset: 0x0
	[Token(Token = "0x4000AAD")]
	private const float BubbleMaxWidth = 920; //Field offset: 0x0
	[Token(Token = "0x4000AB1")]
	private static readonly Color Gold; //Field offset: 0x10
	[Token(Token = "0x4000AB2")]
	private static readonly Color BubbleBg; //Field offset: 0x20
	[Token(Token = "0x4000AB3")]
	private static readonly Color BubbleFg; //Field offset: 0x30
	[Token(Token = "0x4000AB4")]
	private static readonly Color ApplyBg; //Field offset: 0x40
	[Token(Token = "0x4000AB5")]
	private static readonly Color XCol; //Field offset: 0x50
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000A9A")]
	private BoardView _board; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000A9B")]
	private RectTransform _canvas; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000A9C")]
	private GameObject _root; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000A9D")]
	private RectTransform _highlightLayer; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000A9E")]
	private RectTransform _bubble; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000A9F")]
	private TMP_Text _bubbleText; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000AA0")]
	private CanvasGroup _hlGroup; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000AA1")]
	private int _hiddenR; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000AA2")]
	private int _hiddenC; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000AA3")]
	private Action _onApply; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000AA4")]
	private TMP_Text _applyLabel; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000AA5")]
	private TMP_Text _applyGlowLabel; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000AA6")]
	private HintResult _proofHint; //Field offset: 0x78
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000AA7")]
	private string _proofStep2Message; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000AA8")]
	private bool _awaitingStep2; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000AA9")]
	private float _openTime; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000AAA")]
	private readonly List<RectTransform> _pulseBoxes; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000AAB")]
	private Coroutine _pulseFx; //Field offset: 0xE8
	[CompilerGenerated]
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000AAC")]
	private bool <IsOpen>k__BackingField; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000ABC")]
	private float _bubbleAnchorY; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000ABE")]
	private float _wideUiScale; //Field offset: 0xF8
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000AC2")]
	private Material _glowMat; //Field offset: 0x100

	[Token(Token = "0x170001B1")]
	public bool IsOpen
	{
		[Address(RVA = "0x32334F4", Offset = "0x32334F4", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000C3D")]
		 get { } //Length: 8
		[Address(RVA = "0x32334FC", Offset = "0x32334FC", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000C3E")]
		private set { } //Length: 8
	}

	[Address(RVA = "0x3236A50", Offset = "0x3236A50", Length = "0xA4")]
	[Token(Token = "0x6000C5A")]
	private static HintPreview() { }

	[Address(RVA = "0x32369B4", Offset = "0x32369B4", Length = "0x9C")]
	[Token(Token = "0x6000C59")]
	public HintPreview() { }

	[Address(RVA = "0x3234ECC", Offset = "0x3234ECC", Length = "0x4C")]
	[Token(Token = "0x6000C4D")]
	private void Apply() { }

	[Address(RVA = "0x3233C9C", Offset = "0x3233C9C", Length = "0x9CC")]
	[Token(Token = "0x6000C56")]
	private void Build() { }

	[Address(RVA = "0x3234668", Offset = "0x3234668", Length = "0x168")]
	[Token(Token = "0x6000C46")]
	private void ClearHighlights() { }

	[Address(RVA = "0x3235F98", Offset = "0x3235F98", Length = "0xF4")]
	[Token(Token = "0x6000C4E")]
	public void Close() { }

	[Address(RVA = "0x3234ADC", Offset = "0x3234ADC", Length = "0x150")]
	[Token(Token = "0x6000C4B")]
	private void FinishShow(string message) { }

	[Address(RVA = "0x32334F4", Offset = "0x32334F4", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000C3D")]
	public bool get_IsOpen() { }

	[Address(RVA = "0x3233504", Offset = "0x3233504", Length = "0x94")]
	[Token(Token = "0x6000C3F")]
	public void Init(BoardView board, RectTransform canvas, float bubbleAnchorY = 0.8, float wideUiScale = 0.72) { }

	[Address(RVA = "0x32360B4", Offset = "0x32360B4", Length = "0x204")]
	[Token(Token = "0x6000C55")]
	private static void MakeBarPart(RectTransform parent, float deg, float len, float thick, Color color, float w) { }

	[Address(RVA = "0x32362B8", Offset = "0x32362B8", Length = "0x65C")]
	[Token(Token = "0x6000C58")]
	private void MakeButton(string name, Color bg, Vector2 anchor, Vector2 size, int fontSize, string label, UnityAction onClick, string spriteName, Color textColor, Nullable<Color> glowColor) { }

	[Address(RVA = "0x32352A8", Offset = "0x32352A8", Length = "0x18C")]
	[Token(Token = "0x6000C52")]
	private void MakeContextBox(int r, int c) { }

	[Address(RVA = "0x32356F4", Offset = "0x32356F4", Length = "0x4EC")]
	[Token(Token = "0x6000C4A")]
	private RectTransform MakeHypotheticalBox(int r, int c) { }

	[Address(RVA = "0x3234FAC", Offset = "0x3234FAC", Length = "0x2FC")]
	[Token(Token = "0x6000C51")]
	private void MakeSourceBox(int r, int c) { }

	[Address(RVA = "0x3235434", Offset = "0x3235434", Length = "0x2C0")]
	[Token(Token = "0x6000C53")]
	private void MakeTargetBox(int r, int c, bool place) { }

	[Address(RVA = "0x3235BE0", Offset = "0x3235BE0", Length = "0x230")]
	[Token(Token = "0x6000C54")]
	private GameObject NewCellBox(RectTransform cellRt, Color color) { }

	[Address(RVA = "0x3236914", Offset = "0x3236914", Length = "0xA0")]
	[Token(Token = "0x6000C57")]
	private void OnDestroy() { }

	[Address(RVA = "0x3233598", Offset = "0x3233598", Length = "0x32C")]
	[Token(Token = "0x6000C40")]
	private void PlaceBubbleAboveBoard() { }

	[Address(RVA = "0x3234EBC", Offset = "0x3234EBC", Length = "0x10")]
	[Token(Token = "0x6000C44")]
	private void PrimaryAction() { }

	[Address(RVA = "0x3235E10", Offset = "0x3235E10", Length = "0x6C")]
	[IteratorStateMachine(typeof(<PulseLoop>d__59))]
	[Token(Token = "0x6000C4F")]
	private IEnumerator PulseLoop() { }

	[Address(RVA = "0x32347D0", Offset = "0x32347D0", Length = "0x12C")]
	[Token(Token = "0x6000C48")]
	private void RenderProofStep1(HintResult h) { }

	[Address(RVA = "0x3234CE0", Offset = "0x3234CE0", Length = "0x1DC")]
	[Token(Token = "0x6000C49")]
	private void RenderProofStep2(HintResult h) { }

	[Address(RVA = "0x32348FC", Offset = "0x32348FC", Length = "0xFC")]
	[Token(Token = "0x6000C47")]
	private void RenderReason(HintResult h) { }

	[Address(RVA = "0x3234F18", Offset = "0x3234F18", Length = "0x94")]
	[Token(Token = "0x6000C50")]
	private void RestoreHiddenHamster() { }

	[Address(RVA = "0x32334FC", Offset = "0x32334FC", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000C3E")]
	private void set_IsOpen(bool value) { }

	[Address(RVA = "0x32338C4", Offset = "0x32338C4", Length = "0x144")]
	[Token(Token = "0x6000C41")]
	public void SetBubbleAnchorY(float y) { }

	[Address(RVA = "0x32349F8", Offset = "0x32349F8", Length = "0xE4")]
	[Token(Token = "0x6000C45")]
	private void SetPrimaryLabel(string label) { }

	[Address(RVA = "0x3233A08", Offset = "0x3233A08", Length = "0x294")]
	[Token(Token = "0x6000C42")]
	public void Show(HintResult h, string message, Action onApply) { }

	[Address(RVA = "0x3234C2C", Offset = "0x3234C2C", Length = "0xB4")]
	[Token(Token = "0x6000C43")]
	private void ShowProofStep2() { }

	[Address(RVA = "0x3235E7C", Offset = "0x3235E7C", Length = "0x11C")]
	[Token(Token = "0x6000C4C")]
	private void Update() { }

}

