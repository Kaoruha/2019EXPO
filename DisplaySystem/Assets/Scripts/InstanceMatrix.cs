using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMatrix : MonoBehaviour {
    public GameObject instance;


    public int row;

    public int column;

    public float spacing;
    
    
    // Start is called before the first frame update
    void Start() {
        Initiation(row,column);
        StartCoroutine(Running(0.6f,0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Transform> Instances;
    private void Initiation(int row,int column) {
        Instances = new List<Transform>();
        float interval = spacing + instance.GetComponent<RectTransform>().sizeDelta.x;
        float x = 0;
        float y = 0;
        for (int i = 0; i < column; i++) {
            y = 0;
            for (int j = 0; j < row; j++) {
                GameObject go = GameObject.Instantiate(instance, this.transform);
                go.transform.position = new Vector3(x+transform.position.x,y+transform.position.y,0);
                Instances.Add(go.transform);
                y -= interval;
                   
            }

            x += interval;
        }
    }


    private IEnumerator Running(float rate, float time) {
        while (true) {
            for (int i = 0; i < Instances.Count; i++) {
                if (UnityEngine.Random.value <= rate) {
                    if (Instances[i].GetChild(0).gameObject.active) {
                        Instances[i].GetChild(0).gameObject.SetActive(false);
                    }
                    else if (!Instances[i].GetChild(0).gameObject.active) {
                        Instances[i].GetChild(0).gameObject.SetActive(true);
                    }
                    
                }
            }
            yield return new WaitForSeconds(time);
        }
    }
    
    
}
