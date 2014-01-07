Shader "MyShaders/Diffuse Lighting" {
	Properties{
		_MainTex("Main Texture",2D) = "white"{}
		_Color ("Main Color",Color) = (1,1,1,1)
		_SpecColor("Specular Color", Color) = (1,1,1,1)
		_Shininess("Shininess", float) = 10.0
	}

	SubShader { // Unity chooses the subshader that fits the GPU best	
		
		Pass { // some shaders require multiple passes
			Tags{"LightMode" = "ForwardBase" }
			
			CGPROGRAM 

			#pragma vertex vert 
			#pragma fragment frag
			
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			#include "CG_Defines.cginc"

			
			uniform half4 _Color;
			uniform sampler2D _MainTex; 
			uniform float4 _MainTex_ST;
	
			uniform half4 _LightColor0; 
			uniform half4 _SpecColor;
			uniform float _Shininess;

			struct vertexInput{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};
			
			struct fragmentInput{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR0;
				half2 uv : TEXCOORD0;
			};
	
			//Vertex Shader
			fragmentInput vert(vertexInput i){
				fragmentInput o;
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.uv = TRANSFORM_TEX(i.texcoord,_MainTex);
				
				float3 normalDirection = NORMAL_TO_WORLD( i.normal );
				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
								
				float attenuation = 1.0 / length(lightDirection);
				lightDirection = normalize(lightDirection);
				
				float ndotl = dot(normalDirection, lightDirection);

				
				float3 diffuse = attenuation * _LightColor0.rgb * _Color.rgb * max(0.0, ndotl);
				
				float3 viewDirection = WorldSpaceViewDir(i.vertex);
				float specularReflection;
				
				if(ndotl > 0){
					float3 reflection = reflect(-lightDirection , normalDirection);
					float4 rdotv = pow(max(0, dot(reflection, viewDirection)),_Shininess);
					specularReflection = attenuation * _LightColor0.rgb * _Color.rgb * rdotv;
				}
				else
					specularReflection = float3(0,0,0);
				
				
				float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;
				
				o.color = float4( ambientLighting + diffuse + specularReflection, 1);
				return o;
			}

			//Fragment Shader
			half4 frag(fragmentInput i) : COLOR{
				return tex2D( _MainTex,i.uv) * i.color; 
			}

			ENDCG // here ends the part in Cg 
		}
		
		
	}
	Fallback "Diffuse"
}	