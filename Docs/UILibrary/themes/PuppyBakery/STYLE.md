- A1 风格定位与确认基准
	- B1 游戏名称：Sudoku Pup，中文名《数独小汪》。美术主题：小狗面包房。视觉方向：奶油白与雾灰蓝的温暖绘本风格，使用简洁的二维造型与克制的手绘笔触，适配休闲解谜游戏。

	- B2 用户于 2026-10-27 确认的视觉基准为 [小狗正面头像](assets/Sprite/hamster_idle_04__sharedassets2.assets__6.png)。后续制作必须实际查看该图片，并以它作为图像参考；文字描述不能代替参考图。替换对应关系见 [manifest.json](manifest.json)。

	- B3 已确认的是这一张正面头像的造型、配色与画法。完整身体、侧背面、服装、其他表情、背景和 UI 尚无已确认成品，不把这些扩展写成已定稿设计。


	- B4 Logo 页整体样式图：[Panel_Logo_Style_1080x1920.png](assets/UI/Logo/Panel_Logo_Style_1080x1920.png)，尺寸1080×1920，放在对应页面的素材目录内，供制作时直接查看。此图是用户确认的整体视觉参考，不作为单张运行贴图替换，也不代表后续动画和局部修正的最新运行截图。

		![Sudoku Pup Logo页整体样式图](assets/UI/Logo/Panel_Logo_Style_1080x1920.png)

- A2 小狗造型
	- B1 采用正面、居中的单个小狗头像。头部饱满，脸型为柔和的圆角方形，下巴圆润；脸颊两侧保留少量简化毛簇，避免细碎毛发。

	- B2 两只雾灰蓝垂耳从头顶两侧向外、向下展开，耳尖圆钝。垂耳与脸颊共同构成小狗识别轮廓，不沿用原仓鼠顶部的两只直立圆耳和底部横向鼓出的轮廓。

	- B3 主脸为浅奶油白，画面右侧眼睛周围有一块雾灰蓝色眼斑。后续同视角素材保持眼斑在画面右侧，不随意镜像；其他视角需先确认角色自身左右关系。

	- B4 双眼为简洁的深色圆点，鼻子为小而圆钝的深色犬鼻，口鼻区为浅奶油色。嘴部保持轻微微笑，两侧带淡桃色腮红；不画仓鼠胡须。

	- B5 基础头像不添加身体、脖子、爪子、衣服、项圈、厨师帽或面包道具。后续需要这些元素时单独制作变体，不改动基础款来混入新设计。

- A3 配色关系
	- B1 主色：浅奶油白，用于脸部和口鼻区。保留温暖感，避免变成高亮纯白或偏黄橙的大面积毛色。

	- B2 识别色：低饱和雾灰蓝，用于两只垂耳和单侧眼斑。耳朵与眼斑属于同一色系，避免分别变成紫色、青色或高饱和亮蓝。

	- B3 结构色：暖深棕与近深炭色，用于外描边、眼睛、鼻子和嘴巴。深色结构保证缩小后仍可辨认，不使用强烈纯黑粗边。

	- B4 点缀色：淡桃色腮红，面积小、对比轻，不抢过眼睛、鼻子和耳朵。

	- B5 颜色以确认图片中的视觉关系为准。当前不把带笔触图片中的任意单个采样像素定义为唯一标准色；制作不同尺寸时保持明暗、冷暖和饱和度关系，不自由更换整套配色。

- A4 线条、笔触与明暗
	- B1 外描边清楚、连续、圆润，带轻微手绘起伏。线宽观感参照确认图片，不复制原仓鼠外描边，也不增加厚重的双层边框。

	- B2 色块内部保留轻微水粉或干刷质感，形成绘本插画观感。笔触服从大色块，不使用密集纸纹、噪点和逐根毛发。

	- B3 以平面色块为主，只保留轻微的局部明暗变化。避免写实皮毛、塑料高光、立体玩具渲染、金属质感、强烈渐变和戏剧化打光。

	- B4 纹理和深浅变化限定在角色内部；透明区不添加纸张底色、外发光、地面或投影。

- A5 尺寸、位置与文件交付
	- B1 当前这张替换图的画布必须为 509 × 439 像素，PNG、RGBA、真实透明背景。不得将生成工具的更大输出直接作为这一张的最终交付。

	- B2 保持角色居中、完整可见和接近原素材的占用尺度，保留少量透明边距。允许小狗轮廓与原仓鼠不同，不再要求透明蒙版、外描边或外形逐像素一致。

	- B3 当前确认文件的非零透明度边界为左 19、上 5、右 501、下 430 像素，右与下为不包含端点的边界；此值记录该文件实际内容，不作为所有表情或其他素材的通用边界锁。

	- B4 后续其他替换素材分别读取其对应原文件的像素尺寸、透明区、切片和用途，不把全部素材强制输出为 509 × 439。尺寸归一化保持等比，不拉伸角色。

	- B5 新套素材保存在本目录的 assets 下，沿用对应原文件名建立映射。原始参考素材保持不变；制作新方案时另存版本，不覆盖已确认基准。

