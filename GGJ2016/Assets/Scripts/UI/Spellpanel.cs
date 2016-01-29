using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spellpanel : MonoBehaviour {

    private List<Element> _spell = new List<Element>();


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendSpell();
        }
	}
    public void AddElement(Element value)
    {
        _spell.Add(value);
        string line = "";
        foreach(Element el in _spell)
        {
            line += el.name + ", ";
        }

        Debug.Log("Spell: "+ _spell.Count+" Content: "+ line);
    }
    void SendSpell()
    {

    }
}
