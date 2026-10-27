from pathlib import Path
import json
from PIL import Image
import numpy as np
ROOT=Path(r'D:/UnityProject/Hamdoku2')
T=ROOT/'Docs/UILibrary/themes/PuppyBakery'
W=T/'previews/Logo_Slicing'
O=T/'assets/UI/Logo'
manifest=json.loads((O/'manifest.json').read_text(encoding='utf-8'))
by={a['file']:a for a in manifest['assets']}
page=Image.open(T/'previews/Panel_Logo_overall_v01_1080x1920.png').convert('RGBA')
layout=[]

def restore(name):
 rec=by[name];meta=rec['normalization'];rect=rec['sourceRect1080x1920']
 box=meta['trim'];pad=meta['padding'];wh=meta['contentSize']
 im=Image.open(O/name).convert('RGBA').crop((pad[0],pad[1],pad[0]+wh[0],pad[1]+wh[1]))
 im=im.resize((box[2]-box[0],box[3]-box[1]),Image.Resampling.LANCZOS)
 out=Image.new('RGBA',(rect[2]-rect[0],rect[3]-rect[1]))
 out.alpha_composite(im,(box[0],box[1]))
 # Display rectangle accounts for texture padding, so replacement artwork is not squashed.
 scale=(box[2]-box[0])/wh[0]
 center=[rect[0]+box[0]-pad[0]*scale+rec['width']*scale/2,rect[1]+box[1]-pad[1]*scale+rec['height']*scale/2]
 layout.append({'file':name,'pageCenterTopLeftOrigin':center,'pageDisplaySize':[rec['width']*scale,rec['height']*scale],'note':'Offline reconstruction placement only; integrate with LogoConfig and parent transforms separately.'})
 return out,rect

bg=Image.open(O/'bg_Common_Menu.png').convert('RGBA').resize((1080,1920),Image.Resampling.LANCZOS)
# Static source-preserving final logo overlay.
static=bg.copy();logo,rect=restore('Img_Common_Logo.png');static.alpha_composite(logo,(rect[0],rect[1]))
# Layered animation rest-pose review, generated blank plate underneath extracted title/paws.
layered=bg.copy()
for name in ['Img_Logo_HamsterBody.png','Img_Logo_Eyes_Open.png']:
 im,rect=restore(name);layered.alpha_composite(im,(rect[0],rect[1]))
blank=Image.open(W/'plaque_blank_generated.png').convert('RGBA')
a=np.array(blank);a[:,:,3]=np.where(a[:,:,3]>200,255,0).astype('uint8');blank=Image.fromarray(a)
blank=blank.crop(blank.getchannel('A').getbbox()).resize((960,460),Image.Resampling.LANCZOS)
layered.alpha_composite(blank,(60,790))
for name in ['Img_Logo_BoardFront.png','Img_Logo_Cross.png','Img_Logo_BellyOverlay.png']:
 im,rect=restore(name);layered.alpha_composite(im,(rect[0],rect[1]))
# Caption raster shown only in review to compare against approved page. Runtime remains TMP.
for box in [(220,1285,865,1430),(450,1820,650,1875)]:
 text=page.crop(box);a=np.array(text)
 m=(a[:,:,0]<160)&(a[:,:,1]<130)&(a[:,:,2]<130)
 a[:,:,3]=m.astype('uint8')*255;text=Image.fromarray(a)
 static.alpha_composite(text,(box[0],box[1]));layered.alpha_composite(text,(box[0],box[1]))
for name,centers in [('Img_Logo_LoadingSeed.png',[342,441]),('Img_Logo_LoadingSeed_Empty.png',[540,639,738])]:
 im,rect=restore(name)
 for center in centers:
  static.alpha_composite(im,(round(center-im.width/2),rect[1]));layered.alpha_composite(im,(round(center-im.width/2),rect[1]))
static.save(W/'page_static_reassembled_1080x1920.png')
layered.save(W/'page_layers_reassembled_1080x1920.png')
layout_data={'status':'offline-artwork-layout-reference-not-applied','pageSize':[1080,1920],'placements':layout,'blankBoardPageRect':[60,790,960,460],'background':'Background has awning: runtime EnvelopeParent cropping may hide it; integrate background top alignment or separate awning after reviewing in Unity.','text':{'quoteZh':'烤一份香甜，解一道数独。','authorZh':'— 小汪的烘焙日记 —','footer':'Sudoku Pup','runtime':'Use existing L10NSO and TMP, do not bake functional captions into background.'},'integrationRequired':['LogoConfig part display sizes and centers must be updated for the approved taller two-line sign; old geometry is not equivalent.','Paws now use BellyOverlay slot; must appear over the sign edge.','Cross stamp is the ivory paw inside letter o. Use its source-aware display center and size; the underlying letter o is now solid.','Preserve destination meta files, GUIDs and sprite-pop subrect names/IDs.','Check the animated-to-static switch, clipping mask, blink alignment and actual portrait viewport in Unity.']}
(W/'layout_reference.json').write_text(json.dumps(layout_data,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
# Keep root mapping comprehensive but don't imply implementation was performed.
root_manifest=json.loads((T/'manifest.json').read_text(encoding='utf-8'))
root_manifest['gameName']='Sudoku Pup'
root_manifest['pages']=[{'page':'Panel_Logo','manifest':'assets/UI/Logo/manifest.json','status':'sliced-artwork-not-unity-validated','count':13,'review':'previews/Logo_Slicing/contact_sheet_v01.png'}]
(T/'manifest.json').write_text(json.dumps(root_manifest,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
print('Saved static and layered offline review pages, source-aware layout JSON, and root manifest mapping.')
