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


### UI参考库第二版：组件补齐与用户截图对照（2026-10-27）

- 按用户确认的五项顺序补齐按钮规格/字形视觉居中、九宫格与可调间距、标签页/列表、Hamdoku专属组件和游戏截图对照。
- 新增 `Docs/UILibrary/UI Library.components.js`、`UI Library.components.css`，扩展 `UI Library.config.js` 与入口。提供五种按钮皮肤及标准/紧凑/禁用/忙碌状态、动态文案测量、160–360px切片拉伸、4–32px内距、文字层级、键盘标签、0/1/2/6项列表、徽标、骨架及补充输入状态。
- 接收并保存8张用户截图，包含首页、棋盘、设置、商店、每日连胜、个人资料6类画面；两张重复首页以哈希标记duplicateOf。全部原件保留于 `Docs/UILibrary/references/original/`，与4张当前工程旧截图区分来源；未将剪贴板路径作为后续浏览依赖。
- 扩展 `extract.py`，只读解析原资源的708项Sprite元数据，记录原始rect/border/PPU/textureRect/裁切偏移及导出border换算；加入ShopCatalog快照。总计718项资源、12份证据、12张参考图，原PNG/字体字节保持不变。
- 专属组合支持8个标签：首页、截图转录9×9棋盘、七行设置、7个商品、七天连胜、个人资料以及补充的日历/排行榜。个人资料展示18项头像/姿态、19个边框和6件服装；提供12种区域图案目录。日历、排行榜与语言弹层明确标记未有对应截图。
- 修复本地file://下图案mask的CORS问题，改用原PNG字节内嵌；商店礼包图核对为offer_art_starter_pack。截图与浏览器组合可并排查看，重写README、Missing和Verification，移除已不准确的“没有原应用画面”“切片全部未知”等缺口描述。
- 验证：`verify.cjs`与新增 `verify-components.cjs` 后台Chrome检查通过，708张图像解码、资源/证据/截图哈希检查通过；8个组合在1440/768/375px无横向溢出，按钮测量、切片端点、间距、列表键盘/领取、设置、棋盘、商品说明、头像/边框分类选择、日历、排行榜状态及资源用途过滤通过，无JavaScript/控制台/资源请求错误。已查看桌面/手机预览，结果在 `verification-results.json`、`verification-components.json` 与 `previews/`。
- 未完成：逐像素视觉匹配、逐字体截图像素居中验收、全部资源切片拉伸验收、完整动画与输入语义、商品服务及真实奖励。教程、通关、失败/复活、确认弹窗、日历/排行榜/无限、语言列表、商店下半部分与个人资料编辑/服装佩戴等缺图状态详见Missing。
- 本轮未修改Unity业务/Prefab/场景/SO或存档，未运行Unity编译、Play Mode、内容打包、APK构建和真机检查。网页可交互不等于对应Unity页面或服务已实现。

### UI 资料待办记录（2026-10-27）

- 按用户要求新增 `Docs/UILibrary/TODO.md`，将失败/复活、退出/重新开始确认、每日挑战/排行榜/无限模式、语言/资料编辑/服装佩戴、购买各结果五类资料列为未完成待办，留待后续补充。
- 记录已查看 `handoku.mp4` 的范围，明确教程、通关与商店下半部分已有录像依据，但尚未接入参考库；同步修正 `Missing.md` 中对应的过时缺口，在 `AGENTS.md` 添加 TODO 入口。
- 验证：静态核对五类待办均保留未完成状态，文档相对链接有效。仅修改文档，未修改参考库交互或 Unity 文件，未运行浏览器或 Unity 测试。

### Logo 启动页与首页按原作整理（2026-10-27）

- 对照原项目 `LobbyLayoutConfig__resources.assets__1481.json`、level1 的 RectTransform/Image、LogoAnimator 配置和用户提供的首页截图，定点调整现有场景及 Prefab，未重建启动、资源加载或面板管理体系。
- 修正首页把裁切后的 Logo 当作完整 1080 方形构图拉伸的问题，按原作 800 方形节点换算可见尺寸；启动页与首页统一到原作 Logo 锚点和偏移。启动页新增固定设计坐标 Content，沿用首页的安全区域等比适配方式。
- 调整每日挑战图标、标题、日期、开始按钮、排行榜图标、主线按钮与顶部入口的位置和尺寸；恢复三张卡片的 80 像素 Sprite border，并按原 Image 的 1.8／2.2 倍率切片，避免圆角被放大。主线文案改为白色；修正无限模式背景缩窄导致图标落在按钮外的问题。
- 使用原作成品图补齐商店、默认个人资料头像与边框；每日连胜卡接入点击。新增 Shop／Profile／Streak 请求，仍经 Panel 委托与 Controller 处理，目标页尚未实现，明确显示“功能准备中”。设置入口去除原作截图中没有的额外文字标签。
- 首页补齐原 LogoAnimator 的上下浮动参数（高度 2.5、速度 1.2），由 HomeConfigSO 维护；重复打开时恢复初始显示姿态。保留现有关卡进度、锁定提示和本地化。无限模式的窄按钮排布属于对现有复刻布局的修复，尚无对应原应用截图作逐像素确认。
- 主要文件：`Assets/Res_Runtime/Scene_Main.unity`、`Assets/Res_Runtime/UI/Home/Panel_Home.prefab`、三张卡片 `.meta`、新增三个原作图片及 `.meta`、`HomeConfig.asset`、`Panel_Home.cs`、`Panel_Logo.cs`、`Panel_Home_Controller.cs`、`HomeRequestType.cs`、`HomeConfigSO.cs`、`HomeSetupEM.cs`、`LogoSetupEM.cs`。
- 验证：隔离副本使用 Unity 6000.5.2f1，编译和实际 Play Mode 通过；正式 Scene_Main 启动、default 标签资源加载、八个按钮中心射线命中、三个新增请求、重复 Open、Close/Open、中英切换均通过，项目运行错误 0。生成并查看 1080×1920、1080×2400 和模拟安全区域的相机后台渲染截图；后台渲染不等同编辑器 Game 视图或手机验收。
- 首轮验证被 UnityEditor.Search.SearchDatabase 自身索引越界异常中断，已单独保留初次失败记录与编辑器诊断；随后将该编辑器异常与项目运行错误分开记录，后续验证通过。记录在 `Logs/UIRefineValidation/`，编译及运行日志在 `Logs/UIRefine-Compile.log`、`Logs/UIRefine-Play.log`，初次记录在 `Logs/UIRefine-FirstAttempt.txt`。
- 同步后核对场景、Prefab、图片 `.meta` 字节一致、内部 fileID 引用完整、Addressables 注册与 DefaultObject GUID 正确。未同步 Library、测试存档或测试用 HomeConfig；正式存档文件名保持不变。当前工程直接使用已绑定资产，无需先执行制作菜单。本轮未在当前已打开的 Unity 窗口再执行 Play Mode。
- 尚未实现倒计时、每日完成勾选、连胜奖励、商店／个人资料／连胜详情页及真实服务；没有以模拟倒计时或奖励冒充完成。尚未做逐像素复刻、动画录像逐帧对照、Addressables 重新内容打包、APK 构建、安装或真机验证。


