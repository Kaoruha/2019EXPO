using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : UIClass {
    public Vector2 initialPos;
    public Vector2 targetPos;


    private void Awake() {
        SetInitialPos(initialPos);
    }

    void Update()
    {
        RCMove(targetPos);
    }
        



}
