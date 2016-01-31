using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

    Vector3 targetPos;
    Transform camera;
    bool go_up = true;
	// Use this for initialization
	void Start () {
        camera = GameObject.Find("CameraContainer/GameObject/Main Camera").transform;
        targetPos = transform.position + Vector3.up*3;

    }
    void Update()
    {
        if (go_up)
        {
            if (Vector3.Distance(transform.position, targetPos) < 0.5)
            {
                go_up = false;
            }
        }
        else {
            targetPos = camera.position + (camera.forward * 0.7f) + ((camera.up * -0.8f));
            if (Vector3.Distance(transform.position, targetPos) < 0.5)
            {
                DestroySelf();
            }
        }
        transform.position += (targetPos - transform.position) * (Time.deltaTime * 5);
    }
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
