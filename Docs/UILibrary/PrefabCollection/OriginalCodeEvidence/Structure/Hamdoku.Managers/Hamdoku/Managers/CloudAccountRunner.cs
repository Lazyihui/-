namespace Hamdoku.Managers;

[Token(Token = "0x200003B")]
internal sealed class CloudAccountRunner : MonoBehaviour
{
	[Token(Token = "0x4000151")]
	private static CloudAccountRunner _instance; //Field offset: 0x0

	[Address(RVA = "0x3208F84", Offset = "0x3208F84", Length = "0x8")]
	[Token(Token = "0x6000189")]
	public CloudAccountRunner() { }

	[Address(RVA = "0x31FCA70", Offset = "0x31FCA70", Length = "0x128")]
	[Token(Token = "0x6000185")]
	internal static void Ensure() { }

	[Address(RVA = "0x3208ED0", Offset = "0x3208ED0", Length = "0xB4")]
	[Token(Token = "0x6000188")]
	private void OnDestroy() { }

	[Address(RVA = "0x31F8324", Offset = "0x31F8324", Length = "0x60")]
	[Token(Token = "0x6000186")]
	internal static Coroutine Run(IEnumerator routine) { }

	[Address(RVA = "0x3208E80", Offset = "0x3208E80", Length = "0x50")]
	[Token(Token = "0x6000187")]
	private void Update() { }

}

