using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour {
    private Text dateText;
    void Awake() {
        dateText = transform.GetComponent<Text>();
        StartCoroutine(clock());
    }

    private IEnumerator clock() {
        while (true) {
            string year = System.DateTime.Now.Year.ToString();
            year += "    ";
            string month = System.DateTime.Now.Month.ToString();
            if (Convert.ToInt16(month) < 10) {
                month = '0' + month;
            }

            month += "   ";
            string day = System.DateTime.Now.Day.ToString();
            if (Convert.ToInt16(day) < 10) {
                day = '0' + day;
            }




            dateText.text = month + day;
            
            yield return new WaitForSeconds(1);
          
        }
        
    } 
}
