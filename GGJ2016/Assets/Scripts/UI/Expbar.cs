using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Expbar : MonoBehaviour {

    Slider _slider;

    public ParticleSystem System;
    public RectTransform ParticleBegin;
    public RectTransform ParticleEnd;

	// Use this for initialization
	void Start () {
        _slider = GetComponent<Slider>();
        System.Pause();

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerManager.instance != null)
            _slider.value = PlayerManager.instance.PercentageAmount;

    }

    public void PlayCompleted(){
        System.Play();
        LeanTween.moveLocal(System.gameObject, ParticleEnd.transform.localPosition, 1.0f).onComplete = delegate {
            System.Stop();
            System.transform.localPosition = ParticleBegin.transform.localPosition;
        };
    }
}
