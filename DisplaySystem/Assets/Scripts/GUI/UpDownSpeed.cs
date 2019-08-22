using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownSpeed : MonoBehaviour {
    public enum UpOrDown {
        Upload,
        Download
    }

    public UpOrDown _upOrDown;
    private float randomInterval;
    private float min;
    private float max;
    private Text speedText;
    private float num;
    void Start() {
        num = 56.4f;
        speedText = GetComponent<Text>();
        speedText.text = num.ToString("f1");
        StartCoroutine(DataUpdate());
    }



    private IEnumerator DataUpdate() {

        while (true) {

            for (int i = 1; i <= 2; i++) {
                speedText.enabled = false;
                yield return new WaitForSeconds(.05f);
                speedText.enabled = true;
                yield return new WaitForSeconds(.05f);
            }

            if (_upOrDown == UpOrDown.Upload) {
                num = Random.Range(10.0f, 50.0f);
            } else if (_upOrDown == UpOrDown.Download) {
                num = Random.Range(10.0f, 442.0f);
            }
            
            speedText.text = num.ToString("f1");
            yield return new WaitForSeconds(Random.Range(0.5f,5.0f));
        }
        


    }

}
