from pathlib import Path
import json
import hashlib
import shutil
import numpy as np
from PIL import Image, ImageDraw, ImageFont
from scipy import ndimage as ndi

ROOT=Path(__file__).resolve().parents[6]
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent
OUT=THEME/'assets/UI/Game'
GEN=Path('C:/Users/Administrator/.codex/generated_images/01a17caf-dfcf-7710-83fe-0f0e4e1f5d6f')
sources={'Img_Game_Guide':'exec-95f33813-69bf-4629-819e-136781153ca6.png','Img_Game_Hint':'exec-3f7314fa-6e68-4db4-8a6c-17eb1e30f6dc.png'}
manifest_path=OUT/'manifest.json'
manifest=json.loads(manifest_path.read_text(encoding='utf-8'))
checks=[]
for name,source in sources.items():
    master=WORK/(name+'_master.png')
    if not master.exists():
        shutil.copy2(GEN/source,master)
    im=Image.open(master).convert('RGBA')
    arr=np.array(im)
    # Retain the connected solid button and remove isolated generated alpha
    # flecks; keep the color/highlight artwork intact inside its silhouette.
    labels,_=ndi.label(arr[:,:,3]>150)
    areas=np.bincount(labels.ravel());areas[0]=0
    mask=ndi.binary_fill_holes(labels==areas.argmax())
    mask=ndi.binary_opening(mask,iterations=2)
    arr[:,:,3]=np.minimum(arr[:,:,3],mask.astype('uint8')*255)
    arr[arr[:,:,3]==0,:3]=0
    im=Image.fromarray(arr)
    bounds=im.getchannel('A').getbbox()
    im=im.crop(bounds)
    scale=min(112/im.width,116/im.height)
    im=im.resize((round(im.width*scale),round(im.height*scale)),Image.Resampling.LANCZOS)
    canvas=Image.new('RGBA',(114,118))
    canvas.alpha_composite(im,((114-im.width)//2,(118-im.height)//2))
    canvas.save(OUT/(name+'.png'))
    a=np.array(canvas)
    record=next(r for r in manifest['assets'] if r['file']==name+'.png')
    record.update(source='../../previews/Game_Tools_Revision_20261028/'+name+'_master.png',sourceRect=None,method='imagegen-redraw-alpha-normalized',revisionDate='2026-10-28',note=('Redrawn smooth complete bulb with joined neck, rounded two-band screw base and contained highlight.' if name.endswith('Guide') else 'Searching expression: eyes glance left, inquisitive asymmetric brows and small closed mouth; viewer-right blue eye patch retained.'),sha256=hashlib.sha256((OUT/(name+'.png')).read_bytes()).hexdigest())
    checks.append(dict(file=name+'.png',size=list(canvas.size),mode=canvas.mode,alphaBounds=canvas.getchannel('A').getbbox(),transparentPixels=int((a[:,:,3]==0).sum()),edgesTransparent=not bool(a[0,:,3].any() or a[-1,:,3].any() or a[:,0,3].any() or a[:,-1,3].any()),sha256=record['sha256'],masterBounds=bounds))
manifest['lastRevisionDate']='2026-10-28'
manifest_path.write_text(json.dumps(manifest,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
before=json.loads((WORK/'before_hashes.json').read_text(encoding='utf-8'))
changed=[p for p,h in before.items() if hashlib.sha256((ROOT/p).read_bytes()).hexdigest()!=h]
expected={str((OUT/(n+'.png')).relative_to(ROOT)) for n in sources}|{str(manifest_path.relative_to(ROOT))}
assert set(changed)<=expected,changed
assert all(c['edgesTransparent'] for c in checks)
(WORK/'verification.json').write_text(json.dumps(dict(date='2026-10-28',checks=checks,changedFiles=changed,productionFilesUnchanged=not any(p.startswith('Assets') for p in changed),other32ImagesUnchanged=True,unity='not run; documentation assets only'),ensure_ascii=False,indent=2),encoding='utf-8')
sheet=Image.new('RGB',(760,420),'#e9e4da');d=ImageDraw.Draw(sheet)
font=ImageFont.truetype('C:/Windows/Fonts/arial.ttf',18)
for row,name in enumerate(sources):
    for col,im in enumerate([Image.open(WORK/('before_'+name+'.png')).convert('RGBA'),Image.open(OUT/(name+'.png')).convert('RGBA')]):
        x=col*380;y=row*210
        for yy in range(y,y+170,12):
            for xx in range(x,x+380,12):
                d.rectangle((xx,yy,xx+11,yy+11),fill='#fff' if (xx//12+yy//12)%2 else '#ddd')
        # Show actual pixel size next to a 2x enlargement.
        sheet.paste(im,(x+12,y+28),im)
        big=im.resize((137,142),Image.Resampling.LANCZOS)
        sheet.paste(big,(x+172,y+14),big)
        d.text((x+10,y+175),('Before' if col==0 else 'After')+' '+name,fill='#4a3022',font=font)
sheet.save(WORK/'before_after.png')
print(json.dumps(dict(checks=checks,productionFilesUnchanged=True),ensure_ascii=False))
