Shader "Custom/BackgroundScroll"
{
	//公開するテクスチャプロパティ
	Properties
	{
		_MainTex("スクロールさせたいスプライト", 2D) = "red"{}
	}
	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
		}
		LOD 200

		CGPROGRAM
		//fullforwardshadowsはデフォルト設定（物理レンダリング）。
		#pragma surface surf Standard
		#pragma target 3.0

		//テクスチャを設定するために、uv座標を入手
		struct Input
		{
			float2 uv_MainTex;
		};

		//2Dテクスチャ＝＝sampler2D
		sampler2D _MainTex;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed2 uv = IN.uv_MainTex;
			uv.x += 5 * _Time;
			uv.y += 5 * _Time;

			o.Albedo = tex2D(_MainTex, uv);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
