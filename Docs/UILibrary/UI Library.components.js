'use strict';

// Component examples live only in this document; production Unity state stays separate.
const componentConfig = cfg.components;
const originalsByName = new Map();
for (const asset of catalog.assets) {
  if (asset.type === 'Sprite' && !originalsByName.has(asset.name)) {
    originalsByName.set(asset.name, asset);
  }
}
function original(name) {
  const asset = originalsByName.get(name);
  if (!asset) {
    throw new Error('Original sprite not found: ' + name);
  }
  return asset;
}
function picture(name, className = '', alt = '') {
  const image = document.createElement('img');
  image.src = original(name).file;
  image.className = className;
  image.alt = alt;
  return image;
}
function element(tag, className = '', text = '') {
  const node = document.createElement(tag);
  node.className = className;
  node.textContent = text;
  return node;
}
function sectionBefore(id, number, title, intro, before) {
  const section = element('section');
  section.id = id;
  const heading = element('div', 'section-title');
  heading.append(element('span', '', number), element('h2', '', title), element('p', '', intro));
  section.append(heading);
  $(before).before(section);
  return section;
}
const skinResize = new ResizeObserver(entries => {
  for (const entry of entries) {
    alignSkin(entry.target);
  }
});
const textCanvas = document.createElement('canvas');
const textContext = textCanvas.getContext('2d');
function sourceToTarget(value, sourceSize, start, end, targetSize, renderedBorder) {
  if (value < start) {
    return value * renderedBorder / start;
  }
  if (value > sourceSize - end) {
    return targetSize - (sourceSize - value) * renderedBorder / end;
  }
  return renderedBorder + (value - start) * (targetSize - 2 * renderedBorder) / (sourceSize - start - end);
}
function alignSkin(button) {
  if (!button.isConnected || button.offsetWidth === 0) {
    return;
  }
  const variant = componentConfig.buttons[button.dataset.skin];
  const asset = byKey.get(variant.asset);
  const label = button.querySelector('.button-label');
  const style = getComputedStyle(label);
  textContext.font = `${style.fontWeight} ${style.fontSize} ${style.fontFamily}`;
  const metrics = textContext.measureText(label.textContent);
  const [left, top, right, bottom] = asset.exportBorderLTRB;
  const bounds = variant.faceBounds;
  const centerX = sourceToTarget((bounds[0] + bounds[2]) / 2, asset.size[0], left, right, button.clientWidth, variant.borderWidth);
  const centerY = sourceToTarget((bounds[1] + bounds[3]) / 2, asset.size[1], top, bottom, button.clientHeight, variant.borderWidth);
  const emHeight = metrics.fontBoundingBoxAscent + metrics.fontBoundingBoxDescent;
  const baseline = (label.offsetHeight - emHeight) / 2 + metrics.fontBoundingBoxAscent;
  const glyphCenterY = baseline + (metrics.actualBoundingBoxDescent - metrics.actualBoundingBoxAscent) / 2;
  const glyphCenterX = (metrics.actualBoundingBoxRight - metrics.actualBoundingBoxLeft) / 2;
  label.style.left = `${centerX - glyphCenterX}px`;
  label.style.top = `${centerY - glyphCenterY}px`;
  button.dataset.faceY = centerY.toFixed(3);
  button.dataset.inkY = (parseFloat(label.style.top) + glyphCenterY).toFixed(3);
  button.dataset.labelWidth = metrics.width.toFixed(3);
}
function skinButton(text, skin = 'orange', compact = false, action) {
  const button = element('button', 'skin-button game-font' + (compact ? ' compact' : ''));
  button.dataset.skin = skin;
  const asset = byKey.get(componentConfig.buttons[skin].asset);
  const variant = componentConfig.buttons[skin];
  const size = componentConfig.buttonSizes[compact ? 'compact' : 'standard'];
  const [l, t, r, b] = asset.exportBorderLTRB;
  button.style.setProperty('--skin-url', `url("${asset.file}")`);
  button.style.setProperty('--skin-slice', `${t} ${r} ${b} ${l} fill`);
  button.style.setProperty('--skin-border', variant.borderWidth + 'px');
  button.style.setProperty('--skin-height', size.height + 'px');
  button.style.setProperty('--skin-pad', size.paddingX + 'px');
  button.style.setProperty('--skin-font', size.fontSize + 'px');
  button.style.color = variant.textColor;
  const label = element('span', 'button-label', text);
  button.append(label);
  if (action) {
    button.addEventListener('click', action);
  }
  skinResize.observe(button);
  document.fonts.ready.then(() => {
    textContext.font = `${size.fontSize}px HamdokuChinese`;
    button.style.minWidth = Math.max(size.height, textContext.measureText(text).width + 2 * size.paddingX) + 'px';
    alignSkin(button);
  });
  return button;
}
function iconControl(name, label, action) {
  const button = element('button', 'original-icon');
  button.setAttribute('aria-label', label);
  button.append(picture(name));
  if (action) {
    button.addEventListener('click', action);
  }
  return button;
}
function makeTabSet(names, onChange, label) {
  const root = element('div', 'component-tabs');
  root.setAttribute('role', 'tablist');
  root.setAttribute('aria-label', label);
  names.forEach((name, index) => {
    const tab = element('button', '', name);
    tab.setAttribute('role', 'tab');
    tab.setAttribute('aria-selected', index === 0);
    tab.tabIndex = index === 0 ? 0 : -1;
    function select() {
      Array.from(root.children).forEach(sibling => {
        sibling.setAttribute('aria-selected', sibling === tab);
        sibling.tabIndex = sibling === tab ? 0 : -1;
      });
      onChange(index);
    }
    tab.addEventListener('click', select);
    tab.addEventListener('keydown', event => {
      const next = event.key === 'ArrowRight' ? (index + 1) % names.length : event.key === 'ArrowLeft' ? (index + names.length - 1) % names.length : event.key === 'Home' ? 0 : event.key === 'End' ? names.length - 1 : -1;
      if (next >= 0) {
        event.preventDefault();
        root.children[next].focus();
        root.children[next].click();
      }
    });
    root.append(tab);
  });
  return root;
}

