#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;

void main()
{    
    float ratio = 1.00 / 10.52;
    vec3 I = normalize(Position - cameraPos);
    vec3 R = refract(I, normalize(Normal), ratio);
    
    //the light color r,g,b have different extents to refract
    float r=R[0]*0.09;
    float g=R[1]*0.06;
    float b=R[2]*0.07;

    vec3 color=vec3(r,g,b);
    FragColor = vec4(texture(skybox, color).rgb,1.0);
}