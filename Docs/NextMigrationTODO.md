- A1 下一批目标与授权边界（2026-10-28）
	- B1 用户已确认整理“主线101—300关＋无限模式完整本地玩法”执行TODO。本次授权为文档编写，尚未授权修改功能代码或正式资源；实施前须提交原作证据、具体脚本／资源清单、职责变化与验证边界，取得迁移确认。确认范围内的常规实现及必要修复不逐项重复询问。

	- B2 当前基线：主线可玩至100关，活动池9610张；地图全量12319份PuzzleSO已导入；普通池已有8种镜像／旋转、游标轮次、固定题与阶段奖励，存档v12。无限模式首页解锁入口存在，但仍走准备提示。上述为当前工程状态，不代表原作全部行为已核实。

	- B3 本批目标：交付101—300关连续主线，以及可进入、连续游玩、结束、重试、返回并保存最高纪录的无限模式；同时完成正式配置、UI接入、中英文、旧档兼容和验证。无限模式的计分、生命、尺寸推进、道具及退出规则须以证据核查结果确定，不按名称自行推断。

	- B4 本任务量足够安排至少两小时连续AI实施，完整工作可能超过两小时。以功能闭环和验证结果为完成条件，不通过等待、重复测试或虚增条目凑时长；两小时到点未完成时保留真实进度与可继续入口。

	- B5 黄金挑战、真实广告／购买／排行榜服务、账号与云存档、301关以后及新一轮换皮美术不在本批实施范围。现有未接入服务继续明确显示真实准备或失败状态，不伪造成功。

- A2 执行顺序与原作依据
	- [ ] B1 建立只读基线：检查git差异、当前场景／Prefab／SO／Addressables引用及现有工作记录，列出本批保护文件和已有用户修改。运行版本读取ProjectVersion.txt及包清单，不更换Unity或包版本。

	- [ ] B2 读取原作`D:/0000001apkUnbag/01_逆向工程项目/Hamdoku2/03_code/decompiled_csharp/README.md`及GAME_INDEX.md，从DynamicDifficulty、CampaignMapBank、CampaignDifficulty、GameController、GameProgress、GameConfig、MainMenu、ResultScreen及相关状态机定位业务链；类型实际名称以索引为准。

	- [ ] B3 主线核查101—300关尺寸、技能上限与选图上限的区别、固定题、升降级条件、失败／重试处理、池轮次、避重、阶段奖励及第300关边界。重点核查100→101、200→201两处规则是否改变，不把恢复C#可疑零值当原作参数。

	- [ ] B4 无限模式核查LoadEndless、EndlessAutoAdvance、EndlessOverAfterDelay及调用方：解锁、初始状态、选图来源、尺寸推进、正确放置计数、计时／生命／道具、过关自动接续、结束／重试、最高纪录及退出／重启语义。字段名只作为搜索线索，不直接确认为规则。

	- [ ] B5 使用game-method-index.tsv记录关键方法的assembly、type、recovered_token、status、diagnostic_count、source_line；结合method-issues.jsonl及source-diagnostics.json回查structure／native／isil。把每条规则归为原作静态证据、运行核实、工程选择或待核实，并保留来源路径与必要哈希。

	- [ ] B6 先查原作Prefab与场景层级、GameConfig／结果配置和资源依赖，再决定现有Panel_Game／Panel_GameDialog／Panel_GameResult的适配点。入口已知资料为`Docs/UILibrary/PrefabCollection/OriginalHierarchies/level1__14__EndlessButton.json`，仅证明首页按钮层级，不证明无限模式完整页面已找到。

	- [ ] B7 输出一份具体迁移确认清单：列出已核实规则、未决项、修改／新增类型、正式资产及行为变化，请用户确认后实施。若确实缺少UI层级需补建，明确缺失及补建范围纳入该确认；证据不足的核心规则不得擅自编造。独立可核查任务继续推进。

- A3 主线101—300关实施包
	- [ ] B1 复用既有PuzzleSO和ID／GUID，按证据生成101—300关正式尺寸／难度／固定题配置；保持前100关配置及旧活动池相对顺序。先核对全量地图中的目标数据，不重新全量导入或生成旋转副本。

	- [ ] B2 调整CampaignConfigSO／CampaignConfig.asset及PuzzleConfigSetupEM／PuzzleImportEM中实际涉及的范围校验与配置维护。选图参数与技能参数分别验证，不将技能上限直接等同地图grade上限。

	- [ ] B3 在CampaignController／PuzzleModule内接续选图、历史避重、升降级与失败计数，复用现有独立PuzzleBoardModel和池轮次变换；固定题保持证据要求的方向。无效固定题、缺池或缺地图明确报错，不退回随机占位题。

	- [ ] B4 GameController／GameFlowController接续100关结算到101关，继续阶段奖励、领取防重、返回与读盘；旧100关终点存档能进入101关，不重复发放已领取奖励。第300关按本批边界收口，并检查结果页按钮和中英文文案。

	- [ ] B5 覆盖101、200、201、299、300关以及全部新增固定题；验证尺寸、预置、提示、标记、重开、道具、失败、变换与难度。不得仅验证数组长度便勾选“300关可玩”。

