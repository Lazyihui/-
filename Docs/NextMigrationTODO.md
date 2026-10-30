- A1 下一批目标与授权边界（2026-10-28）
	- B1 用户已确认整理“主线101—300关＋无限模式完整本地玩法”执行TODO。2026-10-28授权为文档编写；2026-10-29已提交A9具体清单并获得用户“好的继续”的实施确认。原实施要求为：实施前须提交原作证据、具体脚本／资源清单、职责变化与验证边界，取得迁移确认。确认范围内的常规实现及必要修复不逐项重复询问。

	- B2 实施前基线：主线可玩至100关，活动池9610张；地图全量12319份PuzzleSO已导入；普通池已有8种镜像／旋转、游标轮次、固定题与阶段奖励，存档v12。无限模式首页解锁入口存在，但仍走准备提示。上述为实施前工程状态，不代表原作全部行为已核实。

	- B3 本批目标：交付101—300关连续主线，以及可进入、连续游玩、结束、重试、返回并保存最高纪录的无限模式；同时完成正式配置、UI接入、中英文、旧档兼容和验证。无限模式的计分、生命、尺寸推进、道具及退出规则须以证据核查结果确定，不按名称自行推断。

	- B4 本任务量足够安排至少两小时连续AI实施，完整工作可能超过两小时。以功能闭环和验证结果为完成条件，不通过等待、重复测试或虚增条目凑时长；两小时到点未完成时保留真实进度与可继续入口。

	- B5 黄金挑战、真实广告／购买／排行榜服务、账号与云存档、301关以后及新一轮换皮美术不在本批实施范围。现有未接入服务继续明确显示真实准备或失败状态，不伪造成功。

- A2 执行顺序与原作依据
	- [x] B1 建立只读基线：检查git差异、当前场景／Prefab／SO／Addressables引用及现有工作记录，列出本批保护文件和已有用户修改。运行版本读取ProjectVersion.txt及包清单，不更换Unity或包版本。

	- [x] B2 读取原作`D:/0000001apkUnbag/01_逆向工程项目/Hamdoku2/03_code/decompiled_csharp/README.md`及GAME_INDEX.md，从DynamicDifficulty、CampaignMapBank、CampaignDifficulty、GameController、GameProgress、GameConfig、MainMenu、ResultScreen及相关状态机定位业务链；类型实际名称以索引为准。

	- [x] B3 主线核查101—300关尺寸、技能上限与选图上限的区别、固定题、升降级条件、失败／重试处理、池轮次、避重、阶段奖励及第300关边界。重点核查100→101、200→201两处规则是否改变，不把恢复C#可疑零值当原作参数。

	- [x] B4 无限模式核查LoadEndless、EndlessAutoAdvance、EndlessOverAfterDelay及调用方：解锁、初始状态、选图来源、尺寸推进、正确放置计数、计时／生命／道具、过关自动接续、结束／重试、最高纪录及退出／重启语义。字段名只作为搜索线索，不直接确认为规则。

	- [x] B5 使用game-method-index.tsv记录关键方法的assembly、type、recovered_token、status、diagnostic_count、source_line；结合method-issues.jsonl及source-diagnostics.json回查structure／native／isil。把每条规则归为原作静态证据、运行核实、工程选择或待核实，并保留来源路径与必要哈希。

	- [x] B6 先查原作Prefab与场景层级、GameConfig／结果配置和资源依赖，再决定现有Panel_Game／Panel_GameDialog／Panel_GameResult的适配点。入口已知资料为`Docs/UILibrary/PrefabCollection/OriginalHierarchies/level1__14__EndlessButton.json`，仅证明首页按钮层级，不证明无限模式完整页面已找到。

	- [x] B7 输出一份具体迁移确认清单：列出已核实规则、未决项、修改／新增类型、正式资产及行为变化，请用户确认后实施。若确实缺少UI层级需补建，明确缺失及补建范围纳入该确认；证据不足的核心规则不得擅自编造。独立可核查任务继续推进。