### 追加排行榜与葵花籽耗尽截图（2026-10-27）

- 保存用户新提供的两张游戏画面至 `Docs/UILibrary/references/original/ranking-overlay.png` 与 `seed-empty-revive.png`，在 `index.json` 登记来源、尺寸和SHA-256。
- 更新 `TODO.md` 与 `Missing.md`：排行榜前三名/部分条目/个人行及葵花籽耗尽选择界面已有截图；广告结果、棋盘恢复、重新开始确认、其他排名状态仍未覆盖，五类TODO均保留未完成。
- 验证：两张归档文件与输入哈希一致，可解码，TODO包含五个未完成条目，相对链接有效。仅归档与更新文档，未修改参考库组件、catalog/manifest发布快照或Unity文件，未进行运行时验收。

### Panel_Logo 空引用修复与瓜子加载页补齐（2026-10-27）

- 用户反馈 `Panel_Logo.Ctor` 抛出 InvalidOperationException。初次核查正式场景发现新增必填的 `contentRoot` 为 0，而 Content 节点已存在；随后场景被保存为有效的新 Content 绑定，本轮沿用该绑定和当前 Logo 父节点，未覆盖为旧验证副本的节点 ID。错误提示补全 ContentRoot，避免误导为 SafeRoot 或 Widget_LogoIntro 缺失。
- 修正 `HomeSetupEM`：引用丢失时优先复用 LogoMotion 的真实 Content 父节点，并显式标脏组件，避免再次生成平行 Content。`LogoSetupEM` 加入仅在编辑器执行的已知绑定迁移；它修复序列化引用，运行时继续严格校验。为当前已打开场景准备一次性编辑器迁移请求，退出 Play／脚本重载后或下次进入 Play 前应用，无需手工执行制作菜单；如有未保存场景修改则保留脏状态，不自动保存用户其他修改。
- 根据用户新截图，纠正上一轮将启动页对齐首页的处理：启动页单独采用较小的 Logo 与上移构图，补齐格言、署名、底部版权和五颗瓜子。复用原作 `icon_life`、`seed_off`、`seed_pop` 图像，填充后隐藏对应虚线空槽，显示当前瓜子的弹动标记。
- 参考原作 `LoadingScreenConfig__resources.assets__1480.json`、`LoadingScreen__level0__12.json` 和中英文原文，使用五颗、75 像素槽位、14 像素间距、0.34 秒弹动、1.18 弹动倍率及 0.3 秒完成停留。版面按用户截图在 1080×1920 设计坐标中落实，未宣称逐像素匹配或完整格言随机库已实现。
- 加载进度由 Controller 根据 Addressables 实际操作进度、最低展示时长及 Logo 动画完成状态共同推进；全部完成且停留结束后才进入首页。这是当前复刻工程的启动阶段进度，不是下载字节百分比，也不是原应用内部进度算法的运行验证。
- 新增三个独立 L10NSO：Loading_Quote、Loading_Author、Loading_Copyright；启动时仍使用同一 L10NModule，按既有存档语言注册字体，完整资源加载后替换本地化数据集并重新应用语言。更新原有中英静态字体图集以覆盖新增字符，未引入字体 fallback。制作工具修复静态字体再次烘焙时未取得源字体的问题，连续执行两次配置通过。
- 主要文件：`Scene_Main.unity`、`LogoConfig.asset`、`UI/Logo/` 三张图片与 meta、`Font/Chinese SDF.asset`、`Font/English SDF.asset`、三个加载文案 SO、Addressables Home 组；以及 `Panel_Logo.cs`、`Panel_Logo_Controller.cs`、`LoadingController.cs`、`LoadingSystem.cs`、`LoadingState.cs`、`AssetModule.cs`、`L10NModule.cs`、`HomeController.cs`、`LogoConfigSO.cs`、`UINameType.cs`、两份现有制作工具。
- 验证：隔离副本 Unity 6000.5.2f1 编译通过；不调用配置菜单直接加载保存的 Scene_Main，Play Mode 启动、ContentRoot 绑定、本地化由启动到完整资源的切换、进度单调及完成条件、五颗瓜子 0／60／100% 显示、标记隐藏、完成停留和首页关闭重开均通过，项目运行错误 0。检查中英字体与 1080×1920／1080×2400 后台相机渲染截图；静态显示状态检查不代表原应用加载过程的实时对比。
- Unity Search 的编辑器索引异常单独记录，未作为项目错误忽略。制作工具首轮批处理未打开 Scene_Main、重复静态字体烘焙源引用问题均已修复并复跑。记录、脚本、用户原图和最终截图位于 `Logs/LoadingScreenValidation/`；另有 `Logs/LogoBindingFix-Play.log`、`Logs/LoadingScreen-Setup.log`、`Logs/LoadingScreen-Play.log`。
- 同步后核对场景、LogoConfig、字体图集、三份文案与 meta、Addressables 组字节一致，全部 Panel_Logo 必填引用非 0，五组填充／空槽引用及场景内部 fileID 有效，Addressables DefaultObject 注册正确。正式 HomeConfig 与存档文件名保留，未同步验证存档或测试用 HomeConfig。尚未在用户当前 Unity 窗口执行 Play，未重新内容打包、构建 APK、安装或真机验证。

