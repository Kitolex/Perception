﻿Shader "Hidden/Fade"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_FadeText ("Fade Texture", 2D) = "white" {}
		_FadeRange("Fade Range", Range(0,1)) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _FadeText;
			float _FadeRange;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 FadeTexCol = tex2D(_FadeText, i.uv);

			/*	if(FadeTexCol.r < _FadeRange)
				{
					col.rgb = float3(0,0,0);
					return col;
				}
				else
				{
					return col;
				}*/

				col.rgb = lerp(float3(0,0,0), col.rgb, _FadeRange);
				return col;
				
			}
			ENDCG
		}
	}
}
