from pathlib import Path
import hashlib
import json
import shutil
import re
import numpy as np
from PIL import Image, ImageDraw, ImageFont, ImageChops
from scipy import ndimage as ndi
from scipy.spatial import ConvexHull

ROOT = Path(__file__).resolve().parents[6]
THEME = ROOT / 'Docs/UILibrary/themes/PuppyBakery'
WORK = Path(__file__).resolve().parent
OUT = THEME / 'assets/UI/Game'
ORIGINAL = ROOT / 'Assets/Res_Runtime/UI/Game'
GEN = Path('C:/Users/Administrator/.codex/generated_images/01a17caf-dfcf-7710-83fe-0f0e4e1f5d6f')
SOURCES = {
    'approved': 'exec-9e147eab-8d87-419d-bb30-83ac585b1dbe.png',
    'background': 'exec-3f7eb811-46b8-4bdb-8433-055af04aede0.png',
    'rule': 'exec-de75d936-8c8f-4ba4-a6a4-9b9e323fbfd5.png',
    'hud': 'exec-fabef35f-6b87-4f3a-96bf-fce2e4bdeee1.png',
    'base': 'exec-8d15747b-3785-45f2-91c7-0a96c13be213.png',
}
OUT.mkdir(parents=True, exist_ok=True)
for key, name in SOURCES.items():
    shutil.copy2(GEN / name, WORK / (key + '_master.png'))
masters = {k: Image.open(WORK / (k + '_master.png')).convert('RGBA') for k in SOURCES}
inventory = json.loads((WORK / 'original_inventory.json').read_text(encoding='utf-8'))
specs = {r['file']: r for r in inventory}
records = []


def clean_alpha(im):
    a = np.array(im)
    mask = a[:, :, 3] > 150
    labels, count = ndi.label(mask)
    areas = np.bincount(labels.ravel())
    areas[0] = 0
    mask = labels == areas.argmax()
    mask = ndi.binary_fill_holes(mask)
    mask = ndi.binary_opening(mask, iterations=2)
    a[:, :, 3] = np.minimum(a[:, :, 3], mask.astype('uint8') * 255)
    a[a[:, :, 3] == 0, :3] = 0
    im = Image.fromarray(a)
    return im.crop(im.getchannel('A').getbbox())