- A3 主线101—300关实施包
	- [x] B1 复用既有PuzzleSO和ID／GUID，按证据生成101—300关正式尺寸／难度／固定题配置；保持前100关配置及旧活动池相对顺序。先核对全量地图中的目标数据，不重新全量导入或生成旋转副本。

	- [x] B2 调整CampaignConfigSO／CampaignConfig.asset及PuzzleConfigSetupEM／PuzzleImportEM中实际涉及的范围校验与配置维护。选图参数与技能参数分别验证，不将技能上限直接等同地图grade上限。

	- [x] B3 在CampaignController／PuzzleModule内接续选图、历史避重、升降级与失败计数，复用现有独立PuzzleBoardModel和池轮次变换；固定题保持证据要求的方向。无效固定题、缺池或缺地图明确报错，不退回随机占位题。

	- [x] B4 GameController／GameFlowController接续100关结算到101关，继续阶段奖励、领取防重、返回与读盘；旧100关终点存档能进入101关，不重复发放已领取奖励。第300关按本批边界收口，并检查结果页按钮和中英文文案。

	- [x] B5 覆盖101、200、201、299、300关以及全部新增固定题；验证尺寸、预置、提示、标记、重开、道具、失败、变换与难度。不得仅验证数组长度便勾选“300关可玩”。

- A4 无限模式完整本地玩法实施包
	- [x] B1 先确定最小数据与职责方案：复用现有启动、GameSystem、棋盘、面板、资源模块和存档体系。必要新增EndlessController、EndlessState、EndlessSaveModel或EndlessConfigSO时，在实施确认中列明；不新增接口、抽象基类、单例或平行管理体系。

	- [x] B2 首页Endless请求接入实际进入流程，保留原100关解锁条件；空格临时解锁仅开放测试入口，不授予持久化纪录或主线进度。ClientMain仅负责装配、注入和事件连接，业务状态由Controller修改。

	- [x] B3 根据已核实规则建立无限模式初始化、选题、尺寸／难度推进与连续游玩流程；复用地图索引、运行棋盘、提示和计分能力。确认哪些棋盘行为与主线不同，显式按模式分支处理，不意外改变主线或每日规则。

	- [x] B4 实现通关接续与交互锁定：最后一步只结算一次，过渡期间禁止重复输入；自动下一题的延迟、动画、计时与累计状态按证据／已确认配置执行。正确处理过渡时返回、设置遮挡、关闭与重新进入，清理延迟任务和委托。

	- [x] B5 实现本轮结束、实际成绩、历史最佳与新纪录显示、重新挑战和返回首页。区分单题统计与整轮统计，记录来源明确；广告相关操作保持真实未接入状态，不通过本地假成功提供复活。

	- [x] B6 明确原作退出／中断是否续局。按核查及确认结果实现续局或结束本轮的语义，覆盖退出确认、取消、应用重启、通关过渡中断和失败结果恢复；不得默认为可以无限恢复生命或反复领取收益。

	- [x] B7 隔离主线／每日／无限模式的棋盘、游标、难度、纪录、奖励和选图历史；共享能力只共享经证据确认的部分。无限模式正确落子或过关不能意外增加campaignClears、每日完成天数或主线阶段奖励。

- A5 存档与旧进度兼容实施包
	- [x] B1 查阅SaveModule、PlayerSaveModel、CampaignSaveModel、PuzzleSaveModel、DailySaveModel和现有版本迁移路径；新增字段仅由业务需要驱动。确需升版时同步GameConfigSO／正式GameConfig及校验，不预先把下一版号码写为已完成事实。

	- [x] B2 兼容v1—12，重点使用真实保留的v11／v12测试样本覆盖：缺少新字段、100关完成、100关结果未关闭、旧主线中途、每日中途和阶段奖励未领取。旧棋盘、变换、选图历史、资料、库存及纪录保持合法，不通过清空存档解决兼容问题。

	- [x] B3 无限模式纪录和必要局内状态按确认语义保存；加载校验模式、地图ID、尺寸、坐标、累计值及流程阶段。损坏或不支持的数据暴露明确错误；缺失存档可初始化，其余读取错误不静默重置。

	- [x] B4 检查写入失败、重复关闭／结算／领取、重试与重启的一致性，沿用临时文件与替换写盘。测试只使用唯一隔离存档及副本数据，不读取或覆盖正式hamdoku-progress.json，不同步开发通关进度。

