- A1 Hamdoku2 UI Library
	- B1 入口：[UI Library.html](<UI Library.html>)。用 Chrome 或 Edge 直接打开即可；图片、字体、脚本与配置都在本目录，不依赖网络、服务器或原项目的相对链接。`catalog.js` 支持 `file://`；`manifest.json` 提供相同的机器可读资源清单。

	- B2 本库用于在开发期间确认 UI 样式、组件职责、状态与表现，随后与 Unity 页面同步维护。第一版保留 Hamdoku 原作的视觉风格，结构参考 `D:\UnityProject\Mahjong_j\Docs\UILibrary`，不沿用其红金主题、麻将牌或业务组件。

- A2 来源与当前范围
	- B1 实现目标：`D:\UnityProject\Hamdoku2`。

	- B2 原作资料：`D:\0000001apkUnbag\01_逆向工程项目\Hamdoku2`，Hamdoku 1.2.2；样本 APK SHA-256 为 `0079af1d59afafe461c5eccf736b74d0a9d79090599454777f05caa00f59192c`。

	- B3 提取时间：2026-10-27。复制 708 张已导出 Sprite、10 份 Font、11 份配置/文案证据、4 张当前工程验证截图。Texture2D 与 Sprite 可能内容重复，本库只复制 Sprite；音频和着色器不纳入此版资源目录。

	- B4 `assets/` 保留原导出字节，不重新压缩；清单记录来源文件、源资源包、pathID、尺寸、透明边界和 SHA-256。同名资源通过类型、资源包与 pathID 区分。

	- B5 `evidence/` 保存 GameConfig、BoardView、ButtonPressEffect、LogoAnimator、首页与游戏 CanvasScaler 及简中/英文案快照。展示所用主图通过 `UI Library.config.js` 的 `images` 指向唯一资源 ID。

	- B6 `references/` 是当前 Unity 复刻工程的首页验证截图，**不是原应用截图**。原作资料 `06_runtime/README.md` 表明本轮未采集运行时业务证据；已检查目录内没有可用于页面验收的原应用截图。

	- B7 本库未恢复可直接导入 Unity 的原作 Prefab，也没有把原作 JSON 当作 Unity Prefab。当前 Unity Prefab 的实现状态以工程文件与工作记录为准。

- A3 页面内容
	- B1 色板与字体 → 四向间距 → 通用控件 → 首页卡片 → 棋盘与 HUD → 弹层 → 动效 → 资源检索 → Unity 实现对照 → 证据与缺口。

	- B2 对照明细：
		| 组件 | 参数与职责 | 展示状态 | 当前性质 |
		| --- | --- | --- | --- |
		| 文字按钮 | 文案、强调、disabled、busy | 正常、按下、聚焦、禁用、忙碌 | CSS 重构示例；按压比例来自原作配置 |
		| 图标按钮 | 图标、无障碍名称、点击上报 | 正常、按下、聚焦 | 原作图标 |
		| 模式卡 | 标题、图标、解锁条件、模式 | 锁定、可进入、按下 | 原作背景 + 当前工程组合参考 |
		| 关卡按钮 | 关号、普通/困难背景 | 普通、困难、按下 | 原作底图；浏览器不执行选关 |
		| 连胜卡 | 图标、连胜显示 | 零值、点击反馈 | 当前示例固定为 0，不执行结算 |
		| 开关 | checked、标签、切换事件 | 开、关、键盘切换 | 浏览器结构重构，非 Unity 已实现设置页 |
		| 单选按钮组 | 选项、selected | 普通/困难单选 | 补充状态示例 |
		| 昵称输入 | 文本、长度、校验反馈 | 空值错误、输入通过 | 补充状态示例，不保存 |
		| 进度 | value、max | 0–100% | 补充规范，未宣称原作存在此布局 |
		| 空态 | 是否有内容 | 有内容、无内容 | 补充示例 |
		| 棋盘格 | 区域色、局部显示状态 | 空白、排除、仓鼠、冲突 | 原作色值与图像；布局/冲突样式待核对 |
		| 生命与提示 HUD | 数量、图标、操作 | 3 次生命、3 次提示 | GameConfig 初值；不执行消耗 |
		| 设置弹层 | 开关与关闭 | 打开、切换、Esc、关闭 | 浏览器重构，布局未由原应用截图验证 |
		| 通关反馈 | 仓鼠图像、继续 | 打开、关闭、继续反馈 | 浏览器示例，不结算奖励 |
		| 网络失败 | 文案、重试状态 | 失败、忙碌、恢复可重试 | 原作文案 + 补充流程，不发送网络请求 |
		| Toast | message、duration | 显示、自动消失 | 补充规范 |
		| 资源检索 | query、type、page、selected | 搜索、空结果、分页、详情 | manifest 原始资源，48 项/页 |

	- B3 所有演示状态只在内存中维护，刷新重置；不修改游戏存档，不发送广告、登录、排行榜或业务请求。英文按钮只切换首页组件演示，不代表整个网页或 Unity 全部页面已完成本地化。

