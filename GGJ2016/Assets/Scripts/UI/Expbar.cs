using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Expbar : MonoBehaviour {

    Slider _slider;

	// Use this for initialization
	void Start () {
        _slider = GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerManager.instance != null)
            _slider.value = PlayerManager.instance.PercentageAmount;

    }
}