- A6 目标脚本、资源与正式接入
	- B1 主线代码优先修改现有`Assets/Src_Runtime/Controllers/CampaignController.cs`、`GameController.cs`、`GameFlowController.cs`、`HomeController.cs`、`Module/Puzzle/PuzzleModule.cs`及`Module/Assets/TM/CampaignConfigSO.cs`。逐项以实际引用核查为准，不因列名就无意义修改。

	- B2 模式与显示优先检查`Assets/Src_Runtime/ClientMain.cs`、`GameContext.cs`、`System/Game/GameState.cs`、`Generic/Enum/HomeRequestType.cs`、`Controllers/Panel/Home/Panel_Home_Controller.cs`、`Controllers/Panel/Game/Panel_Game_Controller.cs`、`Panel_GameDialog_Controller.cs`及`Panel_GameResult_Controller.cs`，对应Panel只处理显示与交互上报。Context仅保留字段，只有ClientMain注入依赖。

	- B3 正式资源优先定点修改`Assets/Res_Runtime/Config/CampaignConfig.asset`、必要的HomeConfig／ResultConfig／GameConfig，以及`UI/Game/Panel_Game.prefab`、`Panel_GameDialog.prefab`、`UI/GameResult/Panel_GameResult.prefab`。保留已安装小狗结果图、地图GUID及现有相机／Canvas／EventSystem，不销毁重建页面。

	- [x] B4 新模式参数进入正式SO并接入现有AssetModule；必要新Prefab沿用IPanelAsset、PanelFactory、PanelRepository和Addressables default标签。现有Panel足够时直接复用；新增资产随交付实际绑定，打开Scene_Main即可运行，无需先执行制作菜单。

	- [x] B5 补充UINameType与独立L10NSO的简体中文／英文条目，复用L10NModule与每语言单字体；检查新增字符离线烘焙。不要保留“前100关已完成”作为300关结果，不把迁移、SO、存档版本等开发信息写进产品文案。

	- [x] B6 同步必要的GameSetupEM／GameFlowSetupEM／ResultSetupEM／HomeSetupEM及导入工具维护逻辑；只更新实际受影响部分，不以工具执行替代正式资产交付，不回退同期用户修改。

- A7 开发验证与交付条件
	- [x] B1 在Unity6000.5.2f1／Addressables2.10.3隔离环境编译并从正式Scene_Main进入Play Mode；保留失败记录及修复后的复验，编辑器自身异常与项目错误分开记录。

	- [x] B2 主线验证：从100关旧进度接续至300关，逐关核对配置／选图合法性及全部固定题，重点实测100→101、199→200→201、299→300和300终点；覆盖困难关、降级、8种变换、池尾跨轮、奖励防重与续局。测试快捷键只能辅助推进，不能替代这些行为检查。

	- [x] B3 无限验证：未解锁／正常解锁／临时解锁进入，连续多题至尺寸或难度上限，正确累计、生命耗尽、失败重试、刷新最佳、重复结算、关闭重开及中断恢复。具体断言取自核实规则，不以实现本身作为唯一期望值。

	- [x] B4 模式交叉与生命周期：主线→无限→每日→主线，设置／商店／资料／连胜弹窗接入，语言切换、返回取消、重复初始化、打开关闭及释放。检查输入锁、事件监听、计时与最高纪录不串模式。

	- [x] B5 视觉检查：1080×1920、较短及较长竖屏和模拟安全区，中英文标题、纪录、统计、按钮与10／11阶棋盘可读可点；背景比例、TMP缺字、截断、遮挡、GraphicRaycaster及唯一EventSystem。程序化点击／后台渲染与真实鼠标／手机触摸分别说明。

	- [x] B6 完成Windows Addressables内容构建，核查新增／修改资产、meta／GUID、default标签、DefaultObject、EditorBuildSettings、程序集及包依赖；核对副本与正式工程交付哈希，恢复正式配置，不复制Library、测试脚本、测试配置或测试进度。

	- [x] B7 更新本TODO实际完成状态、既有玩法TODO、WORK_LOG及MigrationAcceptance。验收文档追加本批入口、步骤、预期结果、旧进度兼容、已知限制与开发证据，用户验收保持未勾选。分别报告代码、Unity编译、Play、内容打包、应用／APK构建、安装及真机状态；本清单不把APK／真机未执行写成已通过。

