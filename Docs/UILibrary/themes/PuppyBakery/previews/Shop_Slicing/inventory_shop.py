from pathlib import Path
import json,re,hashlib
from PIL import Image,ImageDraw,ImageFont
ROOT=Path('D:/UnityProject/Hamdoku2')
WORK=Path(__file__).resolve().parent
ORIG=Path('D:/0000001apkUnbag/01_逆向工程项目/Hamdoku2')
runtime=ROOT/'Assets/Res_Runtime/UI/Shop'
rows=[]
for p in sorted(runtime.glob('*.png')):
    im=Image.open(p)
    meta=p.with_suffix('.png.meta').read_text(encoding='utf-8-sig')
    border=re.search(r'spriteBorder: \{x: (.*?), y: (.*?), z: (.*?), w: (.*?)\}',meta)
    src=list((ORIG/'04_assets/Sprite').glob(p.stem+'__*.png'))
    rows.append(dict(file=p.name,size=list(im.size),borderLTRB=[float(border[1]),float(border[4]),float(border[3]),float(border[2])],guid=re.search(r'guid: (\w+)',meta)[1],originalSprite=str(src[0]) if src else None,sha256=hashlib.sha256(p.read_bytes()).hexdigest()))
(WORK/'original_inventory.json').write_text(json.dumps(rows,ensure_ascii=False,indent=2),encoding='utf-8')
sheet=Image.new('RGB',(1100,((len(rows)+3)//4)*230),'#eee6d7');d=ImageDraw.Draw(sheet)
for i,r in enumerate(rows):
    x=i%4*275;y=i//4*230
    im=Image.open(runtime/r['file']).convert('RGBA');im.thumbnail((255,165))
    sheet.paste(im,(x+(275-im.width)//2,y+10),im)
    d.text((x+6,y+180),r['file'],fill='#34291f')
    d.text((x+6,y+201),str(r['size'])+' '+str(r['borderLTRB']),fill='#34291f')
sheet.save(WORK/'original_contact_sheet.png')
# Snapshot only this task's production inputs; no snapshots of user progress.
paths=list(runtime.rglob('*'))+[ROOT/'Assets/Res_Runtime/Config/ShopConfig.asset']
paths += list((ROOT/'Assets/Src_Runtime').rglob('*Shop*.cs'))+[ROOT/'Assets/Src_Editor/EM/ShopSetupEM.cs']
snap={str(p.relative_to(ROOT)):hashlib.sha256(p.read_bytes()).hexdigest() for p in paths if p.is_file()}
(WORK/'production_before.json').write_text(json.dumps(snap,indent=2),encoding='utf-8')
print(json.dumps(rows,ensure_ascii=False,indent=2))
