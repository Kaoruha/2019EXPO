using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cloud : MonoBehaviour {
    private RaycastHit hitInfo;
    public Case shownCase;
    void Update(){
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, 9999f)){
                if ((hitInfo.transform == transform) && !EventSystem.current.IsPointerOverGameObject()){
                    shownCase.MoveIn();
                }
            }
        }
    }
}
