namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "HamsterSkin", menuName = "Hamdoku/Hamster Skin")]
[Token(Token = "0x200006D")]
public sealed class HamsterSkin : ScriptableObject
{
	[Token(Token = "0x200006E")]
	public struct CelebrateTheme
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000607")]
		[Tooltip("ComboCelebrateFx 테마 등록명(cheer·dance…)")]
		public string theme; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000608")]
		[Tooltip("교체 프레임 — 기본 테마와 프레임 수가 같아야 적용된다")]
		public Sprite[] frames; //Field offset: 0x8

	}

	[Token(Token = "0x4000604")]
	public static Func<int> ActiveIdProvider; //Field offset: 0x0
	[Token(Token = "0x4000605")]
	private static readonly Dictionary<int, HamsterSkin> _cache; //Field offset: 0x8
	[CompilerGenerated]
	[Token(Token = "0x4000606")]
	private static Action ActiveChanged; //Field offset: 0x10
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40005FE")]
	[Tooltip("스킨 ID(1~). 파일명 skin_{id}와 같아야 한다")]
	public int id; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40005FF")]
	[Tooltip("배치 등장(엄지척) 프레임")]
	public Sprite appear; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000600")]
	[Tooltip("상시 표정 프레임 — 프리팹 idleFrames와 같은 순서(idle_01~08)")]
	public Sprite[] idle; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000601")]
	[Tooltip("오답(울상) 프레임")]
	public Sprite wrong; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000602")]
	[Tooltip("상단 목표 카운터(N/10) 얼굴 아이콘 — 비면 상시 2번 컷(idle_02)")]
	public Sprite hudIcon; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000603")]
	[Tooltip("콤보 셀레브레이션 테마별 교체 프레임. 비면 기본 그림")]
	public CelebrateTheme[] celebrate; //Field offset: 0x40

	[Token(Token = "0x14000009")]
	public static event Action ActiveChanged
	{
		[Address(RVA = "0x340686C", Offset = "0x340686C", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000321")]
		 add { } //Length: 220
		[Address(RVA = "0x3406948", Offset = "0x3406948", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000322")]
		 remove { } //Length: 220
	}

	[Token(Token = "0x17000087")]
	public static HamsterSkin Active
	{
		[Address(RVA = "0x3403F08", Offset = "0x3403F08", Length = "0x50")]
		[Token(Token = "0x6000320")]
		 get { } //Length: 80
	}

	[Token(Token = "0x17000086")]
	public static int ActiveId
	{
		[Address(RVA = "0x34065D0", Offset = "0x34065D0", Length = "0x98")]
		[Token(Token = "0x600031F")]
		 get { } //Length: 152
	}

	[Token(Token = "0x17000088")]
	public int IdleCount
	{
		[Address(RVA = "0x34042BC", Offset = "0x34042BC", Length = "0x18")]
		[Token(Token = "0x6000328")]
		 get { } //Length: 24
	}

	[Address(RVA = "0x3406C84", Offset = "0x3406C84", Length = "0x90")]
	[Token(Token = "0x600032C")]
	private static HamsterSkin() { }

	[Address(RVA = "0x3406C7C", Offset = "0x3406C7C", Length = "0x8")]
	[Token(Token = "0x600032B")]
	public HamsterSkin() { }

	[Address(RVA = "0x340686C", Offset = "0x340686C", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000321")]
	public static void add_ActiveChanged(Action value) { }

	[Address(RVA = "0x34040A0", Offset = "0x34040A0", Length = "0x7C")]
	[Token(Token = "0x6000325")]
	public Sprite Appear(Sprite fallback) { }

	[Address(RVA = "0x3406B54", Offset = "0x3406B54", Length = "0x128")]
	[Token(Token = "0x600032A")]
	public Sprite[] Celebrate(string theme, Sprite[] fallback) { }

	[Address(RVA = "0x3403F08", Offset = "0x3403F08", Length = "0x50")]
	[Token(Token = "0x6000320")]
	public static HamsterSkin get_Active() { }

	[Address(RVA = "0x34065D0", Offset = "0x34065D0", Length = "0x98")]
	[Token(Token = "0x600031F")]
	public static int get_ActiveId() { }

	[Address(RVA = "0x34042BC", Offset = "0x34042BC", Length = "0x18")]
	[Token(Token = "0x6000328")]
	public int get_IdleCount() { }

	[Address(RVA = "0x3406AC0", Offset = "0x3406AC0", Length = "0x94")]
	[Token(Token = "0x6000327")]
	public Sprite HudIcon(Sprite fallback) { }

	[Address(RVA = "0x3403F58", Offset = "0x3403F58", Length = "0xC0")]
	[Token(Token = "0x6000329")]
	public Sprite Idle(int i, Sprite fallback) { }

	[Address(RVA = "0x3406668", Offset = "0x3406668", Length = "0x204")]
	[Token(Token = "0x6000324")]
	public static HamsterSkin Load(int id) { }

	[Address(RVA = "0x3406A24", Offset = "0x3406A24", Length = "0x9C")]
	[Token(Token = "0x6000323")]
	public static void NotifyActiveChanged() { }

	[Address(RVA = "0x3406948", Offset = "0x3406948", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000322")]
	public static void remove_ActiveChanged(Action value) { }

	[Address(RVA = "0x34041A4", Offset = "0x34041A4", Length = "0x7C")]
	[Token(Token = "0x6000326")]
	public Sprite Wrong(Sprite fallback) { }

}

