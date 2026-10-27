# 项目工作记录

记录实际完成的工作、验证结果及尚未完成的功能。按日期追加，每项说明修改内容、主要文件和验证情况。

## 2026-10-27

### 项目约定

- 创建 `AGENTS.md`，明确当前 Unity 项目为 `D:\UnityProject\Hamdoku2`，待复刻原项目为 `D:\0000001apkUnbag\01_逆向工程项目\Hamdoku2`。
- 明确以 `D:\UnityProject\Mahjong_j` 为架构参考。
- 创建本工作记录，并在 `AGENTS.md` 中添加后续更新要求。

### 启动架构

- 搭建 `ClientMain → System → Controller → UI / Module` 的运行结构，并分离运行时与编辑器程序集。
- `ClientMain` 负责创建和注入依赖；`GameContext` 仅保存字段；Controller 负责修改运行状态；System 负责组织流程。
- 实现启动状态、完成和失败通知、重复初始化处理及退出清理。
- 主要文件：`Assets/Src_Runtime/ClientMain.cs`、`Assets/Src_Runtime/GameContext.cs`、`Assets/Src_Runtime/System/Loading/`、`Assets/Src_Runtime/Controllers/LoadingController.cs`。

### Logo 面板

- 导入原作背景、完整 Logo、动画分片及所需音效。
- 实现 `Panel_Logo`、面板 Controller、`Widget_LogoIntro` 与 `LogoConfigSO`；动画配置初值依据原作提取资料。
- 实现分片入场、回弹、音效时序、完整 Logo 静止姿态、呼吸和上下浮动。
- Logo 使用不受 `Time.timeScale` 影响的时间更新，启动流程包含最低展示时长和一次性完成通知。
- 在现有 `Scene_Main` 中配置 `ClientMain`、Canvas、Logo 面板和音频引用，加入安全区域适配及背景按比例铺满。
- 主要资源：`Assets/Res_Runtime/Scene_Main.unity`、`Assets/Res_Runtime/Config/LogoConfig.asset`、`Assets/Res_Runtime/UI/Logo/`。
- 验证：Unity 编译、Play Mode 启动、暂停游戏时间时的 Logo 更新、音效次数、重复初始化、释放及横竖屏截图检查通过。记录位于 `Logs/LogoValidation/`。
- 边界：动画按提取参数与可用代码资料还原，尚未完成与原应用运行录像逐帧对比。

### 首页与本地进度

- 实现 `AssetModule`、`PanelFactory`、`PanelRepository` 和面板枚举，首页以 Addressables 的 `default` 标签加载 Prefab。
- 接入兼容当前 Unity 6000.5.2f1 的 Addressables 2.10.3；参考项目所用 1.22.3 因调用已移除 API 无法在当前版本编译。
- 实现 `HomeSystem`、`HomeController`、`HomeState`、`HomeSystemEvents`、`Panel_Home` 及面板 Controller。
- 创建首页 Prefab，接入原作卡片、图标、Logo、按钮音效以及安全区域和横竖屏适配。
- 实现主线关卡显示、困难关表现，以及排行榜通关 10 关、每日挑战通关 20 关、无限模式通关 100 关的解锁条件；业务配置由 `HomeConfigSO` 维护。
- 实现本地 JSON 进度的写入与读取，包括教程完成状态、主线通关数、语言和每日连胜数；写入先使用临时文件，再替换正式文件。
- 接入中英文文案 SO、字体映射和离线烘焙字体；语言及字体统一由 `L10NModule` 管理。
- 打通 Logo 到首页的切换，场景加入 Input System 的 EventSystem，锁定按钮可点击查看解锁条件。
- 新玩家进入首页时上报教程请求；主线、每日挑战、无限模式、排行榜及设置按钮通过委托上报对应请求。
- 修正英文每日挑战标题与图标重叠的间距。
- 主要资源：`Assets/Res_Runtime/UI/Home/Panel_Home.prefab`、`Assets/Res_Runtime/Config/HomeConfig.asset`、`Assets/Res_Runtime/Localization/`、`Assets/Res_Runtime/Font/`、`Assets/AddressableAssetsData/`。
- 验证：编译、资源标签加载、Logo 到首页切换、真实 EventSystem 射线和点击、10／20／100 关解锁边界、困难关表现、中英文字体、重复打开、存档往返读取、重新加载场景恢复进度和退出清理通过；运行错误为 0。Addressables 内容打包通过。
- 验证在隔离副本中执行，测试用通关进度未复制到当前项目。记录和截图位于 `Logs/HomeValidation/`。

