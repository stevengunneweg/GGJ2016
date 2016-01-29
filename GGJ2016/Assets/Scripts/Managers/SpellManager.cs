using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellManager : MonoBehaviour {

    Spell[] _spells;
    Element[] _elements;

    // Use this for initialization
    void Start () {
        _spells = Resources.FindObjectsOfTypeAll<Spell>();
        _elements = Resources.FindObjectsOfTypeAll<Element>();
        Debug.Log("Spells "+_spells.Length);
        Debug.Log("Elements " + _elements.Length);
    }

    public Spell FindSpell(List<Element> elements){
        foreach(Spell spell in _spells){
            bool hasElements = elements.All(el => spell.Elements.Contains(el));
            return spell;
        }

        return null;
    }
}