- A6 后续素材的一致性与检查
	- B1 同一小狗的表情和动作变体保持头脸比例、垂耳结构、眼斑位置、配色和线条体系一致，仅改变必要的表情与动作。

	- B2 后续面包房道具和 UI 可沿用圆润造型、低饱和配色、清楚深色边缘及克制绘本笔触，但具体图案、布局和功能色仍需结合页面制作，不把头像配色机械应用到全部棋盘区域。

	- B3 每张素材检查实际像素尺寸、透明背景、完整边缘和居中位置；按游戏内实际尺寸检查眼睛、鼻子、嘴巴和轮廓能否辨认，避免纹理缩小后变脏。

	- B4 接入棋盘后检查角色与区域颜色的区分度，保留区域颜色与辅助纹样的可辨识性。成品图片已确认不等于已完成 Unity 接入、Play Mode 或真机验证。

- A7 可复用的生成描述
	- B1 使用本目录已确认的小狗头像作为图像参考，制作温暖绘本风格的二维小狗头像；正面居中，饱满圆角方脸，左右两只向下垂落的圆钝耳朵，少量简化脸颊毛簇；浅奶油白脸部、雾灰蓝耳朵及画面右侧单眼眼斑，深暖色圆眼睛、小犬鼻和轻微微笑，淡桃色腮红；清楚圆润的手绘外描边，色块内部仅有克制的水粉干刷笔触，缩小后仍清晰可辨；单个头像、完整可见、真实透明背景。当前对应头像最终画布为 509 × 439 像素。

	- B2 排除项：仓鼠直立圆耳、仓鼠胡须、橙棕色耳朵、写实皮毛、密集纸纹、三维塑料质感、额外身体与服装、背景色块、投影、文字、水印。其他资产使用时调整主体与尺寸描述，继续保留确认图的视觉语言。


- A8 Panel_Logo 首批拆分素材
	- B1 用户已确认 [1080×1920 启动页整体方案](previews/Panel_Logo_overall_v01_1080x1920.png)。本页招牌采用上下两行 Sudoku／Pup，包含小型数独格标志、蓝白遮阳篷、浅色烘焙与爪印纹样和五枚饼干加载标记；这些页面元素以该整体图为基准。

	- B2 首批 13 张替换图片位于 assets/UI/Logo/，详细对应关系、实际像素尺寸及来源见 [页面素材清单](assets/UI/Logo/manifest.json)。名称以当前正式目录为准，已采用 Img_Common_Logo、Img_Logo_HamsterBody 等现有名称；保留 Hamster 等文件名是为了对应引用，图片内容为小狗。

	- B3 完整 Logo、角色可见部分、标题、爪子和加载图标主要从确认稿提取。干净背景、空招牌和闭眼图层通过内置 image_gen 补全；工作底图保存在 previews/Logo_Slicing/。背景不包含文案、Logo 和加载图标，运行文案继续使用既有 TMP 与本地化体系。

	- B4 文件名、像素尺寸、RGBA 和透明区域已做离线检查，另有 [素材总览](previews/Logo_Slicing/contact_sheet_v01.png) 和 [分层拼合预览](previews/Logo_Slicing/page_layers_reassembled_1080x1920.png)。这两类检查不能替代 Unity 运行验证。

	- B5 旧动画按单行招牌设计，不能只换图片就视为整体效果一致。两行招牌的显示尺寸与中心、眼睛对齐、前景爪子遮挡、字母 o 内奶油色爪印的盖章位置、背景顶部裁切，以及动画切换完整 Logo 的衔接，均需在接入阶段核对。离线位置参考保存在 previews/Logo_Slicing/layout_reference.json；当前图片已安装到正式目录 new，旧图归档到 old；正式场景布局和配置尚未调整。

- A9 标题中心爪印动画图层
	- B1 按用户要求，将 Sudoku 中字母 o 内的奶油色爪印独立为 assets/UI/Logo/Img_Logo_Cross.png，保持正式文件的 88×89 像素。它取代此前误选的侧边蓝色装饰爪印；四个趾垫和一个掌垫来自确认稿。

	- B2 Img_Logo_BoardFront.png 中字母 o 的底层已补成完整深棕色字面，爪印隐藏、缩放和位移时不会露出原来的透明镂空；完整静态 Logo 保留最终爪印外观。

	- B3 [爪印盖章动画预览](previews/Logo_Slicing/center_paw_stamp_preview.gif) 为离线缩放与轻微回弹演示，不是 Unity 运行截图。对应位置已写入 layout_reference.json，可继续复用现有 Cross 图层动画槽位；正式场景和 SO 尚未调整。

- A10 正式图片替换与归档
	- B1 2026-10-27 按用户要求将13张新素材安装至 Assets/Res_Runtime/UI/Logo/new/，旧图片归档至同级 old/。new 中图片继承原有 .meta 与 GUID，old 中图片使用独立 GUID，原有场景、SO 和其他页面的序列化引用继续指向新版。

	- B2 LogoSetupEM、HomeSetupEM 中明确的图片加载路径已更新为 new，LogoSetupEM 的素材扫描范围也限定为 new，避免把 old 中归档图片再次批量导入或修改。替换未改动正式场景、动画逻辑或 SO 布局。

	- B3 图片、尺寸、GUID 和引用关系已做文件层检查；新招牌布局、实际导入结果与动画衔接尚未完成 Unity Play Mode 验证，不能将图片安装视为完整页面验收。