### Addressables 启动报错修复

- 用户反馈 `Invalid path in TextDataProvider`，路径指向 `Library/com.unity.addressables/aa/Windows/settings.json`，并伴随运行数据为空及资源键加载失败。
- 原因：同步首页资源时遗漏 `ProjectSettings/EditorBuildSettings.asset` 中的 `com.unity.addressableassets` 注册项，编辑器未正确关联已有 Addressables 配置。
- 补齐注册项，并核对其 GUID 与 `Assets/AddressableAssetsData/DefaultObject.asset.meta` 一致。
- 修改 `Assets/Src_Editor/EM/HomeSetupEM.cs`，使配置工具重新注册已有 DefaultObject，避免因注册缺失而重复创建配置。
- 验证：不调用首页配置工具，直接打开 `Scene_Main` 进入 Play Mode，首页启动与相关检查通过，运行错误为 0。记录位于 `Logs/HomeValidation/AddressablesFix/`。

### 项目规范文档整理

- 经用户确认，参考 Mahjong_j 的协作与架构约定，重写根目录 `AGENTS.md`；未创建或复制 Docs 文档。
- 建立项目定位、协作、文档格式、分层与 Context、代码、UI 与资源、配置与本地化、验证交付及工作记录共九部分规范。
- 保留现有 `WORK_LOG.md` 的日期记录格式与历史内容，明确后续同步更新要求。
- 结合当前实际实现注明 Scene_Main、Panel_Logo 启动例外、首页 Prefab 管理、中英文本地化入口、版本来源，以及隔离验证同步时的配置检查。
- 验证：核对规范与当前项目入口、Context、包版本和本地化 API；本次仅修改 Markdown，未修改业务代码、场景或资源，未运行 Unity 测试。

### 分辨率与屏幕方向标准

- 核对原项目 `CanvasScaler__level1__145.json` 和 `CanvasScaler__level2__147.json`，首页与游戏场景均为 1080 × 1920、Scale With Screen Size、宽高匹配值 0.5、Reference Pixels Per Unit 100。
- 将此配置确定为本项目 UI 设计基准，并补充至 `AGENTS.md`；实际手机显示继续适配设备尺寸与安全区域，不固定设备渲染分辨率。
- 当前 `Scene_Main` 的 CanvasScaler 已符合基准，无需改动；`ProjectSettings/ProjectSettings.asset` 默认方向改为正向竖屏，桌面和 Android 默认窗口改为 1080 × 1920，Web 默认预览改为 540 × 960，关闭其他方向的自动旋转选项。
- 编辑器 Game 视图有独立尺寸设置，后续以 1080 × 1920 或 9:16 预览验收；本次未操作 Game 视图，也未执行真机方向验证。
- 验证：对照原作配置、当前场景和项目设置进行静态核对；未修改业务脚本，未运行 Unity 编译或 Play Mode。

### 1080 × 1920 预览统一与布局验证

