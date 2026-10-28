from pathlib import Path
from PIL import Image, ImageDraw, ImageFont
import json,hashlib

HERE=Path(__file__).resolve().parent
PROJECT=HERE.parents[5]
OUT=HERE.parents[1]/'assets/UI/Profile/Schnauzer/v01'
config=json.loads((HERE/'hand_prompts.json').read_text(encoding='utf-8-sig'))
records=[]
sheet=Image.new('RGB',(1000,400),'#f6f0e5')
draw=ImageDraw.Draw(sheet)
font=ImageFont.truetype('C:/Windows/Fonts/msyh.ttc',20)
for index,avatar_id in enumerate(config['ids']):
    name=f'avatar_hand_{avatar_id}.png'
    raw=Image.open(HERE/'raw'/name).convert('RGBA')
    original=Image.open(PROJECT/'Assets/Res_Runtime/UI/Profile'/name)
    assert raw.getbbox() and raw.getchannel('A').getextrema()==(0,255)
    art=raw.crop(raw.getbbox())
    art.thumbnail((original.width-4,original.height-4),Image.Resampling.LANCZOS)
    image=Image.new('RGBA',original.size)
    image.alpha_composite(art,((image.width-art.width)//2,(image.height-art.height)//2))
    target=OUT/name
    image.save(target)
    thumb=image.copy()
    thumb.thumbnail((230,145),Image.Resampling.LANCZOS)
    x,y=index%4*250,index//4*200
    sheet.paste(thumb,(x+(250-thumb.width)//2,y+10+(145-thumb.height)//2),thumb)
    draw.text((x+12,y+165),f'{avatar_id} 前爪层',font=font,fill='#493629')
    records.append(dict(id=avatar_id,file=name,size=list(image.size),mode=image.mode,alpha=list(image.getchannel('A').getextrema()),bbox=list(image.getbbox()),sha256=hashlib.sha256(target.read_bytes()).hexdigest(),status='pending-user-review-overlay-alignment-unverified'))
sheet.save(HERE/'hands_contact_sheet_v01.png')
p=OUT/'manifest.json'
m=json.loads(p.read_text(encoding='utf8'))
m.update(hands=records,handCount=len(records),count=len(records)+len(m['assets']),notes='Artwork candidates only. Front-paw layers were AI-isolated and fitted uniformly to original hand canvas sizes. Not lossless pixel extraction. Sprite pivots, clothing occlusion and exact overlay alignment need integration validation. Existing blue-ear puppy artwork retained; no production asset installation.')
p.write_text(json.dumps(m,ensure_ascii=False,indent=2),encoding='utf8')
checks=[]
for row in m['assets']+m['hands']:
    image=Image.open(OUT/row['file'])
    original=Image.open(PROJECT/'Assets/Res_Runtime/UI/Profile'/row['file'])
    assert image.mode=='RGBA' and image.size==original.size and image.getchannel('A').getextrema()==(0,255)
    checks.append(dict(file=row['file'],size=list(image.size),rgba=True,alphaRange=[0,255],nonempty=bool(image.getbbox())))
baseline=json.loads((HERE/'baseline_hashes.json').read_text(encoding='utf8'))
changes=[name for name,old in baseline.items() if not (PROJECT/name).exists() or hashlib.sha256((PROJECT/name).read_bytes()).hexdigest()!=old]
verification=dict(environment='Windows/Python/Pillow offline image checks',checks=checks,count=len(checks),baselineChanges=changes,oldBlueEarPuppyArtworkUnchanged=not any('assets/UI/Profile/v01/' in name.replace('\\','/') for name in changes),unityCompilation=False,playMode=False,addressablesBuild=False,applicationBuild=False,installation=False,deviceValidation=False)
(HERE/'verification.json').write_text(json.dumps(verification,ensure_ascii=False,indent=2),encoding='utf8')
print(f'{len(checks)} files passed RGBA/size/alpha checks; baseline changes: {changes}')
