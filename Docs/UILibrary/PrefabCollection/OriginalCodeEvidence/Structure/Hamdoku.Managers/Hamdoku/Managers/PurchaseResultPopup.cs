namespace Hamdoku.Managers;

[Token(Token = "0x200028A")]
public static class PurchaseResultPopup
{
	[CompilerGenerated]
	[Token(Token = "0x200028B")]
	private sealed class <>c__DisplayClass10_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40010F9")]
		public Action onClose; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40010FA")]
		public int days; //Field offset: 0x18

		[Address(RVA = "0x32D6014", Offset = "0x32D6014", Length = "0x8")]
		[Token(Token = "0x6001299")]
		public <>c__DisplayClass10_0() { }

		[Address(RVA = "0x32D784C", Offset = "0x32D784C", Length = "0x74")]
		[Token(Token = "0x600129A")]
		internal void <ShowClubSuccess>b__0() { }

		[Address(RVA = "0x32D78C0", Offset = "0x32D78C0", Length = "0x74")]
		[Token(Token = "0x600129B")]
		internal void <ShowClubSuccess>b__1() { }

		[Address(RVA = "0x32D7934", Offset = "0x32D7934", Length = "0x68")]
		[Token(Token = "0x600129C")]
		internal void <ShowClubSuccess>b__2(RectTransform inner, ShopPopupLayout cfg) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200028C")]
	private sealed class <>c__DisplayClass4_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40010FB")]
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"icon", "label"})]
		public List<ValueTuple<string, string>> rewards; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40010FC")]
		public string noteKey; //Field offset: 0x18

		[Address(RVA = "0x32D5614", Offset = "0x32D5614", Length = "0x8")]
		[Token(Token = "0x600129D")]
		public <>c__DisplayClass4_0() { }

		[Address(RVA = "0x32D799C", Offset = "0x32D799C", Length = "0x70")]
		[Token(Token = "0x600129E")]
		internal void <Show>b__0(RectTransform inner, ShopPopupLayout cfg) { }

		[Address(RVA = "0x32D7A0C", Offset = "0x32D7A0C", Length = "0x70")]
		[Token(Token = "0x600129F")]
		internal void <Show>b__1(RectTransform inner, ShopPopupLayout cfg) { }

	}

	[Token(Token = "0x40010F3")]
	private const string WarnIconPath = "UI/Shop/icon_cart_warning"; //Field offset: 0x0
	[Token(Token = "0x40010F4")]
	private const string Tag = "purchase"; //Field offset: 0x0
	[Token(Token = "0x40010F5")]
	private static readonly Color ClubBoxBg; //Field offset: 0x0
	[Token(Token = "0x40010F6")]
	private static readonly Color ClubBoxLine; //Field offset: 0x10
	[Token(Token = "0x40010F7")]
	private static readonly Color ClubInk; //Field offset: 0x20
	[Token(Token = "0x40010F8")]
	private static readonly Color ClubSub; //Field offset: 0x30

	[Address(RVA = "0x32D77C8", Offset = "0x32D77C8", Length = "0x84")]
	[Token(Token = "0x6001298")]
	private static PurchaseResultPopup() { }

	[Address(RVA = "0x32D601C", Offset = "0x32D601C", Length = "0x950")]
	[Token(Token = "0x6001292")]
	private static void BuildClubBox(RectTransform inner, int days) { }

	[Address(RVA = "0x32D6E7C", Offset = "0x32D6E7C", Length = "0x41C")]
	[Token(Token = "0x6001294")]
	private static void BuildRewards(RectTransform inner, ShopPopupLayout cfg, List<ValueTuple<string, string>> rewards) { }

	[Address(RVA = "0x32D7298", Offset = "0x32D7298", Length = "0x41C")]
	[Token(Token = "0x6001295")]
	private static void BuildSoloReward(RectTransform inner, ShopPopupLayout cfg, ValueTuple<string, string> reward) { }

	[Address(RVA = "0x32D696C", Offset = "0x32D696C", Length = "0x510")]
	[Token(Token = "0x6001293")]
	private static void BuildWarning(RectTransform inner, ShopPopupLayout cfg, string noteKey) { }

	[Address(RVA = "0x32D5F80", Offset = "0x32D5F80", Length = "0x94")]
	[Token(Token = "0x6001290")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x32D59E4", Offset = "0x32D59E4", Length = "0x59C")]
	[Token(Token = "0x6001297")]
	private static List<ValueTuple<string, string>> RewardsOf(Item item) { }

	[Address(RVA = "0x32D76B4", Offset = "0x32D76B4", Length = "0x114")]
	[Token(Token = "0x6001296")]
	private static void SetIcon(Image img, string path, ShopPopupLayout cfg) { }

	[Address(RVA = "0x32D522C", Offset = "0x32D522C", Length = "0x37C")]
	[Token(Token = "0x600128F")]
	public static void Show(bool success, Item item, FailReason reason = 0, Action onClose = null) { }

	[Address(RVA = "0x32D561C", Offset = "0x32D561C", Length = "0x3C8")]
	[Token(Token = "0x6001291")]
	private static void ShowClubSuccess(Item item, Action onClose) { }

	[Address(RVA = "0x32D55A8", Offset = "0x32D55A8", Length = "0x6C")]
	[Token(Token = "0x600128E")]
	public static void ShowFail(FailReason reason = 0, Action onClose = null) { }

	[Address(RVA = "0x32D51C0", Offset = "0x32D51C0", Length = "0x6C")]
	[Token(Token = "0x600128D")]
	public static void ShowSuccess(Item item, Action onClose = null) { }

}

