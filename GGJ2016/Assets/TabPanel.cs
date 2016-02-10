using UnityEngine;
using System.Collections;

public class TabPanel : MonoBehaviour {

    private SpellManager spellManager;

    public void Start () {
        spellManager = GameObject.Find("Managers").GetComponent<SpellManager>();
    }
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            SelectSpell(0);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            SelectSpell(1);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            SelectSpell(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            spellManager.AddElementToQueue(spellManager.Elements[3]);
        }
    }
    private void SelectSpell(int index)
    {
        switch (index)
        {
            case 0:
                spellManager.AddElementToQueue(spellManager.Elements[0]);
                transform.GetChild(0).GetComponent<Tab>().Select();
                transform.GetChild(1).GetComponent<Tab>().Deselect();
                transform.GetChild(2).GetComponent<Tab>().Deselect();
                break;
            case 1:
                spellManager.AddElementToQueue(spellManager.Elements[1]);
                transform.GetChild(0).GetComponent<Tab>().Deselect();
                transform.GetChild(1).GetComponent<Tab>().Select();
                transform.GetChild(2).GetComponent<Tab>().Deselect();
                break;
            case 2:
                spellManager.AddElementToQueue(spellManager.Elements[2]);
                transform.GetChild(0).GetComponent<Tab>().Deselect();
                transform.GetChild(1).GetComponent<Tab>().Deselect();
                transform.GetChild(2).GetComponent<Tab>().Select();
                break;
        }
    }


    public void DeselectAll(){
        transform.GetChild(0).GetComponent<Tab>().Deselect();
        transform.GetChild(1).GetComponent<Tab>().Deselect();
        transform.GetChild(2).GetComponent<Tab>().Deselect();
    }
    public void ClickElement(int elementID)
    {
        SelectSpell(elementID);
    }
}
