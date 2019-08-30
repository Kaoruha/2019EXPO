using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cake : MonoBehaviour {
    private Transform stick;
    private int shakeRange;


    private void Start() {
        shakeRange = 20;
        stick = transform.GetChild(0);
        StartCoroutine(Running());
    }

    private void Update() {
    }


    private IEnumerator Running() {
        while (true) {
            if (Random.value >= 0.5f) {
                stick.Rotate(Vector3.forward, shakeRange * Random.value);
            }
            else {
                stick.Rotate(Vector3.forward, -shakeRange * Random.value);
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}