using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGraphic : GraphicClass {

    private int _cloudId;
    public int columnNum;

    public float columnWidth;

    public float columnHeight;

    public float spacing;

    private float[] columnValue;

    public GameObject columnPrefab;

    private int max;

    private GameObject[] columns;

    private Vector2 position;

    public Color basicColor = Color.white;

    public Color hightLightColor;
    
    public enum source {
        last12Flows,
        last9Responses,
        last12Ram,
        last24Disc,
    }

    public source dataSource;
    // Start is called before the first frame update
    void Start() {
        position = transform.position;
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
        switch (dataSource) {
            case source.last12Flows:
                if (columnValue == null) {
                    columnValue = new float[12];
                }
                columnValue = CloudManager.instance.GetLast12Flows(id);
                break;
            case source.last9Responses:
                if (columnValue == null) {
                    columnValue = new float[9];
                }
                columnValue = CloudManager.instance.GetLast9Responses(id);
                break;
            case source.last12Ram:
                if (columnValue == null) {
                    columnValue = new float[12];
                }
                columnValue = CloudManager.instance.GetLast12Rams(id);
                break;
            case source.last24Disc:
                if (columnValue == null) {
                    columnValue = new float[24];
                }
                columnValue = CloudManager.instance.GetLast24DiscUses(id);
                break;
            
        }
        

        

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


    private void GraphicInitialization() {
        columns = new GameObject[columnNum];
        for (int i = 0; i < columnNum; i++) {
            columns[i] = Instantiate(columnPrefab, transform,false);
            columns[i].GetComponent<RectTransform>().sizeDelta = new Vector2(columnWidth,0);
            columns[i].GetComponent<RectTransform>().position = new Vector3(i * (columnWidth + spacing) + position.x,position.y,0);
            columns[i].GetComponent<Image>().color = basicColor;
            columns[i].GetComponent<Image>().raycastTarget = false;
            if (i == columnNum - 1) {
                columns[i].GetComponent<Image>().color = hightLightColor;
            }
        }
        GraphicUpdate();
    }
    
    
    private void GraphicUpdate() {
        for (int i = 0; i < columnNum; i++) {
            float tempHeight = columnHeight * columnValue[i] / max;
            columns[i].GetComponent<RectTransform>().sizeDelta = new Vector2(columnWidth,tempHeight);
        }
    }



    private void KeepIDUpdate() {
        if (_cloudId != CloudManager.instance.GetID()) {
            _cloudId = CloudManager.instance.GetID();
            DataUpdate(_cloudId);
            GraphicUpdate();
        }
    }



    private float speed = 1f;
    private IEnumerator UpToMax(int id) {
        float height = 0;
        float tempHeight = columnHeight * columnValue[id] / max;
        while (true) {
            if (height < tempHeight) {
                height += speed * Time.deltaTime;
                columns[id].GetComponent<RectTransform>().sizeDelta = new Vector2(columnWidth,height);
                yield return new WaitForSeconds(.75f);
            }
            else {
                break;
            }
            
        }
        //TODO
        
    }
}
