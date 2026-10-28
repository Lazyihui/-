from pathlib import Path
import json,hashlib,re,shutil,csv
import numpy as np
from collections import deque
from PIL import Image,ImageDraw,ImageFont,ImageFilter

ROOT=Path('D:/UnityProject/Hamdoku2')
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
OUT=THEME/'assets/UI/Shop'
GEN=Path('C:/Users/Administrator/.codex/generated_images/01a1807d-07d6-7da0-9f33-7a9276b61ac9')
ORIG=Path('D:/0000001apkUnbag/01_逆向工程项目/Hamdoku2')
SOURCES={'clean':'exec-a1b0ef00-5bba-4a1e-aa31-dd64983ef22c.png','background':'exec-c9f9ab78-440f-4563-a71c-dc3f97e85eb2.png','panel':'exec-24c59772-aded-44c5-96c3-5ebb140124b3.png'}
for k,v in SOURCES.items():
    shutil.copy2(GEN/v,WORK/(k+'_master.png'))
approved=Image.open(OUT/'Panel_Shop_Style_v02_source.png').convert('RGBA')
clean=Image.open(WORK/'clean_master.png').convert('RGBA')
bg=Image.open(WORK/'background_master.png').convert('RGBA')
# All crop coordinates use native 941x1672 masters, rather than resized screenshot coordinates.
assert approved.size==clean.size==(941,1672)
specs={r['file']:r for r in json.loads((WORK/'original_inventory.json').read_text(encoding='utf-8'))}
records=[]
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def largest(mask):
    seen=np.zeros(mask.shape,dtype=bool);best=[];h,w=mask.shape
    for y,x in zip(*np.where(mask)):
        if seen[y,x]:continue
        q=deque([(y,x)]);seen[y,x]=True;component=[]
        while q:
            yy,xx=q.popleft();component.append((yy,xx))
            for ny,nx in [(yy-1,xx),(yy+1,xx),(yy,xx-1),(yy,xx+1)]:
                if 0<=ny<h and 0<=nx<w and mask[ny,nx] and not seen[ny,nx]:
                    seen[ny,nx]=True;q.append((ny,nx))
        if len(component)>len(best):best=component
    out=np.zeros(mask.shape,dtype=bool)
    if best:
        yy,xx=zip(*best);out[yy,xx]=True
    return out
def morph(mask,kind):
    im=Image.fromarray(mask.astype('uint8')*np.uint8(255))
    return np.array(im.filter(ImageFilter.MaxFilter(3) if kind=='dilate' else ImageFilter.MinFilter(3)))>0
def fill_holes(mask):
    im=Image.fromarray(np.pad(mask,1).astype('uint8')*np.uint8(255)).convert('RGB')
    ImageDraw.floodfill(im,(0,0),(127,127,127),thresh=0)
    return np.array(im)[1:-1,1:-1,0]!=127
