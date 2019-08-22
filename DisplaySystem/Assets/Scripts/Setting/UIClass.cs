using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClass : MonoBehaviour {
    
    private string _name;
    private int _id;

    
    //Name的Get、Set方法
    public void SetName(string name) {
        if (this._name == null) {
            this._name = name;
        }
    }

    public string GetName() {
        if (this._name != null) {
            return this._name;
        }

        return null;
    }
    
    //ID的Get、Set方法
    public void SetID(int id) {
        if (this._id == null) {
            this._id = id;
        }
        
    }

    public int GetID() {
        if (this._id != null) {
            return this._id;

        }
        return 0;

    }


    //UI位置
    public enum Position {
        screenLeft,
        screenRight,
        ScreenTop,
        SreenBottom
        
    }

    private Position _UIPosition;

    public void SetPosition(Position pos) {
        this._UIPosition = pos;
    }

    public Position GetPositon() {
        if (_UIPosition != null) {
            return _UIPosition;

        }

        return Position.ScreenTop;

    }


    
    
    //UI面板移入
    private float _moveSpeed = 1f;

    public void SetMoveSpeed(float speed) {
        if (speed >= 0f) {
            _moveSpeed = speed;
        }
    }

    private float _interval = 0.2f;
    public void SetInterval(float time) {
        if (time >= 0f) {
            _interval = time;
        }
    }

    private float _offSet = 0.5f;

    private Vector2 _UGUIPOS;
    private Vector2 _InitialPos = new Vector2(0,0);

    public void SetInitialPos(Vector2 initialPos) {
        _InitialPos = initialPos;
    }

    public Vector2 GetInitialPos() {
        return _InitialPos;

    }


    public void RCMove(Vector2 Destination) {
        _UGUIPOS = new Vector2(transform.position.x , transform.position.y);
        
        if (Vector3.Distance(transform.position ,Destination) <= _offSet) {
            transform.position = Destination;
        }
        else {
            transform.Translate((Destination - _UGUIPOS) * _moveSpeed * Time.deltaTime);
        }
    }




}
