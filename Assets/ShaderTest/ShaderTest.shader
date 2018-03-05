Shader "Test/ShaderTest"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("NoiseTex",2D) = "white"{}
		_Speed ("Speed",float) = 1.0
		_DistortCenter("DistortCenter",Vector) = (0,0,0,0)
		_DistortTimeFactor("DistortTimeFactor", float) = 1
		_DistortStrength("DistortStrength", float) = 0.2
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float4 _MainTex_ST;
			float _Speed;
			float _DistortTimeFactor;
			float _DistortStrength;
			float4 _DistortCenter;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 dir = i.uv - _DistortCenter.xy;
				float2 scaleOffset = _DistortTimeFactor * normalize(dir) * (1 - length(dir));
				float4 noise = tex2D(_NoiseTex,i.uv);
				float2 noiseOffset = noise.xy * _DistortStrength * dir;
				float2 offset = scaleOffset - noiseOffset;
				float2 uv = i.uv + offset;
				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
