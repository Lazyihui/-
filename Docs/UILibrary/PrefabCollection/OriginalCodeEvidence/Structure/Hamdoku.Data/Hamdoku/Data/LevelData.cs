namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "Level", menuName = "Hamdoku/Level Data")]
[Token(Token = "0x2000019")]
public sealed class LevelData : ScriptableObject
{
	[FieldOffset(Offset = "0x18")]
	[Min(1)]
	[Token(Token = "0x4000124")]
	[Tooltip("보드 한 변의 크기 (예: 5 이면 5x5)")]
	public int size; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000125")]
	[Tooltip("구역 ID 배열 — 행 우선(row-major), 길이 = size*size, 값 범위 0~size-1")]
	public int[] regionIds; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000126")]
	[Tooltip("정답 햄스터 위치(힌트/검증용). 각 원소 x=열, y=행")]
	public Vector2Int[] solution; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000127")]
	[Tooltip("판을 열 때부터 놓여 있는 햄스터(스도쿠의 givens). 비어 있으면 빈 판으로 시작. x=열, y=행")]
	public Vector2Int[] preplaced; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Header("메타")]
	[Token(Token = "0x4000128")]
	public int levelNumber; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000129")]
	public string displayName; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400012A")]
	[Tooltip("난이도 점수(작을수록 쉬움). 캠페인 정렬/표시용")]
	public int difficulty; //Field offset: 0x48

	[Address(RVA = "0x31E9890", Offset = "0x31E9890", Length = "0x10")]
	[Token(Token = "0x6000061")]
	public LevelData() { }

	[Address(RVA = "0x31E97BC", Offset = "0x31E97BC", Length = "0x74")]
	[Token(Token = "0x600005F")]
	public Board CreateBoard() { }

	[Address(RVA = "0x31E9830", Offset = "0x31E9830", Length = "0x60")]
	[Token(Token = "0x6000060")]
	public bool IsValid() { }

	[Address(RVA = "0x31E96C0", Offset = "0x31E96C0", Length = "0xFC")]
	[Token(Token = "0x600005E")]
	public int[,] ToRegionLayout() { }

}