- 检查当前场景与首页 Prefab，Canvas 和首页 Content 均已采用 1080 × 1920；现有 Game 视图布局文件显示预览为 750 × 1650。
- 新增 `Assets/Src_Runtime/Generic/Const/UIResolutionConst.cs`，集中维护 UI 参考尺寸、宽高匹配和像素单位常量；Logo 与首页制作工具改为引用同一尺寸常量，避免后续生成资产时基准不一致。
- 新增 `Assets/Src_Editor/EM/ResolutionSetupEM.cs`，提供 `Hamdoku/Preview/1080 x 1920 Portrait` 菜单，选择或创建固定分辨率预览。当前工程已写入一次性请求，下次 Unity 脚本重载后应用；若正在 Play Mode，则退出后应用。该工具仅改变编辑器预览，不强制设备渲染分辨率。
- 未重建场景或 Prefab，现有标准比例下的布局经过截图核对，无需为分辨率改变重新排列控件。
- 验证：隔离副本使用 Unity 6000.5.2f1 编译并运行，成功选择 1080 × 1920 固定 Game 预览，确认竖屏默认方向、窗口尺寸、Canvas 模式及 0.5 匹配值；Logo 到首页正常。
- 验证 1080 × 1920、1080 × 2400、720 × 1280 及模拟顶部 110／底部 70 像素安全区，首页五个按钮均位于可用区域，截图检查通过，运行错误为 0。记录与图片位于 `Logs/ResolutionValidation/`；未进行真机验证。

### 当前未完成事项

以下事项截至本次记录仍未完成，分辨率标准的确定不改变这些功能的实现状态。

- 新手教学、第一关棋盘与实际游戏规则流程尚未接入。
- 每日挑战、无限模式、排行榜和设置页尚未实现；目前首页负责锁定提示与请求上报，目标功能显示“功能准备中”。
- 每日连胜目前只读取和显示存档值，尚未实现连胜结算。
- 尚未接入真实广告、登录、云存档或排行榜服务。
- 当前验证覆盖编辑器运行与 Addressables 内容打包，尚未完成 Android 安装包及真机触摸、音频和性能验证。


### Hamdoku2 离线 UI 参考库（2026-10-27）

- 按已确认范围创建 `Docs/UILibrary/`，参考麻将项目最新组件库的组织方式，以 Hamdoku 原作素材建立奶油色、棕色与柔和功能色的独立参考库。
- 提供离线 HTML/CSS/JS、统一浏览器配置、色板与字体、间距规范、按钮与开关、首页解锁状态、中英首页标题、棋盘视觉状态、弹窗、动效和资源搜索/详情/分页。
- 复制 708 张 Sprite、10 份字体、11 份配置/文案证据及 4 张当前工程首页验证截图；记录来源资源包、pathID、尺寸、透明边界和 SHA-256。当前工程截图明确标注为复刻工程截图，非原应用截图。
- 核对原作首页/游戏 CanvasScaler 与最新项目约定，参考库记录 1080×1920、9:16 正向竖屏、匹配值 0.5、PPU 100；未修改生产 Canvas 设置。
- 主要文件：`Docs/UILibrary/UI Library.html`、`UI Library.css`、`UI Library.js`、`UI Library.config.js`、`extract.py`、`manifest.json`、`catalog.js`、`README.md`、`Missing.md`、`Verification.md`、`verify.cjs`；在 `AGENTS.md` 增加文档入口。
- 验证：Chrome 后台 file:// 检查通过；718 项资源、11 份证据及 4 张截图哈希一致，708 张 PNG 全部解码；1440/768/375 px 无页面横向溢出；解锁边界、输入/空态/进度、棋盘状态、弹窗与焦点恢复、加载/重试、检索分页和减少动态效果检查通过，无 JavaScript/控制台/资源请求错误。已人工查看桌面概览、首页、棋盘和手机设置预览。
- 验证明细与生成截图：`Docs/UILibrary/verification-results.json`、`Docs/UILibrary/previews/`。初次弹窗截图采在动画开始，已修订脚本等待动画结束并更新最终预览。
- 尚未完成：原应用截图/操作录像对照、Sprite 九宫格逐项核验、其他页面与语言全覆盖、音频触发映射。当前首页模式卡 Item 复用记录为后续整改项，本轮未重构运行资源。
- 本次未修改 Unity 业务、Prefab、场景或生产 SO，未运行 Unity 编译、Play Mode、Addressables 内容打包、Android 构建或真机检查。浏览器棋盘与弹层为明确标注的示例，不代表玩法或目标页面已完成。用户需要补充的资料按优先级列于 `Docs/UILibrary/Missing.md`。
