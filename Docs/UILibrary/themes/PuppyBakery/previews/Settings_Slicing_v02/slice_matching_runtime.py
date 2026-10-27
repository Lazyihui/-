from pathlib import Path
import json, re, shutil, hashlib
import numpy as np
from PIL import Image, ImageDraw, ImageFont
from scipy import ndimage as ndi

ROOT=Path(__file__).resolve().parents[6]
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
RUNTIME=ROOT/'Assets/Res_Runtime/UI/Settings'
OUT=THEME/'assets/UI/Settings/v02'
OUT.mkdir(parents=True,exist_ok=True)
OLD=THEME/'previews/Settings_Slicing'
NEW=WORK/'panels_save_master.png'
if not NEW.exists():
    shutil.copy2(Path('C:/Users/Administrator/.codex/generated_images/01a17ca9-ac58-77e0-bbe8-9fa8a10744ea/exec-af24ecda-3c82-4e8c-a3eb-095f6ee6ab9d.png'),NEW)
masters={'icons':Image.open(OLD/'icons_master.png').convert('RGBA'),'structure':Image.open(OLD/'structure_master.png').convert('RGBA'),'new':Image.open(NEW).convert('RGBA')}
mapping={
    'PopupPanel.png':('new',(55,45,575,785)),
    'PopupPanelInner.png':('new',(665,155,1370,700)),
    'icon_save.png':('new',(1490,270,1870,640)),
    'icon_sfx.png':('icons',(70,90,340,355)),
    'icon_music.png':('icons',(365,90,635,355)),
    'icon_combo_voice.png':('icons',(660,90,930,355)),
    'icon_vibration.png':('icons',(950,90,1225,355)),
    'icon_border.png':('icons',(70,395,340,655)),
    'icon_pattern.png':('icons',(365,395,635,655)),
    'icon_language.png':('icons',(660,395,930,655)),
    'icon_support.png':('icons',(390,735,610,930)),
    'icon_privacy.png':('icons',(685,715,900,945)),
    'icon_terms.png':('icons',(1005,715,1190,945)),
    'icon_tutorial.png':('icons',(365,995,625,1195)),
    'icon_chevron.png':('icons',(130,745,250,920)),
    'icon_close.png':('structure',(910,925,1155,1175)),
    'popup_btn_close.png':('structure',(910,925,1155,1175))}

def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()

before={p.name:sha(p) for p in RUNTIME.iterdir() if p.is_file()}
def clean(im):
    a=np.array(im); rgb=a[:,:,:3].astype(int)
    mask=(a[:,:,3]>160)&(rgb.min(2)<246)&((rgb.max(2)-rgb.min(2))<155)
    mask=ndi.binary_opening(mask)
    labs,_=ndi.label(mask); counts=np.bincount(labs.ravel());counts[0]=0
    mask=ndi.binary_fill_holes(labs==counts.argmax())
    mask=ndi.binary_closing(mask,iterations=2)
    a[:,:,3]=np.minimum(a[:,:,3],np.uint8(mask)*255)
    a[a[:,:,3]==0,:3]=0
    out=Image.fromarray(a); return out.crop(out.getchannel('A').getbbox())

def panel_fit(art, original, border):
    # Resize only the stretchable center/edges; retain the 28px corner contract.
    sw,sh=art.size; tw,th=original.size; sb=round(min(sw,sh)*0.09); db=int(border[0])
    result=Image.new('RGBA',(tw,th))
    sx=[0,sb,sw-sb,sw];sy=[0,sb,sh-sb,sh]
    dx=[0,db,tw-db,tw];dy=[0,db,th-db,th]
    for y in range(3):
        for x in range(3):
            tile=art.crop((sx[x],sy[y],sx[x+1],sy[y+1])).resize((dx[x+1]-dx[x],dy[y+1]-dy[y]),Image.Resampling.LANCZOS)
            result.alpha_composite(tile,(dx[x],dy[y]))
    a=np.array(result); valid=a[:,:,3]>100
    indices=ndi.distance_transform_edt(~valid,return_distances=False,return_indices=True)
    a[~valid,:3]=a[indices[0][~valid],indices[1][~valid],:3]
    a[:,:,3]=np.array(original.getchannel('A'))
    return Image.fromarray(a)

