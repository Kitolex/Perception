Shader "GrayScale" {
	Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_RedChannel ("Red Channel", Range (0, 1)) = 0
	_GreenChannel ("Green Channel", Range (0, 1)) = 0
	_BlueChannel ("Blue Channel", Range (0, 1)) = 0
	}
		SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			
			uniform sampler2D _MainTex;
			uniform float _RedChannel;
			uniform float _GreenChannel;
			uniform float _BlueChannel;


			struct v2f 
			{
				float4 pos : SV_POSITION;
				half2 uv   : TEXCOORD0;
				fixed4 color : COLOR;
			};

	
			
			float4 frag(v2f i) : COLOR {
				float4 c = tex2D(_MainTex, i.uv) ;
				
				float lum = c.r*.3 + c.g*.59 + c.b*.11;
				float3 bw = float3( lum, lum, lum ); 
				
				float4 result = c;

				result.r = lerp(bw.r, float( c.r*_RedChannel), _RedChannel);
				result.g = lerp(bw.g, float( c.g*_GreenChannel), _GreenChannel);
				result.b = lerp(bw.b, float( c.b*_BlueChannel), _BlueChannel);
				return result;
				
			}
		ENDCG
		}
 	}
}