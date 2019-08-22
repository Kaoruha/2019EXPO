using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CLock : MonoBehaviour {
    private Text clocktext;
    private GameObject[] colons;
    void Awake() {
        clocktext = transform.GetComponent<Text>();
        StartCoroutine(clock());
        getColons();
        StartCoroutine(blin());
    }


    //时钟
    private IEnumerator clock() {
        while (true) {
            string hour = System.DateTime.Now.Hour.ToString();
            if (Convert.ToInt16(hour) < 10) {
                hour = '0' + hour;
            }

            hour += "  ";
            string min = System.DateTime.Now.Minute.ToString();
            if (Convert.ToInt16(min) < 10) {
                min = '0' + min;
            }

            min += "  ";
            string sec = System.DateTime.Now.Second.ToString();
            if (Convert.ToInt16(sec) < 10) {
                sec = '0' + sec;
            }

            clocktext.text =hour + min + sec;
            
            yield return new WaitForSeconds(1);
          
        }
        
    }

    //blinblin冒号动画
    private IEnumerator blin() {
        while (true) {
            colons[0].SetActive(false);
            yield return new WaitForSeconds(.05f);
            colons[1].SetActive(false);
            yield return new WaitForSeconds(.15f);
            colons[0].SetActive(true);
            yield return new WaitForSeconds(.05f);
            colons[1].SetActive(true);
            yield return new WaitForSeconds(.75f);
        }
        
        
    }

    //初始化冒号集
    private void getColons() {
        colons = new GameObject[2];
        int count = transform.childCount;
        Debug.Log(count);
        for (int i = 0; i < count; i++) {
            colons[i] = transform.GetChild(i).gameObject;
        }
    }
}