records=[]
for p in sorted(RUNTIME.glob('*.png')):
    original=Image.open(p).convert('RGBA'); size=original.size
    box=original.getchannel('A').getbbox(); meta=p.with_suffix('.png.meta').read_text(encoding='utf-8')
    border=[float(x) for x in re.search(r'spriteBorder: \{x: ([\d.]+), y: ([\d.]+), z: ([\d.]+), w: ([\d.]+)\}',meta).groups()]
    guid=re.search(r'^guid: (\w+)',meta,re.M).group(1)
    source='unchanged neutral white mask'; crop=None
    if p.name in ['RoundedFill.png','CircleFill.png']:
        shutil.copy2(p,OUT/p.name)
    else:
        source,crop=mapping[p.name]; art=clean(masters[source].crop(crop))
        if p.name in ['PopupPanel.png','PopupPanelInner.png']:
            result=panel_fit(art,original,border)
        else:
            result=Image.new('RGBA',size)
            l,t,r,b=box; scale=min((r-l)/art.width,(b-t)/art.height)
            art=art.resize((max(1,round(art.width*scale)),max(1,round(art.height*scale))),Image.Resampling.LANCZOS)
            result.alpha_composite(art,(l+((r-l)-art.width)//2,t+((b-t)-art.height)//2))
        result.save(OUT/p.name)
    candidate=Image.open(OUT/p.name).convert('RGBA'); actual=candidate.getchannel('A').getbbox()
    records.append({'file':p.name,'size':list(size),'mode':'RGBA','originalAlphaBounds':list(box),'candidateAlphaBounds':list(actual),'borderUnityXYZW':border,'pixelsPerUnit':float(re.search(r'spritePixelsToUnits: ([\d.]+)',meta).group(1)),'runtimeGuidReadOnly':guid,'source':source,'sourceCrop':crop,'runtimeSHA256':before[p.name],'candidateSHA256':sha(OUT/p.name),'metaWritten':False,'status':'candidate-awaiting-user-image-approval'})

assert len(records)==19
assert {r['file'] for r in records}=={p.name for p in OUT.glob('*.png')}
for r in records:
    assert Image.open(OUT/r['file']).size==Image.open(RUNTIME/r['file']).size
assert before=={p.name:sha(p) for p in RUNTIME.iterdir() if p.is_file()},'Runtime files changed'

font=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',17)
small=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',14)
def checker(size):
    im=Image.new('RGB',size,'#eee');d=ImageDraw.Draw(im)
    for y in range(0,size[1],16):
        for x in range(0,size[0],16):
            d.rectangle((x,y,x+15,y+15),fill='#f7f5f1' if (x//16+y//16)%2 else '#d9d7d3')
    return im

sheet=Image.new('RGB',(1200,1000),'#fffaf1')
compare=Image.new('RGB',(1500,1680),'#fffaf1')
for i,r in enumerate(records):
    name=r['file'];x=i%5*240;y=i//5*250
    tile=checker((224,196)); art=Image.open(OUT/name).convert('RGBA');art.thumbnail((204,176),Image.Resampling.LANCZOS)
    tile.paste(art,((224-art.width)//2,(196-art.height)//2),art);sheet.paste(tile,(x+8,y+4))
    d=ImageDraw.Draw(sheet);d.text((x+8,y+205),name,font=font,fill='#4b3328');d.text((x+8,y+228),str(r['size']),font=small,fill='#765b4b')
    bx=i%3*500;by=i//3*240;d=ImageDraw.Draw(compare);d.text((bx+10,by+4),name+'  '+str(r['size']),font=font,fill='#4b3328')
    for j,src in enumerate([RUNTIME/name,OUT/name]):
        tile=checker((235,180));art=Image.open(src).convert('RGBA');art.thumbnail((218,166),Image.Resampling.LANCZOS)
        tile.paste(art,((235-art.width)//2,(180-art.height)//2),art);compare.paste(tile,(bx+j*250+7,by+30))
        d.text((bx+j*250+12,by+213),'ORIGINAL' if j==0 else 'CANDIDATE v02',font=small,fill='#765b4b')
sheet.save(WORK/'contact_sheet_v02.png');compare.save(WORK/'original_vs_candidate_v02.png')
manifest={'page':'Panel_Settings','date':'2026-10-27','status':'candidate-awaiting-user-image-approval','runtimeReplacementAuthorized':False,'runtimeDirectoryReadOnly':str(RUNTIME),'count':19,'notes':['Exact existing file list and pixel canvases. Sprite borders recorded, no runtime or meta writes.','Shared RoundedFill/CircleFill byte-identical neutral masks. No ON/OFF textures, background, title plaque or localized text added.','Art scaled proportionally into original alpha bounds. Silhouette can differ; inspect recorded candidate bounds.','Seven settings icons include their rounded tile in one PNG. icon_save retains floppy-disk meaning.','New panels/save plate generated with built-in image_gen, other art reuses earlier generated high-resolution masters. No new generation of the approved mascot.'],'assets':records}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
(WORK/'verification.json').write_text(json.dumps({'assetCount':len(records),'sameFilenames':True,'sameCanvasSizes':True,'allRGBA':True,'runtimeBeforeSHA256':before,'runtimeUnchangedAfter':True,'metasCopiedOrChanged':False,'neutralMasksByteIdentical':all(sha(OUT/n)==before[n] for n in ['RoundedFill.png','CircleFill.png']),'unityCompile':'not run - image candidates only','unityImport':'not run - no runtime replacement','playMode':'not run','device':'not run'},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'count':len(records),'runtimeUnchanged':True,'output':str(OUT)},ensure_ascii=False))
