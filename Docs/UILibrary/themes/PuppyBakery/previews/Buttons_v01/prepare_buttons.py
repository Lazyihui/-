from pathlib import Path
import json,re,hashlib,shutil
import numpy as np
from scipy import ndimage as ndi
from PIL import Image,ImageDraw,ImageFont

ROOT=Path(__file__).resolve().parents[6]
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
OUT=THEME/'assets/UI/Buttons/v01'
OUT.mkdir(parents=True,exist_ok=True)
UI=ROOT/'Assets/Res_Runtime/UI'
GEN=Path('C:/Users/Administrator/.codex/generated_images/01a17ca9-ac58-77e0-bbe8-9fa8a10744ea')
GENFILES={'honey':'exec-e891a62c-1570-4ec4-94ad-4e76b90e4153.png','blue':'exec-67846465-538b-4185-ac8b-8fbf8def1a35.png','cream':'exec-ab151582-800b-4ab5-a936-2c0021cdb9b8.png','peach':'exec-af640940-56b1-453f-ba06-b283446e0b63.png','pink':'exec-2e0f1f39-9921-4e3c-ae36-fc69adae8420.png','coral':'exec-270a7412-76c4-4c89-a6cb-c9eb9a99370b.png'}
SPECS={'Game/btn_Common_Rounded_Yellow.png':'honey','Game/btn_Game_Rounded_Blue.png':'blue','Home/btn_Home_Endless.png':'peach','Home/btn_Home_Level.png':'honey','Home/btn_Home_Level_Hard.png':'coral','Home/btn_Home_Play.png':'cream','Ranking/btn_Ranking_Pill_Cream.png':'cream','Ranking/btn_Ranking_Pill_Orange.png':'honey','Shop/shop_btn_magnifier.png':'blue','Shop/shop_btn_pink.png':'pink','Shop/shop_btn_special_offer.png':'honey','Streak/btn_Streak_Continue.png':'honey'}
sha=lambda p:hashlib.sha256(p.read_bytes()).hexdigest()
before={str(p.relative_to(UI)):sha(p) for p in UI.rglob('*') if p.is_file()}

def clean(im,multiple=False):
    a=np.array(im.convert('RGBA'));rgb=a[:,:,:3].astype(int)
    mask=(a[:,:,3]>160)&(rgb.min(2)<247)&((rgb.max(2)-rgb.min(2))<155)
    lab,_=ndi.label(ndi.binary_opening(mask));counts=np.bincount(lab.ravel());counts[0]=0
    keep=counts>=max(30,counts.max()*(0.03 if multiple else 0.90));keep[0]=False
    mask=ndi.binary_fill_holes(keep[lab])
    a[:,:,3]=np.minimum(a[:,:,3],np.uint8(mask)*255);a[a[:,:,3]==0,:3]=0
    out=Image.fromarray(a);return out.crop(out.getchannel('A').getbbox())

def nine(im,size,border,outborder=None):
    l,t,r,b=map(float,border);w,h=im.size;tw,th=map(int,size)
    dl,dt,dr,db=border if outborder is None else outborder
    if dl+dr>tw:
        s=tw/(dl+dr);dl*=s;dr*=s
    if dt+db>th:
        s=th/(dt+db);dt*=s;db*=s
    sx=list(map(round,[0,l,w-r,w]));sy=list(map(round,[0,t,h-b,h]))
    dx=list(map(round,[0,dl,tw-dr,tw]));dy=list(map(round,[0,dt,th-db,th]))
    result=Image.new('RGBA',(tw,th))
    for y in range(3):
        for x in range(3):
            dw=dx[x+1]-dx[x];dh=dy[y+1]-dy[y]
            if dw>0 and dh>0 and sx[x+1]>sx[x] and sy[y+1]>sy[y]:
                tile=im.crop((sx[x],sy[y],sx[x+1],sy[y+1])).resize((dw,dh),Image.Resampling.LANCZOS)
                result.alpha_composite(tile,(dx[x],dy[y]))
    return result

masters={}
for color,file in GENFILES.items():
    shutil.copy2(GEN/file,WORK/(color+'_master.png'))
    masters[color]=clean(Image.open(GEN/file))