- A8 连续执行与中断交接
	- B1 推荐顺序：证据及实施确认→主线配置与流程→无限模式数据和完整流程→存档兼容→资源／双语接入→专项验证及正式同步。主线、无限模式均属本批交付，不以只扩关卡数组或只打通入口作为完成。

	- B2 实施确认后连续完成已授权工作，不在每个TODO前重复请求许可；发现核心规则缺证据、需要新增未确认职责关系或补建UI时，说明具体问题并请求所需确认，同时推进不依赖该决定的工作。

	- B3 会话中断时记录已改文件、已通过／失败检查、未决问题和下一条可执行步骤，保持未验证项目未勾选。若受限只能部分交付，分别说明主线和无限模式完成程度，不把整批标记完成。

	- B4 当前状态（2026-10-29）：A2—A7开发实施与验证已完成，主线连续至300关，无限模式本地流程已接入正式场景。详细结果见A10；APK、安装、真机及原APK动态对照未执行，用户验收仍待执行，见[迁移验收文档](MigrationAcceptance.md)A27。

- A9 首轮核查与实施确认清单（2026-10-29，已确认实施）
	- B1 基线与保护范围
		- C1 开始时`git status --porcelain`为空。读取ProjectVersion及包清单，仍为Unity6000.5.2f1／Addressables2.10.3；不升级版本。对运行／编辑器脚本、正式配置、棋盘／结果资源、地图、Addressables、正式场景及必要包／工程设置共25287份文件建立SHA-256基线，见`Logs/NextMigrationAnalysis/evidence.json`。

		- C2 本轮只读查看现有CampaignController、GameController、GameFlowController、HomeController、GameState、GameContext、PlayerSaveModel、PuzzleModule、AssetModule及棋盘／结果Panel。当前选题、存档合法性及配置验证仍限制100关、技能4；新增模式须逐一隔离这些入口，不能只改首页请求。

	- B2 已取得的原作静态证据
		- C1 已读原作恢复README和类型索引，归档38个关键方法的assembly、type、recovered_token、status、diagnostic_count、source_line及关联路径。其中23个方法有恢复诊断，相关源码扫描另有4条诊断；29份来源文件保留SHA-256。索引无诊断不代表逻辑已核实，归档不代表全部方法已完成语义审查。

		- C2 `DynamicDifficulty`的ARM64显示：101—200关技能上限5，201关起上限6；`SelectionCeiling`在51关后仍为4。`Select`对困难关另有5／6级分支及expertRelief／pendingDemotion判断。因此普通选图上限、技能上限及困难关实际grade必须分开实现，专家缓解的完整状态语义继续核查。

		- C3 `IsFixed`原生分支与已导入SO相互印证：本批新增固定关123／200／250，分别对应Puzzle_10889（9阶）、Puzzle_10890（11阶）、Puzzle_10891（11阶），三者grade均为4。`BoardSize(level, grade)`对grade6返回10或11；本批视觉与操作验证须覆盖11阶，不能沿用A7-B5只检查10阶的边界。第300关是当前批次收口的工程选择，不是原作终点。

		- C4 原作正式`GameConfig__resources.assets__1476.json`给出无限模式100关解锁、5阶起步、10阶上限、每3题推进一阶。`LoadEndless`原生指令确认按已过题数计算尺寸；6阶起按组内位置选择maxTier与preferHard，默认每组三题的第三题进入较难候选分支。此处maxTier属于生成器逻辑等级，不能直接当作主线地图grade。

		- C5 无限模式调用`GenerateAndStart`及`PuzzleGenerator.Generate`运行时出题，不是CampaignMapBank抽题。`ContinueClearTail`在无限分支增加本轮过题数，并将已完成棋盘size加入`endlessFound`；自动接题常量为1.3秒。结束状态机使用`GameProgress.EndlessBest`及`ShowEndlessResult`显示本轮成绩、最佳与新纪录，重试回调清零本轮累计值。计入未完成棋盘的口径、每题生命／道具重置、完整计时及中断语义仍需逐调用方核查，暂不据局部代码作完整结论。

		- C6 已找到原作level2的GameController、BoardFrame、BoardArea、HamsterCounter及ResultPopup层级；结果内容由ResultScreen的MakeTitle／MakeHero／MakeBig／MakePillButton等动态构建。不能因静态ResultPopup缺少全部成绩节点就自行设计另一套页面；迁移以原场景骨架和动态构建证据适配现有Panel。

	- B3 拟修改的现有脚本及职责
		- C1 主线：`Assets/Src_Runtime/Controllers/CampaignController.cs`负责技能／困难关选择与缓解状态；`Module/Puzzle/PuzzleModule.cs`负责正式池索引、独立棋盘数据及合法性校验；`Module/Assets/TM/CampaignConfigSO.cs`配置101—300关与相关参数。`Entities_Sub/Save/CampaignSaveModel.cs`仅增加确有需要的专家状态字段，保留原游标／轮次／历史顺序。

		- C2 模式接入：`Controllers/GameController.cs`、`GameFlowController.cs`、`HomeController.cs`、`Controllers/Panel/Home/Panel_Home_Controller.cs`及`Controllers/Panel/Game/Panel_Game_Controller.cs`、`Panel_GameDialog_Controller.cs`、`Panel_GameResult_Controller.cs`处理进入、输入、接题、退出、重试、结束显示及模式隔离；`System/Game/GameSystem.cs`按实际现有路径接入更新。`ClientMain.cs`只装配／注入／连接事件，`GameContext.cs`及`System/Game/GameState.cs`只增加所需字段。

		- C3 保存与展示：`Module/Save/SaveModule.cs`、`Entities_Sub/Save/PlayerSaveModel.cs`、必要的`PuzzleSaveModel.cs`及`Module/Assets/TM/GameConfigSO.cs`维护新状态、升版和v1—12兼容。`Module/Assets/AssetModule.cs`登记新正式SO；`Generic/Enum/UINameType.cs`和现有L10NSO接入双语；棋盘、对话框、结果Panel只增加显示与交互上报能力。

		- C4 编辑器维护：`Assets/Src_Editor/EM/PuzzleConfigSetupEM.cs`、`PuzzleImportEM.cs`、`GameSetupEM.cs`、`GameFlowSetupEM.cs`、`ResultSetupEM.cs`及`HomeSetupEM.cs`仅更新受影响的配置生成、验证与序列化绑定。具体改动以实际调用关系为准，不要求为清单列名而修改无关文件。

	- B4 拟新增类型与依赖边界
		- C1 `Controllers/EndlessController.cs`、`System/Game/EndlessState.cs`、`Entities_Sub/Save/EndlessSaveModel.cs`、`Module/Assets/TM/EndlessConfigSO.cs`及`Generic/Enum/GameModeType.cs`分别承担模式流程、纯运行数据、独立保存数据、正式规则配置及明确模式标识；沿用当前Context／System／Controller／Module依赖方向，不新增单例、interface或abstract class。

		- C2 原作运行时出题能力为现有工程缺口。建议纳入本批，按原生／ISIL证据实现`Module/Puzzle/PuzzleGeneratorModule.cs`、`PuzzleSolverModule.cs`及`PuzzleLogicModule.cs`，分别处理生成、唯一解验证及逻辑等级判断；必要结果数据使用独立`GeneratedPuzzleModel.cs`、`PuzzleAnalysisModel.cs`。这些Module不接收Context，不修改业务状态，由Controller接收结果后建立本局数据；不把恢复C#直接复制到Assets，也不使用示例棋盘作正常失败fallback。

		- C3 本方案保持原作运行时生成路线。改用现有SO题库属于另一项工程选择，生成器等级与主线grade没有经核实的一一映射，不能静默替换。如用户希望缩小出题器工作范围，须另行明确替代行为与还原限制。

	- B5 拟交付正式资产与行为变化
		- C1 定点修改`Assets/Res_Runtime/Config/CampaignConfig.asset`及必要GameConfig／ResultConfig／HomeConfig，新增`EndlessConfig.asset`并加入Addressables default标签；主线复用既有地图及GUID，补入123／200／250固定题和所需困难／专家池，不重新全量导入。

		- C2 适配现有`Assets/Res_Runtime/UI/Game/Panel_Game.prefab`、`Panel_GameDialog.prefab`与`UI/GameResult/Panel_GameResult.prefab`，依据原作动态结果页补齐无限成绩／最佳／新纪录／重试／返回的序列化显示绑定。复用当前小狗图片、Canvas和Panel生命周期；不另建启动／UI／加载体系，不整体重建页面。11阶棋盘布局与新增双语字符一并交付。

		- C3 保留100关解锁条件，空格临时入口不授予持久化纪录或主线收益；主线／每日／无限的难度、题目、累计成绩、选图历史及奖励隔离。无限模式退出／重启按后续核实语义落地，证据不足时单独提交具体分歧，暂不预设续局或退出结算。黄金挑战及真实外部服务保持本批范围外。

	- B6 验证与待确认事项
		- C1 确认本清单后，先完成剩余核心规则与出题链审查，再连续实施主线、无限、旧档、双语、正式资产及隔离Unity／Play／Windows Addressables验证。关键边界包括100→101、199→200→201、299→300、三张固定题、10／11阶、专家缓解、连续生成、生命耗尽、重试、最佳、防重复结算、临时解锁及跨模式恢复。独立求解结果验证生成棋盘，不能仅用同一生成实现作为期望值。

		- C2 本节首次提交时仅完成所述首轮静态核查，未执行功能实现、Unity编译、Play Mode、内容打包、应用／APK构建、安装或真机验证；未读取正式玩家存档，未修改原作资料。该时点A2保留未完成状态；后续结果见A10。

		- C3 用户于本节清单提交后回复“好的继续”，已确认B3—B5具体实施范围；原待确认范围为B3—B5，尤其包含原作运行时出题器、11阶支持和依据动态UI证据适配现有结果Prefab。依据AGENTS A2-B7及本TODO A2-B7，确认前不修改功能或正式资源；确认后已列范围内必要修复与常规实现选择持续推进，不逐项重复询问。


