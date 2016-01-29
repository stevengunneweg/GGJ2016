using UnityEngine;
using System.Collections;
using System;

public class PopulationManager : MonoBehaviour {

    public Action<int> PopulationChanged;

    [SerializeField]
    private GameObject person;

    private int amount;

    private void Start(){
    
        AddPopultation(2);
    }
   

    public void AddPopultation(int amount) {
        this.amount += amount;

        for(int i = 0; i < amount; i++){
            GameObject newPerson = Instantiate(person);
            newPerson.transform.SetParent(transform, false);
            newPerson.transform.position += new Vector3(UnityEngine.Random.Range(-2.0f, 2.0f), 0, 0);
        }

    }

    public void RemovePopultation(int amount) {
        for(int i = 0; i < amount; i++){
            Transform child = FindPerson();
            if(child == null){
                return;
            }

            Destroy(child.gameObject);
        }
    }

    private Transform FindPerson(){
        foreach(Transform child in transform){
            if(child != null){
                return child;
            }
        }

        return null;
    }

}
