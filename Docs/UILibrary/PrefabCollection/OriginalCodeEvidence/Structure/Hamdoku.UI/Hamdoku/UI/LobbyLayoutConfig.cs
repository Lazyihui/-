namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "LobbyLayoutConfig", menuName = "Hamdoku/Lobby Layout Config")]
[Token(Token = "0x200007F")]
public sealed class LobbyLayoutConfig : ScriptableObject
{
	[FieldOffset(Offset = "0x18")]
	[Header("카드 그룹")]
	[Range(0, 1)]
	[Token(Token = "0x40006C5")]
	[Tooltip("그룹 '하단'의 세로 앵커(SafeArea 비율). 하단 고정이라 커져도 아래 BI를 침범하지 않는다")]
	public float groupBottomY; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(0.5, 1)]
	[Token(Token = "0x40006C6")]
	[Tooltip("그룹 상단 한계(SafeArea 비율) — 상단 원형 버튼(상점/설정)과 겹치지 않는 선. 겹치면 더 내리기")]
	public float groupTopLimit; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Range(0.5, 1)]
	[Token(Token = "0x40006C7")]
	[Tooltip("그룹이 SafeArea 폭에서 차지할 목표 비율(와이드에서 이 비율까지 확대)")]
	public float groupFillWidth; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Range(1, 2)]
	[Token(Token = "0x40006C8")]
	[Tooltip("그룹 확대 상한(폰=1)")]
	public float groupMaxScale; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40006C9")]
	[Tooltip("데일리-우측 열 가로 간격(px). 스트릭-랭킹 세로 간격은 (데일리 높이-두 카드 높이)")]
	public float cardGap; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Header("데일리 카드")]
	[Token(Token = "0x40006CA")]
	public Vector2 dailySize; //Field offset: 0x2C
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x40006CB")]
	public Vector2 dailyIconPos; //Field offset: 0x34
	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40006CC")]
	public Vector2 dailyIconSize; //Field offset: 0x3C
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x40006CD")]
	public Vector2 dailyTitlePos; //Field offset: 0x44
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40006CE")]
	public Vector2 dailyTitleBox; //Field offset: 0x4C
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x40006CF")]
	public float dailyTitleFontMax; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40006D0")]
	public Vector2 dailyDatePos; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40006D1")]
	public Vector2 dailyDateBox; //Field offset: 0x60
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40006D2")]
	public Vector2 dailyCapsulePos; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40006D3")]
	public Vector2 dailyCapsuleSize; //Field offset: 0x70
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40006D4")]
	public Vector2 dailyPillPos; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40006D5")]
	public Vector2 dailyPillSize; //Field offset: 0x80
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40006D6")]
	public Vector2 dailyPillLabelBox; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40006D7")]
	public float dailyPillFontMax; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Header("스트릭 카드")]
	[Token(Token = "0x40006D8")]
	public Vector2 streakSize; //Field offset: 0x94
	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x40006D9")]
	public Vector2 streakIconPos; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40006DA")]
	public Vector2 streakIconSize; //Field offset: 0xA4
	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x40006DB")]
	public Vector2 streakValuePos; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x40006DC")]
	public Vector2 streakValueBox; //Field offset: 0xB4
	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x40006DD")]
	public float streakFontMax; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[Range(0, 8)]
	[Token(Token = "0x40006DE")]
	[Tooltip("해바라기 아이콘 반짝이 개수(상점 썸네일 방식). 0이면 꺼짐 — 플레이 중에만 보임")]
	public int streakSparkleCount; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x40006DF")]
	public Color streakSparkleColor; //Field offset: 0xC4
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x40006E0")]
	[Tooltip("반짝이 한 개 크기 범위(px) — 작으면 카드 배경에 묻힌다(2026-08-25 상향)")]
	public Vector2 streakSparkleSize; //Field offset: 0xD4
	[FieldOffset(Offset = "0xDC")]
	[Range(0, 10)]
	[Token(Token = "0x40006E1")]
	[Tooltip("해바라기가 좌우로 살랑이는 최대 기울기(도). 0이면 꺼짐 — 플레이 중에만 보임")]
	public float streakSwayDegrees; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Range(1, 15)]
	[Token(Token = "0x40006E2")]
	[Tooltip("한 번 왕복(왼쪽→오른쪽→왼쪽)에 걸리는 초. 클수록 느긋하게 살랑인다")]
	public float streakSwaySeconds; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Range(0, 1)]
	[Token(Token = "0x40006E3")]
	[Tooltip("흔들림 축의 세로 위치(아이콘 높이 비율, 0=바닥 1=꼭대기). 줄기 밑(≈0.04)을 축으로 두면 꽃머리만 기운다")]
	public float streakSwayPivotY; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Header("스트릭 완료 체크 (오늘 승리 시 'N일' 오른쪽 — 데일리 카드 체크와 같은 뱃지)")]
	[Token(Token = "0x40006E4")]
	[Tooltip("체크 뱃지 한 변(px). 0이면 표시 안 함")]
	public float streakCheckSize; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x40006E5")]
	[Tooltip("'N일' 글자 끝과 체크 사이 간격(px)")]
	public float streakCheckGap; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40006E6")]
	[Tooltip("체크 오른쪽 끝이 카드 오른쪽 가장자리에서 안쪽으로 유지할 여유(px)")]
	public float streakCheckRightInset; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x40006E7")]
	[Tooltip("글자 끝 자동 배치 기준 위치 미세 조정(px, -y = 아래)")]
	public Vector2 streakCheckOffset; //Field offset: 0xF4
	[FieldOffset(Offset = "0xFC")]
	[Range(0.3, 1)]
	[Token(Token = "0x40006E8")]
	[Tooltip("자리가 모자랄 때(긴 숫자/언어) 뱃지가 줄어들 수 있는 최소 배율")]
	public float streakCheckMinScale; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(0, 1)]
	[Token(Token = "0x40006E9")]
	[Tooltip("글자가 뱃지 아래로 파고들 수 있는 비율(0=겹침 금지, 1=뱃지 폭 전부). 'N일'은 짧아 기본 0")]
	public float streakCheckOverlap; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Header("랭킹 카드")]
	[Token(Token = "0x40006EA")]
	public Vector2 rankSize; //Field offset: 0x104
	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x40006EB")]
	public Vector2 rankIconPos; //Field offset: 0x10C
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x40006EC")]
	public Vector2 rankIconSize; //Field offset: 0x114
	[FieldOffset(Offset = "0x11C")]
	[Range(0, 4)]
	[Token(Token = "0x40006ED")]
	[Tooltip("포디움 뒤 방사형 후광 크기(아이콘 대비 배율). 0이면 숨김")]
	public float rankGlowScale; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40006EE")]
	[Tooltip("후광 색(연한 웜 화이트 권장)")]
	public Color rankGlowColor; //Field offset: 0x120
	[FieldOffset(Offset = "0x130")]
	[Range(4, 24)]
	[Token(Token = "0x40006EF")]
	[Tooltip("후광 스포크(살) 개수 — 상점 썸네일 후광과 동일 방식")]
	public int rankGlowSpokes; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x40006F0")]
	[Tooltip("후광이 한 바퀴 도는 초. 0이면 회전 없음")]
	public float rankGlowSpinSeconds; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40006F1")]
	public Vector2 rankCapsulePos; //Field offset: 0x138
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40006F2")]
	public Vector2 rankCapsuleSize; //Field offset: 0x140
	[FieldOffset(Offset = "0x148")]
	[Header("레벨 버튼")]
	[Range(0, 1.2)]
	[Token(Token = "0x40006F3")]
	[Tooltip("레벨 버튼의 보이는 판 폭 = 그룹 폭 × 이 비율. 0이면 폭을 건드리지 않음(수동)")]
	public float levelWidthOfGroup; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Range(0.5, 1)]
	[Token(Token = "0x40006F4")]
	[Tooltip("레벨 버튼 스프라이트에서 보이는 판의 비율(투명 여백 제외) — 현재 아트 기준 0.796")]
	public float levelVisibleFrac; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40006F5")]
	[Tooltip("레벨 버튼 렉트 높이")]
	public float levelHeight; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Range(0, 1)]
	[Token(Token = "0x40006F6")]
	[Tooltip("레벨 버튼 중심의 세로 앵커(SafeArea 비율)")]
	public float levelCenterY; //Field offset: 0x154
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40006F7")]
	[Tooltip("'레벨 N' 텍스트 최대 폰트(오토사이즈 상한)")]
	public float levelFontMax; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x40006F8")]
	[Tooltip("'레벨 N' 텍스트 박스(라벨 영역)")]
	public Vector2 levelLabelBox; //Field offset: 0x15C
	[FieldOffset(Offset = "0x164")]
	[Header("데일리 완료 반짝이 (발바닥 뱃지 주변 도넛 분포)")]
	[Range(0, 8)]
	[Token(Token = "0x40006F9")]
	[Tooltip("동시에 떠 있는 별 개수. 0이면 연출 끔")]
	public int dailyTwinkleCount; //Field offset: 0x164
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40006FA")]
	[Tooltip("별 한 변 크기 범위(px) — 매 깜빡임마다 이 사이에서 추첨")]
	public Vector2 dailyTwinkleSize; //Field offset: 0x168
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40006FB")]
	[Tooltip("별 색(알파 = 최대 밝기)")]
	public Color dailyTwinkleColor; //Field offset: 0x170
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40006FC")]
	[Tooltip("깜빡임 사이 쉬는 시간 범위(초) — 별마다 무작위")]
	public Vector2 dailyTwinkleRest; //Field offset: 0x180
	[FieldOffset(Offset = "0x188")]
	[Header("데일리 완료 기록 필 (배경 교체 + 뱃지)")]
	[Token(Token = "0x40006FD")]
	[Tooltip("완료 상태의 필 크기(px). 축이 0이면 씬 크기 유지")]
	public Vector2 dailyRecordPillSize; //Field offset: 0x188
	[FieldOffset(Offset = "0x190")]
	[Range(0.5, 2)]
	[Token(Token = "0x40006FE")]
	[Tooltip("뱃지 한 변 = 필 높이 × 이 배율")]
	public float dailyRecordBadgeScale; //Field offset: 0x190
	[FieldOffset(Offset = "0x194")]
	[Token(Token = "0x40006FF")]
	[Tooltip("뱃지 중심 위치(필 왼쪽 가장자리 기준 px, +x 오른쪽 +y 위)")]
	public Vector2 dailyRecordBadgeOffset; //Field offset: 0x194
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x4000700")]
	[Tooltip("TOP 라벨 왼쪽 여백(px) — 뱃지와 겹치지 않게 밀어낸다")]
	public float dailyRecordLabelInset; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x4000701")]
	[Tooltip("TOP 라벨 위치 미세 조정(px, 씬 위치 기준. -y = 아래로). 폰트 어센더 때문에 살짝 떠 보이는 것 보정")]
	public Vector2 dailyRecordLabelOffset; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x4000702")]
	[Tooltip("TOP 라벨 색. 알파 0이면 씬 색 유지")]
	public Color dailyRecordLabelColor; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1B8")]
	[Range(0, 96)]
	[Token(Token = "0x4000703")]
	[Tooltip("TOP 라벨 글자 크기(오토사이즈 상한 겸용). 0이면 씬 값 유지")]
	public float dailyRecordLabelFontSize; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1BC")]
	[Header("어려움 뱃지(레벨 버튼 좌상단 알약)")]
	[Token(Token = "0x4000704")]
	[Tooltip("알약 크기(px)")]
	public Vector2 hardBadgeSize; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1C4")]
	[Token(Token = "0x4000705")]
	[Tooltip("판 좌상단 자동 배치 기준 위치 오프셋(+x 오른쪽, +y 위)")]
	public Vector2 hardBadgeOffset; //Field offset: 0x1C4
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x4000706")]
	[Tooltip("알약 색(테두리 없음)")]
	public Color hardBadgeColor; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x4000707")]
	[Tooltip("알약 '어려움' 텍스트 색")]
	public Color hardBadgeTextColor; //Field offset: 0x1DC

	[Address(RVA = "0x34102B4", Offset = "0x34102B4", Length = "0x244")]
	[Token(Token = "0x600039B")]
	public LobbyLayoutConfig() { }

}