icon_master=Image.open(THEME/'previews/Settings_Slicing/icons_master.png').convert('RGBA')
paws={'warm':clean(icon_master.crop((695,1000,895,1190)),True),'cool':clean(icon_master.crop((1005,1000,1210,1190)),True)}
for n,paw in paws.items():paw.save(WORK/(n+'_paw_source.png'))

# Read real consumers without modifying Prefabs or importer settings.
guidmap={re.search(r'^guid: (\w+)',(UI/path).with_suffix('.png.meta').read_text(encoding='utf-8'),re.M).group(1):path for path in SPECS}
consumers={p:[] for p in SPECS}
for prefab in UI.rglob('*.prefab'):
    blocks=re.split(r'--- !u!',prefab.read_text(encoding='utf-8'));rects={};objects={}
    for block in blocks:
        go=re.search(r'm_GameObject: \{fileID: (\d+)\}',block)
        if block.startswith('224 ') and go:
            size=re.search(r'm_SizeDelta: \{x: ([\d.-]+), y: ([\d.-]+)\}',block)
            if size:rects[go.group(1)]=[float(x) for x in size.groups()]
        if block.startswith('1 '):
            bid=re.search(r'1 &(\d+)',block);name=re.search(r'  m_Name: (.*)',block)
            if bid:objects[bid.group(1)]=name.group(1) if name else '?'
    for block in blocks:
        sprite=re.search(r'm_Sprite: \{fileID: [^,]+, guid: (\w+)',block);go=re.search(r'm_GameObject: \{fileID: (\d+)\}',block)
        if sprite and go and sprite.group(1) in guidmap:
            typ=re.search(r'm_Type: (\d+)',block);ppum=re.search(r'm_PixelsPerUnitMultiplier: ([\d.]+)',block)
            consumers[guidmap[sprite.group(1)]].append({'prefab':str(prefab.relative_to(ROOT)),'object':objects.get(go.group(1)),'size':rects.get(go.group(1)),'imageType':int(typ.group(1)) if typ else 0,'pixelsPerUnitMultiplier':float(ppum.group(1)) if ppum else 1})