### UI 参考库新增玩法分析（2026-10-27）

- 按用户要求参考 Mahjong_j/Docs/RichMahjongMatch/01_玩法文档.html 的阅读结构，新增 Docs/UILibrary/玩法分析.html，采用 Hamdoku 奶油色与棕色风格；内容覆盖核心循环、三条规则、单击/双击/滑动教程、生命与道具、失败补救、主线/每日/连胜/排行榜/无限模式及表现和结算。
- 加入可操作4×4约束示意，使用原作 Campaign 样例0区域与答案；明确区分示意规则、原作文案/配置/截图、原作待验证行为和当前工程实现。未将静态配置组合推断为已验证运行规则，未宣称广告、购买或排行榜服务已经完成。
- 只读复制原资料 Campaign_样例.md 与 Tutorial_4x4__sharedassets1.assets__11.json 到本库 evidence，两份副本与原件 SHA-256 一致；本页独立引用，不改既有 catalog/manifest 发布快照。复用棋盘、耗尽提示、每日连胜和排行榜四张已归档截图。
- 在 UI Library.html 侧栏添加玩法分析入口，更新 README.md 与 AGENTS.md 文档入口；保留已有项目修改。预览位于 Docs/UILibrary/previews/gameplay-analysis-1440.png 和 gameplay-analysis-375.png。
- 验证环境与结果：Windows 后台 Chrome / Playwright，以 file:// 打开；31处本地文件链接有效，4张原图加载解码正常，1440/768/375px无页面横向溢出，16格规则示意的相邻冲突/暂不冲突/显示布局/重置及参考库入口跳转通过，页面JavaScript、控制台及请求错误为0。手机宽表采用内部横向滚动，避免配置字段挤压正文。
- 未完成或未验证：原作更深层落子判定、精确输入时序、道具效果/库存及广告结果、各模式完整运行流程、结算公式与购买服务仍需核对；既有资料TODO状态不变。本次只修改文档及网页，不修改Unity脚本/资源/场景/SO/存档，未执行Unity编译、Play Mode、内容打包、APK构建、安装或真机检查。
### 每日连胜页面与本地业务迁移（2026-10-27）

