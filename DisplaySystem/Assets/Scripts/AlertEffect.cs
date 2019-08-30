using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertEffect : MonoBehaviour {
    private float bumpSize;
    private RectTransform alertRect;
    void Start() {
        alertRect = transform.GetComponent<RectTransform>();
        bumpSize = 2f;
        StartCoroutine(Bump());
    }

    private float speed = 0.000001f;
    
    private IEnumerator Bump() {
        while (true) {
            alertRect.localScale = new Vector3(bumpSize,bumpSize,1);
            while (alertRect.localScale.x > 1f) {
                alertRect.localScale = new Vector3(alertRect.localScale.x - speed*Time.deltaTime, alertRect.localScale.y - speed*Time.deltaTime, 1);
            }
            Debug.Log("ouch");
            
            yield return new WaitForSeconds(1.5f);
        }
    }
    
    
    
}
