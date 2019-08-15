// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:34398,y:32980,varname:node_4013,prsc:2|emission-6152-OUT,custl-6152-OUT,alpha-3747-OUT;n:type:ShaderForge.SFN_Fresnel,id:6082,x:33381,y:33071,varname:node_6082,prsc:2;n:type:ShaderForge.SFN_Power,id:6678,x:33598,y:33163,varname:node_6678,prsc:2|VAL-6082-OUT,EXP-344-OUT;n:type:ShaderForge.SFN_Exp,id:344,x:33381,y:33201,varname:node_344,prsc:2,et:0|IN-3284-OUT;n:type:ShaderForge.SFN_Slider,id:3284,x:32705,y:33205,ptovrint:False,ptlb:width,ptin:_width,varname:node_837,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-100,cur:-31.79978,max:1;n:type:ShaderForge.SFN_DepthBlend,id:1495,x:33405,y:33426,varname:node_1495,prsc:2|DIST-5146-OUT;n:type:ShaderForge.SFN_Add,id:1702,x:33774,y:33281,varname:node_1702,prsc:2|A-6678-OUT,B-3689-OUT;n:type:ShaderForge.SFN_OneMinus,id:3689,x:33588,y:33426,varname:node_3689,prsc:2|IN-1495-OUT;n:type:ShaderForge.SFN_RemapRange,id:5146,x:33192,y:33426,varname:node_5146,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-3284-OUT;n:type:ShaderForge.SFN_Color,id:4830,x:33774,y:33131,ptovrint:False,ptlb:node_5157,ptin:_node_5157,varname:node_5157,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.3793104,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6152,x:33997,y:33209,varname:node_6152,prsc:2|A-4830-RGB,B-1702-OUT;n:type:ShaderForge.SFN_Slider,id:3071,x:33497,y:33676,ptovrint:False,ptlb:opactiy,ptin:_opactiy,varname:node_3071,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:3747,x:33899,y:33487,varname:node_3747,prsc:2|A-3689-OUT,B-3071-OUT;proporder:4830-3284-3071;pass:END;sub:END;*/

Shader "BFW/nengliang" {
    Properties {
        [HDR]_node_5157 ("node_5157", Color) = (0,0.3793104,1,1)
        _width ("width", Range(-100, 1)) = -31.79978
        _opactiy ("opactiy", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _width;
            uniform float4 _node_5157;
            uniform float _opactiy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_3689 = (1.0 - saturate((sceneZ-partZ)/(_width*-1.0+1.0)));
                float3 node_6152 = (_node_5157.rgb*(pow((1.0-max(0,dot(normalDirection, viewDirection))),exp(_width))+node_3689));
                float3 emissive = node_6152;
                float3 finalColor = emissive + node_6152;
                fixed4 finalRGBA = fixed4(finalColor,(node_3689*_opactiy));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
