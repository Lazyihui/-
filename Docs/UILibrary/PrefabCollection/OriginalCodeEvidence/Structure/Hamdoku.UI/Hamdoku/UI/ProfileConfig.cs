namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "ProfileConfig", menuName = "Hamdoku/Profile Config")]
[Token(Token = "0x200009D")]
public sealed class ProfileConfig : ScriptableObject
{
	[Token(Token = "0x200009F")]
	public struct Costume
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000899")]
		[Tooltip("식별 키(파일명·이름 키 costume_name_{key}). 비우면 없는 항목으로 본다")]
		public string key; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400089A")]
		[Tooltip("기본 장식(512 캔버스, 전 표정 공용)")]
		public Sprite sprite; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400089B")]
		[Tooltip("등장(윙크+엄지척) 프레임용 변형 — 비우면 기본")]
		public Sprite appearSprite; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400089C")]
		[Tooltip("오답(울상) 프레임용 변형 — 비우면 기본")]
		public Sprite wrongSprite; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400089D")]
		[Tooltip("햄스터 rect 안 위치(정규화, 좌하단 원점). 비우면(0,0,0,0) 캔버스 전체 = 햄스터와 같은 rect. 규격 에셋은 512 캔버스 그대로라 비워 둔다")]
		public Rect rect; //Field offset: 0x20
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400089E")]
		[Tooltip("출처 — Season이면 seasonId(yyyymm)의 데일리 챌린지 시즌 보상")]
		public CostumeSource source; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x400089F")]
		public int seasonId; //Field offset: 0x34

	}

	[Token(Token = "0x20000A0")]
	public struct CostumeFit
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40008A0")]
		[Tooltip("머리 기준점 이동(아바타 rect 비율, +오른쪽/+위). 스티커형 7~16은 머리 위치가 조금씩 다르다")]
		public Vector2 offset; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40008A1")]
		[Tooltip("배율(1=그대로) — 머리 기준점(costumeHeadPivot) 중심")]
		public float scale; //Field offset: 0x8
		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x40008A2")]
		[Tooltip("회전(도, +반시계) — 고개를 기울인 아바타용, 머리 기준점 중심")]
		public float rotation; //Field offset: 0xC
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40008A3")]
		[Tooltip("이 아바타에 쓸 코스튬 변형 — 손이 얼굴 앞에 있는 그림은 손 자리를 뚫은 변형(Appear=엄지척, Wrong=울상)을 쓴다")]
		public CostumeState variant; //Field offset: 0x10

	}

	[Token(Token = "0x20000A1")]
	public struct CostumeFitSet
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40008A4")]
		[Tooltip("코스튬 key(Costumes 시트 key 열, 예: nightcap) — id 대신 key로 묶어 시트 행 순서와 무관")]
		public string costumeKey; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40008A5")]
		[Tooltip("이 코스튬 전용 아바타별 보정 — 인덱스 = 아바타 ID. scale 0이면 그 아바타는 공통값(avatarCostumeFits)")]
		public CostumeFit[] fits; //Field offset: 0x8

	}

	[Token(Token = "0x200009E")]
	public enum CostumeSource : int
	{
		Season = 0,
		Event = 1,
		Shop = 2,
	}

	[Token(Token = "0x20000A2")]
	private sealed class CrownAuraDriver : MonoBehaviour
	{
		[Token(Token = "0x40008A6")]
		private static CrownAuraDriver _inst; //Field offset: 0x0
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40008A7")]
		private float[] _phase; //Field offset: 0x20

		[Address(RVA = "0x3420590", Offset = "0x3420590", Length = "0x8")]
		[Token(Token = "0x6000462")]
		public CrownAuraDriver() { }

		[Address(RVA = "0x341F30C", Offset = "0x341F30C", Length = "0x138")]
		[Token(Token = "0x6000460")]
		public static void Ensure() { }

		[Address(RVA = "0x3420364", Offset = "0x3420364", Length = "0x22C")]
		[Token(Token = "0x6000461")]
		private void Update() { }

	}

	[Token(Token = "0x4000838")]
	private static ProfileConfig _inst; //Field offset: 0x0
	[Token(Token = "0x4000883")]
	public const int ClubFrameId = 20; //Field offset: 0x0
	[Token(Token = "0x4000885")]
	public const float CrownOpening = 0.5567; //Field offset: 0x0
	[Token(Token = "0x4000886")]
	public const float RingOpening = 0.77; //Field offset: 0x0
	[Token(Token = "0x4000839")]
	public const int ClubAvatarsMirroringBase = 6; //Field offset: 0x0
	[Token(Token = "0x4000888")]
	public const float CrownOpeningCenterX = 0.518; //Field offset: 0x0
	[Token(Token = "0x4000889")]
	public const float CrownOpeningCenterY = 0.568; //Field offset: 0x0
	[Token(Token = "0x400088B")]
	public const float CrownBadgeNumBox = 0.135; //Field offset: 0x0
	[Token(Token = "0x400083B")]
	public const float RingOpeningOfPlate = 0.9; //Field offset: 0x0
	[Token(Token = "0x400088D")]
	public const float CrownFrameK = 1.39; //Field offset: 0x0
	[Token(Token = "0x400088E")]
	public const float CrownPlateScale = 1.04; //Field offset: 0x0
	[Token(Token = "0x400088F")]
	private const string AuraName = "CrownAura"; //Field offset: 0x0
	[Token(Token = "0x4000890")]
	private const string AuraSpritePath = "UI/Profile/crown_aura"; //Field offset: 0x0
	[Token(Token = "0x4000891")]
	private const string AuraMaterialPath = "UIRainbowAura"; //Field offset: 0x0
	[Token(Token = "0x4000892")]
	private const float AuraCanvasScale = 1.3333334; //Field offset: 0x0
	[Token(Token = "0x400083A")]
	public const int BoardFitAvatarId = 0; //Field offset: 0x0
	[Token(Token = "0x400083C")]
	public static readonly int[] CrownFrameIds; //Field offset: 0x8
	[Token(Token = "0x400083D")]
	public static readonly int[] LegendFrameIds; //Field offset: 0x10
	[CompilerGenerated]
	[Token(Token = "0x4000882")]
	private static Action Edited; //Field offset: 0x18
	[Token(Token = "0x4000884")]
	public static readonly int[] ClubFrameIds; //Field offset: 0x20
	[Token(Token = "0x4000887")]
	private static readonly Vector2 CrownOpeningCenter; //Field offset: 0x28
	[Token(Token = "0x400088A")]
	public static readonly Vector2 CrownBadgeCenter; //Field offset: 0x30
	[Token(Token = "0x400088C")]
	public static readonly Vector2 CrownJewelCenter; //Field offset: 0x38
	[Token(Token = "0x4000893")]
	private static Material[] _auraMats; //Field offset: 0x40
	[Token(Token = "0x4000894")]
	private static bool _auraMissingLogged; //Field offset: 0x48
	[FieldOffset(Offset = "0x18")]
	[Header("아바타(인덱스 = 저장 ID, 추가는 뒤로만)")]
	[Token(Token = "0x40007F3")]
	public Sprite[] avatars; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40007F4")]
	[Tooltip("아바타 셀/카드 배경 파스텔 — 아바타 인덱스로 순환(개수가 달라도 됨)")]
	public Color[] avatarBg; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Header("프레임(인덱스 = 저장 ID. 0=기본, 1~3=위클리 Top3 보상, 7·10~15=1위 왕관 로테이션, 16~19=1위 누적 횟수 해금)")]
	[Token(Token = "0x40007F5")]
	public Sprite[] frames; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40007F6")]
	private readonly Dictionary<int, Costume> _costumeCache; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40007F7")]
	private int _costumeCacheVersion; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40007F8")]
	[Tooltip("기본 햄스터(아바타 0) 머리 기준점(아바타 rect 정규화, y 위). 코스튬 보정의 배율·회전 중심. Tools/CostumeFit 자동 측정값")]
	public Vector2 costumeHeadPivot; //Field offset: 0x3C
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40007F9")]
	[Tooltip("아바타별 코스튬 보정 — 인덱스 = 아바타 ID. 없거나 scale 0이면 보정 없음(0~6은 보드 햄스터와 같은 캔버스라 불필요)")]
	public CostumeFit[] avatarCostumeFits; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40007FA")]
	[Tooltip("코스튬별 전용 보정 — 없는 코스튬·아바타는 위 avatarCostumeFits(공통, 호박 후드 기준)를 쓴다")]
	public CostumeFitSet[] costumeFitSets; //Field offset: 0x50
	[FieldOffset(Offset = "0x58")]
	[Header("누적 1위 해금 프레임 — 회전 무지개 오라")]
	[Token(Token = "0x40007FB")]
	[Tooltip("이 단계(ProfileConfig.LegendTier, 1~4) 이상부터 프레임 뒤에 회전 오라를 붙인다. 0=끔. 기본 2 = 블루 오로라(17)부터, 무지개(18·19)까지")]
	public int auraFromTier; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40007FC")]
	[Tooltip("오라 알파 — 인덱스 = (단계 - auraFromTier). 부족하면 마지막 값. 위 단계가 더 진하다")]
	public float[] auraAlpha; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40007FD")]
	[Tooltip("오라 회전 속도(바퀴/초) — 인덱스 = (단계 - auraFromTier). 부족하면 마지막 값")]
	public float[] auraSpeed; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40007FE")]
	[Tooltip("휘감는 빛 띠 세기 — 0=오라 전체가 균일하게 발광, 1=돌아가는 띠만 보임. 인덱스 = (단계 - auraFromTier)")]
	public float[] auraSweepStrength; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40007FF")]
	[Tooltip("빛 띠 꼬리 길이(한 바퀴 대비 비율) — 인덱스 = (단계 - auraFromTier). 길수록 부드럽게 감김")]
	public float[] auraSweepWidth; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000800")]
	[Tooltip("동시에 돌아가는 빛 띠 개수 — 인덱스 = (단계 - auraFromTier). 최상위는 2개가 마주 돌며 감싸는 느낌")]
	public int[] auraSweepCount; //Field offset: 0x80
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000801")]
	[Tooltip("오라 색상 시작(0~1, 0=빨강 0.5=청록 0.67=파랑 0.75=보라) — 인덱스 = (단계 - auraFromTier). 무지개 단계는 0. 크림 배경에선 밝은 청록·노랑이 묻히므로 단색 오라는 파랑~보라 같은 짙은 계열로")]
	public float[] auraHueBase; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000802")]
	[Tooltip("오라 색상 폭(1=무지개 전체, 0.24=시작 색에서 한 계열만 왕복. 예: 0.5+0.24 = 청록~인디고 푸른 오라) — 인덱스 = (단계 - auraFromTier)")]
	public float[] auraHueRange; //Field offset: 0x90
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000803")]
	[Tooltip("테두리 한 바퀴에 색 띠가 몇 번 반복되는가 — 1=무지개 한 바퀴(츄르 아이콘), 2~3=같은 계열 색이 여러 띠로 늘어서 흐름이 잘 보임. 인덱스 = (단계 - auraFromTier)")]
	public float[] auraCycles; //Field offset: 0x98
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000804")]
	[Tooltip("오라 퍼짐 — 1=마스크 그대로, 클수록 프레임에 바짝 붙고 좁아짐(2~3), 작을수록 넓고 진하게 퍼짐(0.5). 인덱스 = (단계 - auraFromTier)")]
	public float[] auraSpread; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA8")]
	[Range(0, 1)]
	[Token(Token = "0x4000805")]
	[Tooltip("오라 색 채도(셰이더 _Saturation)")]
	public float auraSaturation; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Range(0, 2)]
	[Token(Token = "0x4000806")]
	[Tooltip("오라 색 밝기(셰이더 _Value)")]
	public float auraValue; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Header("로비 프로필 카드")]
	[Token(Token = "0x4000807")]
	public float cardSize; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4000808")]
	[Tooltip("SafeArea 좌상단 → 카드 좌상단 여백")]
	public Vector2 cardMargin; //Field offset: 0xB4
	[FieldOffset(Offset = "0xBC")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000809")]
	[Tooltip("카드 크기 대비 배경 채움 인셋 비율(프레임 중앙이 투명이라 배경 필수)")]
	public float cardBgInset; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Range(0, 0.4)]
	[Token(Token = "0x400080A")]
	[Tooltip("카드 크기 대비 아바타 인셋 비율")]
	public float cardAvatarInset; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Range(0, 0.4)]
	[Token(Token = "0x400080B")]
	[Tooltip("햄덕 클럽 회원증(프로필 페이지·랭킹 카드) 사진 칸의 아바타 인셋 비율 — 사진 칸 배경에 아바타·코스튬 윗부분이 잘려 로비 카드보다 살짝 작게(2026-10-20)")]
	public float clubCardAvatarInset; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400080C")]
	[Tooltip("왕관 프레임을 썼을 때 추가로 더 밀어 넣는 여백(px) — 링/왕관이 카드 밖으로 나가 화면 모서리에 물린다")]
	public float cardCrownMargin; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Range(0.5, 1)]
	[Token(Token = "0x400080D")]
	[Tooltip("회원증 카드(프로필·랭킹 팝업) 사진 칸의 왕관 프레임 축소 배율 — 왕관 링이 사진 칸보다 커서(1.39배) 카드 밖으로 나가는 것을 막는다. 1=축소 없음")]
	public float clubCardCrownScale; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400080E")]
	[Tooltip("이 캔버스 높이(px)보다 짧으면 카드를 그 비율만큼 줄인다(태블릿·폴드 펼침에서 상단이 잘리는 것 방지). 0=끔")]
	public float cardWideRefHeight; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Range(0.5, 1)]
	[Token(Token = "0x400080F")]
	[Tooltip("카드 축소 하한 — 너무 작아지면 터치 타겟이 부담스러워진다")]
	public float cardWideMinScale; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000810")]
	public Vector2 closeOffset; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE0")]
	[Header("프로필 그리드·닉네임 공용 — 그룹 판·닉네임 글자 수")]
	[Token(Token = "0x4000811")]
	public float groupPpum; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x4000812")]
	public int nameMaxChars; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Header("프로필 그리드 탭(클럽 페이지 공용 — 높이·글자는 아래 클럽 항목)")]
	[Token(Token = "0x4000813")]
	public float tabH; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4000814")]
	public float tabGap; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000815")]
	[Tooltip("탭 행 좌우 인셋(px, ContentW 기준) — 탭이 그리드 패널 가장자리보다 안쪽으로 들어와 폴더 탭처럼 패널에 붙어 보인다")]
	public float tabSideInset; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000816")]
	public float tabFs; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000817")]
	[Tooltip("탭 스프라이트(profile_tab/_off) 9-slice 코너 배율")]
	public float tabPpum; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4000818")]
	[Tooltip("탭 스프라이트 없을 때 폴백 틴트 색")]
	public Color tabOnColor; //Field offset: 0xFC
	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4000819")]
	public Color tabOffColor; //Field offset: 0x10C
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x400081A")]
	public Color tabOnText; //Field offset: 0x11C
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x400081B")]
	public Color tabOffText; //Field offset: 0x12C
	[FieldOffset(Offset = "0x13C")]
	[Header("프로필 그리드(클럽 페이지·구 팝업 공용) — 칸·간격")]
	[Token(Token = "0x400081C")]
	[Tooltip("그리드 패널을 탭 행보다 좌우로 얼마나 더 넓게 (시안: 패널이 탭보다 살짝 큼)")]
	public float gridExtraWidth; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x400081D")]
	public int gridCols; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x400081E")]
	[Tooltip("보이는 행 수 — 팝업 높이는 이 값으로 고정되고, 넘치는 항목은 드래그 스크롤")]
	public int gridVisibleRows; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x400081F")]
	public float gridPad; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x4000820")]
	public float cellGap; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000821")]
	[Tooltip("셀 크기 대비 아바타 인셋 비율")]
	public float cellAvatarInset; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Range(0.7, 1.1)]
	[Token(Token = "0x4000822")]
	[Tooltip("그리드에서 왕관 프레임의 개구부 크기 = 일반 프레임 개구부 × 이 값. 1이면 같은 크기(왕관·뱃지가 셀 밖 간격으로 살짝 나감), 작을수록 셀 안에 여유")]
	public float cellCrownOpeningMatch; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x4000823")]
	[Tooltip("선택 링 두께(px)")]
	public float selRingWidth; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x4000824")]
	public Color selRingColor; //Field offset: 0x15C
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x4000825")]
	public float checkSize; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Range(0.1, 1)]
	[Token(Token = "0x4000826")]
	[Tooltip("잠긴 프레임 셀의 표시 알파")]
	public float lockedAlpha; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x4000827")]
	[Tooltip("코스튬 칸 자물쇠 위치(칸 대비 비율, 1,0 = 오른쪽 아래)·크기(칸 대비) — 햄스터 얼굴을 가리지 않게(유저 10-15). 프레임 칸 자물쇠는 프레임 가운데 그대로")]
	public Vector2 costumeLockAnchor; //Field offset: 0x174
	[FieldOffset(Offset = "0x17C")]
	[Range(0.1, 0.5)]
	[Token(Token = "0x4000828")]
	public float costumeLockSize; //Field offset: 0x17C
	[FieldOffset(Offset = "0x180")]
	[Range(0.1, 0.5)]
	[Token(Token = "0x4000829")]
	[Tooltip("프레임 칸 자물쇠 크기(칸 대비) — 프레임 가운데(왕관은 입구)")]
	public float frameLockSize; //Field offset: 0x180
	[FieldOffset(Offset = "0x184")]
	[Range(-0.1, 0.3)]
	[Token(Token = "0x400082A")]
	[Tooltip("코스튬 칸 아바타 여백(칸 크기 비율). 작을수록 꽉 찬다. 자르기는 분홍 박스 기준(2026-10-15)")]
	public float costumeCellInset; //Field offset: 0x184
	[FieldOffset(Offset = "0x188")]
	[Range(-0.3, 0.3)]
	[Token(Token = "0x400082B")]
	[Tooltip("코스튬 칸 아바타 세로 이동(칸 크기 비율, 음수=아래). 모자가 위로 잘리면 더 내린다")]
	public float costumeCellDy; //Field offset: 0x188
	[FieldOffset(Offset = "0x18C")]
	[Header("새 프레임 레드닷")]
	[Token(Token = "0x400082C")]
	[Tooltip("레드닷 지름(px) — 로비 카드·프레임 탭·그리드 셀 공용(셀은 0.85배)")]
	public float newDotSize; //Field offset: 0x18C
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x400082D")]
	[Tooltip("레드닷 색")]
	public Color newDotColor; //Field offset: 0x190
	[FieldOffset(Offset = "0x1A0")]
	[Range(0.5, 2)]
	[Token(Token = "0x400082E")]
	[Tooltip("로비 프로필 카드 레드닷 추가 배율. 1 = 팝업과 같은 화면 크기(팝업의 와이드 축소분은 코드가 자동 보정)")]
	public float newDotCardScale; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Token(Token = "0x400082F")]
	[Tooltip("레드닷 흰 테두리 두께(px)")]
	public float newDotRim; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Range(1, 1.6)]
	[Token(Token = "0x4000830")]
	[Tooltip("숨쉬기 펄스 최대 배율(1이면 정지) — 타일 피크닉 다이어리 레드닷과 같은 값")]
	public float newDotPulseScale; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x4000831")]
	[Tooltip("펄스 한 왕복 시간(초)")]
	public float newDotPulseSec; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1B0")]
	[Range(0, 0.1)]
	[Token(Token = "0x4000832")]
	[Tooltip("로비 카드 레드닷을 링 모서리 실측점에서 안쪽으로 얼마나 당길지(캔버스 비율). 0=모서리 바운딩에 걸침, 0.04=둥근 모서리 곡선 위")]
	public float newDotCornerInset; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B4")]
	[Header("로비 프로필 카드 그림자 · 탭~그리드 간격")]
	[Token(Token = "0x4000833")]
	[Tooltip("연필/확인 버튼 소프트 섀도 색(알파 = 진하기)")]
	public Color shadowColor; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x4000834")]
	[Tooltip("소프트 섀도 오프셋(px)")]
	public Vector2 shadowOffset; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x4000835")]
	[Tooltip("버튼보다 얼마나 크게 번질지(px)")]
	public float shadowGrow; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x4000836")]
	[Tooltip("0 = 탭 밑단과 그리드 패널 상단이 딱 맞닿음(탭이 패널 안으로 안 들어감). 음수 = 겹침")]
	public float gapTabsGrid; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Header("와이드 대응(로비 카드)")]
	[Range(0.3, 1)]
	[Token(Token = "0x4000837")]
	[Tooltip("와이드(태블릿) 배율 상한 — 설정 팝업과 같은 값으로 유지해야 팝업 간 크기가 일관됨")]
	public float wideScale; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Header("햄덕 클럽 아바타(이 ID부터 = 클럽 전용, 추가는 뒤로만)")]
	[Token(Token = "0x400083E")]
	public int clubAvatarStart; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x400083F")]
	[Tooltip("클럽 아바타를 골랐을 때 보드 햄스터에 쓰는 스킨 ID(Resources/HamsterSkins/skin_{id})")]
	public int clubSkinId; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Header("햄덕 클럽 회원증 — 점선·여백(플레이 중 조정 시 페이지가 바로 다시 그려진다)")]
	[Token(Token = "0x4000840")]
	[Tooltip("통계 아래 점선 색 — 일반 회원증")]
	public Color clubDashColorBasic; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x4000841")]
	[Tooltip("통계 아래 점선 색 — 골드 회원증")]
	public Color clubDashColorGold; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x200")]
	[Range(2, 40)]
	[Token(Token = "0x4000842")]
	[Tooltip("점선 한 칸 길이")]
	public float clubDashLength; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Range(1, 40)]
	[Token(Token = "0x4000843")]
	[Tooltip("점선 칸 사이 간격 — 작을수록 촘촘")]
	public float clubDashGap; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Range(1, 8)]
	[Token(Token = "0x4000844")]
	[Tooltip("점선 두께")]
	public float clubDashThickness; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Range(32, 80)]
	[Token(Token = "0x4000845")]
	[Tooltip("페이지 제목(프로필) 글자 크기")]
	public float clubPageTitleSize; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Range(28, 72)]
	[Token(Token = "0x4000846")]
	[Tooltip("회원증 브랜드(햄덕 클럽) 글자 크기")]
	public float clubBrandSize; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Range(0, 40)]
	[Token(Token = "0x4000847")]
	[Tooltip("햄덕 클럽 ~ 등급 사이 간격")]
	public float clubBrandGradeGap; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Range(14, 40)]
	[Token(Token = "0x4000848")]
	[Tooltip("등급(GOLD MEMBER / MEMBER) 글자 크기")]
	public float clubGradeSize; //Field offset: 0x218
	[FieldOffset(Offset = "0x21C")]
	[Range(18, 40)]
	[Token(Token = "0x4000849")]
	[Tooltip("좌우명 말풍선 글자 크기")]
	public float clubMottoSize; //Field offset: 0x21C
	[FieldOffset(Offset = "0x220")]
	[Range(32, 72)]
	[Token(Token = "0x400084A")]
	[Tooltip("닉네임 글자 크기")]
	public float clubNameSize; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Range(18, 40)]
	[Token(Token = "0x400084B")]
	[Tooltip("레벨·시작일 줄 글자 크기")]
	public float clubInfoSize; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Range(60, 140)]
	[Token(Token = "0x400084C")]
	[Tooltip("아바타·프레임·코스튬 탭 높이")]
	public float clubTabHeight; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Range(28, 64)]
	[Token(Token = "0x400084D")]
	[Tooltip("아바타·프레임·코스튬 탭 글자 크기")]
	public float clubTabFontSize; //Field offset: 0x22C
	[FieldOffset(Offset = "0x230")]
	[Range(0, 0.6)]
	[Token(Token = "0x400084E")]
	[Tooltip("회원증 카드 그림자 진하기(0 = 없음) — 데일리 퍼즐 카드와 같은 소프트 드롭 섀도")]
	public float clubCardShadowAlpha; //Field offset: 0x230
	[FieldOffset(Offset = "0x234")]
	[Range(4, 60)]
	[Token(Token = "0x400084F")]
	[Tooltip("그림자 번짐 폭")]
	public float clubCardShadowSpread; //Field offset: 0x234
	[FieldOffset(Offset = "0x238")]
	[Range(-40, 10)]
	[Token(Token = "0x4000850")]
	[Tooltip("그림자 아래로 내림(음수 = 아래)")]
	public float clubCardShadowOffsetY; //Field offset: 0x238
	[FieldOffset(Offset = "0x23C")]
	[Token(Token = "0x4000851")]
	[Tooltip("그림자 색")]
	public Color clubCardShadowColor; //Field offset: 0x23C
	[FieldOffset(Offset = "0x24C")]
	[Range(-40, 60)]
	[Token(Token = "0x4000852")]
	[Tooltip("로그인 스탬프를 위로 올리는 양(+ = 위로, UID 줄과의 간격이 줄어든다)")]
	public float clubStampRaise; //Field offset: 0x24C
	[FieldOffset(Offset = "0x250")]
	[Range(0, 80)]
	[Token(Token = "0x4000853")]
	[Tooltip("로그인 스탬프 아래 ~ 카드 바닥 여백")]
	public float clubStampBottomPad; //Field offset: 0x250
	[FieldOffset(Offset = "0x254")]
	[Range(16, 40)]
	[Token(Token = "0x4000854")]
	[Tooltip("로그인 스탬프 제목(LOGIN STAMP)·개수 글자 크기")]
	public float clubStampTitleSize; //Field offset: 0x254
	[FieldOffset(Offset = "0x258")]
	[Range(14, 36)]
	[Token(Token = "0x4000855")]
	[Tooltip("유효기한 글자 크기")]
	public float clubStampUntilSize; //Field offset: 0x258
	[FieldOffset(Offset = "0x25C")]
	[Range(12, 32)]
	[Token(Token = "0x4000856")]
	[Tooltip("아래 안내 문구(접속한 날마다…) 글자 크기")]
	public float clubStampHintSize; //Field offset: 0x25C
	[FieldOffset(Offset = "0x260")]
	[Range(16, 48)]
	[Token(Token = "0x4000857")]
	[Tooltip("머리줄 도장 아이콘 크기")]
	public float clubStampIconSize; //Field offset: 0x260
	[FieldOffset(Offset = "0x264")]
	[Range(32, 76)]
	[Token(Token = "0x4000858")]
	[Tooltip("도장 한 칸 크기(10칸 × 2줄)")]
	public float clubStampDotSize; //Field offset: 0x264
	[FieldOffset(Offset = "0x268")]
	[Range(4, 30)]
	[Token(Token = "0x4000859")]
	[Tooltip("도장 칸 사이 간격")]
	public float clubStampDotGap; //Field offset: 0x268
	[FieldOffset(Offset = "0x26C")]
	[Range(0.5, 3)]
	[Token(Token = "0x400085A")]
	[Tooltip("도장 찍힐 때 터지는 별 크기 배율(별 하나 = 도장 칸 × 0.34 × 이 값)")]
	public float clubStampStarScale; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Range(0.6, 2.5)]
	[Token(Token = "0x400085B")]
	[Tooltip("로그인 보너스 수령 연출 — 도장 도구 너비(도장 칸 크기의 배수)")]
	public float clubStampToolScale; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Range(0.6, 3)]
	[Token(Token = "0x400085C")]
	[Tooltip("로그인 보너스 수령 연출 — 도장 칸에서 '매일 접속 보상' 아이콘으로 날아가는 돋보기·힌트 크기(도장 칸 크기의 배수)")]
	public float clubBonusFlySize; //Field offset: 0x274
	[FieldOffset(Offset = "0x278")]
	[Range(0, 110)]
	[Token(Token = "0x400085D")]
	[Tooltip("펼쳤을 때 '매일 접속 보상' 띠 높이(0 = 숨김)")]
	public float clubStampRewardHeight; //Field offset: 0x278
	[FieldOffset(Offset = "0x27C")]
	[Range(16, 40)]
	[Token(Token = "0x400085E")]
	[Tooltip("'매일 접속 보상' 띠 글자 크기")]
	public float clubStampRewardFontSize; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Range(16, 48)]
	[Token(Token = "0x400085F")]
	[Tooltip("'매일 접속 보상' 띠 숫자(×2) 글자 크기")]
	public float clubStampRewardCountSize; //Field offset: 0x280
	[FieldOffset(Offset = "0x284")]
	[Range(20, 64)]
	[Token(Token = "0x4000860")]
	[Tooltip("'매일 접속 보상' 띠 아이템 아이콘 크기")]
	public float clubStampRewardIconSize; //Field offset: 0x284
	[FieldOffset(Offset = "0x288")]
	[Range(48, 120)]
	[Token(Token = "0x4000861")]
	[Tooltip("로그인 스탬프 머리줄 높이(접었을 때 영역 높이) — 펼치면 도장 두 줄만큼 더해진다")]
	public float clubStampHeaderHeight; //Field offset: 0x288
	[FieldOffset(Offset = "0x28C")]
	[Range(0, 60)]
	[Token(Token = "0x4000862")]
	[Tooltip("펼쳤을 때 안내 문구 아래 ~ 스탬프 영역 바닥 여백(영역 높이는 도장·문구 크기에 맞춰 자동)")]
	public float clubStampBodyPad; //Field offset: 0x28C
	[FieldOffset(Offset = "0x290")]
	[Range(0, 400)]
	[Token(Token = "0x4000863")]
	[Tooltip("UID 글자를 복사 버튼 앞에서 더 비워 둘 폭 — 클수록 UID가 짧아진다(넘치면 ...)")]
	public float clubUidReserve; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000864")]
	[Tooltip("골드 회원증 엠블럼 워터마크 진하기")]
	public float clubGoldMarkAlpha; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Range(0, 0.4)]
	[Token(Token = "0x4000865")]
	[Tooltip("일반 회원증 햄스터 워터마크 진하기")]
	public float clubBasicMarkAlpha; //Field offset: 0x298
	[FieldOffset(Offset = "0x29C")]
	[Range(-60, 120)]
	[Token(Token = "0x4000866")]
	[Tooltip("페이지 제목(프로필)을 위로 올리는 양(+ = 위로)")]
	public float clubTitleRaise; //Field offset: 0x29C
	[FieldOffset(Offset = "0x2A0")]
	[Range(40, 200)]
	[Token(Token = "0x4000867")]
	[Tooltip("제목 영역 높이 — 작을수록 회원증 카드가 위로 올라온다")]
	public float clubHeaderHeight; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A4")]
	[Range(20, 48)]
	[Token(Token = "0x4000868")]
	[Tooltip("좌우명 목록(드롭다운) 글자 크기")]
	public float clubMottoListFontSize; //Field offset: 0x2A4
	[FieldOffset(Offset = "0x2A8")]
	[Range(48, 120)]
	[Token(Token = "0x4000869")]
	[Tooltip("좌우명 목록 한 줄 높이")]
	public float clubMottoListRowHeight; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Range(12, 40)]
	[Token(Token = "0x400086A")]
	[Tooltip("통계 라벨(연속 클리어 등) 글자 크기")]
	public float clubStatLabelSize; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Range(20, 64)]
	[Token(Token = "0x400086B")]
	[Tooltip("통계 값(1, 3일 등) 글자 크기")]
	public float clubStatValueSize; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Range(30, 100)]
	[Token(Token = "0x400086C")]
	[Tooltip("값 뒤 보조 글자(최고 n, 회) 크기 — 값 대비 %")]
	public float clubStatSubPercent; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Range(16, 56)]
	[Token(Token = "0x400086D")]
	[Tooltip("통계 아이콘 크기")]
	public float clubStatIconSize; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Range(80, 180)]
	[Token(Token = "0x400086E")]
	[Tooltip("통계 타일 높이")]
	public float clubStatTileHeight; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2C0")]
	[Range(160, 480)]
	[Token(Token = "0x400086F")]
	[Tooltip("골드 회원 신청 버튼 폭")]
	public float clubApplyWidth; //Field offset: 0x2C0
	[FieldOffset(Offset = "0x2C4")]
	[Range(40, 110)]
	[Token(Token = "0x4000870")]
	[Tooltip("골드 회원 신청 버튼 높이")]
	public float clubApplyHeight; //Field offset: 0x2C4
	[FieldOffset(Offset = "0x2C8")]
	[Range(16, 44)]
	[Token(Token = "0x4000871")]
	[Tooltip("골드 회원 신청 글자 크기")]
	public float clubApplyFontSize; //Field offset: 0x2C8
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x4000872")]
	[Tooltip("골드 회원 신청 글자 아웃 글로우 색(버튼색보다 살짝 진하게, 알파 0이면 끔)")]
	public Color clubApplyLabelGlow; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2DC")]
	[Token(Token = "0x4000873")]
	[Tooltip("자격 미달 신청 버튼 바탕(베이지) — 눌리는 버튼으로 보이게 배경보다 살짝 진하게")]
	public Color clubApplyLockedFill; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2EC")]
	[Token(Token = "0x4000874")]
	[Tooltip("자격 미달 신청 버튼 테두리 색")]
	public Color clubApplyLockedBorder; //Field offset: 0x2EC
	[FieldOffset(Offset = "0x2FC")]
	[Range(0, 8)]
	[Token(Token = "0x4000875")]
	[Tooltip("자격 미달 신청 버튼 테두리 두께(0이면 없음)")]
	public float clubApplyLockedBorderWidth; //Field offset: 0x2FC
	[FieldOffset(Offset = "0x300")]
	[Token(Token = "0x4000876")]
	[Tooltip("자격 미달 신청 버튼 글자 색")]
	public Color clubApplyLockedText; //Field offset: 0x300
	[FieldOffset(Offset = "0x310")]
	[Range(0, 3)]
	[Token(Token = "0x4000877")]
	[Tooltip("자격 미달 신청 버튼 자물쇠 아이콘 크기(글자 크기 배율, 0이면 없음) — 아이콘 원본에 여백이 있어 글자보다 커야 비슷해 보인다")]
	public float clubApplyLockIconScale; //Field offset: 0x310
	[FieldOffset(Offset = "0x314")]
	[Range(0, 24)]
	[Token(Token = "0x4000878")]
	[Tooltip("자물쇠 아이콘과 글자 사이 간격")]
	public float clubApplyLockGap; //Field offset: 0x314
	[FieldOffset(Offset = "0x318")]
	[Range(0, 80)]
	[Token(Token = "0x4000879")]
	[Tooltip("UID 복사 버튼과 골드 회원 신청 버튼 사이 간격(일반 회원증)")]
	public float clubCopyGap; //Field offset: 0x318
	[FieldOffset(Offset = "0x31C")]
	[Token(Token = "0x400087A")]
	[Tooltip("자격 안내 토스트 둘째 줄(현재 최고 n일 / 목표 n일) 색")]
	public Color clubEligToastSubColor; //Field offset: 0x31C
	[FieldOffset(Offset = "0x32C")]
	[Range(50, 100)]
	[Token(Token = "0x400087B")]
	[Tooltip("자격 안내 토스트 둘째 줄 글자 크기(첫 줄 대비 %)")]
	public float clubEligToastSubPercent; //Field offset: 0x32C
	[FieldOffset(Offset = "0x330")]
	[Range(1.5, 6)]
	[Token(Token = "0x400087C")]
	[Tooltip("자격 안내 토스트 표시 시간(초) — 조건을 읽어야 하므로 2.5~3초")]
	public float clubEligToastSeconds; //Field offset: 0x330
	[FieldOffset(Offset = "0x334")]
	[Range(100, 200)]
	[Token(Token = "0x400087D")]
	[Tooltip("자격 안내 토스트 행간(줄 높이 %, 100이 기본 간격)")]
	public float clubEligToastLineHeight; //Field offset: 0x334
	[FieldOffset(Offset = "0x338")]
	[Range(0, 80)]
	[Token(Token = "0x400087E")]
	[Tooltip("통계 타일과 점선 사이 간격")]
	public float clubDashTopGap; //Field offset: 0x338
	[FieldOffset(Offset = "0x33C")]
	[Range(0, 80)]
	[Token(Token = "0x400087F")]
	[Tooltip("점선과 UID·골드 회원 신청 줄 사이 간격(일반 회원증, 신청 버튼이 있는 줄)")]
	public float clubDashBottomGap; //Field offset: 0x33C
	[FieldOffset(Offset = "0x340")]
	[Range(-30, 80)]
	[Token(Token = "0x4000880")]
	[Tooltip("점선과 UID 줄 사이 간격(골드 회원증 전용, 신청 버튼이 없어 더 좁게. 음수면 더 붙음)")]
	public float clubDashBottomGapGold; //Field offset: 0x340
	[FieldOffset(Offset = "0x344")]
	[Range(0, 80)]
	[Token(Token = "0x4000881")]
	[Tooltip("UID·골드 회원 신청 줄 아래 여백(카드 바닥까지)")]
	public float clubBottomPad; //Field offset: 0x344

	[Token(Token = "0x1400000C")]
	public static event Action Edited
	{
		[Address(RVA = "0x341C528", Offset = "0x341C528", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000444")]
		 add { } //Length: 220
		[Address(RVA = "0x341C604", Offset = "0x341C604", Length = "0xDC")]
		[CompilerGenerated]
		[Token(Token = "0x6000445")]
		 remove { } //Length: 220
	}

	[Token(Token = "0x170000A9")]
	public int AvatarCount
	{
		[Address(RVA = "0x341B5EC", Offset = "0x341B5EC", Length = "0x18")]
		[Token(Token = "0x600042D")]
		 get { } //Length: 24
	}

	[Token(Token = "0x170000AB")]
	public int CostumeCount
	{
		[Address(RVA = "0x341B61C", Offset = "0x341B61C", Length = "0x20")]
		[Token(Token = "0x600042F")]
		 get { } //Length: 32
	}

	[Token(Token = "0x170000AA")]
	public int FrameCount
	{
		[Address(RVA = "0x341B604", Offset = "0x341B604", Length = "0x18")]
		[Token(Token = "0x600042E")]
		 get { } //Length: 24
	}

	[Address(RVA = "0x3420214", Offset = "0x3420214", Length = "0x150")]
	[Token(Token = "0x600045F")]
	private static ProfileConfig() { }

	[Address(RVA = "0x341FBC8", Offset = "0x341FBC8", Length = "0x64C")]
	[Token(Token = "0x600045E")]
	public ProfileConfig() { }

	[Address(RVA = "0x341C528", Offset = "0x341C528", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000444")]
	public static void add_Edited(Action value) { }

	[Address(RVA = "0x341CFCC", Offset = "0x341CFCC", Length = "0x59C")]
	[Token(Token = "0x6000452")]
	public static void AddCrownSparkles(RectTransform frameRt, int count, float sizeFrac, float spreadFrac, int frameId = -1) { }

	[Address(RVA = "0x341F450", Offset = "0x341F450", Length = "0x194")]
	[Token(Token = "0x600045A")]
	public static void ApplyFrameAnchors(RectTransform frameRt, int id, float plateScale = 1) { }

	[Address(RVA = "0x341CF1C", Offset = "0x341CF1C", Length = "0xB0")]
	[Token(Token = "0x6000451")]
	public static TMP_Text AttachWinsBadge(RectTransform frameRt, int frameId, int wins, float fontSizeMin = 6) { }

	[Address(RVA = "0x341EC18", Offset = "0x341EC18", Length = "0x6F4")]
	[Token(Token = "0x6000455")]
	private static Material AuraMaterial(int slot) { }

	[Address(RVA = "0x341C0D4", Offset = "0x341C0D4", Length = "0x48")]
	[Token(Token = "0x600043B")]
	public Sprite Avatar(int id) { }

	[Address(RVA = "0x341BCE8", Offset = "0x341BCE8", Length = "0x194")]
	[Token(Token = "0x6000437")]
	public CostumeFit AvatarCostumeFit(int avatarId, int costumeId) { }

	[Address(RVA = "0x341BF88", Offset = "0x341BF88", Length = "0x14C")]
	[Token(Token = "0x6000439")]
	public CostumeFit AvatarCostumeFit(int avatarId) { }

	[Address(RVA = "0x341FB00", Offset = "0x341FB00", Length = "0xC8")]
	[Token(Token = "0x600045D")]
	public Color Bg(int avatarId) { }

	[Address(RVA = "0x341BC00", Offset = "0x341BC00", Length = "0x3C")]
	[Token(Token = "0x6000434")]
	public int CostumeFitAvatar(int avatarId) { }

	[Address(RVA = "0x341BE7C", Offset = "0x341BE7C", Length = "0xC4")]
	[Token(Token = "0x6000438")]
	public int CostumeFitSetIndex(int costumeId) { }

	[Address(RVA = "0x341BB84", Offset = "0x341BB84", Length = "0x7C")]
	[Token(Token = "0x6000433")]
	public int CostumeIdForSeason(int seasonId) { }

	[Address(RVA = "0x341F690", Offset = "0x341F690", Length = "0x470")]
	[Token(Token = "0x600045C")]
	public static GameObject CreateNewDot(RectTransform parent, Vector2 anchor, Vector2 offset, float scale = 1) { }

	[Address(RVA = "0x341C954", Offset = "0x341C954", Length = "0x308")]
	[Token(Token = "0x600044E")]
	public static TMP_Text CreateWinsBadge(RectTransform frameRt, float fontSizeMin = 6) { }

	[Address(RVA = "0x341C8C4", Offset = "0x341C8C4", Length = "0x90")]
	[Token(Token = "0x600044D")]
	public static Vector2 CrownBadgeCenterFor(int id) { }

	[Address(RVA = "0x341C820", Offset = "0x341C820", Length = "0xA4")]
	[Token(Token = "0x600044C")]
	public static void CrownBadgeColors(int id, out Color number, out Color glow) { }

	[Address(RVA = "0x341D568", Offset = "0x341D568", Length = "0x208")]
	[Token(Token = "0x6000453")]
	public static bool CrownLayout(int id, RectTransform frame, RectTransform plate, RectTransform face) { }

	[Address(RVA = "0x341C4AC", Offset = "0x341C4AC", Length = "0x60")]
	[Token(Token = "0x6000440")]
	public static int CrownSparkleBonus(int id) { }

	[Address(RVA = "0x341C2C8", Offset = "0x341C2C8", Length = "0x64")]
	[Token(Token = "0x6000447")]
	public static float DisplayOuterMatch(int id) { }

	[Address(RVA = "0x341BCB4", Offset = "0x341BCB4", Length = "0x34")]
	[Token(Token = "0x6000436")]
	private int FitFallback(int mapped) { }

	[Address(RVA = "0x341C11C", Offset = "0x341C11C", Length = "0x48")]
	[Token(Token = "0x600043C")]
	public Sprite Frame(int id) { }

	[Address(RVA = "0x341F444", Offset = "0x341F444", Length = "0xC")]
	[Token(Token = "0x6000459")]
	public static bool FrameBgOverride(int id, out Color color) { }

	[Address(RVA = "0x341C32C", Offset = "0x341C32C", Length = "0xA8")]
	[Token(Token = "0x600043E")]
	public static void FrameFit(int id, out float k, out Vector2 center, float plateScale = 1) { }

	[Address(RVA = "0x341B5EC", Offset = "0x341B5EC", Length = "0x18")]
	[Token(Token = "0x600042D")]
	public int get_AvatarCount() { }

	[Address(RVA = "0x341B61C", Offset = "0x341B61C", Length = "0x20")]
	[Token(Token = "0x600042F")]
	public int get_CostumeCount() { }

	[Address(RVA = "0x341B604", Offset = "0x341B604", Length = "0x18")]
	[Token(Token = "0x600042E")]
	public int get_FrameCount() { }

	[Address(RVA = "0x341C6E0", Offset = "0x341C6E0", Length = "0x7C")]
	[Token(Token = "0x6000448")]
	public static float GridOuterMatch(int id) { }

	[Address(RVA = "0x341BF40", Offset = "0x341BF40", Length = "0x48")]
	[Token(Token = "0x600043A")]
	private bool HasOwnCommonFit(int id) { }

	[Address(RVA = "0x341C51C", Offset = "0x341C51C", Length = "0xC")]
	[Token(Token = "0x6000443")]
	public static bool IsAvatarHidden(int id) { }

	[Address(RVA = "0x341BC3C", Offset = "0x341BC3C", Length = "0x34")]
	[Token(Token = "0x6000446")]
	public bool IsClubAvatar(int id) { }

	[Address(RVA = "0x341C75C", Offset = "0x341C75C", Length = "0x84")]
	[Token(Token = "0x600044A")]
	public static bool IsClubFrame(int id) { }

	[Address(RVA = "0x341BB20", Offset = "0x341BB20", Length = "0x64")]
	[Token(Token = "0x6000432")]
	public bool IsCostumeEnabled(int id) { }

	[Address(RVA = "0x341C200", Offset = "0x341C200", Length = "0xC8")]
	[Token(Token = "0x6000441")]
	public static bool IsCrownFrame(int id) { }

	[Address(RVA = "0x341C50C", Offset = "0x341C50C", Length = "0x10")]
	[Token(Token = "0x6000442")]
	public static bool IsFrameHidden(int id) { }

	[Address(RVA = "0x341C3EC", Offset = "0x341C3EC", Length = "0xC0")]
	[Token(Token = "0x600043F")]
	public static int LegendTier(int id) { }

	[Address(RVA = "0x341B440", Offset = "0x341B440", Length = "0x1AC")]
	[Token(Token = "0x600042C")]
	public static ProfileConfig Load() { }

	[Address(RVA = "0x341BC70", Offset = "0x341BC70", Length = "0x44")]
	[Token(Token = "0x6000435")]
	public bool MirrorsCostumeFit(int avatarId) { }

	[Address(RVA = "0x341F5E4", Offset = "0x341F5E4", Length = "0xAC")]
	[Token(Token = "0x600045B")]
	public static Vector2 NewDotCorner(int frameId) { }

	[Address(RVA = "0x341C3D4", Offset = "0x341C3D4", Length = "0x18")]
	[Token(Token = "0x6000449")]
	public static float OpeningOf(int id) { }

	[Address(RVA = "0x341BA8C", Offset = "0x341BA8C", Length = "0x94")]
	[Token(Token = "0x6000431")]
	private static CostumeSource ParseSource(string s) { }

	[Address(RVA = "0x341EBDC", Offset = "0x341EBDC", Length = "0x3C")]
	[Token(Token = "0x6000454")]
	private static float PickTier(float[] arr, int idx, float fallback) { }

	[Address(RVA = "0x341CC5C", Offset = "0x341CC5C", Length = "0x174")]
	[Token(Token = "0x600044F")]
	public static void PlaceWinsBadge(TMP_Text label, int frameId) { }

	[Address(RVA = "0x341C164", Offset = "0x341C164", Length = "0x9C")]
	[Token(Token = "0x600043D")]
	public static float PlateOpeningInsetFrac(int frameId) { }

	[Address(RVA = "0x341C604", Offset = "0x341C604", Length = "0xDC")]
	[CompilerGenerated]
	[Token(Token = "0x6000445")]
	public static void remove_Edited(Action value) { }

	[Address(RVA = "0x341E93C", Offset = "0x341E93C", Length = "0x168")]
	[Token(Token = "0x6000457")]
	private static void RestoreRoundedPlate(RectTransform plate) { }

	[Address(RVA = "0x341EAA4", Offset = "0x341EAA4", Length = "0x138")]
	[Token(Token = "0x6000458")]
	private static void SetBox(RectTransform rt, Vector2 c, float k) { }

	[Address(RVA = "0x341C7E0", Offset = "0x341C7E0", Length = "0x40")]
	[Token(Token = "0x600044B")]
	public int SkinForAvatar(int avatarId) { }

	[Address(RVA = "0x341CDD0", Offset = "0x341CDD0", Length = "0x14C")]
	[Token(Token = "0x6000450")]
	public static void StyleWinsBadge(TMP_Text label, int frameId, int wins) { }

	[Address(RVA = "0x341D770", Offset = "0x341D770", Length = "0x11CC")]
	[Token(Token = "0x6000456")]
	public static void SyncCrownAura(int id, RectTransform frame) { }

	[Address(RVA = "0x341B63C", Offset = "0x341B63C", Length = "0x450")]
	[Token(Token = "0x6000430")]
	public bool TryGetCostume(int id, out Costume c) { }

}

