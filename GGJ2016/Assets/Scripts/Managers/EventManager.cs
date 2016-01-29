using UnityEngine;
using System.Collections;
using System;

public class EventManager : MonoBehaviour {

    [SerializeField]
    private Transform effectParent;


    public void SpellCasted(Spell spell){
        PlayEvent(spell.Event);
    }

    private void PlayEvent(Event myEvent){
        GameObject effectGameObject = Instantiate(myEvent.Effect);
        effectGameObject.transform.SetParent(effectParent, false);

        PopulationManager populationManager = FindObjectOfType<PopulationManager>();

        if(myEvent.populationEffect > 0){
            populationManager.AddPopultation(myEvent.populationEffect);
        }else{
            populationManager.RemovePopultation(Math.Abs(myEvent.populationEffect));
        }
    }
}
