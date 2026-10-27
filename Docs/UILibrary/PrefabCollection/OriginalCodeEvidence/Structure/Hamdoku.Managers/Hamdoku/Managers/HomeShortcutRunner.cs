namespace Hamdoku.Managers;

[Token(Token = "0x20001B8")]
internal sealed class HomeShortcutRunner : MonoBehaviour
{
	[Token(Token = "0x4000ACB")]
	private static HomeShortcutRunner _instance; //Field offset: 0x0

	[Address(RVA = "0x3237AF8", Offset = "0x3237AF8", Length = "0x8")]
	[Token(Token = "0x6000C70")]
	public HomeShortcutRunner() { }

	[Address(RVA = "0x3236F24", Offset = "0x3236F24", Length = "0x128")]
	[Token(Token = "0x6000C6B")]
	internal static void Ensure() { }

	[Address(RVA = "0x323799C", Offset = "0x323799C", Length = "0xC")]
	[Token(Token = "0x6000C6C")]
	private void OnApplicationFocus(bool focused) { }

	[Address(RVA = "0x3237A38", Offset = "0x3237A38", Length = "0xC")]
	[Token(Token = "0x6000C6D")]
	private void OnApplicationPause(bool paused) { }

	[Address(RVA = "0x3237A44", Offset = "0x3237A44", Length = "0xB4")]
	[Token(Token = "0x6000C6F")]
	private void OnDestroy() { }

	[Address(RVA = "0x32379A8", Offset = "0x32379A8", Length = "0x90")]
	[Token(Token = "0x6000C6E")]
	private static void Recapture() { }

}

