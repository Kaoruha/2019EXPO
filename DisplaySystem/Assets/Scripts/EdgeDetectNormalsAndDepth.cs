 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetectNormalsAndDepth : PostEffectsBase {

    public Shader edgeDetectShader;

    public RenderTexture RTex;

    public RenderTexture RTexMask;

    private Material edgeDetectMaterial = null;

    public Material material {
        get {
            edgeDetectMaterial = CheckShaderAndCreatMaterial(edgeDetectShader, edgeDetectMaterial);
            return edgeDetectMaterial;
        }
    }

    [Range(0.0f, 1.0f)] 
    public float edgesOnly = 0.0f;

    public Color edgeColor = Color.black;
    public Color backGroundColor = Color.white;
    public float sampleDistance = 1.0f;
    public float sensitivityDepth = 1.0f;
    public float sensitivityNormals = 1.0f;


    private void OnEnable() {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
    }

    [ImageEffectOpaque]

    private void OnRenderImage(RenderTexture source,RenderTexture destination) {
        if (material!=null) {
            material.SetTexture("_Mask",RTexMask);
            material.SetFloat("_EdgeOnly",edgesOnly);
            material.SetColor("_EdgeColor",edgeColor);
            material.SetColor("_BackgroundColor",backGroundColor);
            material.SetFloat("_SampleDistance",sampleDistance);
            material.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
            Graphics.Blit(source,destination,material);
            material.SetFloat("_EdgeOnly",1);
            Graphics.Blit(source,RTex,material);

            DrawDepth();
        }
        else {
            Graphics.Blit(source,destination);
        }

        void DrawDepth() {
            Graphics.SetRenderTarget(RTex);//设置渲染目标
        }
    }


}
