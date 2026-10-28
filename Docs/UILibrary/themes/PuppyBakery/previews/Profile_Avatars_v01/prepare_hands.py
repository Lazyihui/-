from pathlib import Path
from PIL import Image, ImageDraw
import json, hashlib, shutil

HERE = Path(__file__).resolve().parent
PROJECT = HERE.parents[5]
OUTPUT = HERE.parents[1] / 'assets/UI/Profile/v01'
data = json.loads((HERE / 'hands_generated.json').read_text(encoding='utf-8-sig'))
manifest_path = OUTPUT / 'manifest.json'
manifest = json.loads(manifest_path.read_text(encoding='utf8'))
manifest['hands'] = []
sheet = Image.new('RGB', (1000, 5 * 180), '#f6f0e5')
draw = ImageDraw.Draw(sheet)
raw_dir = HERE / 'raw'
raw_dir.mkdir(exist_ok=True)
for index, row in enumerate(data['records']):
    name = f"avatar_hand_{row['id']}.png"
    source = PROJECT / 'Assets/Res_Runtime/UI/Profile' / name
    original = Image.open(source)
    raw = Image.open(row['path']).convert('RGBA')
    if not raw.getbbox() or raw.getchannel('A').getextrema()[0] != 0:
        raise ValueError(f'Invalid paw alpha: {name}')
    image = raw.crop(raw.getbbox())
    image.thumbnail((original.width - 4, original.height - 4), Image.Resampling.LANCZOS)
    canvas = Image.new('RGBA', original.size)
    canvas.alpha_composite(image, ((canvas.width-image.width)//2, (canvas.height-image.height)//2))
    target = OUTPUT / name
    canvas.save(target)
    shutil.copy2(row['path'], raw_dir / name)
    thumb = canvas.copy()
    thumb.thumbnail((230, 130), Image.Resampling.LANCZOS)
    x,y = index % 4 * 250, index // 4 * 180
    sheet.paste(thumb, (x+(250-thumb.width)//2,y+(135-thumb.height)//2),thumb)
    draw.text((x+12,y+145),name,fill='#493629')
    manifest['hands'].append(dict(id=row['id'],file=name,size=list(canvas.size),alpha=list(canvas.getchannel('A').getextrema()),bbox=list(canvas.getbbox()),raw=str((raw_dir/name).relative_to(HERE)),sha256=hashlib.sha256(target.read_bytes()).hexdigest(),status='pending-user-review-overlay-alignment-not-validated'))
for row in json.loads((HERE / 'generated.json').read_text(encoding='utf-8-sig')):
    name = row['file'] + '.png'
    shutil.copy2(row['path'],raw_dir / name)
for row in manifest['assets']:
    row['raw'] = 'raw/' + row['file']
manifest.update(tool='built-in image_gen',date='2026-10-28',count=48,avatarCount=28,handCount=20,notes='Candidate artwork only. No production Assets, GUIDs, prefab, SO, scripts or Addressables replaced. Paw overlays are AI isolated and fitted uniformly to original hand canvases; exact face, clothing and paw alignment needs Unity integration validation after artwork approval.')
manifest_path.write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf8')
sheet.save(HERE/'hands_contact_sheet_v01.png')
checks=[]
for row in manifest['assets']+manifest['hands']:
    p=OUTPUT/row['file']; im=Image.open(p)
    assert im.mode=='RGBA' and list(im.size)==row['size'] and im.getchannel('A').getextrema()==(0,255)
    assert (PROJECT/'Assets/Res_Runtime/UI/Profile'/row['file']).exists()
    checks.append({'file':row['file'],'mode':im.mode,'size':list(im.size),'alpha':list(im.getchannel('A').getextrema()),'sourceSha256':hashlib.sha256((PROJECT/'Assets/Res_Runtime/UI/Profile'/row['file']).read_bytes()).hexdigest()})
(HERE/'verification.json').write_text(json.dumps(dict(environment='Windows offline Pillow image inspection',count=len(checks),checks=checks,unityCompiled=False,playMode=False,addressablesBuild=False,applicationBuild=False,device=False),indent=2),encoding='utf8')
print(f'{len(checks)} RGBA files passed size and alpha inspection')
