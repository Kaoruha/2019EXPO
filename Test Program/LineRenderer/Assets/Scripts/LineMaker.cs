using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>();
    private LineRenderer lineMaker;
    private Vector3 endPoint;
    private Vector3 unitVector;
    public float speed;
    private Vector3 intransitPoint;
    private int target;
    private float distance;
    private int count;
    private bool isArrived;
    private bool shouldGo;
    public float range;
    


    void Start() {
        lineMaker = GetComponent<LineRenderer>();
        PointsRegister();
        lineMaker.positionCount = count;
        isArrived = false;
        shouldGo = true;
        
        
        
        //设置速度,检测阈值，速度越快，检测阈值越高
        speed = 10f;
        range = 0.8f;

    }

    void Update() {

        if (isArrived & (target<=count-2)) {
            target++;
            endPoint = points[target];
            unitVector = Vector3.Normalize(points[target] - points[target - 1]);
            isArrived = false;
        }

        distance = Vector3.Distance(intransitPoint, endPoint);
        
        
        if (shouldGo) {
            intransitPoint += speed * unitVector * Time.deltaTime;
            lineMaker.SetPosition(target,intransitPoint);
        }

        if (distance<=range) {
            isArrived = true;
            if (target==count-1) {
                shouldGo = false;
            }
        }
        

    }

    //路径拐点注册
    void PointsRegister() {
        count = transform.childCount;
        for (int i = 0; i < count; i++) {
            points.Add(transform.GetChild(i).position);
        }
        lineMaker.SetPosition(0,points[0]);
        intransitPoint = points[0];
        endPoint = points[1];
        unitVector = Vector3.Normalize(endPoint - intransitPoint);
        target = 1;

    }

}
