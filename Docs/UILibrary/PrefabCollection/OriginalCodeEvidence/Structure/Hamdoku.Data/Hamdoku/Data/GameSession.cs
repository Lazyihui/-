namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "GameSession", menuName = "Hamdoku/Game Session")]
[Token(Token = "0x2000015")]
public sealed class GameSession : ScriptableObject
{
	[CompilerGenerated]
	[Token(Token = "0x400010C")]
	private static GameSession <Active>k__BackingField; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000105")]
	[Tooltip("메인 캠페인 팩")]
	public LevelPack campaignPack; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000106")]
	[Tooltip("튜토리얼 전용 손제작 레벨(4x4)")]
	public LevelData tutorialLevel; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000107")]
	public PlayMode mode; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000108")]
	[Tooltip("런타임: 플레이할 레벨 인덱스. -1이면 저장된 진행을 사용")]
	public int levelIndex; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000109")]
	public int dailySeed; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x400010A")]
	[Tooltip("런타임: 지나간 날짜의 보충 도전인지(광고 입장). 스트릭·기록에 안 섞이고 도장판만 채운다")]
	public bool dailyLate; //Field offset: 0x34
	[FieldOffset(Offset = "0x35")]
	[Token(Token = "0x400010B")]
	[Tooltip("런타임: 황금 해바라기씨 챌린지(캠페인 보너스 판) 요청인지. 캠페인 모드 위에 얹는 표식이다")]
	public bool golden; //Field offset: 0x35

	[Token(Token = "0x17000014")]
	public static GameSession Active
	{
		[Address(RVA = "0x31E72D4", Offset = "0x31E72D4", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x6000047")]
		 get { } //Length: 72
		[Address(RVA = "0x31E731C", Offset = "0x31E731C", Length = "0x58")]
		[CompilerGenerated]
		[Token(Token = "0x6000048")]
		private set { } //Length: 88
	}

	[Address(RVA = "0x31E7424", Offset = "0x31E7424", Length = "0x10")]
	[Token(Token = "0x600004F")]
	public GameSession() { }

	[Address(RVA = "0x31E72D4", Offset = "0x31E72D4", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x6000047")]
	public static GameSession get_Active() { }

	[Address(RVA = "0x31E7374", Offset = "0x31E7374", Length = "0x58")]
	[Token(Token = "0x6000049")]
	private void OnEnable() { }

	[Address(RVA = "0x31E73CC", Offset = "0x31E73CC", Length = "0xC")]
	[Token(Token = "0x600004A")]
	public void RequestCampaign(int index = -1) { }

	[Address(RVA = "0x31E73EC", Offset = "0x31E73EC", Length = "0x18")]
	[Token(Token = "0x600004C")]
	public void RequestDaily(int seed, bool late = false) { }

	[Address(RVA = "0x31E7404", Offset = "0x31E7404", Length = "0x10")]
	[Token(Token = "0x600004D")]
	public void RequestEndless() { }

	[Address(RVA = "0x31E73D8", Offset = "0x31E73D8", Length = "0x14")]
	[Token(Token = "0x600004B")]
	public void RequestGolden() { }

	[Address(RVA = "0x31E7414", Offset = "0x31E7414", Length = "0x10")]
	[Token(Token = "0x600004E")]
	public void RequestTutorial() { }

	[Address(RVA = "0x31E731C", Offset = "0x31E731C", Length = "0x58")]
	[CompilerGenerated]
	[Token(Token = "0x6000048")]
	private static void set_Active(GameSession value) { }

}

