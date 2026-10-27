namespace Hamdoku.Managers;

[Token(Token = "0x2000073")]
internal sealed class CloudSaveRunner : MonoBehaviour
{
	[Token(Token = "0x4000258")]
	private static CloudSaveRunner _instance; //Field offset: 0x0

	[Address(RVA = "0x3217114", Offset = "0x3217114", Length = "0x8")]
	[Token(Token = "0x6000233")]
	public CloudSaveRunner() { }

	[Address(RVA = "0x3212BF4", Offset = "0x3212BF4", Length = "0x128")]
	[Token(Token = "0x600022E")]
	internal static void Ensure() { }

	[Address(RVA = "0x3216FB4", Offset = "0x3216FB4", Length = "0x60")]
	[Token(Token = "0x6000230")]
	private void OnApplicationPause(bool paused) { }

	[Address(RVA = "0x3217014", Offset = "0x3217014", Length = "0x4C")]
	[Token(Token = "0x6000231")]
	private void OnApplicationQuit() { }

	[Address(RVA = "0x3217060", Offset = "0x3217060", Length = "0xB4")]
	[Token(Token = "0x6000232")]
	private void OnDestroy() { }

	[Address(RVA = "0x3216F68", Offset = "0x3216F68", Length = "0x4C")]
	[Token(Token = "0x600022F")]
	private void Update() { }

}

