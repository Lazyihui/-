from pathlib import Path
from PIL import Image, ImageDraw, ImageFont
import json, shutil, hashlib

HERE = Path(__file__).resolve().parent
OUT = HERE.parents[1] / 'assets/UI/Profile/DogVariants/v01'
OUT.mkdir(parents=True, exist_ok=True)
(HERE/'raw').mkdir(exist_ok=True)
data = json.loads((HERE/'prompts.json').read_text(encoding='utf-8-sig'))
sheet = Image.new('RGB', (1530, 520), '#f6f0e5')
draw = ImageDraw.Draw(sheet)
font = ImageFont.truetype('C:/Windows/Fonts/msyh.ttc', 30)
entries = []
for i, job in enumerate(data['jobs']):
    raw = Image.open(job['rawPath']).convert('RGBA')
    assert raw.getchannel('A').getextrema() == (0,255)
    art = raw.crop(raw.getbbox())
    art.thumbnail((469,399), Image.Resampling.LANCZOS)
    image = Image.new('RGBA', (509,439))
    image.alpha_composite(art, ((509-art.width)//2,(439-art.height)//2))
    name = job['key']+'.png'
    target = OUT/name
    image.save(target)
    shutil.copy2(job['rawPath'], HERE/'raw'/name)
    sheet.paste(image,(i*510,5),image)
    label = job['label']
    box=draw.textbbox((0,0),label,font=font)
    draw.text((i*510+(510-(box[2]-box[0]))//2,455),label,font=font,fill='#493629')
    entries.append(dict(file=name,label=label,size=list(image.size),mode=image.mode,alpha=list(image.getchannel('A').getextrema()),bbox=list(image.getbbox()),sha256=hashlib.sha256(target.read_bytes()).hexdigest(),status='pending-user-selection'))
sheet.save(HERE/'comparison_v01.png')
(OUT/'manifest.json').write_text(json.dumps(dict(date='2026-10-28',tool='built-in image_gen',status='pending-user-selection-not-installed',count=3,scope='Three different puppy head concepts, one neutral base portrait each. Existing blue-ear puppy set preserved; no expression sets or runtime changes.',assets=entries),ensure_ascii=False,indent=2),encoding='utf8')
print('3 transparent RGBA portraits checked at 509x439; comparison saved.')
