namespace Hamdoku.Managers;

[CreateAssetMenu(fileName = "CloudAccountConfig", menuName = "Hamdoku/Cloud Account Config")]
[Token(Token = "0x2000019")]
public sealed class CloudAccountConfig : ScriptableObject
{
	[Token(Token = "0x200001A")]
	public enum EditorPreviewMode : int
	{
		Off = 0,
		Unlinked = 1,
		Linked = 2,
	}

	[Token(Token = "0x40000C1")]
	private static Nullable<bool> _rcGoogleAutoRecover; //Field offset: 0x0
	[Token(Token = "0x40000C0")]
	public const string RcKeyDeviceHashUpload = "account_device_hash_upload"; //Field offset: 0x0
	[Token(Token = "0x40000BF")]
	public const string RcKeyDeviceRecovery = "account_device_recovery"; //Field offset: 0x0
	[Token(Token = "0x40000BE")]
	public const string RcKeyGoogleAutoRecover = "account_google_auto_recover"; //Field offset: 0x0
	[Token(Token = "0x40000C2")]
	private static Nullable<bool> _rcDeviceRecovery; //Field offset: 0x2
	[Token(Token = "0x40000C3")]
	private static Nullable<bool> _rcDeviceHashUpload; //Field offset: 0x4
	[CompilerGenerated]
	[Token(Token = "0x40000C4")]
	private static bool <RemoteReady>k__BackingField; //Field offset: 0x6
	[Token(Token = "0x40000C5")]
	private static CloudAccountConfig _instance; //Field offset: 0x8
	[FieldOffset(Offset = "0x18")]
	[Header("Google 로그인")]
	[Token(Token = "0x40000AF")]
	[Tooltip("Firebase 콘솔 Google 공급자의 웹 클라이언트 ID(OAuth client_type 3). 비우면 Android Google 연결이 꺼진다. iOS는 네이티브(GIDSignIn)가 GoogleService-Info.plist의 CLIENT_ID를 직접 읽으므로 이 값과 무관하다.")]
	public string googleWebClientId; //Field offset: 0x18
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40000B0")]
	[Tooltip("iOS에서 Google 로그인 버튼을 보인다(GoogleSignIn-iOS SPM + REVERSED_CLIENT_ID URL Scheme 후처리 필요).")]
	public bool googleIosEnabled; //Field offset: 0x20
	[FieldOffset(Offset = "0x21")]
	[Header("진행 상황 저장 팝업 — 공급자 노출(2026-10-04)")]
	[Token(Token = "0x40000B1")]
	[Tooltip("Sign in with Apple 버튼(iOS 전용). lupidan 패키지 + Apple Developer App ID의 Sign in with Apple capability + Firebase 콘솔 Apple 공급자 활성화가 선행돼야 한다. App Store 심사 4.8: 타사 로그인을 제공하면 Apple 로그인도 함께.")]
	public bool appleEnabled; //Field offset: 0x21
	[FieldOffset(Offset = "0x22")]
	[Token(Token = "0x40000B2")]
	[Tooltip("Facebook 로그인 버튼(Android·iOS). Facebook Unity SDK 임포트 + FacebookSettings(App ID·Client Token) + Firebase 콘솔 Facebook 공급자(App ID/Secret)가 선행돼야 한다. SDK가 없거나 App ID가 비면 코드가 알아서 숨긴다.")]
	public bool facebookEnabled; //Field offset: 0x22
	[FieldOffset(Offset = "0x23")]
	[Header("재설치 자동 복구(Android)")]
	[Token(Token = "0x40000B3")]
	[Tooltip("첫 실행(캐시 UID 없음)에 이전 계정 복구 체인을 돌린다(아래 두 단계의 마스터 스위치).")]
	public bool autoRecoverOnFreshInstall; //Field offset: 0x23
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40000B4")]
	[Tooltip("1단계 기기 해시 복구(recoverDevice). 서버가 App Check를 강제하므로 클라이언트에 App Check(Play Integrity)가 붙고 콘솔 등록이 끝난 뒤에만 켠다. 꺼져 있으면 호출조차 하지 않는다. [RC 키 account_device_recovery가 우선]")]
	public bool deviceRecoveryEnabled; //Field offset: 0x24
	[FieldOffset(Offset = "0x25")]
	[Token(Token = "0x40000B5")]
	[Tooltip("saveGame에 기기 해시(SHA-256 of ANDROID_ID)를 실어 서버가 기기→UID 매핑을 쌓게 한다. 서버는 App Check로 검증된 요청에서만 매핑을 기록하므로 App Check 도입과 함께 켠다. 지속 기기 식별자 파생값 수집이라 개인정보처리방침·Data Safety 반영 필요. [RC 키 account_device_hash_upload가 우선]")]
	public bool deviceHashUploadEnabled; //Field offset: 0x25
	[FieldOffset(Offset = "0x26")]
	[Token(Token = "0x40000B6")]
	[Tooltip("2단계 Google 자동 선택. 인증된 계정이 하나면 UI 없이 로그인하지만, 여럿이거나 기기 자동 로그인이 꺼져 있으면 계정 선택 화면이 뜰 수 있다. 첫 출시는 수동 연결만(꺼짐) — 경쟁 조건 수정을 실기에서 확인한 뒤 켠다. [RC 키 account_google_auto_recover가 우선]")]
	public bool googleAutoRecoverEnabled; //Field offset: 0x26
	[FieldOffset(Offset = "0x28")]
	[Range(0, 15)]
	[Token(Token = "0x40000B7")]
	[Tooltip("부트 로딩 화면이 복구 완료를 기다리는 최대 추가 시간(초). 로딩 연출용 상한이며, 계정 판정은 아래 값이 정한다.")]
	public float bootWaitMaxSeconds; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Range(3, 30)]
	[Token(Token = "0x40000B8")]
	[Tooltip("앱 시작 후 이 시간(초) 안에 복구가 결정되지 않으면 로비가 새 유저로 판정을 진행한다(늦게 온 복구는 별도 반영).")]
	public float recoveryDecisionTimeoutSeconds; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Header("연결 제안(로비 1회)")]
	[Token(Token = "0x40000B9")]
	[Tooltip("진행이 어느 정도 쌓인 미연결 유저에게 로비 진입 시 Google 계정 선택 시트를 한 번 띄운다.")]
	public bool linkPromptEnabled; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Min(0)]
	[Token(Token = "0x40000BA")]
	[Tooltip("캠페인 진행 인덱스(0 기반)가 이 값 이상일 때만 제안한다.")]
	public int linkPromptMinIndex; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Range(0, 10)]
	[Token(Token = "0x40000BB")]
	[Tooltip("로비 진입 후 이만큼 지난 뒤 제안한다(스트릭/보상 팝업과 겹치지 않게).")]
	public float linkPromptDelaySeconds; //Field offset: 0x38
	[FieldOffset(Offset = "0x3C")]
	[Header("에디터 미리보기(빌드 무시)")]
	[Token(Token = "0x40000BC")]
	[Tooltip("에디터에서만 동작. Off가 아니면 플랫폼·SDK 유무와 무관하게 설정 팝업(로비)에 진행 상황 저장 행을 보여 주고 팝업엔 Google·Apple·Facebook 버튼을 모두 그린다. Play 중 바꾸면 열린 팝업이 다시 그려진다. Unlinked에서 버튼을 탭하면 연결 성공 흐름(토스트 → 연결됨 표시)을 흉내 낸다.")]
	public EditorPreviewMode editorPreview; //Field offset: 0x3C
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40000BD")]
	[Tooltip("미리보기 Linked 상태에서 연결된 것으로 보여 줄 공급자(에디터 전용).")]
	public AccountProvider editorPreviewProvider; //Field offset: 0x40

	[Token(Token = "0x1700001C")]
	public bool DeviceHashUploadEffective
	{
		[Address(RVA = "0x31FA7AC", Offset = "0x31FA7AC", Length = "0x84")]
		[Token(Token = "0x60000C7")]
		 get { } //Length: 132
	}

	[Token(Token = "0x1700001B")]
	public bool DeviceRecoveryEffective
	{
		[Address(RVA = "0x31F7864", Offset = "0x31F7864", Length = "0x84")]
		[Token(Token = "0x60000C6")]
		 get { } //Length: 132
	}

	[Token(Token = "0x1700001A")]
	public bool GoogleAutoRecoverEffective
	{
		[Address(RVA = "0x31F78E8", Offset = "0x31F78E8", Length = "0x84")]
		[Token(Token = "0x60000C5")]
		 get { } //Length: 132
	}

	[Token(Token = "0x1700001D")]
	public static CloudAccountConfig Instance
	{
		[Address(RVA = "0x31F769C", Offset = "0x31F769C", Length = "0x13C")]
		[Token(Token = "0x60000C9")]
		 get { } //Length: 316
	}

	[Token(Token = "0x17000019")]
	public static bool RemoteReady
	{
		[Address(RVA = "0x31FA5C0", Offset = "0x31FA5C0", Length = "0x48")]
		[CompilerGenerated]
		[Token(Token = "0x60000C1")]
		 get { } //Length: 72
		[Address(RVA = "0x31FA608", Offset = "0x31FA608", Length = "0x50")]
		[CompilerGenerated]
		[Token(Token = "0x60000C2")]
		private set { } //Length: 80
	}

	[Address(RVA = "0x31FA8C4", Offset = "0x31FA8C4", Length = "0x84")]
	[Token(Token = "0x60000CA")]
	public CloudAccountConfig() { }

	[Address(RVA = "0x31FA658", Offset = "0x31FA658", Length = "0x110")]
	[Token(Token = "0x60000C3")]
	public static void ApplyRemote(bool googleAutoRecover, bool deviceRecovery, bool deviceHashUpload) { }

	[Address(RVA = "0x31FA7AC", Offset = "0x31FA7AC", Length = "0x84")]
	[Token(Token = "0x60000C7")]
	public bool get_DeviceHashUploadEffective() { }

	[Address(RVA = "0x31F7864", Offset = "0x31F7864", Length = "0x84")]
	[Token(Token = "0x60000C6")]
	public bool get_DeviceRecoveryEffective() { }

	[Address(RVA = "0x31F78E8", Offset = "0x31F78E8", Length = "0x84")]
	[Token(Token = "0x60000C5")]
	public bool get_GoogleAutoRecoverEffective() { }

	[Address(RVA = "0x31F769C", Offset = "0x31F769C", Length = "0x13C")]
	[Token(Token = "0x60000C9")]
	public static CloudAccountConfig get_Instance() { }

	[Address(RVA = "0x31FA5C0", Offset = "0x31FA5C0", Length = "0x48")]
	[CompilerGenerated]
	[Token(Token = "0x60000C1")]
	public static bool get_RemoteReady() { }

	[Address(RVA = "0x31FA768", Offset = "0x31FA768", Length = "0x44")]
	[Token(Token = "0x60000C4")]
	public static void MarkRemoteReady() { }

	[Address(RVA = "0x31FA830", Offset = "0x31FA830", Length = "0x94")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x60000C8")]
	private static void ResetStatics() { }

	[Address(RVA = "0x31FA608", Offset = "0x31FA608", Length = "0x50")]
	[CompilerGenerated]
	[Token(Token = "0x60000C2")]
	private static void set_RemoteReady(bool value) { }

}

