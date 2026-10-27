namespace Hamdoku.Managers;

[Token(Token = "0x20001BD")]
public static class KoreanTermsConsent
{
	[CompilerGenerated]
	[Token(Token = "0x20001BF")]
	private sealed class <>c__DisplayClass14_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000AF8")]
		public Action onAgree; //Field offset: 0x10

		[Address(RVA = "0x3239D3C", Offset = "0x3239D3C", Length = "0x8")]
		[Token(Token = "0x6000CA1")]
		public <>c__DisplayClass14_0() { }

		[Address(RVA = "0x323BA1C", Offset = "0x323BA1C", Length = "0x1C")]
		[Token(Token = "0x6000CA2")]
		internal void <Show>b__0(bool _) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001C0")]
	private sealed class <>c__DisplayClass16_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000AF9")]
		public bool[] states; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000AFA")]
		public Image[] boxes; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000AFB")]
		public GameObject[] marks; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000AFC")]
		public RectTransform[] rows; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000AFD")]
		public ShopPopupLayout cfg; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000AFE")]
		public bool preview; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000AFF")]
		public Action<bool> onDone; //Field offset: 0x40

		[Address(RVA = "0x323A2CC", Offset = "0x323A2CC", Length = "0x8")]
		[Token(Token = "0x6000CA3")]
		public <>c__DisplayClass16_0() { }

		[Address(RVA = "0x323BA38", Offset = "0x323BA38", Length = "0x88")]
		[Token(Token = "0x6000CA4")]
		internal void <Build>b__0(RectTransform inner, ShopPopupLayout c) { }

		[Address(RVA = "0x323BAC0", Offset = "0x323BAC0", Length = "0x1A0")]
		[Token(Token = "0x6000CA5")]
		internal bool <Build>b__1(bool confirmed) { }

		[Address(RVA = "0x323BC60", Offset = "0x323BC60", Length = "0x6C")]
		[Token(Token = "0x6000CA6")]
		internal void <Build>b__2() { }

		[Address(RVA = "0x323BCCC", Offset = "0x323BCCC", Length = "0x6C")]
		[Token(Token = "0x6000CA7")]
		internal void <Build>b__3() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001C1")]
	private sealed class <>c__DisplayClass19_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B00")]
		public ShopPopupLayout cfg; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000B01")]
		public bool[] states; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000B02")]
		public Image[] boxes; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000B03")]
		public GameObject[] marks; //Field offset: 0x28

		[Address(RVA = "0x323B44C", Offset = "0x323B44C", Length = "0x8")]
		[Token(Token = "0x6000CA8")]
		public <>c__DisplayClass19_0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001C2")]
	private sealed class <>c__DisplayClass19_1
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B04")]
		public int idx; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000B05")]
		public string page; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000B06")]
		public <>c__DisplayClass19_0 CS$<>8__locals1; //Field offset: 0x20

		[Address(RVA = "0x323B454", Offset = "0x323B454", Length = "0x8")]
		[Token(Token = "0x6000CA9")]
		public <>c__DisplayClass19_1() { }

		[Address(RVA = "0x323BD38", Offset = "0x323BD38", Length = "0xBC")]
		[Token(Token = "0x6000CAA")]
		internal void <BuildRows>b__0() { }

