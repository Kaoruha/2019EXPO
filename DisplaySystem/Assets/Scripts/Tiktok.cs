using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiktok : MonoBehaviour
{
    private GameObject[] tiktoks;

    private void Awake() {
        getTiktoks();
    }

    private void Start() {
        StartCoroutine(tiktok());
    }

    private void getTiktoks() {
        tiktoks = new GameObject[5];
        for (int i = 0; i < 5; i++) {
            tiktoks[i] = transform.GetChild(i).gameObject;
        }
    }

    private int timer = 0;
    private IEnumerator tiktok() {
        while (true) {
            for (int i = 0; i < 5; i++) {
                if (i <= timer) {
                    if (!tiktoks[i].activeSelf) {
                        tiktoks[i].SetActive(true);
                    }
                }
                else {
                    if (tiktoks[i].activeSelf) {
                        tiktoks[i].SetActive(false);
                    }
                }
            }

            timer++;
            timer = timer % 5;
            yield return new WaitForSeconds(1);
        }

    }
}
