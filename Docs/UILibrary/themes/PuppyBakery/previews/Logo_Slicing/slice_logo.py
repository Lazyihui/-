from pathlib import Path
import json, hashlib
import numpy as np
from PIL import Image, ImageFilter, ImageDraw, ImageFont
from scipy import ndimage as ndi

ROOT=Path(r'D:/UnityProject/Hamdoku2')
THEME=ROOT/'Docs/UILibrary/themes/PuppyBakery'
WORK=THEME/'previews/Logo_Slicing'
OUT=THEME/'assets/UI/Logo'
ORIG=ROOT/'Assets/Res_Runtime/UI/Logo'
SOURCE=Image.open(THEME/'previews/Panel_Logo_overall_v01_1080x1920.png').convert('RGBA')
records=[]

def clean(im):
 a=np.array(im.convert('RGBA')); a[a[:,:,3]==0,:3]=0
 return Image.fromarray(a)

def largest(mask):
 labels,n=ndi.label(mask)
 sizes=np.bincount(labels.ravel());sizes[0]=0
 return labels==sizes.argmax()

def outline_extract(im):
 a=np.array(im.convert('RGBA'))
 dark=(a[:,:,0]<155)&(a[:,:,1]<125)&(a[:,:,2]<125)&(a[:,:,3]>100)
 edge=largest(ndi.binary_closing(dark,iterations=2))
 mask=ndi.binary_fill_holes(edge)
 mask=ndi.binary_dilation(mask,iterations=1)
 a[:,:,3]=mask.astype('uint8')*255
 return clean(Image.fromarray(a))

def mask_image(im,mask):
 a=np.array(im.convert('RGBA'));a[:,:,3]=np.clip(mask,0,1)*a[:,:,3]
 return clean(Image.fromarray(a))

