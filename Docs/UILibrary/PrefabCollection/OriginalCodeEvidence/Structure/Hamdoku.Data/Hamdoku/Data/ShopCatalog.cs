namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "ShopCatalog", menuName = "Hamdoku/Shop Catalog")]
[Token(Token = "0x2000025")]
public sealed class ShopCatalog : ScriptableObject
{
	[Token(Token = "0x2000027")]
	public sealed class Item
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000193")]
		public string type; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000194")]
		public string section; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000195")]
		public string productId; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000196")]
		public string nameKey; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000197")]
		public string descKey; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000198")]
		public string badgeKey; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000199")]
		public int hintItems; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x400019A")]
		public int guideItems; //Field offset: 0x44
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x400019B")]
		public int adFreeHours; //Field offset: 0x48
		[FieldOffset(Offset = "0x4C")]
		[Token(Token = "0x400019C")]
		public bool adFreeForever; //Field offset: 0x4C
		[FieldOffset(Offset = "0x4D")]
		[Token(Token = "0x400019D")]
		public bool autoX; //Field offset: 0x4D
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x400019E")]
		public int clubDays; //Field offset: 0x50
		[FieldOffset(Offset = "0x54")]
		[Token(Token = "0x400019F")]
		public int priceKrw; //Field offset: 0x54
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x40001A0")]
		public float priceUsd; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[Token(Token = "0x40001A1")]
		public string sku; //Field offset: 0x60
		[FieldOffset(Offset = "0x68")]
		[Token(Token = "0x40001A2")]
		public int discountPercent; //Field offset: 0x68
		[FieldOffset(Offset = "0x6C")]
		[Token(Token = "0x40001A3")]
		public bool enabled; //Field offset: 0x6C
		[FieldOffset(Offset = "0x70")]
		[Token(Token = "0x40001A4")]
		public int maxPurchases; //Field offset: 0x70
		[FieldOffset(Offset = "0x74")]
		[Token(Token = "0x40001A5")]
		public int offerHours; //Field offset: 0x74
		[FieldOffset(Offset = "0x78")]
		[Token(Token = "0x40001A6")]
		public int offerCooldownHours; //Field offset: 0x78
		[FieldOffset(Offset = "0x80")]
		[Token(Token = "0x40001A7")]
		public string image; //Field offset: 0x80

