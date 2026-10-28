- A1 本批范围与授权（2026-10-28）
	- B1 根据用户确认，接续第20关，迁移第21—50关主线、对应地图池／固定关／难度规则与主线阶段奖励；沿用当前启动、Controller、PuzzleModule、面板、Addressables、SO及存档体系。

	- B2 原作依据：只读目录中的 DynamicDifficulty、CampaignMapBank、CampaignDifficulty、LevelRewardService、ResultScreen 及其调用方、方法索引／诊断、ARM64／ISIL、CampaignDdaMaps 二进制和正式 GameConfig／ResultLayoutConfig。恢复代码不是运行验证结果。

	- B3 主要修改：CampaignController、PuzzleModule、GameController、HomeController、SaveModule、CampaignSaveModel、GameConfigSO、结果页 Panel／Controller／制作工具；正式 GameConfig、HomeConfig、必要结果UI与中英文文案。新增资产须绑定正式引用；不新增启动或资源加载体系。

	- B4 黄金挑战仅核对触发、账号／服务依赖及资源依据，记录后续迁移边界；第51关起地图变换、无限模式、真实广告／支付／排行榜／云端服务不在本批实现范围。

- A2 实施 TODO
	- [x] B1 保存当前修改基线，核对原作第21—50关尺寸、固定关、技能／选图上限、困难关及奖励时机；记录诊断与静态证据边界。

	- [x] B2 增量导入实际需要的原作地图为正式SO，保留既有地图ID、GUID、池内顺序与存档游标；扩展至50关，保留第51关明确边界。

	- [x] B3 扩展现有选图与校验、难度进退、困难关接续，确保返回／重启／重开不重复抽题或重复结算。

	- [x] B4 接入主线阶段奖励、正式SO参数、领取防重、现有额外道具余额、结果页显示与双语文案；广告翻倍明确未接入，不模拟成功。

	- [x] B5 实现旧进度兼容与合法性校验，保留旧棋盘、选图历史、每日／连胜／资料进度；明确历史奖励处理策略，不复制测试进度。

	- [x] B6 在隔离工程完成Unity编译、正式场景Play Mode、20→21及49→50边界、难度／固定关／历史、奖励防重、存档恢复与相邻已实现页面回归；检查中英文及竖屏布局，构建Addressables内容。

	- [x] B7 检查正式工程同步完整性、GUID与Addressables注册，更新迁移验收文档和工作记录。分别报告编译、Play Mode、内容打包、APK、安装与真机状态；用户验收保持未勾选。

- A3 后续队列
	- [ ] B1 黄金挑战：核清第20关起、间隔4关的静态配置与实际状态流、奖励和服务依赖，再按完整功能单独确认实施。

	- [x] B2 第51—100关：后期地图变换与下一阶段难度已完成，见A8；无限模式完整玩法另批确认。

	- [ ] B3 外部服务：广告、每日授权、账号／云存档、排行榜、支付按独立完整批次推进。

	- B4 2026-10-28已确认整理[下一批迁移TODO](NextMigrationTODO.md)，集中规划101—300关与无限模式完整本地玩法；本次仅文档授权，实施前按新TODO核实证据并确认具体迁移清单。原有批次结论保留。

- A4 验证与证据
	- B1 开发证据保存至 Logs/Campaign50Migration/。静态分析、程序化Play Mode和后台渲染分别记录，不代替原APK动态对照或真机触摸验收。

	- B2 2026-10-28开发完成：前50关、2923张新增地图（主线共6359张）、阶段领取、v11存档、双语资源和正式引用已接入。Unity6000.5.2f1／Addressables2.10.3隔离工程编译、355项程序化检查、中英文后台截图与Windows内容打包通过；54份交付文件／meta与验证副本一致，GUID／依赖／DefaultObject注册已核对。开发结果不代替用户验收。

	- B3 黄金挑战依赖分析完成：GoldenChallenge使用FirebaseCallables会话与云函数，关联排行榜待上报通关和奖励；恢复方法存在诊断。本批不实现挑战或模拟服务成功，A3-B1完整迁移仍待后续确认。第51关、APK、安装、真机与原APK动态对照未执行。


- A5 已确认的配置结构整理（2026-10-28）
	- [x] B1 对齐麻将项目的独立地图SO、规则／表现分离及AssetModule整数ID注册；保留主线50关与当前Hamdoku选图规则。

	- [x] B2 8180张地图整理至Assets/Res_Runtime/Puzzle/，主线6359、每日1820、教程1。原有1967份独立资产保留GUID，其余6213张从GameConfig提取；地图ID和业务字段逐项一致。

	- [x] B3 新增PuzzleRulesSO／CampaignConfigSO／PuzzlePresentationSO与正式资产，ResultConfig独立加载；GameConfig只保留默认语言、存档名与版本。Logo启动配置同步改绑GameConfig；HomeConfig保留首页配置。

	- [x] B4 每日日期表转为原地图整数ID，AssetModule统一加载／索引；原地图数组位置映射结果保持。更新Controller、PuzzleModule、Panel／Widget的配置参数及现有编辑器工具，不新增启动或Context体系。

	- [x] B5 完成Unity编译、正式场景Play Mode、教程与1—50关、旧版存档、阶段奖励、每日进入／续局／读盘恢复／通关返回、资料与商店回归；Windows Addressables内容打包和静态交付审计通过，存档保持v11。用户验收见迁移验收文档对应批次，APK与真机未执行。

