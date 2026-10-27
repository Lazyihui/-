namespace Hamdoku.Managers;

[Token(Token = "0x20000C2")]
public sealed class RankView
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40003EF")]
	public RankScope scope; //Field offset: 0x10
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40003F0")]
	public List<RankEntry> top; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40003F1")]
	public RankEntry me; //Field offset: 0x20

	[Address(RVA = "0x33120FC", Offset = "0x33120FC", Length = "0x88")]
	[Token(Token = "0x60003F5")]
	public RankView() { }

}

