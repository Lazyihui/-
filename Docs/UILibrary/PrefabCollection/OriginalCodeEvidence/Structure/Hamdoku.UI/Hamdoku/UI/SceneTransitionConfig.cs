namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "SceneTransitionConfig", menuName = "Hamdoku/Scene Transition Config")]
[Token(Token = "0x20000B7")]
public sealed class SceneTransitionConfig : ScriptableObject
{
	[CompilerGenerated]
	[Token(Token = "0x4000BB2")]
	private static bool <CurtainUp>k__BackingField; //Field offset: 0x0
	[Token(Token = "0x4000BB3")]
	private static SceneTransitionConfig _instance; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Header("크림 페이드(모든 전환)")]
	[Range(0.05, 0.6)]
	[Token(Token = "0x4000BA7")]
	[Tooltip("이전 화면을 크림으로 덮는 시간(초)")]
	public float fadeOutSeconds; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(0.05, 0.6)]
	[Token(Token = "0x4000BA8")]
	[Tooltip("새 화면을 드러내는 시간(초). 이 동안 보드 셀 착착(레벨) / 로고 팝(홈)이 눈앞에서 시작된다")]
	public float fadeInSeconds; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000BA9")]
	[Tooltip("페이드 색(테마 크림). 로딩 화면 배경과 같은 값. 패턴이 켜져 있으면 패턴 아래 바탕색")]
	public Color fadeColor; //Field offset: 0x20
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000BAA")]
	[Tooltip("커튼에 로비 배경 패턴(UI/MenuBackground)을 로비와 같은 배치로 깐다. 끄면 단색 크림")]
	public bool curtainPattern; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Header("홈 복귀 마스코트(인게임 → 로비에만)")]
	[Range(0, 1.5)]
	[Token(Token = "0x4000BAB")]
	[Tooltip("크림 위에 햄스터가 머무는 시간(초). 0이면 마스코트 없이 페이드만. 레벨→홈 총 시간 ≈ 페이드 아웃 + 이 값 + 페이드 인")]
	public float homeMascotSeconds; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Range(200, 800)]
	[Token(Token = "0x4000BAC")]
	[Tooltip("마스코트 크기(px, 캔버스 기준)")]
	public float homeMascotSize; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Range(0.3, 1)]
	[Token(Token = "0x4000BAD")]
	[Tooltip("등장 시작 크기 비율(이 크기에서 1.0으로 커진다)")]
	public float homeMascotPopFrom; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Range(0, 60)]
	[Token(Token = "0x4000BAE")]
	[Tooltip("둥실 떠오르는 높이(px)")]
	public float homeMascotBobHeight; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Header("홈 로고 등장(LogoAnimator)")]
	[Range(0.5, 1)]
	[Token(Token = "0x4000BAF")]
	[Tooltip("로고 팝 시작 크기 비율(이 크기에서 1.0으로)")]
	public float logoPopFrom; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[Token(Token = "0x4000BB0")]
	[Tooltip("로고 팝 시간(초). 0이면 팝 없음")]
	public float logoPopSeconds; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000BB1")]
	[Tooltip("씬이 뜬 뒤 팝을 시작하기까지 대기(초). 페이드가 걷히는 초반에 팝이 묻히지 않게 한다")]
	public float logoPopDelaySeconds; //Field offset: 0x4C

	[Token(Token = "0x170000C1")]
	public static bool CurtainUp
	{
		[Address(RVA = "0x342D9CC", Offset = "0x342D9CC", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x60004F7")]
		 get { } //Length: 72
		[Address(RVA = "0x342DA14", Offset = "0x342DA14", Length = "0x50")]
		[CompilerGenerated]
		[Token(Token = "0x60004F8")]
		 set { } //Length: 80
	}

	[Token(Token = "0x170000C2")]
	public static SceneTransitionConfig Instance
	{
		[Address(RVA = "0x342DAA4", Offset = "0x342DAA4", Length = "0x180")]
		[Token(Token = "0x60004FA")]
		 get { } //Length: 384
	}

	[Address(RVA = "0x342DC24", Offset = "0x342DC24", Length = "0x4C")]
	[Token(Token = "0x60004FB")]
	public SceneTransitionConfig() { }

	[Address(RVA = "0x342D9CC", Offset = "0x342D9CC", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x60004F7")]
	public static bool get_CurtainUp() { }

	[Address(RVA = "0x342DAA4", Offset = "0x342DAA4", Length = "0x180")]
	[Token(Token = "0x60004FA")]
	public static SceneTransitionConfig get_Instance() { }

	[Address(RVA = "0x342DA64", Offset = "0x342DA64", Length = "0x40")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x60004F9")]
	private static void ResetStatics() { }

	[Address(RVA = "0x342DA14", Offset = "0x342DA14", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x60004F8")]
	public static void set_CurtainUp(bool value) { }

}

