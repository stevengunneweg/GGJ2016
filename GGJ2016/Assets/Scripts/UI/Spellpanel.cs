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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
			spellManager.AddElementToQueue(spellManager.Elements[0]);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			spellManager.AddElementToQueue(spellManager.Elements[1]);
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			spellManager.AddElementToQueue(spellManager.Elements[2]);
		} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			spellManager.AddElementToQueue(spellManager.Elements[3]);
		}
    }
    public void AddElement(Element value)
    {
        spellManager.AddElementToQueue(value);
    }
}
