using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLock : MonoBehaviour {
    private Text clocktext;
    private GameObject[] colons;
    void Awake() {
        clocktext = transform.GetComponent<Text>();
        StartCoroutine(clock());
        colons = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator clock() {
        while (true) {
//            string year = System.DateTime.Now.Year.ToString();
//            year += '-';
//            string month = System.DateTime.Now.Month.ToString();
//            if (Convert.ToInt16(month) < 10) {
//                month = '0' + month;
//            }
//
//            month += '-';
//            string day = System.DateTime.Now.Day.ToString();
//            if (Convert.ToInt16(day) < 10) {
//                day = '0' + day;
//            }
//
//            day += "  ";
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
}
