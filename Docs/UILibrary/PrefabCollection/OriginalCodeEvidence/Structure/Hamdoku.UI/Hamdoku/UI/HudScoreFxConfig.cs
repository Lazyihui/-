namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "HudScoreFxConfig", menuName = "Hamdoku/Hud Score Fx Config")]
[Token(Token = "0x200006F")]
public sealed class HudScoreFxConfig : ScriptableObject
{
	[Token(Token = "0x2000070")]
	public sealed class ColorStop
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000629")]
		[Tooltip("이 점수에서 정확히 이 색. 오름차순으로 적는다")]
		public int score; //Field offset: 0x10
		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x400062A")]
		public Color color; //Field offset: 0x14
		[FieldOffset(Offset = "0x24")]
		[Token(Token = "0x400062B")]
		[Tooltip("이 정지점의 반짝이 색. 알파 0이면 자동(숫자 색보다 명도·채도를 sparkleBrighten/Saturate만큼 올린 색). 정지점 사이는 보간")]
		public Color sparkleColor; //Field offset: 0x24

		[Address(RVA = "0x3407748", Offset = "0x3407748", Length = "0x24")]
		[Token(Token = "0x6000335")]
		public ColorStop() { }

	}

	[Token(Token = "0x4000628")]
	private static HudScoreFxConfig _inst; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("점수 → 숫자 색 정지점(오름차순). 첫 정지점 미만은 기본 색·연출 없음, 경계에서 다음 색으로")]
	[Token(Token = "0x4000609")]
	public ColorStop[] stops; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Header("색 전환")]
	[Token(Token = "0x400060A")]
	[Tooltip("켜면 정지점 사이를 1점 단위로 섞는다. 끄면(기본) 경계 점수에서 다음 색으로 바뀌고 그 사이는 그 색 유지(2026-10-05 확정)")]
	public bool blendBetweenStops; //Field offset: 0x20
	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x400060B")]
	[Tooltip("섞을 때 색상환(HSV)으로 돈다. 끄면 RGB 직선 보간 → 파랑↔주황처럼 보색 사이가 회색으로 물이 빠진다")]
	public bool hsvBlend; //Field offset: 0x21
	[FieldOffset(Offset = "0x24")]
	[Range(0, 1.5)]
	[Token(Token = "0x400060C")]
	[Tooltip("색이 바뀔 때(경계 통과·강조 진입/이탈) 넘어가는 시간(초, 실시간). 1점 단위 섞기 중에는 즉시")]
	public float colorTweenDuration; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Range(0, 12)]
	[Token(Token = "0x400060D")]
	[Tooltip("정지점을 위로 통과하는 순간 양옆에서 한꺼번에 터지는 반짝이 수(한쪽 기준, 0=끔)")]
	public int milestoneBurstCount; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Header("반짝이 — 양옆에서 바깥으로 퍼짐(반복)")]
	[Range(0, 12)]
	[Token(Token = "0x400060E")]
	[Tooltip("한쪽에 동시에 떠 있을 수 있는 최대 개수(풀 크기). 0이면 반짝이 끔")]
	public int sparklePerSide; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Range(0, 1)]
	[Token(Token = "0x400060F")]
	[Tooltip("자동 반짝이 색: 숫자 색보다 명도(V)를 이만큼 올린다(0=그대로, 0.25=25% 밝게). 빛나는 느낌은 숫자보다 밝아야 난다")]
	public float sparkleBrighten; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Range(0, 1)]
	[Token(Token = "0x4000610")]
	[Tooltip("자동 반짝이 색: 숫자 색보다 채도(S)를 이만큼 올린다(0=그대로). 흰색 섞기와 달리 색이 바래지 않는다")]
	public float sparkleSaturate; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000611")]
	[Tooltip("다음 반짝이가 나오기까지 쉬는 시간 범위(초). 좁게 주면 촘촘히 나온다")]
	public Vector2 sparkleInterval; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000612")]
	[Tooltip("반짝이 하나의 수명 범위(초). 퍼지는 속도 = 이동 거리 ÷ 수명 → 느리게 하려면 수명을 늘린다")]
	public Vector2 sparkleLife; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Range(0, 1)]
	[Token(Token = "0x4000613")]
	[Tooltip("퍼지는 속도 곡선. 0=일정한 속도, 1=출발 때 빠르고 멀어질수록 급히 느려짐")]
	public float travelEase; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000614")]
	[Tooltip("4포인트 별 크기 범위(px). 스프라이트 팔 끝은 흐려서 체감 크기는 이 값의 6~7할")]
	public Vector2 sparkleSize; //Field offset: 0x4C
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4000615")]
	[Tooltip("숫자 가장자리에서 바깥으로 이동하는 거리 범위(px)")]
	public Vector2 sparkleTravel; //Field offset: 0x54
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000616")]
	[Tooltip("출발점: 숫자 가장자리에서 바깥으로 띄우는 거리(px)")]
	public float sparkleStartInset; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Range(0, 1.5)]
	[Token(Token = "0x4000617")]
	[Tooltip("세로 흩어짐 = 숫자 높이 × 이 배율(위아래 합). 0이면 가운데 한 줄")]
	public float sparkleYSpread; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Range(0, 1)]
	[Token(Token = "0x4000618")]
	[Tooltip("별 대신 작은 원형 점으로 나올 확률(레퍼런스의 점·별 섞임)")]
	public float dotChance; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000619")]
	[Tooltip("작은 원형 점 크기 범위(px)")]
	public Vector2 dotSize; //Field offset: 0x68
	[FieldOffset(Offset = "0x70")]
	[Range(0.1, 0.95)]
	[Token(Token = "0x400061A")]
	[Tooltip("원형 점의 또렷한 중심 비율(0.9=거의 선명한 원, 0.3=뿌연 빛 알갱이)")]
	public float dotCore; //Field offset: 0x70
	[FieldOffset(Offset = "0x74")]
	[Range(0, 1)]
	[Token(Token = "0x400061B")]
	[Tooltip("원형 점 밝기 배율(별 대비). 점은 면이 꽉 차서 같은 알파면 별보다 진해 보인다 → 낮춰서 맞춘다")]
	public float dotAlpha; //Field offset: 0x74
	[FieldOffset(Offset = "0x78")]
	[Header("반짝이 종류 섞기(레퍼런스 9728: 흰 속+색 테두리 별 / 연한 채움 별 / 색 점)")]
	[Range(0, 1)]
	[Token(Token = "0x400061C")]
	[Tooltip("별 중에서 '속은 흰색, 테두리만 색' 별이 나올 확률(나머지 별은 색 채움)")]
	public float outlineChance; //Field offset: 0x78
	[FieldOffset(Offset = "0x7C")]
	[Range(0.3, 1.5)]
	[Token(Token = "0x400061D")]
	[Tooltip("테두리 별 크기 배율(sparkleSize 기준). 채움 별보다 커 보이면 내린다")]
	public float outlineStarScale; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Range(0.05, 0.4)]
	[Token(Token = "0x400061E")]
	[Tooltip("테두리 별의 테두리 두께(별 반경 대비 비율, 경계에서 안쪽으로·팔 끝까지 균일). 바꾸면 다음 판부터 적용")]
	public float outlineWidth; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Range(0, 1)]
	[Token(Token = "0x400061F")]
	[Tooltip("테두리 색 = 반짝이 색보다 채도를 이만큼 더 올림(테두리는 더 진하게)")]
	public float outlineSaturate; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000620")]
	[Tooltip("테두리 색 = 반짝이 색보다 명도를 이만큼 내림(0=그대로)")]
	public float outlineDarken; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Range(0, 1)]
	[Token(Token = "0x4000621")]
	[Tooltip("채움 별 색 = 반짝이 색을 흰색 쪽으로 이만큼 연하게(채움은 더 흐리게)")]
	public float fillFade; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Range(0, 0.5)]
	[Token(Token = "0x4000622")]
	[Tooltip("점 색상을 색상환에서 이만큼(±, 1=한 바퀴) 흩뿌린다 — 레퍼런스의 보라·하늘·노랑 점. 0이면 반짝이 색 그대로")]
	public float dotHueJitter; //Field offset: 0x90
	[FieldOffset(Offset = "0x94")]
	[Header("깜빡임(트윙클) — 떠 있는 동안 밝기·크기가 떨린다")]
	[Range(0, 20)]
	[Token(Token = "0x4000623")]
	[Tooltip("초당 깜빡이는 횟수(0=깜빡임 없음, 매끈한 페이드만)")]
	public float twinkleHz; //Field offset: 0x94
	[FieldOffset(Offset = "0x98")]
	[Range(0, 1)]
	[Token(Token = "0x4000624")]
	[Tooltip("깜빡임 깊이(0=없음, 1=완전히 꺼졌다 켜짐)")]
	public float twinkleDepth; //Field offset: 0x98
	[FieldOffset(Offset = "0x9C")]
	[Range(0, 0.6)]
	[Token(Token = "0x4000625")]
	[Tooltip("깜빡일 때 크기도 함께 떨리는 폭(0=크기 고정, 0.3=±30%)")]
	public float twinkleScale; //Field offset: 0x9C
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000626")]
	[Tooltip("수명 동안 도는 회전량 범위(도)")]
	public Vector2 sparkleSpin; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA8")]
	[Range(0, 1)]
	[Token(Token = "0x4000627")]
	[Tooltip("최대 밝기(알파). 숫자가 진한 배경 위면 낮춰도 된다")]
	public float sparkleAlpha; //Field offset: 0xA8

	[Token(Token = "0x17000089")]
	public int StartScore
	{
		[Address(RVA = "0x3406D14", Offset = "0x3406D14", Length = "0x4C")]
		[Token(Token = "0x600032D")]
		 get { } //Length: 76
	}

	[Address(RVA = "0x3407438", Offset = "0x3407438", Length = "0x310")]
	[Token(Token = "0x6000334")]
	public HudScoreFxConfig() { }

	[Address(RVA = "0x3407010", Offset = "0x3407010", Length = "0x26C")]
	[Token(Token = "0x6000330")]
	private Color Blend(Color a, Color b, float t) { }

	[Address(RVA = "0x3406D14", Offset = "0x3406D14", Length = "0x4C")]
	[Token(Token = "0x600032D")]
	public int get_StartScore() { }

	[Address(RVA = "0x34072F4", Offset = "0x34072F4", Length = "0x144")]
	[Token(Token = "0x6000333")]
	public static HudScoreFxConfig Load() { }

	[Address(RVA = "0x340727C", Offset = "0x340727C", Length = "0x78")]
	[Token(Token = "0x6000332")]
	public int MilestonesCrossed(int from, int to) { }

	[Address(RVA = "0x3406F48", Offset = "0x3406F48", Length = "0xC8")]
	[Token(Token = "0x6000331")]
	private Color SparkleOf(ColorStop s) { }

	[Address(RVA = "0x3406D60", Offset = "0x3406D60", Length = "0x24")]
	[Token(Token = "0x600032E")]
	public bool TryEvaluate(int score, out Color color) { }

	[Address(RVA = "0x3406D84", Offset = "0x3406D84", Length = "0x1C4")]
	[Token(Token = "0x600032F")]
	public bool TryEvaluate(int score, out Color color, out Color sparkle) { }

}