const standards = sectionBefore('button-standards', '03B / BUTTON SPECIFICATIONS', '按钮规格与视觉居中', '使用原作底图与实际 Sprite 切片。可见按钮面与字形分别测量；规格为本库提炼值，最终仍需原应用光学校准。', '#home');
const buttonSpec = element('div', 'spec');
const buttonMatrix = element('div', 'button-matrix');
for (const [skin, name] of [['orange','主要操作'], ['blue','辅助操作'], ['yellow','高亮操作'], ['pink','商店操作'], ['cream','轻量操作']]) {
  const group = element('article', 'button-spec-cell');
  group.append(element('h3', '', name));
  const regular = skinButton('继续', skin, false, () => toast(name + '：点击反馈'));
  const small = skinButton('确认', skin, true, () => toast('紧凑按钮反馈'));
  const disabled = skinButton('不可操作', skin, true);
  disabled.disabled = true;
  group.append(regular, small, disabled);
  buttonMatrix.append(group);
}
buttonSpec.append(buttonMatrix);
const dynamicInput = element('input');
dynamicInput.id = 'button-copy';
dynamicInput.value = '领取每日奖励';
dynamicInput.maxLength = 12;
dynamicInput.setAttribute('aria-label', '按钮动态文案');
const dynamicButton = skinButton(dynamicInput.value, 'orange');
dynamicButton.id = 'alignment-button';
dynamicInput.addEventListener('input', () => {
  const label = dynamicButton.querySelector('.button-label');
  label.textContent = dynamicInput.value || ' ';
  textContext.font = `${componentConfig.buttonSizes.standard.fontSize}px HamdokuChinese`;
  dynamicButton.style.minWidth = Math.max(54, textContext.measureText(label.textContent).width + 48) + 'px';
  alignSkin(dynamicButton);
});
const debug = element('label', 'row', '显示按钮面中心线');
const debugInput = document.createElement('input');
debugInput.type = 'checkbox';
debugInput.id = 'alignment-guide';
debugInput.addEventListener('change', () => buttonSpec.classList.toggle('show-center', debugInput.checked));
debug.append(debugInput);
const busySkin = skinButton('加载示例', 'yellow', false, () => {
  busySkin.disabled = true;
  busySkin.setAttribute('aria-busy', 'true');
  busySkin.querySelector('.button-label').textContent = '加载中…';
  alignSkin(busySkin);
  setTimeout(() => {
    busySkin.disabled = false;
    busySkin.removeAttribute('aria-busy');
    busySkin.querySelector('.button-label').textContent = '加载示例';
    alignSkin(busySkin);
  }, cfg.timing.busy);
});
buttonSpec.append(element('h3', '', '动态文案 / 标准与紧凑 / 忙碌'), dynamicInput, element('div', 'row wrap'));
buttonSpec.lastChild.append(dynamicButton, busySkin);
buttonSpec.append(debug, element('p', '', '标准：字号19、上下12/左右24、最小高54；紧凑：字号15、上下8/左右16、最小高44。悬停、按下、聚焦、禁用、忙碌分别表达；同一区域突出一个主要操作。'));
standards.append(buttonSpec);
const typeScale = element('div', 'spec type-scale');
for (const type of componentConfig.typeScale) {
  const line = element('p', 'game-font', `${type.name}　Hamdoku 仓鼠 128`);
  line.style.fontSize = type.size + 'px';
  line.style.fontWeight = type.weight;
  line.style.lineHeight = type.line;
  typeScale.append(line, element('small', '', `${type.size}px / ${type.weight} / 行高 ${type.line}`));
}
standards.append(typeScale);

