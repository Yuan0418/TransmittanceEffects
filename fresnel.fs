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

    //fresnel reflection*fresnel
    vec3 F0=vec3(0.04);
    vec3 V=normalize(cameraPos-Position);
    vec3 L=normalize(-Normal);
    vec3 H=normalize(V+L);
    vec3 kS=F0+(1.0-F0)*pow(1.0-dot(H,V),5.0);
   // vec3 kD=1.0-kS;

    vec3 I = normalize(Position - cameraPos);
    vec3 R = reflect(I, normalize(Normal))*kS;
    FragColor = vec4(texture(skybox,R).rgb, 1.0);
}