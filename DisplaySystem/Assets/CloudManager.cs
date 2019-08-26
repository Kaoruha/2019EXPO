using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudManager : MonoBehaviour {
    #region Instance

    private static CloudManager _instance;

    public static CloudManager instance {
        get {
            if (_instance == null) {
                _instance = GameObject.Find("CloudManager").GetComponent<CloudManager>();
            }

            return _instance;
        }
    }

    #endregion

    private List<CloudClass> CloudList;

    void ParseCloudJson() {
        CloudList = new List<CloudClass>();
        TextAsset cloudText = Resources.Load<TextAsset>("BasicInfo/CloudInfo");



        

    }

    private void Start() {
        ParseCloudJson();
    }
}