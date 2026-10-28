"""Normalize generated sprites without redrawing; assemble offline review sheets."""
from pathlib import Path
import json, hashlib, shutil
from PIL import Image, ImageDraw, ImageFont

ROOT = Path(__file__).resolve().parents[6]
PREVIEW = Path(__file__).resolve().parent
ASSETS = ROOT / 'Docs/UILibrary/themes/PuppyBakery/assets/UI/Game/Patterns/v01'
ASSETS.mkdir(parents=True, exist_ok=True)
FONT = 'C:/Windows/Fonts/msyh.ttc'
def font(size):
    return ImageFont.truetype(FONT, size)
def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()
def tinted(icon, color, size):
    layer = Image.new('RGBA', icon.size, color)
    layer.putalpha(icon.getchannel('A'))
    layer.thumbnail(size, Image.Resampling.LANCZOS)
    return layer
rows = json.loads((PREVIEW/'prompts.json').read_text(encoding='utf-8'))
baseline=json.loads((PREVIEW/'baseline_hashes.json').read_text(encoding='utf-8'))
assert all(sha(ROOT/path)==digest for path,digest in baseline.items()), 'Protected runtime inputs changed; inspect before continuing.'
source_library=json.loads((ROOT/'Docs/UILibrary/manifest.json').read_text(encoding='utf-8'))
manifest = []
for row in rows:
    source = Path(row['source'])
    raw = PREVIEW/'generated'/f"{row['index']:02d}.png"
    raw.parent.mkdir(exist_ok=True)
    shutil.copyfile(source, raw)
    im = Image.open(raw).convert('RGBA')
    box = im.getchannel('A').getbbox()
    assert box, row
    crop = im.crop(box)
    original = ROOT/'Assets/Res_Runtime/UI/Game'/row['file']
    size = Image.open(original).size
    crop.thumbnail((max(1,round(size[0]*.90)),max(1,round(size[1]*.90))), Image.Resampling.LANCZOS)
    out = Image.new('RGBA',size)
    out.alpha_composite(crop,((size[0]-crop.width)//2,(size[1]-crop.height)//2))
    target = ASSETS/row['file']
    out.save(target)
    assert out.getchannel('A').getextrema()==(0,255), row['file']
    assert all(out.getpixel(p)[3]==0 for p in [(0,0),(0,size[1]-1),(size[0]-1,0),(size[0]-1,size[1]-1)])
    evidence=next(a for a in source_library['assets'] if a['name']==f"pattern_{row['index']}" and a['type']=='Sprite')
    manifest.append(dict(row, size=list(size), sha256=sha(target), originalEvidence=evidence['source'], originalSHA256=sha(original), originalMetaSHA256=sha(Path(str(original)+'.meta')), alphaRange=list(out.getchannel('A').getextrema()), sourceSize=list(im.size), method='alpha bounds crop, proportional downscale, transparent centered padding; no redraw'))

sheet = Image.new('RGB',(1440,790),'#FFF9EF')
d=ImageDraw.Draw(sheet)
d.text((30,20),'小狗面包房 · 12种区域图案与新配色',font=font(32),fill='#654A3A')
d.text((30,67),'美术候选 v01 · 白色透明PNG可统一染色 · 未接入Unity',font=font(19),fill='#856F60')
for row in rows:
    i=row['index']; x=30+(i%6)*235; y=115+(i//6)*305
    d.rounded_rectangle((x,y,x+215,y+245),18,fill=row['color'])
    icon=Image.open(ASSETS/row['file']).convert('RGBA')
    ink=tinted(icon,'#72513C',(92,92))
    sheet.paste(ink,(x+(215-ink.width)//2,y+35+(100-ink.height)//2),ink)
    d.text((x+14,y+158),f"{i:02d}  {row['name']}",font=font(24),fill='#513D34')
    d.text((x+14,y+199),row['color'],font=font(19),fill='#513D34')
    small=tinted(icon,'#72513C',(28,28))
    sheet.paste(small,(x+15,y+259),small)
    d.text((x+55,y+260),'28px辨识检查',font=font(16),fill='#856F60')
d.text((30,746),'图案编号沿用0—11；预览使用较深染色以便审图。实际运行透明度与布局另行验收。',font=font(20),fill='#856F60')
sheet.save(PREVIEW/'contact_sheet.png')

palette=Image.new('RGB',(1440,380),'#FFF9EF'); pd=ImageDraw.Draw(palette)
pd.text((30,18),'12色区域底色 · v01',font=font(30),fill='#654A3A')
for row in rows:
    i=row['index']; x=30+(i%6)*235; y=75+(i//6)*145
    pd.rounded_rectangle((x,y,x+215,y+95),12,fill=row['color'])
    pd.text((x+10,y+103),f"{i:02d}  {row['color']}",font=font(19),fill='#654A3A')
palette.save(PREVIEW/'palette.png')

# An explicitly offline arrangement, not a gameplay puzzle or Unity screenshot.
board=Image.new('RGB',(1140,920),'#FFF9EF'); bd=ImageDraw.Draw(board)
bd.text((30,18),'棋盘搭配预览 · 离线排布示意',font=font(30),fill='#654A3A')
bd.text((30,64),'左：当前运行染色参数    右：全部12种图案缩小检查',font=font(20),fill='#856F60')
regions=[[0,0,1,1,1,2,2,2,2],[0,0,0,1,1,2,2,2,3],[0,0,4,4,1,1,3,3,3],[5,4,4,4,4,1,3,3,3],[5,5,4,6,6,6,3,3,7],[5,5,5,6,6,6,6,7,7],[5,5,8,8,6,9,9,7,7],[8,8,8,8,9,9,9,9,7],[8,8,8,8,9,9,9,7,7]]
for y,line in enumerate(regions):
    for x,i in enumerate(line):
        row=rows[i]; left=30+x*70; top=120+y*70
        bd.rectangle((left,top,left+69,top+69),fill=row['color'])
        icon=Image.open(ASSETS/row['file']).convert('RGBA')
        rgb=tuple(round(int(row['color'][j:j+2],16)*.65) for j in (1,3,5))
        ink=tinted(icon,rgb,(28,28))
        ink.putalpha(ink.getchannel('A').point(lambda a:round(a*.26)))
        board.paste(ink,(left+(70-ink.width)//2,top+(70-ink.height)//2),ink)
for i,row in enumerate(rows):
    x=715+(i%3)*130; y=120+(i//3)*150
    bd.rounded_rectangle((x,y,x+112,y+110),12,fill=row['color'])
    icon=Image.open(ASSETS/row['file']).convert('RGBA')
    ink=tinted(icon,'#72513C',(32,32))
    board.paste(ink,(x+(112-ink.width)//2,y+(110-ink.height)//2),ink)
    bd.text((x,y+115),f"{i:02d} {row['name']}",font=font(16),fill='#654A3A')
bd.text((30,790),'示意图不代表可解关卡，也不是Unity运行截图。',font=font(22),fill='#856F60')
bd.text((30,830),'左侧复现现有0.65倍区域色、26%透明度，淡纹样实际可见性待接入验证。',font=font(20),fill='#856F60')
board.save(PREVIEW/'board_preview.png')

(ASSETS/'manifest.json').write_text(json.dumps({'status':'candidate-not-installed','date':'2026-10-28','tool':'built-in image_gen','preview':'../../../../../previews/Game_Patterns_v01/contact_sheet.png','assets':manifest},ensure_ascii=False,indent=2),encoding='utf-8')
(PREVIEW/'verification.json').write_text(json.dumps({'environment':'Windows; Pillow offline','count':len(manifest),'checks':['RGBA','original canvas sizes','nonempty alpha','alpha range 0..255','transparent corners','proportional resize','runtime PNG and meta hashes recorded'],'runtimeInstalled':False,'unityValidated':False,'assets':manifest},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'count':len(manifest),'assets':str(ASSETS),'review':str(PREVIEW/'contact_sheet.png')},ensure_ascii=False))
