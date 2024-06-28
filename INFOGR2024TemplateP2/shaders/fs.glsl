#version 330
 
// shader inputs
in vec4 positionWorld;              // fragment position in World Space
in vec4 normalWorld;                // fragment normal in World Space
in vec2 uv;                         // fragment uv texture coordinates
in vec4 cameraWorldPosition;
uniform sampler2D diffuseTexture;	// texture sampler

// shader output
out vec4 outputColor;

// fragment shader
void main()
{
    vec4 positionLight = vec4(100.0, 0.0, 0.0, 0.0);
    float intensity = 9000.0;

    vec4 directionLight = normalize(positionLight - positionWorld);

    vec4 refracted = directionLight - 2.0 * dot(directionLight, normalize(normalWorld)) * normalize(normalWorld);

    outputColor = texture(diffuseTexture, uv) * intensity * 1.0 / 
            dot(positionLight - positionWorld, positionLight - positionWorld) * 
            (
                max(0.0, dot(normalize(normalWorld), directionLight)) 
                + pow( max(0.0, dot(normalize(refracted), normalize(cameraWorldPosition - positionWorld))) , 10.0) 
            );
    outputColor += texture(diffuseTexture, uv) * 0.08;
}