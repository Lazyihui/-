from pathlib import Path
import hashlib,json,re,shutil
import numpy as np
from scipy import ndimage as ndi
from PIL import Image,ImageDraw,ImageFont

ROOT=Path(__file__).resolve().parents[6]
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
OUT=THEME/'assets/UI/Settings/v03'
OUT.mkdir(parents=True,exist_ok=True)
RUNTIME=ROOT/'Assets/Res_Runtime/UI/Settings'
GEN=Path('C:/Users/Administrator/.codex/generated_images/01a17ca9-ac58-77e0-bbe8-9fa8a10744ea')
sha=lambda p:hashlib.sha256(p.read_bytes()).hexdigest()
before={str(p.relative_to(RUNTIME)):sha(p) for p in RUNTIME.rglob('*') if p.is_file()}
specs=[('PopupPanel.png','exec-820b6899-21e3-441b-aa83-cbfcf11c31a0.png',(351,512),0.6),('PopupPanelInner.png','exec-aa08bde7-28c0-461f-a915-bbd56b7003ae.png',(512,428),0.7)]

def clean(im):
    a=np.array(im.convert('RGBA'));rgb=a[:,:,:3].astype(int)
    mask=(a[:,:,3]>160)&(rgb.min(2)<246)&((rgb.max(2)-rgb.min(2))<155)
    lab,_=ndi.label(ndi.binary_opening(mask));counts=np.bincount(lab.ravel());counts[0]=0
    mask=ndi.binary_fill_holes(lab==counts.argmax())
    # Use only the new art's own silhouette. Never reuse the old panel's alpha.
    a[:,:,3]=np.minimum(a[:,:,3],np.uint8(mask)*255)
    a[a[:,:,3]==0,:3]=0
    result=Image.fromarray(a);return result.crop(result.getchannel('A').getbbox())

def nine(im,size,border,target_border=None):
    sw,sh=im.size;tw,th=size;db=border if target_border is None else target_border
    sx=[0,border,sw-border,sw];sy=[0,border,sh-border,sh]
    dx=[0,db,tw-db,tw];dy=[0,db,th-db,th]
    out=Image.new('RGBA',size)
    for y in range(3):
        for x in range(3):
            tile=im.crop((sx[x],sy[y],sx[x+1],sy[y+1]))
            tile=tile.resize((dx[x+1]-dx[x],dy[y+1]-dy[y]),Image.Resampling.LANCZOS)
            out.alpha_composite(tile,(dx[x],dy[y]))
    return out

def checker(size):
    out=Image.new('RGB',size,'#e5e1db');d=ImageDraw.Draw(out)
    for y in range(0,size[1],12):
        for x in range(0,size[0],12):
            if (x//12+y//12)%2:d.rectangle((x,y,x+11,y+11),fill='#faf8f3')
    return out

font=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',20)
records=[];comparison=Image.new('RGB',(1000,680),'#fffaf1')
for i,(name,gen,size,ppum) in enumerate(specs):
    shutil.copy2(GEN/gen,WORK/(name[:-4]+'_master.png'))
    art=clean(Image.open(GEN/gen));sb=round(min(art.size)*0.12)
    core=nine(art,(size[0]-4,size[1]-4),sb,26)
    result=Image.new('RGBA',size);result.alpha_composite(core,(2,2));result.save(OUT/name)
    a=np.array(result);w,h=size
    corners=[int(a[y,x,3]) for x,y in [(0,0),(w-1,0),(0,h-1),(w-1,h-1),(5,5),(w-6,5),(5,h-6),(w-6,h-6)]]
    assert corners==[0]*8
    # At 28px slice cuts the outline has already become straight.
    xline=[int(np.flatnonzero(a[y,:,3]>127)[0]) for y in [28,40,h//2,h-41,h-29]]
    assert max(xline)-min(xline)<=1,(name,xline)
    record={'file':name,'size':list(size),'mode':'RGBA','alphaBounds':result.getchannel('A').getbbox(),'borderLTRB':[28]*4,'outsideCornerAlpha':corners,'leftEdgeXAtSliceAndMid':xline,'sha256':sha(OUT/name),'generatedMaster':name[:-4]+'_master.png','oldMaskReused':False,'status':'candidate-awaiting-user-image-approval'}
    records.append(record)
    for j,im in enumerate([Image.open(RUNTIME/'new'/name).convert('RGBA'),result]):
        tile=checker((480,270));im=im.copy();im.thumbnail((450,250),Image.Resampling.LANCZOS)
        tile.paste(im,((480-im.width)//2,(270-im.height)//2),im);comparison.paste(tile,(j*500+10,i*340+35))
        ImageDraw.Draw(comparison).text((j*500+15,i*340+8),name+(' CURRENT' if j==0 else ' CANDIDATE v03'),font=font,fill='#583c2c')

comparison.save(WORK/'original_vs_candidate_v03.png')
# Model Unity UI nine-slice corner scaling: fixed border pixels / PPU multiplier.
preview=Image.new('RGB',(1080,1920),'#dcd5c9')
outer=nine(Image.open(OUT/'PopupPanel.png').convert('RGBA'),(960,1800),28,round(28/.6))
preview.paste(outer,(60,60),outer)
draw=ImageDraw.Draw(preview);draw.text((390,102),'Settings border review',font=font,fill='#583c2c')
for y,height in [(190,980),(1220,160),(1430,260)]:
    card=nine(Image.open(OUT/'PopupPanelInner.png').convert('RGBA'),(820,height),28,round(28/.7))
    preview.paste(card,(130,y),card)
preview.save(WORK/'nine_slice_portrait_1080x1920.png')
wide=checker((1200,540))
for x,width in [(30,380),(440,730)]:
    im=nine(Image.open(OUT/'PopupPanelInner.png').convert('RGBA'),(width,200),28,40)
    wide.paste(im,(x,60),im)
wide.save(WORK/'nine_slice_width_comparison.png')
after={str(p.relative_to(RUNTIME)):sha(p) for p in RUNTIME.rglob('*') if p.is_file()};assert before==after
manifest={'date':'2026-10-28','status':'candidate-awaiting-user-image-approval','runtimeReplacementAuthorized':False,'tool':'built-in image_gen','normalization':'Own generated alpha; connected silhouette cleanup; corners normalized to fit28px border;2px transparent canvas margin. Never copy old alpha.','assets':records}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf-8')
(WORK/'verification.json').write_text(json.dumps({'runtimeFilesUnchanged':True,'runtimeSHA256BeforeAndAfter':before,'checks':records,'preview':'offline nine-slice approximation using current0.6/0.7 PPU multipliers; not a Unity render','unityImport':'not run','unityCompile':'not run','playMode':'not run','addressablesBuild':'not run','appBuild':'not run','device':'not run'},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'candidateCount':2,'runtimeUnchanged':True,'checks':records},ensure_ascii=False))
