namespace Hamdoku.Managers;

[Token(Token = "0x200009D")]
public sealed class ForceUpdateGate : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x200009E")]
	private sealed class <>c
	{
		[Token(Token = "0x400031B")]
		public static readonly <>c <>9; //Field offset: 0x0
		[Token(Token = "0x400031C")]
		public static UnityAction <>9__27_0; //Field offset: 0x8

		[Address(RVA = "0x32FF418", Offset = "0x32FF418", Length = "0x68")]
		[Token(Token = "0x6000328")]
		private static <>c() { }

		[Address(RVA = "0x32FF480", Offset = "0x32FF480", Length = "0x8")]
		[Token(Token = "0x6000329")]
		public <>c() { }

		[Address(RVA = "0x32FF488", Offset = "0x32FF488", Length = "0x58")]
		[Token(Token = "0x600032A")]
		internal void <BuildPreviewCloseX>b__27_0() { }

	}

	[Token(Token = "0x4000312")]
	private const int SortOrder = 32760; //Field offset: 0x0
	[Token(Token = "0x4000313")]
	private const string AppStoreId = "6795797684"; //Field offset: 0x0
	[Token(Token = "0x4000314")]
	private static readonly Vector2 RefPanel; //Field offset: 0x0
	[Token(Token = "0x4000315")]
	private static ForceUpdateGate _open; //Field offset: 0x8
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000316")]
	private string _storeUrl; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000317")]
	private bool _preview; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000318")]
	private CanvasGroup _group; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000319")]
	private RectTransform _panel; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400031A")]
	private RectTransform _content; //Field offset: 0x40

	[Token(Token = "0x17000050")]
	private static ForceUpdateGateConfig Cfg
	{
		[Address(RVA = "0x3227428", Offset = "0x3227428", Length = "0x8")]
		[Token(Token = "0x6000314")]
		 get { } //Length: 8
	}

	[Token(Token = "0x1700004F")]
	public static bool IsOpen
	{
		[Address(RVA = "0x3221BDC", Offset = "0x3221BDC", Length = "0x8C")]
		[Token(Token = "0x6000312")]
		 get { } //Length: 140
	}

	[Token(Token = "0x17000051")]
	public static int RuntimeVersion
	{
		[Address(RVA = "0x3227430", Offset = "0x3227430", Length = "0x84C")]
		[Token(Token = "0x6000316")]
		 get { } //Length: 2124
	}

	[Address(RVA = "0x32299F4", Offset = "0x32299F4", Length = "0x50")]
	[Token(Token = "0x6000326")]
	private static ForceUpdateGate() { }

	[Address(RVA = "0x32299EC", Offset = "0x32299EC", Length = "0x8")]
	[Token(Token = "0x6000325")]
	public ForceUpdateGate() { }

	[Address(RVA = "0x3229A44", Offset = "0x3229A44", Length = "0x1C")]
	[CompilerGenerated]
	[Token(Token = "0x6000327")]
	private void <BuildButton>b__26_0() { }

	[Address(RVA = "0x3227F24", Offset = "0x3227F24", Length = "0x5F4")]
	[Token(Token = "0x600031C")]
	private void Build() { }

	[Address(RVA = "0x3228B68", Offset = "0x3228B68", Length = "0x1AC")]
	[Token(Token = "0x600031F")]
	private void BuildBody() { }

	[Address(RVA = "0x3228D14", Offset = "0x3228D14", Length = "0x7F0")]
	[Token(Token = "0x6000320")]
	private void BuildButton() { }

	[Address(RVA = "0x3228938", Offset = "0x3228938", Length = "0x230")]
	[Token(Token = "0x600031E")]
	private void BuildMascot() { }

	[Address(RVA = "0x3229504", Offset = "0x3229504", Length = "0x32C")]
	[Token(Token = "0x6000321")]
	private void BuildPreviewCloseX() { }

	[Address(RVA = "0x32287AC", Offset = "0x32287AC", Length = "0x18C")]
	[Token(Token = "0x600031D")]
	private void BuildTitle() { }

	[Address(RVA = "0x32285E8", Offset = "0x32285E8", Length = "0x100")]
	[Token(Token = "0x600031A")]
	public static void CloseIfPreview() { }

	[Address(RVA = "0x3227C7C", Offset = "0x3227C7C", Length = "0x78")]
	[Token(Token = "0x6000317")]
	private static string DefaultStoreUrl() { }

	[Address(RVA = "0x3221F50", Offset = "0x3221F50", Length = "0x1D0")]
	[Token(Token = "0x6000315")]
	public static void Evaluate(long minVersion, string storeUrl) { }

	[Address(RVA = "0x32298C4", Offset = "0x32298C4", Length = "0x70")]
	[Token(Token = "0x6000323")]
	private static void FitOneLine(TMP_Text t, float size, float minScale) { }

	[Address(RVA = "0x3227428", Offset = "0x3227428", Length = "0x8")]
	[Token(Token = "0x6000314")]
	private static ForceUpdateGateConfig get_Cfg() { }

	[Address(RVA = "0x3221BDC", Offset = "0x3221BDC", Length = "0x8C")]
	[Token(Token = "0x6000312")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x3227430", Offset = "0x3227430", Length = "0x84C")]
	[Token(Token = "0x6000316")]
	public static int get_RuntimeVersion() { }

	[Address(RVA = "0x3229830", Offset = "0x3229830", Length = "0x94")]
	[Token(Token = "0x6000324")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x32286E8", Offset = "0x32286E8", Length = "0xC4")]
	[Token(Token = "0x600031B")]
	private void OnDestroy() { }

	[Address(RVA = "0x3229934", Offset = "0x3229934", Length = "0xB8")]
	[Token(Token = "0x6000322")]
	private void OpenStore() { }

	[Address(RVA = "0x32273CC", Offset = "0x32273CC", Length = "0x5C")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000313")]
	private static void ResetStatics() { }

	[Address(RVA = "0x3227CF4", Offset = "0x3227CF4", Length = "0x230")]
	[Token(Token = "0x6000318")]
	private static void Show(string storeUrl, bool preview) { }

	[Address(RVA = "0x3228518", Offset = "0x3228518", Length = "0xD0")]
	[Token(Token = "0x6000319")]
	public static void ShowPreview() { }

}

