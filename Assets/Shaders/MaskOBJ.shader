// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit alpha-blended shader.
 // - no lighting
 // - no lightmap support
 // - no per-material color

Shader "Custom/PortalOBJ_01"{
    Properties{
        _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
           [Enum(Equal,3,NotEqua,6)]_StencilTest("Stencil Test",int) = 6
    }

        SubShader{
            Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            LOD 100

            cull off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Stencil{
                 Ref 2
                 Comp[_StencilTest]

            }

            Pass {
                CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma multi_compile_fog

                    #include "UnityCG.cginc"

                    struct appdata_t {
                        float4 vertex : POSITION;
                        float2 texcoord : TEXCOORD0;
                    };

                    struct v2f {
                        float4 vertex : SV_POSITION;
                        half2 texcoord : TEXCOORD0;
                        UNITY_FOG_COORDS(1)
                    };

                    sampler2D _MainTex;
                    float4 _MainTex_ST;

                    v2f vert(appdata_t v)
                    {
                        v2f o;
                        o.vertex = UnityObjectToClipPos(v.vertex);
                        o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                        UNITY_TRANSFER_FOG(o,o.vertex);
                        return o;
                    }

                    fixed4 frag(v2f i) : SV_Target
                    {
                        fixed4 col = tex2D(_MainTex, i.texcoord);
                        UNITY_APPLY_FOG(i.fogCoord, col);
                        return col;
                    }
                ENDCG
            }
           }

}
//
//Shader "Custom/PortalOBJ_01"
//{
//    Properties
//    {
//        _MainTex("Texture", 2D) = "white" {}
//        //_Color("COlor", Color) = (1,1,1,1)//Èò»ö
//        _Alpha ("Alpha", range(0.0,1.0)) = 1.0
//        [Enum(Equal,3,NotEqua,6)]_StencilTest("Stencil Test",int) = 6
//    }
//        SubShader
//    {
//        Tags
//        {
//            "RenderType" = "Transparent"
//            "Queue"= "Transparent"
//        }
//       //Color[_Color]
//            float2 uv_MainTex : 
//       Stencil{
//            Ref 2
//            Comp[_StencilTest]
//
//       }
//
//        Pass
//        {
//
//        }
//    }
//}