const geometry = sectionBefore('slice-spacing', '03C / NINE-SLICE & SPACING', '九宫格与可调间距', '原始 m_Border 使用左/下/右/上；导出 PNG 已发生裁切时，按 textureRectOffset 换算到导出图坐标。零切片图片仍按比例展示。', '#home');
const sliceSpec = element('div', 'spec');
const sliceControls = element('div', 'row wrap');
const widthInput = document.createElement('input');
widthInput.type = 'range';
widthInput.min = '160';
widthInput.max = '360';
widthInput.value = '260';
widthInput.id = 'slice-width';
widthInput.setAttribute('aria-label', '九宫格宽度');
const sizeReadout = element('output', '', '260px');
const stretch = skinButton('继续游戏', 'orange');
stretch.id = 'slice-demo';
stretch.style.width = '260px';
widthInput.addEventListener('input', () => {
  stretch.style.width = widthInput.value + 'px';
  sizeReadout.textContent = widthInput.value + 'px';
});
sliceControls.append(element('label', '', '拉伸宽度'), widthInput, sizeReadout);
const borderInfo = byKey.get(componentConfig.buttons.orange.asset);
sliceSpec.append(sliceControls, stretch, element('pre', '', JSON.stringify({spriteBorder: borderInfo.spriteBorder, exportBorderLTRB: borderInfo.exportBorderLTRB, spriteRect: borderInfo.spriteRect, exportedPNG: borderInfo.size}, null, 2)));
const panelDemo = element('div', 'nine-panel game-font', '原作 PopupPanel：九宫格面板');
const panelAsset = original('PopupPanel');
panelDemo.style.borderImageSource = `url("${panelAsset.file}")`;
panelDemo.style.borderImageSlice = '28 fill';
sliceSpec.append(panelDemo);
geometry.append(sliceSpec);
const spacingSpec = element('div', 'spec');
const spaceInput = document.createElement('input');
spaceInput.type = 'range';
spaceInput.id = 'item-spacing';
spaceInput.min = componentConfig.spacing.min;
spaceInput.max = componentConfig.spacing.max;
spaceInput.value = componentConfig.spacing.initial;
spaceInput.setAttribute('aria-label', 'Item 四向内边距');
const spaceOutput = element('output');
const spaceItem = element('div', 'spacing-item');
spaceItem.append(picture('icon_daily'), element('span', '', '每日挑战'), element('span', 'count-badge', '3'));
function updateSpace() {
  spaceItem.style.padding = spaceInput.value + 'px';
  spaceItem.style.gap = spaceInput.value + 'px';
  spaceOutput.textContent = `上 / 右 / 下 / 左 = ${spaceInput.value}px；图标与文字间距 = ${spaceInput.value}px`;
}
spaceInput.addEventListener('input', updateSpace);
updateSpace();
spacingSpec.append(element('h3', '', 'Item 内距与内容间距'), spaceOutput, spaceInput, spaceItem);
geometry.append(spacingSpec);

const patternsSection = sectionBefore('tabs-lists', '03D / TABS & ITEMS', '标签页、列表与辅助状态', '同类 Item 使用同一结构表达差异。这里的数量和领取流程为组件演示，不写入游戏进度。', '#home');
const listSpec = element('div', 'spec');
const listBody = element('div', 'component-list');
listBody.id = 'example-list';
listBody.setAttribute('role', 'tabpanel');
const listStatuses = Array.from({length:6}, (_, index) => index % 3);
function renderExampleList(type) {
  listBody.replaceChildren();
  const count = Number($('#item-count').value);
  for (let index = 0; index < count; index++) {
    const status = listStatuses[index];
    const row = element('div', 'reusable-item');
    row.append(picture(type === 0 ? 'icon_daily' : 'StreakGift'), element('div', '', (type === 0 ? '挑战记录 ' : '连胜奖励 ') + (index + 1)));
    const action = skinButton(['查看','领取','已领取'][status], status === 1 ? 'yellow' : 'blue', true, () => {
      if (status === 1) {
        listStatuses[index] = 2;
        renderExampleList(type);
      } else {
        toast('记录详情：组件演示');
      }
    });
    action.disabled = status === 2;
    row.append(action);
    listBody.append(row);
  }
  if (count === 0) {
    listBody.append(element('p', 'empty-state', '暂无内容，完成一次挑战后再来看看。'));
  }
}
let listTab = 0;
const countSelect = element('select');
countSelect.id = 'item-count';
countSelect.setAttribute('aria-label', 'Item 数量');
for (const count of [0,1,2,6]) {
  const option = element('option', '', count + ' 项');
  option.value = count;
  option.selected = count === 2;
  countSelect.append(option);
}
countSelect.addEventListener('change', () => renderExampleList(listTab));
const listTabs = makeTabSet(['挑战记录','连胜奖励'], index => {
  listTab = index;
  renderExampleList(index);
}, '列表演示标签');
listTabs.id = 'example-tabs';
Array.from(listTabs.children).forEach((tab, index) => {
  tab.id = 'example-tab-' + index;
  tab.setAttribute('aria-controls', listBody.id);
});
listTabs.addEventListener('click', () => {
  listBody.setAttribute('aria-labelledby', listTabs.querySelector('[aria-selected=true]').id);
});
listBody.setAttribute('aria-labelledby', 'example-tab-0');
listSpec.append(listTabs, countSelect, listBody);
patternsSection.append(listSpec);
renderExampleList(0);
const supporting = element('div', 'spec');
supporting.append(element('h3', '', '徽标、骨架、只读字段与多行输入'));
const badges = element('div', 'row wrap');
for (const count of [0,3,99]) {
  badges.append(element('span', 'count-badge', count));
}
const skeleton = element('div', 'component-skeleton');
skeleton.setAttribute('aria-label', '正在加载内容');
skeleton.append(element('i'), element('i'), element('i'));
const textarea = element('textarea');
textarea.rows = 2;
textarea.placeholder = '两行起；补充组件示例，不发送内容。';
textarea.setAttribute('aria-label', '多行文本示例');
const readonly = element('input');
readonly.disabled = true;
readonly.value = '不可编辑字段示例';
supporting.append(badges, skeleton, textarea, readonly);
patternsSection.append(supporting);

