namespace Hamdoku.UI;

[Token(Token = "0x20000AF")]
public static class ResponsiveUI
{
	[Token(Token = "0x4000AC1")]
	public const float DefaultWideAspectMin = 0.65; //Field offset: 0x0
	[Token(Token = "0x4000AC2")]
	public const float DefaultWideScale = 0.8; //Field offset: 0x0
	[Token(Token = "0x4000AC3")]
	public const float DefaultMargin = 0.94; //Field offset: 0x0
	[Token(Token = "0x4000AC4")]
	public const string WrapperName = "Fit"; //Field offset: 0x0

	[Token(Token = "0x170000BA")]
	public static float Aspect
	{
		[Address(RVA = "0x3425E54", Offset = "0x3425E54", Length = "0x48")]
		[Token(Token = "0x60004AA")]
		 get { } //Length: 72
	}

	[Address(RVA = "0x3425ED0", Offset = "0x3425ED0", Length = "0x2FC")]
	[Token(Token = "0x60004AC")]
	public static Rect AvailableRect(RectTransform rootRt, float margin) { }

	[Address(RVA = "0x34266F8", Offset = "0x34266F8", Length = "0x354")]
	[Token(Token = "0x60004B0")]
	private static RectTransform EnsureWrapper(RectTransform content) { }

	[Address(RVA = "0x34262A8", Offset = "0x34262A8", Length = "0x200")]
	[Token(Token = "0x60004AE")]
	public static float Fit(GameObject popupRoot, RectTransform content, float wideScale = 0.8, float margin = 0.94) { }

	[Address(RVA = "0x34264A8", Offset = "0x34264A8", Length = "0x250")]
	[Token(Token = "0x60004AF")]
	public static float Fit(GameObject popupRoot, RectTransform content, Vector2 contentSize, float wideScale, float margin) { }

	[Address(RVA = "0x34261CC", Offset = "0x34261CC", Length = "0xDC")]
	[Token(Token = "0x60004AD")]
	public static float FitScale(Rect avail, Vector2 content, bool wide, float wideScale) { }

	[Address(RVA = "0x3425E54", Offset = "0x3425E54", Length = "0x48")]
	[Token(Token = "0x60004AA")]
	public static float get_Aspect() { }

	[Address(RVA = "0x3425E9C", Offset = "0x3425E9C", Length = "0x34")]
	[Token(Token = "0x60004AB")]
	public static bool IsWide(float wideAspectMin = 0.65) { }

}

