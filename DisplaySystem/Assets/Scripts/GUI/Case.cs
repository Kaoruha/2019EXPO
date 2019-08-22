using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Case : UIClass
{
    public Vector2 initialPos;
    private Vector2 targetPos;
    private float zoomRate;

    private void Awake() {
        zoomRate = 1f;
        targetPos = new Vector2(960,640);
    }
}
