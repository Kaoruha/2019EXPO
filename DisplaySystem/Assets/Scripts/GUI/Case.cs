using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Case : UIClass {
    public Transform btnFrom;
    private Vector2 initialPos;
    private Vector2 targetPos;
    public UIController uiController;
    private float zoomRateWithDis = 1.2f;

    private float interval = 0.01f;
    private float targetZoom = 0f;
    private Vector3 screenPos;
    private Vector2 screenCenter = new Vector2();
    private float distance;
    private float targetSpeed;
    private int currentPage;
    public Transform content;
    private Transform[] pages;

    private void Awake() {
        currentPage = 1;
        screenCenter = new Vector2(UnityEngine.Screen.width/2,UnityEngine.Screen.height/2);
        transform.localScale = new Vector3(0,0,0);
        
        
        targetPos = new Vector2(960,540);
    }

    private void Start() {
        InitializePages();


    }


    public void MoveIn() {
        screenPos = Camera.main.WorldToScreenPoint(btnFrom.position);
        initialPos = new Vector2(screenPos.x,screenPos.y);
        distance = Vector2.Distance(screenCenter, screenPos);
        ChangeSpeed();
        SetInitialPos(initialPos,true);
        uiController.ShouldOut();
        SetState(RCUIState.shouldIN);
        StartCoroutine(ZoomIn());
    }
    
    public void MoveOut() {
        screenPos = Camera.main.WorldToScreenPoint(btnFrom.position);
        initialPos = new Vector2(screenPos.x,screenPos.y);
        ChangeSpeed();
        SetInitialPos(initialPos, false);
        uiController.ShouldIn();
        SetState(RCUIState.shouldOut);
        StartCoroutine(ZoomOut());
        currentPage = 1;

    }

    private void Update() {
        RCMove(targetPos);
    }


    private IEnumerator ZoomIn() {
        while (targetZoom <= 1f) {
            targetZoom = (Vector2.Distance(transform.position, initialPos)) / (Vector2.Distance(initialPos, targetPos));
                
            transform.localScale = new Vector3(targetZoom,targetZoom,1);
            yield return new WaitForSeconds(interval);
        }
        transform.localScale = new Vector3(1,1,1);
    }

    private IEnumerator ZoomOut() {
        while (targetZoom >= 0f) {
            targetZoom = (Vector2.Distance(transform.position, initialPos)) / (Vector2.Distance(initialPos, targetPos));
            transform.localScale = new Vector3(targetZoom,targetZoom,1);
            yield return new WaitForSeconds(interval);
        }
        transform.localScale = new Vector3(0,0,0);
    }

    private void ChangeSpeed() {
        targetSpeed = 1400f * distance / 260f;
        SetMoveSpeed(targetSpeed);
    }


    private void InitializePages() {
        pages = new Transform[content.childCount];
        for (int i = 0; i < content.childCount; i++) {
            pages[i] = content.GetChild(i);
        }
        showPage(currentPage);
    }


    public void PageUp() {
        if (currentPage < content.childCount) {
            currentPage++;
            showPage(currentPage);
        }
        else {
            currentPage = content.childCount;
        }
    }

    public void PageDown() {
        if (currentPage > 1) {
            currentPage--;
            showPage(currentPage);
        }
        else {
            currentPage = 1;
        }
        
    }

    private void showPage(int id) {
        for (int i = 0; i < pages.Length; i++) {
            if (i == currentPage -1) {
                pages[i].gameObject.SetActive(true);
            }
            else {
                pages[i].gameObject.SetActive(false);
            }
        }
    }
}