- 按用户确认范围新增 `StreakSystem`、`StreakController`、`StreakState`、`StreakSaveModel`、`Panel_Streak_Controller`、`Panel_Streak`、`Widget_StreakDay`、`Widget_StreakPlant`、`StreakConfigSO` 和 `StreakSetupEM`。沿用 ClientMain 注入、Controller 修改运行数据、Panel/Widget 委托上报，以及 PanelFactory/Repository 的 Ctor、Init、TearDown 生命周期；未新增单例、接口或资源加载体系。
- 只读核对原作 GameProgress 的 GetDailyStreak、NotifyWin、OnFirstWinOfDay、StreakSlot、StreakStage、StreakCut、AccrueStreakReward 及原 GameConfig、StreakPageConfig。按当天第一次有效胜利记录日期，同日重复胜利不累计；今天尚未获胜时保留昨日连续天数，漏日后当前连胜归零、最佳记录保留。当前有效来源接入主线非教程胜利，其他模式后续在其权威结算中复用 RecordWin，未把登录或打开页面当作胜利。
- 原作七天周期第 3/5/7 天的基础奖励为提示 1、排除辅助 1、提示与排除辅助各 1；配置由 StreakConfig.asset 维护，并按日期与周期计算待领数量。实际领取后保存额外库存；棋盘本关原有道具用尽时消耗该库存，重复点击领取、重复结算及礼盒预览不重复发奖。胜利记录与完成棋盘由同一次进度保存写入；待展示页面标记、未领奖励与已领库存保留在存档。
- 接通首页连胜入口；当天首胜在结算继续后进入连胜页，继续返回后续主线，返回按钮回到首页。新增正式 Panel_Streak.prefab、Widget_StreakDay.prefab、19 份中英文 L10NSO 及 Addressables/default 注册。采用 1080×1920、安全区域和背景比例铺满，包含当前/最佳连胜、星期与完成勾选、礼盒预览、幼苗/花苞/花瓣/盛开和后续花丛、蝴蝶表现。原作图片直接接入，光晕和胶囊底图为编辑器烘焙的正式图像；修复植物子节点锚点、礼盒尺寸及继续按钮皮肤。成长动画和后期花丛排布为依据静态资料落实的复刻实现，未宣称原作录像逐帧或逐像素一致。
- 按原配置实现断签恢复资格和放弃入口。广告 SDK 尚未接入，恢复按钮明确显示不可用，不恢复日期、不模拟广告成功或追加奖励；广告加倍、云端时间与云存档也未接入。日期采用设备本地日历；日期回退不补记旧日，不宣称具备服务端校时或防作弊能力。
- 扩展现有 PlayerSaveModel/SaveModule 与 HomeController 初始化。共享存档版本保持其他并行功能已升级的 4，制作工具不会降级版本；旧版缺少日期证据的 dailyStreak 仅保留为最佳记录，不伪造历史胜利或补发奖励。验证发现 JsonUtility 将可空嵌套对象写为全零数据，现有存档读写统一采用 DataContractJsonSerializer，相关模型显式声明数据成员，兼容旧字段缺省并保留真正的 null；维持版本/合法性检查、临时文件与替换写入，读取错误不静默重置。
- 主要接入文件：ClientMain.cs、GameContext.cs、HomeController.cs、GameController.cs、Panel_Game_Controller.cs、PlayerSaveModel.cs、SaveModule.cs、AssetModule.cs、UINameType.cs、UIPanelType.cs；新增连胜脚本分别位于既有 System、Controllers、Entities_Sub、UI、Module/Assets/TM 和 Src_Editor/EM 目录，资源位于 Assets/Res_Runtime/UI/Streak、Config/StreakConfig.asset 与 Localization/Streak_*.asset。保留其他对话的游戏与排行榜改动，未覆盖其场景、主线 Prefab、配置或正式玩家进度。
- 验证：隔离副本 Unity 6000.5.2f1 编译通过；以当前工程完整快照直接运行已保存 Scene_Main，不调用制作菜单，Play Mode 92 项检查通过、项目运行错误 0。覆盖首页实际按钮、主线真实解题胜利和结算继续跳转、当前/最佳记录、同日防重、3/5/7 日奖励、重复领取、库存持久化与真实棋盘消耗、关闭重开、跨年/闰日/漏日/回退日期、断签未接入状态与放弃、版本 1/2 迁移和损坏存档错误。中英字体及界面切换、1080×1920/1080×2400/1080×1620 和模拟顶部 110/底部 70 像素安全区域、按钮中心射线命中均通过；另查看第 4/30/60 天成长截图。测试日期、连续通关和道具数量只存在于隔离验证存档，不写回正式进度。
- 最初隔离快照包含另一功能尚未完成的文件，曾出现编译依赖不完整；序列化初次验证及中途共享资源 GUID 同步也曾失败，均保留日志，修正后以当前完整快照复跑通过。UnityEditor.Search 的 SearchDatabase 越界异常单独记录为编辑器诊断，未混入项目运行错误。最终记录与截图在 Logs/StreakValidation，验证辅助代码和同步/GUID 核对记录在 Logs/StreakMigration。
- 同步时按资源路径映射并保留当前工程已有 GUID，逐项同步新资源、Prefab、SO、本地化、字体及 Streak 组/Schema；未复制 Library、验证专用脚本到正式程序集、验证 HomeConfig 或验证存档。核对本轮连胜脚本及共享接入点与最终验证快照一致，已同步资源与快照一致；验证结束后另一任务向 RankingConfigSO 增加 assetVersion 字段，该项不属于本轮连胜验证范围，正式存档文件名仍为 hamdoku-progress.json，EditorBuildSettings 的 Addressables DefaultObject 注册有效。用户当前打开的 Unity 窗口未由本轮操作进入 Play Mode；相机后台渲染不替代 Game 视图操作或手机触摸验收。尚未执行本轮 Addressables 内容打包、应用/APK 构建、安装或真机验证。

### 首批玩法迁移：教程、五关主线与局内恢复（2026-10-27）

