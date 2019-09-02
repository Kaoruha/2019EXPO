using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public bool isAbleToControl = true;
    private float moveSpeed = 0.1f;
    private float scaleSpeed = 600f;
    private double mouseX;
    private Vector2[] mouseList;
    private double mouseY;
    private double ScreenWidth;
    private int range = 50;
    private Camera mainCam;
    public GameObject camTarget;
    private float maxView = 90;
    private float minView = 70;
    private bool ShouldAutoMove = false;

    private int waitSecends;
    
    void Start() {
        waitSecends = 10;
        mainCam = Camera.main;
        mainCam.fieldOfView = 80;
        ScreenWidth = Screen.width;
        mainCam.transform.LookAt(camTarget.transform);
        StartCoroutine(AutoRotation(waitSecends));
    }

    void Update() {
        if (isAbleToControl) {
            ScreenMove();
            ZoomInOut();
        }
        
        AutoMove();
        
    }


    private void ScreenMove() {
             mouseX = Input.mousePosition.x;
             mouseY = Input.mousePosition.y;
             if (mouseX<range) {
                 mainCam.transform.Translate(Vector3.left * moveSpeed * 10 *Time.deltaTime);
             }else if (mouseX>(ScreenWidth-range)) {
                 mainCam.transform.Translate(Vector3.right * moveSpeed * 10 * Time.deltaTime);
             }
             mainCam.transform.LookAt(camTarget.transform);
     
     
    }
    //scrolling bewteen minView to maxView
    private void ZoomInOut() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if ((scroll > 0) && (mainCam.fieldOfView >= minView)) {
            mainCam.fieldOfView -= scroll * scaleSpeed * Time.deltaTime;

        }else if ((scroll < 0) && (mainCam.fieldOfView <= maxView)) {
            mainCam.fieldOfView -= scroll * scaleSpeed * Time.deltaTime;
        }
    }

    private Vector2 _nowPosition;
    private bool _isMoving = true;
    private int second = 0;
    private IEnumerator AutoRotation(int wait4Seconds) {
        //initialize vector2 list
        if (mouseList == null) {
            mouseList = new Vector2[wait4Seconds];
        }

        while (true) {
            _nowPosition.x = Input.mousePosition.x;
            _nowPosition.y = Input.mousePosition.y;
            mouseList[second] = _nowPosition;
            second++;
            second %= wait4Seconds;
            
            if (ShouldAutoMove != IsAllPosSame(mouseList)) {
                ShouldAutoMove = IsAllPosSame(mouseList);
            }
            yield return new WaitForSeconds(1);
        }
        

    }

    private bool IsAllPosSame(Vector2[] list) {
        Vector2 temp = list[0];
        bool isAllSame = true;
        for (int i = 0; i < list.Length; i++) {
            if (temp != list[i]) {
                isAllSame = false;
                break;
            }
        }
        return isAllSame;
    }


    private void AutoMove() {
        if (ShouldAutoMove) {
            mainCam.transform.Translate(Vector3.right * moveSpeed *Time.deltaTime);
        }
    }
}
