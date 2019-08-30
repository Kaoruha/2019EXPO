using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWidth : MonoBehaviour {
    private RectTransform line;
    private float maxLength;

    private void Awake() {
        line = transform.GetComponent<RectTransform>();
        maxLength = line.sizeDelta.x;
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0,line.sizeDelta.y);
    }

    private void Update() {
        Dance(400f);
    }


    private float target;
    private void Dance(float speed) {
        target = maxLength - UnityEngine.Random.value * .1f * maxLength;
        if (line.sizeDelta.x < target) {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(line.sizeDelta.x + speed * Time.deltaTime,line.sizeDelta.y);
        }
        else if(line.sizeDelta.x > target) {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(line.sizeDelta.x - speed * Time.deltaTime,line.sizeDelta.y);
        }

    }
}
