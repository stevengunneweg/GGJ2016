﻿using UnityEngine;
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
            transform.GetChild(0).GetComponent<Tab>().Select();
            transform.GetChild(1).GetComponent<Tab>().Deselect();
            transform.GetChild(2).GetComponent<Tab>().Deselect();
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            spellManager.AddElementToQueue(spellManager.Elements[1]);
            transform.GetChild(0).GetComponent<Tab>().Deselect();
            transform.GetChild(1).GetComponent<Tab>().Select();
            transform.GetChild(2).GetComponent<Tab>().Deselect();
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            spellManager.AddElementToQueue(spellManager.Elements[2]);
            transform.GetChild(0).GetComponent<Tab>().Deselect();
            transform.GetChild(1).GetComponent<Tab>().Deselect();
            transform.GetChild(2).GetComponent<Tab>().Select();
		} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			spellManager.AddElementToQueue(spellManager.Elements[3]);
		}
    }
    public void AddElement(Element value)
    {
        if (value.Available)
            spellManager.AddElementToQueue(value);
        else
            Debug.Log(value.name + " Not available");
    }
    public List<Element> SelectedElement()
    {
        return spellManager.SelectedElements();
    }
}