- 按用户要求先创建 `Docs/GameplayMigrationTODO.md`，在 `AGENTS.md` 添加入口，再按任务项实施。本批完成独立 4×4 教程与主线前 5 关；第 6 关明确提示尚待迁移，没有循环地图伪造后续进度。
- 使用原作 `Tutorial_4x4` 的区域和答案；首个引导落点依据 native `PlaceGuided(3,1)`。实现双击放置、单击排除／取消排除、滑动连续标记、教程高亮和自由完成。原作完整确认步骤、手指及动画时序仍待补齐。
- 根据 1–5 关 grade 1 上限、native 尺寸表候选及 Campaign 尺寸交叉核对，首批尺寸为 4、5、6、6、8；导入 146 张对应 DDA 地图为独立 PuzzleSO（4×4 为 9 张、5×5 为 6 张、6×6 为 86 张、8×8 为 45 张）。按尺寸池选择并避开上一张 ID，保存具体地图 ID，返回／重载不重新抽图。此实现没有宣称还原完整动态选图、地图变换、游标、技能升降或原应用运行结果。
- 实现 GameState、PuzzleModule、GameSystem 和 GameController；规则检查覆盖每行、每列、每区域一只及八方向不相邻。依据原作 GameState.IsCorrectCell 调用关系，带答案的落点同时校验答案，错误扣瓜子且不放入仓鼠。
- 新增正式 Panel_Game、Panel_GameDialog 与 Widget_BoardCell Prefab，沿用原有 Canvas、PanelFactory、PanelRepository 和 Addressables default 加载；没有新建平行启动或 UI 管理体系。导入 29 张实际使用的原作图片与 4 段音效，序列化绑定实际落在资源中。
- 接入基础分数、仓鼠计数、瓜子、计时、通关／完美标题、下一关、返回首页、取消／确认重开、生命耗尽及同棋盘重新开始。提示揭示实际答案；排除辅助标记已放仓鼠产生的冲突格。广告复活按钮明确显示服务未接入，不发放模拟奖励。
- 新增 36 份独立中英文 L10NSO，继续使用 L10NModule 的统一文字与字体入口；扩展现有静态字体图集，未加字体 fallback。全局语言切换补齐已打开游戏页与游戏弹层的刷新。
- 存档扩展具体棋盘、标记、生命、错误、道具、分数、计时、教程步骤及状态；恢复时校验地图 ID、关号、答案、枚举和完成状态。完成结果防止重复加关；返回首页后的已完成局清空，局内及失败局保留。暂停／退出沿用 Controller 保存和临时文件替换写入。
- 检查期间同工程同步加入排行榜与连胜代码，保留它们的 Context、入口、通关记录和奖励道具接入，没有用旧副本覆盖共享脚本。联合检查暴露 Unity JSON 对缺失引用字段的兼容问题；保留合并后的 DataContract JSON 与存档版本 4 约定，明确序列化错误，实际验证旧版 1 数据读取、当前存档往返及 activePuzzle 为 null 的恢复，不静默重置用户进度。
- 为满足同步后的启动依赖，使用现有 StreakSetupEM 在隔离副本制作正式连胜资产并补齐当前工程缺少的资源。最终核对采用连胜任务更新后的七天奖励配置、Single Sprite 导入及 PetalRing 绑定；补节点时保留原有层级，未销毁重建首页或游戏页。连胜全量表现及排行榜服务仍按其各自任务验证，本条不将其整体记为本批完成。
- 主要文件：`Assets/Src_Runtime/Controllers/GameController.cs`、`Controllers/Panel/Game/`、`System/Game/`、`Module/Puzzle/PuzzleModule.cs`、`Module/Assets/TM/GameConfigSO.cs`、`PuzzleSO.cs`、`UI/Panel/Game/`、`UI/Widget/Widget_Board.cs`、`Widget_BoardCell.cs`、`Entities_Sub/Save/PuzzleSaveModel.cs`；并接入已有 ClientMain、GameContext、HomeController、AssetModule、SaveModule、PlayerSaveModel 与枚举。制作入口为 `Assets/Src_Editor/EM/GameSetupEM.cs`；正式资源位于 `Assets/Res_Runtime/UI/Game/`、`Audio/Game/`、`Config/Puzzles/`、`Config/GameConfig.asset` 和 `Localization/Game_*.asset`。
- 验证：Unity 6000.5.2f1／Addressables 2.10.3 隔离副本，直接使用正式 Scene_Main 与资产快照，无需先执行制作菜单；编译和实际 Play Mode 通过，项目运行错误 0。检查唯一 EventSystem、真实射线命中与 PointerEventData 分发、教程三种手势、146 张地图答案、错误扣瓜子、耗尽输入阻断、广告无假奖励、同图重开、提示与排除、取消重开、弹层暂停计时、退出存档、场景实际重载恢复、重复 Open／结算、五关推进与批次边界、面板释放。另核对全局语言入口对游戏页和已打开结算弹层的即时刷新。
- 画面：已生成并查看中文／英文、1080×1920、1080×2400 及注入安全区的后台相机渲染截图；文本字体覆盖与实际绑定通过。它们不是用户当前 Game 视图的人工点击、手机触摸或原应用逐像素验收；音效已接入但没有实际扬声器试听。
- 内容打包：最终 Windows Addressables 内容打包通过（约 20.37 秒），不等同 Android 应用构建。未进行 APK 构建、安装或真机验证，也未验证 DataContract 序列化的 IL2CPP 应用构建表现。
- 同步：交付核对 453 个文件与验证副本字节一致；当前编辑器新生成的 GUID 得到保留，187 份玩法资产的外部 GUID 静态核对无缺失。正式场景 SHA-256 保持 `8be20026277e2c4b8c0b1853bd4c72263c2809e3bbcc756033cf7a800ce42056`；Gameplay／Streak 组与 DefaultObject 注册有效，正式文件名仍为 `hamdoku-progress.json`。没有同步 Library、验证存档、测试 HomeConfig 或测试编辑器脚本。
- 初次失败与修复：自动化驱动的同帧新 UI 射线检查及局部变量编译错误已修正；记录保留。共享工程新 GUID、连胜配置结构／花瓣引用／图集导入与旧存档兼容问题均经后续检查解决。Unity Search 索引越界作为编辑器自身异常单独保留，未混作项目错误。最终结果和截图位于 `Logs/GameplayMigrationValidation/`，历次运行日志位于其中 `Runs/`；来源及同步明细位于 `Logs/GameplayMigration/`。
- 后续：第 6 关后的动态难度、固定关及完整选图；原作完整教程、开局揭示、逻辑提示解释、计分细节／连击、成绩统计、完整结算与奖励表现；设置页、其他模式及真实服务；APK／真机验收。均保留在 TODO，未把基础可玩流程写成完整原作复刻完成。


## 2026-10-27 小狗面包房换皮素材归档

- 用户确认奶油白＋雾灰蓝、垂耳小狗轮廓与绘本风格，以本次图片作为后续同套素材的视觉参考。
- 新建 `Docs/UILibrary/themes/PuppyBakery/assets/Sprite/`，保存已确认的 `hamster_idle_04__sharedassets2.assets__6.png`；沿用原文件名对应原素材，新增 `manifest.json` 记录替换关系、来源和确认状态。当前仅有一张素材，不表示整套换皮完成。
- 验证：Python/Pillow 核对 PNG 为 509×439、RGBA，归档图片与用户确认文件 SHA-256 一致。静态检查 UI Library HTML/JS：目前仅支持素材浏览、筛选和页面预览，没有上传替换、主题切换或 Unity 资源写入功能。
- 边界：未覆盖原始资料，未修改参考库页面引用、Unity 代码、Prefab、SO 或运行素材；本次未执行 Unity 编译、Play Mode、内容打包、应用构建及真机验证。


