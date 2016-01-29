using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellManager : MonoBehaviour {

    Object[] _spellsObjects;
    Object[] _elementsObjects;
    Spell[] _spells;
    Element[] _elements;

    // Use this for initialization
    void Start () {
        SetSpellAndElements();

    }

    public Spell FindSpell(List<Element> elements){
        foreach(Spell spell in _spells){
            bool hasElements = elements.All(el => spell.Elements.Contains(el));
            return spell;
        }

        return null;
    }
	
	// Update is called once per frame
	void Update () {

    }
    void SetSpellAndElements()
    {
        //_spells = Resources.FindObjectsOfTypeAll<Spell>();
        //_elements = Resources.FindObjectsOfTypeAll<Element>();
        _spellsObjects = Resources.LoadAll("Data", typeof(Spell));
        _elementsObjects = Resources.LoadAll("Data", typeof(Element));
        _spells = new Spell[_spellsObjects.Length];
        _elements = new Element[_elementsObjects.Length];
        for (int i=0;i< _spellsObjects.Length;i++)
        {
            _spells[i] = _spellsObjects[i] as Spell;
        }
        for (int i = 0; i < _elementsObjects.Length; i++)
        {
            _elements[i] = _elementsObjects[i] as Element;
        }
        Debug.Log("_spells: " + _spells.Length+" 0:"+ _spells[0]);
        Debug.Log("_elements: " + _elements.Length + " 0:" + _elements[0]);
    }

    public Spell[] Spells
    {
        get { return _spells; }
    }
    public Element[] Elements
    {
        get { return _elements; }
    }

}