- A11 Logo 动画接入与修复
	- B1 按新图层实际透明边距校准角色、眼睛、招牌、前爪和字母 o 内爪印的显示尺寸及位置；校准数据保存在正式 LogoConfig.asset 和 Scene_Main.unity。原始 PNG 像素尺寸与 GUID 保持不变。

	- B2 HamsterMask 是不显示的白色矩形揭示遮罩，不能再换成小狗轮廓形状，否则运动中的脸和耳朵会被固定外形截断。BoardFront 中字母 o 在爪印出现前必须为无爪形残影的完整深棕字面。

	- B3 入场结束保留已经拼合的图层，直接进入整体呼吸与轻微浮动，避免切换完整 Logo 引起比例和位置跳变。关闭入场时仍使用完整 Logo 静态分支，完整图的显示尺寸与中心由 SO 保存。

	- B4 Unity 6000.5.2f1 隔离副本完成视觉 Play Mode 检查、重复初始化和释放、静态分支以及1080×1920、1080×2400、1080×1620渲染。验证中禁用ClientMain以隔离存档和其他服务，没有以此替代完整启动流程或真机验收。修复结果已同步到当前工程，依据见 Logs/LogoAnimationFix/verification.json。

	- B5 字母 o 内的中心爪印在盖章完成后持续独立呼吸缩放，局部比例范围为0.92–1.08，周期约2.24秒；位置不随该局部动画变化。参数使用LogoConfigSO的xIdlePulseAmount和xIdlePulseSpeed，原盖章入场仍保留。

- A12 设置页首批拆分素材
	- B1 用户于2026-10-27确认设置页整体视觉方向并要求切图。[整体样式图](assets/UI/Settings/Panel_Settings_Style_1080x1920.png)保存于页面素材目录，以1080×1920设计坐标归一化；不是运行截图，也不是整页运行贴图。

	- B2 [28张素材清单](assets/UI/Settings/manifest.json)包含背景、无字面板与小狗标题牌、两种按钮底图、开关轨道与独立滑块、选择底图、关闭入口、七类设置图标、底部入口图标、箭头及分隔装饰。背景复用Logo页绘本底图；原设置截图与SettingsPopupLayout配置用于核对功能和组件。无字底图与图标通过内置image_gen重建后分割，不能视为从确认稿无损裁切。

	- B3 中文、版本号、ON／OFF与设置值不烘焙进运行素材，后续使用TMP及既有本地化。纹理、尺寸、透明边界与建议九宫格边距见清单；开关轨道使用普通图片，面板与按钮可使用建议九宫格，仍需Unity实际导入验证。

	- B4 [素材总览](previews/Settings_Slicing/contact_sheet_v01.png)、[分层拼合预览](previews/Settings_Slicing/page_layers_reassembled_1080x1920.png)、[布局参考](previews/Settings_Slicing/layout_reference.json)及[离线检查结果](previews/Settings_Slicing/verification.json)用于接入前查看。原始生成底稿及切图脚本保存在同目录；本批仅保存主题素材，尚未创建或接入设置页Prefab、运行逻辑、SO与Addressables，未进行Unity或真机验收。

	- B5 用户随后要求以正式Settings目录的现有资源为切图契约，第一版28张保留为历史方案；当前待确认版为[v02的19张对应素材](assets/UI/Settings/v02/manifest.json)，沿用正式文件名与画布尺寸，记录原九宫格、PPU和GUID。两种白色Fill保持原文件，图标与底块不拆开，外层与内部面板分别制作，不新增标题牌、状态贴图或背景。面板保留原透明蒙版与28像素九宫格边距，其他造型等比放入原透明内容范围，边界差异记录在清单中。

	- B6 [v02切图总览](previews/Settings_Slicing_v02/contact_sheet_v02.png)与[原图／候选图对照](previews/Settings_Slicing_v02/original_vs_candidate_v02.png)用于用户审图；[检查结果](previews/Settings_Slicing_v02/verification.json)确认19张文件名及尺寸对应、Fill字节一致、正式目录所有文件哈希未变。用户明确要求先确认切图再替换，本轮未写入正式PNG、meta、Prefab或运行配置；此前B4的页面未实现说明仅描述第一版制作时状态，不用于判断当前工程实现进度。

	- B7 用户于2026-10-28授权按Logo页目录方式安装v02，19张新图位于正式Assets/Res_Runtime/UI/Settings/new，旧图归档至同级old。new保留原meta及GUID，old使用独立GUID；Panel_Settings.prefab原位且内容不变。SettingsSetupEM的导入扫描与图片查找同步指向new；没有运行配置工具。安装哈希与引用保留检查见Logs/SettingsImageInstall/verification.json，尚未验证Unity实际导入、Play Mode或真机效果。

	- B8 用户反馈v02面板粗角与宽边后，重新生成[两张v03边框候选图](assets/UI/Settings/v03/manifest.json)，保持351×512、512×428画布和28像素九宫格边距，使用新底图自身的透明轮廓，不再套用旧面板蒙版；圆角外侧真实透明，边线减细并保持连贯。当前仅候选，正式new目录仍为v02。[前后对照](previews/Settings_BorderFix_v03/original_vs_candidate_v03.png)、[竖屏拉伸预览](previews/Settings_BorderFix_v03/nine_slice_portrait_1080x1920.png)及[横向拉伸对照](previews/Settings_BorderFix_v03/nine_slice_width_comparison.png)为离线九宫格近似，采用当前0.6／0.7的PPU倍率，不是Unity运行截图。边界与文件哈希检查见同目录verification.json，待用户确认再替换。

	- B9 用户于2026-10-28确认v03边框后，两张PNG已安装到Assets/Res_Runtime/UI/Settings/new。原meta、GUID、28像素九宫格及Prefab引用保留；其余17张素材、old归档、Prefab、SO与运行逻辑不变。当前生效版本为v02其余素材加v03两张面板，B8的候选状态描述仅记录审图阶段。文件层验证见Logs/SettingsBorderInstall/verification.json；Unity实际导入和Play Mode效果尚未验证。

