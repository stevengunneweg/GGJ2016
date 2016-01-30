using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {

    private float time = 0;
    private float shakeAmount;
    private float decreaseFactor = 1;
    private Vector3 ownposition;
    bool _shake = false;

    void Start()
    {
        ownposition =transform.localPosition;
    }

    public void Shake(float amount, float time){
        shakeAmount = amount;
        ownposition = transform.localPosition;
        this.time = time;
        _shake = true;
    }

    private void Update(){
        if (_shake)
        {
            if (time > 0)
            {
                transform.localPosition = ownposition + (Random.insideUnitSphere * shakeAmount);
                time -= Time.deltaTime * decreaseFactor;

            }
            else {
                time = 0.0f;
                transform.localPosition = ownposition;
                _shake = false;
            }
        }
    }
}
