
Shader "Custom/PortalOBJ_01"
{
    Properties
    {
        _Color("COlor", Color) = (1,1,1,1)//Èò»ö
        [Enum(Equal,3,NotEqua,6)]_StencilTest("Stencil Test",int) = 6
    }
        SubShader
    {
       Color[_Color]
       Stencil{
            Ref 2
            Comp[_StencilTest]

       }

        Pass
        {

        }
    }
}
