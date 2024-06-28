Team members: (names and student IDs)
* ...
* Blossom de Ruiter 7772777
* Saar van Netburg 7515960

Tick the boxes below for the implemented features. Add a brief note only if necessary, e.g., if it's only partially working, or how to turn it on.

Formalities:
[X] This readme.txt
[X] Cleaned (no obj/bin folders)
[x] Demonstration scene(s) with all implemented features
[X] (Optional) Screenshots: make it clear which feature is demonstrated in which screenshot

Minimum requirements implemented:
[x] Camera: position and orientation controls
Controls: ...
[X] Model matrix: for each mesh, stored as part of the scene graph
[X] Scene graph data structure: tree hierarchy, no limitation on breadth or depth or size
[x] Rendering: recursive scene graph traversal, correct model matrix concatenation
[x] Shading in fragment shader: diffuse, glossy, uniform variable for ambient light color
[x] Point light: at least 1, position/color may be hardcoded

Bonus features implemented:
[ ] Multiple point lights: at least 4, uniform variables to change position and color at runtime
[ ] Spot lights: position, center direction, opening angle, color
[ ] Environment mapping: cube or sphere mapping, used in background and/or reflections
[ ] Frustum culling: in C# code, using scene graph node bounds, may be conservative
[ ] Bump or normal mapping
[ ] Shadow mapping: render depth map to texture, only hard shadows required, some artifacts allowed
[x] Vignetting and chromatic aberrations: darker corners, color channels separated more near corners
[ ] Color grading: color cube lookup table
[ ] Blur: separate horizontal and vertical blur passes, variable blur size
[ ] HDR glow: HDR render target, blur in HDR, tone-mapping
[ ] Depth of field: blur size based on distance from camera, some artifacts allowed
[ ] Ambient occlusion: darker in tight corners, implemented as screen-space post process
[X] inverted colors (see screenshots)
[x] black and white (see screenshots)
 ...

Notes:
camera can be moved around the scene using:
	w -> froward
	A-> left
	S -> backwards
	D-> right
	space -> up
	left shift -> down

camera can be oriented using the arrow keys:
	up -> up
	left -> left
	right -> right
	down -> dowm

