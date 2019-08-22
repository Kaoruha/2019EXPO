using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudName : MonoBehaviour {
    private Transform cam;
    private Vector3 lookAtPos;
    void Start() {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() {
        LookAt();
        
    }


    private void LookAt() {
        lookAtPos = transform.position - (cam.position - transform.position);
        transform.LookAt(lookAtPos);
    }
}
