Shader "LSJShader/SpriteOutline"
{
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_Color("OutlineColor", Color) = (1,1,1,1)
	}

		SubShader{
			Cull Off

			Pass
			{
				CGPROGRAM

				#pragma vertex vertexFunc
				#pragma fragment fragFunc
				#include "UnityCG.cginc"

				sampler2D _MainTex;

				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				v2f vertexFunc(appdata_base v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord;

					return o;
				}

				fixed4 _OutlineColor;
				float4 _MainTex_TexelSize;

				fixed4 fragFunc(v2f i) : COLOR
				{
					float4 c = tex2D(_MainTex, i.uv);

					return c;
				}
			ENDCG
		}
	}
}
