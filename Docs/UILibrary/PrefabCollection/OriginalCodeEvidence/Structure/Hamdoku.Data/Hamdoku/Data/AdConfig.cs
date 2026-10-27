namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "AdConfig", menuName = "Hamdoku/Ad Config")]
[Token(Token = "0x2000004")]
public sealed class AdConfig : ScriptableObject
{
	[Token(Token = "0x400000D")]
	private static AdConfig _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("Android 광고 유닛 ID")]
	[Token(Token = "0x4000006")]
	public string androidInterstitial; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000007")]
	public string androidRewarded; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000008")]
	public string androidBanner; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Header("iOS 광고 유닛 ID")]
	[Token(Token = "0x4000009")]
	public string iosInterstitial; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400000A")]
	public string iosRewarded; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400000B")]
	public string iosBanner; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Header("디버그")]
	[Token(Token = "0x400000C")]
	public bool verboseLogging; //Field offset: 0x48

	[Token(Token = "0x17000003")]
	public string BannerId
	{
		[Address(RVA = "0x31E1E5C", Offset = "0x31E1E5C", Length = "0x8")]
		[Token(Token = "0x6000005")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000004")]
	public static AdConfig Instance
	{
		[Address(RVA = "0x31E1E64", Offset = "0x31E1E64", Length = "0xDC")]
		[Token(Token = "0x6000006")]
		 get { } //Length: 220
	}

	[Token(Token = "0x17000001")]
	public string InterstitialId
	{
		[Address(RVA = "0x31E1E4C", Offset = "0x31E1E4C", Length = "0x8")]
		[Token(Token = "0x6000003")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000002")]
	public string RewardedId
	{
		[Address(RVA = "0x31E1E54", Offset = "0x31E1E54", Length = "0x8")]
		[Token(Token = "0x6000004")]
		 get { } //Length: 8
	}

	[Address(RVA = "0x31E1F40", Offset = "0x31E1F40", Length = "0xB0")]
	[Token(Token = "0x6000007")]
	public AdConfig() { }

	[Address(RVA = "0x31E1E5C", Offset = "0x31E1E5C", Length = "0x8")]
	[Token(Token = "0x6000005")]
	public string get_BannerId() { }

	[Address(RVA = "0x31E1E64", Offset = "0x31E1E64", Length = "0xDC")]
	[Token(Token = "0x6000006")]
	public static AdConfig get_Instance() { }

	[Address(RVA = "0x31E1E4C", Offset = "0x31E1E4C", Length = "0x8")]
	[Token(Token = "0x6000003")]
	public string get_InterstitialId() { }

	[Address(RVA = "0x31E1E54", Offset = "0x31E1E54", Length = "0x8")]
	[Token(Token = "0x6000004")]
	public string get_RewardedId() { }

}

