- A1 Hamdoku2 UI Library · 第二版
	- B1 入口：[UI Library.html](<UI Library.html>)。Chrome / Edge 直接打开即可，支持 file:// 离线浏览，无需服务器。页面保留组件目录，另有 8 个可切换的页面组合与截图并排对照。

	- B2 本版按用户确认顺序补齐按钮规格与视觉居中、九宫格和间距、标签页与列表、Hamdoku 专属组件及截图对照。只修改参考库与记录；Unity 业务实现、Prefab、场景、SO 和存档未在本轮修改。

- A2 来源与数据
	- B1 目标工程为 D:/UnityProject/Hamdoku2；原作只读资料为 D:/0000001apkUnbag/01_逆向工程项目/Hamdoku2。结构参考麻将项目 UI Library，视觉与业务组件从 Hamdoku 资料整理。

	- B2 708 张 Sprite、10 份字体保持原导出字节；manifest.json / catalog.js 记录来源资源包、pathID、哈希、导出尺寸与透明边界。APK SHA-256：0079af1d59afafe461c5eccf736b74d0a9d79090599454777f05caa00f59192c。

	- B3 708 张 Sprite 的 spriteRect、spriteBorder、pixelsPerUnit、textureRect、textureRectOffset 来自对原 APK 解包资源的 UnityPy 只读解析；exportBorderLTRB 为考虑裁切偏移后的左/上/右/下边界。原始 spriteBorder 的 x/y/z/w 是左/下/右/上，不能直接按 CSS 顺序使用。LevelButton 等原始 border 为零的资源保留按比例显示。

	- B4 evidence/ 保存 12 份配置或文案快照，包括 GameConfig、BoardView、ShopCatalog、ButtonPressEffect、LogoAnimator、CanvasScaler 及简中/英文案。网页参数为展示规范，Unity 生产配置仍由各功能 SO 管理。

	- B5 用户提供 8 张截图，实际为 6 类独立画面：首页、棋盘、设置、商店、每日连胜、个人资料。两张额外首页图与首页主图字节相同，index.json 记录 duplicateOf；原文件全部保留于 references/original/。设置画面可见 v1.2.2，其他画面的版本、设备与采集时间未独立确认。

	- B6 原有 references/ 的 4 张首页图来自当前复刻工程；它们与用户提供的游戏截图分别标注来源。截图能证明可见组合与样式，不能证明倒计时、输入手势、奖励、购买或服务规则。

- A3 通用组件与规范
	- B1 按钮提供橙色主要操作、蓝色辅助操作、黄色高亮、粉色商店操作及奶油色轻量操作。每种展示标准、紧凑与禁用；另有忙碌反馈、悬停、按压和键盘聚焦。标准字号19/左右内距24/最小高54，紧凑字号15/左右内距16/最小高44，为本库提炼值。

	- B2 按钮面亮色区域由原 PNG 的像素阈值测量；排除深色投影后，通过切片坐标映射求可见面中心。文字使用 Canvas 字形 ascent/descent 定位，ResizeObserver 与字体加载完成后重算。动态文案示例和中心参考线可操作。这是可检查的测量方案，尚未完成逐字体、逐字号的截图像素精确验收。

	- B3 九宫格区展示原始 border、导出 border、Sprite 原始尺寸与 PNG 尺寸，并支持 160–360px 宽度变化。PopupPanel 使用原始 28px 切片；按钮使用导出坐标切片和可配置的呈现边框。原始切片为资源事实，浏览器呈现边宽属于本库选择，不代表 Unity 已按相同显示尺度验收。

	- B4 内距支持 4–32px 调整，同步展示四向 padding 与图标/文字 gap。文字层级含标题、区块、正文、辅助信息和数字；这些字号与行高是补充规范，不是由截图精确测量得出。

	- B5 标签页支持左右键、Home/End、焦点与 aria-selected；列表支持 0/1/2/6 项、查看/可领取/已领取、空态。辅助组件包括数量徽标、骨架加载、多行输入、禁用字段、进度与表单校验。

