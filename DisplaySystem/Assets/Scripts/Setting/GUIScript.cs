using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : UIClass {
    public Vector2 initialPos;
    public Vector2 targetPos;
    private GameObject UIBorder;
    private Image borderImage;
    private Color borderColor;


    private void Awake() {
        SetInitialPos(initialPos);
        GetBorder();
    }

    private void Start() {
        GetBorderColor();

    }

    void Update()
    {
        RCMove(targetPos);
        SetBorderColor(borderColor);

    }

    
    private string borderName = "Border";
    private void GetBorder() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).name == borderName) {
                UIBorder = transform.GetChild(i).gameObject;
                borderImage = UIBorder.GetComponent<Image>();
            }
        }
    }

    private void SetBorderColor(Color color) {
        
//        borderImage.color = new Color(0.1f,0.8f,0.1f,1f);
//        borderImage.color = color;
    }

    private void GetBorderColor() {
        UIController controller = transform.parent.GetComponent<UIController>();
        borderColor = controller.frameColor;
        Debug.Log(borderColor.GetType());
    }


    

}
