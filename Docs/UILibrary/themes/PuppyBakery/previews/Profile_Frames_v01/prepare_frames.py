"""Normalize generated artwork only; previews are offline and never Unity screenshots."""
from pathlib import Path
import hashlib
import json
import math
import re

import numpy as np
from PIL import Image, ImageDraw, ImageFont

ROOT = Path(__file__).resolve().parents[6]
THEME = ROOT / 'Docs/UILibrary/themes/PuppyBakery'
PREVIEW = Path(__file__).resolve().parent
OUTPUT = THEME / 'assets/UI/Profile/Frames/v01'
FONT = Path('C:/Windows/Fonts/msyh.ttc')


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def opening(image, decorated=None):
    alpha = np.asarray(image.getchannel('A'))
    height, width = alpha.shape
    decorated = height != width if decorated is None else decorated
    cx, cy = width // 2, int(height * (0.568 if decorated else 0.5))
    assert alpha[cy, cx] < 8, 'Center is not transparent'
    # Measure contiguous clear opening across its center. Ignore transparent RGB.
    row = alpha[cy] < 32
    col = alpha[:, cx] < 32
    left = cx
    while left > 0 and row[left - 1]:
        left -= 1
    right = cx
    while right < width - 1 and row[right + 1]:
        right += 1
    top = cy
    while top > 0 and col[top - 1]:
        top -= 1
    bottom = cy
    while bottom < height - 1 and col[bottom + 1]:
        bottom += 1
    assert 0 < left < right < width - 1 and 0 < top < bottom < height - 1, 'Unclosed frame ring'
    return [left, top, right + 1, bottom + 1]


def normalize(raw, target_size, source_opening, target_opening):
    # Piecewise coordinate resampling aligns the four opening edges, without
    # borrowing any old colors, pixels, alpha silhouette, or border artwork.
    sw, sh = raw.size
    tw, th = target_size
    sx = [0, source_opening[0], source_opening[2], sw]
    sy = [0, source_opening[1], source_opening[3], sh]
    tx = [0, target_opening[0], target_opening[2], tw]
    ty = [0, target_opening[1], target_opening[3], th]
    # Premultiplied interpolation prevents dark/colored transparent RGB fringes.
    premult = raw.convert('RGBa')
    mesh = []
    for row in range(3):
        for column in range(3):
            box = (tx[column], ty[row], tx[column + 1], ty[row + 1])
            quad = (sx[column], sy[row], sx[column], sy[row + 1],
                    sx[column + 1], sy[row + 1], sx[column + 1], sy[row])
            mesh.append((box, quad))
    return premult.transform((tw, th), Image.Transform.MESH, mesh,
                            resample=Image.Resampling.BICUBIC).convert('RGBA')


def fit(image, size):
    result = image.copy()
    result.thumbnail(size, Image.Resampling.LANCZOS)
    return result