- A4 Hamdoku 专属组合
	- B1 首页：头像入口、商店/设置入口、每日卡片、连胜、排行倒计时、Logo 和关卡17入口，按截图组织。倒计时是截图文本；早期首页组件区仍保留当前 Unity 解锁数与中英标题的演示，用于区分现有实现与截图目标。

	- B2 棋盘：按截图转录的 9×9 色区、图案、规则说明、仓鼠1/9、三颗生命种子、两种道具数量和广告占位。单击只轮换局部视觉状态，不判断真实解题规则；12 种原始区域图案另有完整目录。设置中的图案与区域边框可影响此预览。

	- B3 设置：音效、音乐、连击语音、震动、区域边框、图案、语言七行；语音前后切换、开关和语言行可以操作，另含重新开始、教程、客服、隐私与条款入口。语言弹层是补充布局，选择只更新演示行，不宣称整页翻译完成。两行设置旧占位已改为进入完整设置预览。

	- B4 商店：新手礼包、3 个去广告档位、3 个放大镜档位，共7个商品示例。礼包图采用原作 offer_art_starter_pack。价格来自截图的静态展示，不能视为实时价格；点击只展示商品说明，不提交订单、不发奖。商品分组密度与原截图仍有差异，商店下半部分尚无截图。

	- B5 每日连胜：幼苗、当前/最佳连胜、7天条目、完成标记与礼盒、继续。点击日期查看样例状态，不执行领取或结算。当前植物样例对应截图幼苗，不冒充完整成长阶段还原。

	- B6 个人资料：资料摘要、6项统计、头像、边框、服装标签；从原资源展示18项头像/姿态、19个边框、6件服装。头像与边框可切换，服装仅展示资源与选择反馈；佩戴绑定、解锁、个人信息编辑和会员服务待核对。

	- B7 每日挑战日历、排行榜正常/加载/空/失败布局为明确标记的补充示例；不是已经取得截图的还原页面。日历选择和排行榜重试只改变网页内存状态。

- A5 来源对照与尚存差异
	- B1 “专属组件与页面组合”左侧为重构、右侧为对应用户截图；没有截图的页面显示缺口说明。组件级交互已提供，但本版不是逐像素复刻完成声明。

	- B2 首页 Logo 姿态/缩放、字体观感、卡片渐变与字距、棋盘顶部信息布局、设置背景与间距、商店分组以及个人资料细节仍需精调。静态原图与动画中的某一帧可能不同，需录像定位。

	- B3 缺口与优先级以 [Missing.md](Missing.md) 为准。当前截图已收到的六类画面不再列作完全缺失，仅列未覆盖的变体、操作与状态。

- A6 配置、复现与工程落地
	- B1 UI Library.config.js 管理基础参数与 components 配置，包括按钮底图/面区域/尺寸、文字层级、间距、设置行、截图棋盘矩阵及商品。UI Library.components.js / .css 实现本版组件；基础 JS/CSS 保留第一版组件。

	- B2 在项目根执行 python Docs/UILibrary/extract.py，需要 Pillow 与 UnityPy。提取脚本只写本库 assets、evidence、references、manifest 和 catalog，不修改原作。references/original/index.json 为已保存用户截图的索引，重新提取会保留并载入它们，不依赖临时剪贴板文件仍然存在。

	- B3 图案遮罩使用原 PNG 字节的 data URL，解决 Chrome file:// 对 CSS mask 的跨源限制；独立 PNG 与原哈希仍保留。不得通过关闭浏览器安全策略才能使用本库。

	- B4 Node.js + Playwright 可执行 verify.cjs 与 verify-components.cjs，NODE_PATH 指向可用模块，UI_BROWSER 可指定 Chrome/Edge。结果在 verification-results.json、verification-components.json，预览在 previews/。实际范围见 [Verification.md](Verification.md)。

	- B5 Unity 仍遵循 ClientMain → System → Controller → UI/Module、既有 PanelFactory/Repository 与 Open/Close 生命周期。重复 Item 使用独立资源与对应脚本；Context 只持字段，生产状态与配置分开。本轮没有从网页生成或修改 Unity Prefab。

	- B6 UI 设计基准为1080×1920、9:16正向竖屏，CanvasScaler 匹配值0.5、PPU100。网页逻辑 px 按显示宽度呈现，不复制麻将的750/375换算。文案/字体生产入口仍为 L10NModule 与各语言 L10NFontSO。

- A7 玩法分析
	- B1 [玩法分析.html](玩法分析.html)：按参考项目玩法文档的阅读结构整理核心规则、交互示意、教程、道具与失败、模式成长、结算表现和证据来源；支持离线浏览。原作静态证据、运行待核实项与工程实现状态分别说明。

	- B2 新增 evidence/Campaign_样例.md 与 evidence/Tutorial_4x4__sharedassets1.assets__11.json 为只读原资料副本，仅供本页引用，不属于 catalog/manifest 的既有资源发布快照。
