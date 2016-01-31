using UnityEngine;
using System.Collections;

public class TabPanel : MonoBehaviour {

    private SpellManager spellManager;

    public void Start () {
        spellManager = GameObject.Find("Managers").GetComponent<SpellManager>();
    }
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            spellManager.AddElementToQueue(spellManager.Elements[0]);
            transform.GetChild(0).GetComponent<Tab>().Select();
            transform.GetChild(1).GetComponent<Tab>().Deselect();
            transform.GetChild(2).GetComponent<Tab>().Deselect();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            spellManager.AddElementToQueue(spellManager.Elements[1]);
            transform.GetChild(0).GetComponent<Tab>().Deselect();
            transform.GetChild(1).GetComponent<Tab>().Select();
            transform.GetChild(2).GetComponent<Tab>().Deselect();
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            spellManager.AddElementToQueue(spellManager.Elements[2]);
            transform.GetChild(0).GetComponent<Tab>().Deselect();
            transform.GetChild(1).GetComponent<Tab>().Deselect();
            transform.GetChild(2).GetComponent<Tab>().Select();
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            spellManager.AddElementToQueue(spellManager.Elements[3]);
        }
    }

    public void DeselectAll(){
        transform.GetChild(0).GetComponent<Tab>().Deselect();
        transform.GetChild(1).GetComponent<Tab>().Deselect();
        transform.GetChild(2).GetComponent<Tab>().Deselect();
    }
}
