#version 450 core

const int MAX_JOINTS = 15;

struct JointTransformation 
{
	mat4 transform;
	mat4 idefaultTransform;
};

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

uniform JointTransformation joints[MAX_JOINTS];

uniform vec4 ambientCoefficient;
uniform vec4 diffuseCoefficient;
uniform vec4 specularCoefficient; 
uniform float shininessCoefficient;

uniform vec4 lightColor;
uniform vec3 lightDirection;

in vec4 position;
in vec4 color;
in vec3 normal;

in int jointIndex;
in float jointCoefficient;

out vec4 vertexColor;

void main() {
	
	mat4 transform = model + jointCoefficient * joints[jointIndex].transform * joints[jointIndex].idefaultTransform;
	vec4 transPos = transform * position;
	vec3 transNorm = normalize(mat3(transform) * normal);

	vec4 viewPos = -view[3];
	vec3 viewDir = normalize(viewPos - transPos).xyz;
	vec3 reflectDir = reflect(normalize(lightDirection), transNorm);

	float diffuse = max(dot(transNorm, -lightDirection), 0.0);
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), shininessCoefficient);

	vertexColor = ((ambientCoefficient * lightColor) + (diffuse * diffuseCoefficient * lightColor) + (spec * specularCoefficient * lightColor)) * color;

	gl_Position = projection * view * transPos;

}