		[Address(RVA = "0x31EE860", Offset = "0x31EE860", Length = "0x8")]
		[Token(Token = "0x6000097")]
		public Item() { }

	}

	[Token(Token = "0x2000026")]
	public sealed class Tier
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400018A")]
		public string sku; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400018B")]
		public string platform; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400018C")]
		public string type; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400018D")]
		public int tierNum; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400018E")]
		public string displayName; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x400018F")]
		public int priceKrw; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x4000190")]
		public float priceUsd; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000191")]
		public string[] mappedIds; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000192")]
		public string defaultId; //Field offset: 0x48

		[Token(Token = "0x17000020")]
		public bool IsNonConsumable
		{
			[Address(RVA = "0x31EEAC4", Offset = "0x31EEAC4", Length = "0x50")]
			[Token(Token = "0x6000095")]
			 get { } //Length: 80
		}

		[Address(RVA = "0x31EDEA4", Offset = "0x31EDEA4", Length = "0x8")]
		[Token(Token = "0x6000096")]
		public Tier() { }

		[Address(RVA = "0x31EEAC4", Offset = "0x31EEAC4", Length = "0x50")]
		[Token(Token = "0x6000095")]
		public bool get_IsNonConsumable() { }

	}

	[Token(Token = "0x4000188")]
	private static ShopCatalog _instance; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x4000189")]
	private static Action Changed; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000186")]
	public List<Tier> tiers; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000187")]
	public List<Item> items; //Field offset: 0x20

	[Token(Token = "0x14000002")]
	public static event Action Changed
	{
		[Address(RVA = "0x31ECFB8", Offset = "0x31ECFB8", Length = "0xBC")]
		[CompilerGenerated]
		[Token(Token = "0x6000083")]
		 add { } //Length: 188
		[Address(RVA = "0x31ED074", Offset = "0x31ED074", Length = "0xBC")]
		[CompilerGenerated]
		[Token(Token = "0x6000084")]
		 remove { } //Length: 188
	}

	[Token(Token = "0x1700001F")]
	public static ShopCatalog Instance
	{
		[Address(RVA = "0x31ECEDC", Offset = "0x31ECEDC", Length = "0xDC")]
		[Token(Token = "0x6000082")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x31EE9E8", Offset = "0x31EE9E8", Length = "0xDC")]
	[Token(Token = "0x6000094")]
	public ShopCatalog() { }

	[Address(RVA = "0x31ED204", Offset = "0x31ED204", Length = "0x270")]
	[Token(Token = "0x6000087")]
	public List<Tier> ActiveTiers() { }

	[Address(RVA = "0x31ECFB8", Offset = "0x31ECFB8", Length = "0xBC")]
	[CompilerGenerated]
	[Token(Token = "0x6000083")]
	public static void add_Changed(Action value) { }

	[Address(RVA = "0x31EE914", Offset = "0x31EE914", Length = "0xD4")]
	[Token(Token = "0x600008E")]
	public void ApplyRemote(List<Tier> newTiers, List<Item> newItems) { }

	[Address(RVA = "0x31EDE00", Offset = "0x31EDE00", Length = "0xA4")]
	[Token(Token = "0x600008F")]
	private static string Cell(List<string> row, int i) { }

	[Address(RVA = "0x31EE868", Offset = "0x31EE868", Length = "0xAC")]
	[Token(Token = "0x6000092")]
	private static bool CellBool(List<string> row, int i) { }

	[Address(RVA = "0x31EDF4C", Offset = "0x31EDF4C", Length = "0xA4")]
	[Token(Token = "0x6000091")]
	private static float CellFloat(List<string> row, int i) { }

	[Address(RVA = "0x31EDEAC", Offset = "0x31EDEAC", Length = "0xA0")]
	[Token(Token = "0x6000090")]
	private static int CellInt(List<string> row, int i) { }

	[Address(RVA = "0x31ED7AC", Offset = "0x31ED7AC", Length = "0x260")]
	[Token(Token = "0x600008B")]
	public List<Item> EnabledItems(string section = null) { }

	[Address(RVA = "0x31ECEDC", Offset = "0x31ECEDC", Length = "0xDC")]
	[Token(Token = "0x6000082")]
	public static ShopCatalog get_Instance() { }

	[Address(RVA = "0x31ED794", Offset = "0x31ED794", Length = "0x18")]
	[Token(Token = "0x600008A")]
	public string GetDefaultProductId(string sku) { }

	[Address(RVA = "0x31ED60C", Offset = "0x31ED60C", Length = "0x188")]
	[Token(Token = "0x6000089")]
	public Item GetItem(string productId) { }

	[Address(RVA = "0x31ED474", Offset = "0x31ED474", Length = "0x198")]
	[Token(Token = "0x6000088")]
	public Tier GetTier(string sku) { }

	[Address(RVA = "0x31EE1D8", Offset = "0x31EE1D8", Length = "0x688")]
	[Token(Token = "0x600008D")]
	public static List<Item> ParseItemsCsv(string csv) { }

	[Address(RVA = "0x31EDA0C", Offset = "0x31EDA0C", Length = "0x3F4")]
	[Token(Token = "0x600008C")]
	public static List<Tier> ParseTiersCsv(string csv) { }

	[Address(RVA = "0x31ED198", Offset = "0x31ED198", Length = "0x6C")]
	[Token(Token = "0x6000086")]
	private static bool PlatformMatches(string platform) { }

	[Address(RVA = "0x31ED074", Offset = "0x31ED074", Length = "0xBC")]
	[CompilerGenerated]
	[Token(Token = "0x6000084")]
	public static void remove_Changed(Action value) { }

	[Address(RVA = "0x31ED130", Offset = "0x31ED130", Length = "0x68")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000085")]
	private static void ResetStatics() { }

	[Address(RVA = "0x31EDFF0", Offset = "0x31EDFF0", Length = "0x1E8")]
	[Token(Token = "0x6000093")]
	private static string[] SplitIds(string raw) { }

}

