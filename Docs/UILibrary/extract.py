"""Copy original evidence into this offline library. Never modifies the source project."""
import argparse
import hashlib
import json
import shutil
from pathlib import Path
from PIL import Image

ROOT = Path(__file__).resolve().parent
parser = argparse.ArgumentParser()
parser.add_argument('--source', type=Path, default=Path(r'D:\0000001apkUnbag\01_逆向工程项目\Hamdoku2'))
args = parser.parse_args()
source = args.source.resolve()
mapping = json.loads((source / '07_reports/asset_map.json').read_text(encoding='utf-8'))
assets = []
for item in mapping:
    if item['type'] not in ('Sprite', 'Font'):
        continue
    for output in item['outputs']:
        original = source / output.replace('\\', '/')
        if original.suffix.lower() not in ('.png', '.ttf', '.otf'):
            continue
        relative = Path('assets') / item['type'] / original.name
        target = ROOT / relative
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(original, target)
        record = dict(key=f"{item['type']}:{item['source']}:{item['path_id']}", name=item.get('name', original.stem),
                      type=item['type'], file=relative.as_posix(), source=output.replace('\\', '/'),
                      sourceBundle=item['source'], pathID=item['path_id'],
                      sha256=hashlib.sha256(original.read_bytes()).hexdigest())
        if original.suffix.lower() == '.png':
            with Image.open(original) as picture:
                record['size'] = list(picture.size)
                record['alphaBounds'] = picture.convert('RGBA').getchannel('A').getbbox()
            record['spriteBorder'] = None
        assets.append(record)

evidence = []
for pattern in ('GameConfig__*.json', 'BoardView__*.json', 'ButtonPressEffect__*.json', 'LogoAnimator__*.json', 'CanvasScaler__level1__145.json', 'CanvasScaler__level2__147.json'):
    for original in sorted((source / '05_data/Configs').glob(pattern)):
        target = ROOT / 'evidence' / original.name
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(original, target)
        evidence.append(dict(file=target.relative_to(ROOT).as_posix(), source=original.relative_to(source).as_posix(),
                             sha256=hashlib.sha256(original.read_bytes()).hexdigest()))
for name in ('zh.md', 'en.md'):
    original = source / '05_data/Localization' / name
    target = ROOT / 'evidence' / ('localization-' + name)
    shutil.copyfile(original, target)
    evidence.append(dict(file=target.relative_to(ROOT).as_posix(), source=original.relative_to(source).as_posix(),
                         sha256=hashlib.sha256(original.read_bytes()).hexdigest()))

references = []
for name in ('home-first.png', 'home-unlocked.png', 'home-english.png', 'home-wide.png'):
    original = ROOT.parents[1] / 'Logs/HomeValidation' / name
    if original.exists():
        target = ROOT / 'references' / name
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(original, target)
        references.append(dict(file=target.relative_to(ROOT).as_posix(), origin='当前复刻工程 Unity 验证截图，非原应用截图',
                               source=original.relative_to(ROOT.parents[1]).as_posix(),
                               sha256=hashlib.sha256(original.read_bytes()).hexdigest()))

manifest = dict(title='Hamdoku2 UI Library', extracted='2026-10-27', sourceRoot=str(source),
                apkSHA256='0079af1d59afafe461c5eccf736b74d0a9d79090599454777f05caa00f59192c',
                scope='全部已导出 Sprite 与 Font；不重复复制 Texture2D、音频和 SDK 原始对象',
                assets=assets, evidence=evidence, references=references)
serialized = json.dumps(manifest, ensure_ascii=False, indent=2)
(ROOT / 'manifest.json').write_text(serialized, encoding='utf-8')
(ROOT / 'catalog.js').write_text('window.UI_CATALOG = ' + serialized + ';\n', encoding='utf-8')
print(f'Copied {len(assets)} assets, {len(evidence)} evidence files, {len(references)} reconstruction screenshots.')
