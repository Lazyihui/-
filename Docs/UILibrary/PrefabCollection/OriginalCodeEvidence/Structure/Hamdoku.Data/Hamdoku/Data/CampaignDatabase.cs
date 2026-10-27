namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "CampaignDatabase", menuName = "Hamdoku/Campaign Database")]
[Token(Token = "0x2000007")]
public sealed class CampaignDatabase : ScriptableObject
{
	[Token(Token = "0x2000008")]
	public struct Entry
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x400001E")]
		[Tooltip("보드 한 변 크기")]
		public int size; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400001F")]
		[Tooltip("구역 ID 배열 — 행 우선, 길이 size*size, 값 0~size-1")]
		public byte[] regions; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000020")]
		[Tooltip("정답 열 — solCols[행] = 그 행의 햄스터 열. 행은 인덱스로 표현한다(행당 정확히 1마리)")]
		public byte[] solCols; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000021")]
		[Tooltip("판을 열 때부터 놓여 있는 햄스터의 '행'. 열은 해답이 정하므로 solCols[행]에서 나온다. 없으면 빈 배열")]
		public byte[] preRows; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000022")]
		[Tooltip("난이도 표시/정렬용(0=일반, 1=하드 등)")]
		public int difficulty; //Field offset: 0x20

	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000019")]
	[Tooltip("플레이 순서대로 나열한 레벨들")]
	public Entry[] entries; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400001A")]
	private LevelData _buffer; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400001B")]
	private int[][] _regionBuf; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400001C")]
	private Vector2Int[][] _solBuf; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400001D")]
	private Vector2Int[][] _preBuf; //Field offset: 0x38

	[Token(Token = "0x17000007")]
	public int Count
	{
		[Address(RVA = "0x31E21AC", Offset = "0x31E21AC", Length = "0x18")]
		[Token(Token = "0x600000C")]
		 get { } //Length: 24
	}

	[Address(RVA = "0x31E2858", Offset = "0x31E2858", Length = "0x8")]
	[Token(Token = "0x6000010")]
	public CampaignDatabase() { }

	[Address(RVA = "0x31E2604", Offset = "0x31E2604", Length = "0x178")]
	[Token(Token = "0x600000E")]
	private void EnsureBuffers(int n) { }

	[Address(RVA = "0x31E21AC", Offset = "0x31E21AC", Length = "0x18")]
	[Token(Token = "0x600000C")]
	public int get_Count() { }

	[Address(RVA = "0x31E21C4", Offset = "0x31E21C4", Length = "0x440")]
	[Token(Token = "0x600000D")]
	public LevelData GetLevel(int index) { }

	[Address(RVA = "0x31E277C", Offset = "0x31E277C", Length = "0xDC")]
	[Token(Token = "0x600000F")]
	public static byte[] ToRegionBytes(int[] flat, int size) { }

}

