using System;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Profile_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Profile, out Panel_Profile panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.backHandle = () => ProfileController.Back(ctx);
                panel.infoHandle = () => ProfileController.ShowDialog(ctx, ProfileDialogType.Info);
                panel.editHandle = () => ProfileController.ShowDialog(ctx, ProfileDialogType.Name);
                panel.mottoHandle = () => ProfileController.ShowDialog(ctx, ProfileDialogType.Motto);
                panel.copyHandle = () => ProfileController.CopyUid(ctx);
                panel.memberHandle = () => ProfileController.Notice(ctx, UINameType.Profile_MemberUnavailable);
                panel.closeDialogHandle = () => ProfileController.ShowDialog(ctx, ProfileDialogType.None);
                panel.saveNameHandle = name => ProfileController.SaveName(ctx, name);
                panel.selectMottoHandle = id => ProfileController.SetMotto(ctx, id);
                panel.tabHandle = tab => ProfileController.SetTab(ctx, tab);
                panel.selectHandle = (tab, id) => ProfileController.Select(ctx, tab, id);
            }
            panel.Init();
        }

        public static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string value)) {
                throw new InvalidOperationException("Missing profile text: " + id);
            }
            return value;
        }

        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Profile, out Panel_Profile panel)) {
                return;
            }
            var state = ctx.state_Profile;
            var assets = ctx.assetModule;
            var config = assets.GetProfileConfig();
            var save = ctx.playerSave;
            var profile = save.profile;
            var newMasks = new[] { ProfileController.NewMask(config, save, ProfileTabType.Avatar),
                ProfileController.NewMask(config, save, ProfileTabType.Frame), ProfileController.NewMask(config, save, ProfileTabType.Costume) };
            panel.titleLabel.text = Text(ctx, UINameType.Profile_Title);
            panel.brandLabel.text = Text(ctx, UINameType.Profile_Brand);
            panel.gradeLabel.text = Text(ctx, UINameType.Profile_Member);
            panel.memberLabel.text = Text(ctx, UINameType.Profile_Apply);
            panel.nameLabel.text = profile.nickname;
            panel.mottoLabel.text = Text(ctx, profile.mottoId == 0 ? UINameType.Profile_MottoPlaceholder : config.mottos[profile.mottoId - 1]);
            panel.infoLabel.text = string.Format(Text(ctx, UINameType.Profile_LevelDate), save.campaignClears + 1,
                profile.historyKnown ? new DateTime((long)(profile.firstRecordedDay - 1) * TimeSpan.TicksPerDay).ToString("yyyy/MM/dd") : Text(ctx, UINameType.Profile_Unknown));
            panel.uidLabel.text = "UID " + save.ranking.clientId.Substring(0, 18) + "...";
            panel.avatar.sprite = config.avatars[profile.avatarId];
            panel.frame.sprite = config.frames[profile.frameId];
            panel.avatarBackground.color = config.avatarColors[profile.avatarId % config.avatarColors.Length];
            panel.portrait.Show(config, profile.avatarId, profile.frameId, profile.costumeId, 1, -1);
            panel.statLabels[0].text = Text(ctx, UINameType.Profile_WinStreak);
            panel.statLabels[1].text = Text(ctx, UINameType.Profile_LoginStreak);
            panel.statLabels[2].text = Text(ctx, UINameType.Profile_Puzzles);
            panel.statLabels[3].text = Text(ctx, UINameType.Profile_ThreeSeeds);
            panel.statLabels[4].text = Text(ctx, UINameType.Profile_FirstTry);
            panel.statLabels[5].text = Text(ctx, UINameType.Profile_RankWins);
            string suffix = profile.historyKnown ? string.Empty : "+";
            panel.statValues[0].text = string.Format(Text(ctx, UINameType.Profile_CurrentBest), profile.consecutiveClears, profile.bestConsecutiveClears);
            panel.statValues[1].text = string.Format(Text(ctx, UINameType.Profile_CurrentBest), profile.loginStreak, profile.bestLoginStreak);
            panel.statValues[2].text = save.campaignClears.ToString();
            panel.statValues[3].text = profile.threeSeedClears + suffix;
            panel.statValues[4].text = profile.firstTryClears + suffix;
            panel.statValues[5].text = Text(ctx, UINameType.Profile_Unknown);
            var tabIds = new[] { UINameType.Profile_Avatar, UINameType.Profile_Frame, UINameType.Profile_Costume };
            for (int i = 0; i < 3; i++) {
                panel.tabLabels[i].text = Text(ctx, tabIds[i]);
                bool selected = (int)state.tab == i + 1;
                panel.grids[i].SetActive(selected);
                panel.tabButtons[i].GetComponent<UnityEngine.UI.Image>().color = selected ? config.selectedColor : config.idleColor;
                panel.tabButtons[i].GetComponent<UnityEngine.UI.Image>().sprite = selected ? config.tabOn : config.tabOff;
                panel.tabLabels[i].color = selected ? config.tabOnText : config.tabOffText;
                panel.tabDots[i].SetActive((state.visitedTabs & (1 << i)) == 0 && newMasks[i] != 0);
            }
            panel.RefreshTabLayering();
            foreach (var item in panel.items) {
                int selection = item.tab == ProfileTabType.Avatar ? profile.avatarId : item.tab == ProfileTabType.Frame ? profile.frameId : profile.costumeId;
                item.Show(item.itemId == selection, ProfileController.AvailableForSession(ctx, config, save, item.tab, item.itemId), config.lockedAlpha);
                bool available = ProfileController.AvailableForSession(ctx, config, save, item.tab, item.itemId);
                bool club = (item.tab == ProfileTabType.Avatar && item.itemId >= config.clubAvatarStart) ||
                    (item.tab == ProfileTabType.Frame && item.itemId == config.clubFrameId);
                item.clubTag.SetActive(club);
                item.clubLabel.text = Text(ctx, UINameType.Profile_ClubTag);
                item.newDot.SetActive(item.itemId >= 0 && (newMasks[(int)item.tab - 1] & (1u << item.itemId)) != 0);
                bool avatarCell = item.tab == ProfileTabType.Avatar;
                item.art.gameObject.SetActive(avatarCell);
                item.portrait.gameObject.SetActive(!avatarCell);
                if (avatarCell) {
                    item.art.sprite = config.avatars[item.itemId];
                } else {
                    item.portrait.Show(config, profile.avatarId,
                        item.tab == ProfileTabType.Frame ? item.itemId : -1,
                        item.tab == ProfileTabType.Costume ? item.itemId : -1, available ? 1 : config.lockedAlpha, -1);
                }
                item.requirementLabel.gameObject.SetActive(item.tab == ProfileTabType.Costume && item.itemId >= 0);
                if (item.tab == ProfileTabType.Costume && item.itemId >= 0) {
                    int season = config.costumeSeasons[item.itemId];
                    item.requirementLabel.text = string.Format(Text(ctx, UINameType.Profile_SeasonSource), season / 100, season % 100);
                }
                if (item.tab == ProfileTabType.Frame) {
                    item.avatar.sprite = config.avatars[profile.avatarId];
                }
                if (item.tab == ProfileTabType.Costume) {
                    item.label.text = Text(ctx, item.itemId == -1 ? UINameType.Profile_NoCostume : config.costumeNames[item.itemId]);
                }
            }
            string notice = state.notice == UINameType.None ? string.Empty : string.Format(Text(ctx, state.notice), state.noticeArgument);
            panel.noticeLabel.gameObject.SetActive(state.notice != UINameType.None && state.dialog == ProfileDialogType.None);
            panel.noticeBackground.gameObject.SetActive(state.notice != UINameType.None && state.dialog == ProfileDialogType.None);
            panel.noticeLabel.text = notice;
            panel.dialogNotice.text = notice;
            panel.dialogRoot.SetActive(state.dialog != ProfileDialogType.None);
            panel.nameRoot.SetActive(state.dialog == ProfileDialogType.Name);
            panel.mottoRoot.SetActive(state.dialog == ProfileDialogType.Motto);
            panel.helpRoot.SetActive(state.dialog == ProfileDialogType.Info);
            panel.dialogBox.SetActive(state.dialog != ProfileDialogType.Info);
            panel.dialogBackdrop.color = state.dialog == ProfileDialogType.Info ? config.helpBackdropColor : config.editBackdropColor;
            panel.saveButton.gameObject.SetActive(state.dialog == ProfileDialogType.Name);
            panel.dialogTitle.text = Text(ctx, state.dialog == ProfileDialogType.Name ? UINameType.Profile_EditName :
                state.dialog == ProfileDialogType.Motto ? UINameType.Profile_MottoPlaceholder : UINameType.Profile_Help);
            panel.dialogBody.text = Text(ctx, UINameType.Profile_HelpBody);
            panel.helpTitle.text = Text(ctx, UINameType.Profile_Help);
            panel.helpRowTitles[0].text = string.Format(Text(ctx, UINameType.Profile_HelpDaysTitle), config.helpMemberDays);
            panel.helpRowTitles[1].text = string.Format(Text(ctx, UINameType.Profile_HelpRewardTitle), config.helpRewardMax);
            panel.helpRowTitles[2].text = Text(ctx, UINameType.Profile_HelpStyleTitle);
            panel.helpRowTitles[3].text = Text(ctx, UINameType.Profile_HelpEligibilityTitle);
            panel.helpRowDescriptions[0].text = Text(ctx, UINameType.Profile_HelpDaysDescription);
            panel.helpRowDescriptions[1].text = string.Format(Text(ctx, UINameType.Profile_HelpRewardDescription), config.helpRewardHint, config.helpRewardGuide);
            panel.helpRowDescriptions[2].text = Text(ctx, UINameType.Profile_HelpStyleDescription);
            panel.helpRowDescriptions[3].text = string.Format(Text(ctx, UINameType.Profile_HelpEligibilityDescription), config.helpEligibleStreak);
            panel.helpConfirmLabel.text = Text(ctx, UINameType.Profile_HelpConfirm);
            panel.nameHint.text = string.Format(Text(ctx, UINameType.Profile_NameHint), config.nameMaxChars);
            panel.nameInput.fontAsset = panel.nameLabel.font;
            panel.saveLabel.text = Text(ctx, UINameType.Profile_Save);
            panel.cancelLabel.text = Text(ctx, UINameType.Profile_Close);
            for (int i = 0; i < panel.mottoLabels.Length; i++) {
                panel.mottoLabels[i].text = Text(ctx, i == 0 ? UINameType.Profile_NoMotto : config.mottos[i - 1]);
            }
        }

        public static void RefreshSafeArea(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Profile, out Panel_Profile panel)) {
                panel.RefreshSafeArea();
            }
        }

        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Profile, out Panel_Profile panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
            var state = ctx.state_Profile;
            state.isOpen = false;
            state.dialog = ProfileDialogType.None;
        }
    }
}
