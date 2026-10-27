const { chromium } = require('playwright');
const fs = require('node:fs');
const path = require('node:path');
const { pathToFileURL } = require('node:url');
const assert = require('node:assert/strict');

(async () => {
  const root = __dirname;
  const browser = await chromium.launch({ executablePath: process.env.UI_BROWSER || 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe', headless: true });
  const page = await browser.newPage({ viewport: { width: 1440, height: 1000 } });
  const errors = [];
  page.on('pageerror', error => errors.push(error.message));
  page.on('console', message => {
    if (message.type() === 'error') {
      errors.push(message.text());
    }
  });
  page.on('requestfailed', request => errors.push(request.url()));
  await page.goto(pathToFileURL(path.join(root, 'UI Library.html')).href);
  await page.waitForFunction(() => window.UI_COMPONENTS_READY);
  await page.evaluate(() => document.fonts.ready);
  const sourceChecks = await page.evaluate(() => ({
    originalScreenshots: UI_CATALOG.references.filter(ref => ref.kind === 'user-screenshot').length,
    duplicates: UI_CATALOG.references.filter(ref => ref.duplicateOf).length,
    spriteMetadata: UI_CATALOG.assets.filter(asset => asset.type === 'Sprite' && asset.spriteBorder && asset.spriteRect && asset.textureRectOffset).length
  }));
  assert.deepEqual(sourceChecks, {originalScreenshots:8,duplicates:2,spriteMetadata:708});
  const sizeChecks = [];
  for (const width of [1440,768,375]) {
    await page.setViewportSize({width,height:1000});
    for (let tab = 0; tab < 8; tab++) {
      await page.locator('#screen-tab-' + tab).click();
      assert.ok(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), 'Page overflow: ' + width + '/' + tab);
      assert.ok(await page.locator('.screen').evaluate(element => element.scrollWidth <= element.clientWidth + 1), 'Screen overflow: ' + width + '/' + tab);
      if (width === 375 || width === 1440) {
        await page.locator('#screen-root').screenshot({path:path.join(root,`previews/components-${tab}-${width}.png`)});
      }
    }
    sizeChecks.push(width);
  }
  await page.setViewportSize({width:1440,height:1000});
  await page.locator('#button-copy').fill('领取每日奖励×12');
  await page.waitForFunction(() => {
    const button = document.getElementById('alignment-button');
    return button.dataset.inkY && Math.abs(Number(button.dataset.inkY) - Number(button.dataset.faceY)) < 0.1;
  });
  assert.ok(await page.locator('#alignment-button').evaluate(element => element.clientWidth > Number(element.dataset.labelWidth)));
  await page.locator('#alignment-guide').check();
  await page.locator('#button-standards').screenshot({path:path.join(root,'previews/button-specifications.png')});
  for (const value of [160,360]) {
    await page.locator('#slice-width').fill(String(value));
    assert.ok(Math.abs((await page.locator('#slice-demo').boundingBox()).width - value) < 1);
  }
  await page.locator('#item-spacing').fill('28');
  assert.equal(await page.locator('.spacing-item').evaluate(element => getComputedStyle(element).paddingTop), '28px');
  for (const count of ['0','1','2','6']) {
    await page.locator('#item-count').selectOption(count);
    assert.equal(await page.locator('#example-list .reusable-item').count(), Number(count));
  }
  const listTabs = page.locator('#example-tabs [role=tab]');
  await listTabs.first().focus();
  await page.keyboard.press('ArrowRight');
  assert.equal(await listTabs.nth(1).getAttribute('aria-selected'), 'true');
  await page.locator('#item-count').selectOption('2');
  await page.locator('#example-list .reusable-item').nth(1).getByRole('button',{name:'领取',exact:true}).click();
  assert.ok(await page.locator('#example-list .reusable-item').nth(1).getByRole('button',{name:'已领取',exact:true}).isDisabled());
  await page.locator('#screen-tab-2').click();
  assert.equal(await page.locator('.observed-setting-row').count(),7);
  await page.getByRole('switch',{name:'图案',exact:true}).click();
  await page.getByRole('switch',{name:'区域边框',exact:true}).click();
  await page.getByRole('button',{name:'下一种连击语音'}).click();
  assert.ok((await page.locator('.voice-selector').innerText()).includes('女声'));
  await page.locator('.language-row-link').click();
  assert.ok(await page.locator('#language-dialog').isVisible());
  await page.locator('#language-dialog .skin-button').nth(1).click();
  assert.ok((await page.locator('.language-row-link').innerText()).includes('English'));
  await page.locator('#screen-tab-1').click();
  assert.equal(await page.locator('.observed-cell').count(),81);
  assert.equal(await page.locator('.region-pattern:visible').count(),0);
  assert.ok(await page.locator('.observed-board').evaluate(element => element.classList.contains('region-outlines')));
  await page.locator('.observed-cell').first().click();
  assert.equal(await page.locator('.observed-cell').first().getAttribute('data-state'),'1');
  await page.locator('.observed-cell').first().click();
  assert.equal(await page.locator('.found-count b').innerText(),'2/9');
  await page.locator('#screen-tab-3').click();
  assert.equal(await page.locator('.product-item').count(),7);
  await page.locator('.product-item .skin-button').first().click();
  assert.ok((await page.locator('#purchase-detail').innerText()).includes('不发起订单'));
  await page.keyboard.press('Escape');
  await page.locator('#screen-tab-4').click();
  assert.equal(await page.locator('.streak-day').count(),7);
  await page.locator('.streak-day').nth(3).click();
  assert.equal(await page.locator('.streak-number').innerText(),'4');
  await page.locator('#screen-tab-5').click();
  const portraits = await page.locator('.profile-choice').count();
  assert.ok(portraits >= 16);
  await page.locator('.profile-choice').nth(3).click();
  assert.equal(await page.locator('.profile-choice').nth(3).getAttribute('aria-pressed'),'true');
  await page.locator('#profile-tab-1').click();
  const frames = await page.locator('.profile-choice').count();
  assert.ok(frames >= 16);
  await page.locator('.profile-choice').nth(2).click();
  assert.equal(await page.locator('.profile-choice').nth(2).getAttribute('aria-pressed'),'true');
  await page.locator('#profile-tab-2').click();
  const costumes = await page.locator('.profile-choice').count();
  assert.ok(costumes >= 1);
  await page.locator('#screen-tab-6').click();
  assert.equal(await page.locator('.calendar-grid button').count(),31);
  await page.locator('[data-day="20"]').click();
  assert.ok((await page.locator('#calendar-selection').innerText()).includes('20'));
  await page.locator('#screen-tab-7').click();
  await page.locator('#rank-state').selectOption({label:'空'});
  assert.ok((await page.locator('#ranking-list').innerText()).includes('还没有'));
  await page.locator('#rank-state').selectOption({label:'加载'});
  assert.equal(await page.locator('#ranking-list .component-skeleton').count(),1);
  await page.locator('#rank-state').selectOption({label:'失败'});
  await page.locator('#ranking-list .skin-button').click();
  assert.equal(await page.locator('.rank-item').count(),3);
  await page.locator('#asset-purpose').selectOption('profile');
  assert.ok((await page.locator('#asset-visible').innerText()) !== '718 项');
  await page.locator('#asset-search').fill('profile_frame_0');
  assert.equal(await page.locator('.asset-card').count(),1);
  await page.locator('.asset-card').first().click();
  assert.ok((await page.locator('#asset-detail').innerText()).includes('textureRectOffset'));
  await page.keyboard.press('Escape');
  await page.emulateMedia({reducedMotion:'reduce'});
  assert.equal(await page.locator('.component-skeleton i').first().evaluate(element => getComputedStyle(element).animationName),'none');
  assert.deepEqual(errors,[]);
  const result = {date:'2026-10-27',browser:await browser.version(),sourceChecks,viewportWidths:sizeChecks,
    pageCompositions:8,settingsRows:7,products:7,portraits,frames,costumes,
    checks:['all compositions at three widths','button glyph center and width','slice endpoints','spacing control','list counts 0/1/2/6','tab keyboard','claim state','settings switches/voice/language','81-cell states and region outlines','product details without purchase','7-day streak','profile avatar/frame/clothing categories','calendar selection','ranking loading/empty/failure/retry','purpose filter','sprite metadata details','reduced motion'],errors,
    excluded:['pixel-perfect source match','gesture semantics','real countdown','purchase or rewards','Unity runtime','Android device']};
  fs.writeFileSync(path.join(root,'verification-components.json'),JSON.stringify(result,null,2));
  console.log(JSON.stringify(result,null,2));
  await browser.close();
})().catch(error => {
  console.error(error);
  process.exit(1);
});
