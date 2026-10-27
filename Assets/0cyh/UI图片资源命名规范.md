# 图片与音频资源命名规范

## 1. 目的与适用范围

- 本规范于 2026-10-13 经用户确认，用于 Spin 项目后续新增、迁移及整理的 UI 图片、背景音乐与音效资源。
- 图片适用于按钮图片、图标、装饰、特效贴图、页面及区域背景，以及配套的独立 Sprite `.asset`；音频适用于背景音乐及音效文件。
- 本规范约束资源文件名，不要求同步修改 Prefab 节点、脚本字段或业务类型名。第 3～8 节为图片规则，第 9 节为音频规则。
- 为保留已有文档引用，沿用原文件名 `04_UI图片资源命名规范.md`，图片与音频规则统一维护在本文。
- 旧资源在对应任务涉及新增或整理时采用本规范，不因规范发布自动批量改名。

## 2. 统一格式

```text
<类型>_<功能>_<用途>[_<状态或变体>]
```

- 图片类型固定为 `btn`、`Img`、`bg`，音频类型固定为 `Bgm`、`SFV`，保留上述大小写。
- 功能、用途和文字后缀采用英文 PascalCase，例如 `MainSpin`、`RewardSum`、`Disabled`。
- 各段用单个下划线分隔；方括号表示可选部分，不写入实际文件名。
- 不以下划线开头，不含空格、中文、随机字符串或原始 atlas 编号，不重复携带 `Img`、`Bg` 等类型词。
- 使用含义明确的英文词，避免 `Image1`、`New`、`Copy`、`Final` 等无法表达用途的名称。

## 3. 类型选择

按图片自身用途分类，不仅根据其所在节点是否属于按钮判断。

| 前缀 | 用途 | 示例 |
| --- | --- | --- |
| `btn_` | 按钮表面或按钮底图 | `btn_MainSpin_Spin.png` |
| `Img_` | 图标、装饰、特效图片 | `Img_MainSpin_EdgeLight.png` |
| `bg_` | 页面或区域底图 | `bg_FreeGame_RewardSum.png` |

例如：金币按钮的表面使用 `btn_Common_Coin`，按钮内部独立的金币图标使用 `Img_Common_Coin`。

## 4. 功能与用途

功能段表示图片的业务归属。同一功能保持同一名称，避免交替使用 `Free`、`FreeSpin`、`FreeGame`。

| 功能段 | 归属 |
| --- | --- |
| `MainSpin` | 普通转盘主面板 |
| `FreeGame` | 免费转盘及其开始、奖励等页面 |
| `Wheel` | Wheel 小游戏 |
| `PickGame` | 选箱小游戏 |
| `Common` | 多个功能共同使用的通用资源 |

其他功能沿用项目已明确的业务名称。资源即使暂时存放在某个 Panel 目录中，功能段也按实际归属填写。

用途段描述图片表达的内容或承担的作用，例如 `Spin`、`PlayAd`、`Coin`、`Multiplier`、`RewardSum`、`EdgeLight`。用途包含多个单词时合并为 PascalCase。

## 5. 共用图片命名与复用

### 5.1 判断归属

| 使用范围 | 功能段 | 示例 |
| --- | --- | --- |
| 仅普通转盘主面板使用 | `MainSpin` | `Img_MainSpin_EdgeLight` |
| FreeGame 开始页、奖励页共同使用 | `FreeGame` | `Img_FreeGame_Flame` |
| 多个不同功能共同使用 | `Common` | `Img_Common_Coin` |
| 已明确作为通用素材制作，暂时只有一个调用方 | `Common` | `bg_Common_Popup` |

同一功能内被多个页面引用，仍属于该功能。多个不同功能共用同一素材，或已明确作为公共素材制作时，使用 `Common`。不能仅因图片看起来可能复用，就将全部图片归为 `Common`。

### 5.2 命名方式

