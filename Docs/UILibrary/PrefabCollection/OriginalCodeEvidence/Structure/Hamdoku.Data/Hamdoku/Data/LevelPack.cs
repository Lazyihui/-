namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "LevelPack", menuName = "Hamdoku/Level Pack")]
[Token(Token = "0x200001A")]
public sealed class LevelPack : ScriptableObject
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400012B")]
	public string packName; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400012C")]
	[Tooltip("플레이 순서대로 나열한 레벨들(개별 LevelData 방식). database가 있으면 무시된다")]
	public LevelData[] levels; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400012D")]
	[Tooltip("대량 레벨 저장소. 지정되면 이 팩은 개별 levels 대신 DB에서 레벨을 읽는다")]
	public CampaignDatabase database; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400012E")]
	[Tooltip("신규 캠페인 판에 크기×난이도 문제집과 성적 기반 난이도 적용")]
	public bool dynamicDifficulty; //Field offset: 0x30

	[Token(Token = "0x17000017")]
	public int Count
	{
		[Address(RVA = "0x31E98A0", Offset = "0x31E98A0", Length = "0x90")]
		[Token(Token = "0x6000062")]
		 get { } //Length: 144
	}

	[Address(RVA = "0x31E99F0", Offset = "0x31E99F0", Length = "0x8")]
	[Token(Token = "0x6000064")]
	public LevelPack() { }

	[Address(RVA = "0x31E9930", Offset = "0x31E9930", Length = "0xC0")]
	[Token(Token = "0x6000063")]
	public LevelData Get(int index) { }

	[Address(RVA = "0x31E98A0", Offset = "0x31E98A0", Length = "0x90")]
	[Token(Token = "0x6000062")]
	public int get_Count() { }

}