def fit(im, size, pad=2):
    im = im.crop(im.getchannel('A').getbbox())
    scale = min((size[0] - 2 * pad) / im.width, (size[1] - 2 * pad) / im.height)
    im = im.resize((max(1, round(im.width * scale)), max(1, round(im.height * scale))), Image.Resampling.LANCZOS)
    result = Image.new('RGBA', size)
    result.alpha_composite(im, ((size[0] - im.width) // 2, (size[1] - im.height) // 2))
    return result


def rounded_mask(size, radius, inset=0):
    w, h = size
    mask = Image.new('L', (w * 4, h * 4))
    ImageDraw.Draw(mask).rounded_rectangle((inset * 4, inset * 4, (w - inset) * 4 - 1, (h - inset) * 4 - 1), radius=radius * 4, fill=255)
    return mask.resize(size, Image.Resampling.LANCZOS)


def nine(im, size, borders):
    w, h = im.size
    tw, th = size
    l, t, r, b = borders
    xs, ys = [0, l, w-r, w], [0, t, h-b, h]
    dx, dy = [0, l, tw-r, tw], [0, t, th-b, th]
    out = Image.new('RGBA', size)
    for y in range(3):
        for x in range(3):
            piece = im.crop((xs[x], ys[y], xs[x+1], ys[y+1]))
            piece = piece.resize((dx[x+1]-dx[x], dy[y+1]-dy[y]), Image.Resampling.LANCZOS)
            out.alpha_composite(piece, (dx[x], dy[y]))
    return out


def emit(name, im, source, method, note='', source_rect=None, retained=False):
    file = name + '.png'
    spec = specs[file]
    assert im.size == tuple(spec['size']), (name, im.size, spec['size'])
    im = im.convert('RGBA')
    im.save(OUT / file)
    if retained:
        shutil.copy2(ORIGINAL / file, OUT / file)
    records.append(dict(file=file, size=spec['size'], mode=im.mode, source=source, method=method,
                        sourceRect=source_rect, note=note, retainedOriginal=retained,
                        originalSpriteBorderXYZW=spec['border'], originalSpriteMode=spec['spriteMode'],
                        sha256=hashlib.sha256((OUT / file).read_bytes()).hexdigest()))


def foreground(box, kind):
    im = masters['approved'].crop(box)
    a = np.array(im)
    r, g, b = [a[:, :, i].astype(float) for i in range(3)]
    if kind == 'brown':
        mask = (r < 170) & (g < 145) & (b < 140)
    elif kind == 'gold':
        mask = (r-g > 16) & (g-b > 14) & (g < 205)
    elif kind == 'pink':
        mask = (r > 200) & (r-g > 25) & (b-g > 8)
    elif kind == 'biscuit':
        mask = (r-g > 25) & (g-b > 20) & (g < 213)
    labels, count = ndi.label(mask)
    areas = np.bincount(labels.ravel())
    areas[0] = 0
    mask = ndi.binary_fill_holes(labels == areas.argmax())
    if kind == 'gold':
        # Restore the approved bulb's bright highlight, which touches its
        # silhouette and cannot be recovered by enclosed-hole filling alone.
        pts = np.argwhere(mask[:83])[:, ::-1]
        hull = ConvexHull(pts)
        restored = Image.fromarray(mask.astype('uint8') * 255)
        ImageDraw.Draw(restored).polygon([tuple(p) for p in pts[hull.vertices]], fill=255)
        mask = np.array(restored) > 0
    a[:, :, 3] = mask.astype('uint8') * 255
    a[a[:, :, 3] == 0, :3] = 0
    im = Image.fromarray(a)
    return im.crop(im.getchannel('A').getbbox())


# True neutral masks must stay neutral: runtime multiplies their colors.
for p in sorted(ORIGINAL.glob('Img_Game_Pattern*.png')):
    emit(p.stem, Image.open(p), str(p.relative_to(ROOT)), 'retained-white-runtime-tint-mask',
         'Preserve silhouette and white RGB; Widget_BoardCell supplies the region color and opacity.', retained=True)
for name in ['bg_Common_Rounded', 'bg_Game_Rounded', 'bg_Game_Circle']:
    emit(name, Image.open(ORIGINAL / (name + '.png')), 'Assets/Res_Runtime/UI/Game/' + name + '.png',
         'retained-neutral-shared-mask', 'Used for runtime tint, badges, focus, dimming and borders; do not bake a board color or warm outline into this shared mask.', retained=True)
emit('Img_Game_TutorialFinger', Image.open(ORIGINAL / 'Img_Game_TutorialFinger.png'),
     'Assets/Res_Runtime/UI/Game/Img_Game_TutorialFinger.png', 'retained-existing-hand-illustration',
     'Existing cream/brown illustrated pointer already matches; retain alpha, hotspot and original multiple-sprite rect x3 y0 width206 height236.', retained=True)

# Reconstructed empty background: cover crop, never distort the bakery motifs.
bg = masters['background']
target = tuple(specs['bg_Common_Game.png']['size'])
scale = max(target[0]/bg.width, target[1]/bg.height)
bg = bg.resize((round(bg.width*scale), round(bg.height*scale)), Image.Resampling.LANCZOS)
left = (bg.width-target[0])//2
bg = bg.crop((left, 0, left+target[0], target[1]))
emit('bg_Common_Game', bg, 'background_master.png', 'generated-clean-plate-cover-crop', 'No text/UI/canopy; fully opaque.')

base = clean_alpha(masters['base'])
base = fit(base, (351, 351), pad=2)
popup = nine(base, (351, 512), (80,80,80,80))
emit('bg_Common_Popup', popup, 'base_master.png', 'generated-empty-base-nine-slice', 'Original border x/y/z/w=80 preserved in manifest; no text.')
pill = clean_alpha(masters['hud'])
# Keep semicircular end geometry rather than stretching the whole capsule.
pill = fit(pill, (970,277), pad=2)
pill = nine(pill, (705,277), (138,45,138,45))
emit('bg_Game_HudBar', pill, 'hud_master.png', 'generated-empty-pill-resized-by-sections', 'No icons, count or life graphics baked in.')

# Horizontal buttons share the approved empty cream base, with warm/blue fills.
for name, rgb in [('btn_Common_Rounded_Yellow',(255,224,163)), ('btn_Game_Rounded_Blue',(174,205,228))]:
    # Match source corner radius to the target height before applying the
    # original 60px borders; a 512px source would pinch the curved sides.
    height = specs[name+'.png']['size'][1]
    button_base = fit(clean_alpha(masters['base']), (height,height), pad=2)
    im = nine(button_base, tuple(specs[name+'.png']['size']), (60,60,60,60))
    a = np.array(im).astype(float)
    a[:, :, :3] *= np.array(rgb)[None,None,:] / np.array([255,248,229])[None,None,:]
    im = Image.fromarray(np.clip(a,0,255).astype('uint8'))
    emit(name, im, 'base_master.png', 'clean-base-nine-slice-and-palette-normalization', 'No labels/icons; original 60px borders remain compatible.')

dogpath = THEME / 'assets/Sprite/hamster_idle_04__sharedassets2.assets__6.png'
dog = Image.open(dogpath).convert('RGBA')
for name in ['Img_Game_Hamster','Img_Game_HamsterCounter']:
    emit(name, dog.copy(), '../../Sprite/' + dogpath.name, 'reuse-approved-puppy', 'Approved 509x439 avatar, viewer-right patch, no additional clothing or face redesign.')

crossbox = (437,467,506,535)
cross = foreground(crossbox, 'pink')
emit('Img_Common_Cross', fit(cross,(88,89)), 'approved_master.png', 'approved-crop-alpha-isolation', source_rect=crossbox)
seedbox = (518,206,590,285)
life = foreground(seedbox, 'biscuit')
emit('Img_Common_Seed', fit(life,(95,128)), 'approved_master.png', 'approved-paw-biscuit-crop-alpha-isolation',
     'Theme content is a paw biscuit; keep legacy filename for future references.', seedbox)

# Back button is a complete circular button, not just an arrow.
back = masters['approved'].crop((35,80,130,177))
mask = Image.new('L',(back.width*4,back.height*4))
ImageDraw.Draw(mask).ellipse((7,5,back.width*4-8,back.height*4-5),fill=255)
back.putalpha(mask.resize(back.size,Image.Resampling.LANCZOS))
emit('Img_Common_Back', fit(back,(249,256)), 'approved_master.png', 'approved-button-crop-ellipse-alpha', source_rect=[35,80,130,177])

# Info-button artwork is not visible in approved page; reuse the existing glyph
# on a matching cream circular face, without adding any new behavior.
info_src = Image.open(ORIGINAL/'Img_Game_Help.png').convert('RGBA')
a=np.array(info_src); r,g,b=[a[:,:,i].astype(int) for i in range(3)]
mask=(r-g>25)&(g-b>15)&(g<160)&(a[:,:,3]>0)
labels,count=ndi.label(mask); areas=np.bincount(labels.ravel());areas[0]=0
mask=np.isin(labels,np.flatnonzero(areas>100))
arr=np.zeros_like(a); arr[:,:,:3]=(112,72,47);arr[:,:,3]=mask.astype('uint8')*255
glyph=Image.fromarray(arr);glyph=glyph.crop(glyph.getchannel('A').getbbox())
disc=masters['approved'].crop((35,80,130,177)).resize((253,255),Image.Resampling.LANCZOS)
# Fill the center with the blank cream base, preserving the cropped circle rim.
fill=clean_alpha(masters['base']).resize((192,192),Image.Resampling.LANCZOS)
disc.alpha_composite(fill,(30,31))
disc.putalpha(Image.open(ORIGINAL/'Img_Game_Help.png').getchannel('A'))
disc.alpha_composite(fit(glyph,(51,119)),(101,68))
emit('Img_Game_Help',disc,'approved_master.png + original info glyph + base_master.png','assembled-matching-info-button',
     'Not visible in approved page; existing information symbol retained, no text.')

# Extract one coherent high-resolution biscuit tile family; reassemble exact
# rule masks to avoid generative errors in the 3x3 cell semantics.
rule=masters['rule']
tile_boxes={'x':(107,115,454,462),'blank':(800,466,1147,813),'dog':(458,463,795,800)}
tiles={}
for key,box in tile_boxes.items():
    im=rule.crop(box).resize((347,347),Image.Resampling.LANCZOS)
    im.putalpha(rounded_mask(im.size,57,inset=1))
    tiles[key]=im
    im.save(WORK/('rule_tile_'+key+'.png'))
maps={
    'Img_Game_RuleRegion':['xxx','xdb','xbb'],
    'Img_Game_RuleLine':['bxb','xdx','bxb'],
    'Img_Game_RuleAdjacent':['xxx','xdx','xxx'],
}
for name,rows in maps.items():
    im=Image.new('RGBA',(478,478))
    for row,line in enumerate(rows):
        for col,ch in enumerate(line):
            key={'x':'x','b':'blank','d':'dog'}[ch]
            im.alpha_composite(tiles[key].resize((150,150),Image.Resampling.LANCZOS),(4+160*col,4+160*row))
    emit(name,im,'rule_master.png','reassembled-biscuit-rule-tiles',
         '3x3 exact map: '+ '/'.join(rows) + '; x=excluded, b=blank, d=dog. Transparent 10px gutters, 4px outside margin.')

auto=fit(tiles['x'],(218,218),pad=0).rotate(12,Image.Resampling.BICUBIC,expand=True)
emit('Img_Game_AutoMark',fit(auto,(245,256)), 'rule_master.png','cropped-x-biscuit-rotated',
     'Matches original tilted X tile function; distinct from magnifier and bulb.')

# Original Guide is bulb; original Hint is magnifier (legacy names differ
# from UI-facing labels). Each original sprite includes its cream button base.
toolbase=fit(clean_alpha(masters['base']),(114,118),pad=1)
for name,box,kind,area in [
    ('Img_Game_Hint',(310,1344,446,1468),'brown',(11,13,95,96)),
    ('Img_Game_Guide',(528,1348,613,1466),'gold',(24,15,67,94)),
]:
    icon=foreground(box,kind)
    im=toolbase.copy();x,y,w,h=area
    im.alpha_composite(fit(icon,(w,h),pad=0),(x,y))
    emit(name,im,'approved_master.png + base_master.png','approved-tool-foreground-on-clean-base',
         'No count badge, badge text or bottom TMP label baked into sprite.',box)
retry=Image.open(THEME/'assets/UI/Settings/Img_Settings_Restart.png').convert('RGBA')
emit('Img_Game_Retry',fit(retry,(175,188)), '../Settings/Img_Settings_Restart.png','reuse-existing-theme-retry',
     'Transparent arrow only, no circle background or text.')

assert len(records)==34
assert {r['file'] for r in records}==set(specs)
masters['approved'].resize((1080,1920),Image.Resampling.LANCZOS).save(WORK/'Panel_Game_Style_1080x1920.png')
manifest={
    'page':'Panel_Game','date':'2026-10-27','status':'sliced-offline-not-installed',
    'originalDirectory':'Assets/Res_Runtime/UI/Game','outputDirectory':str(OUT.relative_to(ROOT)),
    'approvedPage':'../../../previews/Game_Slicing/Panel_Game_Style_1080x1920.png',
    'generationTool':'built-in image_gen; Pillow/NumPy/SciPy for requested slicing, alpha isolation, normalization and assembly',
    'note':'Exactly 34 PNG matching original filenames and pixel sizes. Do not copy meta from this documentation folder. Existing production PNG/meta/prefab/scripts unchanged. Mask and pointer originals intentionally retained. Text and numeric badges remain separate TMP/UI elements. New clean plates and rule enlargement are reconstructed illustrations, not lossless cuts. Same-size assets preserve import compatibility but do not guarantee screenshot-identical runtime layout or color; shared tint masks stay white.',
    'assets':sorted(records,key=lambda r:r['file']),
}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf-8')
# Preserve the user-requested 2026-10-28 tool artwork when rerunning the full
# historical slicing script; normalize from the saved revision masters.
import runpy
runpy.run_path(str(THEME/'previews/Game_Tools_Revision_20261028/normalize_tools.py'), run_name='__main__')
print(json.dumps({'assets':len(records),'retainedOriginal':sum(r['retainedOriginal'] for r in records),'output':str(OUT)},ensure_ascii=False))
