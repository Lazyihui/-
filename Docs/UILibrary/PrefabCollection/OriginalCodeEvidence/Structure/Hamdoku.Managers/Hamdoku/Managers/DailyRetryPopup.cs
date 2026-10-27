namespace Hamdoku.Managers;

[Token(Token = "0x2000122")]
public sealed class DailyRetryPopup : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000124")]
	private sealed class <>c__DisplayClass43_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000673")]
		public DailyRetryPopup <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000674")]
		public Action onClick; //Field offset: 0x18

		[Address(RVA = "0x3384920", Offset = "0x3384920", Length = "0x8")]
		[Token(Token = "0x600072C")]
		public <>c__DisplayClass43_0() { }

		[Address(RVA = "0x3386490", Offset = "0x3386490", Length = "0x48")]
		[Token(Token = "0x600072D")]
		internal void <MakePill>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000125")]
	private sealed class <>c__DisplayClass55_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000675")]
		public int seed; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x4000676")]
		public Source source; //Field offset: 0x14
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000677")]
		public Action onGranted; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000678")]
		public Action onFailed; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000679")]
		public Func<bool> stillValid; //Field offset: 0x28

		[Address(RVA = "0x3385E2C", Offset = "0x3385E2C", Length = "0x8")]
		[Token(Token = "0x600072E")]
		public <>c__DisplayClass55_0() { }

		[Address(RVA = "0x33864D8", Offset = "0x33864D8", Length = "0xCC")]
		[Token(Token = "0x600072F")]
		internal void <RetryViaAd>b__0(bool ready) { }

		[Address(RVA = "0x33865A4", Offset = "0x33865A4", Length = "0x7C")]
		[Token(Token = "0x6000730")]
		internal void <RetryViaAd>b__1(string nonce) { }

		[Address(RVA = "0x3386620", Offset = "0x3386620", Length = "0x7C")]
		[Token(Token = "0x6000731")]
		internal void <RetryViaAd>b__2() { }

		[Address(RVA = "0x338669C", Offset = "0x338669C", Length = "0x19C")]
		[Token(Token = "0x6000732")]
		internal void <RetryViaAd>b__3() { }

		[Address(RVA = "0x3386838", Offset = "0x3386838", Length = "0x7C")]
		[Token(Token = "0x6000733")]
		internal void <RetryViaAd>b__4() { }

	}

	[Token(Token = "0x2000123")]
	public enum Source : int
	{
		Lobby = 0,
		Fail = 1,
		Result = 2,
	}

	[Token(Token = "0x400065C")]
	private static DailyRetryPopup _open; //Field offset: 0x0
	[Token(Token = "0x400065D")]
	private const int SortOrder = 990; //Field offset: 0x0
	[Token(Token = "0x400065E")]
	private static readonly Vector2 RefPanel; //Field offset: 0x8
	[Token(Token = "0x400066E")]
	private static bool _adBusy; //Field offset: 0x10
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400065F")]
	private int _seed; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000660")]
	private Source _source; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000661")]
	private bool _makeup; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000662")]
	private Action _onRetry; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000663")]
	private Action _onClose; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000664")]
	private bool _preview; //Field offset: 0x40
	[FieldOffset(Offset = "0x41")]
	[Token(Token = "0x4000665")]
	private bool _busy; //Field offset: 0x41
	[FieldOffset(Offset = "0x42")]
	[Token(Token = "0x4000666")]
	private bool _closed; //Field offset: 0x42
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000667")]
	private CanvasGroup _group; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000668")]
	private RectTransform _panel; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000669")]
	private RectTransform _content; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400066A")]
	private RectTransform _hero; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400066B")]
	private RectTransform _btnAd; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400066C")]
	private RectTransform _btnClose; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400066D")]
	private TMP_Text _adButtonLabel; //Field offset: 0x78

	[Token(Token = "0x170000BE")]
	private static DailyRetryConfig Cfg
	{
		[Address(RVA = "0x3381284", Offset = "0x3381284", Length = "0x8")]
		[Token(Token = "0x6000701")]
		 get { } //Length: 8
	}

	[Token(Token = "0x170000BF")]
	public static bool IsEnabled
	{
		[Address(RVA = "0x338128C", Offset = "0x338128C", Length = "0x8C")]
		[Token(Token = "0x6000702")]
		 get { } //Length: 140
	}

	[Token(Token = "0x170000BD")]
	public static bool IsOpen
	{
		[Address(RVA = "0x3381194", Offset = "0x3381194", Length = "0x8C")]
		[Token(Token = "0x60006FF")]
		 get { } //Length: 140
	}

	[Token(Token = "0x170000C0")]
	public static int MaxPerDay
	{
		[Address(RVA = "0x3381318", Offset = "0x3381318", Length = "0x88")]
		[Token(Token = "0x6000703")]
		 get { } //Length: 136
	}

	[Address(RVA = "0x3385F38", Offset = "0x3385F38", Length = "0x50")]
	[Token(Token = "0x6000723")]
	private static DailyRetryPopup() { }

	[Address(RVA = "0x3385F30", Offset = "0x3385F30", Length = "0x8")]
	[Token(Token = "0x6000722")]
	public DailyRetryPopup() { }

	[Address(RVA = "0x3385F88", Offset = "0x3385F88", Length = "0x28")]
	[CompilerGenerated]
	[Token(Token = "0x6000724")]
	private void <BuildCloseX>b__38_0() { }

	[Address(RVA = "0x33863F4", Offset = "0x33863F4", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x600072B")]
	private void <Close>b__48_0() { }

	[Address(RVA = "0x3385FB0", Offset = "0x3385FB0", Length = "0x138")]
	[CompilerGenerated]
	[Token(Token = "0x6000725")]
	private void <OnRetry>b__45_0(bool ready) { }

	[Address(RVA = "0x33860E8", Offset = "0x33860E8", Length = "0xB8")]
	[CompilerGenerated]
	[Token(Token = "0x6000726")]
	private void <OnRetry>b__45_1(string nonce) { }

	[Address(RVA = "0x33861A0", Offset = "0x33861A0", Length = "0x84")]
	[CompilerGenerated]
	[Token(Token = "0x6000727")]
	private void <OnRetry>b__45_2() { }

	[Address(RVA = "0x3386224", Offset = "0x3386224", Length = "0xCC")]
	[CompilerGenerated]
	[Token(Token = "0x6000728")]
	private bool <OnRetry>b__45_3() { }

	[Address(RVA = "0x33862F0", Offset = "0x33862F0", Length = "0x80")]
	[CompilerGenerated]
	[Token(Token = "0x6000729")]
	private void <OnRetry>b__45_4() { }

	[Address(RVA = "0x3386370", Offset = "0x3386370", Length = "0x84")]
	[CompilerGenerated]
	[Token(Token = "0x600072A")]
	private void <OnRetry>b__45_5() { }

	[Address(RVA = "0x3381A5C", Offset = "0x3381A5C", Length = "0x61C")]
	[Token(Token = "0x600070C")]
	private void Build() { }

	[Address(RVA = "0x33833B0", Offset = "0x33833B0", Length = "0x23C")]
	[Token(Token = "0x6000712")]
	private void BuildButtons() { }

	[Address(RVA = "0x33822D4", Offset = "0x33822D4", Length = "0x2D4")]
	[Token(Token = "0x600070E")]
	private void BuildCloseX() { }

	[Address(RVA = "0x33825A8", Offset = "0x33825A8", Length = "0x604")]
	[Token(Token = "0x600070F")]
	private void BuildHero() { }

	[Address(RVA = "0x3382BAC", Offset = "0x3382BAC", Length = "0x804")]
	[Token(Token = "0x6000711")]
	private void BuildRecordAndDesc() { }

	[Address(RVA = "0x338372C", Offset = "0x338372C", Length = "0x674")]
	[Token(Token = "0x6000710")]
	private void BuildSparkles(RectTransform frame, float hw, float hh) { }

	[Address(RVA = "0x3382144", Offset = "0x3382144", Length = "0x190")]
	[Token(Token = "0x600070D")]
	private void BuildTitle() { }

	[Address(RVA = "0x3381434", Offset = "0x3381434", Length = "0xE4")]
	[Token(Token = "0x6000705")]
	public static bool CanOffer(int seed) { }

	[Address(RVA = "0x33854A8", Offset = "0x33854A8", Length = "0x228")]
	[Token(Token = "0x6000718")]
	private void Close() { }

	[Address(RVA = "0x338180C", Offset = "0x338180C", Length = "0xC4")]
	[Token(Token = "0x6000708")]
	public static void CloseOpen() { }

	[Address(RVA = "0x33818D0", Offset = "0x33818D0", Length = "0xA4")]
	[Token(Token = "0x6000717")]
	private void Dismiss() { }

	[Address(RVA = "0x33836BC", Offset = "0x33836BC", Length = "0x70")]
	[Token(Token = "0x6000714")]
	private static void FitOneLine(TMP_Text t, float size, float minScale) { }

	[Address(RVA = "0x3381284", Offset = "0x3381284", Length = "0x8")]
	[Token(Token = "0x6000701")]
	private static DailyRetryConfig get_Cfg() { }

	[Address(RVA = "0x338128C", Offset = "0x338128C", Length = "0x8C")]
	[Token(Token = "0x6000702")]
	public static bool get_IsEnabled() { }

	[Address(RVA = "0x3381194", Offset = "0x3381194", Length = "0x8C")]
	[Token(Token = "0x60006FF")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x3381318", Offset = "0x3381318", Length = "0x88")]
	[Token(Token = "0x6000703")]
	public static int get_MaxPerDay() { }

	[Address(RVA = "0x3385008", Offset = "0x3385008", Length = "0x238")]
	[Token(Token = "0x6000716")]
	private void Grant() { }

	[Address(RVA = "0x3385EA0", Offset = "0x3385EA0", Length = "0x90")]
	[Token(Token = "0x6000720")]
	private static void GrantRetry(int seed, Action onGranted) { }

	[Address(RVA = "0x33813A0", Offset = "0x33813A0", Length = "0x94")]
	[Token(Token = "0x6000704")]
	public static bool IsCapped(int seed) { }

	[Address(RVA = "0x33835EC", Offset = "0x33835EC", Length = "0xD0")]
	[Token(Token = "0x6000721")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x3384F94", Offset = "0x3384F94", Length = "0x74")]
	[Token(Token = "0x600071A")]
	private void LogClick(string detail) { }

	[Address(RVA = "0x33856D0", Offset = "0x33856D0", Length = "0xC0")]
	[Token(Token = "0x600071B")]
	private static void LogClick(string detail, Source source) { }

	[Address(RVA = "0x3385E34", Offset = "0x3385E34", Length = "0x6C")]
	[Token(Token = "0x600071F")]
	public static void LogSkipped(Source source) { }

	[Address(RVA = "0x3383DA0", Offset = "0x3383DA0", Length = "0xB80")]
	[Token(Token = "0x6000713")]
	private RectTransform MakePill(string name, string label, bool primary, Vector2 size, float y, bool adIcon, Action onClick) { }

	[Address(RVA = "0x3382078", Offset = "0x3382078", Length = "0xCC")]
	[Token(Token = "0x600070B")]
	private void OnDestroy() { }

	[Address(RVA = "0x3384928", Offset = "0x3384928", Length = "0x66C")]
	[Token(Token = "0x6000715")]
	private void OnRetry() { }

	[Address(RVA = "0x3385814", Offset = "0x3385814", Length = "0x58")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x600071D")]
	private static void ResetAdBusy() { }

	[Address(RVA = "0x3381220", Offset = "0x3381220", Length = "0x64")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000700")]
	private static void ResetStatics() { }

	[Address(RVA = "0x338586C", Offset = "0x338586C", Length = "0x5C0")]
	[Token(Token = "0x600071E")]
	public static void RetryViaAd(int seed, Source source, Action onGranted, Action onFailed = null, Func<bool> stillValid = null) { }

	[Address(RVA = "0x3385240", Offset = "0x3385240", Length = "0x268")]
	[Token(Token = "0x6000719")]
	private void SetButtons(bool on) { }

	[Address(RVA = "0x33815A0", Offset = "0x33815A0", Length = "0x1F0")]
	[Token(Token = "0x6000709")]
	private static void Show(int seed, Source source, Action onRetry, Action onClose, bool preview, bool makeup = false) { }

	[Address(RVA = "0x3381518", Offset = "0x3381518", Length = "0x88")]
	[Token(Token = "0x6000706")]
	public static void Show(int seed, Source source, Action onRetry, Action onClose = null, bool makeup = false) { }

	[Address(RVA = "0x3381790", Offset = "0x3381790", Length = "0x7C")]
	[Token(Token = "0x6000707")]
	public static void ShowPreview() { }

	[Address(RVA = "0x3381974", Offset = "0x3381974", Length = "0xE8")]
	[Token(Token = "0x600070A")]
	private void Start() { }

	[Address(RVA = "0x3385790", Offset = "0x3385790", Length = "0x84")]
	[Token(Token = "0x600071C")]
	private static string ValueOf(Source s) { }

}