- A10 开发实施与验证完成（2026-10-29）
	- B1 主线101—300关、固定123／200／250、困难／专家选择及缓解、阶段奖励和旧100关结果接续完成。活动池10432，保留原9610池顺序、前100关尺寸及全部12319份地图／meta。原生构造0x33c73e8／0x33c740c确认fixedLevel=-1不入普通池，64张原记录保持非活动，导入工具与正式池一致。

	- B2 无限运行时生成、唯一解／逻辑判断、5→10阶、完成目标累计、每题3生命、持久道具、暂停／教程返回、失败／重试／退出、独立最佳及写盘失败重试完成。存档v13兼容v1—12，无限不保存局内续局，试玩不写纪录。EndlessConfig及14份双语L10NSO已登记default，中文单字体补齐离线字符，英文单字体覆盖通过；复用现有Prefab。

	- B3 Windows／Unity6000.5.2f1／Addressables2.10.3：全运行代码.NET编译0警告／0错误，隔离Unity运行／编辑器程序集编译与Scene_Main Play通过。600张生成题7500项独立检查、配置1115项通过；首轮实际逐关至300完成28245项后因旧100关奖励断言失败，修订后真实v11／v12、旧100→300及19题无限专项27291项通过。新增困难／专家池尾跨轮、8变换及历史跳过72项通过，未重跑未改动的全地图98552变换历史验证。

	- B4 最终D3D12 Canvas专项297项通过，16张截图人工查看，覆盖中英文、短／长竖屏及安全区、11阶固定／专家题、300关终点、试玩／纪录、实际写盘失败及重试保存成功后最佳立即刷新。后台渲染及程序化回调不等同真实鼠标／手机触摸验收。

	- B5 Windows Addressables内容打包通过，导入validate为12319张全部unchanged，无缺失／冲突。正式资产与完整验证副本、地图／来源哈希、meta／GUID、既有注册、default标签、DefaultObject、EditorBuildSettings、程序集及包依赖核验通过；正式文件名保持hamdoku-progress.json，未复制测试代码／进度／Library。审计Logs/NextMigrationImplementation/delivery-audit.json，结果在同目录Supplement、FinalUI、pool-result.txt及content-result.txt；原作证据Logs/NextMigrationAnalysis。

	- B6 早期失败日志保留：200次搜索预算在9阶失败，正式SO采用2000次预算；旧复用副本缺文件、测试驱动重载丢失路径及旧100关断言分别修复复验，编辑器Search／许可提示单列。最终无未解决项目错误。不声明与原APK逐种子／全部逻辑等级一致；APK构建、安装、真机触摸／性能／扬声器及原APK动态对照未执行，用户验收未代勾。