records=[]
for path,color in SPECS.items():
    original=Image.open(UI/path).convert('RGBA');w,h=original.size
    meta=(UI/path).with_suffix('.png.meta').read_text(encoding='utf-8')
    border=[float(v) for v in re.search(r'spriteBorder: \{x: ([\d.]+), y: ([\d.]+), z: ([\d.]+), w: ([\d.]+)\}',meta).groups()]
    art=masters[color];sb=round(art.height*0.47);db=round((h-4)*0.27)
    core=nine(art,(w-4,h-4),[sb]*4,[db]*4)
    result=Image.new('RGBA',(w,h));result.alpha_composite(core,(2,2))
    sliced=any(c['imageType']==1 for c in consumers[path])
    if sliced:
        bx=min(round(h*.65),w//3);top=h//2-1;bottom=h-top-1
        proposed=[bx,top,bx,bottom]
        px=round(bx*.43)
    else:
        proposed=border;px=round(w*.10)
    paw=paws['cool' if color=='blue' else 'warm'].copy()
    ph=round(h*.23);scale=ph/paw.height
    paw_width=round(paw.width*scale)
    simple_compensation=1.0
    if not sliced and consumers[path]:
        display=consumers[path][0]['size']
        if display and min(display)>0:
            simple_compensation=(display[1]/h)/(display[0]/w)
            paw_width=round(paw_width*simple_compensation)
    paw=paw.resize((paw_width,ph),Image.Resampling.LANCZOS)
    # Paired decorations live in the two endcaps; text remains a separate consumer.
    left=(px-paw.width//2,(h-paw.height)//2);right=(w-px-paw.width//2,(h-paw.height)//2)
    result.alpha_composite(paw,left);result.alpha_composite(paw,right)
    dest=OUT/path;dest.parent.mkdir(parents=True,exist_ok=True);result.save(dest)
    a=np.array(result);assert a[0,0,3]==a[0,-1,3]==a[-1,0,3]==a[-1,-1,3]==0
    for c in consumers[path]:
        c['proposedPixelsPerUnitMultiplier']=h/c['size'][1] if c['imageType']==1 and c['size'] and c['size'][1]>0 else c['pixelsPerUnitMultiplier']
    records.append({'file':path,'size':[w,h],'mode':'RGBA','alphaBounds':result.getchannel('A').getbbox(),'runtimeSource':str((UI/path).relative_to(ROOT)),'runtimeGuid':re.search(r'^guid: (\w+)',meta,re.M).group(1),'runtimeSHA256':sha(UI/path),'runtimeMetaSHA256':sha((UI/path).with_suffix('.png.meta')),'candidateSHA256':sha(dest),'currentBorderLTRB':border,'proposedBorderLTRB':proposed,'importChangeNeeded':border!=proposed,'color':color,'pawRectsXYWH':[[*left,paw.width,paw.height],[*right,paw.width,paw.height]],'simplePawWidthCompensation':simple_compensation,'consumers':consumers[path],'status':'candidate-awaiting-user-image-approval'})

font=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',18)
small=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',14)
cn=ImageFont.truetype('C:/Windows/Fonts/msyhbd.ttc',30)
def checker(size):
    im=Image.new('RGB',size,'#dedbd5');d=ImageDraw.Draw(im)
    for y in range(0,size[1],14):
        for x in range(0,size[0],14):
            if (x//14+y//14)%2:d.rectangle((x,y,x+13,y+13),fill='#faf8f2')
    return im

sheet=Image.new('RGB',(1200,1000),'#fffaf0')
comparison=Image.new('RGB',(1400,1680),'#fffaf0')
for i,r in enumerate(records):
    x=i%3*400;y=i//3*250;tile=checker((384,175));im=Image.open(OUT/r['file']).convert('RGBA');im.thumbnail((360,155),Image.Resampling.LANCZOS)
    tile.paste(im,((384-im.width)//2,(175-im.height)//2),im);sheet.paste(tile,(x+8,y+5));d=ImageDraw.Draw(sheet)
    d.text((x+10,y+190),r['file'].split('/')[0]+' / '+r['file'].split('/')[-1],font=small,fill='#573b2b')
    d.text((x+10,y+217),str(r['size'])+'  '+r['color'],font=small,fill='#78614b')
    bx=i%2*700;by=i//2*280;d=ImageDraw.Draw(comparison);d.text((bx+10,by+7),r['file'],font=small,fill='#573b2b')
    for j,src in enumerate([UI/r['file'],OUT/r['file']]):
        tile=checker((330,200));im=Image.open(src).convert('RGBA');im.thumbnail((310,180),Image.Resampling.LANCZOS)
        tile.paste(im,((330-im.width)//2,(200-im.height)//2),im);comparison.paste(tile,(bx+j*350+8,by+33));d.text((bx+j*350+10,by+241),'CURRENT' if j==0 else 'CANDIDATE',font=small,fill='#78614b')
sheet.save(WORK/'contact_sheet_v01.png');comparison.save(WORK/'original_vs_candidate_v01.png')

def render(r,size,ppum,proposed=True):
    im=Image.open(OUT/r['file']).convert('RGBA')
    if not any(r['proposedBorderLTRB']):return im.resize(tuple(map(round,size)),Image.Resampling.LANCZOS)
    border=r['proposedBorderLTRB'] if proposed else r['currentBorderLTRB']
    if not any(border):return im.resize(tuple(map(round,size)),Image.Resampling.LANCZOS)
    effective_ppum=r['size'][1]/size[1] if proposed else ppum
    return nine(im,tuple(map(round,size)),border,[v/effective_ppum for v in border])

# Every real consumer at its serialized size, not an invented standard button.
cases=[(r,c) for r in records for c in r['consumers'] if c['size'] and min(c['size'])>0]
stretch=Image.new('RGB',(1200,len(cases)*210),'#fffaf0')
for i,(r,c) in enumerate(cases):
    y=i*210;d=ImageDraw.Draw(stretch);d.text((12,y+6),r['file']+' | '+Path(c['prefab']).stem+'/'+c['object']+' '+str(c['size'])+' ppum='+str(c['pixelsPerUnitMultiplier']),font=small,fill='#573b2b')
    for j,proposed in enumerate([False,True]):
        tile=checker((580,155));im=render(r,c['size'],c['pixelsPerUnitMultiplier'],proposed)
        im.thumbnail((560,140),Image.Resampling.LANCZOS);tile.paste(im,((580-im.width)//2,(155-im.height)//2),im);stretch.paste(tile,(j*600+10,y+29))
        d.text((j*600+14,y+187),'CURRENT SLICE + PPU' if j==0 else 'PROPOSED SLICE + PPU (not applied)',font=small,fill='#78614b')
stretch.save(WORK/'all_consumers_slice_comparison.png')

# Focused readable previews, with sample text/one existing icon. Not a Unity render.
lookup={r['file']:r for r in records}
focus=Image.new('RGB',(1080,1740),'#fff8eb');d=ImageDraw.Draw(focus);d.text((40,18),'OFFLINE BUTTON REVIEW / proposed slices',font=font,fill='#573b2b')
review=[('Game/btn_Common_Rounded_Yellow.png',(732,120),1.125,'重新开始'),('Game/btn_Game_Rounded_Blue.png',(732,120),1.125,'游戏教程'),('Home/btn_Home_Level.png',(741,208),1,'关卡 1'),('Home/btn_Home_Level_Hard.png',(741,208),1,'困难关卡'),('Home/btn_Home_Endless.png',(790,170),1,'无限模式'),('Shop/shop_btn_pink.png',(290,90),1,'购买'),('Ranking/btn_Ranking_Pill_Cream.png',(210,65),2,'重试'),('Streak/btn_Streak_Continue.png',(620,150),2,'继续')]
y=75
for path,size,ppum,label in review:
    im=render(lookup[path],size,ppum);x=(1080-size[0])//2;focus.paste(im,(x,y),im)
    d=ImageDraw.Draw(focus);d.text((540,y+size[1]//2),label,font=cn,fill='#573b2b',anchor='mm')
    if label=='游戏教程':
        icon=Image.open(UI/'Settings/new/icon_tutorial.png').convert('RGBA');icon.thumbnail((68,68),Image.Resampling.LANCZOS);focus.paste(icon,(x+95-icon.width//2,y+(size[1]-icon.height)//2),icon)
    y+=size[1]+48
focus.save(WORK/'button_style_preview.png')

after={str(p.relative_to(UI)):sha(p) for p in UI.rglob('*') if p.is_file()};assert before==after
manifest={'date':'2026-10-28','status':'candidate-awaiting-user-image-approval','runtimeReplacementAuthorized':False,'tool':'built-in image_gen','count':12,'note':'Six generated color masters; approved paw source extracted and composited. Same filenames and canvases. No labels baked. Proposed importer borders AND per-Image PPU multiplier are review-only and require approval before installation. PPU = sprite pixel height / displayed reference height keeps vertical scale uniform; fixed endcaps protect paw shapes while center stretches horizontally. Installing only PNGs is not sufficient. Relevant Prefab Image PPU and editor/runtime overrides must be synchronized after approval; no changes are made now. Simple Endless image paw width precompensates its existing nonuniform display ratio. Offline previews approximate Unity nine-slice including border clamping, not Play Mode. Runtime layout and resize must be verified later.','assets':records}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
(WORK/'verification.json').write_text(json.dumps({'assetCount':12,'sameFilenamesAndSizes':True,'allRGBA':True,'runtimeUIFilesUnchanged':True,'runtimeUIFileSHA256':before,'realConsumerPreviewCount':len(cases),'recommendedImportChanges':[r['file'] for r in records if r['importChangeNeeded']],'unityImport':'not run','unityCompile':'not run','playMode':'not run','addressablesBuild':'not run','appBuild':'not run','device':'not run'},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'count':12,'consumers':len(cases),'recommendedImportChanges':[r['file'] for r in records if r['importChangeNeeded']],'runtimeUnchanged':True},ensure_ascii=False))