共用图片沿用统一格式：`<类型>_Common_<用途>[_<状态或变体>]`。

- 用途描述素材本身的内容或形状，不携带某个调用页面的名称，不拼接所有使用方名称。
- 无文字、无业务图案的通用按钮底图按外观命名，如 `btn_Common_Rounded_Green`；只有素材自身包含领取文字或图案时，才使用 `btn_Common_Claim_Green` 等业务用途名。
- 共用金币、广告、关闭图标分别命名为 `Img_Common_Coin`、`Img_Common_Ad`、`Img_Common_Close`。
- 弹窗底图、分隔线等按实际角色命名，如 `bg_Common_Popup`、`Img_Common_Divider`。
- 不同外观使用明确变体区分，如 `Img_Common_Coin_Gold`、`Img_Common_Coin_Silver`；同一图片被不同页面缩放、染色或旋转使用时，保持同一资源名。
- 同一图片同时用于按钮表面和区域底图时，按其公共素材定位选择一个前缀；通用区域底图可使用 `bg_Common_Rounded`。调用节点是 Button 不要求另复制一份 `btn_` 图片。

### 5.3 复用与专用转公共

- 新增图片前先查找已有公共资源；满足用途、外观和导入配置要求时，各调用方引用同一资源。
- 同一公共资源保持一份权威文件及其配套 Sprite，不为不同页面复制同图再分别命名。
- 专用图片经确认转为跨功能共用时，将功能段改为 `Common`，保留原 `.meta` GUID，并检查所有调用方；不把原页面名称继续留在用途段中。
- 若两个调用方确实需要不同的图片内容、Sprite 裁切、边框或导入配置，可按差异拆分资源并命名；不能只按文件像素相同就合并。
- 目录优先沿用项目已有公共资源位置。命名规范本身不授权移动资源、合并重复文件或调整 Addressables；具体任务授权整理时，再检查路径加载、Addressables 地址和引用后处理。

## 6. 状态、变体与序列

- 默认状态省略后缀；按下、选中、禁用统一使用 `Pressed`、`Selected`、`Disabled`。
- 外观变体优先使用有意义的名称，如 `Left`、`Right`、`Gold`、`Green`。
- 只有序列帧等确实存在顺序关系的资源使用数字后缀，从 `01` 开始、位数一致；超过 99 帧时统一使用三位数。
- 同时需要区分变体与状态时，顺序为 `<类型>_<功能>_<用途>_<变体>_<状态>`；序列编号放在最后。
- 不为没有实际差异的资源添加后缀，不用无意义编号代替用途描述。

```text
btn_MainSpin_Spin.png
btn_MainSpin_Spin_Pressed.png
btn_MainSpin_Spin_Disabled.png
Img_Wheel_Steam_Left.png
btn_Common_Claim_Gold_Disabled.png
Img_FreeGame_Flame_01.png
Img_FreeGame_Flame_02.png
```

## 7. 配套资源与重命名要求

- 同一图片的 PNG 与配套独立 Sprite `.asset` 使用相同基础名，扩展名保持原类型。
- 独立 Sprite `.asset` 的主对象 `m_Name` 与文件基础名一致。
- 每个资源保留自身原有 `.meta` 和 GUID；PNG 与 Sprite `.asset` 的 GUID 不应互相替换。
- 优先在 Unity Project 窗口重命名；通过文件工具改名时，资源及对应 `.meta` 必须成对移动。
- 改名前检查 GUID 引用及按路径、资源名加载的调用点；涉及路径或名称字符串的引用同步更新。
- 改名后检查文件重名、GUID 关联、Sprite 到贴图的引用及外部引用；Unity 重新导入后的显示验证单独记录，未实际验证不得写为通过。

配套示例：

```text
btn_MainSpin_Spin.png
btn_MainSpin_Spin.png.meta
btn_MainSpin_Spin.asset
btn_MainSpin_Spin.asset.meta
```

## 8. 现有命名转换示例