## 2026-10-27 小狗面包房风格文字定稿

- 按用户要求新增 `Docs/UILibrary/themes/PuppyBakery/STYLE.md`，以已确认图片锁定垂耳小狗、奶油白与雾灰蓝配色、绘本笔触及头像交付规格，并区分已确认头像与待设计的身体、服装和 UI。
- 明确保留当前头像 509×439 像素与居中呈现，但不再要求沿用原仓鼠轮廓；其他素材按各自原图尺寸制作。已在 `AGENTS.md` 增加入口。
- 验证：核对风格说明中的基准图、manifest 链接及实际 PNG 尺寸、RGBA 和透明边界；文档采用 A/B 编号与 Tab 缩进。仅文档修改，未执行 Unity 编译、Play Mode 或打包验证。

## 2026-10-27 排行榜本地表现与服务接口

- 按用户确认的范围实施：新增正式 `Panel_Ranking`、`Panel_RankingDialog`、`Widget_RankingEntry` Prefab，复用原作领奖台、奖牌、礼盒、瓜子、头像、装扮、标题横幅和背景；包含前三名、可滚动榜单、本人排名、赛季倒计时、规则与奖励说明、返回、重试和“去收集吧！”主线入口。采用现有 Canvas、PanelFactory／Repository、Addressables default 标签与 Open／Close 生命周期，没有新增并行 UI 管理或 C# interface。
- 新增 `RankingSystem`／`RankingState`、`RankingController`、两份 Panel Controller、`RankingModule`、请求／结果／条目／存档 Model 及状态枚举。由 ClientMain 装配和组织更新，Controller 修改状态，Panel／Widget 只显示和上报交互；关闭、释放与请求代次／赛季检查处理重复打开和过期回调。
- `RankingModule.FetchBoard`、`SubmitClear`、`ClaimReward` 为后续服务接入边界，目前明确返回 ServiceUnavailable。正式页面显示服务准备中、未知赛季与排名；没有生成在线竞争数据、模拟上报成功或发放赛季奖励。服务快照携带 UTC Unix 秒与赛季 ID；收到后以单调时钟计算倒计时，期满及切回前台重新请求，不在本地结算排名。
- 主线实际通关接入持久待上报队列：记录客户端标识、递增事件 ID、关卡、棋盘、剩余瓜子槽、游戏分数和完成时间；确认赛季未知时记录为 0。没有把剩余槽位或棋盘分数擅自转换成排行榜瓜子。重复结算不重复入队，失败保留记录，只有对应事件得到真实成功确认后才移除。领取请求保存赛季与幂等 token，未确认成功不改变领取结果。
- 存档主版本升至 4，支持旧版 1／2／3 进入迁移流程，补充排行榜子版本与合法性检查；旧通关次数不补造历史上报事件。为现有存档类型与新队列数据声明可选 DataContract 成员，兼容缺失的新字段并保留 null 棋盘；新版本损坏的队列明确报错。StreakSetupEM 使用 Math.Max 保留更高的存档版本。正式文件名 `hamdoku-progress.json` 与排行榜通关 10 关解锁条件保留。
- 新增 `RankingConfigSO` 正式配置、23 份中英文 L10NSO 和静态字体所需字符；预览数据保存于 `Assets/Res_Editor/Ranking/RankingPreview.asset`，没有 default 标签或正式场景引用。Play 后回到首页，可通过 `Hamdoku/Ranking Preview/` 切换 Normal、Loading、Empty、Failed、Not Participating、Ended、Reward Available、Claimed；预览标识始终显示，预览领取不发奖，也不写入正式排名进度。
- 主要接入文件：`ClientMain.cs`、`GameContext.cs`、`HomeController.cs`、`GameController.cs`、`SaveModule.cs`、存档 Model、`AssetModule.cs`、PanelType／UINameType、`RankingSetupEM.cs`；资源为 `UI/Ranking/`、`Config/RankingConfig.asset`、`Res_Editor/Ranking/`、Ranking 本地化、现有中英字体、Addressables Ranking 组及其 schema。保存了实际 Prefab 与序列化绑定，正常运行无需先执行制作菜单。
- 验证环境：Windows、Unity 6000.5.2f1、Addressables 2.10.3，独立工程 `D:/UnityProject/HamdokuRankingValidation-20261027`。编译通过；最终把主工程的正式文件重新覆盖验证副本，未调用制作菜单直接打开 Scene_Main，以独立旧版 v2 存档启动通过。正式离线入口、原解锁门槛、重试、重复打开／关闭、规则与奖励弹窗、八种预览、倒计时归零、前台恢复、真实关卡通关后的单次入队与落盘、重复提交防护、失败保留、无效队列拒绝、返回首页保存 null 棋盘、连胜自动弹出后返回以及幂等释放通过，最终项目运行错误 0。
- 查看并核对中英文与 1080×1920、1080×2400、1080×1620、1920×1080 后台相机渲染截图；修正列表行宽、名次数字、按钮形状及礼盒位置。横屏仅检查窗口变化容错，后台渲染不等于真机触摸。StandaloneWindows64 Addressables 内容打包通过；未构建 Android APK、安装或进行真机验收，也未验证真实网络和服务端结算。
- 同步仅合并排行榜新组与资源，核对 DefaultObject 注册、正式存档名／版本／解锁条件、预览不入正式标签，以及当前运行脚本、排行榜资源、本地化、字体和 Addressables 与最终验证快照一致。记录、制作与验证脚本、截图、打包结果和同步核对保存在 `Logs/RankingMigration/`，最终结果见 `Verified/result.txt`；Unity Search 编辑器索引异常单独记录于 `Verified/editor-diagnostics.txt`。原作具体计分、赛季周期、同分规则、奖励内容及后端协议仍待确认，当前不宣称已完成真实在线排行榜或领奖。


