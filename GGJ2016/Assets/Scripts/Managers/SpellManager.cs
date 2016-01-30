using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellManager : MonoBehaviour {

    private Object[] _spellsObjects;
    private Object[] _elementsObjects;
    private Spell[] _spells;
    private Element[] _elements;

    private List<Element> selectedElems = new List<Element>();
    
    public float maxDistance = 50f;

    // Use this for initialization
    void Start () {
        SetSpellAndElements();
    }

    public Spell FindSpell(List<Element> elements){
        
        foreach(Spell spell in _spells){
            
            if(spell.Elements.Count != elements.Count){
                continue;
            }

            bool hasElements = elements.All(el => spell.Elements.Contains(el));
            if(hasElements){
                return spell;
            }
        }

        return null;
    }

    internal void AddElementToQueue(Element value)
    {
        selectedElems.Add(value);
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


    void FixedUpdate() {
        //if mouse button (left hand side) pressed instantiate a raycast
        if (Input.GetMouseButtonDown(0)) {
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance)) {
                //log hit area to the console
                Debug.Log(hit.point);
                Spell cur_spell = FindSpell(selectedElems);
                Debug.Log(cur_spell);

                if (cur_spell != null) {
                    GameObject ding = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    ding.transform.position += hit.point;
                    Instantiate(ding);
                }
            }
            selectedElems.Clear();
        }
    }
}
