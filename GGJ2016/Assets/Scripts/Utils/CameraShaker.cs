using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {

    private float time;
    private float shakeAmount;
    private float decreaseFactor = 1;

    public void Shake(float amount, float time){
        shakeAmount = amount;
        this.time = time;
    }

    private void Update(){
        if (time > 0) {
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
            time -= Time.deltaTime * decreaseFactor;

        } else {
            time = 0.0f;
        }
    }
}