		[Address(RVA = "0x323BDF4", Offset = "0x323BDF4", Length = "0x64")]
		[Token(Token = "0x6000CAB")]
		internal void <BuildRows>b__1() { }

	}

	[IsReadOnly]
	[Token(Token = "0x20001BE")]
	private struct Item
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000AF5")]
		public readonly bool Required; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000AF6")]
		public readonly string Label; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000AF7")]
		public readonly string Page; //Field offset: 0x10

		[Address(RVA = "0x323B9E4", Offset = "0x323B9E4", Length = "0x38")]
		[Token(Token = "0x6000CA0")]
		public Item(bool required, string label, string page) { }

	}

	[Token(Token = "0x4000AEE")]
	private const string PrefAgreed = "TermsAgreed_v1"; //Field offset: 0x0
	[Token(Token = "0x4000AEF")]
	private const string PrefNightPush = "NightPushConsent_v1"; //Field offset: 0x0
	[Token(Token = "0x4000AF0")]
	private const string Tag = "terms"; //Field offset: 0x0
	[Token(Token = "0x4000AF1")]
	private const string CheckIconPath = "icon_check"; //Field offset: 0x0
	[Token(Token = "0x4000AF2")]
	private const string HeartPath = "UI/Shop/shop_heart_deco"; //Field offset: 0x0
	[Token(Token = "0x4000AF3")]
	private const int NightPushIndex = 2; //Field offset: 0x0
	[Token(Token = "0x4000AF4")]
	private static readonly Item[] Items; //Field offset: 0x0

	[Token(Token = "0x170001B8")]
	public static bool Agreed
	{
		[Address(RVA = "0x3239AB4", Offset = "0x3239AB4", Length = "0x54")]
		[Token(Token = "0x6000C92")]
		 get { } //Length: 84
	}

	[Token(Token = "0x170001B9")]
	public static bool NightPushAllowed
	{
		[Address(RVA = "0x3239B08", Offset = "0x3239B08", Length = "0x54")]
		[Token(Token = "0x6000C93")]
		 get { } //Length: 84
	}

	[Address(RVA = "0x323B7E0", Offset = "0x323B7E0", Length = "0x204")]
	[Token(Token = "0x6000C9F")]
	private static KoreanTermsConsent() { }

	[Address(RVA = "0x3239D44", Offset = "0x3239D44", Length = "0x530")]
	[Token(Token = "0x6000C98")]
	private static void Build(bool preview, Action<bool> onDone) { }

	[Address(RVA = "0x323A2D4", Offset = "0x323A2D4", Length = "0x194")]
	[Token(Token = "0x6000C99")]
	private static void BuildHearts(RectTransform frame, ShopPopupLayout cfg, float creamY) { }

	[Address(RVA = "0x323A62C", Offset = "0x323A62C", Length = "0xE20")]
	[Token(Token = "0x6000C9B")]
	private static void BuildRows(RectTransform inner, ShopPopupLayout cfg, bool[] states, Image[] boxes, GameObject[] marks, RectTransform[] rows) { }

	[Address(RVA = "0x323B70C", Offset = "0x323B70C", Length = "0xD4")]
	[Token(Token = "0x6000C9E")]
	private static void Commit(bool preview, bool[] states, Action<bool> onDone) { }

	[Address(RVA = "0x3239AB4", Offset = "0x3239AB4", Length = "0x54")]
	[Token(Token = "0x6000C92")]
	public static bool get_Agreed() { }

	[Address(RVA = "0x3239B08", Offset = "0x3239B08", Length = "0x54")]
	[Token(Token = "0x6000C93")]
	public static bool get_NightPushAllowed() { }

	[Address(RVA = "0x323A468", Offset = "0x323A468", Length = "0x1C4")]
	[Token(Token = "0x6000C9A")]
	private static void MakeHeart(RectTransform frame, ShopPopupLayout cfg, Sprite sprite, string name, float x, float y, float tilt) { }

	[Address(RVA = "0x3239BEC", Offset = "0x3239BEC", Length = "0x6C")]
	[Token(Token = "0x6000C95")]
	public static void Reset() { }

	[Address(RVA = "0x323B45C", Offset = "0x323B45C", Length = "0x1A4")]
	[Token(Token = "0x6000C9C")]
	private static void SetChecked(ShopPopupLayout cfg, int i, bool on, bool[] states, Image[] boxes, GameObject[] marks) { }

	[Address(RVA = "0x323B600", Offset = "0x323B600", Length = "0x10C")]
	[Token(Token = "0x6000C9D")]
	private static void Shake(RectTransform rt) { }

	[Address(RVA = "0x3239B5C", Offset = "0x3239B5C", Length = "0x90")]
	[Token(Token = "0x6000C94")]
	public static bool ShouldShow() { }

	[Address(RVA = "0x3239C58", Offset = "0x3239C58", Length = "0xE4")]
	[Token(Token = "0x6000C96")]
	public static void Show(Action onAgree = null) { }

	[Address(RVA = "0x323A274", Offset = "0x323A274", Length = "0x58")]
	[Token(Token = "0x6000C97")]
	public static void ShowPreview(Action<bool> onDone = null) { }

}