- A13 游戏页原尺寸切图（未替换）
	- B1 用户于2026-10-27确认无顶部遮阳篷的游戏页样图及焦糖饼干规则图，并明确本轮只切图、不替换正式资源。[确认整页图](previews/Game_Slicing/Panel_Game_Style_1080x1920.png)仅作为视觉参考。

	- B2 [34张PNG](assets/UI/Game/manifest.json)逐项对应Assets/Res_Runtime/UI/Game的文件名和实际像素尺寸；18张为主题制作、裁切或已确认主题素材复用，另16张保留原文件（12张辅助纹样、3张运行时着色白色底图、1张教程手指）。白色遮罩不能预先烘焙区域色，教程手指保留原图集切片与指尖位置。

	- B3 三张规则图均为478×478，沿用原作3×3排除关系，以同一套焦糖饼干格、巧克力叉号及小狗中心格拼合。背景、HUD空底及工具按钮空底通过内置image_gen补绘，不能宣称全部从样图无损裁切。生成描述和底稿保存在previews/Game_Slicing/；文字、数量角标和计数继续由TMP及独立UI显示。

	- B4 [素材总览](previews/Game_Slicing/contact_sheet_v01.png)、[实际920×128规则栏](previews/Game_Slicing/rule_strip_920x128.png)、[离线整页拼合](previews/Game_Slicing/page_layers_reassembled_1080x1920.png)及[检查结果](previews/Game_Slicing/verification.json)用于审图。拼合图使用离线布局、配色与Windows字体，不能作为当前Prefab运行截图；相同尺寸也不代表直接替换后与确认稿完全一致。

	- B5 34张文件名、RGBA、尺寸、非空内容及正式PNG／meta未改动检查通过，原九宫格边距、Sprite模式与素材来源已写入清单。不复制meta、不安装正式图片、不修改脚本、Prefab、场景、SO、存档或Addressables；本轮未进行Unity编译、Play Mode、内容打包、应用构建、安装及真机验证。

	- B6 2026-10-28按用户确认重绘Img_Game_Guide与Img_Game_Hint：灯泡轮廓、灯颈与双段底座连续完整，小狗改为侧向寻找、微收眉眼与闭口神态；均保留奶油色按钮及114×118 RGBA透明规格。仅更新本主题Game目录的这两张图片和对应清单，正式资源未替换。[前后对照](previews/Game_Tools_Revision_20261028/before_after.png)、底稿、生成描述及离线检查保存在同目录；历史全量切图脚本重跑时会应用此次修订。

- A14 项目长按钮风格候选（未替换）
	- B1 用户确认按设置页样图中金黄、蓝色长按钮的绘本语言制作项目按钮候选，范围为[12张按钮底图](assets/UI/Buttons/v01/manifest.json)：Game两张共享操作底图、Home四张长按钮、Ranking两张胶囊底图、Shop三张操作底图、Streak一张继续底图。关闭、箭头、开关和首页两张大型模式卡不在本批。当前仅审图候选，未安装正式资源。

	- B2 六种生成底稿分别为蜂蜜金黄、雾灰蓝、奶油、桃色、柔和粉色及困难关珊瑚红；各张沿用原文件名和像素画布。爪印从前批高分辨率主题底稿提取后拼合，中心不烘焙文字或功能图标。原底图与生成底稿不是无损切图关系。

	- B3 [素材总览](previews/Buttons_v01/contact_sheet_v01.png)、[原图／候选图对照](previews/Buttons_v01/original_vs_candidate_v01.png)、[按钮示意](previews/Buttons_v01/button_style_preview.png)及[全部22处尺寸的切线对照](previews/Buttons_v01/all_consumers_slice_comparison.png)用于用户审图。示意文字和教程图标仅离线演示；没有通过Unity渲染，不能代表最终本地化或布局验收。

	- B4 原九宫格参数会使部分爪印消失或变形，单改切线也无法适配共享按钮的不同高度。清单记录9张建议调整的Sprite边距及各个已序列化Image的建议PPU倍率；切片按钮倍率按图片像素高度／显示高度计算，使装饰随高度等比显示，再仅拉伸中部宽度。首页无限模式按现有非等比显示尺寸对爪印宽度作反向补偿。正式安装须经用户同意，同步导入边距、对应Image倍率及制作工具／可能的运行覆盖；不能只复制PNG就宣称效果一致。本轮不修改这些参数或脚本。

	- B5 [离线检查](previews/Buttons_v01/verification.json)记录12张RGBA、名称／尺寸对应及正式UI目录全部文件哈希未变。源底稿、生成提示词和切图脚本保存在同目录，历史其他页面候选保留。未执行Unity导入、编译、Play Mode、内容打包、应用构建、安装或真机验证。

	- B6 用户确认后，2026-10-28已将12张按钮安装到各自正式Game／Home／Ranking／Shop／Streak的new目录，旧图在同级old归档，原GUID保留。9张Sprite更新九宫格边距，9份Prefab的20处切片Image按实际高度更新倍率；浅底图上的原白字改为暖棕色，文案、图标、尺寸、回调与生命周期保留。8份既有编辑器工具同步路径、导入边距及显示参数，不新增运行脚本或节点；同目录其他新素材保留，不纳入本批替换。

	- B7 Unity6000.5.2f1独立副本通过编译、导入、22处Prefab按钮引用及倍率检查、隔离Play Mode、中英文设置页、1080×1920／1080×2400渲染，以及设置页重新开始／教程事件上报与释放。截图及日志在Logs/ButtonsInstall/，本批41份图片／meta／Prefab／工具文件与验证副本一致。验证未启动ClientMain或读写进度，不等同完整业务启动、Editor人工点击或真机触摸验收；未进行内容打包、应用构建、安装或真机验证。A14前述候选状态为历史审图记录，当前安装状态以本条和素材manifest为准。

