/* Run with Node.js + playwright available through NODE_PATH. Browser stays headless. */
const { chromium } = require('playwright');
const fs = require('node:fs');
const path = require('node:path');
const { pathToFileURL } = require('node:url');
const crypto = require('node:crypto');
const assert = require('node:assert/strict');
(async () => {
  const root = __dirname;
  const manifest = JSON.parse(fs.readFileSync(path.join(root, 'manifest.json'), 'utf8'));
  const keys = new Set();
  for (const record of [...manifest.assets, ...manifest.evidence, ...manifest.references]) {
    const bytes = fs.readFileSync(path.join(root, record.file));
    assert.equal(crypto.createHash('sha256').update(bytes).digest('hex'), record.sha256, record.file);
    if (record.key) { assert.ok(!keys.has(record.key), record.key); keys.add(record.key); }
  }
  const executablePath = process.env.UI_BROWSER || 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe';
  const browser = await chromium.launch({ executablePath, headless: true });
  const errors = [];
  const page = await browser.newPage({ viewport: { width: 1440, height: 1000 } });
  page.on('pageerror', error => errors.push(error.message));
  page.on('console', message => { if (message.type() === 'error') { errors.push(message.text()); } });
  page.on('requestfailed', request => errors.push(request.url() + ' ' + request.failure().errorText));
  await page.goto(pathToFileURL(path.join(root, 'UI Library.html')).href);
  await page.evaluate(() => document.fonts.ready);
  assert.equal(await page.locator('#asset-count').innerText(), String(manifest.assets.length));
  const imageCheck = await page.evaluate(async () => {
    const failed = [];
    for (const asset of UI_CATALOG.assets.filter(record => record.type === 'Sprite')) {
      const image = new Image(); image.src = asset.file;
      try { await image.decode(); } catch { failed.push(asset.file); }
    }
    return failed;
  });
  assert.deepEqual(imageCheck, []);
  const sizes = [];
  fs.mkdirSync(path.join(root, 'previews'), { recursive: true });
  for (const width of [1440, 768, 375]) {
    await page.setViewportSize({ width, height: 1000 });
    assert.ok(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), 'Page overflow at ' + width);
    await page.screenshot({ path: path.join(root, `previews/overview-${width}.png`) });
    await page.locator('#home-preview').screenshot({ path: path.join(root, `previews/home-${width}.png`) });
    sizes.push(width);
  }
  await page.setViewportSize({ width: 1440, height: 1000 });
  for (const [value, mode, locked] of [[9,'ranking',true],[10,'ranking',false],[19,'daily',true],[20,'daily',false],[99,'endless',true],[100,'endless',false]]) {
    await page.locator('#clears').fill(String(value));
    assert.equal(await page.locator(`[data-mode=${mode}]`).getAttribute('data-locked'), String(locked));
  }
  await page.locator('#clears').fill('29');
  assert.ok((await page.locator('.campaign-button img').getAttribute('src')).includes('LevelButtonHard'));
  await page.locator('#language').click(); assert.equal(await page.locator('#level-label').innerText(), 'Level 30');
  await page.locator('#clears').fill('-1'); assert.equal(await page.locator('#clears').getAttribute('aria-invalid'), 'true');
  await page.locator('#clears').fill('0'); await page.locator('#language').click();
  const toggle = page.locator('#controls .toggle'); await toggle.click(); assert.equal(await toggle.getAttribute('aria-checked'), 'false');
  await page.locator('.segmented button').nth(1).click(); assert.equal(await page.locator('.segmented button').nth(1).getAttribute('aria-pressed'), 'true');
  await page.locator('#name-form .game-button').click(); assert.equal(await page.locator('#nickname').getAttribute('aria-invalid'), 'true');
  await page.locator('#nickname').fill('仓鼠玩家'); await page.locator('#name-form .game-button').click(); assert.equal(await page.locator('#nickname').getAttribute('aria-invalid'), 'false');
  for (const value of [0, 5, 100]) {
    await page.locator('#progress-input').evaluate((element, value) => { element.value = value; element.dispatchEvent(new Event('input')); }, String(value));
    assert.equal(await page.locator('#progress-bar').getAttribute('value'), String(value));
  }
  await page.locator('#empty-toggle').click(); assert.ok((await page.locator('#list-state').innerText()).includes('还没有'));
  await page.locator('#empty-toggle').click();
  const cell = page.locator('#board-grid .cell').first();
  for (const state of [1,2,3,0]) { await cell.click(); assert.equal(await cell.getAttribute('data-state'), String(state)); }
  await cell.click(); await page.locator('#reset-board').click(); assert.equal(await cell.getAttribute('data-state'), '0');
  await page.locator('#busy-button').click(); assert.equal(await page.locator('#busy-button').getAttribute('aria-busy'), 'true');
  await page.locator('#busy-button').isEnabled().then(async () => { await page.waitForFunction(() => !document.getElementById('busy-button').disabled); });
  const opener = page.locator('#feedback [data-dialog=settings-dialog]'); await opener.click();
  assert.ok(await page.locator('#settings-dialog').isVisible());
  await page.locator('#settings-dialog').evaluate(element => Promise.all(element.getAnimations().map(animation => animation.finished)));
  await page.locator('#toast').evaluate(element => { element.hidden = true; });
  await page.screenshot({ path: path.join(root, 'previews/settings-desktop.png') });
  await page.keyboard.press('Escape'); assert.ok(await opener.evaluate(element => document.activeElement === element));
  await page.locator('#feedback [data-dialog=error-dialog]').click(); await page.locator('#retry-button').click();
  assert.equal(await page.locator('#retry-button').getAttribute('aria-busy'), 'true');
  await page.waitForFunction(() => !document.getElementById('retry-button').disabled); assert.ok((await page.locator('#retry-message').innerText()).includes('仍需网络连接'));
  await page.keyboard.press('Escape');
  await page.locator('#feedback [data-dialog=reward-dialog]').click(); await page.locator('#reward-dialog .game-button').click();
  assert.ok(!await page.locator('#reward-dialog').isVisible());
  await page.locator('#asset-search').fill('LevelButton'); assert.ok((await page.locator('#asset-visible').innerText()).includes('2'));
  await page.locator('.asset-card').first().click(); assert.ok((await page.locator('#asset-detail').innerText()).includes('sha256')); await page.keyboard.press('Escape');
  await page.locator('#asset-search').fill('no-such-asset-qzx'); assert.ok((await page.locator('#asset-grid').innerText()).includes('没有匹配'));
  await page.locator('#asset-search').fill(''); await page.locator('#asset-type').selectOption('Font');
  assert.equal(await page.locator('.asset-card').count(), 10);
  await page.locator('#asset-type').selectOption('all'); await page.locator('#next-page').click(); assert.equal(await page.locator('#page-label').innerText(), '2 / 15');
  await page.locator('#prev-page').click();
  await page.locator('#press-preview').click(); assert.ok(await page.locator('#press-preview').evaluate(element => element.getAnimations().length > 0));
  await page.locator('#reward-motion').click(); assert.ok(await page.locator('#reward-float').evaluate(element => element.getAnimations().length > 0));
  await page.emulateMedia({ reducedMotion: 'reduce' });
  await page.locator('#press-preview').click(); assert.ok((await page.locator('#toast').innerText()).includes('减少动态效果'));
  await page.emulateMedia({ reducedMotion: 'no-preference' });
  await page.setViewportSize({ width: 375, height: 900 });
  await page.locator('#feedback [data-dialog=settings-dialog]').click();
  await page.locator('#settings-dialog').evaluate(element => Promise.all(element.getAnimations().map(animation => animation.finished)));
  await page.locator('#toast').evaluate(element => { element.hidden = true; });
  assert.ok(await page.evaluate(() => { const r = document.getElementById('settings-dialog').getBoundingClientRect(); return r.left >= 0 && r.right <= innerWidth && r.top >= 0 && r.bottom <= innerHeight && getComputedStyle(document.getElementById('settings-dialog')).opacity === '1'; }));
  await page.screenshot({ path: path.join(root, 'previews/settings-mobile.png') }); await page.keyboard.press('Escape');
  await page.setViewportSize({ width: 1440, height: 1000 });
  await page.locator('#board').scrollIntoViewIfNeeded(); await page.screenshot({ path: path.join(root, 'previews/board-desktop.png') });
  assert.deepEqual(errors, []);
  const result = { date: '2026-10-27', browser: await browser.version(), mode: 'headless file://',
    assetHashChecks: manifest.assets.length, evidenceHashChecks: manifest.evidence.length, referenceHashChecks: manifest.references.length,
    decodedSprites: manifest.assets.filter(asset => asset.type === 'Sprite').length, viewportWidths: sizes,
    checks: ['unique IDs', 'all asset hashes', 'all PNG decoding', 'unlock boundaries', 'hard background', 'home language', 'invalid count', 'toggle', 'choice', 'input validation', 'progress 0/5/100', 'empty state', 'cell cycle/reset', 'busy button', 'dialog Escape/focus restore', 'retry state', 'reward close', 'asset search/details/empty/filter/pagination', 'motion', 'reduced motion', 'mobile modal bounds'], errors,
    excluded: ['Original application screenshot comparison', 'Unity runtime', 'Android device', 'game rules', 'full language coverage'] };
  fs.writeFileSync(path.join(root, 'verification-results.json'), JSON.stringify(result, null, 2));
  console.log(JSON.stringify(result, null, 2)); await browser.close();
})().catch(error => { console.error(error); process.exit(1); });
