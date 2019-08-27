using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudClass{
    
    //CLoudName
    public enum cloudName {
        istack,
        medCloud,
        riverCloud,
        constructionCloud
    }
    
    private cloudName _name;
    public void SetName(cloudName cn) {
        this._name = cn;
    }

    public cloudName GetName() {
        return this._name;
    }
    
    
    //ID
    private int _id;
    public void SetID(int id) {
        this._id = id;
    }

    public int GetID() {
        return this._id;
    }
    
    
    
    //Description
    private string _description;
    public void SetDes(string description) {
        this._description = description;
    }

    public string GetDes() {
        return this._description;
    }
    
    
    //UploadRate
    private float _upLoadRate;
    public void SetUpLoadRate(float upLoadRate) {
        this._upLoadRate = upLoadRate;
    }

    public float GetUpLoadRate() {
        return this._upLoadRate;
    }
    
    
    
    
    //DownLoadRate
    private float _downLoadRate;
    public void SetDownLoadRate(float downLoadRate) {
        this._downLoadRate = downLoadRate;
    }

    public float GetDownLoadRate() {
        return this._downLoadRate;
    }
    
    
    //BandWidthNow
    private float _flowAvg;
    public void SetFlowAvg(float flowAVG) {
        this._flowAvg = flowAVG;
    }

    public float GetFlowAvg() {
        return this._flowAvg;
    }
    
    
    
    //BandWidthMax
    private float _flowMax;
    public void SetFlowMax(float flowMax) {
        this._flowMax = flowMax;
    }
    public float GetFlowMax() {
        return this._flowMax;
    }
    
    
    
    //Last12Flows
    private float[] _last12Flows;
    public void SetLast12Flows(float[] last12Flows) {
        for (int i =0;i<last12Flows.Length;i++) {
            this._last12Flows[i] = last12Flows[i];	
        }
    }

    public float[] GetLast12Flows() {
        return this._last12Flows;
    }
    
    
    
    //Last 6 Visits
    private List<int[]> _last24Visits;
    public void SetLast24Visits(List<int[]> lastVisits) {
        for (int j = 0; j < lastVisits.Count; j++) {
            int[] temp = new int[lastVisits[j].Length];
            for (int i = 0; i < lastVisits[j].Length;i++) {
                temp[i] = lastVisits[j][i];
            }
            _last24Visits.Add(temp);
        }
    }

    public List<int[]> GetLast24Visits() {
        return this._last24Visits;
    }
    
    
    
    //Last 9 Responses
    private float[] _last9Responses;
    public void SetLast9Responses(float[] lastRespons) {
        for (int i =0;i<lastRespons.Length;i++) {
            this._last9Responses[i] = lastRespons[i];	
        }
    }

    public float[] GetLast9Responses() {
        return this._last9Responses;
    }
    
    
    
    //ResponseMax
    private float _responseMax;
    public void SetResponseMax(float responseMax) {
        this._responseMax = responseMax;
    }

    public float GetResponseMax() {
        return this._responseMax;
    }

    
    //ResponseAvg
    private float _responseAvg;
    public void SetResponseAvg(float responseAvg) {
        this._responseAvg = responseAvg;
    }

    public float GetResponseAvg() {
        return this._responseAvg;
    }
    
    
    //RamMax
    private float _ramMax;
    public void SetRamMax(float ramMax) {
        this._ramMax = ramMax;
    }

    public float GetRamMax() {
        return this._ramMax;
    }
    
    
    
    //Last 12 Rams
    private float[] _last12Rams;
    public void SetLast12Rams(float[] lasRams) {
        for (int i =0;i<lasRams.Length;i++) {
            this._last12Rams[i] = lasRams[i];	
        }
    }

    public float[] GetLast12Rams() {
        return this._last12Rams;
    }

    
    
    //DiscMax
    private float _discMax;
    public void SetDiscMax(float discMax) {
        this._discMax = discMax;
    }

    public float GetDiscMax() {
        return this._discMax;
    }
    
    
    
    //DiscNums
    private int[] _discNums;
    public void SetDiscNums(int[] discNums) {
        for (int i =0;i<discNums.Length;i++) {
            this._discNums[i] = discNums[i];	
        }
    }

    public int[] GetDiscNums() {
        return this._discNums;
    }
    
    
    
    
    //Last 24 DiscUses
    private float[] _last24DiscUses;    
    public void SetLast24DiscUses(float[] lasDiscs) {
        for (int i =0;i<lasDiscs.Length;i++) {
            this._last24DiscUses[i] = lasDiscs[i];	
        }
    }

    public float[] GetLast24DiscUses() {
        return this._last24DiscUses;
    }
    
    
    
    
    //DiscInput
    private float _discInput;
    public void SetDiscInput(float discInput) {
        this._discInput = discInput;
    }

    public float GetDiscInput() {
        return this._discInput;
    }
    
    
    
    
    //DiscOutput
    private float _discOutput;
    public void SetDiscOutput(float discOutput) {
        this._discOutput = discOutput;
    }

    public float GetDiscOutput() {
        return this._discOutput;
    }
    
    
    

    //CpuNums
    private int[] _cpuNum;
    public void SetCpuNum(int[] cpuNums) {
        for (int i = 0; i < cpuNums.Length; i++) {
            this._cpuNum[i] = cpuNums[i];            
        }
    }

    public int[] GetCpuNum() {
        return this._cpuNum;
    }
    
    
    
    
    
    //CpuRate
    private float _cpuRate;
    public void SetCpuRate(float cpuRate) {
        this._cpuRate = cpuRate;
    }

    public float GetCpuRate() {
        return this._cpuRate;
    }

    
    
    //AppNames
    private string[] _Apps;
    public void SetApps(string[] appNames) {
        for (int i = 0; i < appNames.Length; i++) {
            _Apps[i] = appNames[i];
        }
        
    }

    public string[] GetApps() {
        for (int i = 0; i < _Apps.Length; i++) {
            Debug.Log(_Apps[i]);
        }
        return this._Apps;
    }
    
    
    
    
    //Appnum
    private int _appNum;
    public void SetAppNum(int appNum) {
        this._appNum = appNum;
    }

    public int GetAppNum() {
        return this._appNum;
    }


    public CloudClass(cloudName name, int id,string des,float ramMax, float discMax, int[] discNums, int[] cpuNum, string[] apps) {
        _name = name;
        _id = id;
        _description = des;
        _upLoadRate = 0f;
        _downLoadRate = 0f;
        _flowAvg = 0f;
        _flowMax = 0f;
        _last12Flows = new float[12] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        _last24Visits = new List<int[]>();
        _last9Responses = new float[9]{0, 0, 0, 0, 0, 0, 0, 0, 0};
        _responseMax = 0f;
        _responseAvg = 0f;
        _ramMax = ramMax;
        _last12Rams = new float[12] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        _discMax = discMax;
        _discNums = discNums;
        _last24DiscUses = new float[24] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        _discInput = 0f;
        _discOutput = 0f;
        _cpuNum = cpuNum;
        _cpuRate = 0f;
        _Apps = apps;
        _appNum = apps.Length;
    }
    
}
