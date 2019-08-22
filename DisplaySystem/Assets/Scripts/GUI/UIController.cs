using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UIController : MonoBehaviour {
    public List<GUIScript> GUIComponents;
    public Color frameColor;
    private int count;
    private float interval;
    

    private void Awake() {
        interval = 0.05f;
        count = transform.childCount;
        for (int i = 0; i < count; i++) {
            GUIComponents.Add(transform.GetChild(i).GetComponent<GUIScript>());
        }
    }

    private void Start() {
        ShouldIn();
    }

    public void ShouldIn() {
        StartCoroutine(MoveIn());
    }
    
    public void ShouldOut() {
        StartCoroutine(MoveOut());
    }


    private IEnumerator MoveIn() {
        for (int i = 0; i < count; i++) {
            GUIComponents[i].SetState(UIClass.RCUIState.shouldIN);
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator MoveOut() {
        for (int i = count-1; i >= 0; i--) {
            GUIComponents[i].SetState(UIClass.RCUIState.shouldOut);
            yield return new WaitForSeconds(interval);
        }
    }


    #region 单例
    public static UIController _instance;

    public static UIController instance {
        get {
            if (_instance == null) {
                _instance = new UIController();
            }

            return _instance;
        }
        
    }
    

    #endregion






}