const screenSection = sectionBefore('page-previews', '08B / HAMDOKU COMPOSITIONS', 'Hamdoku 专属组件与页面组合', '依据本次提供的 6 类画面整理。下方同时展示重构预览与对应截图；每日日历、排行榜内容布局为补充示例，截图未覆盖。', '#implementation');
const notice = element('div', 'notice', '所有开关、选择、库存和领取仅作用于本网页。截图价格为静态参考，不执行购买；静态截图不能证明手势、倒计时、奖励或服务器规则。');
const composition = element('div', 'composition-grid');
const liveColumn = element('article', 'spec composition-column');
const referenceColumn = element('article', 'spec composition-column');
const liveTitle = element('h3');
const referenceTitle = element('h3', '', '用户提供画面');
const screenRoot = element('div', 'screen-root');
screenRoot.id = 'screen-root';
screenRoot.setAttribute('role', 'tabpanel');
const screenRef = element('img', 'screen-reference');
screenRef.id = 'screen-reference';
const refNote = element('p', 'reference-note');
const comparisonStatus = element('p', 'comparison-status');
liveColumn.append(liveTitle, comparisonStatus, screenRoot);
referenceColumn.append(referenceTitle, refNote, screenRef);
composition.append(liveColumn, referenceColumn);
const screenNames = ['首页','棋盘','设置','商店','每日连胜','个人资料','每日挑战','排行榜'];
const screenKeys = ['home','gameplay','settings','shop','streak','profile','daily','ranking'];
const screenState = { patterns: true, borders: false, voice: 0, days: 1, profileTab: 0, portrait: 'hamster_idle_01', selectedFrame: 'profile_frame_0', product: null, calendarSelected: 27 };
let screenIndex = 0;
function screenToolbar(screen, title) {
  const bar = element('div', 'screen-toolbar');
  bar.append(iconControl('icon_back', '返回首页预览', () => selectScreen(0)), element('b', '', title), iconControl('icon_settings', '设置预览', () => selectScreen(2)));
  screen.append(bar);
}
function canvasScreen(className) {
  const screen = element('div', 'screen game-font ' + className);
  screen.style.backgroundImage = `url("${assetFor('background').file}")`;
  screenRoot.replaceChildren(screen);
  return screen;
}
function homeComposition() {
  const screen = canvasScreen('observed-home');
  const avatar = iconControl(screenState.portrait, '个人资料预览', () => selectScreen(5));
  avatar.classList.add('home-avatar');
  const right = element('div', 'home-right-icons');
  right.append(iconControl('icon_shop','商店预览', () => selectScreen(3)), iconControl('icon_settings','设置预览', () => selectScreen(2)));
  const cards = element('div', 'observed-home-cards');
  const daily = element('button', 'observed-daily');
  daily.append(picture('icon_daily'), element('b', '', '每日挑战'), element('strong', '', '10月27日'), element('small', '', '11:53:51'), element('span', '', '开始'));
  daily.addEventListener('click', () => selectScreen(6));
  const stack = element('div', 'observed-home-stack');
  const streak = element('button', 'observed-streak');
  streak.append(picture('IconSunflower'), element('b', '', '1天 ✓'));
  streak.addEventListener('click', () => selectScreen(4));
  const rank = element('button', 'observed-rank');
  rank.append(picture('IconPodium_0'), element('small', '', '2d 19:53'));
  rank.addEventListener('click', () => selectScreen(7));
  stack.append(streak, rank);
  cards.append(daily, stack);
  const logo = picture('Logo', 'observed-logo', 'Hamdoku');
  const play = element('button', 'observed-play', '关卡 17');
  play.style.backgroundImage = `url("${assetFor('campaign').file}")`;
  play.addEventListener('click', () => selectScreen(1));
  screen.append(avatar, right, cards, logo, play);
}
function boardComposition() {
  const screen = canvasScreen('observed-game');
  const header = element('div', 'observed-game-head');
  const titles = element('div', 'game-score', '关卡 17　　分数 576');
  header.append(iconControl('icon_back','返回首页', () => selectScreen(0)), titles, iconControl('icon_shop','商店', () => selectScreen(3)), iconControl('icon_settings','设置', () => selectScreen(2)));
  const counters = element('div', 'game-counters');
  const found = element('span', 'found-count');
  found.append(picture('hamster_idle_01'), element('b', '', '1/9'));
  const lives = element('span', 'game-seeds');
  for (let i = 0; i < 3; i++) {
    lives.append(picture('icon_life'));
  }
  counters.append(found, lives);
  const rules = element('div', 'game-rules');
  for (const [icon, text] of [['icon_rule_region','每色一只仓鼠'], ['icon_rule_line','每行每列各一只'], ['icon_rule_adjacent','仓鼠不可相邻']]) {
    const item = element('div');
    item.append(picture(icon), element('span', '', text));
    rules.append(item);
  }
  const board = element('div', 'observed-board');
  board.id = 'observed-board';
  board.classList.toggle('region-outlines', screenState.borders);
  componentConfig.observedBoard.forEach((row, rowIndex) => {
    row.forEach((region, colIndex) => {
      const cell = element('button', 'observed-cell');
      cell.dataset.state = rowIndex === 3 && colIndex === 3 ? '2' : '0';
      cell.dataset.region = region;
      cell.style.background = cfg.regionColors[region];
      cell.setAttribute('aria-label', `第${rowIndex + 1}行第${colIndex + 1}列`);
      const mask = element('span', 'region-pattern');
      mask.style.maskImage = `url("${original('pattern_' + region).dataUrl}")`;
      mask.hidden = !screenState.patterns;
      cell.append(mask);
      const occupant = picture('hamster_idle_01', 'cell-occupant');
      occupant.hidden = cell.dataset.state !== '2';
      cell.append(occupant);
      const cross = picture('x_mark', 'cell-occupant');
      cross.hidden = true;
      cell.append(cross);
      for (const [edge, dr, dc] of [['Top',-1,0], ['Bottom',1,0], ['Left',0,-1], ['Right',0,1]]) {
        const neighbor = componentConfig.observedBoard[rowIndex + dr]?.[colIndex + dc];
        if (neighbor !== region) {
          cell.style.setProperty('--edge-' + edge.toLowerCase(), '2px');
        }
      }
      cell.addEventListener('click', () => {
        const state = (Number(cell.dataset.state) + 1) % 3;
        cell.dataset.state = state;
        occupant.hidden = state !== 2;
        cross.hidden = state !== 1;
        found.querySelector('b').textContent = board.querySelectorAll('[data-state="2"]').length + '/9';
      });
      board.append(cell);
    });
  });
  const props = element('div', 'observed-props');
  for (const [name, count, label] of [['shop_magnifier',2,'放大镜'], ['shop_hint',3,'提示']]) {
    const button = element('button', 'prop-item');
    button.append(picture(name), element('span', 'count-badge', count));
    button.setAttribute('aria-label', label + ' ' + count);
    button.addEventListener('click', () => toast(label + '：仅展示反馈，不扣除数量'));
    props.append(button);
  }
  const ad = element('div', 'banner-placeholder', '底部横幅广告占位 · 不加载广告');
  screen.append(header, counters, rules, board, props, ad);
}
function settingsComposition() {
  const screen = canvasScreen('observed-settings');
  const panel = element('div', 'settings-panel');
  panel.append(element('h3', '', '设置'));
  const close = iconControl('icon_close', '关闭设置预览', () => selectScreen(1));
  close.classList.add('settings-close');
  panel.append(close);
  const rows = element('div', 'settings-group');
  for (const row of componentConfig.settings) {
    const item = element('div', 'observed-setting-row');
    const label = element('span', 'setting-row-label');
    label.append(picture(row.icon), element('b', '', row.label));
    item.append(label);
    if (row.type === 'switch') {
      const value = row.key === 'patterns' ? screenState.patterns : row.key === 'borders' ? screenState.borders : row.value;
      const toggle = element('button', 'observed-toggle');
      toggle.setAttribute('role', 'switch');
      toggle.setAttribute('aria-label', row.label);
      toggle.setAttribute('aria-checked', value);
      toggle.append(element('span', '', value ? 'ON' : 'OFF'), element('i'));
      toggle.addEventListener('click', () => {
        const checked = toggle.getAttribute('aria-checked') !== 'true';
        toggle.setAttribute('aria-checked', checked);
        toggle.querySelector('span').textContent = checked ? 'ON' : 'OFF';
        row.value = checked;
        if (row.key === 'patterns' || row.key === 'borders') {
          screenState[row.key] = checked;
        }
      });
      item.append(toggle);
    } else if (row.type === 'choice') {
      const choose = element('div', 'voice-selector');
      const value = element('span', '', ['男声','女声','关闭'][screenState.voice]);
      const prev = element('button', '', '‹');
      const next = element('button', '', '›');
      prev.setAttribute('aria-label', '上一种连击语音');
      next.setAttribute('aria-label', '下一种连击语音');
      function update(delta) {
        screenState.voice = (screenState.voice + delta + 3) % 3;
        value.textContent = ['男声','女声','关闭'][screenState.voice];
      }
      prev.addEventListener('click', () => update(-1));
      next.addEventListener('click', () => update(1));
      choose.append(prev, value, next);
      item.append(choose);
    } else {
      const button = element('button', 'language-row-link', row.value + ' ›');
      button.addEventListener('click', () => $('#language-dialog').showModal());
      item.append(button);
    }
    rows.append(item);
  }
  panel.append(rows);
  const actions = element('div', 'settings-actions');
  actions.append(skinButton('重新开始','yellow',false, () => toast('重新开始：待原作确认弹层，本预览不清除进度')), skinButton('游戏教程','blue',false, () => toast('缺少教程完整画面与操作录像')));
  const support = element('div', 'support-links');
  for (const [icon, text] of [['icon_support','客服'], ['icon_privacy','隐私政策'], ['icon_terms','服务条款']]) {
    const button = element('button');
    button.append(picture(icon), element('span', '', text));
    button.addEventListener('click', () => toast(text + '：正文与跳转待核对'));
    support.append(button);
  }
  panel.append(actions, support, element('small', 'version-label', 'v1.2.2 · 截图值'));
  screen.append(panel);
}
function shopComposition() {
  const screen = canvasScreen('observed-shop');
  const header = element('div', 'shop-header');
  header.append(picture('shop_title_banner'), element('b', '', '商店'));
  const back = iconControl('icon_close','关闭商店预览', () => selectScreen(0));
  back.classList.add('shop-close');
  const products = element('div', 'shop-products');
  for (const product of componentConfig.products) {
    const card = element('article', 'product-item' + (product.featured ? ' featured' : ''));
    card.append(element('h4', '', product.title), picture(product.image), element('p', '', product.quantity));
    const buy = skinButton(product.price, product.featured ? 'pink' : 'blue', true, () => {
      screenState.product = product;
      $('#purchase-detail').textContent = `${product.title} · ${product.price}\n截图展示价，非实时价格。本库不发起订单或发放商品。`;
      $('#purchase-dialog').showModal();
    });
    buy.setAttribute('aria-label', product.title + ' ' + product.price + ' 查看');
    card.append(buy);
    products.append(card);
  }
  screen.append(back, header, products, element('p', 'shop-disclaimer', '截图只覆盖商店上半部分；下方商品与购买结果待补。'));
}
function streakComposition() {
  const screen = canvasScreen('observed-streak-page');
  screenToolbar(screen, '每日连胜');
  const center = element('div', 'streak-center');
  center.append(picture('StreakPlant1', 'streak-plant'), element('strong', 'streak-number', screenState.days), element('b', '', '当前连胜'), element('p', 'best-streak', '最佳连胜: ' + Math.max(1, screenState.days)));
  const days = element('div', 'streak-days');
  ['周二','周三','周四','周五','周六','周日','周一'].forEach((name, index) => {
    const item = element('button', 'streak-day');
    item.setAttribute('aria-label', name + ' 连胜状态示例');
    item.append(element('span', '', name));
    if ([2,4,6].includes(index)) {
      item.append(picture(index === 6 ? 'StreakGiftBig' : 'StreakGift'));
    } else {
      item.append(element('i', index < screenState.days ? 'completed' : '', index < screenState.days ? '✓' : ''));
    }
    item.addEventListener('click', () => {
      screenState.days = index + 1;
      streakComposition();
    });
    days.append(item);
  });
  screen.append(center, days, skinButton('继续','orange',false, () => selectScreen(0)), element('p', 'screen-footnote', '点击日期可查看样例状态，不领取实际奖励。'));
}
function profileComposition() {
  const screen = canvasScreen('observed-profile');
  screenToolbar(screen, '个人资料设置');
  const club = element('div', 'profile-card');
  const avatar = element('div', 'profile-portrait');
  avatar.append(picture(screenState.portrait), picture(screenState.selectedFrame,'portrait-frame'));
  club.append(element('h3', '', '仓鼠俱乐部'), element('small', '', 'MEMBER'), avatar, element('h4', '', 'Player · 示例'), element('p', '', '选一句座右铭　✎'), element('p', '', '☆ 等级 17　|　开始日期为演示值'));
  const stats = element('div', 'profile-stats');
  for (const [name,value] of [['连续通关','1'],['连续登录','1天'],['完成的拼图','0次'],['了然种子通关','0'],['首次通关','1'],['第1名次数','0次']]) {
    const stat = element('div');
    stat.append(element('small', '', name), element('b', '', value));
    stats.append(stat);
  }
  club.append(stats, element('p', 'profile-id', 'UID · 本地演示　｜　申请金卡会员'));
  const grid = element('div', 'profile-choice-grid');
  grid.id = 'profile-choice-grid';
  grid.setAttribute('role', 'tabpanel');
  function renderChoices(index) {
    screenState.profileTab = index;
    grid.replaceChildren();
    let choices;
    if (index === 0) {
      choices = [...catalog.assets.filter(asset => /^hamster_idle_0[1-8]$/.test(asset.name)), ...catalog.assets.filter(asset => /^profile_avatar_\d+$/.test(asset.name))];
    } else if (index === 1) {
      choices = catalog.assets.filter(asset => /^profile_frame_\d+$/.test(asset.name));
    } else {
      choices = catalog.assets.filter(asset => asset.name.startsWith('costume_'));
    }
    for (const asset of choices) {
      const option = element('button', 'profile-choice');
      option.setAttribute('aria-label', asset.name);
      option.setAttribute('aria-pressed', index === 0 ? asset.name === screenState.portrait : index === 1 && asset.name === screenState.selectedFrame);
      option.append(picture(asset.name));
      option.addEventListener('click', () => {
        if (index === 0) {
          screenState.portrait = asset.name;
          avatar.children[0].src = asset.file;
        } else if (index === 1) {
          screenState.selectedFrame = asset.name;
          avatar.children[1].src = asset.file;
        } else {
          toast('服装选择示例；佩戴绑定与解锁条件待核对');
        }
        renderChoices(index);
      });
      grid.append(option);
    }
  }
  const tabs = makeTabSet(['头像','边框','服装'], renderChoices, '个人资料分类');
  tabs.id = 'profile-tabs';
  Array.from(tabs.children).forEach((tab, index) => {
    tab.id = 'profile-tab-' + index;
    tab.setAttribute('aria-controls', grid.id);
  });
  tabs.addEventListener('click', () => grid.setAttribute('aria-labelledby', tabs.querySelector('[aria-selected=true]').id));
  grid.setAttribute('aria-labelledby', 'profile-tab-0');
  screen.append(club, tabs, grid);
  tabs.children[screenState.profileTab].click();
}
function dailyComposition() {
  const screen = canvasScreen('supplemental-page');
  screenToolbar(screen, '每日挑战');
  screen.append(element('p', 'supplement-label', '补充布局：缺少原应用日历画面'));
  const calendar = element('div', 'daily-calendar');
  calendar.append(element('h3', '', '2026年10月'));
  const days = element('div', 'calendar-grid');
  for (const name of ['一','二','三','四','五','六','日']) {
    days.append(element('b', '', name));
  }
  for (let blank = 0; blank < 3; blank++) {
    days.append(element('span'));
  }
  for (let day = 1; day <= 31; day++) {
    const cell = element('button', '', day);
    cell.dataset.day = day;
    cell.setAttribute('aria-pressed', day === screenState.calendarSelected);
    cell.addEventListener('click', () => {
      screenState.calendarSelected = day;
      for (const sibling of days.querySelectorAll('button')) {
        sibling.setAttribute('aria-pressed', sibling === cell);
      }
      $('#calendar-selection').textContent = '10月' + day + '日 · 示例状态';
    });
    days.append(cell);
  }
  const selected = element('p', '', '10月' + screenState.calendarSelected + '日 · 示例状态');
  selected.id = 'calendar-selection';
  calendar.append(days, selected, skinButton('开始','orange',false, () => selectScreen(1)));
  screen.append(calendar);
}
function rankingComposition() {
  const screen = canvasScreen('supplemental-page');
  screenToolbar(screen, '排行榜');
  screen.append(element('p', 'supplement-label', '补充布局：缺少榜单与空/加载/失败截图'));
  const states = element('select');
  states.id = 'rank-state';
  states.setAttribute('aria-label', '排行榜状态');
  for (const name of ['正常','加载','空','失败']) {
    const option = element('option', '', name);
    states.append(option);
  }
  const list = element('div', 'ranking-list');
  list.id = 'ranking-list';
  function updateRanks() {
    list.replaceChildren();
    if (states.value === '正常') {
      componentConfig.sampleRanks.forEach((rank, index) => {
        const row = element('div', 'rank-item');
        row.append(element('b', '', index + 1), picture('hamster_idle_01'), element('span', '', rank.name), element('strong', '', rank.score));
        list.append(row);
      });
    } else if (states.value === '加载') {
      const loading = element('div', 'component-skeleton');
      loading.append(element('i'),element('i'),element('i'));
      list.append(loading);
    } else if (states.value === '空') {
      list.append(element('p', '', '还没有排名记录。'));
    } else {
      list.append(element('p', '', '需要网络连接（示例）'), skinButton('重试','blue',true, () => {
        states.value = '正常';
        updateRanks();
      }));
    }
  }
  states.addEventListener('change', updateRanks);
  screen.append(states, list);
  updateRanks();
}
const compositionRenderers = [homeComposition, boardComposition, settingsComposition, shopComposition, streakComposition, profileComposition, dailyComposition, rankingComposition];
const screenTabs = makeTabSet(screenNames, index => {
  screenIndex = index;
  liveTitle.textContent = screenNames[index] + ' · 重构预览';
  const key = screenKeys[index];
  const reference = catalog.references.find(item => item.kind === 'user-screenshot' && item.screen === key);
  comparisonStatus.textContent = reference ? '有截图依据；业务、时间和解锁结果为演示。' : '补充组件布局，待原应用截图确认。';
  screenRef.hidden = !reference;
  screenRef.src = reference ? reference.file : '';
  screenRef.alt = reference ? reference.title : '';
  refNote.textContent = reference ? reference.origin + '；本图 ' + reference.size.join('×') + '。' : '尚无该页面的用户截图。';
  compositionRenderers[index]();
}, '页面组合预览');
screenTabs.id = 'screen-tabs';
Array.from(screenTabs.children).forEach((tab,index) => {
  tab.id = 'screen-tab-' + index;
  tab.setAttribute('aria-controls', screenRoot.id);
});
function selectScreen(index) {
  screenTabs.children[index].click();
}
screenTabs.addEventListener('click', () => {
  screenRoot.setAttribute('aria-labelledby', screenTabs.querySelector('[aria-selected=true]').id);
});
screenSection.append(notice, screenTabs, composition);
selectScreen(0);

