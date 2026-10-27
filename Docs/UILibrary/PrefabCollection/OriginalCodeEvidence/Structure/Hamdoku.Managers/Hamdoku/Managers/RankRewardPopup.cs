namespace Hamdoku.Managers;

[Token(Token = "0x2000204")]
public sealed class RankRewardPopup : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x2000206")]
	private sealed class <>c__DisplayClass33_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D18")]
		public RectTransform cell; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D19")]
		public RankPageConfig cfg; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D1A")]
		public Vector2 origin; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D1B")]
		public Sprite sprite; //Field offset: 0x28

		[Address(RVA = "0x32781F8", Offset = "0x32781F8", Length = "0x8")]
		[Token(Token = "0x6000EE6")]
		public <>c__DisplayClass33_0() { }

		[Address(RVA = "0x327943C", Offset = "0x327943C", Length = "0x84")]
		[Token(Token = "0x6000EE8")]
		internal void <AttachCostumeHearts>b__1() { }

		[Address(RVA = "0x3278200", Offset = "0x3278200", Length = "0x610")]
		[Token(Token = "0x6000EE7")]
		internal void <AttachCostumeHearts>g__Spawn|0(float delay, float power) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000207")]
	private sealed class <>c__DisplayClass33_1
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D1C")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3279434", Offset = "0x3279434", Length = "0x8")]
		[Token(Token = "0x6000EE9")]
		public <>c__DisplayClass33_1() { }

		[Address(RVA = "0x32794C0", Offset = "0x32794C0", Length = "0x90")]
		[Token(Token = "0x6000EEA")]
		internal void <AttachCostumeHearts>b__2() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000208")]
	private sealed class <>c__DisplayClass40_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D1D")]
		public int pending; //Field offset: 0x10

		[Address(RVA = "0x3279550", Offset = "0x3279550", Length = "0x8")]
		[Token(Token = "0x6000EEB")]
		public <>c__DisplayClass40_0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000209")]
	private sealed class <>c__DisplayClass40_1
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D1E")]
		public RectTransform target; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D1F")]
		public <>c__DisplayClass40_0 CS$<>8__locals1; //Field offset: 0x18

		[Address(RVA = "0x3279558", Offset = "0x3279558", Length = "0x8")]
		[Token(Token = "0x6000EEC")]
		public <>c__DisplayClass40_1() { }

		[Address(RVA = "0x3279560", Offset = "0x3279560", Length = "0x25C")]
		[Token(Token = "0x6000EED")]
		internal void <CloseWithFly>b__0(bool last) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200020A")]
	private sealed class <>c__DisplayClass43_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D20")]
		public Action onClick; //Field offset: 0x10

		[Address(RVA = "0x3278F24", Offset = "0x3278F24", Length = "0x8")]
		[Token(Token = "0x6000EEE")]
		public <>c__DisplayClass43_0() { }

		[Address(RVA = "0x32797BC", Offset = "0x32797BC", Length = "0x34")]
		[Token(Token = "0x6000EEF")]
		internal void <MakePill>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200020B")]
	private sealed class <AttachTitleIcon>d__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D21")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D22")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D23")]
		public RankRewardPopup <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D24")]
		public TMP_Text title; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000D25")]
		private Sprite <sp>5__2; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000D26")]
		private GameObject <go>5__3; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000D27")]
		private RectTransform <rt>5__4; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000D28")]
		private float <t>5__5; //Field offset: 0x48
		[FieldOffset(Offset = "0x4C")]
		[Token(Token = "0x4000D29")]
		private float <w>5__6; //Field offset: 0x4C

		[Token(Token = "0x1700020C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3279BD0", Offset = "0x3279BD0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EF3")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700020D")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3279C10", Offset = "0x3279C10", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EF5")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32760B8", Offset = "0x32760B8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF0")]
		public <AttachTitleIcon>d__23(int <>1__state) { }

		[Address(RVA = "0x32797F4", Offset = "0x32797F4", Length = "0x3DC")]
		[Token(Token = "0x6000EF2")]
		private bool MoveNext() { }

		[Address(RVA = "0x3279BD0", Offset = "0x3279BD0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF3")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3279C10", Offset = "0x3279C10", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF5")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3279BD8", Offset = "0x3279BD8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF4")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x32797F0", Offset = "0x32797F0", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF1")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200020C")]
	private sealed class <CloseWithFly>d__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D2A")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D2B")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D2C")]
		public RankRewardPopup <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D2D")]
		private <>c__DisplayClass40_0 <>8__1; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000D2E")]
		public int mult; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000D2F")]
		private float <w>5__2; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000D30")]
		private float <guard>5__3; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000D31")]
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"rt", "sp", "n", "bulb"})]
		private Enumerator<ValueTuple<RectTransform, Sprite, int, bool>> <>7__wrap3; //Field offset: 0x40
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x4000D32")]
		private float <gap>5__5; //Field offset: 0x68

		[Token(Token = "0x1700020E")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x327B0A0", Offset = "0x327B0A0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EFA")]
			 get { } //Length: 8
		}

		[Token(Token = "0x1700020F")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x327B0E0", Offset = "0x327B0E0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EFC")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x3278EFC", Offset = "0x3278EFC", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF6")]
		public <CloseWithFly>d__40(int <>1__state) { }

		[Address(RVA = "0x327B050", Offset = "0x327B050", Length = "0x50")]
		[Token(Token = "0x6000EF9")]
		private void <>m__Finally1() { }

		[Address(RVA = "0x3279C34", Offset = "0x3279C34", Length = "0x141C")]
		[Token(Token = "0x6000EF8")]
		private bool MoveNext() { }

		[Address(RVA = "0x327B0A0", Offset = "0x327B0A0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EFA")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x327B0E0", Offset = "0x327B0E0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EFC")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x327B0A8", Offset = "0x327B0A8", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EFB")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3279C18", Offset = "0x3279C18", Length = "0x1C")]
		[DebuggerHidden]
		[Token(Token = "0x6000EF7")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x2000205")]
	public sealed class Args
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000D03")]
		public int rank; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x4000D04")]
		public int rank1Wins; //Field offset: 0x14
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000D05")]
		public int bulb; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000D06")]
		public int glass; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000D07")]
		public bool giveFrame; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x4000D08")]
		public int frameId; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000D09")]
		public int costumeId; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000D0A")]
		public bool preview; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000D0B")]
		public Action<int, int, bool> onClaim; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000D0C")]
		public Action onEquip; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000D0D")]
		public string titleText; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000D0E")]
		public string heroSpritePath; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000D0F")]
		public bool allowDouble; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000D10")]
		public string titleHead; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x4000D11")]
		public string titleSub; //Field offset: 0x60
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x4000D12")]
		public string titleIconPath; //Field offset: 0x68
		[FieldOffset(Offset = "0x70")]
		[Token(Token = "0x4000D13")]
		public float titleIconScale; //Field offset: 0x70
		[FieldOffset(Offset = "0x74")]
		[Token(Token = "0x4000D14")]
		public int sortOrder; //Field offset: 0x74
		[FieldOffset(Offset = "0x78")]
		[Token(Token = "0x4000D15")]
		public string adPlacement; //Field offset: 0x78
		[FieldOffset(Offset = "0x80")]
		[Token(Token = "0x4000D16")]
		public string clickMenu; //Field offset: 0x80
		[FieldOffset(Offset = "0x88")]
		[Token(Token = "0x4000D17")]
		public Action onBeforeFly; //Field offset: 0x88

		[Address(RVA = "0x3274A64", Offset = "0x3274A64", Length = "0x78")]
		[Token(Token = "0x6000EE5")]
		public Args() { }

	}

	[Token(Token = "0x4000CF3")]
	private static RankRewardPopup _open; //Field offset: 0x0
	[Token(Token = "0x4000D02")]
	private const int MaxFlyPieces = 20; //Field offset: 0x0
	[Token(Token = "0x4000CF4")]
	private static readonly Color TitleCol; //Field offset: 0x8
	[Token(Token = "0x4000CF5")]
	private static readonly Color TextCol; //Field offset: 0x18
	[Token(Token = "0x4000CF6")]
	private static readonly Color OrangeBtn; //Field offset: 0x28
	[Token(Token = "0x4000CF7")]
	private static readonly Color LightBtn; //Field offset: 0x38
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000CF8")]
	private Args _args; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000CF9")]
	private CanvasGroup _group; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000CFA")]
	private RectTransform _content; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000CFB")]
	private RectTransform _hero; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000CFC")]
	private GameObject _stage1Btn; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000CFD")]
	private RectTransform _stage2; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000CFE")]
	private bool _busy; //Field offset: 0x50
	[FieldOffset(Offset = "0x51")]
	[Token(Token = "0x4000CFF")]
	private bool _equipOnClaim; //Field offset: 0x51
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000D00")]
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"rt", "sp", "n", "bulb"})]
	private readonly List<ValueTuple<RectTransform, Sprite, int, bool>> _flyItems; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000D01")]
	private readonly List<RectTransform> _cellTags; //Field offset: 0x60

	[Token(Token = "0x1700020B")]
	private static RankPageConfig Cfg
	{
		[Address(RVA = "0x32740A8", Offset = "0x32740A8", Length = "0x8")]
		[Token(Token = "0x6000EC3")]
		 get { } //Length: 8
	}

	[Token(Token = "0x1700020A")]
	public static bool IsOpen
	{
		[Address(RVA = "0x3273FB8", Offset = "0x3273FB8", Length = "0x8C")]
		[Token(Token = "0x6000EC1")]
		 get { } //Length: 140
	}

	[Address(RVA = "0x32791CC", Offset = "0x32791CC", Length = "0x80")]
	[Token(Token = "0x6000EDF")]
	private static RankRewardPopup() { }

	[Address(RVA = "0x32790F0", Offset = "0x32790F0", Length = "0xDC")]
	[Token(Token = "0x6000EDE")]
	public RankRewardPopup() { }

	[Address(RVA = "0x3279338", Offset = "0x3279338", Length = "0x10")]
	[CompilerGenerated]
	[Token(Token = "0x6000EE1")]
	private void <BuildStage2>b__28_0() { }

	[Address(RVA = "0x3279348", Offset = "0x3279348", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000EE2")]
	private void <BuildStage2>b__28_1() { }

	[Address(RVA = "0x3279350", Offset = "0x3279350", Length = "0x7C")]
	[CompilerGenerated]
	[Token(Token = "0x6000EE3")]
	private void <ClaimDoubledViaAd>b__35_0() { }

	[Address(RVA = "0x32793CC", Offset = "0x32793CC", Length = "0x68")]
	[CompilerGenerated]
	[Token(Token = "0x6000EE4")]
	private void <ClaimDoubledViaAd>b__35_1() { }

	[Address(RVA = "0x327924C", Offset = "0x327924C", Length = "0xEC")]
	[CompilerGenerated]
	[Token(Token = "0x6000EE0")]
	private void <OnOpenBox>b__27_0() { }

	[Address(RVA = "0x3277D7C", Offset = "0x3277D7C", Length = "0x3F8")]
	[Token(Token = "0x6000ECF")]
	private void AttachCostumeHearts(RectTransform icon) { }

	[Address(RVA = "0x3274FC8", Offset = "0x3274FC8", Length = "0x88")]
	[IteratorStateMachine(typeof(<AttachTitleIcon>d__23))]
	[Token(Token = "0x6000EC8")]
	private IEnumerator AttachTitleIcon(TMP_Text title) { }

	[Address(RVA = "0x32742CC", Offset = "0x32742CC", Length = "0x688")]
	[Token(Token = "0x6000EC6")]
	private void Build() { }

	[Address(RVA = "0x3275050", Offset = "0x3275050", Length = "0x91C")]
	[Token(Token = "0x6000ECB")]
	private void BuildHero(RectTransform root) { }

	[Address(RVA = "0x3276758", Offset = "0x3276758", Length = "0xE98")]
	[Token(Token = "0x6000ECD")]
	private void BuildStage2() { }

	[Address(RVA = "0x32789DC", Offset = "0x32789DC", Length = "0xE0")]
	[Token(Token = "0x6000ED3")]
	private void Claim(bool doubled) { }

	[Address(RVA = "0x3278810", Offset = "0x3278810", Length = "0x1CC")]
	[Token(Token = "0x6000ED1")]
	private void ClaimDoubledViaAd() { }

	[Address(RVA = "0x3278B84", Offset = "0x3278B84", Length = "0x7C")]
	[IteratorStateMachine(typeof(<CloseWithFly>d__40))]
	[Token(Token = "0x6000ED6")]
	private IEnumerator CloseWithFly(int mult) { }

	[Address(RVA = "0x3278FF8", Offset = "0x3278FF8", Length = "0xF8")]
	[Token(Token = "0x6000EDB")]
	public static string ColorNumber(int value) { }

	[Address(RVA = "0x3278D7C", Offset = "0x3278D7C", Length = "0xF8")]
	[Token(Token = "0x6000ED5")]
	private void FadeOutChild(Transform child) { }

	[Address(RVA = "0x3278E74", Offset = "0x3278E74", Length = "0x88")]
	[Token(Token = "0x6000ED7")]
	private static CanvasGroup Fader(GameObject go) { }

	[Address(RVA = "0x3278C00", Offset = "0x3278C00", Length = "0x17C")]
	[Token(Token = "0x6000ED4")]
	private static RectTransform FlyTarget(bool bulb) { }

	[Address(RVA = "0x32740A8", Offset = "0x32740A8", Length = "0x8")]
	[Token(Token = "0x6000EC3")]
	private static RankPageConfig get_Cfg() { }

	[Address(RVA = "0x3273FB8", Offset = "0x3273FB8", Length = "0x8C")]
	[Token(Token = "0x6000EC1")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x32763F0", Offset = "0x32763F0", Length = "0xB8")]
	[Token(Token = "0x6000ECA")]
	private float IconSizeFor(TMP_LineInfo line) { }

	[Address(RVA = "0x32775F0", Offset = "0x32775F0", Length = "0xB4")]
	[Token(Token = "0x6000ED8")]
	private static Sprite ItemSprite(string path, string fallback) { }

	[Address(RVA = "0x3274ADC", Offset = "0x3274ADC", Length = "0x94")]
	[Token(Token = "0x6000EDD")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x3278ABC", Offset = "0x3278ABC", Length = "0xC8")]
	[Token(Token = "0x6000ED2")]
	private void LogClaimClick(bool doubled) { }

	[Address(RVA = "0x327596C", Offset = "0x327596C", Length = "0x74C")]
	[Token(Token = "0x6000ED9")]
	private GameObject MakePill(RectTransform root, string label, bool primary, float y, Vector2 size, Action onClick, bool adBadge) { }

	[Address(RVA = "0x32776A4", Offset = "0x32776A4", Length = "0x6D8")]
	[Token(Token = "0x6000ECE")]
	private RectTransform MakeRewardCell(float x, Sprite icon, string count) { }

	[Address(RVA = "0x3274B70", Offset = "0x3274B70", Length = "0x54")]
	[Token(Token = "0x6000EDC")]
	private static string Num(int value) { }

	[Address(RVA = "0x3278F2C", Offset = "0x3278F2C", Length = "0xCC")]
	[Token(Token = "0x6000EDA")]
	private void OnDestroy() { }

	[Address(RVA = "0x32764A8", Offset = "0x32764A8", Length = "0x2B0")]
	[Token(Token = "0x6000ECC")]
	private void OnOpenBox() { }

	[Address(RVA = "0x32760E0", Offset = "0x32760E0", Length = "0x310")]
	[Token(Token = "0x6000EC9")]
	private void PlaceTitleIcon(TMP_Text title, RectTransform rt) { }

	[Address(RVA = "0x3274044", Offset = "0x3274044", Length = "0x64")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000EC2")]
	private static void ResetStatics() { }

	[Address(RVA = "0x32740B0", Offset = "0x32740B0", Length = "0x21C")]
	[Token(Token = "0x6000EC4")]
	public static void Show(Args args) { }

	[Address(RVA = "0x3274954", Offset = "0x3274954", Length = "0x110")]
	[Token(Token = "0x6000EC5")]
	public static void ShowPreview(int rank) { }

	[Address(RVA = "0x3278174", Offset = "0x3278174", Length = "0x84")]
	[Token(Token = "0x6000ED0")]
	private Vector2 Size2(Vector2 v) { }

	[Address(RVA = "0x3274BC4", Offset = "0x3274BC4", Length = "0x404")]
	[Token(Token = "0x6000EC7")]
	public static string TwoLineTitle(string head, string sub) { }

}

