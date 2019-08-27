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
        ParseRealHourData();
        ParseRealSecData();
        Debug.Log(cloudList[1].GetLast12Flows()[2]);

    }
  
    
    #region GetDate
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
    
    public List<int[]> GetLast24Visits(int cloudId) {
        return cloudList[cloudId].GetLast24Visits();
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
    
    
    private List<CloudClass> cloudList;
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

    
    public void ParseRealHourData() {
        TextAsset RealTimeText = Resources.Load<TextAsset>("BasicInfo/CloudRealTimePerHour");
        string realTimeJson = RealTimeText.text;
        JsonData jsonData = JsonMapper.ToObject(realTimeJson);
        for (int i = 0; i < jsonData.Count; i++) {
            
            //Get  ID
            int id = int.Parse(jsonData[i]["id"].ToString());
            
            //last12FlowsString
            JsonData last12FlowsString = jsonData[i]["last12Flows"];
            float[] last12FlowsArray = new float[last12FlowsString.Count];

            for (int j = 0; j < last12FlowsString.Count; j++) {
                last12FlowsArray[j] = float.Parse(last12FlowsString[j].ToString());
            }
            cloudList[id-1].SetLast12Flows(last12FlowsArray);
            

            //last24Visits
            JsonData last24VisitsString = jsonData[i]["last24Visits"];
            List<int[]> last24VisitsArray =new List<int[]>();
            for (int j = 0; j < last24VisitsString.Count; j++) {
                int[] hourVisit = new int[last24VisitsString[j].Count];
                for (int k = 0; k < last24VisitsString[j].Count; k++) {
                    hourVisit[k] = int.Parse(last24VisitsString[j][k].ToString());
                }
                last24VisitsArray.Add(hourVisit);
            }
            cloudList[id-1].SetLast24Visits(last24VisitsArray);
            
            
            //last9Responses
            JsonData last9ResponsesString = jsonData[i]["last9Responses"];
            float[] last9ResponsesArray = new float[last9ResponsesString.Count];

            for (int j = 0; j < last9ResponsesString.Count; j++) {
                last12FlowsArray[j] = float.Parse(last9ResponsesString[j].ToString());
            }
            cloudList[id-1].SetLast9Responses(last9ResponsesArray);
            
            
            
            //last12Ram
            JsonData last12RamString = jsonData[i]["last12Ram"];
            float[] last12RamArray = new float[last12RamString.Count];

            for (int j = 0; j < last12RamString.Count; j++) {
                last12RamArray[j] = float.Parse(last12RamString[j].ToString());
            }
            cloudList[id-1].SetLast12Rams(last12RamArray);
            
            
            //last24Disc
            JsonData last24Disctring = jsonData[i]["last24Disc"];
            float[] last24DiscArray = new float[last24Disctring.Count];

            for (int j = 0; j < last24Disctring.Count; j++) {
                last24DiscArray[j] = float.Parse(last24Disctring[j].ToString());
            }
            cloudList[id-1].SetLast24DiscUses(last24DiscArray);
            
        }
        
    }
    
    public void ParseRealSecData() {
        TextAsset RealTimeText = Resources.Load<TextAsset>("BasicInfo/CloudRealTimePerSec");
        string realTimeJson = RealTimeText.text;
        JsonData jsonData = JsonMapper.ToObject(realTimeJson);
        for (int i = 0; i < jsonData.Count; i++) {
            int id = int.Parse(jsonData[i]["id"].ToString());
            float upLoad = float.Parse(jsonData[i]["upLoad"].ToString());
            float downLoad = float.Parse(jsonData[i]["downLoad"].ToString());
            float discIn = float.Parse(jsonData[i]["discIn"].ToString());
            float discOut = float.Parse(jsonData[i]["discOut"].ToString());
            float cpuRate = float.Parse(jsonData[i]["cpuRate"].ToString());
            
            cloudList[id-1].SetUpLoadRate(upLoad);
            cloudList[id-1].SetDownLoadRate(downLoad);
            cloudList[id-1].SetDiscInput(discIn);
            cloudList[id-1].SetDiscOutput(discOut);
            cloudList[id-1].SetCpuRate(cpuRate);
        }
        
    }



    private int _currentID = 1;

    public void SetID(int id) {
        this._currentID = id;
    }

    public int GetID() {
        return _currentID;
    }
    
    


}