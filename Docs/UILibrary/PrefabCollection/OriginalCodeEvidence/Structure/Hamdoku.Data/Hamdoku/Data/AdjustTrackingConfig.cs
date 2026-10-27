namespace Hamdoku.Data;

[CreateAssetMenu(fileName = "AdjustTrackingConfig", menuName = "Hamdoku/Adjust Tracking Config")]
[Token(Token = "0x2000005")]
public sealed class AdjustTrackingConfig : ScriptableObject
{
	[Token(Token = "0x2000006")]
	public struct EventToken
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000017")]
		public string key; //Field offset: 0x0
		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4000018")]
		public string token; //Field offset: 0x8

	}

	[Token(Token = "0x4000016")]
	private static AdjustTrackingConfig _instance; //Field offset: 0x0
	[FieldOffset(Offset = "0x18")]
	[Header("App Token (Adjust 대시보드 > 앱)")]
	[Token(Token = "0x400000E")]
	[Tooltip("Adjust는 한 앱에 토큰 1개를 쓰고 플랫폼 탭에서 App Store/Google Play를 각각 등록한다. 보통 두 칸이 같은 값이다.")]
	public string androidAppToken; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400000F")]
	public string iosAppToken; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Header("환경 — 출시 빌드만 Production 체크")]
	[Token(Token = "0x4000010")]
	[Tooltip("체크 해제 시 Sandbox(테스트). Sandbox 빌드는 스토어에 제출하지 말 것.")]
	public bool useProduction; //Field offset: 0x28
	[FieldOffset(Offset = "0x29")]
	[Header("로깅")]
	[Token(Token = "0x4000011")]
	[Tooltip("Sandbox일 때만 Verbose가 켜진다. 출시 빌드에선 꺼둘 것.")]
	public bool verboseLogging; //Field offset: 0x29
	[FieldOffset(Offset = "0x2A")]
	[Header("iOS App Tracking Transparency")]
	[Token(Token = "0x4000012")]
	[Tooltip("iOS 첫 실행 시 ATT 동의 팝업 요청. 거부해도 SDK는 IDFV로 동작한다(인스톨 추적엔 무관).")]
	public bool requestAttOnLaunch; //Field offset: 0x2A
	[FieldOffset(Offset = "0x2B")]
	[Header("COPPA")]
	[Token(Token = "0x4000013")]
	[Tooltip("아동 대상(13세 미만) 앱으로 신고할 때만 체크. 켜면 광고 ID 수집이 중단돼 어트리뷰션 정확도와 광고 단가가 크게 떨어지므로, 스토어 연령 등급을 확인하고 결정할 것.")]
	public bool coppaCompliance; //Field offset: 0x2B
	[FieldOffset(Offset = "0x30")]
	[Header("이벤트 토큰 (Adjust 대시보드 > Events)")]
	[Token(Token = "0x4000014")]
	[Tooltip("인앱 구매 성공 시 발사할 매출 이벤트 토큰.")]
	public string iapPurchaseEventToken; //Field offset: 0x30
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000015")]
	[Tooltip("진행 이벤트 매핑 — key는 코드가 넘기는 식별자, token은 Adjust 이벤트 토큰. 토큰이 비면 발사하지 않는다.\n예) key=tutorial_complete, stage_5, stage_10, stage_20")]
	public EventToken[] progressionEvents; //Field offset: 0x38

	[Token(Token = "0x17000005")]
	public string CurrentAppToken
	{
		[Address(RVA = "0x31E1FF0", Offset = "0x31E1FF0", Length = "0x8")]
		[Token(Token = "0x6000008")]
		 get { } //Length: 8
	}

	[Token(Token = "0x17000006")]
	public static AdjustTrackingConfig Instance
	{
		[Address(RVA = "0x31E20C0", Offset = "0x31E20C0", Length = "0xDC")]
		[Token(Token = "0x600000A")]
		 get { } //Length: 220
	}

	[Address(RVA = "0x31E219C", Offset = "0x31E219C", Length = "0x10")]
	[Token(Token = "0x600000B")]
	public AdjustTrackingConfig() { }

	[Address(RVA = "0x31E1FF0", Offset = "0x31E1FF0", Length = "0x8")]
	[Token(Token = "0x6000008")]
	public string get_CurrentAppToken() { }

	[Address(RVA = "0x31E20C0", Offset = "0x31E20C0", Length = "0xDC")]
	[Token(Token = "0x600000A")]
	public static AdjustTrackingConfig get_Instance() { }

	[Address(RVA = "0x31E1FF8", Offset = "0x31E1FF8", Length = "0xC8")]
	[Token(Token = "0x6000009")]
	public string GetProgressionToken(string key) { }

}

