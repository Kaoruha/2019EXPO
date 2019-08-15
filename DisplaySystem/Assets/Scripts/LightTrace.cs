using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using UnityEngine;

public class LightTrace : MonoBehaviour {
    public GameObject lightTracerObject;
    private GameObject lto;
    private Vector3[] path;
    private int count;
    private int target;
    private float distance;
    private float targetDistance;
    private Vector3 unitVector;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public float moveSpeed;
    private bool hasDeleted;
    private float timer;
    private TrailRenderer trailRenderer;
    private float trailLenth;



    void Start() {
        trailLenth = 2f;
        hasDeleted = false;
        moveSpeed = 30f;//粒子移动速度
        timer = 2f;//开始向上移动后，XX秒重置
        target = 0;
        PathGet();
        Creat();
        trailRenderer = lto.transform.GetComponent<TrailRenderer>();


    }

    void Update() {

        if (lto != null) {
            distance = Vector3.Distance(lto.transform.position, startPoint);
            Move();
            
            if (distance>=targetDistance) {
                target++;
                SetVector();
            }

        }
    }

    void Creat() {
        if (lto != null) {
            lto = Instantiate(lightTracerObject, transform);
            lto.transform.position = Vector3.zero;
        }
        else {
            lto = Instantiate(lightTracerObject, transform);
            lto.transform.position = Vector3.zero;
        }
    }

    void PathGet() {
        count = transform.childCount;
        path = new Vector3[count];
        for (int i = 0; i < count; i++) {
            path[i]=(transform.GetChild(i).position);
        }
        SetVector();

    }

    void SetVector() {
        if (target < count) {
            if (target == 0) {
                startPoint = transform.position;
                endPoint = path[target];
            }
            else {
                startPoint = path[target - 1];
                endPoint = path[target];
            }
        }

        targetDistance = Vector3.Distance(startPoint, endPoint);
        unitVector = Vector3.Normalize(endPoint - startPoint);
    }

    void Move() {
        if (trailRenderer.time<trailLenth) {
            trailRenderer.time += 0.01f;
        }
        if (target<=count) {
            lto.transform.Translate(unitVector*moveSpeed*Time.deltaTime);
        }
        else {
            lto.transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
            if (!hasDeleted) {
                StartCoroutine(LightDelete());
            }
        }
       
        
    }

    private IEnumerator  LightDelete() {
        hasDeleted = true;
        yield return new WaitForSeconds(timer+Random.Range(-1f,2f));
        trailRenderer.time = 0f;
        target = 0;
        lto.transform.position = transform.position;
        SetVector();
        hasDeleted = false;
    }



}