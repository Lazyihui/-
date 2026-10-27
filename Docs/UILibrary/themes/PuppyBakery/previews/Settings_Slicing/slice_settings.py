from pathlib import Path
import json, hashlib, shutil
import numpy as np
from PIL import Image, ImageDraw, ImageFont, ImageFilter
from scipy import ndimage as ndi

ROOT = Path(__file__).resolve().parents[6]
THEME = ROOT / 'Docs/UILibrary/themes/PuppyBakery'
WORK = Path(__file__).resolve().parent
OUT = THEME / 'assets/UI/Settings'
OUT.mkdir(parents=True, exist_ok=True)
GEN = Path('C:/Users/Administrator/.codex/generated_images/01a17ca9-ac58-77e0-bbe8-9fa8a10744ea')
sources = {'approved': 'exec-f5862f4a-8f3a-480a-befd-b348255bdbf4.png', 'structure': 'exec-ab5a7222-9fe6-4414-98f2-565118e2a6d2.png', 'icons': 'exec-bfca7d51-34b6-4cb1-8ee6-46c46c76e626.png'}
for key, name in sources.items():
    shutil.copy2(GEN / name, WORK / (key + '_master.png'))
masters = {key: Image.open(WORK / (key + '_master.png')).convert('RGBA') for key in sources}
records = []

def isolate(im, multiple=False):
    a = np.array(im)
    rgb = a[:, :, :3].astype(float)
    # Reject generated transparent-edge white speckles and saturated RGB fringe.
    mask = (a[:, :, 3] > 160) & (rgb.min(2) < 246) & ((rgb.max(2)-rgb.min(2)) < 155)
    mask = ndi.binary_opening(mask)
    labels, _ = ndi.label(mask)
    sizes = np.bincount(labels.ravel()); sizes[0] = 0
    selected = sizes >= max(35, sizes.max() * (0.035 if multiple else 0.9))
    selected[0] = False
    mask = ndi.binary_fill_holes(selected[labels])
    mask = ndi.binary_closing(mask, iterations=2)
    a[:, :, 3] = np.minimum(a[:, :, 3], np.uint8(mask) * 255)
    a[a[:, :, 3] == 0, :3] = 0
    result = Image.fromarray(a)
    box = result.getchannel('A').getbbox()
    if not box:
        raise ValueError('Empty crop')
    return result.crop(box)

