namespace Hamdoku.Managers;

[CreateAssetMenu(fileName = "GameCenterConfig", menuName = "Hamdoku/Game Center Config")]
[Token(Token = "0x20000A1")]
public sealed class GameCenterConfig : ScriptableObject
{
	[Token(Token = "0x20000A3")]
	public enum AccessPointLocation : int
	{
		TopLeading = 0,
		TopTrailing = 1,
		BottomLeading = 2,
		BottomTrailing = 3,
	}

	[Token(Token = "0x20000A2")]
	public struct AchievementEntry
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000351")]
		public GcAchievement kind; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000352")]
		[Tooltip("App Store Connect 업적 ID(예: com.mobirix.hamdoku.ach.first_clear). 비우면 이 업적은 보고하지 않는다.")]
		public string id; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000353")]
		[Tooltip("달성 시 GameKit 기본 완료 배너를 띄운다. 클리어 연출과 겹치면 끄고 자체 안내로 대체.")]
		public bool showBanner; //Field offset: 0x10

	}

	[Token(Token = "0x400034E")]
	public const string RcKeyEnabled = "game_center_enabled"; //Field offset: 0x0
	[Token(Token = "0x400034F")]
	private static Nullable<bool> _rcEnabled; //Field offset: 0x0
	[Token(Token = "0x4000350")]
	private static GameCenterConfig _instance; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Header("마스터")]
	[Token(Token = "0x4000337")]
	[Tooltip("Game Center 연동 전체. [RC 키 game_center_enabled가 우선]")]
	public bool enabled; //Field offset: 0x18
	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x4000338")]
	[Tooltip("앱 시작 후 자동 인증. 꺼두면 GameCenterManager.Authenticate()를 직접 불러야 한다.")]
	public bool authenticateOnLaunch; //Field offset: 0x19
	[FieldOffset(Offset = "0x1C")]
	[Range(0, 15)]
	[Token(Token = "0x4000339")]
	[Tooltip("자동 인증을 이만큼(초) 늦춘다 — 로고 인트로·로딩 위에 GameKit 배너/로그인 시트가 겹치지 않게.")]
	public float authDelaySeconds; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Header("리더보드 ID(App Store Connect)")]
	[Token(Token = "0x400033A")]
	[Tooltip("데일리 챌린지 완료 시간. recurring(일간) · 낮을수록 좋음 · 형식 '경과 시간(1/100초)'. 그날 첫 완주만 제출.")]
	public string dailyTimeLeaderboardId; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400033B")]
	[Tooltip("최고 도달 레벨(캠페인 클리어 수). classic · 높을수록 좋음 · 정수. 캠페인 클리어마다 제출(GC가 최고값 유지).")]
	public string bestLevelLeaderboardId; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Header("업적 ID(App Store Connect)")]
	[Token(Token = "0x400033C")]
	public AchievementEntry[] achievements; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Header("진행형 업적 목표")]
	[Token(Token = "0x400033D")]
	[Tooltip("Clears10 · Clears20 · Clears100의 목표 클리어 수. ASC 업적 이름·설명과 맞춘다.")]
	public int clears10Target; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x400033E")]
	public int clears20Target; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400033F")]
	public int clears100Target; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000340")]
	[Tooltip("Combo8 기준 연속 발견 수(ComboTextFx 8단계 Unbelievable).")]
	public int comboTarget; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000341")]
	[Tooltip("Streak7 · Streak30 기준 연속 승리 일수.")]
	public int streak7Target; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000342")]
	public int streak30Target; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Header("진행형 업적 목표 — 2차 확장")]
	[Token(Token = "0x4000343")]
	[Tooltip("Clears300 목표 레벨 클리어 수.")]
	public int clears300Target; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4000344")]
	[Tooltip("Combo12 기준 연속 발견 수(ComboTextFx 12단계 Breathtaking).")]
	public int combo12Target; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000345")]
	[Tooltip("Daily10 · Daily30 기준 데일리 챌린지 완주 횟수. 출시일(GameConfig.rankingDummyStreakLaunchDay) 이후 날짜별 완료 기록을 센다.")]
	public int daily10Target; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000346")]
	public int daily30Target; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000347")]
	[Tooltip("Streak14 · Streak90 기준 연속 승리 일수(화단 새싹 14 · 뒷줄 90과 맞춤).")]
	public int streak14Target; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000348")]
	public int streak90Target; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000349")]
	[Tooltip("RankFirst3 기준 시즌 1위 누적 횟수(RankingManager.MyRank1Wins). RankFirst는 1회.")]
	public int rankFirst3Target; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Header("Access Point(로비 전용)")]
	[Token(Token = "0x400034A")]
	[Tooltip("로비(Main 씬)에서 GKAccessPoint를 켠다. 플레이·튜토리얼 화면에서는 항상 꺼진다(HIG).")]
	public bool accessPointEnabled; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400034B")]
	[Tooltip("모서리 위치. 로비 상단 프로필 카드·설정 버튼과 겹치지 않는 자리로 — 실기에서 확인.")]
	public AccessPointLocation accessPointLocation; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400034C")]
	[Tooltip("Access Point에 업적·순위 하이라이트를 잠깐 띄운다.")]
	public bool accessPointHighlights; //Field offset: 0x74
	[FieldOffset(Offset = "0x75")]
	[Header("에디터 미리보기(빌드 무시)")]
	[Token(Token = "0x400034D")]
	[Tooltip("에디터에서 인증 성공을 흉내 내 훅·큐 흐름을 로그로 확인한다. 실제 제출은 없다.")]
	public bool editorSimulateAuthenticated; //Field offset: 0x75

	[Token(Token = "0x17000052")]
	public bool EnabledEffective
	{
		[Address(RVA = "0x32FF59C", Offset = "0x32FF59C", Length = "0x84")]
		[Token(Token = "0x600032C")]
		 get { } //Length: 132
	}

	[Token(Token = "0x17000053")]
	public static GameCenterConfig Instance
	{
		[Address(RVA = "0x32FF758", Offset = "0x32FF758", Length = "0xD8")]
		[Token(Token = "0x6000330")]
		 get { } //Length: 216
	}

	[Address(RVA = "0x32FF830", Offset = "0x32FF830", Length = "0x110")]
	[Token(Token = "0x6000331")]
	public GameCenterConfig() { }

	[Address(RVA = "0x32FF4E0", Offset = "0x32FF4E0", Length = "0x84")]
	[Token(Token = "0x600032B")]
	public static void ApplyRemote(bool enabled) { }

	[Address(RVA = "0x32FF6C4", Offset = "0x32FF6C4", Length = "0x48")]
	[Token(Token = "0x600032E")]
	public bool BannerOf(GcAchievement kind) { }

	[Address(RVA = "0x32FF59C", Offset = "0x32FF59C", Length = "0x84")]
	[Token(Token = "0x600032C")]
	public bool get_EnabledEffective() { }

	[Address(RVA = "0x32FF758", Offset = "0x32FF758", Length = "0xD8")]
	[Token(Token = "0x6000330")]
	public static GameCenterConfig get_Instance() { }

	[Address(RVA = "0x32FF620", Offset = "0x32FF620", Length = "0xA4")]
	[Token(Token = "0x600032D")]
	public string IdOf(GcAchievement kind) { }

	[Address(RVA = "0x32FF70C", Offset = "0x32FF70C", Length = "0x4C")]
	[Token(Token = "0x600032F")]
	public string IdOf(GcLeaderboard lb) { }

}

