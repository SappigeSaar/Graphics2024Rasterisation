#version 330

// shader inputs
in vec2 uv;						// fragment uv texture coordinates
in vec2 positionFromBottomLeft;
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
	vec2 blue = vec2(-abberation, 0.0);

	vec3 abberatedColor = vec3(texture(pixels, uv + red).r,
								texture(pixels, uv + green).g,
								texture(pixels, uv + blue).b);

	vec2 offsetPosition = positionFromBottemLeft - vec2(0.5, 0.5);
	float distance = length(offsetPosition);

	float vignette = smoothstep(1.0 - radius, 1.0, distance) * strength;


	outputColor = aberratedColor - vec3(vignette, vignette, vignette);
}