def fit(im,size):
 im=im.convert('RGBA')
 box=im.getchannel('A').getbbox()
 if not box: raise ValueError('Empty sprite')
 im=im.crop(box)
 scale=min((size[0]-2)/im.width,(size[1]-2)/im.height)
 wh=(max(1,round(im.width*scale)),max(1,round(im.height*scale)))
 resized=im.resize(wh,Image.Resampling.LANCZOS)
 result=Image.new('RGBA',size)
 pos=((size[0]-wh[0])//2,(size[1]-wh[1])//2)
 result.alpha_composite(resized,pos)
 return clean(result),{'trim':list(box),'fitScale':scale,'padding':list(pos),'contentSize':list(wh)}

def save(name,im,description,source_rect=None,opaque=False):
 size=Image.open(ORIG/name).size
 if opaque:
  result=im.convert('RGBA').resize(size,Image.Resampling.LANCZOS)
  result.putalpha(255);meta={}
 else:
  result,meta=fit(im,size)
 result.save(OUT/name)
 rec={'file':name,'width':size[0],'height':size[1],'mode':'RGBA','description':description,'sourceRect1080x1920':source_rect,'normalization':meta,'sha256':hashlib.sha256((OUT/name).read_bytes()).hexdigest()}
 records.append(rec)
 return result

# Preserve the exact approved logo pixels; remove only the page background.
master_box=(60,420,1020,1250)
master=outline_extract(SOURCE.crop(master_box))
master.save(WORK/'logo_extracted_master.png')
save('Img_Common_Logo.png',master,'Approved page logo extracted without regenerating its face or lettering.',list(master_box))
save('bg_Common_Menu.png',Image.open(WORK/'background_clean_generated.png'),'Generated clean background; no logo, text or loading icons.',opaque=True)

# Empty sign is a reconstructed lower plate; retain generated texture and contour.
blank=Image.open(WORK/'plaque_blank_generated.png').convert('RGBA')
blank=outline_extract(blank)
blank=blank.crop(blank.getchannel('A').getbbox())
save('Img_Logo_BoardBack.png',blank,'Reconstructed blank cream sign with blue inner trim; no letters.')

# Lettering and ornaments are a transparent overlay extracted from the approved sign.
front_box=(100,850,980,1210)
front=SOURCE.crop(front_box)
a=np.array(front)
colored=((a[:,:,0]<170)&(a[:,:,1]<145)&(a[:,:,2]<145))|((a[:,:,2]>a[:,:,0]+8)&(a[:,:,1]>a[:,:,0]+4)&(a[:,:,0]<205))
# Remove the outside outline and blue trim; keep the artwork centrally inset.
yy,xx=np.indices(colored.shape)
inside=(xx>20)&(xx<860)&(yy>0)&(yy<345)
colored &= inside
# Keep interior components, exclude frame fragments near side/bottom edges.
labels,n=ndi.label(colored)
keep=np.zeros_like(colored)
for label in range(1,n+1):
 ys,xs=np.where(labels==label)
 if len(xs)>=8 and xs.min()>27 and xs.max()<850 and ys.min()>5 and ys.max()<343:
  keep[labels==label]=True
keep=ndi.binary_dilation(keep,iterations=1)&inside
front=mask_image(front,keep)
save('Img_Logo_BoardFront.png',front,'Transparent Sudoku Pup lettering, sudoku grid and blue ornaments extracted from approved page.',list(front_box))
front.save(WORK/'front_master.png')

# Use original puppy pixels for visible anatomy; generated clean fur supplies eye-hole patches only.
head_box=(160,425,920,825)
head=SOURCE.crop(head_box)
full_alpha=master.getchannel('A')
head.putalpha(full_alpha.crop((head_box[0]-master_box[0],head_box[1]-master_box[1],head_box[2]-master_box[0],head_box[3]-master_box[1])))
# The bottom is naturally occluded by the plaque; no head/background pixels below its crest.
ha=np.array(head)
hy,hx=np.indices(ha.shape[:2])
region=(hy<340)|((hx>140)&(hx<620)&(hy<385))
ha[:,:,3]=ha[:,:,3]*region
head=Image.fromarray(ha)
# Remove separate dark eyes by patching with nearby same-color fur texture.
for box,donor in [((250,220,315,282),(245,147,310,209)),((438,220,505,282),(438,150,505,212))]:
 patch=head.crop(donor).resize((box[2]-box[0],box[3]-box[1]),Image.Resampling.LANCZOS)
 local=head.crop(box)
 ar=np.array(local)
 eye=(ar[:,:,0]<160)&(ar[:,:,1]<125)&(ar[:,:,2]<125)
 eye=ndi.binary_dilation(eye,iterations=3)
 feather=Image.fromarray(eye.astype('uint8')*255).filter(ImageFilter.GaussianBlur(1.2))
 head.paste(patch,(box[0],box[1]),feather)
head=clean(head)
head.save(WORK/'head_master.png')
save('Img_Logo_HamsterBody.png',head,'Puppy base extracted from approved page, with eyes removed for overlay animation.',list(head_box))
# Mask is technical alpha, not visible colored artwork.
mask=Image.new('RGBA',head.size,(255,255,255,0));mask.putalpha(head.getchannel('A'))
save('Img_Logo_HamsterMask.png',mask,'White technical clipping mask derived from the puppy base silhouette.',list(head_box))

# Extract two open eyes with original separation.
eye_box=(412,643,667,706)
eyes=SOURCE.crop(eye_box)
a=np.array(eyes)
m=(a[:,:,0]<160)&(a[:,:,1]<125)&(a[:,:,2]<125)
lab,n=ndi.label(m);counts=np.bincount(lab.ravel());counts[0]=0
ids=np.argsort(counts)[-2:]
m=np.isin(lab,ids)
eyes=mask_image(eyes,ndi.binary_dilation(m,iterations=1))
save('Img_Logo_Eyes_Open.png',eyes,'Two eyes extracted from approved puppy.',list(eye_box))
blink=Image.open(WORK/'eyes_blink_generated.png').convert('RGBA')
a=np.array(blink);dark=(a[:,:,0]<170)&(a[:,:,1]<135)&(a[:,:,2]<130)&(a[:,:,3]>80)
lab,n=ndi.label(dark);counts=np.bincount(lab.ravel());counts[0]=0
ids=np.argsort(counts)[-2:];blink=mask_image(blink,ndi.binary_dilation(np.isin(lab,ids),iterations=1))
save('Img_Logo_Eyes_Blink.png',blink,'Generated two closed-eye arcs; transparent overlay.')

# Foreground paws preserve the source page's exact line work.
paws_box=(300,758,780,860)
paws=SOURCE.crop(paws_box)
pa=np.array(paws);combined=np.zeros(pa.shape[:2],bool)
for l,t,r,b in [(2,2,145,100),(330,2,477,100)]:
 part=paws.crop((l,t,r,b))
 ar=np.array(part)
 dark=(ar[:,:,0]<160)&(ar[:,:,1]<130)&(ar[:,:,2]<130)
 barrier=ndi.binary_closing(dark,iterations=1)
 seed=np.zeros(barrier.shape,bool);seed[48,70]=True
 interior=ndi.binary_propagation(seed,mask=~barrier)
 if interior.sum()>barrier.size*.8: raise ValueError('Paw boundary is open')
 pm=ndi.binary_dilation(interior,iterations=6)
 combined[t:b,l:r] |= pm
paws=mask_image(paws,combined)
save('Img_Logo_BellyOverlay.png',paws,'Two foreground puppy paws, replacing original belly seam cover.',list(paws_box))
paws.save(WORK/'paws_master.png')

# Loading biscuit: exact page crop with filled interior mask.
filled_box=(297,1505,386,1596)
filled=SOURCE.crop(filled_box)
fa=np.array(filled)
fm=(fa[:,:,0]<225)&(fa[:,:,1]<190)&(fa[:,:,2]<145)
fm=ndi.binary_fill_holes(largest(ndi.binary_closing(fm,iterations=1)))
filled=mask_image(filled,ndi.binary_dilation(fm,iterations=1))
save('Img_Logo_LoadingSeed.png',filled,'Filled paw biscuit extracted from approved loading row.',list(filled_box))
empty_box=(497,1505,585,1596)
empty=SOURCE.crop(empty_box)
a=np.array(empty)
dark=(a[:,:,0]<200)&(a[:,:,1]<170)&(a[:,:,2]<145)
# Outline remains hollow, matching the dashed empty-state drawing.
empty=mask_image(empty,ndi.binary_dilation(dark,iterations=1))
save('Img_Logo_LoadingSeed_Empty.png',empty,'Hollow paw-shaped empty loading indicator extracted from approved page.',list(empty_box))

# Paw stamp: alpha extraction of existing colored paw print, no invented drawing.
stamp_box=(137,1015,198,1082)
stamp=SOURCE.crop(stamp_box);a=np.array(stamp)
blue=(a[:,:,2]>a[:,:,0]+8)&(a[:,:,1]>a[:,:,0]+4)&(a[:,:,0]<205)
stamp=mask_image(stamp,ndi.binary_dilation(blue,iterations=1))
save('Img_Logo_Cross.png',stamp,'Blue paw stamp replaces original X mark.',list(stamp_box))

# Existing multiple-sprite contract uses three fixed rectangles; fill them from one extracted paw.
pop=Image.new('RGBA',(128,76))
rects=[(0,24,45,51),(43,1,41,61),(83,24,45,51)]
for i,(x,y,w,h) in enumerate(rects):
 paw=stamp.crop(stamp.getchannel('A').getbbox()).rotate([24,0,-24][i],resample=Image.Resampling.BICUBIC,expand=True)
 tile,_=fit(paw,(w,h))
 pop.alpha_composite(tile,(x,y))
# Preserve full sprite-sheet coordinates rather than trimming/repacking.
pop=clean(pop);pop.save(OUT/'Img_Logo_LoadingSeed_Pop.png')
records.append({'file':'Img_Logo_LoadingSeed_Pop.png','width':128,'height':76,'mode':'RGBA','description':'Three paw pop pieces preserving existing Unity sprite rects and indices.','unitySpriteRects':[{'name':'seed_pop_0','rect':[0,1,45,51]},{'name':'seed_pop_1','rect':[43,14,41,61]},{'name':'seed_pop_2','rect':[83,1,45,51]}],'sha256':hashlib.sha256((OUT/'Img_Logo_LoadingSeed_Pop.png').read_bytes()).hexdigest()})

manifest={'gameName':'Sudoku Pup','date':'2026-10-27','status':'sliced-artwork-not-unity-validated','approvedPage':'../../../previews/Panel_Logo_overall_v01_1080x1920.png','sourceDirectory':'Assets/Res_Runtime/UI/Logo','outputDirectory':'Docs/UILibrary/themes/PuppyBakery/assets/UI/Logo','note':'Names and pixel sizes match current runtime directory. Do not copy meta files. Existing layout does not match taller approved plaque; animation display sizes/centers need integration before runtime equivalence can be claimed. Chinese quote and credits stay TMP/localization text, not baked into background.','assets':records}
(OUT/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
# Contact sheet on a checkerboard, all outputs at readable scale.
W,H=1200,5*230
sheet=Image.new('RGB',(W,H),'#f1eee8');d=ImageDraw.Draw(sheet)
font=ImageFont.truetype('C:/Windows/Fonts/consola.ttf',15)
for i,rec in enumerate(records):
 x=(i%3)*400;y=(i//3)*230
 for cy in range(y+35,y+225,14):
  for cx in range(x+5,x+395,14):
   if ((cx-x)//14+(cy-y)//14)%2==0:d.rectangle((cx,cy,cx+13,cy+13),fill='#d8d8d8')
 im=Image.open(OUT/rec['file']).convert('RGBA');im.thumbnail((380,170),Image.Resampling.LANCZOS)
 sheet.paste(im,(x+(400-im.width)//2,y+40+(170-im.height)//2),im)
 d.text((x+8,y+2),rec['file'],fill='#292929',font=font)
 d.text((x+8,y+19),f"{rec['width']} x {rec['height']}",fill='#555555',font=font)
sheet.save(WORK/'contact_sheet_v01.png')
# Mandatory file/size/alpha contract validation.
report=[]
for p in sorted(ORIG.glob('*.png')):
 q=OUT/p.name
 assert q.exists(),p.name
 a=Image.open(p);b=Image.open(q)
 assert a.size==b.size,(p.name,a.size,b.size)
 assert b.mode=='RGBA'
 alpha=b.getchannel('A');lo,hi=alpha.getextrema()
 if p.name!='bg_Common_Menu.png':assert lo==0 and hi==255,p.name
 report.append({'file':p.name,'expectedSize':list(a.size),'actualSize':list(b.size),'alphaRange':[lo,hi],'pass':True})
(WORK/'validation.json').write_text(json.dumps({'checks':report,'unityPlayMode':'not-run','runtimeReplacement':'not-performed'},indent=2)+'\n',encoding='utf-8')
print('Created and size/alpha checked',len(records),'PNGs.')
