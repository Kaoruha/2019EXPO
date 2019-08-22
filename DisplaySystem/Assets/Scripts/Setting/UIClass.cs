using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClass : MonoBehaviour {
    #region Name声明

    private string _RCUIName;

    public void SetName(string name) {
        if (this._RCUIName == null) {
            this._RCUIName = name;
        }
    }

    public string GetName() {
        if (this._RCUIName != null) {
            return this._RCUIName;
        }

        return null;
    }

    #endregion

    
    
    #region ID声明

    //ID的Get、Set方法
    private int _RCUIID;

    public void SetID(int id) {
        if (_RCUIID == null) {
            _RCUIID = id;
        }
    }

    public int GetID() {
        if (this._RCUIID != null) {
            return this._RCUIID;
        }

        return 0;
    }

    #endregion

    
    
    #region UIPosition
    
    //UI位置

    public enum RCUIPosition {
        screenLeft,
        screenRight,
        ScreenTop,
        SreenBottom
    }

    private RCUIPosition _RCUIPosition;

    public void SetPosition(RCUIPosition pos) {
        this._RCUIPosition = pos;
    }

    public RCUIPosition GetPositon() {
        if (_RCUIPosition != null) {
            return _RCUIPosition;
        }

        return RCUIPosition.ScreenTop;
    }

    #endregion

    
    
    #region UIMove
    
    //UI面板移动相关
    public enum RCUIState {
        shouldIN,
        shouldOut,
        shouldStay
    }

    public  RCUIState _RCUIState;

    public void SetState(RCUIState state) {
        _RCUIState = state;
        Debug.Log("Changed to :"+state);
        Debug.Log(_RCUIState);
    }

    

    private float _RCUIMoveSpeed = 2f;

    public void SetMoveSpeed(float speed) {
        if (speed >= 0f) {
            _RCUIMoveSpeed = speed;
        }
    }

    private float _RCUIinterval = 0.2f;

    public float GetInterval() {
        return _RCUIinterval;
    }

    public void SetInterval(float time) {
        if (time >= 0f) {
            _RCUIinterval = time;
        }
    }

    private float _RCUIArriveOffSet = 1f;

    private Vector2 _RCUGUIPos = new Vector2(0,0);
    private Vector2 _RCUIInitialPos = new Vector2(0, 0);
    private float _RCInitialDis = 0f;
    
    public void SetInitialPos(Vector2 initialPos) {
        _RCUIInitialPos = initialPos;
        transform.position = initialPos;
    }
    private void SetInitialDis(Vector2 destination) {
        _RCInitialDis = Vector2.Distance(destination, _RCUIInitialPos);
    }

    

    public Vector2 GetInitialPos() {
        return _RCUIInitialPos;
    }


    public void RCMove(Vector2 Destination) {
//        Debug.Log(_RCUIState);
        //Initial Distance
        if (_RCInitialDis == 0f) {
            SetInitialDis(Destination);
        }
        
        //Update UIPos
        _RCUGUIPos.x =transform.position.x;
        _RCUGUIPos.y=transform.position.y;



        if (_RCUIState == RCUIState.shouldOut) {
            Debug.Log("1");
            
        }
        else if (_RCUIState == RCUIState.shouldIN) {
            Debug.Log("2");
        }
        else if (_RCUIState == RCUIState.shouldStay) {
            Debug.Log("3");
        }
        else {
            Debug.Log("Error");
        }
        
        
        switch (_RCUIState) {
            case RCUIState.shouldIN:
                if (Vector2.Distance(_RCUGUIPos, _RCUIInitialPos) >= _RCInitialDis) {
                    transform.position = Destination;
                    _RCUIState = RCUIState.shouldStay;
                }
                else {
                    transform.Translate((Destination - _RCUIInitialPos) * _RCUIMoveSpeed * Time.deltaTime);
                }
                break;
            
            case RCUIState.shouldOut:
                if (Vector2.Distance(_RCUGUIPos, Destination) >= _RCInitialDis) {
                    transform.position = _RCUIInitialPos;
                    _RCUIState = RCUIState.shouldStay;
                }
                else {
                    transform.Translate((_RCUIInitialPos - Destination) * _RCUIMoveSpeed * Time.deltaTime);
                }
                break;
            
            
            case RCUIState.shouldStay:
                break;
            
        }
        
        
        
        
           
            
        
        
        
        
    }



    #endregion


    
}
