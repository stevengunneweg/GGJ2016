using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spelitem : MonoBehaviour {
    public Element element;
    private Spellpanel _spellPanel;
    Button _button;
    Text _text;
    bool selected = false;
	// Use this for initialization
	void Start () {
        _spellPanel = transform.parent.GetComponent<Spellpanel>();
        GetComponent<Image>().sprite = element.Image;
        _button = GetComponent<Button>();
        _text = transform.Find("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _button.interactable = element.Available;
        _text.text = element.Available ? "" : Mathf.Ceil(element.CurrentCooldown).ToString();
        CheckSelected();
    }
    public void OnClick()
    {
        _spellPanel.AddElement(element);
    }
    void CheckSelected()
    {
        selected = false;
        foreach (Element el in _spellPanel.SelectedElement())
        {
            if (el.name == element.name) 
                selected = true;
        }
        if (!LeanTween.isTweening(this.gameObject)) {
            if (selected)
                LeanTween.scale(this.gameObject, Vector3.one * 1.3f, 0.2f).setEase(LeanTweenType.easeInOutElastic);
            else
                LeanTween.scale(this.gameObject, Vector3.one, 0.2f);
        }
        
    }
}
