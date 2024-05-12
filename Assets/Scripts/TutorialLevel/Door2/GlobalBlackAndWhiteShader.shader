Shader "Hidden/GlobalBlackAndWhiteShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;

            fixed4 frag (v2f_img i) : SV_Target
            {
                // Check if the current fragment belongs to the UI layer (layer 5)
                if (_ProjectionParams.z == 16.0) // Layer 5 is represented by the 17th bit in Unity's projection matrix
                {
                    // Skip black and white conversion for fragments in the UI layer
                    return tex2D(_MainTex, i.uv);
                }
                else
                {
                    // Convert color to black and white for non-UI fragments
                    fixed4 col = tex2D(_MainTex, i.uv);
                    float gray = dot(col.rgb, float3(0.299, 0.587, 0.114));
                    return fixed4(gray, gray, gray, 1.0);
                }
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
