using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public bool isAbleToControl = true;
    private float moveSpeed = 2.5f;
    private float scaleSpeed = 600f;
    private double mouseX;
    private double mouseY;
    private double ScreenWidth;
    private double ScreenHeight;
    private int range = 50;
    private Camera mainCam;
    public GameObject camTarget;
    private float maxView = 90;
    private float minView = 70;
    
    void Start() {
        mainCam = Camera.main;
        mainCam.fieldOfView = 80;
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        mainCam.transform.LookAt(camTarget.transform);

    }

    void Update() {
        if (isAbleToControl) {
            ScreenMove();
            ZoomInOut();
        }
        
    }


    private void ScreenMove() {
             mouseX = Input.mousePosition.x;
             mouseY = Input.mousePosition.y;
             if (mouseX<range) {
                 mainCam.transform.Translate(Vector3.left * moveSpeed *Time.deltaTime);
             }else if (mouseX>(ScreenWidth-range)) {
                 mainCam.transform.Translate(Vector3.right * moveSpeed *Time.deltaTime);
             }
             mainCam.transform.LookAt(camTarget.transform);
     
     
    }
//    滚动滚动，相机视野在minView与maxView之间调整
    private void ZoomInOut() {
        float scrol = Input.GetAxis("Mouse ScrollWheel");
        if ((scrol > 0) && (mainCam.fieldOfView >= minView)) {
            mainCam.fieldOfView -= scrol * scaleSpeed * Time.deltaTime;

        }else if ((scrol < 0) && (mainCam.fieldOfView <= maxView)) {
            mainCam.fieldOfView -= scrol * scaleSpeed * Time.deltaTime;
        }
    }
}
