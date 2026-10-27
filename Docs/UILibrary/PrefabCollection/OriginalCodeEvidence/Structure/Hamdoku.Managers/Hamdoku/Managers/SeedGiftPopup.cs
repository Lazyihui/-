namespace Hamdoku.Managers;

[Token(Token = "0x2000259")]
public sealed class SeedGiftPopup : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x200025A")]
	private sealed class <>c
	{
		[Token(Token = "0x4000F62")]
		public static readonly <>c <>9; //Field offset: 0x0
		[Token(Token = "0x4000F63")]
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pos", "rot", "scale", "front"})]
		public static Comparison<ValueTuple<Vector2, float, float, bool>> <>9__30_2; //Field offset: 0x8

		[Address(RVA = "0x32BA670", Offset = "0x32BA670", Length = "0x68")]
		[Token(Token = "0x6001149")]
		private static <>c() { }

		[Address(RVA = "0x32BA6D8", Offset = "0x32BA6D8", Length = "0x8")]
		[Token(Token = "0x600114A")]
		public <>c() { }

		[Address(RVA = "0x32BA6E0", Offset = "0x32BA6E0", Length = "0x10")]
		[Token(Token = "0x600114B")]
		internal int <BuildSeedPiles>b__30_2(ValueTuple<Vector2, float, float, bool> a, ValueTuple<Vector2, float, float, bool> b) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200025B")]
	private struct <>c__DisplayClass30_0
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000F64")]
		public Random rng; //Field offset: 0x0

	}

	[CompilerGenerated]
	[Token(Token = "0x200025C")]
	private sealed class <>c__DisplayClass33_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000F65")]
		public SeedGiftPopup <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000F66")]
		public Action onClick; //Field offset: 0x18

		[Address(RVA = "0x32B97F8", Offset = "0x32B97F8", Length = "0x8")]
		[Token(Token = "0x600114C")]
		public <>c__DisplayClass33_0() { }

		[Address(RVA = "0x32BA6F0", Offset = "0x32BA6F0", Length = "0x48")]
		[Token(Token = "0x600114D")]
		internal void <MakePill>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200025D")]
	private sealed class <>c__DisplayClass40_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000F67")]
		public GameObject startGo; //Field offset: 0x10

		[Address(RVA = "0x32BA738", Offset = "0x32BA738", Length = "0x8")]
		[Token(Token = "0x600114E")]
		public <>c__DisplayClass40_0() { }

		[Address(RVA = "0x32BA740", Offset = "0x32BA740", Length = "0x104")]
		[Token(Token = "0x600114F")]
		internal void <FlyAndClose>b__0(bool last) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200025E")]
	private sealed class <FlyAndClose>d__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000F68")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000F69")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000F6A")]
		public int seeds; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000F6B")]
		public SeedGiftPopup <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000F6C")]
		public RectTransform from; //Field offset: 0x30

		[Token(Token = "0x1700025E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32BAF88", Offset = "0x32BAF88", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6001153")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700025F")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32BAFC8", Offset = "0x32BAFC8", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6001155")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32BA264", Offset = "0x32BA264", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6001150")]
		public <FlyAndClose>d__40(int <>1__state) { }

		[Address(RVA = "0x32BA848", Offset = "0x32BA848", Length = "0x740")]
		[Token(Token = "0x6001152")]
		private bool MoveNext() { }

		[Address(RVA = "0x32BAF88", Offset = "0x32BAF88", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6001153")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32BAFC8", Offset = "0x32BAFC8", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6001155")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32BAF90", Offset = "0x32BAF90", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6001154")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32BA844", Offset = "0x32BA844", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6001151")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000F52")]
	private static SeedGiftPopup _open; //Field offset: 0x0
	[Token(Token = "0x4000F53")]
	private const int SortOrder = 956; //Field offset: 0x0
	[Token(Token = "0x4000F54")]
	private static readonly Vector2 RefPanel; //Field offset: 0x8
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000F55")]
	private Action<bool> _onResult; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000F56")]
	private bool _preview; //Field offset: 0x28
	[FieldOffset(Offset = "0x29")]
	[Token(Token = "0x4000F57")]
	private bool _busy; //Field offset: 0x29
	[FieldOffset(Offset = "0x2A")]
	[Token(Token = "0x4000F58")]
	private bool _claimed; //Field offset: 0x2A
	[FieldOffset(Offset = "0x2B")]
	[Token(Token = "0x4000F59")]
	private bool _closed; //Field offset: 0x2B
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000F5A")]
	private CanvasGroup _group; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000F5B")]
	private RectTransform _panel; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000F5C")]
	private RectTransform _content; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000F5D")]
	private RectTransform _hero; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000F5E")]
	private SeedGiftChewFx _chew; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000F5F")]
	private RectTransform _btnAd; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000F60")]
	private RectTransform _btnFree; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000F61")]
	private int _bodyVariant; //Field offset: 0x68

	[Token(Token = "0x1700025D")]
	private static SeedGiftConfig Cfg
	{
		[Address(RVA = "0x32B5B2C", Offset = "0x32B5B2C", Length = "0x8")]
		[Token(Token = "0x600112B")]
		 get { } //Length: 8
	}

	[Token(Token = "0x1700025C")]
	public static bool IsOpen
	{
		[Address(RVA = "0x32B58FC", Offset = "0x32B58FC", Length = "0x8C")]
		[Token(Token = "0x6001126")]
		 get { } //Length: 140
	}

	[Address(RVA = "0x32BA548", Offset = "0x32BA548", Length = "0x50")]
	[Token(Token = "0x6001144")]
	private static SeedGiftPopup() { }

	[Address(RVA = "0x32BA538", Offset = "0x32BA538", Length = "0x10")]
	[Token(Token = "0x6001143")]
	public SeedGiftPopup() { }

	[Address(RVA = "0x32BA598", Offset = "0x32BA598", Length = "0x3C")]
	[CompilerGenerated]
	[Token(Token = "0x6001145")]
	private void <BuildCloseX>b__28_0() { }

	[Address(RVA = "0x32B84DC", Offset = "0x32B84DC", Length = "0x34")]
	[CompilerGenerated]
	[Token(Token = "0x6001146")]
	internal static float <BuildSeedPiles>g__J|30_0(ref <>c__DisplayClass30_0 unnamed_param_0) { }

	[Address(RVA = "0x32B8510", Offset = "0x32B8510", Length = "0x14C")]
	[CompilerGenerated]
	[Token(Token = "0x6001147")]
	internal static float <BuildSeedPiles>g__Pose|30_1(float tiltMax, ref <>c__DisplayClass30_0 unnamed_param_1) { }

	[Address(RVA = "0x32BA5D4", Offset = "0x32BA5D4", Length = "0x9C")]
	[CompilerGenerated]
	[Token(Token = "0x6001148")]
	private void <Close>b__44_0() { }

	[Address(RVA = "0x32B865C", Offset = "0x32B865C", Length = "0xF0")]
	[Token(Token = "0x6001141")]
	private static string BodyText(int variant) { }

	[Address(RVA = "0x32B5B94", Offset = "0x32B5B94", Length = "0x64C")]
	[Token(Token = "0x600112E")]
	private void Build() { }

	[Address(RVA = "0x32B6E3C", Offset = "0x32B6E3C", Length = "0x288")]
	[Token(Token = "0x6001134")]
	private void BuildButtons() { }

	[Address(RVA = "0x32B6444", Offset = "0x32B6444", Length = "0x2D4")]
	[Token(Token = "0x6001130")]
	private void BuildCloseX() { }

	[Address(RVA = "0x32B6C80", Offset = "0x32B6C80", Length = "0x1BC")]
	[Token(Token = "0x6001133")]
	private void BuildDesc() { }

	[Address(RVA = "0x32B6718", Offset = "0x32B6718", Length = "0x568")]
	[Token(Token = "0x6001131")]
	private void BuildHero() { }

	[Address(RVA = "0x32B7204", Offset = "0x32B7204", Length = "0x12D8")]
	[Token(Token = "0x6001132")]
	private ValueTuple<RectTransform, RectTransform> BuildSeedPiles(RectTransform frame, float hw, float hh) { }

	[Address(RVA = "0x32B62AC", Offset = "0x32B62AC", Length = "0x198")]
	[Token(Token = "0x600112F")]
	private void BuildTitle() { }

	[Address(RVA = "0x32BA08C", Offset = "0x32BA08C", Length = "0x1D8")]
	[Token(Token = "0x6001140")]
	private void Close() { }

	[Address(RVA = "0x32B5A40", Offset = "0x32B5A40", Length = "0xD4")]
	[Token(Token = "0x600112A")]
	public static void CloseOpen() { }

	[Address(RVA = "0x32B5B14", Offset = "0x32B5B14", Length = "0x18")]
	[Token(Token = "0x600113F")]
	private void Dismiss() { }

	[Address(RVA = "0x32B7194", Offset = "0x32B7194", Length = "0x70")]
	[Token(Token = "0x6001136")]
	private static void FitOneLine(TMP_Text t, float size, float minScale) { }

	[Address(RVA = "0x32B9FFC", Offset = "0x32B9FFC", Length = "0x90")]
	[IteratorStateMachine(typeof(<FlyAndClose>d__40))]
	[Token(Token = "0x600113C")]
	private IEnumerator FlyAndClose(int seeds, RectTransform from) { }

	[Address(RVA = "0x32B5B2C", Offset = "0x32B5B2C", Length = "0x8")]
	[Token(Token = "0x600112B")]
	private static SeedGiftConfig get_Cfg() { }

	[Address(RVA = "0x32B58FC", Offset = "0x32B58FC", Length = "0x8C")]
	[Token(Token = "0x6001126")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x32B99A4", Offset = "0x32B99A4", Length = "0x1CC")]
	[Token(Token = "0x600113A")]
	private void HandleResult(Result r) { }

	[Address(RVA = "0x32B70C4", Offset = "0x32B70C4", Length = "0xD0")]
	[Token(Token = "0x6001142")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x32B991C", Offset = "0x32B991C", Length = "0x88")]
	[Token(Token = "0x6001139")]
	private void LogClick(string detail) { }

	[Address(RVA = "0x32B8854", Offset = "0x32B8854", Length = "0xE9C")]
	[Token(Token = "0x6001135")]
	private RectTransform MakePill(string name, string label, bool primary, Vector2 size, float y, int seeds, bool adIcon, Action onClick) { }

	[Address(RVA = "0x32B9BC8", Offset = "0x32B9BC8", Length = "0x11C")]
	[Token(Token = "0x6001138")]
	private void OnAd() { }

	[Address(RVA = "0x32B61E0", Offset = "0x32B61E0", Length = "0xCC")]
	[Token(Token = "0x600112D")]
	private void OnDestroy() { }

	[Address(RVA = "0x32B9800", Offset = "0x32B9800", Length = "0x11C")]
	[Token(Token = "0x6001137")]
	private void OnFree() { }

	[Address(RVA = "0x32BA344", Offset = "0x32BA344", Length = "0x1F4")]
	[Token(Token = "0x600113E")]
	private RectTransform RankCardRect() { }

	[Address(RVA = "0x32B5988", Offset = "0x32B5988", Length = "0x64")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6001127")]
	private static void ResetStatics() { }

	[Address(RVA = "0x32B9E80", Offset = "0x32B9E80", Length = "0x17C")]
	[Token(Token = "0x600113B")]
	private void SetButtons(bool on) { }

	[Address(RVA = "0x32B3F60", Offset = "0x32B3F60", Length = "0x1A8")]
	[Token(Token = "0x6001128")]
	public static void Show(Action<bool> onResult, bool preview = false) { }

	[Address(RVA = "0x32B59EC", Offset = "0x32B59EC", Length = "0x54")]
	[Token(Token = "0x6001129")]
	public static void ShowPreview() { }

	[Address(RVA = "0x32B5B34", Offset = "0x32B5B34", Length = "0x60")]
	[Token(Token = "0x600112C")]
	private void Start() { }

	[Address(RVA = "0x32BA28C", Offset = "0x32BA28C", Length = "0xB8")]
	[Token(Token = "0x600113D")]
	private static Vector2 ToRootLocal(RectTransform root, RectTransform target) { }

}

