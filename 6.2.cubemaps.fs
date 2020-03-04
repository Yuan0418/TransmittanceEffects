#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;
uniform vec3 lightPos=vec3(3.0, 0.0, 0.0);
//uniform vec3 lightColor=vec3(1.0, 1.0, 1.0);//white color

void main()
{   
    //refraction
    float ratio = 1.00 / 1.52;
    vec3 I = normalize(Position - cameraPos);
    vec3 R = refract(I, normalize(Normal), ratio);
    FragColor = vec4(texture(skybox, R).rgb, 1.0);
}