## 2026-10-27 Sudoku Pup 启动页整体视觉候选

- 按用户确认将游戏名 Sudoku Pup／《数独小汪》补充到 `Docs/UILibrary/themes/PuppyBakery/STYLE.md`，创建 `assets/UI/Logo/` 分页素材目录。
- 基于确认的小狗图片与用户提供的布局参考，通过内置 image_gen 生成启动页整体候选，保存 `previews/Panel_Logo_overall_v01_1080x1920.png` 和生成说明 JSON。候选包含蓝白遮阳篷、烘焙纹样、Sudoku Pup 招牌、候选文案及五枚饼干加载标记，均等待用户确认。
- 验证：Pillow 核对最终整体图为1080×1920像素；风格文档名称已更新。尚未切图或制作正式Logo分层素材，未替换运行资源；本次未执行Unity编译、Play Mode、打包或真机验证。

## 游戏页改为原始层级迁移（2026-10-27）

- 按用户要求停止以手工基础结构重建游戏页。只读核对原 APK：游戏页保存在 `level2`／导出 `Game.unity` 的 Canvas 中，并非独立游戏页 Prefab；棋格是 `sharedassets2.assets` 中的 `Cell.prefab`。提取 Canvas 下除原 ResultPopup 外的 35 个节点，以及 Cell 的 5 个节点，保留原 Header、StatusRow、HamsterCounter、LifeCounter、RuleBanner、BoardArea／BoardFrame／CellsGrid、BottomBar／ItemButton_A／ItemButton_B／Badge 与 StrokeA／StrokeB 层级及源 pathID。
- 正式资产仍为 `Assets/Res_Runtime/UI/Game/Panel_Game.prefab`、`Widget_BoardCell.prefab`，保留原有两份 .meta GUID 和 Addressables 登记。沿用当前项目的 Hamdoku 命名空间、Panel／Widget 与 Controller 委托、PanelFactory／Repository 生命周期和 L10N 字体入口；清除原项目业务脚本、Canvas／Raycaster、静态按钮回调等依赖，不引入第二套启动或 UI 管理。原 ResultPopup 不接入，继续由已实现的 Panel_GameDialog 管理弹窗。
- 原作通过代码生成的分数、规则卡片、辅助图案等在编辑器中实化；新增安全区设计缩放容器与教程／错误提示绑定。补入原 HudBar、RoundedFill、仓鼠计数图及 help 图片，保留 PNG 字节。调整顶部双行信息和商店／设置位置、规则整体框与内卡片、棋盘白框及间距、道具原底板与红色角标、白色叉号；取消重复按钮底板、道具下方额外文字及底部用时显示。4×4 教程与主线棋盘规模保留各自玩法数据；重开按钮使用原 TipButton 节点移至右下角。
- 主要脚本：`Assets/Src_Editor/EM/GameOriginalUIEM.cs` 负责原资产适配，`GameSetupEM.cs` 删除手工 CreateGame／CreateCell 基础生成路径；缺失原资产时明确报错。`Panel_Game.cs`、对应 Controller 与 `GameController.cs` 增加顶部入口委托／请求上报，商店和设置尚未迁移，点击明确显示准备状态；`Widget_BoardCell.cs` 绑定原两根白色笔画。更新 Game_Level／Game_Score 两份本地化 SO 的双行排版。
- 验证环境：隔离工程 `D:/UnityProject/HamdokuGameplayMigrationValidation-20261027`，Unity 6000.5.2f1、Addressables 2.10.3。最终 Unity 编译与 Play Mode 通过；覆盖正式场景启动、按钮射线／回调、教程双击／单击／滑动、前五关、提示道具、失败／重开、返回与实际场景重载恢复、重复开关及释放，最终项目错误 0。人工查看后台相机渲染的教程、8×8 主线、中英文及 1080×2400 安全区画面，并修复英文规则溢出。该渲染／事件模拟不等同编辑器手工点击或手机触摸验收。
- Windows Addressables 内容打包通过（16.74 秒）。未进行 Android 应用构建、安装或真机验证。正式场景、存档文件名及用户进度未替换，未同步 Library、测试 HomeConfig 或验证存档。
- 来源、提取脚本、pathID／依赖记录、实际验证与预览保存在 `Logs/GameUIRefinement/`。原包序列化版本 23 导致 AssetRipper 直接解析失败；只对工作副本转换版本标记以导出场景／Prefab，并以原始 UnityPy 数据和已有 Configs 恢复组件字段，未改动原取证目录。初次导入的 GameObject 版本、移除 Canvas 后的零缩放、按钮 Pivot、圆角和英文换行问题均已修复并重新验证；历次失败日志保留。Unity Search 索引越界单独记录为编辑器异常。
- 最终同步核对：18 份本次脚本／Prefab／文案／新增图片与 meta 与已验证副本字节一致；两份 Prefab 及两份文案 SO 的外部 GUID 无缺失，DefaultObject 注册指向正式 GUID，Scene_Main 哈希保持不变。详见 `Logs/GameUIRefinement/sync-audit.json`。

## UI 迁移来源规范（2026-10-27）

