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

    private List<CloudClass> cloudList;
    
    #region ReadDate
    public CloudClass.cloudName GetName(int cloudId) {
        return cloudList[cloudId].GetName();
    }


    public string GetDes(int cloudId) {
        return cloudList[cloudId].GetDes();
    }

    public float GetUpLoadRate(int cloudId) {
        return cloudList[cloudId].GetUpLoadRate();
    }
    
    public float GetDownLoadRate(int cloudId) {
        return cloudList[cloudId].GetDownLoadRate();
    }

    public float GetFlowAvg(int cloudId) {
        return cloudList[cloudId].GetFlowAvg();
    }
    
    public float GetFlowMax(int cloudId) {
        return cloudList[cloudId].GetFlowMax();
    }
    
    public float[] GetLast12Flows(int cloudId) {
        return cloudList[cloudId].GetLast12Flows();
    }
    
    public int[] GetLast6Visits(int cloudId) {
        return cloudList[cloudId].GetLast6Visits();
    }
    
    public float[] GetLast9Responses(int cloudId) {
        return cloudList[cloudId].GetLast9Responses();
    }

    public float GetResponseMax(int cloudId) {
        return cloudList[cloudId].GetResponseMax();
    }
    public float GetResponseAvg(int cloudId) {
        return cloudList[cloudId].GetResponseAvg();
    }
    
    public float GetRamMax(int cloudId) {
        return cloudList[cloudId].GetRamMax();
    }
    
    public float[] GetLast12Rams(int cloudId) {
        return cloudList[cloudId].GetLast12Rams();
    }

    public float GetDiscMax(int cloudId) {
        return cloudList[cloudId].GetDiscMax();
    }
    
    public int[] GetDiscNums(int cloudId) {
        return cloudList[cloudId].GetDiscNums();
    }
    
    public float[] GetLast24DiscUses(int cloudId) {
        return cloudList[cloudId].GetLast24DiscUses();
    }
    
    public float GetDiscInput(int cloudId) {
        return cloudList[cloudId].GetDiscInput();
    }
    
    public float GetDiscOutput(int cloudId) {
        return cloudList[cloudId].GetDiscOutput();
    }
    
    public int[] GetCpuNum(int cloudId) {
        return cloudList[cloudId].GetCpuNum();
    }
    

    public float GetCpuRate(int cloudId) {
        return cloudList[cloudId].GetCpuRate();
    }

    public string[] GetApps(int cloudId) {
        return cloudList[cloudId].GetApps();
    }
    

    public int GetAppNum(int cloudId) {
        return cloudList[cloudId].GetAppNum();
    }
    
    
    
    
    
    #endregion

    private void ParseCloudJson() {
        cloudList = new List<CloudClass>();
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
            cloudList.Add(cloud);
        }
    }

    
    public void ParseRealTimeData() {
        
    }

    
}