- A15 个人资料头像边框（已安装，运行效果未验证）
	- B1 用户于2026-10-28确认本批只制作19款边框图片。对应正式profile_frame_0至7、10至20；配置21个槽位中的8、9为空，不补建。候选位于[Frames/v01](assets/UI/Profile/Frames/v01/manifest.json)，7款基础、1款金冠、6款彩色皇冠、4款段位和1款会员边框。

	- B2 逐张使用原边框作构图参考、已确认小狗作画风参考，经内置image_gen生成独立底稿；奶油、饼干与糖霜色块采用暖棕描边和绘本笔触。徽章与会员牌留白，不烘焙数字、文字、锁头或现有光效。皇冠、宝石和丝带保留等级识别；19款美术于2026-10-28经用户确认全部保留，随后授权立即替换，现已原位安装正式PNG。

	- B3 原始生成图和完整提示词保存在previews/Profile_Frames_v01/。19张正式尺寸候选为RGBA透明PNG；通过预乘alpha的3×3分段坐标重采样，使开口中心横纵截线边界对齐原图，不复制旧图色块或透明蒙版。圆角轮廓、笔触及徽章形状不保证像素一致；接入前仍需核对实际徽章文字、裁剪及缩放。

	- B4 [整套总览](previews/Profile_Frames_v01/contact_sheet_v01.png)、[小狗叠放预览](previews/Profile_Frames_v01/puppy_overlay_v01.png)及[原图对照](previews/Profile_Frames_v01/original_vs_candidate_v01.png)供审图。小狗叠放按开口离线拟合，未精确复现Widget_ProfilePortrait的缩放与裁剪，不是Unity运行截图。[检查结果](previews/Profile_Frames_v01/verification.json)确认19张名称、画布、RGBA、中心与四角透明、开口中心截线及正式PNG／meta未变。

	- B5 本批未替换正式资源，未修改脚本、Prefab、SO、Addressables或存档，未执行Unity导入、编译、Play Mode、内容打包、应用构建、安装及真机验证。制作期间其他任务修改了Panel_Profile.prefab与ProfileConfig.asset，单独记录，不回滚或归因为本批图片制作；本批处理前后复核它们没有进一步变化。用户审图入口见[迁移验收文档](../../../MigrationAcceptance.md)的本批候选条目。

	- B6 用户随后明确要求立即替换，19张PNG已安装至Assets/Res_Runtime/UI/Profile原路径。保留原meta、GUID、导入参数和配置引用；旧图及原meta备份于Logs/ProfileFrameInstall/before/，确认稿、生成底稿与素材包保留。19张运行PNG与确认稿一致，210个受保护文件中仅这19张PNG改变，核对见Logs/ProfileFrameInstall/verification.json。B4／B5仅记录制作阶段；当前为已安装、Unity实际导入和运行效果未验证，会员牌仍留白，实际徽章、光效和裁剪待运行验收。

- A15 个人资料28款头像及前爪候选（未替换）
	- B1 用户于2026-10-28确认制作全部28个可见头像：16款普通、12款会员；隐藏槽位6的icon_hamster不在本批。候选保存在[Profile/v01](assets/UI/Profile/v01/manifest.json)，另配20张avatar_hand前爪层，共48张PNG。

	- B2 每张头像以已确认的正面小狗图片为参考，使用内置image_gen单独生成；保留奶油白脸、雾灰蓝垂耳、画面右侧眼斑和暖棕描边，按原头像语义区分表情动作。会员基础款仍为同一只小狗，通过表情和轻微脸颊毛簇变化制作，不自行更换角色配色。

	- B3 图片按对应正式文件名和实际画布尺寸保存为RGBA，裁去生成底稿透明边距后等比缩放居中，未拉伸造型。20张前爪通过内置image_gen从对应头像分离，再等比放入原前爪画布；并非逐像素无损提取，服装遮挡、Sprite裁剪／轴心及与头像的精确对齐尚待接入验证，不能直接宣称可无调整替换。

	- B4 [28款头像总览](previews/Profile_Avatars_v01/contact_sheet_v01.png)与[前爪总览](previews/Profile_Avatars_v01/hands_contact_sheet_v01.png)用于用户审图，浅米色仅为总览底色。底稿、头像提示词、前爪提示词、来源映射及[48张检查结果](previews/Profile_Avatars_v01/verification.json)保存在同一预览目录；检查通过文件名、对应画布尺寸、RGBA及0至255透明通道范围。

	- B5 用户于2026-10-28明确确认整套图片可用并全部保留，28张头像与20张前爪状态更新为美术已确认、尚未安装。本批未修改正式Assets、脚本、Prefab、SO、Addressables或存档，未执行Unity编译、Play Mode、内容打包、应用构建、安装或真机验证；前爪精确叠放仍待验证。审图记录见[迁移验收文档](../../../MigrationAcceptance.md)。


