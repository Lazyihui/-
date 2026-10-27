namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "DailySeasonConfig", menuName = "Hamdoku/Daily Season Config")]
[Token(Token = "0x2000033")]
public sealed class DailySeasonConfig : ScriptableObject
{
	[Token(Token = "0x2000038")]
	public struct LobbyBuddy
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x40003F0")]
		[Tooltip("유령 발밑(가운데 아래) 기준 위치(px, +오른쪽/+위)")]
		public Vector2 offset; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x40003F1")]
		[Tooltip("가로 폭(px)")]
		public float size; //Field offset: 0x8
		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x40003F2")]
		public bool flipX; //Field offset: 0xC

	}

	[Token(Token = "0x2000036")]
	public class LobbyDecorStyle
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003D8")]
		[Tooltip("아트웍 폴더 키(Costumes 시트 artwork 열, 예 bakery)")]
		public string folder; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40003D9")]
		[Tooltip("붙는 자리(데일리 버튼 칸 대비 비율, 1,1 = 오른쪽 위)·미세 이동(px)·높이(px)·좌우 반전")]
		public Vector2 anchor; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40003DA")]
		public Vector2 offset; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x40003DB")]
		public float height; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x40003DC")]
		public bool flipX; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Range(0, 30)]
		[Token(Token = "0x40003DD")]
		[Tooltip("발밑 기준 좌우 기울기(도)·한쪽으로 기우는 시간(초). 0이면 없음")]
		public float sway; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x40003DE")]
		public float swayDuration; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40003DF")]
		[Tooltip("위아래 둥실(px)·좌우로 떠다니기(px) — 땅에 붙은 캐릭터는 0")]
		public float bob; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x40003E0")]
		public float drift; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40003E1")]
		[Tooltip("들썩들썩(빵 먹기, 2026-10-21) — 짧게 몇 번 들썩였다 쉬기를 반복. 횟수·한 번 시간(초)·쉬는 시간(초)·세로 눌림(0.05=5%)·들썩 높이(px). 횟수 0이면 없음")]
		public int munchCount; //Field offset: 0x40
		[FieldOffset(Offset = "0x44")]
		[Token(Token = "0x40003E2")]
		public float munchDuration; //Field offset: 0x44
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x40003E3")]
		public float munchPause; //Field offset: 0x48
		[FieldOffset(Offset = "0x4C")]
		[Range(0, 0.2)]
		[Token(Token = "0x40003E4")]
		public float munchSquash; //Field offset: 0x4C
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x40003E5")]
		public float munchHop; //Field offset: 0x50

		[Address(RVA = "0x33ECE60", Offset = "0x33ECE60", Length = "0x30")]
		[Token(Token = "0x60001B5")]
		public LobbyDecorStyle() { }

	}

	[Token(Token = "0x2000037")]
	public class LobbyPasser
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003E6")]
		[Tooltip("아트웍 폴더 키 — 그림 Resources/UI/DailySeason/SeasonLobbyPass_{폴더 키}")]
		public string folder; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40003E7")]
		[Tooltip("크기(px, 긴 변)")]
		public float size; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40003E8")]
		[Tooltip("출발·도착(장식 캐릭터 발밑 기준 px, +오른쪽/+위)·물결 폭(px, 경로 가운데에서 위아래로 출렁)")]
		public Vector2 from; //Field offset: 0x1C
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x40003E9")]
		public Vector2 to; //Field offset: 0x24
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x40003EA")]
		public float wave; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40003EB")]
		[Tooltip("한 번 지나가는 시간(초)·다음까지 쉬는 시간(초)·지나가며 도는 각도(도, +반시계)")]
		public float duration; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x40003EC")]
		public float interval; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x40003ED")]
		public float spin; //Field offset: 0x38
		[FieldOffset(Offset = "0x3C")]
		[Token(Token = "0x40003EE")]
		[Tooltip("살랑 낙하(2026-10-21) — 한 번 떨어지는 시간(초, 매번 0.8~1.25배)·쉬는 시간(초, 매번 0.5~1.5배). 0이면 기본 5초·8초. 이 값이 있으면 위 duration·interval·spin(옛 '휘잉' 직선)은 쓰지 않는다")]
		public float fallTime; //Field offset: 0x3C
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x40003EF")]
		public float pause; //Field offset: 0x40

		[Address(RVA = "0x33ECE90", Offset = "0x33ECE90", Length = "0x34")]
		[Token(Token = "0x60001B6")]
		public LobbyPasser() { }

	}

	[Token(Token = "0x2000034")]
	public enum PopupCharEnter : int
	{
		FlyFromSide = 0,
		PopUp = 1,
		Hop = 2,
	}

	[Token(Token = "0x2000035")]
	public class PopupCharStyle
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003CF")]
		[Tooltip("아트웍 폴더 키(Costumes 시트 artwork 열, 예 bakery)")]
		public string folder; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Range(0.3, 1.2)]
		[Token(Token = "0x40003D0")]
		[Tooltip("캐릭터 높이 배율(1 = 기본, 액자 높이의 78%). 발 위치는 그대로 두고 줄인다")]
		public float heightScale; //Field offset: 0x18
		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40003D1")]
		[Tooltip("등장 — FlyFromSide = 옆에서 기울어 날아옴(popupCharEnterOffset), PopUp = 제자리에서 작게 시작해 톡 커짐, Hop = 제자리에 나타나며 한 번 폴짝(hopHeight)")]
		public PopupCharEnter enter; //Field offset: 0x1C
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40003D2")]
		[Tooltip("Hop 등장 높이(px, 팝업 배치 좌표) — 5·18px은 화면에서 거의 안 움직여 '제자리에서 늘었다 줄어드는' 것으로 보였다(10-21). 약한 웅크림·착지 눌림이 같이 붙는다")]
		public float hopHeight; //Field offset: 0x20
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x40003D3")]
		[Tooltip("살랑 기울기 — 발밑을 축으로 좌우로 천천히 기울이기(이동 없음). 각도(도)·한쪽 끝까지 가는 시간(초)")]
		public bool tilt; //Field offset: 0x24
		[FieldOffset(Offset = "0x28")]
		[Range(0, 6)]
		[Token(Token = "0x40003D4")]
		public float tiltAngle; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x40003D5")]
		public float tiltDuration; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x40003D6")]
		[Tooltip("좌우 살랑(떠다니며 기울기) — popupCharDrift")]
		public bool drift; //Field offset: 0x30
		[FieldOffset(Offset = "0x31")]
		[Token(Token = "0x40003D7")]
		[Tooltip("위아래 둥실 — popupCharFloat")]
		public bool floating; //Field offset: 0x31

		[Address(RVA = "0x33ECE34", Offset = "0x33ECE34", Length = "0x2C")]
		[Token(Token = "0x60001B4")]
		public PopupCharStyle() { }

	}

	[Token(Token = "0x40003CA")]
	private static DailySeasonConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("자동 배치 — 화면 높이에 맞춰 위(제목)·아래(시작 버튼)를 고정하고 두 카드가 사이를 채운다(시안 비율). 카드 폭 = 1080 - 좌우 여백×2")]
	[Token(Token = "0x40001FE")]
	public float sideMargin; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(0.5, 1)]
	[Token(Token = "0x40001FF")]
	[Tooltip("와이드 화면(가로세로비 0.65 이상: 태블릿·폴드 펼침)에서 페이지 전체를 이 배율까지 줄인다. 공용 기본 0.8")]
	public float wideScale; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000200")]
	[Tooltip("세이프에어리어 위 변 → 제목 중심")]
	public float topInset; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000201")]
	public float titleTimerGap; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000202")]
	[Tooltip("남은 시간 → 퍼즐 카드 위 변")]
	public float timerCardGap; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000203")]
	[Tooltip("퍼즐 카드 아래 변 → 도장판 카드 위 변")]
	public float cardGap; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000204")]
	[Tooltip("세이프에어리어 아래 변 → 시작 버튼 아래 변")]
	public float startBottomInset; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000205")]
	[Tooltip("와이드 화면(태블릿·폴드 펼침)에서만 쓰는 값 — 세로가 짧아 세로 폰 값으론 버튼 아래 여백이 사라진다(폴드 10-15). 카드들은 그만큼 위로 올라간다")]
	public float startBottomInsetWide; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000206")]
	[Tooltip("시작 버튼 위 변 → 날짜 줄 중심")]
	public float dateLabelGap; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000207")]
	[Tooltip("날짜 줄 → 도장판 카드 아래 변")]
	public float dateCardGap; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000208")]
	[Tooltip("달력 셀 목표 지름 — 도장판이 이 크기의 5줄을 담도록 먼저 높이를 확보하고, 모자라면 퍼즐 창을 줄인다(puzzleMinArtW까지)")]
	public float cellTargetSize; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000209")]
	[Tooltip("퍼즐 창 최소 폭 — 도장판에 높이를 양보할 때 이보다 좁히지 않는다")]
	public float puzzleMinArtW; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400020A")]
	[Tooltip("도장판 카드 최소 높이(아주 짧은 화면 보호)")]
	public float stampMinH; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Header("상단 — 제목·남은 시간")]
	[Token(Token = "0x400020B")]
	public float titleFontSize; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400020C")]
	public Color titleColor; //Field offset: 0x50
	[FieldOffset(Offset = "0x60")]
	[Range(0, 0.5)]
	[Token(Token = "0x400020D")]
	[Tooltip("제목·남은 시간 글자의 흰 아웃라인 두께(SDF 0~1, 0=없음)")]
	public float titleOutlineWidth; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Range(0, 0.5)]
	[Token(Token = "0x400020E")]
	public float timerOutlineWidth; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400020F")]
	[Tooltip("제목 왼쪽 아이콘(UI/DailySeason/IcoTitle) 크기. 0이면 없음(기본). 에셋도 있어야 붙는다")]
	public float titleIconSize; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000210")]
	public float titleIconGap; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000211")]
	public float timerFontSize; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000212")]
	[Tooltip("남은 시간 글자색(캡슐 없음, 시안 핑크레드) — 설명 글(보상 조건 등)에도 timerText 계열을 쓰는 곳은 timerSubText")]
	public Color timerText; //Field offset: 0x74
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000213")]
	public Color timerSubText; //Field offset: 0x84
	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000214")]
	[Tooltip("남은 시간 왼쪽 시계 아이콘(UI/DailySeason/IcoClock) 크기·간격")]
	public float timerIconSize; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000215")]
	public float timerIconGap; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Header("카드 공통 — 몸체는 기존 공용 라운드 판 UI/PopupPanelInner(파스텔 v3, 외곽선 없음). 전용 에셋 UI/DailySeason/CardPlain이 있으면 그쪽, 둘 다 없으면 코드")]
	[Range(0.2, 3)]
	[Token(Token = "0x4000216")]
	[Tooltip("PopupPanelInner 배율. 작을수록 모서리가 둥글다(반경 = 28/ppum)")]
	public float cardPpum; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Range(0, 1)]
	[Token(Token = "0x4000217")]
	[Tooltip("소프트 드롭 섀도 — 알파 0이면 없음")]
	public float cardShadowAlpha; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000218")]
	public float cardShadowSpread; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000219")]
	public float cardShadowOffsetY; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x400021A")]
	public Color cardShadowColor; //Field offset: 0xAC
	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x400021B")]
	[Tooltip("코드 폴백용 — 모서리 반경·외곽선 두께(0=없음)")]
	public float cardCornerRadius; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400021C")]
	public float cardOutlineW; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Range(1, 3)]
	[Token(Token = "0x400021D")]
	[Tooltip("아래 변 외곽선 배율(살짝 두껍게 — 종이 카드 느낌)")]
	public float cardOutlineBottomMul; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400021E")]
	public Color cardOutline; //Field offset: 0xC8
	[FieldOffset(Offset = "0xD8")]
	[Header("퍼즐 카드 — [제목 줄] [창(5:3)] [구분선] [보상 줄]. 창은 라운드 Mask + 코드 링, 구분선은 코드")]
	[Token(Token = "0x400021F")]
	public Color puzzleCardColor; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000220")]
	[Tooltip("제목 줄 높이(발바닥·아트웍 이름·조각 수 자리)")]
	public float puzzleTitleRowH; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4000221")]
	[Tooltip("보상 줄 높이(액자·코스튬 이름·보상 버튼 자리)")]
	public float puzzleRewardRowH; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000222")]
	[Tooltip("창 좌우 최소 여백(카드 변 → 창). 도장판에 높이를 양보하면 창이 더 좁아져 여백이 늘어난다")]
	public float puzzleSidePad; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000223")]
	[Tooltip("제목 줄 → 창, 창 → 구분선 사이 간격")]
	public float puzzleWindowGap; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000224")]
	[Tooltip("창 모서리 반경(Mask·링 공통)과 링 두께(0=링 없음, 파스텔 v3 기본)")]
	public float windowCornerRadius; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4000225")]
	public float windowOutlineW; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000226")]
	public float dividerH; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000227")]
	[Tooltip("구분선 좌우 여백(카드 변 → 선 끝)")]
	public float dividerInset; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4000228")]
	public Color dividerColor; //Field offset: 0x108
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4000229")]
	[Tooltip("구분선 y = 보상 줄 위 변 + 이 값(음수=아래). 에셋 창 테두리와 겹치지 않게 띄운다")]
	public float dividerOffsetY; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Range(0.5, 4)]
	[Token(Token = "0x400022A")]
	[Tooltip("전용 에셋 CardPlain(파스텔 v3 패널, 주황 가는 선) 배율. 작을수록 선이 굵고 모서리가 둥글다")]
	public float puzzleCardPpum; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x400022B")]
	[Tooltip("아트웍 비율(가로/세로). 5×3 조각이라 5:3")]
	public float artAspect; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x400022C")]
	public int pieceCols; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x400022D")]
	public int pieceRows; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x400022E")]
	public float pieceGap; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x400022F")]
	public Color pieceEdge; //Field offset: 0x130
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000230")]
	[Tooltip("반 조각 표현: 켜면 '흐린 모노톤 → 선명한 그림 + 아주 옅은 색'(piece_NN_half 스프라이트)으로 바뀐다. 끄면 좌→우 그라데이션 방식")]
	public bool halfSharpen; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Range(0, 1.2)]
	[Token(Token = "0x4000231")]
	[Tooltip("(그라데이션 방식) 반 조각의 열린/잠긴 경계 그라데이션 폭 — 조각 폭 대비(0=칼같이 반반)")]
	public float halfFadeFrac; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x4000232")]
	[Tooltip("반 조각이 열릴 때 걸리는 시간 — 선명해지는 크로스페이드(halfSharpen) 또는 그라데이션 경계 이동(0=즉시)")]
	public float halfSweepDuration; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x4000233")]
	[Tooltip("직소 절단선 오버레이(Resources/DailySeason/Jigsaw/lines, 흰 1도 에셋) 틴트. 알파 0이면 숨김")]
	public Color jigsawLineTint; //Field offset: 0x14C
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x4000234")]
	[Tooltip("잠긴 조각의 아트웍 틴트(흑백 셰이더 대신 어둡고 탁하게)")]
	public Color lockedTint; //Field offset: 0x15C
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x4000235")]
	[Tooltip("잠긴 조각 위에 덮는 크림 베일")]
	public Color lockedVeil; //Field offset: 0x16C
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x4000236")]
	[Tooltip("아트웍이 없을 때 조각 바탕색(획득/잠김)")]
	public Color placeholderOpen; //Field offset: 0x17C
	[FieldOffset(Offset = "0x18C")]
	[Token(Token = "0x4000237")]
	public Color placeholderLocked; //Field offset: 0x18C
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x4000238")]
	[Tooltip("열린 조각 수(앞 숫자) 크기·색. 뒤의 \"/ 15\"는 piecesTotalFontSize·제목색")]
	public float piecesCountFontSize; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x4000239")]
	public Color piecesCountColor; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x400023A")]
	public float piecesTotalFontSize; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B4")]
	[Header("퍼즐 카드 제목 줄 — 연노랑 칩 띠(랭킹 화단 말풍선 칩과 같은 코드 드로잉) 위에 [발바닥] 아트웍 이름 [발바닥] … 조각 수")]
	[Token(Token = "0x400023B")]
	[Tooltip("제목 줄 뒤 색 띠(둥근 칩). 알파 0이면 없음")]
	public Color puzzleTitleBandColor; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x400023C")]
	[Tooltip("카드 위 변 → 띠 위 변 여백")]
	public float puzzleTitleTopPad; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x400023D")]
	[Tooltip("띠 높이. 0이면 제목 줄 높이 - 위 여백 - 10")]
	public float puzzleTitleBandH; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x400023E")]
	[Tooltip("띠 좌우를 창보다 안쪽으로 줄이는 폭")]
	public float puzzleTitleBandInset; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x400023F")]
	public float puzzleTitleFontSize; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Token(Token = "0x4000240")]
	[Tooltip("제목 줄 y 보정(+위). 기본은 제목 줄 가운데")]
	public float puzzleTitleOffsetY; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x4000241")]
	[Tooltip("양옆 발바닥 아이콘(UI/DailySeason/IcoPaw) 크기·간격. 에셋이 없으면 생략")]
	public float puzzleTitleIconSize; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x4000242")]
	public float puzzleTitleIconGap; //Field offset: 0x1DC
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x4000243")]
	[Tooltip("발바닥 색(에셋이 없을 때 코드로 그리는 폴백에도 적용)")]
	public Color puzzleTitleIconColor; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1F0")]
	[Header("퍼즐 카드 보상 줄 — [액자+한정 태그] 코스튬 이름/조건 [보상 버튼]")]
	[Token(Token = "0x4000244")]
	public float costumeNameFontSize; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Token(Token = "0x4000245")]
	public Color costumeNameColor; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x4000246")]
	public float costumeCondFontSize; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x4000247")]
	[Tooltip("보상 받기·수령 완료 상태의 이름 두 줄 배치 — 한정 태그 위치(+위), 코스튬 이름 위치(+위)·크기 배율·색(진갈색)")]
	public float rewardStackTagDy; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x4000248")]
	public float rewardStackNameDy; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x4000249")]
	public float rewardStackNameIndent; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Token(Token = "0x400024A")]
	public float rewardStackNameScale; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x400024B")]
	public Color costumeNameStackColor; //Field offset: 0x218
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x400024C")]
	public float limitedTagFontSize; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Header("코스튬 진행 게이지 — 못 받는 동안 [이름 줄 ··· N/15] / 막대 / 안내")]
	[Token(Token = "0x400024D")]
	public float gaugeH; //Field offset: 0x22C
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x400024E")]
	public Color gaugeTrackColor; //Field offset: 0x230
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x400024F")]
	public Color gaugeFillColor; //Field offset: 0x240
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x4000250")]
	public float gaugeCountFontSize; //Field offset: 0x250
	[FieldOffset(Offset = "0x254")]
	[Token(Token = "0x4000251")]
	[Tooltip("이름 줄 오른쪽 끝 'N / 10' 숫자 자리 폭 — 코스튬 이름은 이 폭을 비우고 자동 축소된다(이탈리아어 등 긴 이름이 숫자와 겹치던 문제)")]
	public float gaugeCountReserve; //Field offset: 0x254
	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x4000252")]
	[Tooltip("진행 숫자 'N / 15'에서 현재 개수 N만 키우는 배율과 색(유저 10-13: 타이틀 줄 숫자를 없애고 여기서 강조)")]
	public float gaugeCountBigScale; //Field offset: 0x258
	[FieldOffset(Offset = "0x25C")]
	[Token(Token = "0x4000253")]
	public Color gaugeCountBigColor; //Field offset: 0x25C
	[FieldOffset(Offset = "0x26C")]
	[Token(Token = "0x4000254")]
	[Tooltip("조각 연출 중 게이지가 차오르는 트윈 시간(초). 0이면 즉시")]
	public float gaugeFillTween; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Token(Token = "0x4000255")]
	[Tooltip("게이지가 다 찬 뒤 보상 받기 버튼으로 바뀌기까지 여유(초)")]
	public float gaugeClaimDelay; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Token(Token = "0x4000256")]
	[Tooltip("보상 줄 가운데 기준 세로 위치(+위) — 이름 줄·막대·안내 문구")]
	public float gaugeNameDy; //Field offset: 0x274
	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x4000257")]
	public float gaugeBarDy; //Field offset: 0x278
	[FieldOffset(Offset = "0x27C")]
	[Token(Token = "0x4000258")]
	public float gaugeCondDy; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x4000259")]
	public Color limitedTagColor; //Field offset: 0x280
	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x400025A")]
	[Tooltip("\"N월 한정\" 태그 — 에셋 UI/DailySeason/TagLimited(핑크 캡슐, 9-slice)가 있으면 그걸 쓰고 위 색은 폴백. 높이(0=글자×1.6)·글자 글로우")]
	public float limitedTagH; //Field offset: 0x290
	[FieldOffset(Offset = "0x294")]
	[Token(Token = "0x400025B")]
	[Tooltip("이름 줄의 \"N월 한정\" 뱃지 세로 보정(+위)")]
	public float limitedTagOffsetY; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x400025C")]
	public Color limitedTagGlow; //Field offset: 0x298
	[FieldOffset(Offset = "0x2A8")]
	[Token(Token = "0x400025D")]
	[Tooltip("보상 줄 안 [액자][조각 수][보상 버튼]의 y 보정(+위)")]
	public float bandRowOffsetY; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Header("코스튬 캐러셀(한 시즌 2종 이상일 때만)")]
	[Token(Token = "0x400025E")]
	[Tooltip("왼쪽 선택 영역 [‹ 코스튬 ›] — 꺾쇠 크기·코스튬 액자와의 간격·y 미세 조정")]
	public float costumeArrowSize; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Token(Token = "0x400025F")]
	public float costumeArrowGap; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Token(Token = "0x4000260")]
	public float costumeArrowDy; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x4000261")]
	public Color costumeArrowColor; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2C8")]
	[Token(Token = "0x4000262")]
	[Tooltip("선택 영역 오른쪽 끝과 정보(이름·진행 막대) 사이 간격")]
	public float costumeInfoGap; //Field offset: 0x2C8
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x4000263")]
	[Tooltip("선택 영역 전체를 위로 올리는 양(점 자리 확보)")]
	public float costumeMultiRowDy; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x4000264")]
	[Tooltip("캐러셀일 때 액자·꺾쇠·숫자 원만 더 위로 올리는 양(이름·수령 버튼은 그대로) — 숫자 원 자리 확보(2026-10-19)")]
	public float costumeFrameLift; //Field offset: 0x2D0
	[FieldOffset(Offset = "0x2D4")]
	[Token(Token = "0x4000265")]
	[Tooltip("페이지 점 — 액자 아래와의 간격·지름·점 간격·선택 점 가로 배율(알약)·선택/비선택 색")]
	public float costumeDotGapY; //Field offset: 0x2D4
	[FieldOffset(Offset = "0x2D8")]
	[Token(Token = "0x4000266")]
	public float costumeDotSize; //Field offset: 0x2D8
	[FieldOffset(Offset = "0x2DC")]
	[Token(Token = "0x4000267")]
	public float costumeDotGap; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2E0")]
	[Range(1, 4)]
	[Token(Token = "0x4000268")]
	public float costumeDotOnWidth; //Field offset: 0x2E0
	[FieldOffset(Offset = "0x2E4")]
	[Token(Token = "0x4000269")]
	public Color costumeDotOn; //Field offset: 0x2E4
	[FieldOffset(Offset = "0x2F4")]
	[Token(Token = "0x400026A")]
	public Color costumeDotOff; //Field offset: 0x2F4
	[FieldOffset(Offset = "0x304")]
	[Token(Token = "0x400026B")]
	[Tooltip("코스튬 페이지 표시 — 켜면 점 대신 숫자 원(1·2·3, 유저 시안 10-19: 몇 종인지와 순서를 함께). 숫자를 누르면 그 코스튬으로 넘어간다")]
	public bool costumeNumbered; //Field offset: 0x304
	[FieldOffset(Offset = "0x308")]
	[Token(Token = "0x400026C")]
	[Tooltip("숫자 원 지름(px)·간격(px)·글자 크기(지름 대비)")]
	public float costumeNumSize; //Field offset: 0x308
	[FieldOffset(Offset = "0x30C")]
	[Token(Token = "0x400026D")]
	public float costumeNumGap; //Field offset: 0x30C
	[FieldOffset(Offset = "0x310")]
	[Range(0.3, 0.9)]
	[Token(Token = "0x400026E")]
	public float costumeNumFont; //Field offset: 0x310
	[FieldOffset(Offset = "0x314")]
	[Token(Token = "0x400026F")]
	[Tooltip("숫자 원 색 — 고른 것(면·글자) / 나머지(면·글자)")]
	public Color costumeNumOn; //Field offset: 0x314
	[FieldOffset(Offset = "0x324")]
	[Token(Token = "0x4000270")]
	public Color costumeNumOnText; //Field offset: 0x324
	[FieldOffset(Offset = "0x334")]
	[Token(Token = "0x4000271")]
	public Color costumeNumOff; //Field offset: 0x334
	[FieldOffset(Offset = "0x344")]
	[Token(Token = "0x4000272")]
	public Color costumeNumOffText; //Field offset: 0x344
	[FieldOffset(Offset = "0x354")]
	[Token(Token = "0x4000273")]
	[Tooltip("페이지 넘길 때 미끄러지는 거리(px)·시간(초)")]
	public float costumePageSlide; //Field offset: 0x354
	[FieldOffset(Offset = "0x358")]
	[Token(Token = "0x4000274")]
	public float costumePageDuration; //Field offset: 0x358
	[FieldOffset(Offset = "0x35C")]
	[Range(0.3, 1)]
	[Token(Token = "0x4000275")]
	[Tooltip("'N월 한정' 뱃지 최대 폭 — 코스튬 정보 영역 폭 대비 배율. 넘치면 글자가 줄어든다")]
	public float limitedTagMaxWidth; //Field offset: 0x35C
	[FieldOffset(Offset = "0x360")]
	[Token(Token = "0x4000276")]
	public float costumeFrameSize; //Field offset: 0x360
	[FieldOffset(Offset = "0x364")]
	[Range(0, 0.3)]
	[Token(Token = "0x4000277")]
	[Tooltip("액자 에셋(CostumeFrame) 링 두께 비율(액자 한 변 대비) — 안쪽 면·아바타 여백 계산용. 안쪽 면 색")]
	public float costumeFrameRing; //Field offset: 0x364
	[FieldOffset(Offset = "0x368")]
	[Token(Token = "0x4000278")]
	public Color costumeFrameInnerColor; //Field offset: 0x368
	[FieldOffset(Offset = "0x378")]
	[Range(0.5, 1.2)]
	[Token(Token = "0x4000279")]
	[Tooltip("코스튬 선택 액자 속 햄스터+코스튬 배율. 모자가 잘리면 줄인다(2026-10-15)")]
	public float costumeFrameAvatarScale; //Field offset: 0x378
	[FieldOffset(Offset = "0x37C")]
	[Range(-0.3, 0.3)]
	[Token(Token = "0x400027A")]
	[Tooltip("액자 속 햄스터 세로 이동(액자 크기 비율, 음수=아래). 모자 자리를 만든다")]
	public float costumeFrameAvatarDy; //Field offset: 0x37C
	[FieldOffset(Offset = "0x380")]
	[Token(Token = "0x400027B")]
	public Vector2 claimBtnSize; //Field offset: 0x380
	[FieldOffset(Offset = "0x388")]
	[Token(Token = "0x400027C")]
	public float claimFontSize; //Field offset: 0x388
	[FieldOffset(Offset = "0x38C")]
	[Token(Token = "0x400027D")]
	[Tooltip("보상 버튼 = 연한 코랄 핑크 평면 알약(코드) + 흰 1도 선 선물 아이콘. 끄면 BtnReward 에셋")]
	public bool claimFlatPill; //Field offset: 0x38C
	[FieldOffset(Offset = "0x390")]
	[Token(Token = "0x400027E")]
	public Color claimPillColor; //Field offset: 0x390
	[FieldOffset(Offset = "0x3A0")]
	[Token(Token = "0x400027F")]
	public Color claimPillEdge; //Field offset: 0x3A0
	[FieldOffset(Offset = "0x3B0")]
	[Token(Token = "0x4000280")]
	public float claimPillEdgeW; //Field offset: 0x3B0
	[FieldOffset(Offset = "0x3B4")]
	[Token(Token = "0x4000281")]
	[Tooltip("보상 받기 알약 아래 립 두께(눌리는 버튼 느낌, 테두리보다 아래만 두껍게)")]
	public float claimPillLipH; //Field offset: 0x3B4
	[FieldOffset(Offset = "0x3B8")]
	[Token(Token = "0x4000282")]
	[Tooltip("받은 달 버튼 — 베이지 면·연갈색 테두리·갈색 [체크 원] 수령 완료")]
	public Color claimedPillColor; //Field offset: 0x3B8
	[FieldOffset(Offset = "0x3C8")]
	[Token(Token = "0x4000283")]
	public Color claimedPillEdge; //Field offset: 0x3C8
	[FieldOffset(Offset = "0x3D8")]
	[Token(Token = "0x4000284")]
	public Color claimedLabel; //Field offset: 0x3D8
	[FieldOffset(Offset = "0x3E8")]
	[Range(0.3, 1.2)]
	[Token(Token = "0x4000285")]
	[Tooltip("보상 버튼 선물 아이콘(UI/DailySeason/IcoGift) 크기(버튼 높이 대비)·글자와 간격")]
	public float claimGiftScale; //Field offset: 0x3E8
	[FieldOffset(Offset = "0x3EC")]
	[Token(Token = "0x4000286")]
	public float claimGiftGap; //Field offset: 0x3EC
	[FieldOffset(Offset = "0x3F0")]
	[Token(Token = "0x4000287")]
	[Tooltip("보상 버튼 글자 최소 크기 — 긴 언어(報酬を受け取る 등)가 좁은 버튼에서 넘치지 않게 이 크기까지 줄어든다")]
	public float claimFontMin; //Field offset: 0x3F0
	[FieldOffset(Offset = "0x3F4")]
	[Token(Token = "0x4000288")]
	[Tooltip("보상 버튼 좌우 안쪽 여백 — 글자는 이 안에서 자동 축소")]
	public float claimTextPadX; //Field offset: 0x3F4
	[FieldOffset(Offset = "0x3F8")]
	[Range(0.2, 1)]
	[Token(Token = "0x4000289")]
	public float claimGiftScaleFlat; //Field offset: 0x3F8
	[FieldOffset(Offset = "0x3FC")]
	[Token(Token = "0x400028A")]
	[Tooltip("이달의 코스튬 액자 뒤 발광 — 색(알파 = 최대 밝기, 0이면 끔)·번짐 폭(액자 대비)·숨쉬기 반주기(초)·받기 상태에서만 켤지")]
	public Color frameGlowColor; //Field offset: 0x3FC
	[FieldOffset(Offset = "0x40C")]
	[Token(Token = "0x400028B")]
	public float frameGlowSpread; //Field offset: 0x40C
	[FieldOffset(Offset = "0x410")]
	[Token(Token = "0x400028C")]
	public float frameGlowPulse; //Field offset: 0x410
	[FieldOffset(Offset = "0x414")]
	[Token(Token = "0x400028D")]
	public bool frameGlowOnlyWhenReady; //Field offset: 0x414
	[FieldOffset(Offset = "0x418")]
	[Token(Token = "0x400028E")]
	[Tooltip("보상 받기 상태의 선물 상자 흔들기 — 각도(0 = 끔)·한 번 꺾는 시간·멈춤 시간(흔들흔들 멈췄다 반복, 유저 10-13)")]
	public float claimGiftWiggleAngle; //Field offset: 0x418
	[FieldOffset(Offset = "0x41C")]
	[Token(Token = "0x400028F")]
	public float claimGiftWiggleStep; //Field offset: 0x41C
	[FieldOffset(Offset = "0x420")]
	[Token(Token = "0x4000290")]
	public float claimGiftWiggleRest; //Field offset: 0x420
	[FieldOffset(Offset = "0x424")]
	[Token(Token = "0x4000291")]
	[Tooltip("흔드는 동안 상자 둘레 반짝이 — 개수(0 = 끔)·퍼지는 범위(상자 크기 배율)·크기(상자 대비)·색")]
	public int claimGiftSparkleCount; //Field offset: 0x424
	[FieldOffset(Offset = "0x428")]
	[Token(Token = "0x4000292")]
	public float claimGiftSparkleSpread; //Field offset: 0x428
	[FieldOffset(Offset = "0x42C")]
	[Token(Token = "0x4000293")]
	public float claimGiftSparkleSize; //Field offset: 0x42C
	[FieldOffset(Offset = "0x430")]
	[Token(Token = "0x4000294")]
	public Color claimGiftSparkleColor; //Field offset: 0x430
	[FieldOffset(Offset = "0x440")]
	[Token(Token = "0x4000295")]
	[Tooltip("평면 알약 선물 아이콘(흰 1도 IcoGiftLine) 틴트 색")]
	public Color claimGiftTint; //Field offset: 0x440
	[FieldOffset(Offset = "0x450")]
	[Token(Token = "0x4000296")]
	public Color claimTint; //Field offset: 0x450
	[FieldOffset(Offset = "0x460")]
	[Token(Token = "0x4000297")]
	public Color claimDisabledTint; //Field offset: 0x460
	[FieldOffset(Offset = "0x470")]
	[Token(Token = "0x4000298")]
	[Tooltip("보상 받기 라벨 색 — 활성(핑크 버튼 에셋 BtnReward 위 흰 글자 + 진핑크 글로우)·비활성(크림 알약 위 갈색)")]
	public Color claimLabelColor; //Field offset: 0x470
	[FieldOffset(Offset = "0x480")]
	[Token(Token = "0x4000299")]
	public Color claimLabelGlow; //Field offset: 0x480
	[FieldOffset(Offset = "0x490")]
	[Token(Token = "0x400029A")]
	public Color claimDisabledLabel; //Field offset: 0x490
	[FieldOffset(Offset = "0x4A0")]
	[Header("도장판 카드 — [헤더 줄(완료·완벽)] [달력]. 몸체는 CardPlain")]
	[Token(Token = "0x400029B")]
	public Color stampCardColor; //Field offset: 0x4A0
	[FieldOffset(Offset = "0x4B0")]
	[Token(Token = "0x400029C")]
	[Tooltip("도장판 안쪽 패널 — 헤더 알약 2개(완료·완벽 카운트) + 달력 뒤 라운드 패널(시안). 알파 0이면 없음")]
	public Color headerPillColor; //Field offset: 0x4B0
	[FieldOffset(Offset = "0x4C0")]
	[Token(Token = "0x400029D")]
	[Tooltip("알약 높이(0=헤더 줄 높이 - 22)·알약 사이 간격·라벨 안쪽 여백")]
	public float headerPillH; //Field offset: 0x4C0
	[FieldOffset(Offset = "0x4C4")]
	[Token(Token = "0x400029E")]
	public float headerPillGap; //Field offset: 0x4C4
	[FieldOffset(Offset = "0x4C8")]
	[Token(Token = "0x400029F")]
	public float headerPillPadX; //Field offset: 0x4C8
	[FieldOffset(Offset = "0x4CC")]
	[Token(Token = "0x40002A0")]
	public Color gridPanelColor; //Field offset: 0x4CC
	[FieldOffset(Offset = "0x4DC")]
	[Token(Token = "0x40002A1")]
	[Tooltip("알약·달력 패널의 카드 좌우 여백, 달력 패널 안쪽 여백(셀 ↔ 패널 변), 모서리 반경")]
	public float gridPanelInset; //Field offset: 0x4DC
	[FieldOffset(Offset = "0x4E0")]
	[Token(Token = "0x40002A2")]
	public float gridPanelPad; //Field offset: 0x4E0
	[FieldOffset(Offset = "0x4E4")]
	[Token(Token = "0x40002A3")]
	public float gridPanelRadius; //Field offset: 0x4E4
	[FieldOffset(Offset = "0x4E8")]
	[Token(Token = "0x40002A4")]
	[Tooltip("헤더 줄 높이(카드 위 변 → 첫 줄 시작)")]
	public float stampHeaderRowH; //Field offset: 0x4E8
	[FieldOffset(Offset = "0x4EC")]
	[Range(0.5, 4)]
	[Token(Token = "0x40002A5")]
	[Tooltip("전용 에셋 CardPlain 배율")]
	public float stampCardPpum; //Field offset: 0x4EC
	[FieldOffset(Offset = "0x4F0")]
	[Token(Token = "0x40002A6")]
	[Tooltip("헤더 y = 헤더 줄 가운데 + 이 값")]
	public float headerBandOffsetY; //Field offset: 0x4F0
	[FieldOffset(Offset = "0x4F4")]
	[Token(Token = "0x40002A7")]
	[Tooltip("헤더 줄 아래 → 첫 줄 셀 위 변 / 마지막 줄 아래 → 카드 아래 변 / 달력 좌우 최소 여백")]
	public float gridTopPad; //Field offset: 0x4F4
	[FieldOffset(Offset = "0x4F8")]
	[Token(Token = "0x40002A8")]
	public float gridBottomPad; //Field offset: 0x4F8
	[FieldOffset(Offset = "0x4FC")]
	[Token(Token = "0x40002A9")]
	public float gridSidePad; //Field offset: 0x4FC
	[FieldOffset(Offset = "0x500")]
	[Token(Token = "0x40002AA")]
	public float headerFontSize; //Field offset: 0x500
	[FieldOffset(Offset = "0x504")]
	[Token(Token = "0x40002AB")]
	public float legendIconSize; //Field offset: 0x504
	[FieldOffset(Offset = "0x508")]
	[Token(Token = "0x40002AC")]
	[Tooltip("셀 지름은 카드 폭·높이에서 자동(7열 5줄). 이 값이 상한")]
	public float cellMaxSize; //Field offset: 0x508
	[FieldOffset(Offset = "0x50C")]
	[Token(Token = "0x40002AD")]
	public float cellGap; //Field offset: 0x50C
	[FieldOffset(Offset = "0x510")]
	[Token(Token = "0x40002AE")]
	public float dayFontSize; //Field offset: 0x510
	[FieldOffset(Offset = "0x514")]
	[Token(Token = "0x40002AF")]
	public Color cellBg; //Field offset: 0x514
	[FieldOffset(Offset = "0x524")]
	[Token(Token = "0x40002B0")]
	public Color cellEdge; //Field offset: 0x524
	[FieldOffset(Offset = "0x534")]
	[Token(Token = "0x40002B1")]
	public Color dayText; //Field offset: 0x534
	[FieldOffset(Offset = "0x544")]
	[Token(Token = "0x40002B2")]
	public Color dayTextFuture; //Field offset: 0x544
	[FieldOffset(Offset = "0x554")]
	[Token(Token = "0x40002B3")]
	public Color perfectFill; //Field offset: 0x554
	[FieldOffset(Offset = "0x564")]
	[Token(Token = "0x40002B4")]
	public Color perfectEdge; //Field offset: 0x564
	[FieldOffset(Offset = "0x574")]
	[Token(Token = "0x40002B5")]
	public Color clearFill; //Field offset: 0x574
	[FieldOffset(Offset = "0x584")]
	[Token(Token = "0x40002B6")]
	public Color clearEdge; //Field offset: 0x584
	[FieldOffset(Offset = "0x594")]
	[Token(Token = "0x40002B7")]
	public Color missedRing; //Field offset: 0x594
	[FieldOffset(Offset = "0x5A4")]
	[Token(Token = "0x40002B8")]
	public Color todayRing; //Field offset: 0x5A4
	[FieldOffset(Offset = "0x5B4")]
	[Token(Token = "0x40002B9")]
	public Color selectRing; //Field offset: 0x5B4
	[FieldOffset(Offset = "0x5C4")]
	[Range(0, 0.3)]
	[Token(Token = "0x40002BA")]
	public float ringWidth; //Field offset: 0x5C4
	[FieldOffset(Offset = "0x5C8")]
	[Header("달력 칸 색(유저 시안 10-13) — 미도전·완료·오늘·미래")]
	[Token(Token = "0x40002BB")]
	public Color calMissedFill; //Field offset: 0x5C8
	[FieldOffset(Offset = "0x5D8")]
	[Token(Token = "0x40002BC")]
	public Color calMissedEdge; //Field offset: 0x5D8
	[FieldOffset(Offset = "0x5E8")]
	[Token(Token = "0x40002BD")]
	public Color calMissedNum; //Field offset: 0x5E8
	[FieldOffset(Offset = "0x5F8")]
	[Token(Token = "0x40002BE")]
	public Color calDoneFill; //Field offset: 0x5F8
	[FieldOffset(Offset = "0x608")]
	[Token(Token = "0x40002BF")]
	public Color calDoneEdge; //Field offset: 0x608
	[FieldOffset(Offset = "0x618")]
	[Token(Token = "0x40002C0")]
	public Color calDoneNum; //Field offset: 0x618
	[FieldOffset(Offset = "0x628")]
	[Token(Token = "0x40002C1")]
	public Color calPerfectFill; //Field offset: 0x628
	[FieldOffset(Offset = "0x638")]
	[Token(Token = "0x40002C2")]
	public Color calPerfectEdge; //Field offset: 0x638
	[FieldOffset(Offset = "0x648")]
	[Token(Token = "0x40002C3")]
	public Color calPerfectNum; //Field offset: 0x648
	[FieldOffset(Offset = "0x658")]
	[Range(0, 12)]
	[Token(Token = "0x40002C4")]
	public float calPerfectEdgeW; //Field offset: 0x658
	[FieldOffset(Offset = "0x65C")]
	[Token(Token = "0x40002C5")]
	public Color calTodayFill; //Field offset: 0x65C
	[FieldOffset(Offset = "0x66C")]
	[Token(Token = "0x40002C6")]
	public Color calTodayEdge; //Field offset: 0x66C
	[FieldOffset(Offset = "0x67C")]
	[Token(Token = "0x40002C7")]
	public Color calTodayNum; //Field offset: 0x67C
	[FieldOffset(Offset = "0x68C")]
	[Token(Token = "0x40002C8")]
	public Color calFutureFill; //Field offset: 0x68C
	[FieldOffset(Offset = "0x69C")]
	[Token(Token = "0x40002C9")]
	public Color calFutureEdge; //Field offset: 0x69C
	[FieldOffset(Offset = "0x6AC")]
	[Token(Token = "0x40002CA")]
	[Tooltip("테두리 두께(px) — 기본·오늘")]
	public float calEdgeW; //Field offset: 0x6AC
	[FieldOffset(Offset = "0x6B0")]
	[Token(Token = "0x40002CB")]
	public float calTodayEdgeW; //Field offset: 0x6B0
	[FieldOffset(Offset = "0x6B4")]
	[Range(0.5, 1.3)]
	[Token(Token = "0x40002CC")]
	public float stampScale; //Field offset: 0x6B4
	[FieldOffset(Offset = "0x6B8")]
	[Token(Token = "0x40002CD")]
	[Tooltip("도장 뒤 채움 원판. 기본 꺼짐(알파 0) — 숫자판 그대로 두고 도장만 찍는다(유저 10-12). 켜면 색 원 위에 찍힌다")]
	public Color stampDiscPerfect; //Field offset: 0x6B8
	[FieldOffset(Offset = "0x6C8")]
	[Token(Token = "0x40002CE")]
	public Color stampDiscClear; //Field offset: 0x6C8
	[FieldOffset(Offset = "0x6D8")]
	[Range(0.6, 1.1)]
	[Token(Token = "0x40002CF")]
	public float stampDiscScale; //Field offset: 0x6D8
	[FieldOffset(Offset = "0x6DC")]
	[Header("시작 버튼")]
	[Token(Token = "0x40002D0")]
	[Tooltip("시작 버튼 — 폭은 카드 폭(자동 배치)에서 좌우 startSideInset을 뺀 값, 높이만 여기서")]
	public Vector2 startBtnSize; //Field offset: 0x6DC
	[FieldOffset(Offset = "0x6E4")]
	[Token(Token = "0x40002D1")]
	public float startSideInset; //Field offset: 0x6E4
	[FieldOffset(Offset = "0x6E8")]
	[Token(Token = "0x40002D2")]
	[Tooltip("스트릭 복구 광고 버튼과 같은 주황 알약(btn_pill_cream 틴트)·모서리 배율·라벨 글로우")]
	public Color startTint; //Field offset: 0x6E8
	[FieldOffset(Offset = "0x6F8")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x40002D3")]
	public float startCornerScale; //Field offset: 0x6F8
	[FieldOffset(Offset = "0x6FC")]
	[Token(Token = "0x40002D4")]
	[Tooltip("라벨 글로우 색(LabelGlow, 스트릭 복구 recoverBtnLabelGlow와 동일). 알파 0이면 없음")]
	public Color startLabelGlow; //Field offset: 0x6FC
	[FieldOffset(Offset = "0x70C")]
	[Token(Token = "0x40002D5")]
	public float startFontSize; //Field offset: 0x70C
	[FieldOffset(Offset = "0x710")]
	[Range(0.3, 1)]
	[Token(Token = "0x40002D6")]
	[Tooltip("시작 버튼 글자 최소 배율 — 날짜가 붙어 길어진 문구가 넘치면 이 배율까지 줄인다(2026-10-15)")]
	public float startFontMinRatio; //Field offset: 0x710
	[FieldOffset(Offset = "0x714")]
	[Token(Token = "0x40002D7")]
	public Color startLabel; //Field offset: 0x714
	[FieldOffset(Offset = "0x724")]
	[Token(Token = "0x40002D8")]
	public float dateLabelFontSize; //Field offset: 0x724
	[FieldOffset(Offset = "0x728")]
	[Header("통계 줄 — [날짜] │ [스톱워치] 최고 N초 │ [트로피] TOP N%")]
	[Token(Token = "0x40002D9")]
	public Color statsDateColor; //Field offset: 0x728
	[FieldOffset(Offset = "0x738")]
	[Token(Token = "0x40002DA")]
	public Color statsLabelColor; //Field offset: 0x738
	[FieldOffset(Offset = "0x748")]
	[Token(Token = "0x40002DB")]
	public Color statsBestColor; //Field offset: 0x748
	[FieldOffset(Offset = "0x758")]
	[Token(Token = "0x40002DC")]
	public Color statsTopColor; //Field offset: 0x758
	[FieldOffset(Offset = "0x768")]
	[Token(Token = "0x40002DD")]
	public Color statsSepColor; //Field offset: 0x768
	[FieldOffset(Offset = "0x778")]
	[Token(Token = "0x40002DE")]
	[Tooltip("아이콘 크기(글자 크기 배수)·아이콘↔글자 간격·구분선 두께·구분선 양옆 여백")]
	public float statsIconScale; //Field offset: 0x778
	[FieldOffset(Offset = "0x77C")]
	[Token(Token = "0x40002DF")]
	public float statsIconGap; //Field offset: 0x77C
	[FieldOffset(Offset = "0x780")]
	[Token(Token = "0x40002E0")]
	public float statsSepW; //Field offset: 0x780
	[FieldOffset(Offset = "0x784")]
	[Token(Token = "0x40002E1")]
	public float statsSepPad; //Field offset: 0x784
	[FieldOffset(Offset = "0x788")]
	[Token(Token = "0x40002E2")]
	public Vector2 adIconSize; //Field offset: 0x788
	[FieldOffset(Offset = "0x790")]
	[Token(Token = "0x40002E3")]
	public float adIconInset; //Field offset: 0x790
	[FieldOffset(Offset = "0x794")]
	[Header("뒤로가기(세이프에어리어 안쪽)")]
	[Token(Token = "0x40002E4")]
	public float backSize; //Field offset: 0x794
	[FieldOffset(Offset = "0x798")]
	[Token(Token = "0x40002E5")]
	public float backInset; //Field offset: 0x798
	[FieldOffset(Offset = "0x79C")]
	[Header("오른쪽 위 코너 버튼 [콜렉션][인포] — 크기(0이면 backSize)와 둘 사이 간격(음수면 겹침, 아이콘 그림자 여백 상쇄용)")]
	[Token(Token = "0x40002E6")]
	public float cornerSize; //Field offset: 0x79C
	[FieldOffset(Offset = "0x7A0")]
	[Token(Token = "0x40002E7")]
	public float cornerGap; //Field offset: 0x7A0
	[FieldOffset(Offset = "0x7A4")]
	[Token(Token = "0x40002E8")]
	[Tooltip("콜렉션 버튼 배율 — 아이콘은 뒤로가기와 같은 바탕(원판·두께)으로 다시 그려 1이면 같은 크기(10-13)")]
	public float collectionBtnScale; //Field offset: 0x7A4
	[FieldOffset(Offset = "0x7A8")]
	[Header("인포 버튼 — 퍼즐 타이틀 띠 오른쪽 끝(유저 10-13). 오른쪽 위 코너에는 콜렉션만 남는다")]
	[Token(Token = "0x40002E9")]
	public float infoInlineSize; //Field offset: 0x7A8
	[FieldOffset(Offset = "0x7AC")]
	[Token(Token = "0x40002EA")]
	[Tooltip("띠 오른쪽 끝 기준 위치 보정(+오른쪽/+위)")]
	public Vector2 infoInlineOffset; //Field offset: 0x7AC
	[FieldOffset(Offset = "0x7B4")]
	[Header("콜렉션(완성한 그림 목록) — 캘린더와 같은 배경 위 새 화면, 2열 카드")]
	[Token(Token = "0x40002EB")]
	[Tooltip("카드 안쪽 여백(카드 변 → 썸네일)")]
	public float collectionCardPad; //Field offset: 0x7B4
	[FieldOffset(Offset = "0x7B8")]
	[Token(Token = "0x40002EC")]
	[Tooltip("목록 양옆 추가 여백(캘린더 카드 폭 대비 더 들이는 폭)·맨 위/아래 여백(뱃지가 잘리지 않게)")]
	public float collectionSidePad; //Field offset: 0x7B8
	[FieldOffset(Offset = "0x7BC")]
	[Token(Token = "0x40002ED")]
	public float collectionTopPad; //Field offset: 0x7BC
	[FieldOffset(Offset = "0x7C0")]
	[Range(1, 3)]
	[Token(Token = "0x40002EE")]
	[Tooltip("열 수 — 1이면 카드가 가로로 꽉 찬다")]
	public int collectionColumns; //Field offset: 0x7C0
	[FieldOffset(Offset = "0x7C4")]
	[Token(Token = "0x40002EF")]
	[Tooltip("썸네일 오른쪽 아래 확대 버튼 크기")]
	public float collectionExpandSize; //Field offset: 0x7C4
	[FieldOffset(Offset = "0x7C8")]
	[Token(Token = "0x40002F0")]
	[Tooltip("빈 콜렉션 — 그림 자리 면·아이콘/글자 색·아이콘 크기")]
	public Color collectionEmptyFill; //Field offset: 0x7C8
	[FieldOffset(Offset = "0x7D8")]
	[Token(Token = "0x40002F1")]
	public Color collectionEmptyInk; //Field offset: 0x7D8
	[FieldOffset(Offset = "0x7E8")]
	[Token(Token = "0x40002F2")]
	public float collectionEmptyIcon; //Field offset: 0x7E8
	[FieldOffset(Offset = "0x7EC")]
	[Token(Token = "0x40002F3")]
	[Tooltip("'퍼즐 모으러 가기' 버튼 앞 퍼즐 조각 아이콘(흰색 1도 IcoPuzzleLine) — 틴트 색과 글자 대비 크기")]
	public Color collectionGoIconTint; //Field offset: 0x7EC
	[FieldOffset(Offset = "0x7FC")]
	[Token(Token = "0x40002F4")]
	public float collectionGoIconScale; //Field offset: 0x7FC
	[FieldOffset(Offset = "0x800")]
	[Token(Token = "0x40002F5")]
	[Tooltip("콜렉션 카드의 \"완성!\" 뱃지 표시(10-13 제거 요청으로 기본 끔)")]
	public bool collectionBadgeEnabled; //Field offset: 0x800
	[FieldOffset(Offset = "0x804")]
	[Token(Token = "0x40002F6")]
	[Tooltip("'완성!' 뱃지 높이·기울기(도)·카드 오른쪽 위 기준 위치")]
	public float collectionBadgeH; //Field offset: 0x804
	[FieldOffset(Offset = "0x808")]
	[Token(Token = "0x40002F7")]
	public float collectionBadgeTilt; //Field offset: 0x808
	[FieldOffset(Offset = "0x80C")]
	[Token(Token = "0x40002F8")]
	public Vector2 collectionBadgeOffset; //Field offset: 0x80C
	[FieldOffset(Offset = "0x814")]
	[Header("감상 모드(확대) — 원화만 크게, 핀치 확대·드래그 이동, 우측 상단 X")]
	[Token(Token = "0x40002F9")]
	[Tooltip("켜면 검은 배경, 끄면 햄도쿠 크림 배경")]
	public bool viewerDark; //Field offset: 0x814
	[FieldOffset(Offset = "0x818")]
	[Token(Token = "0x40002FA")]
	public float viewerMargin; //Field offset: 0x818
	[FieldOffset(Offset = "0x81C")]
	[Token(Token = "0x40002FB")]
	[Tooltip("감상 모드 아트 제목 — 그림 바로 위. 글자 크기·그림 위 변과의 간격(px)·y 미세 조정·색(검정 배경이면 흰색)")]
	public float viewerTitleFontSize; //Field offset: 0x81C
	[FieldOffset(Offset = "0x820")]
	[Token(Token = "0x40002FC")]
	public float viewerTitleGap; //Field offset: 0x820
	[FieldOffset(Offset = "0x824")]
	[Token(Token = "0x40002FD")]
	public float viewerTitleDy; //Field offset: 0x824
	[FieldOffset(Offset = "0x828")]
	[Token(Token = "0x40002FE")]
	public Color viewerTitleColor; //Field offset: 0x828
	[FieldOffset(Offset = "0x838")]
	[Token(Token = "0x40002FF")]
	[Tooltip("제목 아래 시즌 표기(\"2026년 10월\") 글자 크기(0이면 숨김)·색")]
	public float viewerSubFontSize; //Field offset: 0x838
	[FieldOffset(Offset = "0x83C")]
	[Token(Token = "0x4000300")]
	public Color viewerSubColor; //Field offset: 0x83C
	[FieldOffset(Offset = "0x84C")]
	[Token(Token = "0x4000301")]
	[Tooltip("감상 모드 하단 \"탭하여 닫기\" — 글자 크기·화면 아래 변에서의 높이(px)")]
	public float viewerTapHintFontSize; //Field offset: 0x84C
	[FieldOffset(Offset = "0x850")]
	[Token(Token = "0x4000302")]
	public float viewerTapHintBottom; //Field offset: 0x850
	[FieldOffset(Offset = "0x854")]
	[Token(Token = "0x4000303")]
	public float viewerMaxZoom; //Field offset: 0x854
	[FieldOffset(Offset = "0x858")]
	[Token(Token = "0x4000304")]
	[Tooltip("확대 중에는 제목·연월·'탭하여 닫기'를 숨긴다 — 그 페이드 시간(초). 0이면 숨기지 않음")]
	public float viewerChromeFade; //Field offset: 0x858
	[FieldOffset(Offset = "0x85C")]
	[Token(Token = "0x4000305")]
	[Tooltip("제목·연월 글자 크기 배수(1열이면 카드가 커서 키운다)")]
	public float collectionTextScale; //Field offset: 0x85C
	[FieldOffset(Offset = "0x860")]
	[Token(Token = "0x4000306")]
	public float collectionGap; //Field offset: 0x860
	[FieldOffset(Offset = "0x864")]
	[Token(Token = "0x4000307")]
	[Tooltip("썸네일 아래 제목·연월 줄 높이")]
	public float collectionTextH; //Field offset: 0x864
	[FieldOffset(Offset = "0x868")]
	[Token(Token = "0x4000308")]
	[Tooltip("카드 아래 글 두 줄 — 줄 사이 간격, 카드 아래 테두리 안쪽 여백(두 줄은 사진 아래 끝과 이 선 사이 가운데)")]
	public float collectionTextLineGap; //Field offset: 0x868
	[FieldOffset(Offset = "0x86C")]
	[Token(Token = "0x4000309")]
	public float collectionTextBottomInset; //Field offset: 0x86C
	[FieldOffset(Offset = "0x870")]
	[Token(Token = "0x400030A")]
	[Tooltip("안내 팝업 — 줄 높이·도장 샘플 크기·글자")]
	public float infoRowH; //Field offset: 0x870
	[FieldOffset(Offset = "0x874")]
	[Token(Token = "0x400030B")]
	public float infoStampSize; //Field offset: 0x874
	[FieldOffset(Offset = "0x878")]
	[Token(Token = "0x400030C")]
	public float infoLabelFontSize; //Field offset: 0x878
	[FieldOffset(Offset = "0x87C")]
	[Token(Token = "0x400030D")]
	public float infoDescFontSize; //Field offset: 0x87C
	[FieldOffset(Offset = "0x880")]
	[Token(Token = "0x400030E")]
	public float infoBoxPad; //Field offset: 0x880
	[FieldOffset(Offset = "0x884")]
	[Header("도장 안내 오버레이 — 딤·빛살·반짝이·화살표 크기는 랭킹 도움말 설정(RankPageConfig.help*)을 그대로 쓴다")]
	[Range(0.3, 1)]
	[Token(Token = "0x400030F")]
	public float infoDimAlpha; //Field offset: 0x884
	[FieldOffset(Offset = "0x888")]
	[Token(Token = "0x4000310")]
	public Color infoTextColor; //Field offset: 0x888
	[FieldOffset(Offset = "0x898")]
	[Header("도장 안내 — 위치 미세 조정(+오른쪽/+위). 기본 배치는 실제 레이아웃(퍼즐 카드·도장판·시작 버튼)에서 계산. 도움말을 연 채 바꾸면 바로 반영")]
	[Token(Token = "0x4000311")]
	[Tooltip("① 묶음 전체(아이콘+문구)")]
	public Vector2 infoStep1Nudge; //Field offset: 0x898
	[FieldOffset(Offset = "0x8A0")]
	[Token(Token = "0x4000312")]
	[Tooltip("① 달력 아이콘만")]
	public Vector2 infoCalendarNudge; //Field offset: 0x8A0
	[FieldOffset(Offset = "0x8A8")]
	[Token(Token = "0x4000313")]
	[Tooltip("① 제목·설명 문구만")]
	public Vector2 infoStep1TextNudge; //Field offset: 0x8A8
	[FieldOffset(Offset = "0x8B0")]
	[Token(Token = "0x4000314")]
	[Tooltip("② 도장 두 개 묶음 전체")]
	public Vector2 infoStep2Nudge; //Field offset: 0x8B0
	[FieldOffset(Offset = "0x8B8")]
	[Token(Token = "0x4000315")]
	[Tooltip("② 퍼펙트 클리어 도장(+씨앗·이름)만")]
	public Vector2 infoPerfectNudge; //Field offset: 0x8B8
	[FieldOffset(Offset = "0x8C0")]
	[Token(Token = "0x4000316")]
	[Tooltip("② 클리어 도장(+씨앗·이름)만")]
	public Vector2 infoClearNudge; //Field offset: 0x8C0
	[FieldOffset(Offset = "0x8C8")]
	[Token(Token = "0x4000317")]
	[Tooltip("③ 도장판 비춤 아래 문구")]
	public Vector2 infoStep3TextNudge; //Field offset: 0x8C8
	[FieldOffset(Offset = "0x8D0")]
	[Token(Token = "0x4000318")]
	[Tooltip("④ 묶음 전체(조각+문구)")]
	public Vector2 infoStep4Nudge; //Field offset: 0x8D0
	[FieldOffset(Offset = "0x8D8")]
	[Token(Token = "0x4000319")]
	[Tooltip("④ 금색 퍼즐 조각만")]
	public Vector2 infoPieceNudge; //Field offset: 0x8D8
	[FieldOffset(Offset = "0x8E0")]
	[Token(Token = "0x400031A")]
	[Tooltip("④ 제목·규칙 문구만")]
	public Vector2 infoStep4TextNudge; //Field offset: 0x8E0
	[FieldOffset(Offset = "0x8E8")]
	[Token(Token = "0x400031B")]
	[Tooltip("문구 최대 폭(px) — ①은 왼쪽 정렬 시작점부터, ③·④는 가운데 기준. 길면 이 안에서 글자가 줄어든다(화살표와 겹침 방지)")]
	public float infoStep1TextMaxW; //Field offset: 0x8E8
	[FieldOffset(Offset = "0x8EC")]
	[Token(Token = "0x400031C")]
	public float infoStep3TextMaxW; //Field offset: 0x8EC
	[FieldOffset(Offset = "0x8F0")]
	[Token(Token = "0x400031D")]
	public float infoStep4TextMaxW; //Field offset: 0x8F0
	[FieldOffset(Offset = "0x8F4")]
	[Token(Token = "0x400031E")]
	[Tooltip("안내 문구가 화면 좌우 끝에서 최소한 떨어질 거리(px) — 넘치면 폭을 줄이고 글자가 작아진다")]
	public float infoTextScreenPad; //Field offset: 0x8F4
	[FieldOffset(Offset = "0x8F8")]
	[Token(Token = "0x400031F")]
	[Tooltip("'탭하여 계속' 문구")]
	public Vector2 infoTapNudge; //Field offset: 0x8F8
	[FieldOffset(Offset = "0x900")]
	[Header("도장 안내 — 화살표 3개(위치 보정·회전·크기 배율, 크기 기준은 랭킹 helpArrowSize)")]
	[Token(Token = "0x4000320")]
	public Vector2 infoArrow1Nudge; //Field offset: 0x900
	[FieldOffset(Offset = "0x908")]
	[Token(Token = "0x4000321")]
	public float infoArrow1Rot; //Field offset: 0x908
	[FieldOffset(Offset = "0x90C")]
	[Token(Token = "0x4000322")]
	public float infoArrow1Scale; //Field offset: 0x90C
	[FieldOffset(Offset = "0x910")]
	[Token(Token = "0x4000323")]
	[Tooltip("화살표 1 좌우 반전·상하 반전")]
	public bool infoArrow1FlipX; //Field offset: 0x910
	[FieldOffset(Offset = "0x911")]
	[Token(Token = "0x4000324")]
	public bool infoArrow1FlipY; //Field offset: 0x911
	[FieldOffset(Offset = "0x914")]
	[Token(Token = "0x4000325")]
	public Vector2 infoArrow2Nudge; //Field offset: 0x914
	[FieldOffset(Offset = "0x91C")]
	[Token(Token = "0x4000326")]
	public float infoArrow2Rot; //Field offset: 0x91C
	[FieldOffset(Offset = "0x920")]
	[Token(Token = "0x4000327")]
	public float infoArrow2Scale; //Field offset: 0x920
	[FieldOffset(Offset = "0x924")]
	[Token(Token = "0x4000328")]
	[Tooltip("화살표 2 좌우 반전·상하 반전")]
	public bool infoArrow2FlipX; //Field offset: 0x924
	[FieldOffset(Offset = "0x925")]
	[Token(Token = "0x4000329")]
	public bool infoArrow2FlipY; //Field offset: 0x925
	[FieldOffset(Offset = "0x928")]
	[Token(Token = "0x400032A")]
	public Vector2 infoArrow3Nudge; //Field offset: 0x928
	[FieldOffset(Offset = "0x930")]
	[Token(Token = "0x400032B")]
	public float infoArrow3Rot; //Field offset: 0x930
	[FieldOffset(Offset = "0x934")]
	[Token(Token = "0x400032C")]
	public float infoArrow3Scale; //Field offset: 0x934
	[FieldOffset(Offset = "0x938")]
	[Token(Token = "0x400032D")]
	[Tooltip("화살표 3 좌우 반전·상하 반전")]
	public bool infoArrow3FlipX; //Field offset: 0x938
	[FieldOffset(Offset = "0x939")]
	[Token(Token = "0x400032E")]
	public bool infoArrow3FlipY; //Field offset: 0x939
	[FieldOffset(Offset = "0x93A")]
	[Header("도장 글자 띠(CLEAR / PERFECT)")]
	[Token(Token = "0x400032F")]
	[Tooltip("띠를 붙일 곳 — 달력 칸 도장·도움말 ② 도장·찍히는 순간 톡 튀어나오기(달력 칸에 띠가 없으면 잠깐 보였다 사라진다)")]
	public bool stampRibbonOnCalendar; //Field offset: 0x93A
	[FieldOffset(Offset = "0x93B")]
	[Token(Token = "0x4000330")]
	public bool stampRibbonOnGuide; //Field offset: 0x93B
	[FieldOffset(Offset = "0x93C")]
	[Token(Token = "0x4000331")]
	public bool stampRibbonOnImpact; //Field offset: 0x93C
	[FieldOffset(Offset = "0x940")]
	[Token(Token = "0x4000332")]
	[Tooltip("띠 폭·높이(도장 크기 배율)·세로 위치(도장 크기 배율, -면 아래)·기울기(도)")]
	public float stampRibbonWidth; //Field offset: 0x940
	[FieldOffset(Offset = "0x944")]
	[Token(Token = "0x4000333")]
	public float stampRibbonHeight; //Field offset: 0x944
	[FieldOffset(Offset = "0x948")]
	[Token(Token = "0x4000334")]
	public float stampRibbonY; //Field offset: 0x948
	[FieldOffset(Offset = "0x94C")]
	[Token(Token = "0x4000335")]
	public float stampRibbonRot; //Field offset: 0x94C
	[FieldOffset(Offset = "0x950")]
	[Token(Token = "0x4000336")]
	[Tooltip("띠 색 — 클리어(더스티 로즈)·퍼펙트(허니 골드)·글자색·글자 크기(띠 높이 배율)")]
	public Color stampRibbonClear; //Field offset: 0x950
	[FieldOffset(Offset = "0x960")]
	[Token(Token = "0x4000337")]
	public Color stampRibbonPerfect; //Field offset: 0x960
	[FieldOffset(Offset = "0x970")]
	[Token(Token = "0x4000338")]
	public Color stampRibbonText; //Field offset: 0x970
	[FieldOffset(Offset = "0x980")]
	[Range(0.3, 0.9)]
	[Token(Token = "0x4000339")]
	public float stampRibbonFontScale; //Field offset: 0x980
	[FieldOffset(Offset = "0x984")]
	[Range(0, 0.6)]
	[Token(Token = "0x400033A")]
	[Tooltip("띠 아래 그림자 알파(0=없음)")]
	public float stampRibbonShadow; //Field offset: 0x984
	[FieldOffset(Offset = "0x988")]
	[Token(Token = "0x400033B")]
	[Tooltip("찍히는 순간 — 띠가 튀어나오기까지 대기·튀는 시간(초)·(달력에 띠가 없을 때) 보였다 사라지기까지 시간")]
	public float stampRibbonPopDelay; //Field offset: 0x988
	[FieldOffset(Offset = "0x98C")]
	[Token(Token = "0x400033C")]
	public float stampRibbonPopDuration; //Field offset: 0x98C
	[FieldOffset(Offset = "0x990")]
	[Token(Token = "0x400033D")]
	public float stampRibbonFlashHold; //Field offset: 0x990
	[FieldOffset(Offset = "0x994")]
	[Header("도장 안내 — 크기")]
	[Token(Token = "0x400033E")]
	[Tooltip("① 달력 아이콘 상자 — 방사형 빛살·반짝이도 이 크기를 따른다. 그림만 키우려면 Info Icon Image Scale")]
	public float infoIconSize; //Field offset: 0x994
	[FieldOffset(Offset = "0x998")]
	[Token(Token = "0x400033F")]
	public float infoStampsCenterX; //Field offset: 0x998
	[FieldOffset(Offset = "0x99C")]
	[Token(Token = "0x4000340")]
	public float infoStampsGap; //Field offset: 0x99C
	[FieldOffset(Offset = "0x9A0")]
	[Token(Token = "0x4000341")]
	public float infoPieceSize; //Field offset: 0x9A0
	[FieldOffset(Offset = "0x9A4")]
	[Range(0.3, 1.6)]
	[Token(Token = "0x4000342")]
	[Tooltip("① 달력·④ 퍼즐 조각 그림만의 크기(상자 대비 배율) — 상자 크기(Info Icon Size / Info Piece Size)는 방사형 빛살·반짝이까지 함께 키운다")]
	public float infoIconImageScale; //Field offset: 0x9A4
	[FieldOffset(Offset = "0x9A8")]
	[Range(0.3, 1.6)]
	[Token(Token = "0x4000343")]
	public float infoPieceImageScale; //Field offset: 0x9A8
	[FieldOffset(Offset = "0x9AC")]
	[Range(0.3, 3)]
	[Token(Token = "0x4000344")]
	[Tooltip("① 달력·④ 퍼즐 조각 뒤 후광·방사형 빛살 크기 배율(1 = 랭킹 도움말과 같음). 랭킹 쪽 설정은 건드리지 않는다")]
	public float infoIconGlowScale; //Field offset: 0x9AC
	[FieldOffset(Offset = "0x9B0")]
	[Range(0.3, 3)]
	[Token(Token = "0x4000345")]
	public float infoIconRayScale; //Field offset: 0x9B0
	[FieldOffset(Offset = "0x9B4")]
	[Range(0.3, 3)]
	[Token(Token = "0x4000346")]
	public float infoPieceGlowScale; //Field offset: 0x9B4
	[FieldOffset(Offset = "0x9B8")]
	[Range(0.3, 3)]
	[Token(Token = "0x4000347")]
	public float infoPieceRayScale; //Field offset: 0x9B8
	[FieldOffset(Offset = "0x9BC")]
	[Range(1, 5)]
	[Token(Token = "0x4000348")]
	[Tooltip("③ 실제 도장판을 비추는 줄 수·여백·가장자리 부드러움·뒤 후광 알파")]
	public int infoSpotRows; //Field offset: 0x9BC
	[FieldOffset(Offset = "0x9C0")]
	[Token(Token = "0x4000349")]
	[Tooltip("도움말 비춤 영역만 7칸 + 안쪽 여백 폭으로 좁힌다(본 화면 도장판 폭은 그대로). 좌우 여유·최소 폭")]
	public bool infoSpotFitWidth; //Field offset: 0x9C0
	[FieldOffset(Offset = "0x9C4")]
	[Token(Token = "0x400034A")]
	public float infoSpotSidePad; //Field offset: 0x9C4
	[FieldOffset(Offset = "0x9C8")]
	[Token(Token = "0x400034B")]
	public float infoSpotMinW; //Field offset: 0x9C8
	[FieldOffset(Offset = "0x9CC")]
	[Token(Token = "0x400034C")]
	public float infoSpotPad; //Field offset: 0x9CC
	[FieldOffset(Offset = "0x9D0")]
	[Token(Token = "0x400034D")]
	public float infoSpotSoftness; //Field offset: 0x9D0
	[FieldOffset(Offset = "0x9D4")]
	[Range(0, 1)]
	[Token(Token = "0x400034E")]
	public float infoSpotGlowAlpha; //Field offset: 0x9D4
	[FieldOffset(Offset = "0x9D8")]
	[Range(0.5, 1.3)]
	[Token(Token = "0x400034F")]
	[Tooltip("③ 도장판 샘플 크기 배율(후광 포함, 아래 설명 글자는 그대로)·위치 미세 조정(px). 본 화면 도장판은 바뀌지 않는다")]
	public float infoSpotScale; //Field offset: 0x9D8
	[FieldOffset(Offset = "0x9DC")]
	[Token(Token = "0x4000350")]
	public Vector2 infoSpotOffset; //Field offset: 0x9DC
	[FieldOffset(Offset = "0x9E4")]
	[Token(Token = "0x4000351")]
	public float infoCellSize; //Field offset: 0x9E4
	[FieldOffset(Offset = "0x9E8")]
	[Token(Token = "0x4000352")]
	[Tooltip("도장판 상단 범례 — 라벨 끝과 개수 숫자 사이 간격")]
	public float headerCountGap; //Field offset: 0x9E8
	[FieldOffset(Offset = "0x9EC")]
	[Token(Token = "0x4000353")]
	public float infoOverlayLabelFontSize; //Field offset: 0x9EC
	[FieldOffset(Offset = "0x9F0")]
	[Token(Token = "0x4000354")]
	public float infoOverlayDescFontSize; //Field offset: 0x9F0
	[FieldOffset(Offset = "0x9F4")]
	[Token(Token = "0x4000355")]
	public float infoRevealDuration; //Field offset: 0x9F4
	[FieldOffset(Offset = "0x9F8")]
	[Token(Token = "0x4000356")]
	public float infoRevealGap; //Field offset: 0x9F8
	[FieldOffset(Offset = "0x9FC")]
	[Header("연출 — 자동 진입(결과 화면 뒤)")]
	[Token(Token = "0x4000357")]
	public float stampDelay; //Field offset: 0x9FC
	[FieldOffset(Offset = "0xA00")]
	[Header("햄스터 손잡이 도장 연출(유저 시안 10-13) — UI/DailySeason/StampToolClear·StampToolPerfect가 있으면 사용")]
	[Token(Token = "0x4000358")]
	public bool stampToolEnabled; //Field offset: 0xA00
	[FieldOffset(Offset = "0xA04")]
	[Token(Token = "0x4000359")]
	[Tooltip("도장 폭 = 칸 지름 × 이 값")]
	public float stampToolScale; //Field offset: 0xA04
	[FieldOffset(Offset = "0xA08")]
	[Token(Token = "0x400035A")]
	[Tooltip("고무판 바닥이 닿는 높이(칸 지름 비율, 칸 중심 기준 +위)")]
	public float stampToolLandY; //Field offset: 0xA08
	[FieldOffset(Offset = "0xA0C")]
	[Token(Token = "0x400035B")]
	[Tooltip("① 등장 위치(착지점 기준)·기울기·시간, 잠깐 머무름")]
	public Vector2 stampToolEnterOffset; //Field offset: 0xA0C
	[FieldOffset(Offset = "0xA14")]
	[Token(Token = "0x400035C")]
	public float stampToolEnterTilt; //Field offset: 0xA14
	[FieldOffset(Offset = "0xA18")]
	[Token(Token = "0x400035D")]
	public float stampToolAppear; //Field offset: 0xA18
	[FieldOffset(Offset = "0xA1C")]
	[Token(Token = "0x400035E")]
	public float stampToolHover; //Field offset: 0xA1C
	[FieldOffset(Offset = "0xA20")]
	[Token(Token = "0x400035F")]
	[Tooltip("② 내려가기 시간")]
	public float stampToolDrop; //Field offset: 0xA20
	[FieldOffset(Offset = "0xA24")]
	[Range(0, 0.3)]
	[Token(Token = "0x4000360")]
	[Tooltip("③ 꾹 눌림 정도·누르고 있는 시간")]
	public float stampToolSquash; //Field offset: 0xA24
	[FieldOffset(Offset = "0xA28")]
	[Token(Token = "0x4000361")]
	public float stampToolHold; //Field offset: 0xA28
	[FieldOffset(Offset = "0xA2C")]
	[Token(Token = "0x4000362")]
	[Tooltip("④ 떼어지며 사라지는 위치·기울기·시간(들리는 모습이 보인 뒤 끝에서 사라짐)")]
	public Vector2 stampToolExitOffset; //Field offset: 0xA2C
	[FieldOffset(Offset = "0xA34")]
	[Token(Token = "0x4000363")]
	public float stampToolExitTilt; //Field offset: 0xA34
	[FieldOffset(Offset = "0xA38")]
	[Token(Token = "0x4000364")]
	public float stampToolLift; //Field offset: 0xA38
	[FieldOffset(Offset = "0xA3C")]
	[Token(Token = "0x4000365")]
	public float stampDuration; //Field offset: 0xA3C
	[FieldOffset(Offset = "0xA40")]
	[Range(1, 3)]
	[Token(Token = "0x4000366")]
	public float stampOvershoot; //Field offset: 0xA40
	[FieldOffset(Offset = "0xA44")]
	[Token(Token = "0x4000367")]
	[Tooltip("내리찍히는 동안 도장 기울기(도) → 0으로 바로 선다")]
	public float stampTilt; //Field offset: 0xA44
	[FieldOffset(Offset = "0xA48")]
	[Range(0, 0.3)]
	[Token(Token = "0x4000368")]
	[Tooltip("쾅: 칸이 눌리는 정도(가로 +, 세로 -)와 도장판 카드 흔들림 세기(px)·별 스파클 개수·크기")]
	public float stampSquash; //Field offset: 0xA48
	[FieldOffset(Offset = "0xA4C")]
	[Token(Token = "0x4000369")]
	public float stampShake; //Field offset: 0xA4C
	[FieldOffset(Offset = "0xA50")]
	[Range(0, 24)]
	[Token(Token = "0x400036A")]
	[Tooltip("인게임 정답 배치 때와 같은 별 터짐(StarBurst): 개수·퍼짐·별 크기 배율")]
	public int stampSparkleCount; //Field offset: 0xA50
	[FieldOffset(Offset = "0xA54")]
	[Token(Token = "0x400036B")]
	public float stampSparkleSpread; //Field offset: 0xA54
	[FieldOffset(Offset = "0xA58")]
	[Token(Token = "0x400036C")]
	public float stampSparkleScale; //Field offset: 0xA58
	[FieldOffset(Offset = "0xA5C")]
	[Token(Token = "0x400036D")]
	public float pieceDelay; //Field offset: 0xA5C
	[FieldOffset(Offset = "0xA60")]
	[Token(Token = "0x400036E")]
	public float pieceDuration; //Field offset: 0xA60
	[FieldOffset(Offset = "0xA64")]
	[Token(Token = "0x400036F")]
	public float pieceStagger; //Field offset: 0xA64
	[FieldOffset(Offset = "0xA68")]
	[Header("연출 — 조각 끼움(절단 조각): 외곽선 발광 + 크게 떴다가 '짠' 끼워짐")]
	[Token(Token = "0x4000370")]
	[Tooltip("외곽 발광 색 — 조각마다 구운 흐린 빛(Jigsaw/glow_NN, 스크립트 --glow)을 조각 뒤에 깔아 틈새로 빛이 새어 나오게")]
	public Color pieceGlowColor; //Field offset: 0xA68
	[FieldOffset(Offset = "0xA78")]
	[Range(1, 1.3)]
	[Token(Token = "0x4000371")]
	[Tooltip("안착 순간 빛이 살짝 부푸는 배율(1=없음)")]
	public float pieceGlowScale; //Field offset: 0xA78
	[FieldOffset(Offset = "0xA7C")]
	[Range(0, 1)]
	[Token(Token = "0x4000372")]
	public float pieceGlowAlpha; //Field offset: 0xA7C
	[FieldOffset(Offset = "0xA80")]
	[Token(Token = "0x4000373")]
	[Tooltip("안착 뒤 빛이 잦아드는 시간")]
	public float pieceGlowDuration; //Field offset: 0xA80
	[FieldOffset(Offset = "0xA84")]
	[Range(1, 2.5)]
	[Token(Token = "0x4000374")]
	[Tooltip("조각이 끼워지기 전 크기(1보다 크게 떠 있다가 OutBack으로 안착)")]
	public float pieceSnapScale; //Field offset: 0xA84
	[FieldOffset(Offset = "0xA88")]
	[Token(Token = "0x4000375")]
	public float pieceSnapDuration; //Field offset: 0xA88
	[FieldOffset(Offset = "0xA8C")]
	[Range(0, 1)]
	[Token(Token = "0x4000376")]
	[Tooltip("안착 순간 조각 위를 스치는 흰 섬광 알파")]
	public float pieceFlashAlpha; //Field offset: 0xA8C
	[FieldOffset(Offset = "0xA90")]
	[Range(0, 1)]
	[Token(Token = "0x4000377")]
	[Tooltip("안착 순간 조각 중심에서 퍼지는 빛 버스트(원형 글로우)·반짝이 개수. 0이면 없음")]
	public float pieceBurstAlpha; //Field offset: 0xA90
	[FieldOffset(Offset = "0xA94")]
	[Range(1, 3)]
	[Token(Token = "0x4000378")]
	public float pieceBurstScale; //Field offset: 0xA94
	[FieldOffset(Offset = "0xA98")]
	[Token(Token = "0x4000379")]
	public Color pieceBurstColor; //Field offset: 0xA98
	[FieldOffset(Offset = "0xAA8")]
	[Range(0, 24)]
	[Token(Token = "0x400037A")]
	[Tooltip("안착 순간 인게임식 별 터짐(StarBurst) 개수·퍼짐·크기 배율")]
	public int pieceSparkleCount; //Field offset: 0xAA8
	[FieldOffset(Offset = "0xAAC")]
	[Token(Token = "0x400037B")]
	[Tooltip("StarBurst는 기준 사각 폭에 비례해 커진다 — 조각은 보드 칸보다 커서 배율을 작게")]
	public float pieceSparkleSpread; //Field offset: 0xAAC
	[FieldOffset(Offset = "0xAB0")]
	[Token(Token = "0x400037C")]
	public float pieceSparkleScale; //Field offset: 0xAB0
	[FieldOffset(Offset = "0xAB4")]
	[Range(0, 12)]
	[Token(Token = "0x400037D")]
	[Tooltip("조각이 박힌 뒤 조각 위에서 반짝이는 4포인트 반짝이 — 개수·크기·시작 지연·퍼지는 시간(0개=없음)")]
	public int pieceTwinkleCount; //Field offset: 0xAB4
	[FieldOffset(Offset = "0xAB8")]
	[Token(Token = "0x400037E")]
	public float pieceTwinkleSize; //Field offset: 0xAB8
	[FieldOffset(Offset = "0xABC")]
	[Token(Token = "0x400037F")]
	public float pieceTwinkleDelay; //Field offset: 0xABC
	[FieldOffset(Offset = "0xAC0")]
	[Token(Token = "0x4000380")]
	public float pieceTwinkleSpan; //Field offset: 0xAC0
	[FieldOffset(Offset = "0xAC4")]
	[Token(Token = "0x4000381")]
	public Color pieceTwinkleColor; //Field offset: 0xAC4
	[FieldOffset(Offset = "0xAD4")]
	[Range(0, 0.1)]
	[Token(Token = "0x4000382")]
	[Tooltip("안착 순간 창 전체가 살짝 튀는 펀치(0=없음)")]
	public float pieceArtPunch; //Field offset: 0xAD4
	[FieldOffset(Offset = "0xAD8")]
	[Header("시즌 시작 팝업 캐릭터")]
	[Token(Token = "0x4000383")]
	[Tooltip("챌린지 시즌 팝업 판 크기 — 랭킹 시즌 팝업보다 크게(제목 한 줄 + 설명 4줄). 내용 좌표도 이 크기 기준(배율 1)")]
	public Vector2 popupPanelSize; //Field offset: 0xAD8
	[FieldOffset(Offset = "0xAE0")]
	[Range(0.6, 1.2)]
	[Token(Token = "0x4000384")]
	[Tooltip("판 전체 배율 — 배치 좌표는 popupPanelSize 기준 그대로 두고 화면에서만 줄인다")]
	public float popupScale; //Field offset: 0xAE0
	[FieldOffset(Offset = "0xAE4")]
	[Token(Token = "0x4000385")]
	[Tooltip("제목 y·글자 크기(오토 사이징 최대). 길면 최소 배율까지 줄고, 그래도 넘치면 두 줄")]
	public float popupTitleY; //Field offset: 0xAE4
	[FieldOffset(Offset = "0xAE8")]
	[Token(Token = "0x4000386")]
	public float popupTitleFontSize; //Field offset: 0xAE8
	[FieldOffset(Offset = "0xAEC")]
	[Range(0.4, 1)]
	[Token(Token = "0x4000387")]
	public float popupTitleMinScale; //Field offset: 0xAEC
	[FieldOffset(Offset = "0xAF0")]
	[Token(Token = "0x4000388")]
	[Tooltip("그림 액자 크기·y")]
	public Vector2 popupHeroSize; //Field offset: 0xAF0
	[FieldOffset(Offset = "0xAF8")]
	[Token(Token = "0x4000389")]
	public float popupHeroY; //Field offset: 0xAF8
	[FieldOffset(Offset = "0xAFC")]
	[Token(Token = "0x400038A")]
	[Tooltip("설명 y·영역 크기·글자 크기(오토 사이징 최대)")]
	public float popupDescY; //Field offset: 0xAFC
	[FieldOffset(Offset = "0xB00")]
	[Token(Token = "0x400038B")]
	public Vector2 popupDescSize; //Field offset: 0xB00
	[FieldOffset(Offset = "0xB08")]
	[Token(Token = "0x400038C")]
	public float popupDescFontSize; //Field offset: 0xB08
	[FieldOffset(Offset = "0xB0C")]
	[Token(Token = "0x400038D")]
	[Tooltip("설명 강조색 — 도장({0})·퍼즐({1})·한정 코스튬({2}). 시트 문구의 <color={n}> 자리에 들어간다")]
	public Color popupDescHighlight; //Field offset: 0xB0C
	[FieldOffset(Offset = "0xB1C")]
	[Token(Token = "0x400038E")]
	public Color popupDescHighlightPuzzle; //Field offset: 0xB1C
	[FieldOffset(Offset = "0xB2C")]
	[Token(Token = "0x400038F")]
	public Color popupDescHighlightCostume; //Field offset: 0xB2C
	[FieldOffset(Offset = "0xB3C")]
	[Token(Token = "0x4000390")]
	[Tooltip("설명 속 '도장'·'퍼즐' 앞 아이콘 — 크기(글자 크기 배율)·글자와의 간격(배율)·세로 미세 조정(크기 배율). 크기 0이면 아이콘 없음")]
	public float popupDescIconScale; //Field offset: 0xB3C
	[FieldOffset(Offset = "0xB40")]
	[Token(Token = "0x4000391")]
	public float popupDescIconGap; //Field offset: 0xB40
	[FieldOffset(Offset = "0xB44")]
	[Token(Token = "0x4000392")]
	public float popupDescIconDy; //Field offset: 0xB44
	[FieldOffset(Offset = "0xB48")]
	[Token(Token = "0x4000393")]
	[Tooltip("버튼 y")]
	public float popupBtnY; //Field offset: 0xB48
	[FieldOffset(Offset = "0xB4C")]
	[Range(0, 15)]
	[Token(Token = "0x4000394")]
	[Tooltip("시즌 마감 리마인드(2026-10-21) — 남은 날(오늘 포함, 마지막 날 = 1)이 이 값 이하가 되면 퍼즐을 다 못 맞춘 유저에게 시즌당 1회 같은 틀로 진행도 안내. 0이면 끔")]
	public int popupRemindDaysLeft; //Field offset: 0xB4C
	[FieldOffset(Offset = "0xB50")]
	[Token(Token = "0x4000395")]
	[Tooltip("등장 — 팝업이 열린 뒤 대기·날아 들어오는 시간(초). 시간 0이면 등장 연출 없음")]
	public float popupCharPopDelay; //Field offset: 0xB50
	[FieldOffset(Offset = "0xB54")]
	[Token(Token = "0x4000396")]
	public float popupCharPopDuration; //Field offset: 0xB54
	[FieldOffset(Offset = "0xB58")]
	[Token(Token = "0x4000397")]
	[Tooltip("등장 시작 위치(최종 자리 기준 px) — 기본은 왼쪽 밖에서 살짝 위로 날아 들어온다")]
	public Vector2 popupCharEnterOffset; //Field offset: 0xB58
	[FieldOffset(Offset = "0xB60")]
	[Range(0, 30)]
	[Token(Token = "0x4000398")]
	[Tooltip("날아오는 동안 진행 방향으로 기우는 각도(도). 도착하면 살랑 펴진다")]
	public float popupCharEnterTilt; //Field offset: 0xB60
	[FieldOffset(Offset = "0xB64")]
	[Token(Token = "0x4000399")]
	[Tooltip("살랑 — 좌우로 떠다니는 폭(px)·한쪽 끝까지 가는 시간(초). 이동 방향으로 popupCharSway만큼 기운다. 0이면 없음")]
	public float popupCharDrift; //Field offset: 0xB64
	[FieldOffset(Offset = "0xB68")]
	[Token(Token = "0x400039A")]
	public float popupCharDriftDuration; //Field offset: 0xB68
	[FieldOffset(Offset = "0xB6C")]
	[Range(0, 15)]
	[Token(Token = "0x400039B")]
	public float popupCharSway; //Field offset: 0xB6C
	[FieldOffset(Offset = "0xB70")]
	[Token(Token = "0x400039C")]
	[Tooltip("둥실 — 위아래 폭(px)·한 번 오르는 시간(초). 0이면 없음")]
	public float popupCharFloat; //Field offset: 0xB70
	[FieldOffset(Offset = "0xB74")]
	[Token(Token = "0x400039D")]
	public float popupCharFloatDuration; //Field offset: 0xB74
	[FieldOffset(Offset = "0xB78")]
	[Range(0, 0.1)]
	[Token(Token = "0x400039E")]
	[Tooltip("숨쉬기 — 세로로 늘어나는 비율(0.015=1.5%, 가로는 그 60%만큼 줄어든다)·한 번 들이쉬는 시간(초). 0이면 없음")]
	public float popupCharBreath; //Field offset: 0xB78
	[FieldOffset(Offset = "0xB7C")]
	[Token(Token = "0x400039F")]
	public float popupCharBreathDuration; //Field offset: 0xB7C
	[FieldOffset(Offset = "0xB80")]
	[Range(0, 0.5)]
	[Token(Token = "0x40003A0")]
	[Tooltip("캐릭터가 떠오를 때 바닥 그림자가 줄어드는 비율(0.1=10%)")]
	public float popupCharShadowShrink; //Field offset: 0xB80
	[FieldOffset(Offset = "0xB84")]
	[Token(Token = "0x40003A1")]
	[Tooltip("시즌 팝업 액자 안 휘날리는 잎(2026-10-21) — 그 시즌 SeasonLobbyPass_{폴더 키} 그림(가을 베이커리 = 단풍잎)이 있을 때만. 개수(0=끔, 절반쯤은 캐릭터 뒤·나머지는 앞)·크기(px)·한 번 가로지르는 시간(초)·지나간 뒤 쉬는 시간(초, 잎마다 0.6~1.6배)·물결 폭(px)·회전(도).\n(10-21 '너무 많이 빨리 한번에' → 3장·5.5초·쉼 2.5초. 옛 이름 popupLeafCount 등은 에디터 메모리 값에 막혀 개명 — 이후 조정은 인스펙터)")]
	public int popupLeafMax; //Field offset: 0xB84
	[FieldOffset(Offset = "0xB88")]
	[Token(Token = "0x40003A2")]
	public float popupLeafBaseSize; //Field offset: 0xB88
	[FieldOffset(Offset = "0xB8C")]
	[Token(Token = "0x40003A3")]
	public float popupLeafFallTime; //Field offset: 0xB8C
	[FieldOffset(Offset = "0xB90")]
	[Token(Token = "0x40003A4")]
	public float popupLeafPause; //Field offset: 0xB90
	[FieldOffset(Offset = "0xB94")]
	[Token(Token = "0x40003A5")]
	public float popupLeafSway; //Field offset: 0xB94
	[FieldOffset(Offset = "0xB98")]
	[Token(Token = "0x40003A6")]
	public float popupLeafTurn; //Field offset: 0xB98
	[FieldOffset(Offset = "0xBA0")]
	[Token(Token = "0x40003A7")]
	[Tooltip("시즌별 캐릭터 연출(2026-10-21) — 아트웍 폴더 키가 같은 항목이 있으면 크기·등장·살랑·둥실을 그 값으로. 없는 시즌은 위 기본값(유령처럼 옆에서 날아와 떠다님).\n땅에 서 있는 캐릭터(가을 베이커리 햄스터)는 반가운 폴짝 한 번 + 발밑 기준 좌우 기울기만(살랑 이동·둥실 끔)")]
	public PopupCharStyle[] popupCharSeasonStyles; //Field offset: 0xBA0
	[FieldOffset(Offset = "0xBA8")]
	[Header("도움말 조각 규칙 아이콘")]
	[Token(Token = "0x40003A8")]
	[Tooltip("'클리어는 1조각' 앞 클리어 도장, '퍼펙트 클리어는 2조각' 앞 퍼펙트 도장 — 크기(글자 크기 배율, 0=없음)·간격·세로 미세 조정")]
	public float infoRuleIconScale; //Field offset: 0xBA8
	[FieldOffset(Offset = "0xBAC")]
	[Token(Token = "0x40003A9")]
	public float infoRuleIconGap; //Field offset: 0xBAC
	[FieldOffset(Offset = "0xBB0")]
	[Token(Token = "0x40003AA")]
	public float infoRuleIconDy; //Field offset: 0xBB0
	[FieldOffset(Offset = "0xBB4")]
	[Header("로비 시즌 장식(데일리 버튼)")]
	[Token(Token = "0x40003AB")]
	[Tooltip("시즌 이벤트 기간(이번 달 시즌 전용 캐릭터 SeasonPopupHero_{폴더 키}가 있을 때) 로비 데일리 버튼에 캐릭터를 살랑살랑. 끄면 숨김")]
	public bool lobbyDecorEnabled; //Field offset: 0xBB4
	[FieldOffset(Offset = "0xBB5")]
	[Token(Token = "0x40003AC")]
	[Tooltip("데일리가 아직 잠겨 있어도 보일지")]
	public bool lobbyDecorWhenLocked; //Field offset: 0xBB5
	[FieldOffset(Offset = "0xBB8")]
	[Token(Token = "0x40003AD")]
	[Tooltip("붙는 자리 — 데일리 버튼 칸 대비 비율(0,0 = 왼쪽 아래, 1,0 = 오른쪽 아래, 1,1 = 오른쪽 위, 0.5,1 = 위 가운데)")]
	public Vector2 lobbyDecorAnchor; //Field offset: 0xBB8
	[FieldOffset(Offset = "0xBC0")]
	[Token(Token = "0x40003AE")]
	[Tooltip("자리에서 미세 이동(px, +오른쪽/+위)·캐릭터 높이(px)·좌우 반전")]
	public Vector2 lobbyDecorOffset; //Field offset: 0xBC0
	[FieldOffset(Offset = "0xBC8")]
	[Token(Token = "0x40003AF")]
	public float lobbyDecorHeight; //Field offset: 0xBC8
	[FieldOffset(Offset = "0xBCC")]
	[Token(Token = "0x40003B0")]
	public bool lobbyDecorFlipX; //Field offset: 0xBCC
	[FieldOffset(Offset = "0xBD0")]
	[Range(0, 30)]
	[Token(Token = "0x40003B1")]
	[Tooltip("살랑 — 좌우 기울기(도)·한쪽으로 기우는 시간(초)·위아래 둥실(px)·둥실 시간(초)")]
	public float lobbyDecorSway; //Field offset: 0xBD0
	[FieldOffset(Offset = "0xBD4")]
	[Token(Token = "0x40003B2")]
	public float lobbyDecorSwayDuration; //Field offset: 0xBD4
	[FieldOffset(Offset = "0xBD8")]
	[Token(Token = "0x40003B3")]
	public float lobbyDecorBob; //Field offset: 0xBD8
	[FieldOffset(Offset = "0xBDC")]
	[Token(Token = "0x40003B4")]
	public float lobbyDecorBobDuration; //Field offset: 0xBDC
	[FieldOffset(Offset = "0xBE0")]
	[Token(Token = "0x40003B5")]
	[Tooltip("좌우 살랑 폭(px, 한쪽). 기울이기(Sway) 대신 몸 전체가 천천히 옆으로 떠다닌다(2026-10-15)")]
	public float lobbyDecorDrift; //Field offset: 0xBE0
	[FieldOffset(Offset = "0xBE4")]
	[Token(Token = "0x40003B6")]
	public float lobbyDecorDriftDuration; //Field offset: 0xBE4
	[FieldOffset(Offset = "0xBE8")]
	[Token(Token = "0x40003B7")]
	[Tooltip("시즌별 로비 장식(2026-10-21) — 폴더 키가 같은 항목이 있으면 위치·크기·움직임을 그 값으로(없으면 위 기본값 = 할로윈 유령처럼 떠다님). 그림은 Resources/UI/DailySeason/SeasonLobbyDecor_{폴더 키}가 먼저, 없으면 시즌 팝업 캐릭터 SeasonPopupHero_{폴더 키}. 가을 베이커리 = 버튼 오른쪽 위 모서리에 걸쳐 앉은 햄스터, 살짝 기울기만")]
	public LobbyDecorStyle[] lobbyDecorSeasonList; //Field offset: 0xBE8
	[FieldOffset(Offset = "0xBF0")]
	[Token(Token = "0x40003B8")]
	[Tooltip("로비 장식 곁을 '휘잉' 지나가는 것(2026-10-21, 가을 베이커리 = 단풍잎) — 그림 SeasonLobbyPass_{폴더 키}가 있을 때만")]
	public LobbyPasser[] lobbyPassList; //Field offset: 0xBF0
	[FieldOffset(Offset = "0xBF8")]
	[Token(Token = "0x40003B9")]
	[Tooltip("유령 곁 작은 친구(할로윈 = 박쥐) — 그림 Resources/UI/DailySeason/SeasonLobbyBuddy_{폴더 키}, 없는 시즌은 안 나온다. 여기 줄 수만큼 같은 그림을 띄운다(2026-10-15). 유령과 같이 살랑이고, 각자 따로 둥실·날갯짓")]
	public LobbyBuddy[] lobbyBuddies; //Field offset: 0xBF8
	[FieldOffset(Offset = "0xC00")]
	[Token(Token = "0x40003BA")]
	[Tooltip("작은 친구 위아래 둥실(px)·둥실 시간(초, 친구마다 조금씩 다르게)·날갯짓 세로 눌림(0=끔)·날갯짓 시간(초)")]
	public float lobbyBuddyBob; //Field offset: 0xC00
	[FieldOffset(Offset = "0xC04")]
	[Token(Token = "0x40003BB")]
	public float lobbyBuddyBobDuration; //Field offset: 0xC04
	[FieldOffset(Offset = "0xC08")]
	[Range(0, 0.5)]
	[Token(Token = "0x40003BC")]
	public float lobbyBuddyFlap; //Field offset: 0xC08
	[FieldOffset(Offset = "0xC0C")]
	[Token(Token = "0x40003BD")]
	public float lobbyBuddyFlapDuration; //Field offset: 0xC0C
	[FieldOffset(Offset = "0xC10")]
	[Token(Token = "0x40003BE")]
	[Tooltip("작은 친구 색 — 그림에 곱한다(흰색 = 원본, 낮출수록 어둡게). 눈 같은 밝은 부분도 같이 어두워진다")]
	public Color lobbyBuddyColor; //Field offset: 0xC10
	[FieldOffset(Offset = "0xC20")]
	[Header("도감 썸네일 절단선")]
	[Range(0, 1.5)]
	[Token(Token = "0x40003BF")]
	[Tooltip("완성한 퍼즐 썸네일 위 퍼즐 절단선 진하기(캘린더 퍼즐 선 색 대비 배율, 0이면 선 없음). 크게 보기에는 선이 없다")]
	public float collectionLineAlpha; //Field offset: 0xC20
	[FieldOffset(Offset = "0xC24")]
	[Header("도감 레드닷")]
	[Token(Token = "0x40003C0")]
	[Tooltip("도감 아이콘 레드닷 위치 — 아이콘 칸 대비 비율(1,1 = 우상단 모서리). 원형 아이콘 테두리에 붙이려면 0.8 안팎")]
	public Vector2 collectionDotAnchor; //Field offset: 0xC24
	[FieldOffset(Offset = "0xC2C")]
	[Token(Token = "0x40003C1")]
	[Tooltip("레드닷 위치 미세 조정(px)·크기 배율(프로필 레드닷 기준)")]
	public Vector2 collectionDotOffset; //Field offset: 0xC2C
	[FieldOffset(Offset = "0xC34")]
	[Range(0.4, 1.5)]
	[Token(Token = "0x40003C2")]
	public float collectionDotScale; //Field offset: 0xC34
	[FieldOffset(Offset = "0xC38")]
	[Header("퍼즐 완성 파동")]
	[Token(Token = "0x40003C3")]
	[Tooltip("마지막 조각이 끼워진 뒤 대기(초) — 0 이하면 파동 없음")]
	public float completeWaveDelay; //Field offset: 0xC38
	[FieldOffset(Offset = "0xC3C")]
	[Token(Token = "0x40003C4")]
	[Tooltip("파동이 가운데에서 가장 먼 조각까지 퍼지는 시간(초)")]
	public float completeWaveSpan; //Field offset: 0xC3C
	[FieldOffset(Offset = "0xC40")]
	[Range(0, 0.4)]
	[Token(Token = "0x40003C5")]
	[Tooltip("조각 하나가 톡 튀는 세기(배율)·시간(초)")]
	public float completeWavePunch; //Field offset: 0xC40
	[FieldOffset(Offset = "0xC44")]
	[Token(Token = "0x40003C6")]
	public float completeWaveDuration; //Field offset: 0xC44
	[FieldOffset(Offset = "0xC48")]
	[Range(0, 1)]
	[Token(Token = "0x40003C7")]
	[Tooltip("조각 위 흰 섬광·외곽 발광 세기(0=없음)")]
	public float completeWaveFlash; //Field offset: 0xC48
	[FieldOffset(Offset = "0xC4C")]
	[Range(0, 1)]
	[Token(Token = "0x40003C8")]
	public float completeWaveGlow; //Field offset: 0xC4C
	[FieldOffset(Offset = "0xC50")]
	[Range(0, 0.1)]
	[Token(Token = "0x40003C9")]
	[Tooltip("파동이 끝날 때 창 전체 펀치(0=없음)")]
	public float completeWaveArtPunch; //Field offset: 0xC50

	[Address(RVA = "0x33EBF98", Offset = "0x33EBF98", Length = "0xE9C")]
	[Token(Token = "0x60001B3")]
	public DailySeasonConfig() { }

	[Address(RVA = "0x33EBF74", Offset = "0x33EBF74", Length = "0x24")]
	[Token(Token = "0x60001B2")]
	public int LayoutHash() { }

	[Address(RVA = "0x33EBE30", Offset = "0x33EBE30", Length = "0x144")]
	[Token(Token = "0x60001B1")]
	public static DailySeasonConfig Load() { }

	[Address(RVA = "0x33EBD8C", Offset = "0x33EBD8C", Length = "0xA4")]
	[Token(Token = "0x60001B0")]
	public LobbyDecorStyle LobbyDecorStyleFor(string folder) { }

	[Address(RVA = "0x33EBCE8", Offset = "0x33EBCE8", Length = "0xA4")]
	[Token(Token = "0x60001AF")]
	public LobbyPasser LobbyPasserFor(string folder) { }

	[Address(RVA = "0x33EBC44", Offset = "0x33EBC44", Length = "0xA4")]
	[Token(Token = "0x60001AE")]
	public PopupCharStyle PopupCharStyleFor(string folder) { }

}

