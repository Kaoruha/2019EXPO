using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClass : MonoBehaviour {
 
    #region UIMove
    
    //UI move
    public enum RCUIState {
        shouldIN,
        shouldOut,
        shouldStay
    }

    private RCUIState _RCUIState = RCUIState.shouldStay;

    public void SetState(RCUIState state) {
        _RCUIState = state;
    }

    

    private float _RCUIMoveSpeed = 5f;

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
        //Initial Distance
//        if (_RCInitialDis == 0f) {
            SetInitialDis(Destination);
//        }
        
        //Update UIPos
        _RCUGUIPos.x =transform.position.x;
        _RCUGUIPos.y=transform.position.y;



        
        
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
