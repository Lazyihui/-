'use strict';
const cfg = window.UI_LIBRARY_CONFIG;
const catalog = window.UI_CATALOG;
const byKey = new Map(catalog.assets.map(asset => [asset.key, asset]));
const $ = selector => document.querySelector(selector);
const all = selector => Array.from(document.querySelectorAll(selector));
for (const [key, value] of Object.entries(cfg.tokens)) {
  document.documentElement.style.setProperty('--' + key, value);
}
for (const [language, name] of Object.entries(cfg.fonts)) {
  const font = catalog.assets.find(asset => asset.type === 'Font' && asset.name === name);
  if (!font) { throw new Error('Missing font: ' + name); }
  const style = document.createElement('style');
  style.textContent = `@font-face{font-family:${language === 'zh' ? 'HamdokuChinese' : 'HamdokuEnglish'};src:url("${font.file}");font-display:swap}`;
  document.head.append(style);
}
function assetFor(name) {
  const asset = byKey.get(cfg.images[name]);
  if (!asset) { throw new Error('Missing configured asset: ' + name); }
  return asset;
}
function bindImages(root = document) {
  for (const element of root.querySelectorAll('[data-image]')) {
    const asset = assetFor(element.dataset.image);
    if (element.tagName === 'IMG') { element.src = asset.file; }
    else { element.style.backgroundImage = `url("${asset.file}")`; }
  }
}
bindImages();
$('#home-preview').style.backgroundImage = `url("${assetFor('background').file}")`;
$('#asset-count').textContent = catalog.assets.length;
$('#config-view').textContent = JSON.stringify(cfg, null, 2);
$('#show-config').addEventListener('click', () => { $('#config-view').hidden = !$('#config-view').hidden; });
function addSwatch(container, label, value) {
  const card = document.createElement('div'); card.className = 'swatch';
  const color = document.createElement('i'); color.style.background = value;
  const text = document.createElement('span'); text.textContent = label;
  const hex = document.createElement('small'); hex.textContent = value; text.append(hex);
  card.append(color, text); container.append(card);
}
for (const key of ['paper', 'ink', 'muted', 'accent', 'pink', 'purple', 'blue', 'line']) { addSwatch($('#palette'), key, cfg.tokens[key]); }
cfg.regionColors.forEach((value, index) => addSwatch($('#region-palette'), '区域 ' + (index + 1), value));
let toastTimer;
function toast(message) {
  clearTimeout(toastTimer); $('#toast').textContent = message; $('#toast').hidden = false;
  toastTimer = setTimeout(() => { $('#toast').hidden = true; }, cfg.timing.toast);
}
document.addEventListener('click', event => {
  const trigger = event.target.closest('[data-toast]'); if (trigger) { toast(trigger.dataset.toast); }
  const opener = event.target.closest('[data-dialog]'); if (opener) { document.getElementById(opener.dataset.dialog).showModal(); }
  const closer = event.target.closest('[data-close]'); if (closer) { closer.closest('dialog').close(); }
  const toggle = event.target.closest('.toggle');
  if (toggle) { toggle.setAttribute('aria-checked', toggle.getAttribute('aria-checked') !== 'true'); }
});
for (const button of all('.segmented button')) {
  button.addEventListener('click', () => {
    for (const sibling of button.parentElement.children) { sibling.setAttribute('aria-pressed', sibling === button); }
  });
}
function busy(button, pending, complete, callback) {
  const label = button.textContent; button.disabled = true; button.setAttribute('aria-busy', 'true'); button.textContent = pending;
  setTimeout(() => { button.disabled = false; button.removeAttribute('aria-busy'); button.textContent = label; toast(complete); if (callback) { callback(); } }, cfg.timing.busy);
}
$('#busy-button').addEventListener('click', event => busy(event.currentTarget, '加载中…', '加载状态演示完成'));
$('#retry-button').addEventListener('click', event => {
  $('#retry-message').textContent = '正在重试（模拟）…';
  busy(event.currentTarget, '重试中…', '重试演示完成', () => { $('#retry-message').textContent = '仍需网络连接；可再次重试。本演示未发送请求。'; });
});
$('#name-form').addEventListener('submit', event => {
  event.preventDefault(); const valid = $('#nickname').value.trim().length > 0;
  $('#nickname').setAttribute('aria-invalid', !valid);
  $('#name-message').textContent = valid ? '校验通过；未保存昵称。' : '请先输入昵称。';
});
function updateProgress() {
  const value = Number($('#progress-input').value); $('#progress-value').textContent = value + '%'; $('#progress-bar').value = value; $('#progress-bar').textContent = value + '%';
}
$('#progress-input').value = cfg.demo.progress; updateProgress();
$('#progress-input').addEventListener('input', updateProgress);
let empty = false;
$('#empty-toggle').addEventListener('click', () => { empty = !empty; $('#list-state').textContent = empty ? '还没有挑战记录，开始第一场吧。' : '今日挑战记录 · 示例条目'; });
let language = 'zh';
function updateHome() {
  const input = $('#clears'); const count = Number(input.value);
  if (!Number.isInteger(count) || count < 0 || count > 50000) { input.setAttribute('aria-invalid', 'true'); return; }
  input.removeAttribute('aria-invalid'); const labels = cfg.labels[language];
  $('#home-preview').style.fontFamily = language === 'zh' ? 'HamdokuChinese' : 'HamdokuEnglish';
  $('#home-preview').lang = language === 'zh' ? 'zh-CN' : 'en';
  for (const element of all('[data-label]')) { element.textContent = labels[element.dataset.label]; }
  $('#level-label').textContent = labels.level + ' ' + (count + 1);
  const hard = count + 1 >= 21 && (count + 1) % 10 === 0;
  $('.campaign-button img').src = assetFor(hard ? 'campaignHard' : 'campaign').file;
  for (const card of all('[data-mode]')) {
    const mode = card.dataset.mode; const locked = mode in cfg.unlocks && count < cfg.unlocks[mode];
    card.classList.toggle('locked', locked); card.dataset.locked = String(locked);
    const subtitle = card.querySelector('.mode-lock');
    if (subtitle) { subtitle.textContent = locked ? labels.locked.replace('{0}', cfg.unlocks[mode]) : labels.play; }
  }
}
$('#clears').value = cfg.demo.clears; updateHome();
$('#clears').addEventListener('input', updateHome);
$('#language').addEventListener('click', () => { language = language === 'zh' ? 'en' : 'zh'; $('#language').textContent = language === 'zh' ? 'English' : '中文'; updateHome(); });
for (const card of all('[data-mode]')) {
  card.addEventListener('click', () => {
    if (!$('#clears').checkValidity() || $('#clears').getAttribute('aria-invalid') === 'true') { toast('请输入 0–50000 之间的整数通关数。'); return; }
    toast(card.dataset.locked === 'true' ? cfg.labels[language].locked.replace('{0}', cfg.unlocks[card.dataset.mode]) : '入口交互示例：不进入实际游戏。');
  });
}
for (let index = 0; index < cfg.demo.lives; index++) { const image = document.createElement('img'); image.src = assetFor('life').file; image.alt = ''; $('#lives').append(image); }
const stateLabels = ['空白', '排除', '仓鼠', '冲突'];
function displayCell(cell, state) {
  cell.dataset.state = state; cell.replaceChildren(); cell.setAttribute('aria-label', `${cell.dataset.position}：${stateLabels[state]}`);
  if (state !== 0) { const image = document.createElement('img'); image.alt = ''; image.src = assetFor(state === 1 ? 'cross' : 'hamster').file; cell.append(image); }
}
function makeCell(row, col, sample = false) {
  const cell = document.createElement('button'); cell.className = 'cell' + (sample ? ' sample-cell' : '');
  cell.style.background = cfg.regionColors[row % cfg.regionColors.length]; cell.dataset.position = sample ? '状态示例' : `第${row + 1}行第${col + 1}列`;
  displayCell(cell, sample ? col : 0);
  cell.addEventListener('click', () => displayCell(cell, (Number(cell.dataset.state) + 1) % stateLabels.length)); return cell;
}
$('#board-grid').style.gridTemplateColumns = `repeat(${cfg.demo.boardSize}, minmax(0, 1fr))`;
for (let row = 0; row < cfg.demo.boardSize; row++) { for (let col = 0; col < cfg.demo.boardSize; col++) { $('#board-grid').append(makeCell(row, col)); } }
for (let state = 0; state < stateLabels.length; state++) { $('#cell-samples').append(makeCell(state, state, true)); }
$('#reset-board').addEventListener('click', () => { for (const cell of all('#board-grid .cell')) { displayCell(cell, 0); } });
const reduced = window.matchMedia('(prefers-reduced-motion: reduce)');
const animations = new WeakMap();
function preview(element, keyframes, duration) {
  if (animations.has(element)) { animations.get(element).cancel(); }
  if (reduced.matches) { toast('当前启用减少动态效果，已省略动画。'); return; }
  const animation = element.animate(keyframes, { duration, easing: 'ease-out' }); animations.set(element, animation);
}
$('#press-preview').addEventListener('click', event => preview(event.currentTarget, [{transform:'scale(1)'}, {transform:`scale(${cfg.tokens['press-scale']})`, offset:0.4}, {transform:`scale(${cfg.tokens['press-scale']})`, offset:0.7}, {transform:'scale(1)'}], cfg.timing.pressPreview));
$('#reward-motion').addEventListener('click', () => preview($('#reward-float'), [{transform:'translateY(12px)',opacity:0}, {transform:'translateY(0)',opacity:1,offset:0.3}, {transform:'translateY(-20px)',opacity:0}], cfg.timing.rewardPreview));
let page = 0; const pageSize = cfg.assetPageSize;
function showAsset(asset) {
  $('#asset-title').textContent = asset.name; $('#asset-preview').replaceChildren();
  if (asset.type === 'Sprite') { const img = document.createElement('img'); img.src = asset.file; img.alt = asset.name; $('#asset-preview').append(img); }
  else { const link = document.createElement('a'); link.href = asset.file; link.textContent = '查看原始字体文件 ↗'; $('#asset-preview').append(link); }
  $('#asset-detail').textContent = JSON.stringify(asset, null, 2) + '\n\nalphaBounds：导出 PNG 的透明边界。spriteRect / spriteBorder / pixelsPerUnit 为原作 Sprite 元数据；exportBorderLTRB 为考虑 textureRectOffset 的导出 PNG 切片。零切片资源不启用九宫格。';
  $('#asset-dialog').showModal();
}
function updateAssets(reset = false) {
  if (reset) { page = 0; }
  const query = $('#asset-search').value.trim().toLowerCase(); const type = $('#asset-type').value;
  const matches = catalog.assets.filter(asset => (type === 'all' || asset.type === type) && (!window.assetPurposeMatches || window.assetPurposeMatches(asset)) && (asset.name + ' ' + asset.key + ' ' + asset.source).toLowerCase().includes(query));
  const pages = Math.max(1, Math.ceil(matches.length / pageSize)); page = Math.min(page, pages - 1);
  $('#asset-visible').textContent = matches.length + ' 项'; $('#asset-grid').replaceChildren();
  for (const asset of matches.slice(page * pageSize, (page + 1) * pageSize)) {
    const card = document.createElement('button'); card.className = 'asset-card';
    if (asset.type === 'Sprite') { const img = document.createElement('img'); img.src = asset.file; img.alt = ''; card.append(img); }
    else { const sample = document.createElement('div'); sample.className = 'font-tile'; sample.textContent = 'Aa'; card.append(sample); }
    const name = document.createElement('span'); name.textContent = asset.name;
    const details = document.createElement('small'); details.textContent = asset.type + (asset.size ? ' · ' + asset.size.join(' × ') : '') + ' · #' + asset.pathID;
    card.append(name, details); card.addEventListener('click', () => showAsset(asset)); $('#asset-grid').append(card);
  }
  if (matches.length === 0) { $('#asset-grid').textContent = '没有匹配的资源，请更换关键词。'; }
  $('#page-label').textContent = `${page + 1} / ${pages}`; $('#prev-page').disabled = page === 0; $('#next-page').disabled = page + 1 >= pages;
}
$('#asset-search').addEventListener('input', () => updateAssets(true)); $('#asset-type').addEventListener('change', () => updateAssets(true));
$('#prev-page').addEventListener('click', () => { page--; updateAssets(); }); $('#next-page').addEventListener('click', () => { page++; updateAssets(); }); updateAssets();
for (const reference of catalog.references) {
  const figure = document.createElement('figure'); const link = document.createElement('a'); link.href = reference.file; link.target = '_blank'; link.rel = 'noopener';
  const img = document.createElement('img'); img.src = reference.file; img.alt = reference.source;
  link.append(img); const caption = document.createElement('figcaption'); caption.textContent = reference.file.split('/').pop();
  const note = document.createElement('small'); note.textContent = reference.origin; caption.append(note); figure.append(link, caption); $('#references').append(figure);
}

// 静态图片直接支持 file://；筛选仅改变当前参考库显示。
{
  const category = document.getElementById('theme-category');
  const search = document.getElementById('theme-search');
  const count = document.getElementById('theme-count');
  const groups = [...document.querySelectorAll('.theme-group')];
  function filterThemeComparison() {
    const query = search.value.trim().toLocaleLowerCase();
    let visible = 0;
    for (const group of groups) {
      const selected = category.value === 'all' || category.value === group.dataset.category;
      let matches = 0;
      for (const pair of group.querySelectorAll('.theme-pair')) {
        pair.hidden = !selected || !pair.dataset.search.toLocaleLowerCase().includes(query);
        if (!pair.hidden) { matches++; }
      }
      group.hidden = matches === 0;
      if (selected && (query || category.value !== 'all')) { group.open = true; }
      visible += matches;
    }
    count.textContent = visible ? visible + ' 组对比 · 点击分类标题展开' : '没有匹配素材，请更换关键词或分类。';
  }
  category.addEventListener('change', filterThemeComparison);
  search.addEventListener('input', filterThemeComparison);
  filterThemeComparison();
}
