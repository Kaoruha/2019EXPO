using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUManeger : MonoBehaviour {
    private Transform[] circles;
    

    private void Awake() {
        GetCircles();
    }

    private void Start() {
        StartCoroutine(Rotate());
    }


    private void GetCircles() {
        circles = new Transform[3];
        for (int i = 0; i < circles.Length; i++) {
            circles[i] = transform.GetChild(i);
        }
    }


    private float speed1 =0.4f;
    private float speed2 =1f;
    private float speed3 =1.2f;
        
    private IEnumerator Rotate() {
        while (true) {
            for (int i = 0; i < 3; i++) {
                switch (i) {
                    case 0:
                        circles[i].GetComponent<RectTransform>().Rotate(Vector3.forward,speed1);
                        break;
                    case 1:
                        circles[i].GetComponent<RectTransform>().Rotate(Vector3.forward,-speed2);
                        break;
                    case 2:
                        circles[i].GetComponent<RectTransform>().Rotate(Vector3.forward,speed3);
                        break;
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
        
    }
}
