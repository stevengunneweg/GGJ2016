using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spellpanel : MonoBehaviour {

    private SpellManager spellManager;
    private EventManager eventManager;

    private List<Element> _spell = new List<Element>();


	// Use this for initialization
	void Start () {
        spellManager = GameObject.Find("Managers").GetComponent<SpellManager>();
        eventManager = GameObject.Find("Managers").GetComponent<EventManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spell.Clear();
        }
	}
    public void AddElement(Element value)
    {
        _spell.Add(value);
        spellManager.AddElementToQueue(value);
    }
}
