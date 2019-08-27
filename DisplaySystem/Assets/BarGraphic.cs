using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGraphic : GraphicClass {

    private int _cloudId;
    public int columnNum;

    public float columnWidth;

    public float columnHeight;

    public float spacing;

    private float[] columnValue;

    public GameObject columnPrefab;

    private int max;
    
    // Start is called before the first frame update
    void Start() {
        _cloudId = 1;
        DataUpdate(_cloudId);
        GraphicInitialization();
    }

    // Update is called once per frame
    void Update() {
        KeepIDUpdate();
    }


    public void SetID(int id) {
        if (_cloudId != id) {
            _cloudId = id;
        }
        DataUpdate(this._cloudId);
        GraphicUpdate();
    }



    #region DataUpdate

    private void DataUpdate(int id) {
        if (columnValue == null) {
            columnValue = new float[]{0,0,0,0,0,0,0,0,0,0,0,0};
        }

        columnValue = CloudManager.instance.GetLast12Flows(id);

        MaxUpdate();
        
    }
    
    private void MaxUpdate() {
        for (int i = 0; i < columnValue.Length; i++) {
            if (columnValue[i] >= max) {
                max = (int)columnValue[i];
            }
        }
    }

    #endregion



    private void GraphicUpdate() {
        Debug.Log(transform.name + " DataUpdate");
    }

    private void GraphicInitialization() {
        GameObject go = Instantiate(columnPrefab, transform,false);
        go.GetComponent<RectTransform>().position = new Vector3(100,100,0) + transform.position;

    }



    private void KeepIDUpdate() {
        if (_cloudId != CloudManager.instance.GetID()) {
            _cloudId = CloudManager.instance.GetID();
            DataUpdate(_cloudId);
            GraphicUpdate();
        }
    }
}