- 经用户确认，在 `AGENTS.md` 的 A6 追加 B12–B14：迁移 UI 必须先查找原项目 Prefab／场景层级及依赖，以原结构为基础适配当前项目；找不到来源或需要自行补建结构时，说明范围并经用户确认后实施。
- 验证：核对条目内容与已确认方案一致，编号连续、Tab 缩进及空行符合文档规范。本次仅修改 `AGENTS.md` 与本工作记录，未修改脚本或 UI 资源，无需 Unity 编译及运行验证。


## 2026-10-27 正式 UI 图片按命名规范整理

- 按 `Assets/0cyh/UI图片资源命名规范.md`，完成 `Assets/Res_Runtime/UI/` 下 96 张 PNG 的原目录重命名，使用 `btn`／`Img`／`bg` 前缀、实际功能归属与 PascalCase 用途；跨功能使用的图片标为 Common。核对实际图片与 Prefab／场景／SO 引用，棋盘辅助图案改用 Paw／Heart／Flower 等内容名称，礼盒按颜色、奖牌按金银铜、植物按生长状态、蝴蝶按颜色与序列帧命名，去除原 atlas 编号与无意义数字。
- 图片及 `.meta` 成对改名，96 份图片内容、96 份 `.meta` 字节及 GUID 均保持不变；保留已有 Sprite 子资源名称、internalID、裁切和导入配置。目录、Prefab 节点与脚本业务字段未改名，没有移动目录、合并图片或调整 Addressables 登记。
- 同步 `Assets/Src_Editor/EM/` 下 `LogoSetupEM.cs`、`HomeSetupEM.cs`、`GameSetupEM.cs`、`GameOriginalUIEM.cs`、`RankingSetupEM.cs`、`StreakSetupEM.cs` 中的直接路径、Sprite 名称、数组、跨页资源分派、Pill 调用、纹理生成路径和文件名匹配的边框导入条件。棋盘前八种辅助图案的配置顺序保持不变。
- 验证环境：当前 Windows 主工程，Python 3／Pillow 静态检查。96 张 PNG 数量不变，新名符合格式、目标无冲突、旧路径及旧 `.meta` 均已移除，图片与元数据 SHA-256 全部与改名前一致。293 份现有 Prefab／场景／SO 序列化文件字节不变；102 处字面量 Sprite／GameSprite 加载、图片直接路径及资源名数组等均核对存在，旧资源加载名已清除。新旧路径与 GUID 对照为 `Logs/UIRename/mapping.csv`／`mapping.json`，验证结果为 `Logs/UIRename/verification.json`。
- 验证边界：本次未执行 Unity 编译、重新导入后的显示检查、Play Mode、Addressables 内容打包、应用构建、安装或真机验证；静态引用及字节核对不替代这些运行验证。保留任务开始前已有的工程修改，未修改原项目取证目录。


## 2026-10-27 Sudoku Pup 启动页首批素材拆分

- 用户确认 1080×1920 整体方案并授权切图。核对当前正式目录后发现名称已更新为 `Img_Common_Logo.png`、`Img_Logo_*`、`bg_Common_Menu.png`，因此按当前名称而非此前旧名称制作，未改动或覆盖正式运行资源。
- 新增 `Docs/UILibrary/themes/PuppyBakery/assets/UI/Logo/` 下 13 张 PNG 和页面 `manifest.json`，逐项保持正式 PNG 像素尺寸；加载弹出图保留 128×76 画布和现有 seed_pop_0／1／2 子图矩形。未复制或生成替换用 Unity .meta，保留正式 GUID 与子图 ID 的要求记入位置参考。
- 完整 Logo、标题、角色可见部分、睁眼、爪子、加载饼干和蓝色爪印从确认稿提取与透明分离；使用内置 image_gen 补全无文案背景、空招牌和闭眼叠加层。另生成过无眼头部探索底图，最终角色层仍采用确认稿像素并局部去除眼睛，探索底图仅留在工作预览目录。
- 主要工作与检查文件：`previews/Logo_Slicing/slice_logo.py`、`reassemble_review.py`、`validation.json`、`contact_sheet_v01.png`、`page_static_reassembled_1080x1920.png`、`page_layers_reassembled_1080x1920.png`、`layout_reference.json`。同步更新主题根 manifest 和 STYLE.md。
- 验证环境与结果：本机 Python/Pillow、NumPy、SciPy；13 张文件名与正式目录逐一对应、像素尺寸一致、RGBA 合法，背景全不透明，其余图层具有真实透明区。人工查看棋盘底色的素材总览和1080×1920离线分层拼合图，修复爪子切边残留、饼干底色和标题边缘碎片。素材生成与切图完成，未宣称 Unity 接入完成。
- 接入边界：确认稿为更高的两行招牌，旧 LogoConfig 的部件大小／位置不能直接复现；背景含顶部遮阳篷，需要检查 EnvelopeParent 的中心裁切。眼睛、前景爪子、盖章位置、动画到完整 Logo 的切换仍待 Unity 接入验证。背景不烘焙引言与署名，文案仍需通过现有 L10NSO/TMP 更新。本次没有修改运行脚本、Scene、Prefab、SO、包配置或正式图片；未执行 Unity 编译、Play Mode、Addressables 打包、应用构建、安装及真机验证。

## 2026-10-27 批量提交

- 按用户要求将现有改动分为三批本地提交：玩法／连胜／排行榜及正式 UI 资源、UI 参考库与 Sudoku Pup 主题素材、项目规范与工作记录。相关脚本、Prefab、SO、本地化、字体、Addressables 与图片重命名一并保存。
- 验证：核对 Git 暂存范围、提交结果及最终工作区状态。本次没有修改业务实现或正式资源，没有重新执行 Unity 编译、Play Mode、内容打包、应用构建、安装或真机验证；既有验证结果与限制见对应历史记录。未推送远程。
