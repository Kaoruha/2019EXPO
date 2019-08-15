using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPrefabs : MonoBehaviour {
    public Transform cityModelParent;
    
    public GameObject[] cityBuildings;
    
    private Vector3 centerCityPos;
    void Start() {
//        设置模型空间基准坐标
        centerCityPos = new Vector3(15.5f,0,11.8f);
        ScenceInitialization();
    }

    void Update()
    {
        
    }
//    实例化预制件
    private void CreatPrefab(GameObject obj,Vector3 pos,Transform parent) {
        GameObject go =Instantiate(obj, pos, Quaternion.identity);
        go.transform.SetParent(parent);
    }
    
    private void CreatPrefab(GameObject obj,Vector3 pos,Transform parent,float scale) {
        GameObject go =Instantiate(obj, pos, Quaternion.identity);
        go.transform.localScale = new Vector3(scale,scale,scale);
        go.transform.SetParent(parent);
    }
    
    private void CreatPrefab(GameObject obj,Vector3 pos) {
        GameObject go =Instantiate(obj, pos, Quaternion.identity);
    }
    

//    遍历模型列表并实例化
    private void ScenceInitialization() {
        
        for (int i = 0; i < cityBuildings.Length; i++) {
            if (cityBuildings[i] != null) {
                CreatPrefab(cityBuildings[i],centerCityPos,cityModelParent,0.01f);
            }
        }
    }
}
