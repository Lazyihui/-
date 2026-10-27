namespace Hamdoku.Managers;

[Token(Token = "0x20000C3")]
public sealed class WeeklyView
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40003F2")]
	public RankEntry[] podium; //Field offset: 0x10
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40003F3")]
	public List<RankEntry> rest; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40003F4")]
	public RankEntry me; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40003F5")]
	public long secondsLeft; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40003F6")]
	public string weekId; //Field offset: 0x30

	[Address(RVA = "0x3312184", Offset = "0x3312184", Length = "0xB8")]
	[Token(Token = "0x60003F6")]
	public WeeklyView() { }

}

