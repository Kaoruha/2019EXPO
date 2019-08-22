using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : UIClass {
    
    public bool shouldIn = false;
    
    void Start() {
        SetInitialPos(new Vector2(100,100));
        StartCoroutine(Move());
    }

    void Update()
    {
        
    }

    private IEnumerator Move() {
        while (true) {
            RCMove(new Vector3(0,0,0));
            yield return new WaitForSeconds(0.01f);
        }
        
    }



}
