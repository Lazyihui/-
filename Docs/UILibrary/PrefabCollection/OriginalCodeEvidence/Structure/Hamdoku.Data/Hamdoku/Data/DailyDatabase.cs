namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "DailyDatabase", menuName = "Hamdoku/Daily Database")]
[Token(Token = "0x200000F")]
public sealed class DailyDatabase : ScriptableObject
{
	[Token(Token = "0x2000010")]
	public struct Entry
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000047")]
		[Tooltip("불변 ID. 편성표가 이 값으로 퍼즐을 가리키므로 한번 배포되면 절대 바꾸지 않는다")]
		public int puzzleId; //Field offset: 0x0
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x4000048")]
		[Tooltip("보드 한 변 크기")]
		public int size; //Field offset: 0x4
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000049")]
		[Tooltip("구역 ID 배열 — 행 우선, 길이 size*size, 값 0~size-1")]
		public int[] regionIds; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400004A")]
		[Tooltip("정답 위치. x=열, y=행")]
		public Vector2Int[] solution; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400004B")]
		[Tooltip("0=일반, 1=하드. 런타임이 difficulty >= 1을 하드로 해석하므로 정렬 점수를 넣으면 안 된다")]
		public int difficulty; //Field offset: 0x18

	}

	[Token(Token = "0x2000011")]
	public struct Season
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x400004C")]
		public int index; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400004D")]
		[Tooltip("길이 364. 시즌 시작일(월요일)부터 하루씩")]
		public int[] dayToPuzzleId; //Field offset: 0x8

	}

	[Token(Token = "0x4000041")]
	public const int SeasonDays = 364; //Field offset: 0x0
	[Token(Token = "0x4000046")]
	private static DailyDatabase _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000042")]
	[Tooltip("시즌 0의 시작 날짜(yyyy-MM-dd). 반드시 월요일. 출시일보다 앞선 월요일로 잡을 것")]
	public string seasonStartDate; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000043")]
	[Tooltip("크기 무관 전체 퍼즐 풀")]
	public Entry[] entries; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000044")]
	[Tooltip("시즌별 364일 편성표. 배포된 시즌은 재정렬 금지, 다음 시즌만 추가")]
	public Season[] seasons; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000045")]
	private Dictionary<int, int> _byId; //Field offset: 0x30

	[Token(Token = "0x17000011")]
	private Dictionary<int, int> ByIdMap
	{
		[Address(RVA = "0x31E5BF8", Offset = "0x31E5BF8", Length = "0x110")]
		[Token(Token = "0x6000039")]
		 get { } //Length: 272
	}

	[Token(Token = "0x17000012")]
	public static DailyDatabase Instance
	{
		[Address(RVA = "0x31E64F8", Offset = "0x31E64F8", Length = "0xDC")]
		[Token(Token = "0x600003F")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x31E65D4", Offset = "0x31E65D4", Length = "0x58")]
	[Token(Token = "0x6000040")]
	public DailyDatabase() { }

	[Address(RVA = "0x31E6360", Offset = "0x31E6360", Length = "0x134")]
	[Token(Token = "0x600003D")]
	public static Board CreateBoard(Entry e) { }

	[Address(RVA = "0x31E5BF8", Offset = "0x31E5BF8", Length = "0x110")]
	[Token(Token = "0x6000039")]
	private Dictionary<int, int> get_ByIdMap() { }

	[Address(RVA = "0x31E64F8", Offset = "0x31E64F8", Length = "0xDC")]
	[Token(Token = "0x600003F")]
	public static DailyDatabase get_Instance() { }

	[Address(RVA = "0x31E6494", Offset = "0x31E6494", Length = "0x64")]
	[Token(Token = "0x600003E")]
	public static bool IsValid(Entry e) { }

	[Address(RVA = "0x31E6010", Offset = "0x31E6010", Length = "0x350")]
	[Token(Token = "0x600003C")]
	private static int PermuteWithinSize(int dayOfSeason, int cycle, int seasonIndex, int len) { }

	[Address(RVA = "0x31E5BA8", Offset = "0x31E5BA8", Length = "0x50")]
	[Token(Token = "0x6000038")]
	public static int SizeForDayOfSeason(int dayOfSeason) { }

	[Address(RVA = "0x31E5DC8", Offset = "0x31E5DC8", Length = "0x248")]
	[Token(Token = "0x600003B")]
	public bool TryGetForDate(DateTime date, out Entry entry, out int seasonIndex, out int dayOfSeason, out int cycle) { }

	[Address(RVA = "0x31E5D08", Offset = "0x31E5D08", Length = "0xC0")]
	[Token(Token = "0x600003A")]
	public bool TryGetSeasonStart(out DateTime start) { }

}