def draw_image(canvas, image, box):
    x, y, w, h = box
    thumb = fit(image, (w, h))
    canvas.alpha_composite(thumb, (x + (w - thumb.width) // 2, y + (h - thumb.height) // 2))


def portrait_composite(frame, face):
    # Offline approximation of current Widget_ProfilePortrait sizes and clipping.
    # Use the opening as the actual clip. No runtime layout is changed.
    box = opening(frame)
    width, height = frame.size
    result = Image.new('RGBA', frame.size)
    clip = Image.new('L', frame.size, 0)
    alpha = np.asarray(frame.getchannel('A'))
    clear = Image.fromarray(np.where(alpha < 32, 255, 0).astype('uint8'))
    flood = clear.convert('RGB')
    ImageDraw.floodfill(flood, ((box[0] + box[2]) // 2, (box[1] + box[3]) // 2), (255, 0, 255))
    values = np.asarray(flood)
    hole = (values[:, :, 0] == 255) & (values[:, :, 1] == 0) & (values[:, :, 2] == 255)
    clip = Image.fromarray((hole * 255).astype('uint8'))
    plate = Image.new('RGBA', frame.size, '#F5E9D5')
    plate.putalpha(clip)
    result.alpha_composite(plate)
    opening_width, opening_height = box[2] - box[0], box[3] - box[1]
    pup = fit(face, (int(opening_width * 0.91), int(opening_height * 0.91)))
    layer = Image.new('RGBA', frame.size)
    layer.alpha_composite(pup, ((box[0] + box[2] - pup.width) // 2,
                               (box[1] + box[3] - pup.height) // 2))
    la = np.asarray(layer.getchannel('A'))
    layer.putalpha(Image.fromarray(np.where(hole, la, 0).astype('uint8')))
    result.alpha_composite(layer)
    result.alpha_composite(frame)
    return result


def main():
    OUTPUT.mkdir(parents=True, exist_ok=True)
    plan = json.loads((PREVIEW / 'generation_plan.json').read_text(encoding='utf-8-sig'))
    extras = json.loads((PREVIEW / 'generation_outputs.json').read_text(encoding='utf-8-sig'))
    paths = {item['id']: item['generatedPath'] for item in extras}
    before = json.loads((PREVIEW / 'runtime_before.json').read_text(encoding='utf-8-sig'))
    before_results = {path: digest(Path(path)).upper() == value.upper() for path, value in before.items()}
    external_changes = [path for path, unchanged in before_results.items() if not unchanged]
    image_checks = {path: same for path, same in before_results.items()
                    if path.endswith('.png') or path.endswith('.png.meta')}
    assert all(image_checks.values()), 'Runtime images changed since initial snapshot; review before proceeding'
    # ProfileConfig and Panel_Profile changed in another concurrent task.
    # This batch neither writes nor restores them. Capture their current bytes
    # to ensure preparation does not change them further.
    reviewed_current = {path: digest(Path(path)) for path in before}
    face = Image.open(THEME / 'assets/Sprite/hamster_idle_04__sharedassets2.assets__6.png').convert('RGBA')
    entries = []
    frames = []
    originals = []
    for item in plan:
        frame_id = item['id']
        source_path = ROOT / item['original']
        raw_path = PREVIEW / f'raw/profile_frame_{frame_id}.png'
        raw = Image.open(raw_path).convert('RGBA')
        original = Image.open(source_path).convert('RGBA')
        source_opening, target_opening = opening(raw, frame_id >= 7), opening(original, frame_id >= 7)
        frame = normalize(raw, original.size, source_opening, target_opening)
        output_path = OUTPUT / source_path.name
        frame.save(output_path)
        result_opening = opening(frame)
        assert frame.size == original.size
        assert frame.getpixel((frame.width // 2, frame.height // 2))[3] == 0
        assert max(abs(a-b) for a,b in zip(result_opening, target_opening)) <= 2, (frame_id, source_opening, target_opening, result_opening)
        assert all(frame.getpixel(point)[3] == 0 for point in
                   [(0, 0), (frame.width-1, 0), (0, frame.height-1), (frame.width-1, frame.height-1)])
        meta = source_path.with_suffix('.png.meta').read_text(encoding='utf-8-sig')
        entries.append({
            'id': frame_id, 'name': item['name'], 'original': item['original'],
            'replacement': str(output_path.relative_to(THEME)).replace('\\', '/'),
            'width': frame.width, 'height': frame.height, 'mode': frame.mode,
            'status': 'candidate-awaiting-user-review-not-installed',
            'generationTool': 'built-in image_gen',
            'prompt': item['prompt'],
            'rawWorkspacePath': str(raw_path.relative_to(THEME)).replace('\\', '/'),
            'originalGeneratedPath': item['generatedPath'] or paths.get(frame_id),
            'sourceOpening': source_opening, 'targetOpening': target_opening,
            'finalOpening': result_opening,
            'openingNormalization': '3x3 coordinate resampling in premultiplied alpha; no old image mask or art copied',
            'sourceGuid': re.search(r'^guid: (\w+)', meta, re.M).group(1),
            'sourceSpritePixelsToUnits': re.search(r'spritePixelsToUnits: (.+)', meta).group(1),
            'sourceSpriteBorder': re.search(r'spriteBorder: (.+)', meta).group(1),
            'sha256': digest(output_path), 'sourceSHA256': digest(source_path),
            'rawSHA256': digest(raw_path),
            'transparentCenter': True, 'transparentCorners': True,
            'rankRequirement': {16: 5, 17: 15, 18: 30, 19: 50}.get(frame_id),
            'runtimeTextBakedIn': False,
            'notes': '徽章、会员牌留空；数字、文案、锁头及现有光效不烘焙。未复制meta或安装正式资源。'
        })
        frames.append(frame)
        originals.append(original)
    title_font = ImageFont.truetype(str(FONT), 34)
    label_font = ImageFont.truetype(str(FONT), 19)
    small_font = ImageFont.truetype(str(FONT), 16)
    for kind in ['contact_sheet', 'puppy_overlay']:
        sheet = Image.new('RGBA', (1400, 1390), '#F8F1E5')
        draw = ImageDraw.Draw(sheet)
        draw.text((34, 22), '小狗面包房 · 19款头像边框' + (' / 头像叠放' if kind == 'puppy_overlay' else ''), font=title_font, fill='#563F31')
        draw.text((34, 73), 'v01 候选素材 · 未替换正式资源 · ' + ('离线叠放预览，非Unity运行截图' if kind == 'puppy_overlay' else '中心与外侧均为真实透明'), font=label_font, fill='#7D6B5C')
        for i, (entry, frame) in enumerate(zip(entries, frames)):
            column, row = i % 5, i // 5
            x, y = 24 + column * 275, 116 + row * 313
            draw.rounded_rectangle((x, y, x + 260, y + 296), radius=15, fill='#FFFCF5', outline='#DFD2BE', width=1)
            image = portrait_composite(frame, face) if kind == 'puppy_overlay' else frame
            draw_image(sheet, image, (x + 17, y + 8, 225, 235))
            draw.text((x + 12, y + 251), f'{entry["id"]:02}  {entry["name"]}', font=label_font, fill='#563F31')
            draw.text((x + 12, y + 276), f'{entry["width"]} × {entry["height"]}  RGBA', font=small_font, fill='#8F7B69')
        sheet.convert('RGB').save(PREVIEW / f'{kind}_v01.png')
    comparison = Image.new('RGBA', (1440, 1770), '#F8F1E5')
    draw = ImageDraw.Draw(comparison)
    draw.text((28, 20), '原图 / 小狗面包房候选图', font=title_font, fill='#563F31')
    draw.text((28, 67), '每组左为当前正式素材，右为v01候选；只重绘图片，未安装', font=label_font, fill='#7D6B5C')
    for i, (entry, frame, original) in enumerate(zip(entries, frames, originals)):
        x, y = 24 + (i % 4) * 354, 110 + (i // 4) * 326
        draw.rounded_rectangle((x, y, x+337, y+310), radius=12, fill='#FFFCF5', outline='#DFD2BE')
        draw_image(comparison, original, (x+8, y+28, 154, 216))
        draw_image(comparison, frame, (x+174, y+28, 154, 216))
        draw.text((x+45, y+4), '原图', font=small_font, fill='#8F7B69')
        draw.text((x+220, y+4), '新图', font=small_font, fill='#8F7B69')
        draw.text((x+10, y+254), f'{entry["id"]:02}  {entry["name"]}', font=label_font, fill='#563F31')
        draw.text((x+10, y+283), f'profile_frame_{entry["id"]}.png', font=small_font, fill='#8F7B69')
    comparison.convert('RGB').save(PREVIEW / 'original_vs_candidate_v01.png')
    manifest = {'batch': 'PuppyBakery.Profile.Frames.v01', 'date': '2026-10-28',
                'status': 'candidate-awaiting-user-review-not-installed', 'count': len(entries),
                'emptySlotsNotProduced': [8, 9], 'runtimeReplacementAuthorized': False,
                'scope': '19 PNG frame candidates only; no script/prefab/config/meta/addressables/save changes',
                'review': 'previews/Profile_Frames_v01/contact_sheet_v01.png',
                'overlay': 'previews/Profile_Frames_v01/puppy_overlay_v01.png',
                'comparison': 'previews/Profile_Frames_v01/original_vs_candidate_v01.png',
                'assets': entries}
    (OUTPUT / 'manifest.json').write_text(json.dumps(manifest, ensure_ascii=False, indent=2)+'\n', encoding='utf-8')
    verification = {'date': '2026-10-28', 'environment': 'Windows / bundled Python / Pillow / NumPy',
                    'count': len(entries), 'allExpectedIdsPresent': len(entries) == 19,
                    'exactCanvasDimensions': True, 'RGBA': True,
                    'centerAndCornersTransparent': True, 'closedRingsAtCenterCrossSection': True,
                    'openingEdgesMaxErrorPixels': max(max(abs(a-b) for a,b in zip(e['finalOpening'],e['targetOpening'])) for e in entries),
                    'runtimeImagesAndMetasUnchanged': all(image_checks.values()),
                    'allRuntimeFilesUnchangedSinceReviewedSnapshot': all(digest(Path(path)) == value for path, value in reviewed_current.items()),
                    'concurrentRuntimeChangesObserved': external_changes,
                    'runtimeFileCountChecked': len(before_results), 'runtimeHashChecks': before_results,
                    'unityImport': 'not-run', 'unityCompilation': 'not-run', 'playMode': 'not-run',
                    'addressablesBuild': 'not-run', 'applicationBuild': 'not-run',
                    'installation': 'not-run', 'physicalDevice': 'not-run',
                    'notes': 'Only center cross-sections align within 2 pixels; rounded silhouettes and badge geometry remain generated art, not pixel-identical original masks. Offline puppy overlay fits the opening, not an exact reproduction of runtime Widget rendering.'}
    (PREVIEW / 'verification.json').write_text(json.dumps(verification, ensure_ascii=False, indent=2)+'\n', encoding='utf-8')
    print(json.dumps({k:v for k,v in verification.items() if k != 'runtimeHashChecks'}, ensure_ascii=False, indent=2))


if __name__ == '__main__':
    main()
