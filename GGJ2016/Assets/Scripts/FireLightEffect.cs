using UnityEngine;
using System.Collections;

public class FireLightEffect : MonoBehaviour {

    Light light;
    float defRange;
    public float delay;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        defRange = light.range;
        light.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0)
        {
            light.enabled = true;
            light.range = defRange + Mathf.Sin(Time.time * 20) * (Random.Range(1, 3) / 2);
            delay = 0;
        }
        else
        {
            delay -= Time.deltaTime;
        }

    }
}
