using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashPanel : MonoBehaviour {

    private Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        renderer.transform.LookAt(Camera.main.transform);
        renderer.transform.Rotate(180, 0, 0);
	}

    public void Flash(Color color, float duration){
        LeanTween.alpha(renderer.gameObject, 1.0f, duration/2.0f).onComplete = delegate {
            LeanTween.alpha(renderer.gameObject, 0.0f, duration/2);
        };
    }
}
