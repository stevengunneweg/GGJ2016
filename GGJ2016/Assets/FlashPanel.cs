using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashPanel : MonoBehaviour {

    private Renderer theRenderer;

	// Use this for initialization
	void Start () {
        theRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        theRenderer.transform.LookAt(Camera.main.transform);
        theRenderer.transform.Rotate(180, 0, 0);
	}

    public void Flash(Color color, float duration){
        LeanTween.alpha(theRenderer.gameObject, 1.0f, duration/2.0f).onComplete = delegate {
            LeanTween.alpha(theRenderer.gameObject, 0.0f, duration/2);
        };
    }
}
