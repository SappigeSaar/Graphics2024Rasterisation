#version 330

// shader inputs
in vec2 positionFromBottomLeft;
in vec2 uv;						// fragment uv texture coordinates
uniform sampler2D pixels;		// input texture (1st pass render target)

// shader output
out vec3 outputColor;

// fragment shader
void main()
{
	float aberration = 0.002;

	float strength = 0.7;
	float radius = 0.6; 

	vec2 red = vec2(aberration, 0.0);
	vec2 green = vec2(0.0, 0.0);
	vec2 blue = vec2(-aberration, 0.0);

	vec3 aberratedColor = vec3(texture(pixels, uv + red).r,
								texture(pixels, uv + green).g,
								texture(pixels, uv + blue).b);



	vec2 offsetPosition = positionFromBottomLeft - vec2(0.3, 0.3);
	float distance = length(offsetPosition);

	float vignette = smoothstep(1.0 - radius, 1.0, distance) * strength;

	outputColor = aberratedColor - vec3(vignette, vignette, vignette);

	//to make it all gray we can do simple normal gray scale where we doe r+g+b /3
	//but our eyes don't see each colour from a screen as much as others. due to wavelength
	float adjustedgrayscale = (outputColor.r*0.3 + outputColor.g*0.59+outputColor.b*0.11);
	//outputColor.r=adjustedgrayscale;
	//outputColor.g=adjustedgrayscale;
	//outputColor.b=adjustedgrayscale;




	//invert the color by doing 1-rgb
	//outputColor.r=1-outputColor.r;
	//outputColor.g=1-outputColor.g;
	//outputColor.b=1-outputColor.b;



	


}