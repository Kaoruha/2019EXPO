﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : UIClass {
    public Vector2 initialPos;
    public Vector2 targetPos;
    
    
    void Start() {
        SetInitialPos(initialPos);
//        StartCoroutine(Move());
    }

    void Update()
    {
        RCMove(targetPos);
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
