namespace Hamdoku.Managers;

[CreateAssetMenu(fileName = "SettingsPopupLayout", menuName = "Hamdoku/Settings Popup Layout")]
[Token(Token = "0x2000277")]
public sealed class SettingsPopupLayout : ScriptableObject
{
	[FieldOffset(Offset = "0x18")]
	[Header("패널")]
	[Token(Token = "0x4000FFF")]
	public float panelWidth; //Field offset: 0x18
	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001000")]
	public float panelPpum; //Field offset: 0x1C
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001001")]
	public float padTop; //Field offset: 0x20
	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001002")]
	public float padBottom; //Field offset: 0x24
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001003")]
	public float padSide; //Field offset: 0x28
	[FieldOffset(Offset = "0x2C")]
	[Header("타이틀/닫기")]
	[Token(Token = "0x4001004")]
	public float titleFs; //Field offset: 0x2C
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001005")]
	public float titleH; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001006")]
	public float closeSize; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001007")]
	public Vector2 closeOffset; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Header("설정 그룹(행)")]
	[Token(Token = "0x4001008")]
	public float groupPpum; //Field offset: 0x40
	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001009")]
	public float rowH; //Field offset: 0x44
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400100A")]
	public float groupPadV; //Field offset: 0x48
	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x400100B")]
	public float rowIconSize; //Field offset: 0x4C
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400100C")]
	public float rowIconX; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x400100D")]
	public float rowLabelX; //Field offset: 0x54
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400100E")]
	public float rowLabelFs; //Field offset: 0x58
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400100F")]
	public float sepThickness; //Field offset: 0x5C
	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001010")]
	public float sepInset; //Field offset: 0x60
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001011")]
	public Color sepColor; //Field offset: 0x64
	[FieldOffset(Offset = "0x74")]
	[Header("토글")]
	[Token(Token = "0x4001012")]
	public Vector2 toggleSize; //Field offset: 0x74
	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4001013")]
	public float toggleRightPad; //Field offset: 0x7C
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001014")]
	public float knobSize; //Field offset: 0x80
	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4001015")]
	public float knobInset; //Field offset: 0x84
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001016")]
	public float toggleTextFs; //Field offset: 0x88
	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001017")]
	public float toggleTextX; //Field offset: 0x8C
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001018")]
	public Color trackOnColor; //Field offset: 0x90
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001019")]
	public Color trackOffColor; //Field offset: 0xA0
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400101A")]
	public Color toggleTextColor; //Field offset: 0xB0
	[FieldOffset(Offset = "0xC0")]
	[Header("언어 행")]
	[Header("콤보 보이스 셀렉터")]
	[Token(Token = "0x400101B")]
	public Vector2 voicePillSize; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400101C")]
	public float voiceArrowSize; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x400101D")]
	public float voiceArrowInset; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400101E")]
	public float voiceValueFs; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD4")]
	[Token(Token = "0x400101F")]
	public Color voicePillColor; //Field offset: 0xD4
	[FieldOffset(Offset = "0xE4")]
	[Header("언어")]
	[Token(Token = "0x4001020")]
	public float langValueFs; //Field offset: 0xE4
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4001021")]
	public float chevronRightPad; //Field offset: 0xE8
	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4001022")]
	public float chevronSize; //Field offset: 0xEC
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4001023")]
	public float langValueGap; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4001024")]
	public Color listBgColor; //Field offset: 0xF4
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001025")]
	public Color listSelColor; //Field offset: 0x104
	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4001026")]
	public float langListW; //Field offset: 0x114
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001027")]
	public float langListYOffset; //Field offset: 0x118
	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001028")]
	public float langListItemH; //Field offset: 0x11C
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4001029")]
	public float langListFs; //Field offset: 0x120
	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x400102A")]
	public float langListPad; //Field offset: 0x124
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x400102B")]
	public int langListVisibleRows; //Field offset: 0x128
	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x400102C")]
	public float langListPeek; //Field offset: 0x12C
	[FieldOffset(Offset = "0x130")]
	[Header("진행 상황 저장 행(설정 그룹 아래, 로비에서만)")]
	[Token(Token = "0x400102D")]
	public float accountBlockH; //Field offset: 0x130
	[FieldOffset(Offset = "0x134")]
	[Token(Token = "0x400102E")]
	public float gapGroupAccount; //Field offset: 0x134
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x400102F")]
	public float accountIconSize; //Field offset: 0x138
	[FieldOffset(Offset = "0x13C")]
	[Token(Token = "0x4001030")]
	public float accountIconGap; //Field offset: 0x13C
	[FieldOffset(Offset = "0x140")]
	[Header("진행 상황 저장 팝업(ProgressSavePopup)")]
	[Token(Token = "0x4001031")]
	public float saveGapTitleBody; //Field offset: 0x140
	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x4001032")]
	public float saveMsgFs; //Field offset: 0x144
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x4001033")]
	public float saveMsgH; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x4001034")]
	public Color saveMsgColor; //Field offset: 0x14C
	[FieldOffset(Offset = "0x15C")]
	[Token(Token = "0x4001035")]
	public float saveGapMsgBtns; //Field offset: 0x15C
	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x4001036")]
	public Vector2 saveBtnSize; //Field offset: 0x160
	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x4001037")]
	public float saveBtnGap; //Field offset: 0x168
	[FieldOffset(Offset = "0x16C")]
	[Token(Token = "0x4001038")]
	public float saveBtnFs; //Field offset: 0x16C
	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x4001039")]
	public float saveBtnIconSize; //Field offset: 0x170
	[FieldOffset(Offset = "0x174")]
	[Token(Token = "0x400103A")]
	public float saveBtnIconX; //Field offset: 0x174
	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x400103B")]
	public float saveBorderW; //Field offset: 0x178
	[FieldOffset(Offset = "0x17C")]
	[Token(Token = "0x400103C")]
	public Color saveFacebookColor; //Field offset: 0x17C
	[FieldOffset(Offset = "0x18C")]
	[Token(Token = "0x400103D")]
	public Color saveGoogleColor; //Field offset: 0x18C
	[FieldOffset(Offset = "0x19C")]
	[Token(Token = "0x400103E")]
	public Color saveGoogleBorderColor; //Field offset: 0x19C
	[FieldOffset(Offset = "0x1AC")]
	[Token(Token = "0x400103F")]
	public Color saveGoogleTextColor; //Field offset: 0x1AC
	[FieldOffset(Offset = "0x1BC")]
	[Token(Token = "0x4001040")]
	public Color saveAppleColor; //Field offset: 0x1BC
	[FieldOffset(Offset = "0x1CC")]
	[Token(Token = "0x4001041")]
	public float saveGapBtnsLink; //Field offset: 0x1CC
	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x4001042")]
	public float saveLinkFs; //Field offset: 0x1D0
	[FieldOffset(Offset = "0x1D4")]
	[Token(Token = "0x4001043")]
	public float saveLinkH; //Field offset: 0x1D4
	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x4001044")]
	public Color saveLinkColor; //Field offset: 0x1D8
	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x4001045")]
	public float savePadBottom; //Field offset: 0x1E8
	[FieldOffset(Offset = "0x1EC")]
	[Token(Token = "0x4001046")]
	public float saveStatusBoxH; //Field offset: 0x1EC
	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x4001047")]
	public float saveStatusPad; //Field offset: 0x1F0
	[FieldOffset(Offset = "0x1F4")]
	[Token(Token = "0x4001048")]
	public float saveStatusFs; //Field offset: 0x1F4
	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x4001049")]
	public float saveStatusLineSpacing; //Field offset: 0x1F8
	[FieldOffset(Offset = "0x1FC")]
	[Token(Token = "0x400104A")]
	public bool saveShowEmail; //Field offset: 0x1FC
	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x400104B")]
	public float saveGapBoxBtn; //Field offset: 0x200
	[FieldOffset(Offset = "0x204")]
	[Token(Token = "0x400104C")]
	public float saveDeleteBoxH; //Field offset: 0x204
	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x400104D")]
	public float saveDeleteGapTitleBox; //Field offset: 0x208
	[FieldOffset(Offset = "0x20C")]
	[Token(Token = "0x400104E")]
	public float saveDeleteGapBoxBtn; //Field offset: 0x20C
	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x400104F")]
	public float saveDeleteFs; //Field offset: 0x210
	[FieldOffset(Offset = "0x214")]
	[Token(Token = "0x4001050")]
	public float saveDeleteLineSpacing; //Field offset: 0x214
	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x4001051")]
	public float saveDeleteParagraphSpacing; //Field offset: 0x218
	[FieldOffset(Offset = "0x21C")]
	[Token(Token = "0x4001052")]
	public float saveDeletePad; //Field offset: 0x21C
	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x4001053")]
	public float saveNoticeBoxH; //Field offset: 0x220
	[FieldOffset(Offset = "0x224")]
	[Token(Token = "0x4001054")]
	public float saveNoticeMaxBoxH; //Field offset: 0x224
	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x4001055")]
	public float saveResultBoxH; //Field offset: 0x228
	[FieldOffset(Offset = "0x22C")]
	[Token(Token = "0x4001056")]
	public float saveResultIconSize; //Field offset: 0x22C
	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x4001057")]
	public float saveResultIconTop; //Field offset: 0x230
	[FieldOffset(Offset = "0x234")]
	[Token(Token = "0x4001058")]
	public float saveResultTextGap; //Field offset: 0x234
	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x4001059")]
	public float saveResultFs; //Field offset: 0x238
	[FieldOffset(Offset = "0x23C")]
	[Token(Token = "0x400105A")]
	public float saveResultLineSpacing; //Field offset: 0x23C
	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x400105B")]
	public Color saveResultOkColor; //Field offset: 0x240
	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x400105C")]
	public Color saveResultFailColor; //Field offset: 0x250
	[FieldOffset(Offset = "0x260")]
	[Header("블록 간격")]
	[Token(Token = "0x400105D")]
	public float gapTitleGroup; //Field offset: 0x260
	[FieldOffset(Offset = "0x264")]
	[Token(Token = "0x400105E")]
	public float gapGroupDash; //Field offset: 0x264
	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x400105F")]
	public float gapDashBtn; //Field offset: 0x268
	[FieldOffset(Offset = "0x26C")]
	[Token(Token = "0x4001060")]
	public float gapBtnBtn; //Field offset: 0x26C
	[FieldOffset(Offset = "0x270")]
	[Token(Token = "0x4001061")]
	public float gapBtnLinks; //Field offset: 0x270
	[FieldOffset(Offset = "0x274")]
	[Token(Token = "0x4001062")]
	public float gapLinksVersion; //Field offset: 0x274
	[FieldOffset(Offset = "0x278")]
	[Header("점선")]
	[Token(Token = "0x4001063")]
	public float dashLen; //Field offset: 0x278
	[FieldOffset(Offset = "0x27C")]
	[Token(Token = "0x4001064")]
	public float dashGap; //Field offset: 0x27C
	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x4001065")]
	public float dashThickness; //Field offset: 0x280
	[FieldOffset(Offset = "0x284")]
	[Token(Token = "0x4001066")]
	public Color dashColor; //Field offset: 0x284
	[FieldOffset(Offset = "0x294")]
	[Header("액션 버튼")]
	[Token(Token = "0x4001067")]
	public float btnH; //Field offset: 0x294
	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x4001068")]
	public float btnPpum; //Field offset: 0x298
	[FieldOffset(Offset = "0x29C")]
	[Token(Token = "0x4001069")]
	public float btnFs; //Field offset: 0x29C
	[FieldOffset(Offset = "0x2A0")]
	[Token(Token = "0x400106A")]
	public float btnIconSize; //Field offset: 0x2A0
	[FieldOffset(Offset = "0x2A4")]
	[Token(Token = "0x400106B")]
	public float btnIconX; //Field offset: 0x2A4
	[FieldOffset(Offset = "0x2A8")]
	[Header("하단 링크")]
	[Token(Token = "0x400106C")]
	public float linkIconSize; //Field offset: 0x2A8
	[FieldOffset(Offset = "0x2AC")]
	[Token(Token = "0x400106D")]
	public float linkFs; //Field offset: 0x2AC
	[FieldOffset(Offset = "0x2B0")]
	[Token(Token = "0x400106E")]
	public float linkIconTextGap; //Field offset: 0x2B0
	[FieldOffset(Offset = "0x2B4")]
	[Token(Token = "0x400106F")]
	public float linkItemGap; //Field offset: 0x2B4
	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x4001070")]
	public float linkRowH; //Field offset: 0x2B8
	[FieldOffset(Offset = "0x2BC")]
	[Header("유저 ID (하단 한 줄 왼쪽 — 오른쪽은 버전)")]
	[Token(Token = "0x4001071")]
	public float uidFs; //Field offset: 0x2BC
	[FieldOffset(Offset = "0x2C0")]
	[Token(Token = "0x4001072")]
	public float uidH; //Field offset: 0x2C0
	[FieldOffset(Offset = "0x2C4")]
	[Token(Token = "0x4001073")]
	public float uidCopyIconSize; //Field offset: 0x2C4
	[FieldOffset(Offset = "0x2C8")]
	[Token(Token = "0x4001074")]
	public float uidCopyGap; //Field offset: 0x2C8
	[FieldOffset(Offset = "0x2CC")]
	[Token(Token = "0x4001075")]
	public float uidVersionGap; //Field offset: 0x2CC
	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x4001076")]
	public int uidDisplayChars; //Field offset: 0x2D0
	[FieldOffset(Offset = "0x2D4")]
	[Header("버전")]
	[Token(Token = "0x4001077")]
	public float versionFs; //Field offset: 0x2D4
	[FieldOffset(Offset = "0x2D8")]
	[Token(Token = "0x4001078")]
	public float versionH; //Field offset: 0x2D8
	[FieldOffset(Offset = "0x2DC")]
	[Header("와이드 해상도(태블릿·폴드 펼침)")]
	[Token(Token = "0x4001079")]
	public float wideScale; //Field offset: 0x2DC
	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x400107A")]
	public float fitMargin; //Field offset: 0x2E0

	[Address(RVA = "0x32CA4A0", Offset = "0x32CA4A0", Length = "0x218")]
	[Token(Token = "0x60011FA")]
	public SettingsPopupLayout() { }

}

