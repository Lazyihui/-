namespace Hamdoku.UI;

[CreateAssetMenu(fileName = "LoadingScreenConfig", menuName = "Hamdoku/Loading Screen Config")]
[Token(Token = "0x200007C")]
public sealed class LoadingScreenConfig : ScriptableObject
{
	[Token(Token = "0x40006AF")]
	private static LoadingScreenConfig _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("격언 문구")]
	[Range(20, 120)]
	[Token(Token = "0x400069B")]
	[Tooltip("격언 글자 크기(px). 자동 축소가 켜져 있으면 '이 값까지만 커진다'는 상한이다")]
	public float quoteFontSize; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Range(12, 120)]
	[Token(Token = "0x400069C")]
	[Tooltip("박스에 안 들어갈 때 여기까지 줄여서 맞춘다. 자동 축소가 꺼져 있으면 무시")]
	public float quoteFontSizeMin; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400069D")]
	[Tooltip("자동 축소. 켜면 박스를 넘칠 때 글자가 줄어들고, 끄면 크기를 고정하는 대신 줄이 늘어난다. 크기를 키웠는데 그대로면 박스가 좁아 축소된 것 — 아래 박스 크기를 같이 키울 것")]
	public bool quoteAutoSize; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x400069E")]
	[Tooltip("격언이 그려지는 박스 크기(px). 격언 2줄 + 출처 1줄이 들어갈 만큼은 돼야 한다")]
	public Vector2 quoteBoxSize; //Field offset: 0x24
	[FieldOffset(Offset = "0x2C")]
	[Range(0, 1)]
	[Token(Token = "0x400069F")]
	[Tooltip("세로 위치(0=화면 맨 아래, 1=맨 위). 로고는 0.585, 하트 3개는 0.28에 있다")]
	public float quoteAnchorY; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Header("출처 줄(- 햄스터 격언)")]
	[Range(30, 100)]
	[Token(Token = "0x40006A0")]
	[Tooltip("격언 대비 출처 글자 크기 비율(%)")]
	public float quoteBySizePercent; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Range(100, 300)]
	[Token(Token = "0x40006A1")]
	[Tooltip("출처 줄의 행간(%). 키우면 격언과 출처 사이가 벌어진다")]
	public float quoteLineHeightPercent; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Header("진행률 씨앗")]
	[Range(3, 10)]
	[Token(Token = "0x40006A2")]
	[Tooltip("씨앗 칸 수. 한 칸이 100/N% 를 뜻한다")]
	public int seedCount; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Range(40, 220)]
	[Token(Token = "0x40006A3")]
	[Tooltip("씨앗 한 칸 크기(px). 받침대가 없어 이 값이 곧 씨앗 높이가 된다")]
	public float seedSize; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Range(-20, 80)]
	[Token(Token = "0x40006A4")]
	[Tooltip("칸 사이 간격(px)")]
	public float seedSpacing; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Range(0, 1)]
	[Token(Token = "0x40006A5")]
	[Tooltip("씨앗 줄의 세로 위치(0=화면 맨 아래, 1=맨 위)")]
	public float seedAnchorY; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Range(1, 1.6)]
	[Token(Token = "0x40006A6")]
	[Tooltip("씨앗이 뿅 하고 튀어오를 때의 최대 배율")]
	public float seedPopScale; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Range(0.1, 1)]
	[Token(Token = "0x40006A7")]
	[Tooltip("뿅 하는 데 걸리는 시간(초)")]
	public float seedPopSeconds; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Range(0, 0.2)]
	[Token(Token = "0x40006A8")]
	[Tooltip("다음 차례 빈 칸이 숨 쉬는 폭(0이면 정지). 진행이 멈춰도 살아 있어 보이게 한다")]
	public float seedIdlePulse; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Range(0.4, 1.6)]
	[Token(Token = "0x40006A9")]
	[Tooltip("느낌표 크기 = 칸 크기 × 이 배율")]
	public float seedMarkScale; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Range(0.3, 1.4)]
	[Token(Token = "0x40006AA")]
	[Tooltip("느낌표가 칸 중심에서 위로 뜨는 거리 = 칸 크기 × 이 배율")]
	public float seedMarkY; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Range(0, 1.5)]
	[Token(Token = "0x40006AB")]
	[Tooltip("100%를 찍고 나서 화면을 넘기기까지 두는 여유(초). 0이면 마지막 씨앗이 뿅 하는 순간 화면이 넘어가 연출을 못 본다")]
	public float finishHoldSeconds; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Header("튜닝 보조 (에디터 전용 — 빌드에는 영향 없음)")]
	[Token(Token = "0x40006AC")]
	[Tooltip("켜면 로딩 화면이 Main으로 넘어가지 않고 계속 떠 있다. 끄면 즉시 진행된다")]
	public bool holdForTuning; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Range(0, 40)]
	[Token(Token = "0x40006AD")]
	[Tooltip("0이면 랜덤. 1 이상이면 그 번호(loading_msg_N) 격언으로 고정한다 — 가장 긴 격언에 맞춰야 다른 격언이 안 잘린다")]
	public int quotePreviewIndex; //Field offset: 0x64
	[FieldOffset(Offset = "0x68")]
	[Range(-1, 1)]
	[Token(Token = "0x40006AE")]
	[Tooltip("홀드 중 진행률을 이 값으로 고정한다(-1이면 실제 진행률). 60%처럼 중간 상태를 세워 놓고 씨앗 배치를 보기 위한 값")]
	public float progressOverride; //Field offset: 0x68

	[Token(Token = "0x17000090")]
	public static LoadingScreenConfig Instance
	{
		[Address(RVA = "0x340E11C", Offset = "0x340E11C", Length = "0xDC")]
		[Token(Token = "0x6000385")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x340E41C", Offset = "0x340E41C", Length = "0x6C")]
	[Token(Token = "0x6000387")]
	public LoadingScreenConfig() { }

	[Address(RVA = "0x340E11C", Offset = "0x340E11C", Length = "0xDC")]
	[Token(Token = "0x6000385")]
	public static LoadingScreenConfig get_Instance() { }

	[Address(RVA = "0x340E1F8", Offset = "0x340E1F8", Length = "0x224")]
	[Token(Token = "0x6000386")]
	public int LayoutHash() { }

}

