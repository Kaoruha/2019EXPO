using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


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

    private void Awake() {
        ParseCloudJson();
    }

    private void Start() {
        ParseRealTimeData();
    }

    private List<CloudClass> CloudList;

    private void ParseCloudJson() {
        CloudList = new List<CloudClass>();
        TextAsset cloudText = Resources.Load<TextAsset>("BasicInfo/CloudInfo");
        string cloudjson = cloudText.text;
        JsonData jsonData = JsonMapper.ToObject(cloudjson);
        for (int i = 0; i < jsonData.Count; i++) {
            
            //ID
            int id = Int32.Parse(jsonData[i]["id"].ToString());
            
            //Name
            string name = jsonData[i]["name"].ToString();
            CloudClass.cloudName cloudName = (CloudClass.cloudName)System.Enum.Parse(typeof(CloudClass.cloudName), name);
            
            //Description
            string des = jsonData[i]["description"].ToString();
            
            //RamMax
            float ramMax = float.Parse(jsonData[i]["ram"].ToString());
            
            
            //DiscMax
            float discMax = float.Parse(jsonData[i]["discMax"].ToString());
            
            
            //DiscArray
            JsonData discArrayString = jsonData[i]["disc"];
            int[] discArray = new int[discArrayString.Count];

            for (int j = 0; j < discArrayString.Count; j++) {
                discArray[j] = int.Parse(discArrayString[j].ToString());
            }
            
            
            
            //CpuArray
            JsonData cpuArrayString = jsonData[i]["cpu"];
            int[] cpuArray = new int[cpuArrayString.Count];

            for (int j = 0; j < cpuArrayString.Count; j++) {
                cpuArray[j] = int.Parse(cpuArrayString[j].ToString());
            }
            
            
            //APPsArray
            JsonData appArrayString = jsonData[i]["app"];
            string[] appArray = new string[appArrayString.Count];

            for (int j = 0; j < appArrayString.Count; j++) {
                appArray[j] = appArrayString[j].ToString();
            }
            
            CloudClass cloud = new CloudClass(cloudName,id,des,ramMax,discMax,discArray,cpuArray,appArray);
            CloudList.Add(cloud);
        }
    }

    
    private void ParseRealTimeData() {
        
    }
}