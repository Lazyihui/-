from pathlib import Path
from PIL import Image, ImageDraw, ImageFont
import json, hashlib

HERE = Path(__file__).resolve().parent
PROJECT = HERE.parents[5]
OUT = HERE.parents[1] / 'assets/UI/Profile/Schnauzer/v01'
config = json.loads((HERE/'prompts.json').read_text(encoding='utf-8-sig'))
font = ImageFont.truetype('C:/Windows/Fonts/msyh.ttc', 21)
sheet = Image.new('RGB', (1200, 900), '#f6f0e5')
draw = ImageDraw.Draw(sheet)
records = []
for index, (avatar_id, stem, label, description) in enumerate(config['jobs']):
    src = HERE/'raw'/(stem+'.png')
    if not src.exists():
        continue
    raw = Image.open(src).convert('RGBA')
    original = Image.open(PROJECT/'Assets/Res_Runtime/UI/Profile'/(stem+'.png'))
    assert raw.getbbox() and raw.getchannel('A').getextrema() == (0,255)
    if avatar_id == 17:
        image = raw.copy()
        assert image.size == original.size
    else:
        art = raw.crop(raw.getbbox())
        art.thumbnail((int(original.width*.92),int(original.height*.92)),Image.Resampling.LANCZOS)
        image = Image.new('RGBA',original.size)
        image.alpha_composite(art,((image.width-art.width)//2,(image.height-art.height)//2))
    target = OUT/(stem+'.png')
    image.save(target)
    thumb = image.copy()
    thumb.thumbnail((280,235),Image.Resampling.LANCZOS)
    x,y = index%4*300,index//4*300
    sheet.paste(thumb,(x+(300-thumb.width)//2,y+10+(235-thumb.height)//2),thumb)
    draw.text((x+24,y+257),f'{avatar_id}  {label}',font=font,fill='#493629')
    records.append(dict(id=avatar_id,file=target.name,label=label,size=list(image.size),mode=image.mode,alpha=list(image.getchannel('A').getextrema()),bbox=list(image.getbbox()),sha256=hashlib.sha256(target.read_bytes()).hexdigest(),status='user-approved-base' if avatar_id==17 else 'pending-user-review',source='approved base reused' if avatar_id==17 else 'built-in image_gen'))
sheet.save(HERE/'contact_sheet_v01.png')
manifest_path=OUT/'manifest.json'
manifest=json.loads(manifest_path.read_text(encoding='utf8')) if manifest_path.exists() else {}
manifest.update(date='2026-10-28',tool='built-in image_gen',status='pending-user-review-not-installed',identityReference='assets/UI/Profile/DogVariants/v01/05_sesame_schnauzer.png',avatarCount=len(records),assets=records)
manifest_path.write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf8')
print(f'{len(records)} schnauzer avatars prepared')
