using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text clock;
    void Start()
    {
        StartCoroutine(timeUpdate());//开启时钟协程
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    
    //时钟功能
    private IEnumerator timeUpdate() {
        while (true) {
            string year = System.DateTime.Now.Year.ToString();
            if (int.Parse(year) < 10) {
                year = '0' + year;
            }
            string month = System.DateTime.Now.Month.ToString();
            if (int.Parse(month) < 10) {
                month = '0' + month;
            }
            string day = System.DateTime.Now.Day.ToString();
            if (int.Parse(day) < 10) {
                day = '0' + day;
            }
            string hour = System.DateTime.Now.Hour.ToString();
            if (int.Parse(hour) < 10) {
                hour = '0' + hour;
            }
            string min = System.DateTime.Now.Minute.ToString();
            if (int.Parse(min) < 10) {
                min = '0' + min;
            }
            string sec = System.DateTime.Now.Second.ToString();
            if (int.Parse(sec) < 10) {
                sec = '0' + sec;
            }
            clock.text = year + "-" + month + "-" + day + "  " + hour + ":" + min + ":" + sec;
            yield return new WaitForSeconds(1);
        }
            
        
        
    }
}
