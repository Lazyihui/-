from pathlib import Path
import json
import hashlib
import re
import sys
import numpy as np
from PIL import Image, ImageDraw, ImageFont, ImageChops
from scipy import ndimage as ndi

ROOT=Path(__file__).resolve().parents[6]
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
OUT=THEME/'assets/UI/Game'
ORIGINAL=ROOT/'Assets/Res_Runtime/UI/Game'
manifest=json.loads((OUT/'manifest.json').read_text(encoding='utf-8'))
original=json.loads((WORK/'original_inventory.json').read_text(encoding='utf-8'))
assets={p.stem:Image.open(p).convert('RGBA') for p in OUT.glob('*.png')}
fontpath='C:/Windows/Fonts/msyh.ttc'
latin=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',14)


def nine(im,size,b):
    w,h=im.size;tw,th=size;l,t,r,bt=b
    out=Image.new('RGBA',size)
    xs=[0,l,w-r,w];ys=[0,t,h-bt,h];dx=[0,l,tw-r,tw];dy=[0,t,th-bt,th]
    for y in range(3):
        for x in range(3):
            q=im.crop((xs[x],ys[y],xs[x+1],ys[y+1]))
            out.alpha_composite(q.resize((dx[x+1]-dx[x],dy[y+1]-dy[y]),Image.Resampling.LANCZOS),(dx[x],dy[y]))
    return out


def tint(im,color):
    fill=Image.new('RGBA',im.size,color)
    return ImageChops.multiply(im,fill)