// Full settings preview replaces the early two-row placeholder dialog.
$('#settings-dialog').replaceChildren();
const settingsClose = element('button', 'dialog-close', '关闭');
settingsClose.setAttribute('data-close','');
$('#settings-dialog').append(settingsClose, element('h2', '', '设置组件已按截图补齐'), element('p', '', '打开完整设置预览，查看音效、音乐、语音、震动、区域边框、图案、语言与支持行。'));
$('#settings-dialog').append(skinButton('查看设置','orange',false, () => {
  $('#settings-dialog').close();
  selectScreen(2);
  screenSection.scrollIntoView({ behavior: 'instant' });
}));
const languageDialog = element('dialog', 'game-dialog');
languageDialog.id = 'language-dialog';
const closeLanguage = element('button', 'dialog-close', '关闭');
closeLanguage.setAttribute('data-close','');
languageDialog.append(closeLanguage, element('h2', '', '语言选择 · 补充布局'));
for (const name of ['简体中文','English']) {
  const button = skinButton(name,'cream',false, () => {
    const row = componentConfig.settings.find(item => item.key === 'language');
    row.value = name;
    languageDialog.close();
    settingsComposition();
  });
  languageDialog.append(button);
}
languageDialog.append(element('p', '', '只演示语言行选择；完整页面翻译与原作语言列表截图待补。'));
const purchaseDialog = element('dialog', 'game-dialog');
purchaseDialog.id = 'purchase-dialog';
const closePurchase = element('button', 'dialog-close', '关闭');
closePurchase.setAttribute('data-close','');
const purchaseDetail = element('p');
purchaseDetail.id = 'purchase-detail';
purchaseDialog.append(closePurchase, element('h2', '', '商品信息'), purchaseDetail, element('p', '', '查看展示信息后关闭。真实购买、恢复购买、失败和退款状态尚未接入。'));
document.body.append(languageDialog,purchaseDialog);

