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

/* 第二版组件参数；商品价格为用户截图中的展示值，不是实时商店报价。 */
window.UI_LIBRARY_CONFIG.components = {
  "buttons": {
    "orange": {
      "asset": "Sprite:resources.assets:1177",
      "faceBounds": [
        1,
        1,
        1023,
        275
      ],
      "faceMethod": "对原 PNG 的高不透明亮色面做像素阈值测量，排除深色投影；需截图光学校准",
      "borderWidth": 14,
      "textColor": "#694735"
    },
    "blue": {
      "asset": "Sprite:resources.assets:1108",
      "faceBounds": [
        5,
        5,
        503,
        155
      ],
      "faceMethod": "对原 PNG 的高不透明亮色面做像素阈值测量，排除深色投影；需截图光学校准",
      "borderWidth": 14,
      "textColor": "#694735"
    },
    "yellow": {
      "asset": "Sprite:resources.assets:823",
      "faceBounds": [
        4,
        5,
        502,
        148
      ],
      "faceMethod": "对原 PNG 的高不透明亮色面做像素阈值测量，排除深色投影；需截图光学校准",
      "borderWidth": 14,
      "textColor": "#694735"
    },
    "pink": {
      "asset": "Sprite:resources.assets:1122",
      "faceBounds": [
        6,
        6,
        475,
        156
      ],
      "faceMethod": "对原 PNG 的高不透明亮色面做像素阈值测量，排除深色投影；需截图光学校准",
      "borderWidth": 14,
      "textColor": "#694735"
    },
    "cream": {
      "asset": "Sprite:resources.assets:1200",
      "faceBounds": [
        1,
        2,
        1022,
        232
      ],
      "faceMethod": "对原 PNG 的高不透明亮色面做像素阈值测量，排除深色投影；需截图光学校准",
      "borderWidth": 14,
      "textColor": "#694735"
    }
  },
  "buttonSizes": {
    "standard": {
      "paddingX": 24,
      "paddingY": 12,
      "fontSize": 19,
      "height": 54
    },
    "compact": {
      "paddingX": 16,
      "paddingY": 8,
      "fontSize": 15,
      "height": 44
    }
  },
  "spacing": {
    "initial": 12,
    "min": 4,
    "max": 32
  },
  "layout": {
    "screenWidth": 390,
    "sidebarBreakpoint": 700,
    "gridBreakpoint": 1100
  },
  "settings": [
    {
      "key": "sfx",
      "label": "音效",
      "icon": "icon_sfx",
      "type": "switch",
      "value": true
    },
    {
      "key": "music",
      "label": "音乐",
      "icon": "icon_music",
      "type": "switch",
      "value": true
    },
    {
      "key": "voice",
      "label": "连击语音",
      "icon": "icon_combo_voice",
      "type": "choice",
      "value": "男声"
    },
    {
      "key": "vibration",
      "label": "震动",
      "icon": "icon_vibration",
      "type": "switch",
      "value": true
    },
    {
      "key": "borders",
      "label": "区域边框",
      "icon": "icon_border",
      "type": "switch",
      "value": false
    },
    {
      "key": "patterns",
      "label": "图案",
      "icon": "icon_pattern",
      "type": "switch",
      "value": true
    },
    {
      "key": "language",
      "label": "语言",
      "icon": "icon_language",
      "type": "link",
      "value": "简体中文"
    }
  ],
  "observedBoard": [
    [
      3,
      3,
      3,
      3,
      3,
      3,
      3,
      3,
      2
    ],
    [
      3,
      7,
      7,
      3,
      3,
      3,
      2,
      3,
      2
    ],
    [
      7,
      7,
      3,
      3,
      2,
      2,
      2,
      3,
      2
    ],
    [
      7,
      7,
      1,
      1,
      1,
      2,
      2,
      2,
      2
    ],
    [
      7,
      7,
      7,
      7,
      1,
      2,
      6,
      6,
      6
    ],
    [
      8,
      1,
      1,
      1,
      1,
      2,
      2,
      2,
      5
    ],
    [
      8,
      8,
      8,
      8,
      1,
      1,
      5,
      5,
      5
    ],
    [
      1,
      1,
      1,
      1,
      1,
      5,
      5,
      5,
      9
    ],
    [
      0,
      0,
      1,
      1,
      1,
      1,
      5,
      9,
      9
    ]
  ],
  "patternColors": {
    "3": 3,
    "7": 7,
    "2": 2,
    "1": 1,
    "6": 6,
    "8": 8,
    "5": 5,
    "9": 9,
    "0": 0
  },
  "products": [
    {
      "id": 1,
      "title": "完美新手礼包",
      "image": "offer_art_starter_pack",
      "price": "US$6.49",
      "quantity": "放大镜 5 · 提示 5 · 永久移除广告",
      "featured": true
    },
    {
      "id": 2,
      "title": "移除广告 · 1天",
      "image": "shop_remove_ads",
      "price": "US$1.19",
      "quantity": "1天"
    },
    {
      "id": 3,
      "title": "移除广告 · 1周",
      "image": "shop_remove_ads",
      "price": "US$3.69",
      "quantity": "1周"
    },
    {
      "id": 4,
      "title": "移除广告 · 永久",
      "image": "shop_remove_ads",
      "price": "US$8.99",
      "quantity": "永久"
    },
    {
      "id": 5,
      "title": "放大镜 · 5个",
      "image": "shop_magnifier",
      "price": "US$1.19",
      "quantity": "×5"
    },
    {
      "id": 6,
      "title": "放大镜 · 20个",
      "image": "shop_magnifier",
      "price": "US$3.69",
      "quantity": "×20"
    },
    {
      "id": 7,
      "title": "放大镜 · 50个",
      "image": "shop_magnifier",
      "price": "US$8.99",
      "quantity": "×50"
    }
  ],
  "sampleRanks": [
    {
      "name": "示例玩家 A",
      "score": 1280
    },
    {
      "name": "示例玩家 B",
      "score": 960
    },
    {
      "name": "我（示例）",
      "score": 576
    }
  ],
  "typeScale": [
    {
      "name": "页面标题",
      "size": 28,
      "weight": 700,
      "line": 1.3
    },
    {
      "name": "区块标题",
      "size": 22,
      "weight": 700,
      "line": 1.4
    },
    {
      "name": "正文 / 按钮",
      "size": 18,
      "weight": 500,
      "line": 1.5
    },
    {
      "name": "辅助信息",
      "size": 14,
      "weight": 400,
      "line": 1.5
    },
    {
      "name": "数值",
      "size": 32,
      "weight": 700,
      "line": 1.2
    }
  ]
};
