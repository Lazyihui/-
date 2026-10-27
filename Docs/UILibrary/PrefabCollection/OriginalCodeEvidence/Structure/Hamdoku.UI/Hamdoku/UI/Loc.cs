namespace Hamdoku.UI;

[Token(Token = "0x2000081")]
public static class Loc
{
	[Token(Token = "0x400071D")]
	private const string PrefKey = "hamdoku_lang"; //Field offset: 0x0
	[Token(Token = "0x400071E")]
	private static Dictionary<string, Entry> _map; //Field offset: 0x0
	[Token(Token = "0x400071F")]
	private static Lang _lang; //Field offset: 0x8
	[Token(Token = "0x4000720")]
	private static bool _init; //Field offset: 0xC
	[Token(Token = "0x4000721")]
	public static readonly string[] Codes; //Field offset: 0x10
	[Token(Token = "0x4000722")]
	public static readonly string[] NativeNames; //Field offset: 0x18
	[Token(Token = "0x4000723")]
	private static readonly string[] CultureNames; //Field offset: 0x20
	[CompilerGenerated]
	[Token(Token = "0x4000724")]
	private static Action LanguageChanged; //Field offset: 0x28

	[Token(Token = "0x1400000A")]
	public static event Action LanguageChanged
	{
		[Address(RVA = "0x341055C", Offset = "0x341055C", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x600039D")]
		 add { } //Length: 220
		[Address(RVA = "0x3410638", Offset = "0x3410638", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x600039E")]
		 remove { } //Length: 220
	}

	[Token(Token = "0x17000095")]
	public static string Code
	{
		[Address(RVA = "0x3410AA4", Offset = "0x3410AA4", Length = "0x7C")]
		[Token(Token = "0x60003A0")]
		 get { } //Length: 124
	}

	[Token(Token = "0x17000097")]
	public static CultureInfo Culture
	{
		[Address(RVA = "0x3410CD4", Offset = "0x3410CD4", Length = "0xAC")]
		[Token(Token = "0x60003A4")]
		 get { } //Length: 172
	}

	[Token(Token = "0x17000093")]
	public static int LangCount
	{
		[Address(RVA = "0x34104F8", Offset = "0x34104F8", Length = "0x64")]
		[Token(Token = "0x600039C")]
		 get { } //Length: 100
	}

	[Token(Token = "0x17000094")]
	public static Lang Language
	{
		[Address(RVA = "0x3410714", Offset = "0x3410714", Length = "0x5C")]
		[Token(Token = "0x600039F")]
		 get { } //Length: 92
	}

	[Token(Token = "0x17000096")]
	public static string LanguageName
	{
		[Address(RVA = "0x3410C58", Offset = "0x3410C58", Length = "0x7C")]
		[Token(Token = "0x60003A3")]
		 get { } //Length: 124
	}

	[Address(RVA = "0x3411670", Offset = "0x3411670", Length = "0xCEC")]
	[Token(Token = "0x60003AC")]
	private static Loc() { }

	[Address(RVA = "0x341055C", Offset = "0x341055C", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x600039D")]
	public static void add_LanguageChanged(Action value) { }

	[Address(RVA = "0x3411460", Offset = "0x3411460", Length = "0x1EC")]
	[Token(Token = "0x60003A9")]
	public static void ApplyEntries(Entry[] entries) { }

	[Address(RVA = "0x3410770", Offset = "0x3410770", Length = "0x334")]
	[Token(Token = "0x60003AA")]
	private static void EnsureInit() { }

	[Address(RVA = "0x3410D80", Offset = "0x3410D80", Length = "0x1F4")]
	[Token(Token = "0x60003A5")]
	public static string FormatDate(DateTime date) { }

	[Address(RVA = "0x34110A0", Offset = "0x34110A0", Length = "0x20C")]
	[Token(Token = "0x60003A6")]
	public static string FormatDuration(float seconds) { }

	[Address(RVA = "0x341164C", Offset = "0x341164C", Length = "0x24")]
	[Token(Token = "0x60003AB")]
	private static Lang FromSystemLanguage(SystemLanguage sys) { }

	[Address(RVA = "0x34112AC", Offset = "0x34112AC", Length = "0xEC")]
	[Token(Token = "0x60003A8")]
	public static string Get(string key, object[] args) { }

	[Address(RVA = "0x3410F74", Offset = "0x3410F74", Length = "0x12C")]
	[Token(Token = "0x60003A7")]
	public static string Get(string key) { }

	[Address(RVA = "0x3410AA4", Offset = "0x3410AA4", Length = "0x7C")]
	[Token(Token = "0x60003A0")]
	public static string get_Code() { }

	[Address(RVA = "0x3410CD4", Offset = "0x3410CD4", Length = "0xAC")]
	[Token(Token = "0x60003A4")]
	public static CultureInfo get_Culture() { }

	[Address(RVA = "0x34104F8", Offset = "0x34104F8", Length = "0x64")]
	[Token(Token = "0x600039C")]
	public static int get_LangCount() { }

	[Address(RVA = "0x3410714", Offset = "0x3410714", Length = "0x5C")]
	[Token(Token = "0x600039F")]
	public static Lang get_Language() { }

	[Address(RVA = "0x3410C58", Offset = "0x3410C58", Length = "0x7C")]
	[Token(Token = "0x60003A3")]
	public static string get_LanguageName() { }

	[Address(RVA = "0x3410638", Offset = "0x3410638", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x600039E")]
	public static void remove_LanguageChanged(Action value) { }

	[Address(RVA = "0x3410B20", Offset = "0x3410B20", Length = "0xD4")]
	[Token(Token = "0x60003A1")]
	public static void SetLanguage(Lang lang) { }

	[Address(RVA = "0x3410BF4", Offset = "0x3410BF4", Length = "0x64")]
	[Token(Token = "0x60003A2")]
	public static void ToggleLanguage() { }

}

