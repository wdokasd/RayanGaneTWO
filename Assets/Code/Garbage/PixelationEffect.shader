Shader "Hidden/PixelationShader" {
    Properties {
        _PixelWidth("Pixel Width", Float) = 320
        _PixelHeight("Pixel Height", Float) = 240
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _PixelWidth;
            float _PixelHeight;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float2 pixelSize = float2(1.0 / _PixelWidth, 1.0 / _PixelHeight);
                float2 uv = floor(i.uv / pixelSize) * pixelSize;
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
    Fallback Off
}
