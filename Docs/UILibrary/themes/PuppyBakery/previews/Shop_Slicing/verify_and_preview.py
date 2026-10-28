from pathlib import Path
import json,hashlib
import numpy as np
from PIL import Image,ImageDraw,ImageFont
ROOT=Path('D:/UnityProject/Hamdoku2');THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=Path(__file__).resolve().parent;OUT=THEME/'assets/UI/Shop'
manifest=json.loads((OUT/'manifest.json').read_text(encoding='utf-8'))
rows=manifest['assets'];specs={r['file']:r for r in rows};layout=[]
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def sliced(im,size,border,scale=1):
    if scale!=1:
        im=im.resize((round(im.width*scale),round(im.height*scale)),Image.Resampling.LANCZOS)
        border=[round(v*scale) for v in border]
    l,t,r,b=map(int,border);w,h=im.size;tw,th=size
    sx=[0,l,w-r,w];sy=[0,t,h-b,h];dx=[0,l,tw-r,tw];dy=[0,t,th-b,th]
    out=Image.new('RGBA',size)
    for y in range(3):
        for x in range(3):
            p=im.crop((sx[x],sy[y],sx[x+1],sy[y+1]))
            target=(dx[x+1]-dx[x],dy[y+1]-dy[y])
            if min(target)>0:out.alpha_composite(p.resize(target,Image.Resampling.LANCZOS),(dx[x],dy[y]))
    return out
canvas=Image.open(OUT/'shop_background.png').convert('RGBA')
def place(name,box,nine=False):
    x,y,w,h=box;im=Image.open(OUT/name).convert('RGBA')
    scale=.35 if name.startswith('shop_pad_') or name.startswith('shop_btn_') else 1
    if nine:im=sliced(im,(w,h),specs[name]['borderLTRB'],scale)
    else:
        ratio=min(w/im.width,h/im.height);im=im.resize((round(im.width*ratio),round(im.height*ratio)),Image.Resampling.LANCZOS)
        x+=(w-im.width)//2;y+=(h-im.height)//2
    canvas.alpha_composite(im,(x,y));layout.append(dict(file=name,rect=list(box),nineSlice=nine,borderDisplayScale=scale if nine else None))
def txt(text,xy,size,color='#58371f',anchor='mm'):
    f=ImageFont.truetype('C:/Windows/Fonts/msyhbd.ttc',size)
    ImageDraw.Draw(canvas).text(xy,text,font=f,fill=color,anchor=anchor)
place('shop_title_banner.png',(125,48,830,345));place('icon_close.png',(942,28,108,115))
txt('商店',(540,317),66)
for box in [(76,420,928,490),(76,953,928,382),(76,1378,928,395)]:place('shop_section_panel.png',box,True)
place('shop_remove_ads.png',(124,454,174,174));txt('移除广告',(330,487),44,anchor='lm')
txt('移除强制广告（插页与横幅）。',(332,546),25,anchor='lm')
txt('奖励广告仍可使用。',(332,584),25,anchor='lm')
for i,(duration,price) in enumerate(zip(['1天','1周','永久'],['JP¥210','JP¥650','JP¥1,580'])):
    x=119+290*i;place('shop_pad_ads.png',(x,644,265,240),True)
    txt(duration,(x+132,665),29,'#fffaf0')
    place('icon_infinity.png' if i==2 else 'icon_calendar.png',(x+91,716,82,70))
    place('shop_btn_magnifier.png',(x+14,805,237,63),True);txt(price,(x+132,836),28,'#fffaf0')
for hint,top,title,desc in [(False,953,'放大镜','用放大镜找出躲起来的小狗！'),(True,1378,'提示','卡关时告诉你下一步和理由！')]:
    tab='shop_tab_hint.png' if hint else 'shop_tab_magnifier.png'
    place(tab,(98,top-20,270 if not hint else 240,78),True)
    place('shop_tab_bulb.png' if hint else 'shop_tab_paw.png',(119,top-4,52,45))
    txt(title,(250 if not hint else 241,top+19),35,'#fffaf0')
    txt(desc,(216,top+94),28,anchor='lm')
    place('shop_hint.png' if hint else 'shop_magnifier.png',(99,top+142,226,225))
    for i,(count,price) in enumerate(zip([5,20,50],['JP¥210','JP¥650','JP¥1,580'])):
        x=355+i*208;y=top+128
        place('shop_pad_hint.png' if hint else 'shop_pad_magnifier.png',(x,y,190,244),True)
        txt(str(count)+'个',(x+95,y+21),27,'#fffaf0')
        place('shop_hint.png' if hint else 'shop_magnifier_small.png',(x+23,y+91,65,73))
        txt('×'+str(count),(x+135,y+128),28)
        place('shop_btn_hint.png' if hint else 'shop_btn_magnifier.png',(x+10,y+181,170,54),True)
        txt(price,(x+95,y+208),21,'#fffaf0')
txt('恢复购买',(540,1840),32,'#5a8cb3')
canvas.save(WORK/'page_layers_reassembled_1080x1920.png')
(WORK/'layout_reference.json').write_text(json.dumps(dict(designSize=[1080,1920],note='Offline proposed layer assembly, Windows font; not current Unity layout or runtime screenshot.',layers=layout),ensure_ascii=False,indent=2),encoding='utf-8')
results=[]
for row in rows:
    im=Image.open(OUT/row['file']);a=np.array(im.getchannel('A'));l,t,r,b=row['borderLTRB']
    entry=dict(file=row['file'],sizeMatch=list(im.size)==row['size'],rgba=im.mode=='RGBA',nonempty=im.getbbox() is not None,hashMatch=sha(OUT/row['file'])==row['sha256'],borderValid=l+r<im.width and t+b<im.height)
    if row['file']!='shop_background.png':entry['transparentCorners']=all(int(a[y,x])==0 for y,x in [(0,0),(0,-1),(-1,0),(-1,-1)])
    if row['originalSprite']:
        source_size=Image.open(row['originalSprite']).size
        if source_size!=im.size:
            entry['originalExportCanvas']=list(source_size)
            entry['canvasNote']='Current production close sprite uses 249x256 trimmed canvas; candidate intentionally preserves production dimensions rather than original export padding.'
    results.append(entry)
before=json.loads((WORK/'production_before.json').read_text())
changes=[p for p,h in before.items() if not (ROOT/p).exists() or sha(ROOT/p)!=h]
added=[str(p.relative_to(ROOT)) for p in (ROOT/'Assets/Res_Runtime/UI/Shop').rglob('*') if p.is_file() and str(p.relative_to(ROOT)) not in before]
verification=dict(environment='Windows; bundled Python, Pillow, NumPy',assetCount=len(rows),assets=results,productionInputsChanged=changes,productionFilesAdded=added,allAssetChecksPassed=all(all(v for k,v in r.items() if k!='file') for r in results),unityImport=False,unityCompile=False,playMode=False,addressablesBuild=False,applicationBuild=False,deviceValidation=False,firstAttempts='Initial script needed unavailable SciPy; replaced with Pillow/NumPy operations. Host temporarily exhausted memory; successful rerun later. First visual pass caught incomplete close icon and contaminated panel; fixed before delivery.')
(WORK/'verification.json').write_text(json.dumps(verification,ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(verification,ensure_ascii=False,indent=2))