def emit(name, source, box, size=None, border=None, multiple=False):
    if name == 'Img_Settings_Knob':
        im=masters[source].crop(box)
        mask=Image.new('L',(im.width*4,im.height*4)); ImageDraw.Draw(mask).ellipse((3,3,im.width*4-3,im.height*4-3),fill=255)
        im.putalpha(mask.resize(im.size,Image.Resampling.LANCZOS))
    elif name in ['Img_Settings_Separator','Img_Settings_DividerPaw']:
        a=np.array(masters[source].crop(box))
        mask=(a[:,:,0]<251)&(a[:,:,1]<225)&(a[:,:,2]<200)&(a[:,:,0].astype(int)-a[:,:,1]>12)
        a[:,:,3]=mask.astype('uint8')*255
        a[a[:,:,3]==0,:3]=0
        im=Image.fromarray(a)
    else:
        im = isolate(masters[source].crop(box), multiple)
    if size:
        scale=min((size[0]-4)/im.width,(size[1]-4)/im.height)
        im=im.resize((round(im.width*scale),round(im.height*scale)),Image.Resampling.LANCZOS)
        canvas = Image.new('RGBA', size)
        canvas.alpha_composite(im, ((size[0]-im.width)//2, (size[1]-im.height)//2))
        im = canvas
    else:
        canvas = Image.new('RGBA', (im.width+4, im.height+4)); canvas.alpha_composite(im, (2, 2)); im = canvas
    im.save(OUT / (name + '.png'))
    records.append({'file': name + '.png', 'size': list(im.size), 'mode': 'RGBA', 'source': source+'_master.png', 'sourceRect': list(box), 'borderLTRB': border or [0,0,0,0], 'sha256': hashlib.sha256((OUT/(name+'.png')).read_bytes()).hexdigest()})
    return im

emit('Img_Settings_Panel', 'structure', (45,65,417,555), border=[65,65,65,65])
emit('Img_Settings_Title', 'structure', (425,175,823,460))
emit('Img_Settings_ButtonRestart', 'structure', (830,250,1235,410), border=[95,40,95,40])
emit('Img_Settings_ButtonTutorial', 'structure', (15,675,445,845), border=[95,40,95,40])
emit('Img_Settings_TrackOn', 'structure', (455,680,798,840), size=(224,96))
emit('Img_Settings_TrackOff', 'structure', (860,680,1235,840), size=(224,96))
emit('Img_Settings_Knob', 'approved', (770,344,830,404), size=(76,76))
emit('Img_Settings_Selector', 'structure', (425,965,835,1145), border=[75,30,75,30])
emit('Img_Settings_Close', 'structure', (910,925,1155,1175), size=(116,116))
names = ['Sound','Music','Voice','Vibration','RegionBorder','Pattern','Language','ArrowLeft','ArrowRight','Support','Privacy','Terms','Restart','Tutorial','PawPeach','PawBlue']
boxes = [(70,90,340,355),(365,90,635,355),(660,90,930,355),(950,90,1225,355),
         (70,395,340,655),(365,395,635,655),(660,395,930,655),(1020,450,1155,620),
         (130,745,250,920),(390,735,610,930),(685,715,900,945),(1005,715,1190,945),
         (80,990,285,1195),(365,995,625,1195),(695,1000,895,1190),(1005,1000,1210,1190)]
for i, (name, box) in enumerate(zip(names, boxes)):
    emit('Img_Settings_'+name, 'icons', box, size=((100,100) if i<7 else (76,76)), multiple=(i>=14))

# Keep the approved page separators rather than generating a replacement style.
emit('Img_Settings_Separator', 'approved', (100,429,841,436), multiple=True)
emit('Img_Settings_DividerPaw', 'approved', (82,1132,858,1169), multiple=True)
bg = Image.open(THEME/'assets/UI/Logo/bg_Common_Menu.png').convert('RGBA')
bg = bg.resize((1080,1920), Image.Resampling.LANCZOS)
bg.save(OUT/'Bg_Settings.png')
records.append({'file':'Bg_Settings.png','size':[1080,1920],'mode':'RGBA','source':'../Logo/bg_Common_Menu.png','borderLTRB':[0,0,0,0],'sha256':hashlib.sha256((OUT/'Bg_Settings.png').read_bytes()).hexdigest()})
masters['approved'].resize((1080,1920),Image.Resampling.LANCZOS).convert('RGB').save(OUT/'Panel_Settings_Style_1080x1920.png')

def nine(im, size, b):
    w,h=im.size; tw,th=size; l,t,r,bt=b
    out=Image.new('RGBA',size)
    xs=[0,l,w-r,w]; ys=[0,t,h-bt,h]; dx=[0,l,tw-r,tw]; dy=[0,t,th-bt,th]
    for y in range(3):
        for x in range(3):
            tile=im.crop((xs[x],ys[y],xs[x+1],ys[y+1]))
            tile=tile.resize((dx[x+1]-dx[x],dy[y+1]-dy[y]),Image.Resampling.LANCZOS)
            out.alpha_composite(tile,(dx[x],dy[y]))
    return out

assets={r['file'][:-4]:Image.open(OUT/r['file']).convert('RGBA') for r in records}
page=bg.copy(); layout=[]
def put(key, box, sliced=False):
    x,y,w,h=box; im=assets[key]; rec=next(r for r in records if r['file']==key+'.png')
    if sliced:
        im=nine(im,(w,h),rec['borderLTRB'])
    elif key in ['Img_Settings_Separator','Img_Settings_DividerPaw','Img_Settings_TrackOn','Img_Settings_TrackOff','Img_Settings_Selector']:
        im=im.resize((w,h),Image.Resampling.LANCZOS)
    else:
        im=im.copy(); im.thumbnail((w,h),Image.Resampling.LANCZOS)
        x+=(w-im.width)//2; y+=(h-im.height)//2
    page.alpha_composite(im,(x,y)); layout.append({'asset':key+'.png','rectXYWH':list(box),'sliced':sliced})
put('Img_Settings_Panel',(60,325,960,1520),True)
put('Img_Settings_Title',(335,100,410,245))
put('Img_Settings_Close',(925,115,116,116))
fontpath='C:/Windows/Fonts/msyhbd.ttc'
font=ImageFont.truetype(fontpath,44); small=ImageFont.truetype('C:/Windows/Fonts/msyh.ttc',29)
def text(s,xy, f=font, color='#533729',anchor='lm'):
    ImageDraw.Draw(page).text(xy,s,font=f,fill=color,anchor=anchor)
text('设置',(540,288),ImageFont.truetype(fontpath,58),anchor='mm')
labels=['音效','音乐','连击语音','震动','区域边框','图案','语言']
for i,(name,label) in enumerate(zip(names[:7],labels)):
    y=380+i*132
    put('Img_Settings_'+name,(115,y,100,100));text(label,(254,y+50))
    if i in [0,1,3,4,5]:
        active=i!=4;put('Img_Settings_TrackOn' if active else 'Img_Settings_TrackOff',(740,y+14,224,76))
        put('Img_Settings_Knob',((884 if active else 747),y+21,62,62))
        text('ON' if active else 'OFF',((794 if active else 902),y+52),ImageFont.truetype(fontpath,29),'#fffaf0',anchor='mm')
    elif i==2:
        put('Img_Settings_Selector',(708,y+14,256,76))
        put('Img_Settings_ArrowLeft',(720,y+32,28,40));put('Img_Settings_ArrowRight',(925,y+32,28,40));text('男声',(835,y+52),small,anchor='mm')
    else:
        text('简体中文',(878,y+52),small,anchor='rm');put('Img_Settings_ArrowRight',(925,y+32,28,40))
    if i<6:
        put('Img_Settings_Separator',(118,y+116,846,3))
put('Img_Settings_DividerPaw',(100,1284,880,35))
for name,y,label in [('ButtonRestart',1335,'重新开始'),('ButtonTutorial',1490,'游戏教程')]:
    put('Img_Settings_'+name,(112,y,856,132),True);text(label,(540,y+66),ImageFont.truetype(fontpath,50),anchor='mm')
for name,x,label in [('Support',116,'客服'),('Privacy',421,'隐私政策'),('Terms',743,'服务条款')]:
    put('Img_Settings_'+name,(x,1674,60,60));text(label,(x+73,1704),small)
text('v1.2.2',(962,1797),ImageFont.truetype(fontpath,25),anchor='rm')
page.save(WORK/'page_layers_reassembled_1080x1920.png')

sheet=Image.new('RGB',(1200,((len(records)+3)//4)*205),'#e2e2e2');d=ImageDraw.Draw(sheet)
for i,r in enumerate(records):
    x=(i%4)*300;y=(i//4)*205
    for cy in range(y,y+165,15):
        for cx in range(x,x+300,15):
            d.rectangle((cx,cy,cx+14,cy+14),fill=('#ddd' if ((cx-x)//15+(cy-y)//15)%2 else '#fff'))
    im=assets[r['file'][:-4]].copy();im.thumbnail((270,145),Image.Resampling.LANCZOS)
    sheet.paste(im,(x+(300-im.width)//2,y+(165-im.height)//2),im)
    d.text((x+8,y+168),r['file'].replace('Img_Settings_',''),fill='#35271d',font=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',14))
    d.text((x+8,y+187),str(r['size']),fill='#35271d')
sheet.save(WORK/'contact_sheet_v01.png')
manifest={'page':'Panel_Settings','date':'2026-10-27','status':'sliced-offline-not-integrated','designSize':[1080,1920],'generationTool':'built-in image_gen','approvedPage':'Panel_Settings_Style_1080x1920.png','sourceEvidence':['../../../../../PrefabCollection/OriginalConfigs/SettingsPopupLayout__resources.assets__1491.json','../../../../../references/original/settings.png'],'note':'No settings prefab/runtime installed. Generated clean plates are reconstructed, not lossless crops. Text stays TMP/L10N, tracks and knob separate. borderLTRB is proposed Unity slicing in source pixels, requires import and runtime verification. Original config sizes are evidence, new visual sizes are implementation proposals. Background reuses Logo source. Preview text is offline only.','assets':records}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf-8')
(WORK/'layout_reference.json').write_text(json.dumps({'canvas':[1080,1920],'origin':'top-left','elements':layout,'text':'Preview only; bind TMP and L10N during implementation.'},ensure_ascii=False,indent=2),encoding='utf-8')
checks=[]
for r in records:
    im=Image.open(OUT/r['file']);a=np.array(im)
    checks.append({'file':r['file'],'size':list(im.size),'mode':im.mode,'alphaBounds':im.getchannel('A').getbbox(),'transparentPixels':int((a[:,:,3]==0).sum()),'nonempty':bool(a[:,:,3].max()),'edgeClear':bool(not np.any(a[0,:,3]) and not np.any(a[-1,:,3]) and not np.any(a[:,0,3]) and not np.any(a[:,-1,3])) if r['file']!='Bg_Settings.png' else None})
(WORK/'verification.json').write_text(json.dumps({'environment':'Windows / Python / Pillow / NumPy / SciPy','checks':checks,'unityCompile':'not run','playMode':'not run','addressablesBuild':'not run','appBuild':'not run','device':'not run'},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'output':str(OUT),'count':len(records),'empty':[c['file'] for c in checks if not c['nonempty']],'opaqueSprite':[c['file'] for c in checks if c['file']!='Bg_Settings.png' and c['transparentPixels']==0]},ensure_ascii=False))
