namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "Localization", menuName = "Hamdoku/Localization Data")]
[Token(Token = "0x2000082")]
public sealed class LocalizationData : ScriptableObject
{
	[Token(Token = "0x2000083")]
	public struct Entry
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000726")]
		public string key; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[TextArea]
		[Token(Token = "0x4000727")]
		public string ko; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[TextArea]
		[Token(Token = "0x4000728")]
		public string en; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[TextArea]
		[Token(Token = "0x4000729")]
		public string ja; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[TextArea]
		[Token(Token = "0x400072A")]
		public string zhTw; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[TextArea]
		[Token(Token = "0x400072B")]
		public string zh; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[TextArea]
		[Token(Token = "0x400072C")]
		public string de; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[TextArea]
		[Token(Token = "0x400072D")]
		public string fr; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[TextArea]
		[Token(Token = "0x400072E")]
		public string es; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[TextArea]
		[Token(Token = "0x400072F")]
		public string pt; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[TextArea]
		[Token(Token = "0x4000730")]
		public string ru; //Field offset: 0x50
		[FieldOffset(Offset = "0x58")]
		[TextArea]
		[Token(Token = "0x4000731")]
		public string vi; //Field offset: 0x58
		[FieldOffset(Offset = "0x60")]
		[TextArea]
		[Token(Token = "0x4000732")]
		public string it; //Field offset: 0x60
		[FieldOffset(Offset = "0x68")]
		[TextArea]
		[Token(Token = "0x4000733")]
		public string id; //Field offset: 0x68
		[FieldOffset(Offset = "0x70")]
		[TextArea]
		[Token(Token = "0x4000734")]
		public string tr; //Field offset: 0x70
		[FieldOffset(Offset = "0x78")]
		[TextArea]
		[Token(Token = "0x4000735")]
		public string nl; //Field offset: 0x78
		[FieldOffset(Offset = "0x80")]
		[TextArea]
		[Token(Token = "0x4000736")]
		public string pl; //Field offset: 0x80
		[FieldOffset(Offset = "0x88")]
		[TextArea]
		[Token(Token = "0x4000737")]
		public string sv; //Field offset: 0x88
		[FieldOffset(Offset = "0x90")]
		[TextArea]
		[Token(Token = "0x4000738")]
		public string da; //Field offset: 0x90
		[FieldOffset(Offset = "0x98")]
		[TextArea]
		[Token(Token = "0x4000739")]
		public string nb; //Field offset: 0x98
		[FieldOffset(Offset = "0xA0")]
		[TextArea]
		[Token(Token = "0x400073A")]
		public string fi; //Field offset: 0xA0

		[Address(RVA = "0x3411398", Offset = "0x3411398", Length = "0xC8")]
		[Token(Token = "0x60003AE")]
		public string Get(Lang lang) { }

		[Address(RVA = "0x3412364", Offset = "0x3412364", Length = "0xD0")]
		[Token(Token = "0x60003AF")]
		public void Set(Lang lang, string value) { }

	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000725")]
	public Entry[] entries; //Field offset: 0x18

	[Address(RVA = "0x341235C", Offset = "0x341235C", Length = "0x8")]
	[Token(Token = "0x60003AD")]
	public LocalizationData() { }

}

