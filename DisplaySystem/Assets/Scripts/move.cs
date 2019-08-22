using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : UIClass {
    
    
    void Start() {
        SetInitialPos(new Vector2(0,0));
//        StartCoroutine(Move());
    }

    void Update()
    {
        RCMove(new Vector2(400,400));
    }

//    private IEnumerator Move() {
//        while (true) {
//            RCMove(new Vector2(400,400));
//            yield return new WaitForSeconds(0.01f);
//        }
//        
//    }
    
    public void clickedIn() {
        SetState(RCUIState.shouldIN);
    }

    public void clickedOut() {
        SetState(RCUIState.shouldOut);
    }
        



}