- A16 商店页首批切图与图片安装
	- B1 2026-10-28用户确认[无顶部垂边的商店稿](assets/UI/Shop/Panel_Shop_Style_v02_1080x1920.png)，授权只读核对原项目并开始切图。范围为移除广告、放大镜、提示三个商品区；礼包、限时优惠、会员及其状态不在本稿范围。

	- B2 核对原项目04_assets/Sprite的商店图片、ShopPopupLayout静态配置、ShopPopup的动态构建方法及当前Panel_Shop.prefab。原目录保持只读。恢复方法均带诊断，仅作为图片／文本拆分和动态组装的结构证据，不作为原作运行验收。

	- B3 [19张PNG清单](assets/UI/Shop/manifest.json)含11张与当前商店正式图片同名同尺寸的候选，以及8张配套背景、分组面板、标签、金色价格底图、无角色小放大镜和标签图标。关闭按钮沿用当前裁边后的249×256，而原导出画布为256×256。新增素材尚未绑定，不覆盖Game共用背景。

	- B4 招牌、分组标签、商品卡和价格按钮均不烘焙文案或数值；ADS保留为图标符号。无字整页、背景与空分组面板由内置image_gen补绘，其他图层裁切及透明处理，不宣称全部来自无损裁切。生成描述、底稿、来源证据与脚本保存在previews/Shop_Slicing/。

	- B5 [素材总览](previews/Shop_Slicing/contact_sheet_v01.png)、[离线拼合](previews/Shop_Slicing/page_layers_reassembled_1080x1920.png)、布局参考及[检查结果](previews/Shop_Slicing/verification.json)用于审图。离线九宫格将商品卡与按钮边距按0.35显示，正式接入仍需校准PPU倍率、布局和颜色；现有粉色图标染色不能直接沿用。拼合使用Windows字体，不是Unity运行截图。

	- B6 Windows／Python／Pillow／NumPy检查19张尺寸、RGBA、非空、透明角、九宫格合法性和哈希通过，核对本任务商店正式图片／meta、Prefab、配置及相关脚本未变。首轮发现关闭按钮缺叉及面板采样残影，均在交付前修复。当前仅素材准备，未进行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。

	
	- B7 2026-10-28按用户确认整理正式Assets/Res_Runtime/UI/Shop/old与new：归档20张原图，new共28张。另批长按钮已先建立目录并安装3张按钮，本轮沿用其目录、meta与归档；用户明确选择保留统一长按钮shop_btn_magnifier。实际替换10张同名PNG，迁移7张未重绘原图，保留3张已安装统一按钮，新增8张尚未绑定的配套素材。

	- B8 20份当前正式meta逐字节保留，原GUID继续指向new，old使用独立GUID；最新Panel_Shop.prefab与ShopConfig.asset保持本轮安装前内容。ShopSetupEM只扫描new并优先在new查找，保留统一按钮的路径、导入参数与像素倍率调整，同时补入新增素材的九宫格边距。未运行制作菜单。

	- B9 文件级尺寸、RGBA、确认稿哈希、旧图归档、meta／GUID保留、重复GUID及20个Prefab引用检查通过，详见Logs/ShopImageInstall/verification.json。shop_btn_magnifier的候选源哈希与实际保留按钮的installedHash分别记录。背景、分组面板和标签等8张图仅安装未绑定；布局、PPU倍率及粉色图标染色仍待后续接入。未执行Unity实际导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。

	- B10 2026-10-28用户确认按原作增加商店投影，已将原ui_soft_shadow（160×160、60像素九宫格边距）和四组静态投影参数接入正式Prefab／ShopConfigSO；卡片使用柔边底图，四张主要插画使用六层轮廓投影。51层均在内容后方且不接收点击，礼包确认图保持。Unity 6000.5.2f1隔离编译、重复制作及三种竖屏比例后台渲染通过，见Logs/ShopShadow；未做本批Play Mode、内容打包、应用构建或真机验证。