- A4 参数与证据边界
	- B1 浏览器参数入口为 [UI Library.config.js](<UI Library.config.js>)，修改后刷新页面。页面“统一参数”直接显示配置对象。该文件用于参考库演示，Unity 生产参数仍维护于对应 ScriptableObject，不建立双份生产配置。

	- B2 对照明细：
		| 参数 | 来源 / 维护方式 |
		| --- | --- |
		| regionColors | BoardView.regionColors，转换为 8 位 sRGB 十六进制值 |
		| press-scale=0.9 | ButtonPressEffect__level1__124.json |
		| 排行榜 10、每日 20、无限 100 | GameConfig，已与当前 HomeConfig.asset 核对 |
		| maxHearts=3、hintsPerLevel=3 | GameConfig；当前 HUD 只是固定展示 |
		| 原作字体 | 10 份导出文件均保留，演示选择中文 ZCOOLKuaiLe-Regular 与英文 Nunito |
		| 奶油/棕/粉/紫/蓝色板 | 根据原作素材视觉整理，非截图逐像素取色 |
		| 间距、字号、触控尺寸、弹窗样式 | 本库补充规范，未宣称来自原作布局测量 |
		| press-ms / enter-ms / Toast、busy | 浏览器演示补充参数，未测量原应用完整动画时序 |
		| Unity 统一设计基准 | 1080×1920、9:16 正向竖屏；原作首页/游戏 CanvasScaler，匹配值 0.5、PPU 100；网页逻辑 px 按实际显示比例换算 |

	- B3 主按钮展示背景保留原图比例；CSS 重构控件用独立边框与阴影。卡片背景按组合区域展示，拉伸切片需回 Unity 核对。`alphaBounds` 是导出 PNG 的可见像素边界，**不是 Unity Sprite rect / border**。`spriteBorder=null` 表示未核验，不表示切片为零。当前不提供已验证的通用九宫格数值。

	- B4 键盘可操作按钮、开关、输入和原生 dialog；弹窗支持 Esc、模态焦点约束及关闭后返回触发按钮。系统减少动态效果时停用动画/过渡，主动预览也省略动画并提示。

- A5 Unity 落地约定
	- B1 参照 `D:\UnityProject\Mahjong_j\Docs\0.1.0.0\Architecture.md` 与其 UI Library 的 Item 规范：

	- B2 `ClientMain` 创建和注入；Context 仅持字段；System 组织流程；Controller 业务决策和修改运行状态；Panel/Widget 显示和通过委托上报事件。

	- B3 沿用 PanelFactory、PanelRepository、AssetModule/default 标签及 Open/Close 生命周期。Logo 启动页按当前场景已有实现维护，不因网页另建加载体系。

	- B4 同类展示 Item 达到 2 个及以上，每种 Item 制作独立 Prefab 与对应脚本；实例共用资源和脚本，通过数据或变体区分。静态实例保留资源关联，动态实例从资源创建。

	- B5 Item 负责本项引用、显示、状态与事件；页面组织，Controller 决策。通用按压脚本不代替 Item 业务显示职责。

	- B6 文案经 L10NModule；每种语言通过 L10NFontSO 管理完整 TMP 字体，不以多个字体拼接作为生产实现。

	- B7 当前首页的多个卡片仍由 Panel_Home 直接持有，作为后续复用整改项；第一版未重构现有 Prefab 和代码。

	- B8 新单元的具体类名与 SO 类型随实现确定；不从浏览器演示自动生成新的生产架构。

- A6 更新与验证
	- B1 在当前项目根目录执行 `python Docs/UILibrary/extract.py`。需要 Pillow；可传 `--source` 指定原作导出目录。提取脚本只写本库的 `assets/`、`evidence/`、`references/`、`manifest.json`、`catalog.js`，不修改源资料与 Unity 运行文件。现有配置与主题样式不会被重新提取覆盖；更换 APK 样本后需重新核对配置中的资源 ID 和来源日期。

	- B2 有 Node.js 和 Playwright 时运行 `node Docs/UILibrary/verify.cjs`。通过 `NODE_PATH` 指定可用的 Playwright 模块路径，`UI_BROWSER` 可指定 Chrome/Edge 可执行文件。验证使用后台浏览器，输出 `verification-results.json` 和 `previews/`；不操纵前台窗口。

	- B3 实际结果见 [Verification.md](Verification.md)，缺口与需要用户提供的资料见 [Missing.md](Missing.md)。项目修改与后续事项同步记录到 `D:\UnityProject\Hamdoku2\WORK_LOG.md`。
