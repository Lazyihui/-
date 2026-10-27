namespace Hamdoku.UI;

[Token(Token = "0x2000031")]
public static class CostumeOverlay
{
	[Token(Token = "0x40001C8")]
	public const string ChildName = "Costume"; //Field offset: 0x0
	[Token(Token = "0x40001C9")]
	public const string HandChildName = "CostumeHand"; //Field offset: 0x0
	[Token(Token = "0x40001CA")]
	public const int BoardAppearAvatarId = 4; //Field offset: 0x0
	[Token(Token = "0x40001CB")]
	public const int BoardWrongAvatarId = 5; //Field offset: 0x0

	[Address(RVA = "0x33EA764", Offset = "0x33EA764", Length = "0x380")]
	[Token(Token = "0x60001A3")]
	public static Image Attach(RectTransform hamsterRt, int costumeId, int avatarId = -1, CostumeState state = 0, bool clipToRect = true) { }

	[Address(RVA = "0x33EB3D4", Offset = "0x33EB3D4", Length = "0x1B0")]
	[Token(Token = "0x60001A4")]
	public static void ClipTo(RectTransform hamsterRt, RectTransform area, float inset = 0, float insetFrac = 0, bool zoomToFit = false) { }

	[Address(RVA = "0x33EB584", Offset = "0x33EB584", Length = "0x80")]
	[Token(Token = "0x60001A5")]
	public static void ClipToFrameOpening(RectTransform hamsterRt, RectTransform plate, int frameId) { }

	[Address(RVA = "0x33EAAE4", Offset = "0x33EAAE4", Length = "0x280")]
	[Token(Token = "0x60001AB")]
	private static Image Ensure(RectTransform hamsterRt) { }

	[Address(RVA = "0x33EA6AC", Offset = "0x33EA6AC", Length = "0xB8")]
	[Token(Token = "0x60001A2")]
	public static Sprite HandSprite(int avatarId, CostumeState state) { }

	[Address(RVA = "0x33EB82C", Offset = "0x33EB82C", Length = "0x134")]
	[Token(Token = "0x60001A9")]
	public static void Hide(RectTransform hamsterRt) { }

	[Address(RVA = "0x33EB144", Offset = "0x33EB144", Length = "0x1E8")]
	[Token(Token = "0x60001A6")]
	public static void Place(RectTransform rt, Rect r, CostumeFit fit, Vector2 headPivot) { }

	[Address(RVA = "0x33EAD64", Offset = "0x33EAD64", Length = "0x3E0")]
	[Token(Token = "0x60001AA")]
	private static void SetHand(RectTransform hamsterRt, Sprite hand) { }

	[Address(RVA = "0x33EB604", Offset = "0x33EB604", Length = "0x228")]
	[Token(Token = "0x60001A7")]
	public static void SetState(RectTransform hamsterRt, int costumeId, CostumeState state) { }

	[Address(RVA = "0x33EB32C", Offset = "0x33EB32C", Length = "0xA8")]
	[Token(Token = "0x60001A8")]
	public static Sprite SpriteFor(in Costume c, CostumeState state) { }

}