- A17 芝麻雪纳瑞第二套头像（美术已确认，未安装）
	- B1 用户于2026-10-28选定[5号芝麻雪纳瑞](assets/UI/Profile/DogVariants/v01/05_sesame_schnauzer.png)，授权制作第二套12款头像及8张前爪，覆盖原会员头像17至28；既有蓝耳小狗整套保留，奶油卷毛犬与黑糖奶牛犬基础图也保留。

	- B2 [20张图片清单](assets/UI/Profile/Schnauzer/v01/manifest.json)沿用对应正式文件名和原图画布尺寸。17号自然微笑逐像素复用确认基础图，其余11张表情以该图为身份和画风参考分别通过内置image_gen生成，保持芝麻灰折耳、奶白眉毛、脸颊胡子与短胡子的造型及绘本笔触。

	- B3 [12款头像总览](previews/Profile_Schnauzer_v01/contact_sheet_v01.png)、[8张前爪总览](previews/Profile_Schnauzer_v01/hands_contact_sheet_v01.png)、底稿、完整提示词与[离线检查](previews/Profile_Schnauzer_v01/verification.json)位于同一预览目录。前爪使用灰色毛与奶白脚趾；AI分离后按原画布等比归一化，不是无损逐像素提取，服装遮挡、轴心与运行精确叠放尚未验证。

	- B4 Windows离线检查20张RGBA、非空内容、对应原画布尺寸及透明通道0至255范围通过，人工查看头像与前爪总览。本批未修改运行资源、脚本、Prefab、SO、Addressables或存档；未执行Unity编译、Play Mode、内容打包、应用构建、安装或真机验证。基准哈希记录制作期间其他工作更新的Panel_Profile及19张边框，与本批制作区分，不回滚这些修改。

	- B5 用户于2026-10-28回复“可以的”，确认本套12款头像与8张前爪美术可用并保留；状态更新为美术已确认，正式接入仍未实施。

- A18 奶油卷毛犬表情套装（图片待确认，未安装）
	- B1 用户于2026-10-28选用[2号奶油卷毛犬](assets/UI/Profile/DogVariants/v01/02_cream_curly_puppy.png)，要求按上一套范围制作12款头像及8张前爪；蓝耳小狗与雪纳瑞两套保留，不替换正式资源。

	- B2 [20张图片清单](assets/UI/Profile/CreamCurly/v01/manifest.json)对应原会员槽位17至28，沿用对应文件名和原画布尺寸。17号逐像素复用所选基础图，其余11款表情以奶油卷毛犬为身份与画风参考，使用内置image_gen分别生成；奶油白脸、浅饼干色卷耳和额头卷毛保持一致。前爪同为奶油色，无雪纳瑞灰色毛。

	- B3 [12款头像总览](previews/Profile_CreamCurly_v01/contact_sheet_v01.png)、[8张前爪总览](previews/Profile_CreamCurly_v01/hands_contact_sheet_v01.png)、底稿、完整提示词和[离线检查](previews/Profile_CreamCurly_v01/verification.json)保存在同一目录。前爪AI分离后等比适配原画布，不是无损逐像素提取；服装遮挡、Sprite轴心和精确叠放仍待接入验证。

	- B4 Windows离线20张RGBA、非空内容、原画布尺寸、透明通道0至255范围及基础图复用像素检查通过，人工查看完整头像与前爪总览。制作完成时正式Profile目录、蓝耳小狗、雪纳瑞及三款基础PNG基准哈希无变化；之后仅同步雪纳瑞美术确认与选型记录。未修改正式运行资源、脚本、Prefab、SO、Addressables或存档，未执行Unity编译、Play Mode、内容打包、应用构建、安装或真机验证。


- A19 商店两张礼包插画（美术已确认，已安装）
	- B1 2026-10-28用户确认截图红框内新手礼包与特别优惠两张插画重绘，先交付候选审图。以已确认蓝耳小狗头像作为身份与画风参考、现有两张礼包图作为构图参考，分别使用内置image_gen生成；保留画面右侧蓝色眼斑和垂耳，仓鼠替换为小狗。

	- B2 [两张PNG清单](assets/UI/Shop/Offers/v01/manifest.json)对应offer_art_starter_pack.png（384×384）与offer_art_special_offer.png（384×376）。新手礼包为珊瑚粉开盖礼盒、小狗、放大镜和灯泡；特别优惠为金色蝴蝶结礼盒、含小狗头像的放大镜、灯泡和ADS禁用徽章。生成原图保留，候选仅裁去空透明边距后等比缩小并居中，不拉伸。

	- B3 [两图总览](previews/Shop_Offers_v01/contact_sheet.png)、[完整提示词](previews/Shop_Offers_v01/prompts.json)、生成底稿、尺寸整理脚本及[离线验证](previews/Shop_Offers_v01/verification.json)位于同一预览目录。总览浅奶油底仅用于审图，单张PNG为真实透明背景。

	- B4 Windows／Pillow离线检查两张尺寸、RGBA、非空内容、透明通道0至255和四角透明通过，人工查看原图与原尺寸总览。商店两张正式图片及meta、Panel_Shop.prefab、ShopConfig.asset哈希未变；未接入Unity，未进行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。美术候选待用户确认。

	- B5 2026-10-28用户确认美术并授权替换，两张确认PNG已原样安装至Assets/Res_Runtime/UI/Shop/new。两份meta／GUID、单Sprite导入和Prefab引用保持；旧图及meta备份于Logs/ShopOfferInstall/before。安装检查确认两图与候选哈希一致，70份受保护文件不变。本批仅文件验证，未执行Unity实际导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。B4保留为候选阶段历史记录。


