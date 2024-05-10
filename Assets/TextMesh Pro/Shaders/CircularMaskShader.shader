Shader "Custom/CircularMaskShader"
{
    Properties
    {
        _Radius ("Radius", Range(0, 10)) = 5
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
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
            
            float _Radius;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            half4 frag (v2f i) : SV_Target
            {
                float2 playerPos = float2(0.5, 0.5); // Player's position (normalized)
                float dist = distance(i.uv, playerPos);
                float alpha = saturate(1 - dist / _Radius);
                return half4(1, 1, 1, alpha);
            }
            ENDCG
        }
    }
}