// Group the source assets by actual Hamdoku purpose, keeping type and text filters.
const groupLabel = element('label', '', '用途');
groupLabel.htmlFor = 'asset-purpose';
const purpose = element('select');
purpose.id = 'asset-purpose';
for (const [value,name] of [['all','全部用途'], ['home','首页'], ['board','棋盘与图案'], ['settings','设置与导航'], ['shop','商店与道具'], ['profile','头像边框服装'], ['streak','连胜与奖励']]) {
  const option = element('option', '', name);
  option.value = value;
  purpose.append(option);
}
$('.asset-tools').append(groupLabel,purpose);
purpose.addEventListener('change', () => updateAssets(true));
window.assetPurposeMatches = function(asset) {
  const groups = {
    home: /Logo|Background|CardDaily|CardRank|CardStreak|LevelButton|EndlessButton|icon_daily|icon_settings/,
    board: /pattern_|hamster_|Board|x_mark|icon_rule/,
    settings: /icon_(sfx|music|combo_voice|vibration|border|pattern|language|privacy|terms|support|back|close|settings)|Toggle/,
    shop: /shop_|offer_|ItemHint|BtnReward|seed_gift/,
    profile: /profile_|costume_|Costume/,
    streak: /Streak|gift_|IconSunflower|sprout_|Stamp/
  };
  return purpose.value === 'all' || groups[purpose.value].test(asset.name);
};