- A20 棋盘12种烘焙图案与新区域配色（候选待确认，未安装）
	- B1 2026-10-28用户确认12种烘焙图案与12色方案并授权制作。按原pattern_0至pattern_11索引依次制作吐司、牛角包、椒盐卷饼、纸杯蛋糕、甜甜圈、烤箱手套、擀面杖、厨师帽、打蛋器、牛奶瓶、饼干骨头、果酱罐；原作资源证据与现有正式文件映射见[素材清单](assets/UI/Game/Patterns/v01/manifest.json)。

	- B2 使用内置image_gen逐张生成白色透明底剪影，按对应正式PNG画布等比缩放居中，不重绘轮廓。打蛋器由斜向版本重生成为竖向粗线条版本，首稿保留。12色按用户确认方案记录在素材清单中，颜色是区域底色，不烘焙进图案PNG。

	- B3 [图案与颜色总览](previews/Game_Patterns_v01/contact_sheet.png)、[配色总览](previews/Game_Patterns_v01/palette.png)、[棋盘搭配预览](previews/Game_Patterns_v01/board_preview.png)、[完整提示词](previews/Game_Patterns_v01/prompts.json)、生成底稿、整理脚本与[离线验证](previews/Game_Patterns_v01/verification.json)均已保存。棋盘为离线排布示意，不代表可解关卡或Unity截图；左侧复现现有0.65倍区域色与26%透明度，右侧及总览采用较深染色便于审图。

	- B4 Windows／Pillow离线检查12张PNG原画布尺寸、RGBA、非空内容、alpha范围0至255及四角透明通过；人工查看完整总览与棋盘示意，打蛋器调整后复查。正式12张图案及meta和PuzzlePresentation.asset共25份文件SHA256未变。未修改正式资源、SO、脚本、Prefab、Addressables或存档，未执行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。待用户确认美术后接入；现有运行展示配置只有前10种绑定，12种完整覆盖在接入时核对，不能将素材齐全写成运行覆盖完成。

	- B5 2026-10-28用户明确要求“接入”，12张PNG已安装到Assets/Res_Runtime/UI/Game，保留12份meta／GUID与原尺寸；PuzzlePresentation.asset更新为12色及12张图案绑定，tutorialColors及其他字段保持。原图／配置备份与检查见Logs/PatternInstall。UI Library现提供12组独立原作／新图案及配色对比；制作阶段总览中的“候选／未接入”文字保留历史，当前安装状态以本条与素材清单为准。Unity验证结果见MigrationAcceptance A22。

	- B6 本批隔离Unity6000.5.2f1导入、编译、正式Scene_Main Play Mode及256项断言通过；教程独立色／无图案保持，主线新配色、图案开关、重复打开及12图案组件绑定通过；人工查看1080×1920后台渲染。25份正式图案／meta／展示SO与验证副本一致，运行脚本一致；并行6份编辑器导入工具不在快照验证范围。未打包、构建、安装或真机验收，详见MigrationAcceptance A22。

- A21 通关大图首张修订（候选待确认，未安装）
	- B1 2026-10-28用户反馈首轮红绶带与金星不贴合小狗画风，并要求前爪改为狗爪；授权先修一张举爪庆祝，确认后再统一其余图。原8张计划中的clear_c骨头饼干、clear_f珊瑚粉蝴蝶结面包花束方案保留。

	- B2 使用内置image_gen，以首轮clear及已确认头像为参考，生成短圆犬前爪、四趾垫与掌垫、小号星形烤饼干、柔软雾灰蓝布带，并减淡描边。[修订PNG](assets/UI/GameResult/v02/clear.png)为990×951；等比适配透明画布，不拉伸。红绶带[初稿](previews/GameResult_v01/raw/clear.png)另存保留。

	- B3 [完整提示词](previews/GameResult_v02/prompts.json)、生成底稿和[离线检查](previews/GameResult_v02/verification.json)保存在预览目录。Windows离线检查尺寸、RGBA及alpha范围0至255通过；alpha边界含极低透明度像素，未手工抹除生成边缘。已人工查看生成结果，当前仅本张修订候选，未确认全套定稿。

	- B4 本批未替换正式资源、脚本、Prefab、SO或存档，未执行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。


- A22 第一版八张结果页大图（已选择、已安装）
	- B1 2026-10-28用户决定使用第一版，并授权整理原尺寸和Unity接入。clear／clear_a—clear_f保留第一版金色星星与珊瑚粉绶带，fail保留碎裂紫星与蓝绶带；clear_c为骨头饼干，clear_f为系珊瑚粉蝴蝶结的面包花束。A21蓝布带修订仅保留备选，不作为正式版本。

	- B2 [八张图片清单](assets/UI/GameResult/v01/manifest.json)记录尺寸、GUID、生成来源及哈希。底稿和[完整提示词](previews/GameResult_v01/prompts.json)保留；按原图alpha边界裁掉外围透明边距，等比缩放至对应原画布并留至少12像素透明边距，不拉伸。[素材总览](previews/GameResult_v01/contact_sheet.png)为奶油底审图展示，八张PNG本身为真实透明背景。

	- B3 八张PNG安装至Assets/Res_Runtime/UI/GameResult原路径，原meta／GUID、Prefab、SO、选图逻辑和存档格式保持。原图及meta备份于Logs/ResultArtInstall/before；本批不重建结果页。正式图与主题候选及独立验证副本一致，详细审计见Logs/ResultArtInstall/delivery-audit.json。

	- B4 Windows／Unity6000.5.2f1独立副本编译、Scene_Main Play Mode共3049项检查及Windows Addressables内容打包通过。七张图在1080×1920／1080×1620后台渲染、英文1080×2400安全区和失败图已检查；验证使用专用随机存档名。UnityEditor.Search索引异常单列，项目检查通过。未执行APK构建、安装、手机触摸或真机验证，用户验收未代勾。
