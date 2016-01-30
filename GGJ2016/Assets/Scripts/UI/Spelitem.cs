using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spelitem : MonoBehaviour {
    public Element element;
    private Spellpanel _spellPanel;
    Button _button;
	// Use this for initialization
	void Start () {
        _spellPanel = transform.parent.GetComponent<Spellpanel>();
        GetComponent<Image>().sprite = element.Image;
        _button = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        _button.interactable = element.Available;
	}
    public void OnClick()
    {
        _spellPanel.AddElement(element);
    }
}
