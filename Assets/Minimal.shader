Shader "MyShaders/Minimal" {
	Properties{
		_Color("Tint",Color) = (1,1,1,1)
	}

	SubShader { // Unity chooses the subshader that fits the GPU best
		Tags{"Queue" = "Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass { // some shaders require multiple passes
			CGPROGRAM // here begins the part in Unity's Cg

			#pragma vertex vert 
			// this specifies the vert function as the vertex shader 
			#pragma fragment frag
			// this specifies the frag function as the fragment shader
			#include "UnityCG.cginc"

			uniform float4 _Color;

			float4 vert(float4 vertexPos : POSITION) : SV_POSITION 
			// vertex shader 
			{
				return mul(UNITY_MATRIX_MVP, vertexPos);
				// this line transforms the vertex input parameter 
				// vertexPos with the built-in matrix UNITY_MATRIX_MVP
				// and returns it as a nameless vertex output parameter 
			}

			float4 frag(void) : COLOR // fragment shader
			{
				return _Color; 
				// this fragment shader returns a nameless fragment
				// output parameter (with semantic COLOR) that is set to
				// opaque red (red = 1, green = 0, blue = 0, alpha = 1)
			}

			ENDCG // here ends the part in Cg 
		}
	}
}	