以下用于说明规范，不表示这些资源已再次重命名。

| 原基础名 | 规范基础名 |
| --- | --- |
| btn_PlayAd | btn_FreeGame_PlayAd |
| Img_FreeWow | Img_FreeGame_Wow |
| Img_WheelBall | Img_Wheel_Ball |
| bg_FreeRewardSum | bg_FreeGame_RewardSum |

后续整理时先确定功能与用途，再套用第 2 节格式；共用资源按第 5 节判断归属，引用维护按第 7 节执行。

## 9. 音频命名规则

### 9.1 类型与格式

音频沿用统一格式：`<类型>_<功能>_<用途>[_<状态或变体>][_<序号>]`，保留原音频扩展名，不因重命名转换格式。

| 前缀 | 用途 | 示例 |
| --- | --- | --- |
| `Bgm_` | 背景音乐 | `Bgm_MainSpin_Main.wav`、`Bgm_FreeGame_Main.wav` |
| `SFV_` | 音效 | `SFV_MainSpin_ReelStop.wav`、`SFV_Common_ButtonClick.wav` |

功能、用途和文字后缀使用英文 PascalCase，各段以单个下划线分隔。去掉随机前后缀、哈希和导出 PathID；不使用空格、中文或无意义长数字。

### 9.2 功能、用途与共用

- 功能段沿用图片规则中的业务名称，例如 `MainSpin`、`FreeGame`、`Wheel`、`PickGame`、`Gashapon`、`LuckZone`、`Stamp`、`PowerUp`，同一功能不混用不同缩写。
- 用途描述声音对应的动作或表现，例如 `ReelSpin`、`ReelStop`、`BoxOpen`、`RewardDouble`；背景音乐主曲目使用 `Main`。
- 同一功能内多个页面共用时保留功能名；跨功能共用或明确作为通用声音制作时使用 `Common`，例如 `SFV_Common_PopupOpen.wav`、`SFV_Common_RewardDouble.wav`。
- 共享音频不以单个调用页面命名，不拼接全部调用方名称，不因多个配置声键引用而复制资源。
- 无法核实具体用途的旧声键暂用 `Legacy`，例如 `SFV_Legacy_Co300.wav`；核实后再改为准确功能与用途，不凭文件名猜测业务。

### 9.3 状态、变体与序号

- 仅有实际差异时添加后缀。有先后顺序的同类声音使用两位编号，例如 `SFV_MainSpin_ScatterStop_01.wav`、`SFV_MainSpin_ScatterStop_02.wav`、`SFV_MainSpin_ScatterStop_03.wav`。
- 只有需要区分循环版与单次版资源时才添加 `Loop`、`OneShot` 等后缀；文件名不代替播放配置，是否循环以配置为准。
- 相同文件被不同音量、速度或循环参数播放时，保持同一资源名，不仅为播放参数复制文件。

### 9.4 重命名与引用维护

- 资源与对应 `.meta` 成对改名，保留原 GUID；优先在 Unity Project 窗口操作。
- 改名前检查 AudioSO、其他 SO、Prefab、动画、路径或名称加载、Addressables 地址及编辑器校验器中的相关引用；依赖名称或路径的部分同步维护。
- 不因重命名调整音量、循环设置或业务触发，不因配置音量为 0 就删除资源。
- 内容哈希相同只证明文件内容相同，不自动授权合并或删除；后续整理重复资源时先确认保留文件及引用迁移方案。
- 改名后检查文件重名、GUID、配置和外部引用；Unity 重新导入后试听相关玩法与界面。未试听的部分单独标明，不以静态检查代替播放验收。

### 9.5 当前项目清单

完整音频盘点及逐文件新旧名称对照见 [音频资源清单与重命名建议](../01cyh/04_音频资源清单与重命名建议.md)。该清单记录 2026-10-13 的资源快照；长期命名规则以本文为准。具体文件用途尚待核实的建议仍需核实后实施。