- A4 无限模式完整本地玩法实施包
	- [ ] B1 先确定最小数据与职责方案：复用现有启动、GameSystem、棋盘、面板、资源模块和存档体系。必要新增EndlessController、EndlessState、EndlessSaveModel或EndlessConfigSO时，在实施确认中列明；不新增接口、抽象基类、单例或平行管理体系。

	- [ ] B2 首页Endless请求接入实际进入流程，保留原100关解锁条件；空格临时解锁仅开放测试入口，不授予持久化纪录或主线进度。ClientMain仅负责装配、注入和事件连接，业务状态由Controller修改。

	- [ ] B3 根据已核实规则建立无限模式初始化、选题、尺寸／难度推进与连续游玩流程；复用地图索引、运行棋盘、提示和计分能力。确认哪些棋盘行为与主线不同，显式按模式分支处理，不意外改变主线或每日规则。

	- [ ] B4 实现通关接续与交互锁定：最后一步只结算一次，过渡期间禁止重复输入；自动下一题的延迟、动画、计时与累计状态按证据／已确认配置执行。正确处理过渡时返回、设置遮挡、关闭与重新进入，清理延迟任务和委托。

	- [ ] B5 实现本轮结束、实际成绩、历史最佳与新纪录显示、重新挑战和返回首页。区分单题统计与整轮统计，记录来源明确；广告相关操作保持真实未接入状态，不通过本地假成功提供复活。

	- [ ] B6 明确原作退出／中断是否续局。按核查及确认结果实现续局或结束本轮的语义，覆盖退出确认、取消、应用重启、通关过渡中断和失败结果恢复；不得默认为可以无限恢复生命或反复领取收益。

	- [ ] B7 隔离主线／每日／无限模式的棋盘、游标、难度、纪录、奖励和选图历史；共享能力只共享经证据确认的部分。无限模式正确落子或过关不能意外增加campaignClears、每日完成天数或主线阶段奖励。

- A5 存档与旧进度兼容实施包
	- [ ] B1 查阅SaveModule、PlayerSaveModel、CampaignSaveModel、PuzzleSaveModel、DailySaveModel和现有版本迁移路径；新增字段仅由业务需要驱动。确需升版时同步GameConfigSO／正式GameConfig及校验，不预先把下一版号码写为已完成事实。

	- [ ] B2 兼容v1—12，重点使用真实保留的v11／v12测试样本覆盖：缺少新字段、100关完成、100关结果未关闭、旧主线中途、每日中途和阶段奖励未领取。旧棋盘、变换、选图历史、资料、库存及纪录保持合法，不通过清空存档解决兼容问题。

	- [ ] B3 无限模式纪录和必要局内状态按确认语义保存；加载校验模式、地图ID、尺寸、坐标、累计值及流程阶段。损坏或不支持的数据暴露明确错误；缺失存档可初始化，其余读取错误不静默重置。

	- [ ] B4 检查写入失败、重复关闭／结算／领取、重试与重启的一致性，沿用临时文件与替换写盘。测试只使用唯一隔离存档及副本数据，不读取或覆盖正式hamdoku-progress.json，不同步开发通关进度。

