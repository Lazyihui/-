/* 浏览器参考参数。原作证据见 evidence/；Unity 生产配置仍由对应 SO 管理。 */
window.UI_LIBRARY_CONFIG = {
  tokens: {
    paper: '#fff8ed', ink: '#694735', muted: '#856d60', accent: '#f6ad63',
    pink: '#f7a7b5', purple: '#b9a5ed', blue: '#b1d6f2', line: '#e7d8c7',
    'space-1': '4px', 'space-2': '8px', 'space-3': '12px', 'space-4': '16px',
    'space-6': '24px', 'space-8': '32px', 'page-padding': '32px',
    'font-body': '16px', 'font-small': '13px', 'font-title': '32px',
    'button-padding-x': '24px', 'button-padding-y': '12px', 'touch-min': '48px',
    'panel-radius': '24px', 'press-scale': 0.9, 'press-ms': '120ms', 'enter-ms': '240ms'
  },
  provenance: {
    tokens: '色板为原作素材视觉整理；间距、字号、弹窗入场时长为本库补充值，非原作测量。',
    press: '0.9 来自 ButtonPressEffect__level1__124.json；120ms 为浏览器补充。',
    board: '区域色由 BoardView__level2__167.json 提取。示例布局为人工构造，不代表关卡。',
    unlocks: '阈值来自原作 GameConfig；与当前 HomeConfig.asset 的 10/20/100 一致。',
    geometry: '项目统一设计基准 1080×1920、正向竖屏；原作首页和游戏 CanvasScaler 的匹配值均为 0.5、PPU 为 100。网页逻辑 px 仅作参考。'
  },
  fonts: { zh: 'ZCOOLKuaiLe-Regular', en: 'Nunito' },
  unityCanvas: { referenceWidth: 1080, referenceHeight: 1920, matchWidthOrHeight: 0.5, referencePixelsPerUnit: 100, orientation: 'Portrait' },
  unlocks: { ranking: 10, daily: 20, endless: 100 },
  timing: { toast: 2500, busy: 900, pressPreview: 360, rewardPreview: 700 },
  assetPageSize: 48,
  demo: { clears: 0, progress: 40, lives: 3, hints: 3, date: '2026-10-27', boardSize: 4 },
  regionColors: ["#f2998b", "#51c3b7", "#f0ca5f", "#7284d7", "#6ebf76", "#e57ec4", "#87c8e9", "#f3aa58", "#b188e1", "#b4d25e", "#eeadc5", "#aba7a0"],
  labels: {
    zh: { level: '关卡', daily: '每日挑战', ranking: '排行榜', endless: '无限模式', settings: '设置', locked: '通关 {0} 关解锁', streak: '每日连胜', play: '开始' },
    en: { level: 'Level', daily: 'Daily Challenge', ranking: 'Ranking', endless: 'Endless', settings: 'Settings', locked: 'Clear {0} levels to unlock', streak: 'Daily Streak', play: 'Play' }
  },
  images: {
    logo: 'Sprite:sharedassets0.assets:6', background: 'Sprite:sharedassets0.assets:5',
    campaign: 'Sprite:resources.assets:1405', campaignHard: 'Sprite:resources.assets:1103',
    daily: 'Sprite:resources.assets:1002', ranking: 'Sprite:resources.assets:1407',
    streak: 'Sprite:resources.assets:1343', endless: 'Sprite:resources.assets:965',
    hamster: 'Sprite:resources.assets:1005', close: 'Sprite:resources.assets:1149',
    settings: 'Sprite:resources.assets:881', life: 'Sprite:resources.assets:904',
    dailyIcon: 'Sprite:resources.assets:1333', endlessIcon: 'Sprite:resources.assets:1128',
    podium: 'Sprite:resources.assets:752', sunflower: 'Sprite:resources.assets:1284',
    hint: 'Sprite:resources.assets:1127', cross: 'Sprite:resources.assets:905',
    sound: 'Sprite:resources.assets:1378', vibration: 'Sprite:resources.assets:972'
  }
};
