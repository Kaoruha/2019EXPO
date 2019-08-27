using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RadioEffect : MonoBehaviour {
    public GameObject[] ableToDance;
    public bool beTransparent = true;
    private float transparency = 0.2f;

    private void Start() {
        if (beTransparent) {
            SetTransparency(transparency);
        }
        
        if (ableToDance != null) {
            StartCoroutine(Dance());
        }
    }

    

    private IEnumerator  Dance() {
        while (true) {
            for (int i = 0; i < ableToDance.Length; i++) {
                ableToDance[i].transform.localScale = new Vector3(UnityEngine.Random.value, 1, 1);
            }
            yield return new WaitForSeconds(.1f);
        }
        
    }


    private void SetTransparency(float transparency) {
        for (int i = 0; i < ableToDance.Length; i++) {
            ableToDance[i].GetComponent<Image>().color = new Color(1,1,1,transparency);
        }
    }
}
