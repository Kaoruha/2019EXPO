using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudClass{
    public enum cloudName {
        istack,
        medCloud,
        riverCloud,
        constructionCloud
    }

    private cloudName _name;
    private int _id;
    
    private float _upLoadRate;
    private float _downLoadRate;

    private float _bandWidthNow;
    private float _bandWidthMax;
    private List<float> _last12BandWidths;
    
    
    private List<float> _last6Visits;
    
    
    private List<float> _last9Responses;
    private float _responseMax;


    private float _responseAvg;

    private float _ramMax;
    private List<float> _last12Rams;


    private float _discMax;
    private List<int> _discNums;
    private List<float> _last24DiscUses;
    private float _discInput;
    private float _discOutput;


    private int _cpuNum;
    private float _cpuRate;


    private List<string> _Apps;
    private int _appNum;


    public CloudClass(cloudName name, int id, float upLoadRate, float downLoadRate, float bandWidthNow, float bandWidthMax, List<float> last12BandWidths, List<float> last6Visits, List<float> last9Responses, float responseMax, float responseAvg, float ramMax, List<float> last12Rams, float discMax, List<int> discNums, List<float> last24DiscUses, float discInput, float discOutput, int cpuNum, float cpuRate, List<string> apps, int appNum) {
        _name = name;
        _id = id;
        _upLoadRate = upLoadRate;
        _downLoadRate = downLoadRate;
        _bandWidthNow = bandWidthNow;
        _bandWidthMax = bandWidthMax;
        _last12BandWidths = last12BandWidths;
        _last6Visits = last6Visits;
        _last9Responses = last9Responses;
        _responseMax = responseMax;
        _responseAvg = responseAvg;
        _ramMax = ramMax;
        _last12Rams = last12Rams;
        _discMax = discMax;
        _discNums = discNums;
        _last24DiscUses = last24DiscUses;
        _discInput = discInput;
        _discOutput = discOutput;
        _cpuNum = cpuNum;
        _cpuRate = cpuRate;
        _Apps = apps;
        _appNum = appNum;
    }

    public void SetName(cloudName cn) {
        this._name = cn;
    }

    public string GetName() {
        return this._name.ToString();
    }

    public void SetID(int id) {
        this._id = id;
    }

    public int GetID() {
        return this._id;
    }
    
    public void SetUpLoadRate(float upLoadRate) {
        this._upLoadRate = upLoadRate;
    }

    public float GetUpLoadRate() {
        return this._upLoadRate;
    }
    
    public void SetDownLoadRate(float downLoadRate) {
        this._downLoadRate = downLoadRate;
    }

    public float GetDownLoadRate() {
        return this._downLoadRate;
    }
    
    public void SetBandWidthNow(float bandWidthNow) {
        this._bandWidthNow = bandWidthNow;
    }

    public float GetBandWidthNow() {
        return this._bandWidthNow;
    }
    
    public void SetBandWidthMax(float bandWidthMax) {
        this._bandWidthMax = bandWidthMax;
    }

    public float GetBandWidthMax() {
        return this._bandWidthMax;
    }
    public void SetLast12BandWidths(List<float> lastBandWidths) {
        for (int i =0;i<lastBandWidths.Count;i++) {
            this._last12BandWidths.Add(lastBandWidths[i]);	
        }
    }

    public List<float> GetLast12BandWidths() {
        return this._last12BandWidths;
    }
    
    public void SetLast6Visits(List<float> lastVisits) {
        for (int i =0;i<lastVisits.Count;i++) {
            this._last6Visits.Add(lastVisits[i]);	
        }
    }

    public List<float> GetLast6Visits() {
        return this._last6Visits;
    }
    
    
    public void SetLast9Responses(List<float> lastRespons) {
        for (int i =0;i<lastRespons.Count;i++) {
            this._last9Responses.Add(lastRespons[i]);	
        }
    }

    public List<float> GetLast9Responses() {
        return this._last9Responses;
    }
    
    
    public void SetResponseMax(float responseMax) {
        this._responseMax = responseMax;
    }

    public float GetResponseMax() {
        return this._responseMax;
    }
    
    
    public void SetResponseAvg(float responseAvg) {
        this._responseAvg = responseAvg;
    }

    public float GetResponseAvg() {
        return this._responseAvg;
    }
    
    
    public void SetRamMax(float ramMax) {
        this._ramMax = ramMax;
    }

    public float GetRamMax() {
        return this._ramMax;
    }
    
    public void SetLast12Rams(List<float> lasRams) {
        for (int i =0;i<lasRams.Count;i++) {
            this._last12Rams.Add(lasRams[i]);	
        }
    }

    public List<float> GetLast12Rams() {
        return this._last12Rams;
    }
    
        
    public void SetDiscMax(float discMax) {
        this._discMax = discMax;
    }

    public float GetDiscMax() {
        return this._discMax;
    }
    
    
    
    public void SetDiscNums(List<int> discNums) {
        for (int i =0;i<discNums.Count;i++) {
            this._discNums.Add(discNums[i]);	
        }
    }

    public List<int> GetDiscNums() {
        return this._discNums;
    }
    
        
    public void SetLast24DiscUses(List<float> lasDiscs) {
        for (int i =0;i<lasDiscs.Count;i++) {
            this._last24DiscUses.Add(lasDiscs[i]);	
        }
    }

    public List<float> GetLast24DiscUses() {
        return this._last24DiscUses;
    }
    
    
    public void SetDiscInput(float discInput) {
        this._discInput = discInput;
    }

    public float GetDiscInput() {
        return this._discInput;
    }
    
    
    public void SetDiscOutput(float discOutput) {
        this._discOutput = discOutput;
    }

    public float GetDiscOutput() {
        return this._discOutput;
    }
    
    
    public void SetCpuNum(int cpuNums) {
        this._cpuNum = cpuNums;
    }

    public int GetCpuNum() {
        return this._cpuNum;
    }
    
    
    
    public void SetCpuRate(float cpuRate) {
        this._cpuRate = cpuRate;
    }

    public float GetCpuRate() {
        return this._cpuRate;
    }


    public void SetApps(List<string> appNames) {
        for (int i = 0; i < appNames.Count; i++) {
            this._Apps.Add(appNames[i]);
        }
        
    }

    public List<string> GetApps() {
        return this._Apps;
    }



    public void SetAppNum(int appNum) {
        this._appNum = appNum;
    }

    public int GetAppNum() {
        return this._appNum;
    }

    

    
}
