using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    private Material skybox;
    private float rotationSpeed = 2.5f;
    void Start() {
        skybox = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        skyBoxRotate();
    }

    //天空盒自旋转
    private void skyBoxRotate() {
        float value = (Time.time * rotationSpeed)%360;
        skybox.SetFloat("_Rotation" , value);
    }
}
