from pathlib import Path
from PIL import Image, ImageDraw
import json, hashlib

ROOT = Path(__file__).resolve().parents[6]
PREVIEW = Path(__file__).resolve().parent
OUTPUT = PREVIEW.parents[1] / 'assets/UI/Profile/v01'
OUTPUT.mkdir(parents=True, exist_ok=True)
inventory = {r['id']: r for r in json.loads((PREVIEW / 'source_inventory.json').read_text(encoding='utf8'))}
records = json.loads((PREVIEW / 'generated.json').read_text(encoding='utf8'))
sheet = Image.new('RGB', (1200, 7 * 240), '#f6f0e5')
draw = ImageDraw.Draw(sheet)
report = []
for index, row in enumerate(sorted(records, key=lambda r: r['id'])):
    source = inventory[row['id']]
    raw = Image.open(row['path']).convert('RGBA')
    bbox = raw.getbbox()
    if bbox is None or raw.getchannel('A').getextrema()[0] != 0:
        raise ValueError(f'Empty or opaque image: {row}')
    # Only trim transparent padding and normalize uniformly to the original canvas.
    art = raw.crop(bbox)
    size = tuple(source['size'])
    art.thumbnail((int(size[0] * .92), int(size[1] * .92)), Image.Resampling.LANCZOS)
    image = Image.new('RGBA', size)
    image.alpha_composite(art, ((size[0]-art.width)//2, (size[1]-art.height)//2))
    target = OUTPUT / source['file']
    image.save(target)
    thumb = image.copy()
    thumb.thumbnail((270, 190), Image.Resampling.LANCZOS)
    x = (index % 4) * 300
    y = (index // 4) * 240
    sheet.paste(thumb, (x+(300-thumb.width)//2, y+(195-thumb.height)//2), thumb)
    draw.text((x+12, y+200), f"{row['id']:02d}  {source['file']}", fill='#493629')
    report.append(dict(id=row['id'], file=source['file'], size=list(size), raw=row['path'], alpha=list(image.getchannel('A').getextrema()), bbox=list(image.getbbox()), sha256=hashlib.sha256(target.read_bytes()).hexdigest(), status='pending-user-review'))
sheet.save(PREVIEW / 'contact_sheet_v01.png')
(OUTPUT / 'manifest.json').write_text(json.dumps(dict(status='pending-user-review-not-installed', assets=report),ensure_ascii=False,indent=2),encoding='utf8')
print(f'{len(report)} avatars saved; overview: {PREVIEW / "contact_sheet_v01.png"}')
