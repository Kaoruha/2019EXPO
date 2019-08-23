using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PostEffectsBase : MonoBehaviour {
//    Called when start
    protected void CheckResources() {
        bool isSupported = CheckSupport();
        if (isSupported == false) {
            NotSupported();
        }
    }

    //Called in CheckResources to check support on this platform
    protected bool CheckSupport() {
#pragma warning disable 618
        if (SystemInfo.supportsImageEffects == false || SystemInfo.supportsRenderTextures == false) {
#pragma warning restore 618
            Debug.LogWarning("This platform does not support image effects or render texture.");
            return false;
        }

        return true;
    }

    //Called when the platform doesn;s support this effect
    protected void NotSupported() {
        enabled = false;
    }

    private void Start() {
        CheckResources();
    }

    //Called when need to create the material used by this effect
    protected Material CheckShaderAndCreatMaterial(Shader shader, Material material) {
        if (shader == null) {
            return null;
        }

        if (shader.isSupported && material && material.shader == shader) {
            return material;
        }

        if (!shader.isSupported) {
            return null;
        }
        else {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;
            if (material) {
                return material;
            }
            else {
                return null;
            }
        }
    }
}
