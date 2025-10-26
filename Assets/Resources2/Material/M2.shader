Shader "Unlit/M2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Frame("frame",int)=0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        blend srcalpha oneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float2 _MainTex_TexelSize;
            uint _Frame;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            float2 texelSize = _MainTex_TexelSize.xy;  
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col.r*=1.1;
                col.b*=1.1;
                if(_Frame%80<15||_Frame%120<15)
                {
                col.r = tex2D(_MainTex,float2(i.uv.x-texelSize.x*15,i.uv.y-texelSize.y*15)).r;
                col.b = tex2D(_MainTex,float2(i.uv.x+texelSize.x*15,i.uv.y+texelSize.y*15)).g;
                }
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
