"""Copy generated originals and fit candidate sprites to their existing canvas sizes."""
import hashlib
import json
import shutil
import sys
from pathlib import Path

from PIL import Image

root = Path(__file__).resolve().parents[6]
preview = Path(__file__).resolve().parent
theme = preview.parent.parent
output = theme / 'assets/UI/Shop/Offers/v01'
output.mkdir(parents=True, exist_ok=True)
names = ['offer_art_starter_pack.png', 'offer_art_special_offer.png']
rows = []
for source, name in zip(sys.argv[1:], names):
    source = Path(source)
    shutil.copy2(source, preview / ('generated_' + name))
    original = Image.open(root / 'Assets/Res_Runtime/UI/Shop/new' / name)
    generated = Image.open(source).convert('RGBA')
    alpha = generated.getchannel('A')
    assert alpha.getextrema() == (0, 255), 'Expected genuine transparency'
    # Only trim empty alpha margins, then uniformly downsample; no repainting.
    content = generated.crop(alpha.getbbox())
    size = original.size
    content.thumbnail((size[0] - 12, size[1] - 12), Image.Resampling.LANCZOS)
    canvas = Image.new('RGBA', size)
    canvas.alpha_composite(content, ((size[0] - content.width) // 2, (size[1] - content.height) // 2))
    target = output / name
    canvas.save(target)
    check = Image.open(target)
    assert check.mode == 'RGBA' and check.size == original.size
    assert all(check.getpixel(p)[3] == 0 for p in [(0, 0), (size[0]-1, 0), (0, size[1]-1), (size[0]-1, size[1]-1)])
    rows.append({'file':name,'size':list(size),'mode':check.mode,'alphaRange':list(check.getchannel('A').getextrema()),'bbox':list(check.getbbox()),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'generatedSource':str(source),'status':'candidate_awaiting_art_review_not_installed'})

baseline = json.loads((preview / 'runtime-baseline.json').read_text(encoding='utf-8'))
unchanged = {p:hashlib.sha256((root / p).read_bytes()).hexdigest() == h for p,h in baseline.items()}
assert all(unchanged.values()), 'Shop runtime files changed during candidate preparation'
result = {'date':'2026-10-28','tool':'built-in image_gen','assets':rows,'runtimeUnchanged':unchanged,'verification':'Windows offline PNG inspection and visual review only; no Unity import, Play Mode, build or device verification'}
(output / 'manifest.json').write_text(json.dumps(result,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
(preview / 'verification.json').write_text(json.dumps(result,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
sheet = Image.new('RGB',(840,440),(255,244,224))
for i,name in enumerate(names):
    im=Image.open(output/name)
    sheet.paste(im,(24+i*416,28),im)
sheet.save(preview/'contact_sheet.png')
print(json.dumps(result,ensure_ascii=False,indent=2))
