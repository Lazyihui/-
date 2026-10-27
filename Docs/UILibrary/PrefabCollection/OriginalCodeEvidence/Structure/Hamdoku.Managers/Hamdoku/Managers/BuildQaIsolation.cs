namespace Hamdoku.Managers;

[Token(Token = "0x200006D")]
public static class BuildQaIsolation
{
	[Token(Token = "0x4000239")]
	public const string EditorIsolationPrefKey = "Hamdoku.Cheat.ServerIsolation"; //Field offset: 0x0
	[Token(Token = "0x400023A")]
	public const string LegacyEditorIsolationPrefKey = "Hamdoku.Cheat.CloudSyncOff"; //Field offset: 0x0
	[Token(Token = "0x400023B")]
	public static readonly bool Active; //Field offset: 0x0
	[Token(Token = "0x400023C")]
	public static readonly bool IsQaRunner; //Field offset: 0x1

	[Address(RVA = "0x32125F0", Offset = "0x32125F0", Length = "0x48")]
	[Token(Token = "0x6000210")]
	private static BuildQaIsolation() { }

	[Address(RVA = "0x32125E8", Offset = "0x32125E8", Length = "0x8")]
	[Token(Token = "0x600020F")]
	private static bool ComputeActive() { }

	[Address(RVA = "0x32125E0", Offset = "0x32125E0", Length = "0x8")]
	[Token(Token = "0x600020E")]
	private static bool ComputeQaRunner() { }

}