const evidenceBox = $('#evidence');
evidenceBox.querySelector('.notice').textContent = '本次用户提供 8 张截图：6 类独立画面，首页有 2 张字节相同的重复图。下方同时保留 4 张当前工程旧截图；两类来源明确区分。';
evidenceBox.querySelector('ol').replaceChildren(element('li','','仍缺：教程、成功、失败/复活、退出确认及语言列表完整画面。'), element('li','','仍缺：点击、双击、拖动和动效衔接录像。'), element('li','','仍缺：每日挑战日历、排行榜、无限模式、商店下半部分与购买结果。'));
const refGrid = $('#references');
refGrid.replaceChildren();
for (const ref of catalog.references.filter(ref => !ref.duplicateOf)) {
  const figure = element('figure');
  const link = element('a');
  link.href = ref.file;
  link.target = '_blank';
  link.rel = 'noopener';
  const image = element('img');
  image.src = ref.file;
  image.alt = ref.title || ref.source;
  link.append(image);
  figure.append(link,element('figcaption','',ref.title || ref.file.split('/').pop()),element('small','',ref.origin));
  refGrid.append(figure);
}
const nav = $('.sidebar nav');
for (const [id,name] of [['button-standards','按钮规格'],['slice-spacing','九宫格与间距'],['tabs-lists','标签与列表'],['page-previews','专属组件与截图对照']]) {
  const link = element('a','',name);
  link.href = '#' + id;
  nav.append(link);
}
$('#overview .stats span:last-child').replaceChildren(element('b','','06'), document.createTextNode(' 用户截图画面类型'));
$('#overview .notice').textContent = '第二版 · 补齐原作截图对照、按钮测量与切片、标签列表，以及 Hamdoku 专属页面组合。所有业务状态为浏览器演示。';
$('#config-view').textContent = JSON.stringify(cfg,null,2);
const symbolCatalog = element('div', 'spec');
symbolCatalog.append(element('h3', '', '12 种区域图案 · 原始资源完整展示'));
const symbolGrid = element('div', 'pattern-catalog');
for (let index = 0; index < 12; index++) {
  const item = element('div', 'pattern-catalog-item');
  item.style.backgroundColor = cfg.regionColors[index];
  const symbol = element('i');
  symbol.style.maskImage = `url("${original('pattern_' + index).dataUrl}")`;
  item.append(symbol,element('small', '', 'pattern_' + index));
  symbolGrid.append(item);
}
symbolCatalog.append(symbolGrid,element('p', '', '图案与颜色按原始索引展示；实际关卡映射由运行配置决定。'));
$('#board').append(symbolCatalog);
window.UI_COMPONENTS_READY = true;
