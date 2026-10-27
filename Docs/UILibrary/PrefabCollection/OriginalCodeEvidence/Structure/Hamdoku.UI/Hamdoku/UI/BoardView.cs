namespace Hamdoku.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[Token(Token = "0x200000B")]
public sealed class BoardView : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x200000D")]
	private struct <>c__DisplayClass182_0
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000084")]
		public float m; //Field offset: 0x0
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x4000085")]
		public float step; //Field offset: 0x4
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000086")]
		public bool[,] vth; //Field offset: 0x8
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000087")]
		public bool[,] hth; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000088")]
		public int n; //Field offset: 0x18

	}

	[CompilerGenerated]
	[Token(Token = "0x200000E")]
	private sealed class <FadeAssistIn>d__180 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000089")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400008A")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400008B")]
		public BoardView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400008C")]
		public float delay; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x400008D")]
		public float dur; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400008E")]
		private Color <c>5__2; //Field offset: 0x30
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x400008F")]
		private float <t>5__3; //Field offset: 0x40

		[Token(Token = "0x1700000F")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DAA40", Offset = "0x33DAA40", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600007C")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000010")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DAA80", Offset = "0x33DAA80", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x600007E")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33DA0A8", Offset = "0x33DA0A8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000079")]
		public <FadeAssistIn>d__180(int <>1__state) { }

		[Address(RVA = "0x33DA898", Offset = "0x33DA898", Length = "0x1A8")]
		[Token(Token = "0x600007B")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DAA40", Offset = "0x33DAA40", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600007C")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DAA80", Offset = "0x33DAA80", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x600007E")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DAA48", Offset = "0x33DAA48", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x600007D")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DA894", Offset = "0x33DA894", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x600007A")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x200000F")]
	private sealed class <ShakeRoutine>d__114 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000090")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000091")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000092")]
		public BoardView <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000093")]
		public float dur; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000094")]
		public float amp; //Field offset: 0x2C
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000095")]
		private RectTransform <rt>5__2; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000096")]
		private float <t>5__3; //Field offset: 0x38

		[Token(Token = "0x17000011")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x33DAD04", Offset = "0x33DAD04", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000082")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000012")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x33DAD44", Offset = "0x33DAD44", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000084")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x33D7270", Offset = "0x33D7270", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x600007F")]
		public <ShakeRoutine>d__114(int <>1__state) { }

		[Address(RVA = "0x33DAA8C", Offset = "0x33DAA8C", Length = "0x278")]
		[Token(Token = "0x6000081")]
		private bool MoveNext() { }

		[Address(RVA = "0x33DAD04", Offset = "0x33DAD04", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000082")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x33DAD44", Offset = "0x33DAD44", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000084")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x33DAD0C", Offset = "0x33DAD0C", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000083")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x33DAA88", Offset = "0x33DAA88", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000080")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x200000C")]
	public enum SweepCorner : int
	{
		TopLeft = 0,
		TopRight = 1,
		BottomLeft = 2,
		BottomRight = 3,
	}

	[Token(Token = "0x400007E")]
	private const int AssistTexSize = 768; //Field offset: 0x0
	[Token(Token = "0x4000074")]
	private const string HypoHamsterResource = "hint_hypo_hamster"; //Field offset: 0x0
	[CompilerGenerated]
	[Token(Token = "0x400006E")]
	private static bool <Shaking>k__BackingField; //Field offset: 0x0
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	[Token(Token = "0x4000025")]
	[Tooltip("한 칸 프리팹 (CellView 포함)")]
	private CellView cellPrefab; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	[Token(Token = "0x4000026")]
	[Tooltip("구역 색 팔레트. 켜진 인접 대비 배정이 판마다 이 중에서 골라 쓴다(부족하면 regionId 순환 폴백)")]
	private Color[] regionColors; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	[Token(Token = "0x4000027")]
	[Tooltip("판마다 맞닿은 구역끼리 지각적으로 먼 색이 가도록 팔레트 배정을 최적화한다. 끄면 기존 규칙(regionId % 팔레트 길이)으로 배정")]
	private bool contrastAwareColors; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	[Token(Token = "0x4000028")]
	[Tooltip("힌트 '가정' 표시용 물음표 햄스터 그림(비우면 기본 햄스터 그림에 ? 를 겹쳐 그린다)")]
	private Sprite hypotheticalHamster; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Header("연출")]
	[SerializeField]
	[Token(Token = "0x4000029")]
	[Tooltip("판을 깔 때 한 줄(행)당 지연(초). 줄 단위로 위→아래 착착착 배치. 0이면 애니메이션 없음")]
	private float appearStagger; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Range(0, 0.2)]
	[SerializeField]
	[Token(Token = "0x400002A")]
	[Tooltip("판이 다 깔린 뒤 클리어 때와 같은 발광 테두리가 좌상단 모서리에서 우하단으로 한 번 훑고 내려간다 — 대각선 한 줄당 시차(초). 0이면 끔. 등장 애니메이션(appearStagger)이 꺼져 있어도 안 돈다")]
	private float introSweepStep; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400002B")]
	[Tooltip("마지막 타일이 착지한 뒤 훑기가 출발하기까지의 텀(초)")]
	private float introSweepDelay; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400002C")]
	[Tooltip("등장 훑기의 발광·테두리 세기 — 클리어 강조 대비 배율. 1이면 클리어와 같고, 낮추면 은은하게 지나간다")]
	private float introSweepIntensity; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	[Token(Token = "0x400002D")]
	[Tooltip("등장 훑기의 발광 색(알파 무시). 클리어의 노란빛(1, 0.88, 0.45)보다 살짝 흰빛 쪽으로 — 은은하게 지나가는 인상")]
	private Color introSweepGlowColor; //Field offset: 0x50
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	[Token(Token = "0x400002E")]
	[Tooltip("훑기가 출발하는 모서리. 반대편 모서리로 대각선으로 지나간다(기본 좌상단 → 우하단 = 타일이 깔리는 방향)")]
	private SweepCorner introSweepFrom; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Header("줄 완성 물결")]
	[Range(0, 0.15)]
	[SerializeField]
	[Token(Token = "0x400002F")]
	[Tooltip("햄스터를 찾은 줄(행/열)의 나머지 칸이 모두 X가 되면 그 줄을 도미노처럼 훑는 반동 — 칸 하나당 시차(초). 0이면 끔. 그 줄의 햄스터 칸에서 양옆(행)·위아래(열)로 번진다")]
	private float lineWaveStep; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Range(0, 0.6)]
	[SerializeField]
	[Token(Token = "0x4000030")]
	[Tooltip("줄이 풀린 순간부터 물결이 출발하기까지의 텀(초). 기본 0.2는 마지막 칸의 배치 팝(0.2초)이 정확히 끝나는 시점 — 더 줄이면 팝이 물결에 넘어가면서 크기가 한 번 튄다")]
	private float lineWaveDelay; //Field offset: 0x68
	[FieldOffset(Offset = "0x6C")]
	[Range(0, 0.4)]
	[SerializeField]
	[Token(Token = "0x4000031")]
	[Tooltip("칸이 솟는 크기 — 0.14면 최대 +14%. 판 등장 바운스보다 작게 둬야 '지나간다'는 인상이 산다")]
	private float lineWaveAmplitude; //Field offset: 0x6C
	[FieldOffset(Offset = "0x70")]
	[Range(0.1, 0.8)]
	[SerializeField]
	[Token(Token = "0x4000032")]
	[Tooltip("칸 하나가 흔들리고 잦아들기까지의 시간(초). 시차(lineWaveStep)보다 길어야 물결이 이어져 보인다")]
	private float lineWaveDuration; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000033")]
	[Tooltip("솟을 때 세로로 길쭉해지는 정도(크기 변화분에 곱함). 0이면 균일 확대, 키우면 더 말랑한 젤리 느낌")]
	private float lineWaveSquash; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000034")]
	[Tooltip("물결과 함께 지나가는 발광 테두리 세기(클리어 강조 대비 배율). 0이면 움직임만")]
	private float lineWaveGlow; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[SerializeField]
	[Token(Token = "0x4000035")]
	[Tooltip("줄 물결 발광의 색(알파 무시). lineWaveGlow가 0보다 클 때만 쓴다")]
	private Color lineWaveGlowColor; //Field offset: 0x7C
	[FieldOffset(Offset = "0x8C")]
	[Header("발견 구역 파동")]
	[Range(0, 0.2)]
	[SerializeField]
	[Token(Token = "0x4000036")]
	[Tooltip("햄스터를 찾은 순간, 그 칸과 같은 색 구역이 햄스터 자리에서부터 동심원으로 한 번 번진다 — 칸 거리 1당 시차(초). 0이면 끔. 거리는 대각선을 포함한 직선 거리라 사각형이 아니라 원으로 퍼진다")]
	private float regionRippleStep; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Range(0, 0.6)]
	[SerializeField]
	[Token(Token = "0x4000037")]
	[Tooltip("햄스터가 놓인 순간부터 파동이 출발하기까지의 텀(초). 배치 팝(0.2초)보다 짧게 둬서 팝이 잦아드는 동안 구역이 이어받게 한다")]
	private float regionRippleDelay; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Range(0, 0.4)]
	[SerializeField]
	[Token(Token = "0x4000038")]
	[Tooltip("칸이 솟는 크기 — 0.09면 최대 +9%. 줄 완성 물결(lineWaveAmplitude)보다 작게 둬야 '줄이 풀린 것'이 더 큰 사건으로 남는다")]
	private float regionRippleAmplitude; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Range(0.1, 0.8)]
	[SerializeField]
	[Token(Token = "0x4000039")]
	[Tooltip("칸 하나가 솟았다 돌아오기까지의 시간(초)")]
	private float regionRippleDuration; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400003A")]
	[Tooltip("솟을 때 세로로 길쭉해지는 정도(크기 변화분에 곱함). 0이면 균일 확대")]
	private float regionRippleSquash; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	[Token(Token = "0x400003B")]
	[Tooltip("햄스터가 놓인 칸 자신도 같이 출렁일지. 그 칸은 이미 배치 팝과 별 스파클이 겹치므로 기본은 끔")]
	private bool regionRippleIncludeOrigin; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA4")]
	[Header("발견 별 스파클")]
	[Range(3, 12)]
	[SerializeField]
	[Token(Token = "0x400003C")]
	[Tooltip("햄스터를 찾은 칸에서 터지는 별 개수")]
	private int sparkleCount; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Range(0.5, 2.5)]
	[SerializeField]
	[Token(Token = "0x400003D")]
	[Tooltip("별이 퍼져 나가는 최종 반경 배율 — 1이면 칸 폭의 0.52배. 키우면 더 멀리 퍼진다")]
	private float sparkleSpread; //Field offset: 0xA8
	[FieldOffset(Offset = "0xAC")]
	[Range(0, 0.95)]
	[SerializeField]
	[Token(Token = "0x400003E")]
	[Tooltip("별이 터져 나오기 시작하는 안쪽 고리 — 최종 반경의 비율. 0이면 얼굴 한가운데서 시작해 햄스터 얼굴을 가린다(얼굴 '주변'으로 터지게 하려면 0.5 이상)")]
	private float sparkleInnerRatio; //Field offset: 0xAC
	[FieldOffset(Offset = "0xB0")]
	[Range(0.3, 2)]
	[SerializeField]
	[Token(Token = "0x400003F")]
	[Tooltip("별 하나의 크기 배율 — 1이면 칸 폭의 0.34배. 작을수록 잔잔한 반짝임")]
	private float sparkleSizeScale; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB4")]
	[Header("드래그 반짝이 궤적")]
	[SerializeField]
	[Token(Token = "0x4000040")]
	[Tooltip("드래그로 X를 칠할 때 손가락이 지나간 자리에 반짝이가 남는다. 색은 그 칸의 구역 색 계열")]
	private bool dragTrailEnabled; //Field offset: 0xB4
	[FieldOffset(Offset = "0xB5")]
	[SerializeField]
	[Token(Token = "0x4000041")]
	[Tooltip("X를 지우는 드래그에도 궤적을 남길지. 끄면 칠할 때만")]
	private bool dragTrailOnErase; //Field offset: 0xB5
	[FieldOffset(Offset = "0xB8")]
	[Range(0.1, 1.5)]
	[SerializeField]
	[Token(Token = "0x4000042")]
	[Tooltip("조각 간격 — 칸 간격 대비. 0.4면 한 칸 지날 때 2~3개. 작을수록 촘촘")]
	private float dragTrailSpacing; //Field offset: 0xB8
	[FieldOffset(Offset = "0xBC")]
	[Range(0, 0.8)]
	[SerializeField]
	[Token(Token = "0x4000043")]
	[Tooltip("손가락 경로에서 조각이 흩뿌려지는 반경 — 칸 간격 대비")]
	private float dragTrailJitter; //Field offset: 0xBC
	[FieldOffset(Offset = "0xC0")]
	[SerializeField]
	[Token(Token = "0x4000044")]
	[Tooltip("반짝이 한 개 크기 범위 — 칸 간격 대비")]
	private Vector2 dragTrailSize; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC8")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000045")]
	[Tooltip("조각 중 작은 빛 방울(반짝이 대신 동그란 점)의 비율. 0이면 전부 4포인트 반짝이")]
	private float dragTrailDotRatio; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Range(0.1, 1)]
	[SerializeField]
	[Token(Token = "0x4000046")]
	[Tooltip("빛 방울 크기 — 반짝이 크기 대비")]
	private float dragTrailDotScale; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[SerializeField]
	[Token(Token = "0x4000047")]
	[Tooltip("조각 수명 범위(초)")]
	private Vector2 dragTrailLife; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000048")]
	[Tooltip("수명 동안 흩어지는 거리 — 칸 간격 대비")]
	private float dragTrailDrift; //Field offset: 0xD8
	[FieldOffset(Offset = "0xDC")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000049")]
	[Tooltip("수명 동안 떠오르는 거리 — 칸 간격 대비")]
	private float dragTrailRise; //Field offset: 0xDC
	[FieldOffset(Offset = "0xE0")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400004A")]
	[Tooltip("구역 색에서 채도를 덜어내는 비율. 0이면 칸 색 그대로(같은 색 칸 위에서 묻힌다), 1이면 흰색")]
	private float dragTrailWhiten; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE4")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400004B")]
	[Tooltip("조각 불투명도")]
	private float dragTrailAlpha; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Range(8, 160)]
	[SerializeField]
	[Token(Token = "0x400004C")]
	[Tooltip("동시에 살아 있는 조각 상한(넘으면 가장 오래된 조각을 재활용)")]
	private int dragTrailMaxPieces; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400004D")]
	[Tooltip("간격 불규칙도. 0이면 일정 간격(도장 찍듯), 1이면 간격이 0.2~2배로 들쭉날쭉")]
	private float dragTrailIrregularity; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400004E")]
	[Tooltip("가끔 작은 조각 1~2개가 곁에 뭉쳐 나오는 확률")]
	private float dragTrailClusterChance; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Range(0, 0.8)]
	[SerializeField]
	[Token(Token = "0x400004F")]
	[Tooltip("경로 옆으로 출렁이는 물결 폭 — 칸 간격 대비. 0이면 손가락 경로 위에 곧게")]
	private float dragTrailWave; //Field offset: 0xF4
	[FieldOffset(Offset = "0xF8")]
	[Range(0.1, 3)]
	[SerializeField]
	[Token(Token = "0x4000050")]
	[Tooltip("물결의 촘촘함 — 한 칸 지날 때의 출렁임 빈도. 작을수록 크게 휘고, 클수록 자글자글")]
	private float dragTrailWaveFreq; //Field offset: 0xF8
	[FieldOffset(Offset = "0xFC")]
	[Range(0, 0.5)]
	[SerializeField]
	[Token(Token = "0x4000051")]
	[Tooltip("가끔 나오는 큰 반짝이 확률")]
	private float dragTrailHeroChance; //Field offset: 0xFC
	[FieldOffset(Offset = "0x100")]
	[Range(1, 3)]
	[SerializeField]
	[Token(Token = "0x4000052")]
	[Tooltip("큰 반짝이 크기 배율")]
	private float dragTrailHeroScale; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000053")]
	[Tooltip("조각이 손가락 진행 방향으로 딸려 나가는 거리 — 칸 간격 대비. 그어 나가는 방향감")]
	private float dragTrailFollow; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Range(0, 0.6)]
	[SerializeField]
	[Token(Token = "0x4000054")]
	[Tooltip("반짝이가 사는 동안 깜빡이듯 크기가 출렁이는 정도. 0이면 끔")]
	private float dragTrailTwinkle; //Field offset: 0x108
	[FieldOffset(Offset = "0x10C")]
	[Range(0, 12)]
	[SerializeField]
	[Token(Token = "0x4000055")]
	[Tooltip("궤적 크기 기준 판 크기(칸 수). 이보다 작은 판(칸이 큰 판)도 이 판의 칸 크기 기준으로 그려 반짝이가 커지지 않는다. 이보다 큰 판은 지금처럼 칸 크기를 따라 작아진다. 0이면 항상 칸 크기를 따름")]
	private int dragTrailRefCells; //Field offset: 0x10C
	[FieldOffset(Offset = "0x110")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x4000056")]
	[Tooltip("반짝이 뒤에 까는 같은 색 후광의 불투명도. 색 계열은 그대로 두고 빛나 보이게 한다. 0이면 끔")]
	private float dragTrailGlow; //Field offset: 0x110
	[FieldOffset(Offset = "0x114")]
	[Range(1, 4)]
	[SerializeField]
	[Token(Token = "0x4000057")]
	[Tooltip("후광 크기 — 반짝이 대비 배율")]
	private float dragTrailGlowScale; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Range(0, 0.8)]
	[SerializeField]
	[Token(Token = "0x4000058")]
	[Tooltip("반짝이 가운데 흰 심지 크기 — 반짝이 대비 비율. 가운데만 하얗게 빛나고 가장자리는 칸 색 계열로 남는다. 0이면 끔")]
	private float dragTrailCore; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Header("색각 보조(설정의 영역 테두리/패턴 토글)")]
	[SerializeField]
	[Token(Token = "0x4000059")]
	[Tooltip("영역 테두리 색 — 모든 구역 색 위에서 또렷한 어두운 계열")]
	private Color assistBorderColor; //Field offset: 0x11C
	[FieldOffset(Offset = "0x12C")]
	[SerializeField]
	[Token(Token = "0x400005A")]
	[Tooltip("구역 경계(두꺼운 선) 두께 — 칸 간격의 배수. 간격을 채우고 타일 가장자리를 살짝 덮는다")]
	private float assistThickScale; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	[Token(Token = "0x400005B")]
	[Tooltip("같은 구역 칸 사이(얇은 선) 두께 — 칸 간격의 배수. 1이면 흰 간격을 꼭 맞게 채운다")]
	private float assistThinScale; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[SerializeField]
	[Token(Token = "0x400005C")]
	[Tooltip("구역 경계가 꺾이는 모서리의 라운딩 반경 — 칸 간격의 배수")]
	private float assistCornerRadius; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400005D")]
	[Tooltip("패턴 진하기: 구역 색을 이 비율만큼 검정 쪽으로 어둡게 만들어 패턴 색으로 쓴다")]
	private float assistPatternDarken; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Range(0, 1)]
	[SerializeField]
	[Token(Token = "0x400005E")]
	[Tooltip("패턴 불투명도 — 잔잔한 톤온톤이 목표(눈에 확 띄지 않게)")]
	private float assistPatternAlpha; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x400005F")]
	private GridLayoutGroup _grid; //Field offset: 0x140
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x4000060")]
	private CellView[,] _cells; //Field offset: 0x148
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x4000061")]
	private readonly List<CellView> _pool; //Field offset: 0x150
	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x4000062")]
	private Board _board; //Field offset: 0x158
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x4000063")]
	private int[] _regionPaletteMap; //Field offset: 0x160
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x4000064")]
	private bool _assistBorderOn; //Field offset: 0x168
	[FieldOffset(Offset = "0x169")]
	[Token(Token = "0x4000065")]
	private bool _assistPatternOn; //Field offset: 0x169
	[CompilerGenerated]
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x4000066")]
	private Action<int, int> CellTapped; //Field offset: 0x170
	[CompilerGenerated]
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x4000067")]
	private Action<int, int> CellDoubleTapped; //Field offset: 0x178
	[CompilerGenerated]
	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x4000068")]
	private Action<int, int, bool> CellDragPainted; //Field offset: 0x180
	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x4000069")]
	private DragSparkleTrail _trail; //Field offset: 0x188
	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x400006A")]
	private float _trailNext; //Field offset: 0x190
	[FieldOffset(Offset = "0x194")]
	[Token(Token = "0x400006B")]
	private float _trailPath; //Field offset: 0x194
	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x400006C")]
	private float _trailSeed; //Field offset: 0x198
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x400006D")]
	private float _trailLastTime; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x400006F")]
	private Coroutine _shakeFx; //Field offset: 0x1A0
	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x4000070")]
	private Vector2 _shakeOrigin; //Field offset: 0x1A8
	[CompilerGenerated]
	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x4000071")]
	private float <CellCornerScale>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	[FieldOffset(Offset = "0x1B4")]
	[Token(Token = "0x4000072")]
	private float <CellSpacingScale>k__BackingField; //Field offset: 0x1B4
	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x4000073")]
	private Vector2 _baseSpacing; //Field offset: 0x1B8
	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x4000075")]
	private Sprite _hypoCached; //Field offset: 0x1C0
	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x4000076")]
	private bool _hypoLoaded; //Field offset: 0x1C8
	[FieldOffset(Offset = "0x1C9")]
	[Token(Token = "0x4000077")]
	private bool _refitting; //Field offset: 0x1C9
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x4000078")]
	private float _assistCellSize; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Range(0, 0.6)]
	[SerializeField]
	[Token(Token = "0x4000079")]
	private float colorNameDarken; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x400007A")]
	private RawImage _assistOverlay; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x400007B")]
	private Texture2D _assistTex; //Field offset: 0x1E0
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x400007C")]
	private Color32[] _assistPixels; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x400007D")]
	private Coroutine _assistFade; //Field offset: 0x1F0

	[Token(Token = "0x14000003")]
	public event Action<int, int> CellDoubleTapped
	{
		[Address(RVA = "0x33D3EB4", Offset = "0x33D3EB4", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000025")]
		 add { } //Length: 176
		[Address(RVA = "0x33D3F64", Offset = "0x33D3F64", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000026")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x14000004")]
	public event Action<int, int, bool> CellDragPainted
	{
		[Address(RVA = "0x33D4014", Offset = "0x33D4014", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000027")]
		 add { } //Length: 176
		[Address(RVA = "0x33D40C4", Offset = "0x33D40C4", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000028")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x14000002")]
	public event Action<int, int> CellTapped
	{
		[Address(RVA = "0x33D3D54", Offset = "0x33D3D54", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000023")]
		 add { } //Length: 176
		[Address(RVA = "0x33D3E04", Offset = "0x33D3E04", Length = "0xB0")]
		[CompilerGenerated]
		[Token(Token = "0x6000024")]
		 remove { } //Length: 176
	}

	[Token(Token = "0x17000002")]
	public float AppearStagger
	{
		[Address(RVA = "0x33D3CC0", Offset = "0x33D3CC0", Length = "0x8")]
		[Token(Token = "0x6000020")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000008")]
	public float CellCornerRatio
	{
		[Address(RVA = "0x33D7EEC", Offset = "0x33D7EEC", Length = "0x98")]
		[Token(Token = "0x6000051")]
		 get { } //Length: 152
	}

	[Token(Token = "0x17000009")]
	public float CellCornerScale
	{
		[Address(RVA = "0x33D8068", Offset = "0x33D8068", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000052")]
		 get { } //Length: 8
		[Address(RVA = "0x33D8070", Offset = "0x33D8070", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000053")]
		 set { } //Length: 8
	}

	[Token(Token = "0x1700000A")]
	public float CellSpacingScale
	{
		[Address(RVA = "0x33D8078", Offset = "0x33D8078", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000054")]
		 get { } //Length: 8
		[Address(RVA = "0x33D8080", Offset = "0x33D8080", Length = "0x8")]
		[CompilerGenerated]
		[Token(Token = "0x6000055")]
		 set { } //Length: 8
	}

	[Token(Token = "0x1700000D")]
	public float CrossLengthRatio
	{
		[Address(RVA = "0x33D8500", Offset = "0x33D8500", Length = "0x84")]
		[Token(Token = "0x600005B")]
		 get { } //Length: 132
	}

	[Token(Token = "0x1700000E")]
	public float CrossThicknessRatio
	{
		[Address(RVA = "0x33D8584", Offset = "0x33D8584", Length = "0x84")]
		[Token(Token = "0x600005C")]
		 get { } //Length: 132
	}

	[Token(Token = "0x1700000C")]
	public bool HasHypotheticalArt
	{
		[Address(RVA = "0x33D8494", Offset = "0x33D8494", Length = "0x6C")]
		[Token(Token = "0x600005A")]
		 get { } //Length: 108
	}

	[Token(Token = "0x1700000B")]
	private Sprite HypoArt
	{
		[Address(RVA = "0x33D83CC", Offset = "0x33D83CC", Length = "0xC8")]
		[Token(Token = "0x6000059")]
		 get { } //Length: 200
	}

	[Token(Token = "0x17000006")]
	public bool LineWaveEnabled
	{
		[Address(RVA = "0x33D7558", Offset = "0x33D7558", Length = "0x24")]
		[Token(Token = "0x6000045")]
		 get { } //Length: 36
	}

	[Token(Token = "0x17000003")]
	public static float MistakeFxDuration
	{
		[Address(RVA = "0x33D6AC4", Offset = "0x33D6AC4", Length = "0xC")]
		[Token(Token = "0x6000038")]
		 get { } //Length: 12
	}

	[Token(Token = "0x17000004")]
	public static float MistakeSplitAt
	{
		[Address(RVA = "0x33D6AD0", Offset = "0x33D6AD0", Length = "0xC")]
		[Token(Token = "0x6000039")]
		 get { } //Length: 12
	}

	[Token(Token = "0x17000007")]
	public bool RegionRippleEnabled
	{
		[Address(RVA = "0x33D7950", Offset = "0x33D7950", Length = "0x24")]
		[Token(Token = "0x6000048")]
		 get { } //Length: 36
	}

	[Token(Token = "0x17000005")]
	public static bool Shaking
	{
		[Address(RVA = "0x33D7030", Offset = "0x33D7030", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x600003D")]
		 get { } //Length: 72
		[Address(RVA = "0x33D7078", Offset = "0x33D7078", Length = "0x50")]
		[CompilerGenerated]
		[Token(Token = "0x600003E")]
		private set { } //Length: 80
	}

	[Address(RVA = "0x33DA650", Offset = "0x33DA650", Length = "0x1A4")]
	[Token(Token = "0x6000071")]
	public BoardView() { }

	[Address(RVA = "0x33DA7F4", Offset = "0x33DA7F4", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x6000075")]
	internal static bool <DrawAssistLines>g__ArmDown|182_3(int rr, int cc, ref <>c__DisplayClass182_0 unnamed_param_2) { }

	[Address(RVA = "0x33DA4D4", Offset = "0x33DA4D4", Length = "0x4C")]
	[CompilerGenerated]
	[Token(Token = "0x6000076")]
	internal static bool <DrawAssistLines>g__ArmLeft|182_4(int rr, int cc, ref <>c__DisplayClass182_0 unnamed_param_2) { }

	[Address(RVA = "0x33DA844", Offset = "0x33DA844", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x6000077")]
	internal static bool <DrawAssistLines>g__ArmRight|182_5(int rr, int cc, ref <>c__DisplayClass182_0 unnamed_param_2) { }

	[Address(RVA = "0x33DA520", Offset = "0x33DA520", Length = "0x4C")]
	[CompilerGenerated]
	[Token(Token = "0x6000074")]
	internal static bool <DrawAssistLines>g__ArmUp|182_2(int rr, int cc, ref <>c__DisplayClass182_0 unnamed_param_2) { }

	[Address(RVA = "0x33DA0F8", Offset = "0x33DA0F8", Length = "0xE4")]
	[CompilerGenerated]
	[Token(Token = "0x6000078")]
	internal static bool <DrawAssistLines>g__IsElbow|182_6(int rr, int cc, ref <>c__DisplayClass182_0 unnamed_param_2) { }

	[Address(RVA = "0x33DA0D0", Offset = "0x33DA0D0", Length = "0x14")]
	[CompilerGenerated]
	[Token(Token = "0x6000072")]
	internal static float <DrawAssistLines>g__TileX|182_0(int c, ref <>c__DisplayClass182_0 unnamed_param_1) { }

	[Address(RVA = "0x33DA0E4", Offset = "0x33DA0E4", Length = "0x14")]
	[CompilerGenerated]
	[Token(Token = "0x6000073")]
	internal static float <DrawAssistLines>g__TileY|182_1(int r, ref <>c__DisplayClass182_0 unnamed_param_1) { }

	[Address(RVA = "0x33D3EB4", Offset = "0x33D3EB4", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000025")]
	public void add_CellDoubleTapped(Action<int, int> value) { }

	[Address(RVA = "0x33D4014", Offset = "0x33D4014", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000027")]
	public void add_CellDragPainted(Action<int, int, bool> value) { }

	[Address(RVA = "0x33D3D54", Offset = "0x33D3D54", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000023")]
	public void add_CellTapped(Action<int, int> value) { }

	[Address(RVA = "0x33D527C", Offset = "0x33D527C", Length = "0x164")]
	[Token(Token = "0x600006A")]
	private void ApplyPattern(CellView view, int regionId) { }

	[Address(RVA = "0x33D4174", Offset = "0x33D4174", Length = "0x104")]
	[Token(Token = "0x6000029")]
	private void Awake() { }

	[Address(RVA = "0x33D4278", Offset = "0x33D4278", Length = "0x720")]
	[Token(Token = "0x600002A")]
	public void Build(Board board) { }

	[Address(RVA = "0x33D6F60", Offset = "0x33D6F60", Length = "0x1C")]
	[Token(Token = "0x600003C")]
	public void CancelTapWindow(int row, int col) { }

	[Address(RVA = "0x33D6964", Offset = "0x33D6964", Length = "0xB4")]
	[Token(Token = "0x6000050")]
	private CellView CellAt(int row, int col) { }

	[Address(RVA = "0x33D6168", Offset = "0x33D6168", Length = "0x258")]
	[Token(Token = "0x6000033")]
	public CellView CellAtScreenPoint(Vector2 screenPos, Camera cam) { }

	[Address(RVA = "0x33D815C", Offset = "0x33D815C", Length = "0xAC")]
	[Token(Token = "0x6000057")]
	public Color CellColor(int row, int col) { }

	[Address(RVA = "0x33D8774", Offset = "0x33D8774", Length = "0xAC")]
	[Token(Token = "0x600005E")]
	public RectTransform CellHamsterRect(int row, int col) { }

	[Address(RVA = "0x33D8298", Offset = "0x33D8298", Length = "0xAC")]
	[Token(Token = "0x6000058")]
	public Sprite CellHamsterSprite(int row, int col) { }

	[Address(RVA = "0x33D5F2C", Offset = "0x33D5F2C", Length = "0x23C")]
	[Token(Token = "0x6000034")]
	public float CellPitchScreen(Camera cam) { }

	[Address(RVA = "0x33D8088", Offset = "0x33D8088", Length = "0xD4")]
	[Token(Token = "0x6000056")]
	public RectTransform CellRect(int row, int col) { }

	[Address(RVA = "0x33D66CC", Offset = "0x33D66CC", Length = "0x1BC")]
	[Token(Token = "0x6000035")]
	private Vector2 CellStepLocal(int n) { }

	[Address(RVA = "0x33D7D18", Offset = "0x33D7D18", Length = "0x4")]
	[Token(Token = "0x600004E")]
	public void ClearFocus() { }

	[Address(RVA = "0x33D4DA4", Offset = "0x33D4DA4", Length = "0x54")]
	[Token(Token = "0x6000064")]
	private Color ColorForRegion(int regionId) { }

	[Address(RVA = "0x33D8C34", Offset = "0x33D8C34", Length = "0x1E8")]
	[Token(Token = "0x6000066")]
	public string ColorNameFor(int regionId) { }

	[Address(RVA = "0x33DA56C", Offset = "0x33DA56C", Length = "0xE4")]
	[Token(Token = "0x600006F")]
	private void DrawArc(float cornerX, float cornerY, float ux1, float uy1, float ux2, float uy2, float radius, float half) { }

	[Address(RVA = "0x33D9604", Offset = "0x33D9604", Length = "0xA24")]
	[Token(Token = "0x600006E")]
	private void DrawAssistLines(int n, float cell, float g, float margin, float total) { }

	[Address(RVA = "0x33DA1DC", Offset = "0x33DA1DC", Length = "0x2F8")]
	[Token(Token = "0x6000070")]
	private void DrawCapsule(float x1, float y1, float x2, float y2, float half) { }

	[Address(RVA = "0x33D58EC", Offset = "0x33D58EC", Length = "0x640")]
	[Token(Token = "0x600002F")]
	public void EmitDragTrail(Vector2 from, Vector2 to, Camera cam, bool erase) { }

	[Address(RVA = "0x33D6434", Offset = "0x33D6434", Length = "0x1F0")]
	[Token(Token = "0x6000030")]
	private void EmitTrailPiece(Vector2 center, Color color, Vector2 dir, float pitchLocal, float age, float sizeMul) { }

	[Address(RVA = "0x33D93E4", Offset = "0x33D93E4", Length = "0x220")]
	[Token(Token = "0x600006D")]
	private void EnsureAssistOverlay() { }

	[Address(RVA = "0x33DA028", Offset = "0x33DA028", Length = "0x80")]
	[IteratorStateMachine(typeof(<FadeAssistIn>d__180))]
	[Token(Token = "0x600006C")]
	private IEnumerator FadeAssistIn(float delay, float dur) { }

	[Address(RVA = "0x33D3CC0", Offset = "0x33D3CC0", Length = "0x8")]
	[Token(Token = "0x6000020")]
	public float get_AppearStagger() { }

	[Address(RVA = "0x33D7EEC", Offset = "0x33D7EEC", Length = "0x98")]
	[Token(Token = "0x6000051")]
	public float get_CellCornerRatio() { }

	[Address(RVA = "0x33D8068", Offset = "0x33D8068", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000052")]
	public float get_CellCornerScale() { }

	[Address(RVA = "0x33D8078", Offset = "0x33D8078", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000054")]
	public float get_CellSpacingScale() { }

	[Address(RVA = "0x33D8500", Offset = "0x33D8500", Length = "0x84")]
	[Token(Token = "0x600005B")]
	public float get_CrossLengthRatio() { }

	[Address(RVA = "0x33D8584", Offset = "0x33D8584", Length = "0x84")]
	[Token(Token = "0x600005C")]
	public float get_CrossThicknessRatio() { }

	[Address(RVA = "0x33D8494", Offset = "0x33D8494", Length = "0x6C")]
	[Token(Token = "0x600005A")]
	public bool get_HasHypotheticalArt() { }

	[Address(RVA = "0x33D83CC", Offset = "0x33D83CC", Length = "0xC8")]
	[Token(Token = "0x6000059")]
	private Sprite get_HypoArt() { }

	[Address(RVA = "0x33D7558", Offset = "0x33D7558", Length = "0x24")]
	[Token(Token = "0x6000045")]
	public bool get_LineWaveEnabled() { }

	[Address(RVA = "0x33D6AC4", Offset = "0x33D6AC4", Length = "0xC")]
	[Token(Token = "0x6000038")]
	public static float get_MistakeFxDuration() { }

	[Address(RVA = "0x33D6AD0", Offset = "0x33D6AD0", Length = "0xC")]
	[Token(Token = "0x6000039")]
	public static float get_MistakeSplitAt() { }

	[Address(RVA = "0x33D7950", Offset = "0x33D7950", Length = "0x24")]
	[Token(Token = "0x6000048")]
	public bool get_RegionRippleEnabled() { }

	[Address(RVA = "0x33D7030", Offset = "0x33D7030", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x600003D")]
	public static bool get_Shaking() { }

	[Address(RVA = "0x33D8608", Offset = "0x33D8608", Length = "0xE4")]
	[Token(Token = "0x600005D")]
	public Sprite HypotheticalHamsterSprite(int row, int col) { }

	[Address(RVA = "0x33D3CC8", Offset = "0x33D3CC8", Length = "0x68")]
	[Token(Token = "0x6000021")]
	public float IntroDuration(int n) { }

	[Address(RVA = "0x33D3D30", Offset = "0x33D3D30", Length = "0x24")]
	[Token(Token = "0x6000022")]
	private float LastAppearStart(int n) { }

	[Address(RVA = "0x33D4998", Offset = "0x33D4998", Length = "0x1FC")]
	[Token(Token = "0x6000063")]
	private void LayoutGrid(int size, bool forceUpdate = true) { }

	[Address(RVA = "0x33D757C", Offset = "0x33D757C", Length = "0x40")]
	[Token(Token = "0x6000046")]
	public float LineWaveDuration(int n) { }

	[Address(RVA = "0x33D9134", Offset = "0x33D9134", Length = "0x20")]
	[Token(Token = "0x6000068")]
	private static string NameOrNull(string localized, string key) { }

	[Address(RVA = "0x33D5854", Offset = "0x33D5854", Length = "0x2C")]
	[Token(Token = "0x600002C")]
	private void OnCellDoubleTapped(CellView v) { }

	[Address(RVA = "0x33D5880", Offset = "0x33D5880", Length = "0x34")]
	[Token(Token = "0x600002D")]
	private void OnCellDragPainted(CellView v, bool erase) { }

	[Address(RVA = "0x33D5828", Offset = "0x33D5828", Length = "0x2C")]
	[Token(Token = "0x600002B")]
	private void OnCellTapped(CellView v) { }

	[Address(RVA = "0x33D6624", Offset = "0x33D6624", Length = "0xA8")]
	[Token(Token = "0x6000032")]
	private void OnDestroy() { }

	[Address(RVA = "0x33D8B24", Offset = "0x33D8B24", Length = "0xBC")]
	[Token(Token = "0x6000061")]
	private void OnRectTransformDimensionsChange() { }

	[Address(RVA = "0x33D8BE0", Offset = "0x33D8BE0", Length = "0x54")]
	[Token(Token = "0x6000065")]
	private int PaletteIndexFor(int regionId) { }

	[Address(RVA = "0x33D74E8", Offset = "0x33D74E8", Length = "0x44")]
	[Token(Token = "0x6000044")]
	public void PlayAutoCrossGlow(int row, int col, float delay = 0) { }

	[Address(RVA = "0x33D7BB0", Offset = "0x33D7BB0", Length = "0xD4")]
	[Token(Token = "0x600004C")]
	public void PlayHamstersCelebrate() { }

	[Address(RVA = "0x33D6C10", Offset = "0x33D6C10", Length = "0xD4")]
	[Token(Token = "0x600004B")]
	public void PlayHamstersWrong() { }

	[Address(RVA = "0x33D75BC", Offset = "0x33D75BC", Length = "0x244")]
	[Token(Token = "0x6000047")]
	public void PlayLineWave(bool isRow, int index, int origin = 0) { }

	[Address(RVA = "0x33D6ADC", Offset = "0x33D6ADC", Length = "0x134")]
	[Token(Token = "0x600003A")]
	public void PlayMistake(MistakeInfo info) { }

	[Address(RVA = "0x33D6A18", Offset = "0x33D6A18", Length = "0x1C")]
	[Token(Token = "0x6000037")]
	public void PlayMistakeAt(int row, int col) { }

	[Address(RVA = "0x33D7298", Offset = "0x33D7298", Length = "0x1C")]
	[Token(Token = "0x6000042")]
	public void PlayPlaceAt(int row, int col) { }

	[Address(RVA = "0x33D79B4", Offset = "0x33D79B4", Length = "0x1FC")]
	[Token(Token = "0x600004A")]
	public void PlayRegionRipple(int row, int col) { }

	[Address(RVA = "0x33D7108", Offset = "0x33D7108", Length = "0xE8")]
	[Token(Token = "0x6000040")]
	public void PlayShake(float amplitude = 9, float duration = 0.26) { }

	[Address(RVA = "0x33D7390", Offset = "0x33D7390", Length = "0x158")]
	[Token(Token = "0x6000043")]
	public void PlaySparkleAt(int row, int col) { }

	[Address(RVA = "0x33D8E1C", Offset = "0x33D8E1C", Length = "0x318")]
	[Token(Token = "0x6000067")]
	private string RawColorNameFor(int regionId) { }

	[Address(RVA = "0x33D8A24", Offset = "0x33D8A24", Length = "0xBC")]
	[Token(Token = "0x6000060")]
	public void Refit() { }

	[Address(RVA = "0x33D8AE0", Offset = "0x33D8AE0", Length = "0x44")]
	[Token(Token = "0x6000062")]
	private void RefreshAssistOnResize() { }

	[Address(RVA = "0x33D7974", Offset = "0x33D7974", Length = "0x40")]
	[Token(Token = "0x6000049")]
	public float RegionRippleDuration(int n) { }

	[Address(RVA = "0x33D3F64", Offset = "0x33D3F64", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000026")]
	public void remove_CellDoubleTapped(Action<int, int> value) { }

	[Address(RVA = "0x33D40C4", Offset = "0x33D40C4", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000028")]
	public void remove_CellDragPainted(Action<int, int, bool> value) { }

	[Address(RVA = "0x33D3E04", Offset = "0x33D3E04", Length = "0xB0")]
	[CompilerGenerated]
	[Token(Token = "0x6000024")]
	public void remove_CellTapped(Action<int, int> value) { }

	[Address(RVA = "0x33D58B4", Offset = "0x33D58B4", Length = "0x38")]
	[Token(Token = "0x600002E")]
	public void ResetDragTrail() { }

	[Address(RVA = "0x33D70C8", Offset = "0x33D70C8", Length = "0x40")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x600003F")]
	private static void ResetShaking() { }

	[Address(RVA = "0x33D8070", Offset = "0x33D8070", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000053")]
	public void set_CellCornerScale(float value) { }

	[Address(RVA = "0x33D8080", Offset = "0x33D8080", Length = "0x8")]
	[CompilerGenerated]
	[Token(Token = "0x6000055")]
	public void set_CellSpacingScale(float value) { }

	[Address(RVA = "0x33D7078", Offset = "0x33D7078", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x600003E")]
	private static void set_Shaking(bool value) { }

	[Address(RVA = "0x33D6888", Offset = "0x33D6888", Length = "0xDC")]
	[Token(Token = "0x6000036")]
	public void SetCellMark(int row, int col, CellMark mark) { }

	[Address(RVA = "0x33D9154", Offset = "0x33D9154", Length = "0x144")]
	[Token(Token = "0x6000069")]
	public void SetColorAssist(bool borderOn, bool patternOn) { }

	[Address(RVA = "0x33D7D14", Offset = "0x33D7D14", Length = "0x4")]
	[Token(Token = "0x600004D")]
	public void SetFocus(bool[,] mask) { }

	[Address(RVA = "0x33D88D0", Offset = "0x33D88D0", Length = "0xBC")]
	[Token(Token = "0x600005F")]
	public void SetHamsterVisible(int row, int col, bool visible) { }

	[Address(RVA = "0x33D7D1C", Offset = "0x33D7D1C", Length = "0xE8")]
	[Token(Token = "0x600004F")]
	public void SetHint(bool[,] mask) { }

	[Address(RVA = "0x33D71F0", Offset = "0x33D71F0", Length = "0x80")]
	[IteratorStateMachine(typeof(<ShakeRoutine>d__114))]
	[Token(Token = "0x6000041")]
	private IEnumerator ShakeRoutine(float amp, float dur) { }

	[Address(RVA = "0x33D6E24", Offset = "0x33D6E24", Length = "0x1C")]
	[Token(Token = "0x600003B")]
	public void ShowMistakeAt(int row, int col) { }

	[Address(RVA = "0x33D63C0", Offset = "0x33D63C0", Length = "0x74")]
	[Token(Token = "0x6000031")]
	private Color TrailColor(Color region) { }

	[Address(RVA = "0x33D5504", Offset = "0x33D5504", Length = "0x324")]
	[Token(Token = "0x600006B")]
	private void UpdateAssistOverlay(bool fadeIn) { }

}

