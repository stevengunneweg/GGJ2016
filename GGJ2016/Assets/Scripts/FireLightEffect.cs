using UnityEngine;
using System.Collections;

public class FireLightEffect : MonoBehaviour {

    Light theLight;
    float defRange;
    public float delay;
	// Use this for initialization
	void Start () {
        theLight = GetComponent<Light>();
        defRange = theLight.range;
        theLight.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0)
        {
            theLight.enabled = true;
            theLight.range = defRange + Mathf.Sin(Time.time * 20) * (Random.Range(1, 3) / 2);
            delay = 0;
        }
        else
        {
            delay -= Time.deltaTime;
        }

    }
}
