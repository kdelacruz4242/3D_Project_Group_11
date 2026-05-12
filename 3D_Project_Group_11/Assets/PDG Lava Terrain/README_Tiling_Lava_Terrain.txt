====================================
=   PDG tiling Lava Terrain v1.0   =
====================================

Thank you for purchasing this asset - I hope you enjoy it as much as I did, creating it!

Please note: 

- If you need more tiling terrain-patches matching this style
_ If you need additional maps (PBR or AO) or adaption in splat map
- If you need any other custom made terrains or maps
- If you looking for someone to bring your terrain/landscapes to Unity3D
- If you implemented this asset into your project 

...just let me know!


Drop an e-mail to: unity@play-da-gaimz.de


******************
*CONTENT-OVERVIEW*
******************

This asset features:

Tiling terrains/meshes
----------------------
16x 2049x2049.raw 16-bit heightfields to create Unity terrains from
16x 2048x2048.png normal maps, matching the unity tangent space
16x 2048x2048.png Textures
16x 2048x2048.png Splat maps (RGBA) R=Lower areas G=Higher areas B=Steep areas A='flow lines'

16x low poly meshes (around 3k tris) in .OBJ format, center=origin, Y=up orientation


Single terrain/mesh/textures 'BIG_lava'
---------------------------------------
1x 2049x2049.raw 16-bit heightfield, covering all 16-tiles at once
1x 2048x2048.png normal map, matching the unity tangent space
1x 2048x2048.png Texture
1x 2048x2048.png Splat map (RGBA) R=Lower areas G=Higher areas B=Steep areas A='flow lines'

1x low poly mesh (around 5k tris) in .OBJ format, center=origin, Y=up orientation
1x low poly mesh (around 10k tris) in .OBJ format, center=origin, Y=up orientation
1x low poly mesh (around 30k tris) in .OBJ format, center=origin, Y=up orientation


Additional goodies
------------------
1x Unity scene 'Meshes' (hosts an example of tiling meshes)
1x Unity scene 'Terrains' (hosts an example of tiling terrains)

1x 'TerrainSticher' Javascript for making unity-terrain LOD seamless at runtime (At runtime!)

3x tiling detail textures for painting or use with splat maps
3x bump maps to augment detail textures

6x 2048x2048.png Skybox textures



Some technical information
--------------------------

- Remember to set the textures (except for detail textures and splat maps) to 'clamp` instead of ´repeat´ 
  to get a 100% smooth and seamless tiling for meshes, terrains and skybox

- Textures look best when set to '2048' and 'Truecolor' in the inspector window

- Textures with '_TN' are normal maps, textures with '_TX' are color maps

- Detail textures with '_height' are bump maps (set to 'normal map' in inspector)

- Good scaling factors for the .raw files are X=2000X Y=370 Z=2000, byte-order is 'Windows'

- Splat maps must be set to RGBA 32-bit, read/write enabled

- If you're using Marmoset Skyshop´s 'Terrain->Import Splat map' script, keep 'Flip-Y Axis' checked, when importing splat maps

- To make terrains LOD´s seamless, use the provided 'TerrainStitcher' script.
  Just drag over the script to all your terrain-tiles in hierarchy tree and remember to set neighbor for
  each terrain. Like when telling 'Terrain1', that 'Terrain2' is the left neighbor - you also have to tell
  'Terrain2', that 'Terrain1' is the right neighbor. (See example setup in 'Terrains' scene)

- Remember you can set a 'pixel error value' for the terrains (1=ultra quality, 5=lower quality from distance)



Placing tiling terrains
-----------------------

Terrains must be placed in a specific order, to get matching borders:

+----+----+----+----+
+x0y3+x1y3+x2y3+x3y3+
+----+----+----+----+
+x0y2+x1y2+x2y2+x3y2+
+----+----+----+----+
+x0y1+x1y1+x2y1+x3y1+
+----+----+----+----+
+x0y0+x1y0+x2y0+x3y0+
+----+----+----+----+

(see demo scene 'Tiling-Terrains')


TerrainStitcher script
---------------------

The script follows the same logic, as the grid above.

Like when applying the script to tile x0y0 and x1y0 for example, you have to assign 'terrain tile x1y0' in
the 'Terrain right' slot of the script attached to terrain tile x0y0. For terrain tile x1y0, you have
to assign 'terrain tile x0y0' as 'Terrain left' in the script's slot of terrain x1y0.

Terrain tile x0y1 would be the 'Terrain top' - neighbor of tile x0y0 and x0y0 is 'Terrain bottom' neighbor
of tile x0y1.

(Again, please see Tiling-Terrains demo scene for example setup)


******************
*  Update v 1.6  *
******************

This free update features:

- Javascript code converted to C# code
- Everything compiled to work 100% with Unity 2017.3


If you need more information or want to give feedback, please contact: unity@play-da-gaimz.de


For more information and reference, please see:
http://docs.unity3d.com/Documentation/Manual/Terrains.html for reference.
http://docs.unity3d.com/Documentation/Components/terrain-Textures.html