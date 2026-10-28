from pathlib import Path
import re,json
ROOT=Path('D:/UnityProject/Hamdoku2');WORK=Path(__file__).resolve().parent
verification=json.loads((WORK/'verification.json').read_text(encoding='utf-8'))
assert verification['allAssetChecksPassed']
assert verification['productionInputsChanged']==[] and verification['productionFilesAdded']==[]
def append(path,text):
    with path.open('a',encoding='utf-8') as f:f.write('\n\n'+text.rstrip()+'\n')
style=ROOT/'Docs/UILibrary/themes/PuppyBakery/STYLE.md'
n=max(map(int,re.findall(r'^- A(\d+) ',style.read_text(encoding='utf-8'),re.M)))+1
append(style,f'''- A{n} 商店页首批切图（未替换）
\t- B1 2026-10-28用户确认[无顶部垂边的商店稿](assets/UI/Shop/Panel_Shop_Style_v02_1080x1920.png)，授权只读核对原项目并开始切图。范围为移除广告、放大镜、提示三个商品区；礼包、限时优惠、会员及其状态不在本稿范围。

\t- B2 核对原项目04_assets/Sprite的商店图片、ShopPopupLayout静态配置、ShopPopup的动态构建方法及当前Panel_Shop.prefab。原目录保持只读。恢复方法均带诊断，仅作为图片／文本拆分和动态组装的结构证据，不作为原作运行验收。

\t- B3 [19张PNG清单](assets/UI/Shop/manifest.json)含11张与当前商店正式图片同名同尺寸的候选，以及8张配套背景、分组面板、标签、金色价格底图、无角色小放大镜和标签图标。关闭按钮沿用当前裁边后的249×256，而原导出画布为256×256。新增素材尚未绑定，不覆盖Game共用背景。

\t- B4 招牌、分组标签、商品卡和价格按钮均不烘焙文案或数值；ADS保留为图标符号。无字整页、背景与空分组面板由内置image_gen补绘，其他图层裁切及透明处理，不宣称全部来自无损裁切。生成描述、底稿、来源证据与脚本保存在previews/Shop_Slicing/。

\t- B5 [素材总览](previews/Shop_Slicing/contact_sheet_v01.png)、[离线拼合](previews/Shop_Slicing/page_layers_reassembled_1080x1920.png)、布局参考及[检查结果](previews/Shop_Slicing/verification.json)用于审图。离线九宫格将商品卡与按钮边距按0.35显示，正式接入仍需校准PPU倍率、布局和颜色；现有粉色图标染色不能直接沿用。拼合使用Windows字体，不是Unity运行截图。

\t- B6 Windows／Python／Pillow／NumPy检查19张尺寸、RGBA、非空、透明角、九宫格合法性和哈希通过，核对本任务商店正式图片／meta、Prefab、配置及相关脚本未变。首轮发现关闭按钮缺叉及面板采样残影，均在交付前修复。当前仅素材准备，未进行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。''')
acceptance=ROOT/'Docs/MigrationAcceptance.md'
n=max(map(int,re.findall(r'^- A(\d+) ',acceptance.read_text(encoding='utf-8'),re.M)))+1
append(acceptance,f'''- A{n} 2026-10-28：商店页小狗面包房切图审查（尚未安装）
\t- B1 本批范围与入口
\t\t- C1 仅交付已确认商店稿的19张拆分PNG及清单，覆盖移除广告、放大镜、提示三个商品区；不含礼包、限时优惠和会员。素材位于[商店素材目录](UILibrary/themes/PuppyBakery/assets/UI/Shop/manifest.json)。

\t\t- C2 先打开[素材总览](UILibrary/themes/PuppyBakery/previews/Shop_Slicing/contact_sheet_v01.png)，再打开[1080×1920离线拼合](UILibrary/themes/PuppyBakery/previews/Shop_Slicing/page_layers_reassembled_1080x1920.png)。本轮不要求进入游戏查新图，正式页面尚未替换。

\t- B2 用户审图项目
\t\t- [ ] C1 背景最上沿没有蓝白垂边；奶油色烘焙纹样、小狗形象和招牌可用于后续接入。

\t\t- [ ] C2 总览中图标外侧与圆角透明，关闭按钮叉号完整；无字底图没有残留价格、数量、期限或商品图标。

\t\t- [ ] C3 离线拼合的三个商品区、9张卡片和工具图标可用于后续Unity布局校准；文案与价格继续独立显示。

\t- B3 兼容与已知限制
\t\t- C1 正式PNG、meta、Prefab、SO、脚本和存档均未修改，旧进度不受本批影响。不要将本目录PNG及meta整批复制到正式目录。

\t\t- C2 无字整页、背景与空面板有生成补绘；离线拼合并非无损还原或Unity截图。新增图层待正式绑定，商品卡／按钮需校准九宫格PPU倍率，日历／无限图标需去掉现有粉色染色。

\t- B4 开发验证与用户结论
\t\t- C1 Windows离线文件检查19张尺寸、RGBA、透明角、九宫格合法性及哈希通过；11张同名候选与当前工程图片尺寸相同。商店正式资源和相关实现前后哈希无变化。关闭按钮保持当前249×256裁边画布，与原导出256×256区别已记录。

\t\t- C2 未执行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。当前状态为待用户审图，以上复选框保持未勾选；后续问题与复验结果追加于本批。''')
append(ROOT/'WORK_LOG.md','''## 2026-10-28 商店页原作核对与19张素材切图（未安装）

- 按用户授权核对原项目商店Sprite、ShopPopupLayout配置、恢复ShopPopup构建方法及当前正式Panel_Shop.prefab和图片导入参数。原项目保持只读，恢复代码含诊断，仅用于定位动态UI与图片／文本职责，不作为运行事实。
- 使用内置image_gen补绘无字整页、无顶部垂边背景及空分组面板，再用Pillow／NumPy按确认稿裁切、透明隔离和组装。19张PNG位于Docs/UILibrary/themes/PuppyBakery/assets/UI/Shop/，11张保留当前商店正式图片名称及尺寸，8张为背景、面板、标签及小图标配套。商店标题、描述、期限、数量与价格均保持独立文字；ADS作为符号保留。礼包、限时优惠、会员及9张未覆盖正式图不在本稿切图范围。
- 清单记录原始来源、实际尺寸、透明边界、九宫格及哈希。关闭按钮沿用当前249×256，区别于原导出256×256。正式布局不同于确认稿；新增图层需绑定，原日历／无限粉色染色需校准，商品卡及按钮离线边距显示比例0.35，正式PPU倍率待Unity校准。未修改正式图片、meta、Prefab、场景、SO、脚本或存档。
- 生成提示词、原图、切图脚本、原始尺寸清单、方法证据、19图总览、1080×1920离线拼合和verification.json位于previews/Shop_Slicing/。Windows离线尺寸、RGBA、非空、透明角、边距及哈希检查通过，商店正式资源和相关实现前后哈希无变化。素材与拼合均人工查看；STYLE.md补充入口，Docs/MigrationAcceptance.md追加本批审图步骤，用户验收未勾选。
- 首次脚本缺SciPy，改用已有Pillow／NumPy；本机阶段性内存不足后重试成功。首次图像检查修复关闭按钮缺叉、面板边缘商品残影和九宫格色带过高问题；一次验证误在切图尚未结束时读取，报PNG截断，待切图完成后重新全量读取检查通过，未放宽损坏文件校验。未执行Unity导入验收、编译、Play Mode、内容打包、应用构建、安装或真机验证。''')
print('Recorded delivery; asset checks passed; production unchanged.')
