using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spelitem : MonoBehaviour {
    public Element element;
    private Spellpanel _spellPanel;
	// Use this for initialization
	void Start () {
        _spellPanel = transform.parent.GetComponent<Spellpanel>();
        GetComponent<Image>().sprite = element.Image;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        _spellPanel.AddElement(element);
    }
}
