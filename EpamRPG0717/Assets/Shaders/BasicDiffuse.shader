Shader "CookbookShaders/BasicDiffuse" {
	Properties {

	    _EmissiveColor ("Emissive Color", Color) = (1, 1, 1, 1)
	    _AmbientColor ("Ambient Color", Color) = (1, 1, 1, 1)
	    _MySliderValue ("My Slider", Range(1,10)) = 2.5
        _RampTex ("Ramp Tex", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf BasicDiffuse

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		float4 _EmissiveColor;
		float4 _AmbientColor;
		float _MySliderValue;

        sampler2D _RampTex;

        inline float4 LightingBasicDiffuse (SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten) {
//            float difLight = max(0, dot(s.Normal, lightDir));
            float difLight = dot(s.Normal, lightDir);
            float rimLight = dot(s.Normal, viewDir);
            float hLambert = 0.5 * difLight + 0.5;
//            float3 ramp = tex2D(_RampTex, float2(0,0)).rgb;
            float3 ramp = tex2D(_RampTex, float2(hLambert, rimLight)).rgb;

            float4 col;
            col.rgb = s.Albedo * _LightColor0.rgb * (ramp);
//            col.rgb = s.Albedo * _LightColor0.rgb * (hLambert * atten * 2);
            col.a = s.Alpha;
            return col;
        }

		struct Input {
			float2 uv_MainTex;
		};


		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c;
			c = pow((_EmissiveColor + _AmbientColor), _MySliderValue);
			o.Albedo = c.rgb;
//			// Metallic and smoothness come from slider variables
//			o.Metallic = _Metallic;
//			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
