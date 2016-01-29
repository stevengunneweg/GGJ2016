using UnityEngine;
using System.Collections;

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