def fit(im,size,pad=2):
    im=im.copy();ratio=min((size[0]-2*pad)/im.width,(size[1]-2*pad)/im.height)
    im=im.resize((round(im.width*ratio),round(im.height*ratio)),Image.Resampling.LANCZOS)
    out=Image.new('RGBA',size);out.alpha_composite(im,((size[0]-im.width)//2,(size[1]-im.height)//2));return out
def isolate(im,mode='structure',holes=True):
    a=np.array(im).astype('int16');r,g,b=a[:,:,0],a[:,:,1],a[:,:,2]
    if mode=='gold':mask=((r-g>14)&(g-b>22))|((r<170)&(g<125)&(b<100))
    elif mode=='blue':mask=(b-r>10)&(r<210)
    else:mask=((r<175)&(g<150)&(b<140))|((b-r>10)&(r<215))
    mask=morph(morph(mask,'dilate'),'erode')
    mask=largest(mask)
    if holes:mask=fill_holes(mask)
    mask=morph(mask,'dilate')
    alpha=Image.fromarray(mask.astype('uint8')*np.uint8(255)).filter(ImageFilter.GaussianBlur(.45))
    alpha_arr=np.array(alpha);alpha_arr[alpha_arr<12]=0
    im.putalpha(Image.fromarray(alpha_arr));box=im.getbbox()
    return im.crop(box)
def save(name,im,source,method,rect=None,size=None,border=None,note=None):
    old=specs.get(name)
    size=tuple(size or old['size'])
    if im.size!=size:im=fit(im,size)
    im=im.convert('RGBA');im.save(OUT/name)
    row=dict(file=name,size=list(size),mode='RGBA',source=source,method=method,sourceRect=rect,
        borderLTRB=border if border is not None else (old['borderLTRB'] if old else [0,0,0,0]),
        originalSprite=old['originalSprite'] if old else None,productionTarget='Assets/Res_Runtime/UI/Shop/'+name if old else None,
        sha256=sha(OUT/name),alphaBBox=list(im.getbbox()))
    if note:row['note']=note
    records.append(row);return im
def crop_icon(name,rect,mode='structure',holes=True,size=None,master=approved):
    return save(name,isolate(master.crop(rect),mode,holes),'approved-v02' if master==approved else 'clean_master.png','crop + silhouette alpha from new artwork + proportional fit',rect,size)

# Header and foreground symbols. All dynamic UI text is excluded.
crop_icon('shop_title_banner.png',(109,43,833,342),master=clean)
crop_icon('shop_remove_ads.png',(106,395,262,550),'blue')
crop_icon('shop_magnifier.png',(90,936,291,1140))
crop_icon('shop_hint.png',(124,1327,263,1510),'gold')
# The pale close-button rim is not reliably connected under color segmentation.
# Preserve the complete circular artwork, including the independent center X.
close=approved.crop((819,27,914,125))
cm=Image.new('L',(380,392));ImageDraw.Draw(cm).ellipse((8,8,372,384),fill=255)
close.putalpha(cm.resize(close.size,Image.Resampling.LANCZOS))
save('icon_close.png',close,'approved-v02','complete circular crop with ellipse alpha',[819,27,914,125])
crop_icon('icon_calendar.png',(181,621,254,693))
crop_icon('icon_infinity.png',(680,631,780,686),'blue',False)
crop_icon('shop_magnifier_small.png',(335,1001,407,1072),size=(128,128))

def rounded_crop(master,rect,radius):
    im=master.crop(rect);s=4;mask=Image.new('L',(im.width*s,im.height*s))
    ImageDraw.Draw(mask).rounded_rectangle((s,s,(im.width-1)*s,(im.height-1)*s),radius=radius*s,fill=255)
    im.putalpha(mask.resize(im.size,Image.Resampling.LANCZOS));return im

# Remove the lower price button from the tile base by assembling clean cream horizontal strips.
# Keep the blue/gold upper band independent of text/icons, preserving the original slicing contract.
def pad(name,rect,header):
    w,h=specs[name]['size'];top=119
    tile=clean.crop(rect)
    out=Image.new('RGBA',(w,h))
    band=tile.crop((24,8,tile.width-24,header-3)).resize((w,top),Image.Resampling.LANCZOS)
    body=tile.crop((8,header+8,tile.width-8,header+46)).resize((w,h-top),Image.Resampling.LANCZOS)
    out.alpha_composite(band,(0,0));out.alpha_composite(body,(0,top))
    mask=Image.new('L',(w*2,h*2));ImageDraw.Draw(mask).rounded_rectangle((4,4,(w-2)*2,(h-2)*2),radius=45*2,fill=255)
    out.putalpha(mask.resize((w,h),Image.Resampling.LANCZOS))
    return save(name,out,'clean_master.png','clean header/body strip assembly; lower price button delivered separately',list(rect),note='Original L/T/R/B 52/119/52/52 retained. Header occupies top 119 source pixels. No price/text/icon baked into tile.')
pad('shop_pad_ads.png',(104,560,337,764),51)
pad('shop_pad_magnifier.png',(309,940,476,1141),50)
pad('shop_pad_hint.png',(309,1309,477,1518),53)

blue=rounded_crop(clean,(118,700,325,755),16)
save('shop_btn_magnifier.png',blue.resize((408,160),Image.Resampling.LANCZOS),'clean_master.png','blank blue price button crop; corner-normalized', [118,700,325,755])
gold=rounded_crop(clean,(318,1452,467,1506),17)
save('shop_btn_hint.png',gold.resize((408,160),Image.Resampling.LANCZOS),'clean_master.png','blank gold price button crop; corner-normalized',[318,1452,467,1506],size=(408,160),border=[58,58,58,58])
for name,rect,size in [('shop_tab_magnifier.png',(85,810,325,880),(320,96)),('shop_tab_hint.png',(85,1178,297,1248),(288,96))]:
    im=rounded_crop(clean,rect,34)
    save(name,im.resize(size,Image.Resampling.LANCZOS),'clean_master.png','blank category tab crop',list(rect),size=size,border=[48,45,48,45])

# Section panel: sample original clean corner/edge patches, assemble at fixed pixels per corner.
# No legacy alpha masks, no brown fill outside rounded edges.
def panel_plate():
    im=Image.open(WORK/'panel_master.png').convert('RGBA')
    a=np.array(im.getchannel('A'));mask=largest(a>180)
    mask=fill_holes(mask);mask=morph(mask,'dilate')
    a[~mask]=0;im.putalpha(Image.fromarray(a))
    im=im.crop(im.getbbox());return fit(im,(256,256),2)
save('shop_section_panel.png',panel_plate(),'panel_master.png','image_gen blank panel reconstruction; isolated generated alpha, no legacy mask',size=(256,256),border=[44,44,44,44])
save('shop_background.png',bg.resize((1080,1920),Image.Resampling.LANCZOS),'background_master.png','image_gen background reconstruction; no top-edge canopy',size=(1080,1920))

# Tiny category glyphs are separate opaque-white masks, leaving translated tab labels as TMP.
for name,rect in [('shop_tab_paw.png',(108,829,156,865)),('shop_tab_bulb.png',(109,1190,154,1235))]:
    im=approved.crop(rect);a=np.array(im);mask=(a[:,:,0]>222)&(a[:,:,1]>222)&(a[:,:,2]>205)
    glyph=Image.new('RGBA',im.size,(255,250,237,0));glyph.putalpha(Image.fromarray((mask*255).astype('uint8')))
    save(name,fit(glyph,(64,64)),'approved-v02','isolated white category glyph alpha',list(rect),size=(64,64))

excluded=[r['file'] for r in specs.values() if r['file'] not in {r['file'] for r in records}]
manifest=dict(page='Panel_Shop',date='2026-10-28',status='sliced-offline-not-installed',approvedPage='Panel_Shop_Style_v02_1080x1920.png',designSize=[1080,1920],generationTool='built-in image_gen; Pillow/NumPy for user-authorized slicing, alpha isolation and assembly',
    note='Visible three sections only. Text, prices, duration and counts are separate TMP/L10N. ADS remains integral pictogram. Generated clean/background plates are reconstructions, not lossless crops. Matching names/sizes do not guarantee current Prefab layout, tint or runtime appearance. No meta files copied; no production resources changed.',
    excludedProductionImages=excluded,previewBorderDisplayScale={'shop_pad_*':0.35,'shop_btn_*':0.35,'shop_section_panel.png':1.0},integrationNotes=['Current production Prefab layout differs from approved mockup. New tabs, small magnifier and separate price buttons require explicit binding in a later authorized integration.','Calendar/infinity artwork is already blue; existing pink image tint must be neutralized during integration.','Tile and price-button offline nine-slice borders displayed at 0.35 source pixels; runtime PPU multiplier/layout must be calibrated in Unity, not assumed compatible from dimensions alone.','New background and section panel are page-local candidates; do not overwrite shared Game backgrounds.'],assets=records)
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf-8')

# Read-only original source evidence and recovered-method status, not gameplay claims.
index=ORIG/'03_code/decompiled_csharp/game-method-index.tsv'
lines=index.read_text(encoding='utf-8-sig').splitlines(); selected=[lines[0]]+[l for l in lines[1:] if '\tHamdoku.Managers.ShopPopup\t' in l and any('\t'+n+'\t' in l for n in ['Build','BuildBackground','BuildHeader','BuildItemCard','BuildAdsCard','MakeCard'])]
(WORK/'source_method_evidence.tsv').write_text('\n'.join(selected)+'\n',encoding='utf-8')
source_paths=[ORIG/'05_data/Configs/ShopPopupLayout__resources.assets__1493.json',ORIG/'03_code/decompiled_csharp/GameAssemblies/Hamdoku.Managers/ShopPopup.cs']
(WORK/'source_evidence.json').write_text(json.dumps(dict(originalPaths=[dict(path=str(p),sha256=sha(p)) for p in source_paths],recoveredCodeBoundary='Recovered pseudocode contains diagnostics. Used to locate dynamic assembly and separate text/image roles only; no original runtime validation performed.',existingPrefab='Assets/Res_Runtime/UI/Shop/Panel_Shop.prefab',productionImageCount=len(specs)),ensure_ascii=False,indent=2),encoding='utf-8')

font=ImageFont.truetype('C:/Windows/Fonts/msyh.ttc',18)
sheet=Image.new('RGB',(1200,((len(records)+3)//4)*260),'#e8e2d8');d=ImageDraw.Draw(sheet)
for i,r in enumerate(records):
    x=i%4*300;y=i//4*260
    # Checkerboard exposes actual alpha rather than a baked cream rectangle.
    for yy in range(0,200,16):
        for xx in range(0,288,16):d.rectangle((x+xx+6,y+yy+5,x+xx+21,y+yy+20),fill='#f6f4ef' if (xx//16+yy//16)%2 else '#d9d7d2')
    im=Image.open(OUT/r['file']);im.thumbnail((272,185))
    sheet.paste(im,(x+(300-im.width)//2,y+8+(185-im.height)//2),im)
    d.text((x+7,y+208),r['file'],font=font,fill='#443224')
    d.text((x+7,y+233),str(r['size'])+' RGBA',font=font,fill='#443224')
sheet.save(WORK/'contact_sheet_v01.png')
print('Saved',len(records),'assets; excluded',excluded)
