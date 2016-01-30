using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spellpanel : MonoBehaviour {

    private SpellManager spellManager;

	// Use this for initialization
	void Start () {
        spellManager = GameObject.Find("Managers").GetComponent<SpellManager>();
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void AddElement(Element value)
    {
        spellManager.AddElementToQueue(value);
    }
}