- A6 原作地图全量导入工具（2026-10-28）
	- [x] B1 用户确认后实现预览／执行／验证三个菜单；直接读取原作HDDA二进制、教程与每日JSON，不修改原始取证资料，不生成5万份逐关重复SO。

	- [x] B2 导入10498条DDA、1820张每日与1张教程，共12319份独立PuzzleSO；本批新增4139份，保留原有8180份ID、GUID及文件内容。保留64条fixedLevel=-1原始标记，不将其视作普通固定关开放。

	- [x] B3 增量维护目录、地图内容、当前配置地图ID与Addressables登记；执行前备份，源文件SHA256变化单列，重复执行零新增／零更新。重复ID、非法区域／答案、固定关冲突、缺失资源及未保存地图／配置／登记编辑明确拦截。

	- [x] B4 Unity6000.5.2f1隔离工程完成实际导入、只读预览、失败不写入、重复执行、标签修复与脏编辑保护测试；正式场景Play Mode 26875项检查和Windows Addressables内容打包通过。工具与数据交付审计见Logs/PuzzleImportValidation/，用户验收见MigrationAcceptance本批。

	- B5 当前主线仍50关、活动池6359张、存档v11；未实现51—100关、无限模式或外部服务。50000条旧CampaignDatabase只核对内容及与当前DDA配置的关系，不能以其数量代替可玩关卡范围。APK、安装、真机与原APK动态对照未执行。

- A7 第51—100关分析与已确认方案（2026-10-28）
	- B1 已核对DynamicDifficulty／CampaignMapBank／CampaignDifficulty调用、方法索引／诊断与ARM64／ISIL，原作二进制只读。51—100关技能与选图上限4；从51关起干净通关晋级门槛从2次变为1次；固定关55／60／62／70／75／80／90／100，尺寸依次9／9／7／9／9／9／9／10。以上是静态证据，不等同原APK运行验证。

	- B2 普通池变换按cursor.cycle取模8，51关前为0，51关起池游标走完一轮再推进cycle；不能替换为每局独立随机旋转。固定题走独立分支，保留原方向。当前存档仅保存位置，无cycle或局内transform，需同时迁移以保证重开／返回／读盘棋盘一致。

	- B3 拟使用现有地图SO，将当前活动池6359张扩至9610张，保持已有ID／GUID和池内顺序；不新增重复地图SO。CampaignConfig扩到100关，加入后期晋级与变换参数；PuzzleModule、CampaignController、运行棋盘Model、GameController／GameFlowController及棋盘PanelController适配，SaveModule／SaveModel升级v12并兼容旧版，相关制作工具同步。

	- [x] B4 用户确认后已实施：交付51—100关、8种变换及持久化、阶段奖励和100关批次边界，实际验证见A8。无限模式只保留原100关解锁条件与现有准备提示，完整玩法、黄金挑战和真实服务另批确认。验证计划覆盖50→51、固定关／62关小棋盘、池轮次与8种变换、旧进度续玩、99→100和领奖防重，并分别记录编译／Play／内容打包／APK／真机。

	- B5 分析阶段只有阅读与记录，证据Logs/Campaign100Analysis/evidence.json；后续实施结果见A8。


- A8 第51—100关实施与验证（2026-10-28）
	- [x] B1 CampaignConfig扩至100关，普通地图上限4，活动地图6359→9610；已有地图ID／GUID、池内顺序及前50关尺寸和难度配置保持。55／60／62／70／75／80／90／100固定题接入，第62关7阶、第100关10阶。

	- [x] B2 新增纯数据PuzzleBoardModel，PuzzleModule生成独立区域／答案／预置位置数组；GameState和GameController使用运行棋盘，不写共享SO。普通池51关起使用cursor.cycle模8，当前题用旧轮次、选中池尾后推进下一轮；历史跳过与固定题保持原分支。

	- [x] B3 CampaignConfigSO新增后期晋级及变换起点参数；第51关起一次干净通关即可晋级，上限4。保留首局减级、道具／失败／延期降级与既有10关阶段奖励、防重复领取及第100关返回首页边界。

	- [x] B4 SaveModule／CampaignSaveModel／PuzzleSaveModel升级v12，保存池轮次和本局变换；旧v1—11兼容，旧轮次补0、旧棋盘不旋转。提示／排除标记／分数账本、重开、返回、读盘均保留同一变换，不复制测试进度。

	- [x] B5 Unity6000.5.2f1／Addressables2.10.3隔离工程编译、完整教程至100关Play Mode通过27296项检查；12319张地图的8种变换共98552组合与独立坐标公式逐项一致。补测60项覆盖真实v11测试存档缺失字段升级及全部8种变换下的提示／返回／重开／读盘，另50项覆盖中英文100关结算、原100关无限模式解锁条件与现有准备边界。

	- [x] B6 第100关结束文案缩短为“前100关已完成！”／“First 100 levels complete!”，修复原长文案换行；1080×1920中文、1080×2400英文安全区后台渲染及51关变换／62关小棋盘截图人工查看。正式内容打包、来源／引用／GUID与交付审计见Logs/Campaign100Migration/，用户验收见MigrationAcceptance A24。

	- B7 无限模式、黄金挑战、101关以后玩法和真实服务不在本批；原APK动态对照、应用／APK构建、安装、手机触摸与真机性能未执行。开发自测不代替用户验收，用户条目未代勾。