files=sorted(OUT.glob('*.png'))
sheet=Image.new('RGB',(1200,((len(files)+3)//4)*210),'white')
d=ImageDraw.Draw(sheet)
for i,f in enumerate(files):
    x=i%4*300;y=i//4*210
    for yy in range(y,y+165,15):
        for xx in range(x,x+300,15):
            d.rectangle((xx,yy,xx+14,yy+14),fill='#ddd' if (xx//15+yy//15)%2 else '#fff')
    im=assets[f.stem].copy();im.thumbnail((270,150),Image.Resampling.LANCZOS)
    sheet.paste(im,(x+(300-im.width)//2,y+(165-im.height)//2),im)
    d.text((x+4,y+168),f.name,fill='#34251f',font=latin)
    d.text((x+4,y+190),str(assets[f.stem].size),fill='black')
sheet.save(WORK/'contact_sheet_v01.png')

# Use actual RuleBanner/card/icon sizes from the current prefab. Text is only
# an offline illustration of the separate TMP layer, not part of the sprites.
strip=Image.new('RGBA',(920,128))
strip.alpha_composite(tint(nine(assets['bg_Common_Rounded'],(920,128),(16,16,16,16)),(255,250,242,255)))
for i,(name,label) in enumerate([('Region','每色一只小狗'),('Line','每行每列各一只'),('Adjacent','小狗不可相邻')]):
    x=17+298*i
    strip.alpha_composite(tint(nine(assets['bg_Common_Rounded'],(290,102),(16,16,16,16)),(245,236,227,255)),(x,13))
    strip.alpha_composite(assets['Img_Game_Rule'+name].resize((82,82),Image.Resampling.LANCZOS),(x+10,23))
    ImageDraw.Draw(strip).text((x+100,64),label,font=ImageFont.truetype(fontpath,24),fill='#593e2d',anchor='lm')
strip.save(WORK/'rule_strip_920x128.png')
strip.resize((1840,256),Image.Resampling.LANCZOS).save(WORK/'rule_strip_detail_2x.png')

# Screen assembled from the deliverable sprites. Coordinates reproduce the
# chosen design for offline inspection, not a runtime or prefab screenshot.
page=assets['bg_Common_Game'].copy()
scale=max(1080/page.width,1920/page.height)
page=page.resize((round(page.width*scale),round(page.height*scale)),Image.Resampling.LANCZOS)
page=page.crop(((page.width-1080)//2,(page.height-1920)//2,(page.width+1080)//2,(page.height+1920)//2))
layout=[]


def put(name,box):
    x,y,w,h=box
    page.alpha_composite(assets[name].resize((w,h),Image.Resampling.LANCZOS),(x,y))
    layout.append(dict(asset=name+'.png',box=list(box)))


def text(value,xy,size=42,anchor='mm',color='#513322'):
    ImageDraw.Draw(page).text(xy,value,font=ImageFont.truetype(fontpath,size),fill=color,anchor=anchor)


put('Img_Common_Back',(40,92,108,111))
text('关卡17',(397,148),49);text('分数576',(642,148),49)
# The shop/settings assets are outside Game and outside this deliverable.
master=Image.open(WORK/'approved_master.png').convert('RGBA')
for box,xy in [((710,79,811,178),(815,91)),((811,79,913,178),(931,91))]:
    piece=master.crop(box).resize((116,114),Image.Resampling.LANCZOS)
    mask=Image.new('L',piece.size);ImageDraw.Draw(mask).ellipse((3,2,113,112),fill=255);piece.putalpha(mask)
    page.alpha_composite(piece,xy)
put('bg_Game_HudBar',(192,228,340,107));put('bg_Game_HudBar',(549,228,340,107))
put('Img_Game_HamsterCounter',(251,243,104,90));text('1/9',(446,284),53)
for x in [594,685,776]:put('Img_Common_Seed',(x+8,237,65,88))
page.alpha_composite(strip.resize((976,136),Image.Resampling.LANCZOS),(52,359))

# Palette and exact irregular region map from approved design.
region_rows=['AAAAAAAAD','ABBAAADAD','BBAADDDAD','BBCCCDDDD','BBBBCDEEE','FCCCCDDDG','FFFFCCGGG','CCCCCGGGH','IICCCCGHH']
palette={'A':'#7b89d7','B':'#f5ae5d','C':'#54bfb1','D':'#f2d16b','E':'#8acee0','F':'#b58cda','G':'#df88bd','H':'#b5cf69','I':'#ee9e8f'}
frame=nine(assets['bg_Common_Rounded'],(976,976),(16,16,16,16))
frame=tint(frame,(255,250,240,255));page.alpha_composite(frame,(52,507))
for row,line in enumerate(region_rows):
    for col,region in enumerate(line):
        tile=nine(assets['bg_Game_Rounded'],(100,100),(16,16,16,16))
        tile=tint(tile,palette[region])
        page.alpha_composite(tile,(69+105*col,524+105*row))
for row,col in [(0,4),(2,3),(5,3),(6,6),(7,1),(7,5),(8,4),(8,5),(8,7),(8,8)]:
    put('Img_Common_Cross',(88+105*col,543+105*row,63,64))
put('Img_Game_Hamster',(69+105*3+3,524+105*3+10,94,81))
put('Img_Game_Hint',(335,1527,180,186));put('Img_Game_Guide',(565,1527,180,186))
for x,num in [(503,'2'),(733,'3')]:
    disc=tint(assets['bg_Game_Circle'].resize((58,58),Image.Resampling.LANCZOS),(255,100,83,255))
    page.alpha_composite(disc,(x-29,1507));text(num,(x,1536),35,color='white')
text('自动标记',(425,1740),34);text('提示',(655,1740),34)
ad=Image.new('RGBA',(1040,164),'#e6ddc7');mask=Image.new('L',ad.size);ImageDraw.Draw(mask).rounded_rectangle((0,0,1039,163),radius=40,fill=255);ad.putalpha(mask)
page.alpha_composite(ad,(20,1770));text('底部横幅广告位 · 不加载广告',(540,1845),27,color='#99876b')
page.save(WORK/'page_layers_reassembled_1080x1920.png')
(WORK/'layout_reference.json').write_text(json.dumps(dict(designSize=[1080,1920],origin='top-left',note='Offline sprite assembly for visual QA only. Shop/settings button crops are reference only; not new Game assets. Text uses Windows Microsoft YaHei, not runtime TMP. Original runtime coordinates, tint and animation require separate integration.',elements=layout),ensure_ascii=False,indent=2),encoding='utf-8')

checks=[]
for r in original:
    file=r['file'];im=Image.open(OUT/file);a=np.array(im.convert('RGBA'))
    retained=next(c for c in manifest['assets'] if c['file']==file)['retainedOriginal']
    labels,count=ndi.label(a[:,:,3]>128);areas=np.bincount(labels.ravel());areas[0]=0
    significant=int((areas>20).sum())
    checks.append(dict(file=file,size=list(im.size),originalSize=r['size'],sizeMatches=list(im.size)==r['size'],mode=im.mode,alphaBounds=im.getchannel('A').getbbox(),transparentPixels=int((a[:,:,3]==0).sum()),nonempty=bool(a[:,:,3].max()),significantAlphaComponents=significant,retainedOriginal=retained,retainedBytesMatch=(hashlib.sha256((OUT/file).read_bytes()).hexdigest()==r['sha256']) if retained else None,productionPngUnchanged=hashlib.sha256((ORIGINAL/file).read_bytes()).hexdigest()==r['sha256'],productionMetaUnchanged=hashlib.sha256((ORIGINAL/(file+'.meta')).read_bytes()).hexdigest()==r['metaSha256']))
names={r['file'] for r in original}
result=dict(date='2026-10-27',environment=dict(platform='Windows',python=sys.version.split()[0],libraries=['Pillow','NumPy','SciPy']),count=len(files),checks=checks,exactFilenameSet={p.name for p in files}==names,noCopiedMeta=not bool(list(OUT.glob('*.meta'))),ruleMaps={'Region':['xxx','xdb','xbb'],'Line':['bxb','xdx','bxb'],'Adjacent':['xxx','xdx','xxx']},neutralMaskCount=15,nativeRuleIconSize=[82,82],originalBordersPreservedInManifest=True,unityCompile='not run: images only, no installation',playMode='not run',addressablesBuild='not run',applicationBuild='not run',deviceValidation='not run',limitations=['Clean plates and enlarged biscuit rules reconstructed through image_gen, not lossless crops.','Same dimensions/sprite borders do not guarantee runtime palette/layout identical to approved preview.','12 assist patterns, 3 neutral UI masks and the existing pointer deliberately retain original files.'])
result['passed']=result['exactFilenameSet'] and result['noCopiedMeta'] and all(c['sizeMatches'] and c['nonempty'] and c['mode']=='RGBA' and c['productionPngUnchanged'] and c['productionMetaUnchanged'] and (c['retainedBytesMatch'] is not False) for c in checks)
(WORK/'verification.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(dict(passed=result['passed'],count=len(files),issues=[c['file'] for c in checks if not c['sizeMatches'] or not c['productionPngUnchanged'] or not c['productionMetaUnchanged']],contactSheet=str(WORK/'contact_sheet_v01.png')),ensure_ascii=False))
assert result['passed']
