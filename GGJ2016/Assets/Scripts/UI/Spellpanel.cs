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
            SendSpell();
            _spell.Clear();
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
        Debug.Log("SendSpell " + _spell.Count);
        if (_spell.Count > 0)
        {
            Spell spell = spellManager.FindSpell(_spell);
            if (spell != null)
            {
                Debug.Log("Spell: "+ spell.name);
                eventManager.SpellCasted(spell);
            }
            else
                Debug.Log("Spell: Null");
        }
    }
}
