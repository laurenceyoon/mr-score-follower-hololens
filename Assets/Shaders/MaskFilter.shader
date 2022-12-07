Shader "Custom/PortalFilter_01"
{

    SubShader
    {
        ZWrite off
        ColorMask 0

        Stencil{
            Ref 2
            Pass replace
        }

        Pass
        {
            }

    }
}