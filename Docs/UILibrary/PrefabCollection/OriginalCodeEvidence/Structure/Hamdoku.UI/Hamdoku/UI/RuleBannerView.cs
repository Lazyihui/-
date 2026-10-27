namespace Hamdoku.UI;

[RequireComponent(typeof(RectTransform))]
[Token(Token = "0x20000B3")]
public sealed class RuleBannerView : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x20000B4")]
	private sealed class <>c__DisplayClass105_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B99")]
		public TMP_Text label; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000B9A")]
		public RuleBannerView <>4__this; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000B9B")]
		public DOGetter<Color> <>9__1; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000B9C")]
		public DOSetter<Color> <>9__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000B9D")]
		public DOGetter<Color> <>9__3; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000B9E")]
		public DOSetter<Color> <>9__4; //Field offset: 0x38

		[Address(RVA = "0x342BC84", Offset = "0x342BC84", Length = "0x8")]
		[Token(Token = "0x60004E6")]
		public <>c__DisplayClass105_0() { }

		[Address(RVA = "0x342D2EC", Offset = "0x342D2EC", Length = "0x18")]
		[Token(Token = "0x60004EB")]
		internal void <PlayViolation>b__0() { }

		[Address(RVA = "0x342D26C", Offset = "0x342D26C", Length = "0x20")]
		[Token(Token = "0x60004E7")]
		internal Color <PlayViolation>b__1() { }

		[Address(RVA = "0x342D28C", Offset = "0x342D28C", Length = "0x20")]
		[Token(Token = "0x60004E8")]
		internal void <PlayViolation>b__2(Color x) { }

		[Address(RVA = "0x342D2AC", Offset = "0x342D2AC", Length = "0x20")]
		[Token(Token = "0x60004E9")]
		internal Color <PlayViolation>b__3() { }

		[Address(RVA = "0x342D2CC", Offset = "0x342D2CC", Length = "0x20")]
		[Token(Token = "0x60004EA")]
		internal void <PlayViolation>b__4(Color x) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20000B5")]
	private sealed class <BuildWhenSized>d__98 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000B9F")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000BA0")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000BA1")]
		public RuleBannerView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000BA2")]
		private RectTransform <rt>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000BA3")]
		private int <guard>5__3; //Field offset: 0x30

		[Token(Token = "0x170000BF")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x342D574", Offset = "0x342D574", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004EF")]
			 get { } //Length: 8
		}

		[Token(Token = "0x170000C0")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x342D5B4", Offset = "0x342D5B4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x60004F1")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x3429C88", Offset = "0x3429C88", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x60004EC")]
		public <BuildWhenSized>d__98(int <>1__state) { }

		[Address(RVA = "0x342D308", Offset = "0x342D308", Length = "0x26C")]
		[Token(Token = "0x60004EE")]
		private bool MoveNext() { }

		[Address(RVA = "0x342D574", Offset = "0x342D574", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004EF")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x342D5B4", Offset = "0x342D5B4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x60004F1")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x342D57C", Offset = "0x342D57C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x60004F0")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x342D304", Offset = "0x342D304", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x60004ED")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x4000B68")]
	private static readonly string[] IconNames; //Field offset: 0x0
	[Token(Token = "0x4000B69")]
	private static readonly string[] LocKeys; //Field offset: 0x8
	[FieldOffset(Offset = "0x20")]
	[Header("표시")]
	[SerializeField]
	[Token(Token = "0x4000B48")]
	[Tooltip("켜면 코드가 자기 위치/폭을 잡는다. 끄면 씬에서 직접 잡은 RectTransform 사용")]
	private bool autoPlace; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Header("세로 위치 (0=화면 바닥, 1=천장)")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000B49")]
	[Tooltip("배너 중심의 세로 위치. 이 슬라이더 하나로 배너 전체가 위아래로 이동")]
	private float bandCenter; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Range(0.02, 0.3)]
	[SerializeField]
	[Token(Token = "0x4000B4A")]
	[Tooltip("배너 두께(정규화 높이). 위치와 독립적으로 높이만 조절")]
	private float bandHeight; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(0, 0.1)]
	[SerializeField]
	[Token(Token = "0x4000B4B")]
	[Tooltip("배너와 아래 보드 사이 간격(정규화)")]
	private float boardGap; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Header("가로 폭")]
	[SerializeField]
	[Token(Token = "0x4000B4C")]
	[Tooltip("이 RectTransform의 좌우 폭에 배너를 맞춘다(보통 보드/CellsGrid). 비우면 Side Margin 사용")]
	private RectTransform widthReference; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4000B4D")]
	[Tooltip("Width Reference를 정사각 보드로 취급 → min(폭,높이)로 실제 보드폭에 맞춤. 보드가 정사각이라 좌우 여백이 배너와 안 맞을 때 켠다")]
	private bool matchBoardSquare; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[SerializeField]
	[Token(Token = "0x4000B4E")]
	[Tooltip("보드 실제 폭 미세보정(px). 셀 여백만큼 배너를 살짝 줄일 때")]
	private float boardMatchTrim; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	[Token(Token = "0x4000B4F")]
	[Tooltip("Width Reference가 없을 때 좌우 여백(px, 1080 기준)")]
	private float sideMargin; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	[Token(Token = "0x4000B50")]
	[Tooltip("배너 아래로 밀어낼 보드 영역(BoardArea). 배너와 겹치지 않게 위를 내림")]
	private RectTransform boardArea; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Range(0, 0.3)]
	[SerializeField]
	[Token(Token = "0x4000B51")]
	[Tooltip("보드 좌우 여백(0=풀폭, 클수록 얇음). BoardArea 폭을 대칭으로 설정 — 이 슬라이더로 실시간 조절")]
	private float boardSideMargin; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Range(0, 80)]
	[SerializeField]
	[Token(Token = "0x4000B52")]
	[Tooltip("보드 외곽 흰 여백(셀↔백킹 사이, px). 줄이면 흰 테두리가 얇아짐")]
	private float boardInnerPad; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Header("하단 아이템 위치")]
	[SerializeField]
	[Token(Token = "0x4000B53")]
	[Tooltip("아이템 바(BottomBar). 비우면 이름으로 자동 연결")]
	private RectTransform bottomBar; //Field offset: 0x58
	[FieldOffset(Offset = "0x60")]
	[Range(0, 0.4)]
	[SerializeField]
	[Token(Token = "0x4000B54")]
	[Tooltip("아이템 하단 위치(0=화면 바닥, 클수록 위로). 아이템 자체를 직접 올리고 내림. 세로 폰 기준 — 와이드는 아래 Wide Item Bottom이 대신 탄다")]
	private float itemBottom; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Header("하단 아이템 — 와이드(태블릿·폴드 펼침, 가로/세로 ≥ 0.65)")]
	[Range(0.5, 1)]
	[SerializeField]
	[Token(Token = "0x4000B55")]
	[Tooltip("와이드에서만 아이템 바(버튼+뱃지) 균일 축소 배율. 캔버스가 짧아져 200px 고정 버튼이 보드 대비 커 보이는 문제 — 세로 폰(0.46)·16:9는 무변화. 기본은 팝업과 같은 전역 상한(0.8): 아이패드에서 버튼/보드 비율이 세로 폰(약 18%)과 같아진다")]
	private float wideItemScale; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Range(0, 0.4)]
	[SerializeField]
	[Token(Token = "0x4000B56")]
	[Tooltip("와이드에서만 쓰는 아이템 하단 위치(Item Bottom 대체). 낮추면 보드와의 간격이 벌어진다 — 0.07이면 보드↔버튼 간격이 세로 폰 비율(보드 폭의 약 7.5%)과 같아진다. 하단 배너(태블릿 90dp) 위는 지켜야 하므로 0.05 아래로는 내리지 말 것")]
	private float wideItemBottom; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Range(0, 0.1)]
	[SerializeField]
	[Token(Token = "0x4000B57")]
	[Tooltip("와이드에서 하단 배너가 떠 있으면 아이콘·뱃지의 실제 밑변(rect Bounds)이 [배너 윗변 + 이 값] 아래로 내려오지 않게 바를 올린다(부모 높이 비율). Wide Item Bottom 위치가 이미 배너 위면 건드리지 않는다. 보드 밑변 쪽에도 같은 값을 남기고 그 사이에 안 들어가면 배율을 더 줄인다 — 폴드 펼침은 0.01이 0.8 배율이 그대로 들어가는 한계(버튼 rect 200에 투명 여백이 있어 눈에 보이는 간격은 이보다 넓다). 배너 높이는 dp 고정(폴드·태블릿 90dp)이라 캔버스 비율 배치와 어긋나 폴드 펼침에서 3px까지 붙었던 문제(2026-09-11)")]
	private float wideBannerGap; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Range(0, 120)]
	[SerializeField]
	[Token(Token = "0x4000B58")]
	[Tooltip("에디터 검증용 가상 배너 높이(dp). 에디터는 실배너가 없어 0이면 회피가 동작하지 않는다 — Device Simulator 폴드·아이패드 프로파일에서 90을 넣고 확인. 빌드에서는 무시")]
	private float editorSimBannerDp; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Header("헤더 버튼 (뒤로가기 / 설정)")]
	[Range(60, 220)]
	[SerializeField]
	[Token(Token = "0x4000B59")]
	[Tooltip("헤더 버튼 공통 크기(px) — 뒤로가기/설정/상점 셋 다 이 한 값으로 동일하게 적용. 위치 기준선 고정, 대칭으로 커짐")]
	private float headerButtonSize; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	[Token(Token = "0x4000B5A")]
	[Tooltip("켜면 버튼 바깥 끝을 보드(=룰배너) 좌우 가장자리 선에 자동 정렬. 끄면 씬 원위치 고정")]
	private bool headerAlignToBoard; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Range(-120, 120)]
	[SerializeField]
	[Token(Token = "0x4000B5B")]
	[Tooltip("보드 가장자리에서 안쪽(+)/바깥(-)으로 미세조정(px). 크기와 무관")]
	private float headerButtonEdgeMargin; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Range(-80, 60)]
	[SerializeField]
	[Token(Token = "0x4000B5C")]
	[Tooltip("설정 버튼 ↔ 상점 버튼 간격(px). 음수면 더 겹쳐 붙는다. 상점 버튼은 설정 버튼 왼쪽에 같은 크기로 따라붙음")]
	private float shopButtonGap; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Header("아이콘 / 텍스트 크기")]
	[Range(0.3, 1)]
	[SerializeField]
	[Token(Token = "0x4000B5D")]
	[Tooltip("아이콘 크기 = 카드 높이 대비 비율(카드 폭도 넘지 않게 자동 제한)")]
	private float iconScale; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	[Token(Token = "0x4000B5E")]
	private float fontSizeMin; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[SerializeField]
	[Token(Token = "0x4000B5F")]
	private float fontSizeMax; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Header("색")]
	[SerializeField]
	[Token(Token = "0x4000B60")]
	[Tooltip("3개 카드 뒤 배경(컨테이너) 색")]
	private Color bannerBg; //Field offset: 0x90
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	[Token(Token = "0x4000B61")]
	[Tooltip("각 규칙(아이콘+텍스트) 카드 배경색")]
	private Color cardBg; //Field offset: 0xA0
	[FieldOffset(Offset = "0xB0")]
	[SerializeField]
	[Token(Token = "0x4000B62")]
	private Color textCol; //Field offset: 0xB0
	[FieldOffset(Offset = "0xC0")]
	[SerializeField]
	[Token(Token = "0x4000B63")]
	[Tooltip("배너·카드 아웃라인 색")]
	private Color outlineColor; //Field offset: 0xC0
	[FieldOffset(Offset = "0xD0")]
	[SerializeField]
	[Token(Token = "0x4000B64")]
	[Tooltip("아웃라인 두께(px). 0이면 아웃라인 없음")]
	private float outlineWidth; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[SerializeField]
	[Token(Token = "0x4000B65")]
	[Tooltip("규칙 카드 소프트 섀도 퍼짐(px). 0이면 없음. 배너 자체 그림자는 SoftShadow 컴포넌트에서 조절")]
	private float cardShadowSpread; //Field offset: 0xD4
	[FieldOffset(Offset = "0xD8")]
	[Range(0.02, 0.25)]
	[SerializeField]
	[Token(Token = "0x4000B66")]
	[Tooltip("배너 가장자리와 카드 사이 여백(배너 높이 대비 비율). 클수록 배너 배경 테두리가 두꺼워짐")]
	private float cardOuterPadRatio; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Header("기타")]
	[SerializeField]
	[Token(Token = "0x4000B67")]
	[Tooltip("레이아웃 계산 시 높이를 못 읽었을 때 대체 높이(px)")]
	private float fallbackHeight; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Header("등장 연출 (DOTween)")]
	[SerializeField]
	[Token(Token = "0x4000B6A")]
	[Tooltip("표시될 때 팝인 연출 사용")]
	private bool playIntro; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[SerializeField]
	[Token(Token = "0x4000B6B")]
	private float introDuration; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Header("실수 강조 (위반한 규칙 카드가 붉게)")]
	[SerializeField]
	[Token(Token = "0x4000B6C")]
	[Tooltip("실수했을 때 원인이 된 규칙 카드가 붉게 물들며 부르르 떨린다")]
	private bool playViolation; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[SerializeField]
	[Token(Token = "0x4000B6D")]
	[Tooltip("위반 카드 배경색 — 붉게 물들되 글자 가독성은 유지")]
	private Color violationCardBg; //Field offset: 0xEC
	[FieldOffset(Offset = "0xFC")]
	[SerializeField]
	[Token(Token = "0x4000B6E")]
	[Tooltip("위반 카드 주변 붉은 글로우 색(알파=최대 진하기). 선처럼 보이지 않게 번지는 색")]
	private Color violationOutline; //Field offset: 0xFC
	[FieldOffset(Offset = "0x10C")]
	[Range(0, 60)]
	[SerializeField]
	[Token(Token = "0x4000B6F")]
	[Tooltip("카드 밖으로 부드럽게 퍼지는 폭(px). 선처럼 진하지 않게 블러로 번진다. 0이면 없음")]
	private float violationGlowSpread; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	[Token(Token = "0x4000B70")]
	[Tooltip("위반 카드 글자색")]
	private Color violationText; //Field offset: 0x110
	[FieldOffset(Offset = "0x120")]
	[Range(1, 4)]
	[SerializeField]
	[Token(Token = "0x4000B71")]
	[Tooltip("깜빡임 횟수(레퍼런스는 2회)")]
	private int violationPulses; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Range(0.3, 2)]
	[SerializeField]
	[Token(Token = "0x4000B72")]
	[Tooltip("한 번 깜빡이는 데 걸리는 시간(초). 물들기·유지·빠지기 전체 — 키우면 천천히 깜빡인다")]
	private float violationPulseDuration; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000B73")]
	[Tooltip("깜빡임 사이에 남겨 두는 붉은 기(0=평상시 색까지 완전히 돌아옴, 1=계속 최대로 붉음)")]
	private float violationMidKeep; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Header("강조 연출 (띠용 + 글로우)")]
	[SerializeField]
	[Token(Token = "0x4000B74")]
	[Tooltip("게임 시작마다 배너가 통통 튀며 아웃 글로우로 규칙을 강조. 값 튜닝은 컴포넌트 우클릭 → Preview Emphasis로 확인")]
	private bool playEmphasis; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	[Token(Token = "0x4000B75")]
	[Tooltip("등장(또는 게임 시작) 후 강조 시작까지 지연(초)")]
	private float emphasisDelay; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Range(1, 1.3)]
	[SerializeField]
	[Token(Token = "0x4000B76")]
	[Tooltip("펄스 시 커지는 배율(1=변화 없음)")]
	private float emphasisScale; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(1, 4)]
	[SerializeField]
	[Token(Token = "0x4000B77")]
	[Tooltip("펄스 횟수(레퍼런스는 2회)")]
	private int emphasisPulses; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Range(0.15, 1.5)]
	[SerializeField]
	[Token(Token = "0x4000B78")]
	[Tooltip("펄스 1회 시간(초)")]
	private float emphasisPulseDuration; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	[Token(Token = "0x4000B79")]
	[Tooltip("아웃 글로우 색(알파=최대 밝기)")]
	private Color glowColor; //Field offset: 0x140
	[FieldOffset(Offset = "0x150")]
	[Range(6, 120)]
	[SerializeField]
	[Token(Token = "0x4000B7A")]
	[Tooltip("글로우가 배너 밖으로 퍼지는 폭(px)")]
	private float glowSpread; //Field offset: 0x150
	[FieldOffset(Offset = "0x154")]
	[Token(Token = "0x4000B7B")]
	private bool _built; //Field offset: 0x154
	[FieldOffset(Offset = "0x155")]
	[Token(Token = "0x4000B7C")]
	private bool _introPlayed; //Field offset: 0x155
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x4000B7D")]
	private float _boardTopOrig; //Field offset: 0x158
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x4000B7E")]
	private float _boardBottomOrig; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x4000B7F")]
	private float _bottomBarHeight; //Field offset: 0x160
	[FieldOffset(Offset = "0x164")]
	[Token(Token = "0x4000B80")]
	private Vector3 _bottomBarScaleOrig; //Field offset: 0x164
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x4000B81")]
	private bool _bottomBarScaleCached; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x4000B82")]
	private Vector2Int _lastScreen; //Field offset: 0x174
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x4000B83")]
	private RectTransform _cellsGrid; //Field offset: 0x180
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x4000B84")]
	private RectTransform _pauseBtn; //Field offset: 0x188
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x4000B85")]
	private RectTransform _settingsBtn; //Field offset: 0x190
	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x4000B86")]
	private RectTransform _shopBtn; //Field offset: 0x198
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x4000B87")]
	private float _pauseOrigX; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A4")]
	[Token(Token = "0x4000B88")]
	private float _settingsOrigX; //Field offset: 0x1A4
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x4000B89")]
	private float _shopOrigX; //Field offset: 0x1A8
	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x4000B8A")]
	private CanvasGroup _cg; //Field offset: 0x1B0
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x4000B8B")]
	private Image _glow; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x4000B8C")]
	private Sequence _emphasisSeq; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x4000B8D")]
	private readonly TMP_Text[] _labels; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x4000B8E")]
	private readonly RectTransform[] _cards; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x4000B8F")]
	private readonly Image[] _cardOutlines; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x4000B90")]
	private readonly Image[] _cardFills; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x4000B91")]
	private readonly Image[] _cardRings; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x4000B92")]
	private Sequence _violationSeq; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x4000B93")]
	private int _violationCard; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x4000B94")]
	private float _lastRefW; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x4000B95")]
	private float _lastParentW; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x4000B96")]
	private float _lastRefL; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x4000B97")]
	private float _lastRefR; //Field offset: 0x208
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x4000B98")]
	private readonly Vector3[] _refCorners; //Field offset: 0x210

	[Token(Token = "0x170000BD")]
	private float BandHi
	{
		[Address(RVA = "0x3428AB8", Offset = "0x3428AB8", Length = "0x34")]
		[Token(Token = "0x60004C0")]
		 get { } //Length: 52
	}

	[Token(Token = "0x170000BC")]
	private float BandLo
	{
		[Address(RVA = "0x3428A84", Offset = "0x3428A84", Length = "0x34")]
		[Token(Token = "0x60004BF")]
		 get { } //Length: 52
	}

	[Token(Token = "0x170000BE")]
	public float ViolationDuration
	{
		[Address(RVA = "0x342B328", Offset = "0x342B328", Length = "0x3C")]
		[Token(Token = "0x60004D5")]
		 get { } //Length: 60
	}

	[Address(RVA = "0x342D090", Offset = "0x342D090", Length = "0x1DC")]
	[Token(Token = "0x60004E5")]
	private static RuleBannerView() { }

	[Address(RVA = "0x342CDAC", Offset = "0x342CDAC", Length = "0x2E4")]
	[Token(Token = "0x60004E4")]
	public RuleBannerView() { }

	[Address(RVA = "0x342A2DC", Offset = "0x342A2DC", Length = "0x208")]
	[Token(Token = "0x60004DF")]
	private Image AddFill(RectTransform parent, Color color) { }

	[Address(RVA = "0x3429654", Offset = "0x3429654", Length = "0x334")]
	[Token(Token = "0x60004CB")]
	private void ApplyBannerFloor(ref float iBot, ref float s) { }

	[Address(RVA = "0x3428C64", Offset = "0x3428C64", Length = "0x204")]
	[Token(Token = "0x60004C9")]
	private void ApplyBoardArea() { }

	[Address(RVA = "0x3428AEC", Offset = "0x3428AEC", Length = "0x54")]
	[Token(Token = "0x60004C2")]
	public void ApplyBoardLayoutOnly() { }

	[Address(RVA = "0x34293EC", Offset = "0x34293EC", Length = "0x268")]
	[Token(Token = "0x60004CA")]
	private void ApplyBottomBar() { }

	[Address(RVA = "0x342C520", Offset = "0x342C520", Length = "0x294")]
	[Token(Token = "0x60004DD")]
	private void ApplyGlowShape() { }

	[Address(RVA = "0x3427E64", Offset = "0x3427E64", Length = "0x210")]
	[Token(Token = "0x60004C5")]
	private void ApplyHeaderButtons() { }

	[Address(RVA = "0x3428E68", Offset = "0x3428E68", Length = "0x1C0")]
	[Token(Token = "0x60004C8")]
	private void ApplyInnerPad() { }

	[Address(RVA = "0x3427D30", Offset = "0x3427D30", Length = "0x134")]
	[Token(Token = "0x60004C1")]
	private void ApplyPlacement() { }

	[Address(RVA = "0x3429988", Offset = "0x3429988", Length = "0xD4")]
	[Token(Token = "0x60004CD")]
	private float BannerHeightScreenPx() { }

	[Address(RVA = "0x3429F70", Offset = "0x3429F70", Length = "0x36C")]
	[Token(Token = "0x60004D2")]
	private void Build(float w, float h) { }

	[Address(RVA = "0x342A4E4", Offset = "0x342A4E4", Length = "0x964")]
	[Token(Token = "0x60004E0")]
	private void BuildCard(RectTransform parent, int i, float w, float h, float outerPad, float gap) { }

	[Address(RVA = "0x3428074", Offset = "0x3428074", Length = "0x6C")]
	[IteratorStateMachine(typeof(<BuildWhenSized>d__98))]
	[Token(Token = "0x60004D0")]
	private IEnumerator BuildWhenSized() { }

	[Address(RVA = "0x342BC8C", Offset = "0x342BC8C", Length = "0x4B8")]
	[Token(Token = "0x60004D9")]
	private Image EnsureCardRing(int i) { }

	[Address(RVA = "0x342B0C4", Offset = "0x342B0C4", Length = "0x264")]
	[Token(Token = "0x60004DC")]
	private void EnsureGlow() { }

	[Address(RVA = "0x3428AB8", Offset = "0x3428AB8", Length = "0x34")]
	[Token(Token = "0x60004C0")]
	private float get_BandHi() { }

	[Address(RVA = "0x3428A84", Offset = "0x3428A84", Length = "0x34")]
	[Token(Token = "0x60004BF")]
	private float get_BandLo() { }

	[Address(RVA = "0x342B328", Offset = "0x342B328", Length = "0x3C")]
	[Token(Token = "0x60004D5")]
	public float get_ViolationDuration() { }

	[Address(RVA = "0x34283A8", Offset = "0x34283A8", Length = "0x124")]
	[Token(Token = "0x60004DB")]
	private void KillEmphasis() { }

	[Address(RVA = "0x34284CC", Offset = "0x34284CC", Length = "0x3C")]
	[Token(Token = "0x60004D7")]
	private void KillViolation() { }

	[Address(RVA = "0x3429CB0", Offset = "0x3429CB0", Length = "0x2C0")]
	[Token(Token = "0x60004D1")]
	private void MatchBoardWidth() { }

	[Address(RVA = "0x3429BFC", Offset = "0x3429BFC", Length = "0x8C")]
	[Token(Token = "0x60004CE")]
	private void OnBannerAreaChanged() { }

	[Address(RVA = "0x3428238", Offset = "0x3428238", Length = "0x170")]
	[Token(Token = "0x60004BD")]
	private void OnDisable() { }

	[Address(RVA = "0x3427C14", Offset = "0x3427C14", Length = "0x11C")]
	[Token(Token = "0x60004BC")]
	private void OnEnable() { }

	[Address(RVA = "0x3428760", Offset = "0x3428760", Length = "0x324")]
	[Token(Token = "0x60004D4")]
	public void PlayEmphasis(float delay = 0) { }

	[Address(RVA = "0x342AE48", Offset = "0x342AE48", Length = "0x27C")]
	[Token(Token = "0x60004D3")]
	private void PlayIntro() { }

	[Address(RVA = "0x342B364", Offset = "0x342B364", Length = "0x920")]
	[Token(Token = "0x60004D6")]
	public void PlayViolation(int ruleIndex) { }

	[Address(RVA = "0x342C7B4", Offset = "0x342C7B4", Length = "0x8")]
	[ContextMenu("Preview Emphasis")]
	[Token(Token = "0x60004DE")]
	private void PreviewEmphasis() { }

	[Address(RVA = "0x342C518", Offset = "0x342C518", Length = "0x8")]
	[ContextMenu("Preview Violation (rule 3)")]
	[Token(Token = "0x60004DA")]
	private void PreviewViolation() { }

	[Address(RVA = "0x342859C", Offset = "0x342859C", Length = "0xE4")]
	[Token(Token = "0x60004C3")]
	private void PushBoard() { }

	[Address(RVA = "0x342C7BC", Offset = "0x342C7BC", Length = "0x2F0")]
	[ContextMenu("Rebuild")]
	[Token(Token = "0x60004E2")]
	private void RebuildNow() { }

	[Address(RVA = "0x34280E0", Offset = "0x34280E0", Length = "0x158")]
	[Token(Token = "0x60004E1")]
	private void RefreshText() { }

	[Address(RVA = "0x342C144", Offset = "0x342C144", Length = "0x3D4")]
	[Token(Token = "0x60004D8")]
	private void ResetViolationVisuals(bool killTweens) { }

	[Address(RVA = "0x3428B40", Offset = "0x3428B40", Length = "0x124")]
	[Token(Token = "0x60004C4")]
	private void ResolveBottomBar() { }

	[Address(RVA = "0x3429028", Offset = "0x3429028", Length = "0x130")]
	[Token(Token = "0x60004C6")]
	private static void ResolveHeaderBtn(ref RectTransform rt, ref float origX, string name) { }

	[Address(RVA = "0x3428680", Offset = "0x3428680", Length = "0xE0")]
	[Token(Token = "0x60004CF")]
	private void RestoreBoard() { }

	[Address(RVA = "0x3428508", Offset = "0x3428508", Length = "0x94")]
	[Token(Token = "0x60004BE")]
	public void SetShown(bool shown) { }

	[Address(RVA = "0x3429158", Offset = "0x3429158", Length = "0x294")]
	[Token(Token = "0x60004C7")]
	private void SizeHeaderButton(RectTransform rt, float origX, float sz, float edge) { }

	[Address(RVA = "0x3429A5C", Offset = "0x3429A5C", Length = "0x1A0")]
	[Token(Token = "0x60004CC")]
	private static bool TryGetChildExtents(RectTransform bar, out float below, out float above) { }

	[Address(RVA = "0x342CAAC", Offset = "0x342CAAC", Length = "0x300")]
	[Token(Token = "0x60004E3")]
	private void Update() { }

}