- A6 目标脚本、资源与正式接入
	- B1 主线代码优先修改现有`Assets/Src_Runtime/Controllers/CampaignController.cs`、`GameController.cs`、`GameFlowController.cs`、`HomeController.cs`、`Module/Puzzle/PuzzleModule.cs`及`Module/Assets/TM/CampaignConfigSO.cs`。逐项以实际引用核查为准，不因列名就无意义修改。

	- B2 模式与显示优先检查`Assets/Src_Runtime/ClientMain.cs`、`GameContext.cs`、`System/Game/GameState.cs`、`Generic/Enum/HomeRequestType.cs`、`Controllers/Panel/Home/Panel_Home_Controller.cs`、`Controllers/Panel/Game/Panel_Game_Controller.cs`、`Panel_GameDialog_Controller.cs`及`Panel_GameResult_Controller.cs`，对应Panel只处理显示与交互上报。Context仅保留字段，只有ClientMain注入依赖。

	- B3 正式资源优先定点修改`Assets/Res_Runtime/Config/CampaignConfig.asset`、必要的HomeConfig／ResultConfig／GameConfig，以及`UI/Game/Panel_Game.prefab`、`Panel_GameDialog.prefab`、`UI/GameResult/Panel_GameResult.prefab`。保留已安装小狗结果图、地图GUID及现有相机／Canvas／EventSystem，不销毁重建页面。

	- [ ] B4 新模式参数进入正式SO并接入现有AssetModule；必要新Prefab沿用IPanelAsset、PanelFactory、PanelRepository和Addressables default标签。现有Panel足够时直接复用；新增资产随交付实际绑定，打开Scene_Main即可运行，无需先执行制作菜单。

	- [ ] B5 补充UINameType与独立L10NSO的简体中文／英文条目，复用L10NModule与每语言单字体；检查新增字符离线烘焙。不要保留“前100关已完成”作为300关结果，不把迁移、SO、存档版本等开发信息写进产品文案。

	- [ ] B6 同步必要的GameSetupEM／GameFlowSetupEM／ResultSetupEM／HomeSetupEM及导入工具维护逻辑；只更新实际受影响部分，不以工具执行替代正式资产交付，不回退同期用户修改。

- A7 开发验证与交付条件
	- [ ] B1 在Unity6000.5.2f1／Addressables2.10.3隔离环境编译并从正式Scene_Main进入Play Mode；保留失败记录及修复后的复验，编辑器自身异常与项目错误分开记录。

	- [ ] B2 主线验证：从100关旧进度接续至300关，逐关核对配置／选图合法性及全部固定题，重点实测100→101、199→200→201、299→300和300终点；覆盖困难关、降级、8种变换、池尾跨轮、奖励防重与续局。测试快捷键只能辅助推进，不能替代这些行为检查。

	- [ ] B3 无限验证：未解锁／正常解锁／临时解锁进入，连续多题至尺寸或难度上限，正确累计、生命耗尽、失败重试、刷新最佳、重复结算、关闭重开及中断恢复。具体断言取自核实规则，不以实现本身作为唯一期望值。

	- [ ] B4 模式交叉与生命周期：主线→无限→每日→主线，设置／商店／资料／连胜弹窗接入，语言切换、返回取消、重复初始化、打开关闭及释放。检查输入锁、事件监听、计时与最高纪录不串模式。

	- [ ] B5 视觉检查：1080×1920、较短及较长竖屏和模拟安全区，中英文标题、纪录、统计、按钮与10阶棋盘可读可点；背景比例、TMP缺字、截断、遮挡、GraphicRaycaster及唯一EventSystem。程序化点击／后台渲染与真实鼠标／手机触摸分别说明。

	- [ ] B6 完成Windows Addressables内容构建，核查新增／修改资产、meta／GUID、default标签、DefaultObject、EditorBuildSettings、程序集及包依赖；核对副本与正式工程交付哈希，恢复正式配置，不复制Library、测试脚本、测试配置或测试进度。

	- [ ] B7 更新本TODO实际完成状态、既有玩法TODO、WORK_LOG及MigrationAcceptance。验收文档追加本批入口、步骤、预期结果、旧进度兼容、已知限制与开发证据，用户验收保持未勾选。分别报告代码、Unity编译、Play、内容打包、应用／APK构建、安装及真机状态；本清单不把APK／真机未执行写成已通过。

- A8 连续执行与中断交接
	- B1 推荐顺序：证据及实施确认→主线配置与流程→无限模式数据和完整流程→存档兼容→资源／双语接入→专项验证及正式同步。主线、无限模式均属本批交付，不以只扩关卡数组或只打通入口作为完成。

	- B2 实施确认后连续完成已授权工作，不在每个TODO前重复请求许可；发现核心规则缺证据、需要新增未确认职责关系或补建UI时，说明具体问题并请求所需确认，同时推进不依赖该决定的工作。

	- B3 会话中断时记录已改文件、已通过／失败检查、未决问题和下一条可执行步骤，保持未验证项目未勾选。若受限只能部分交付，分别说明主线和无限模式完成程度，不把整批标记完成。

	- B4 当前状态：仅完成执行计划编写；A2—A7实施及验证条目均待执行。现有主线历史见[主线50关迁移TODO](Campaign50MigrationTODO.md)，用户验收历史见[迁移验收文档](MigrationAcceptance.md)。
