using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell : ScriptableObject {

    public List<Element> Elements;
    public GameObject Effect;
    public int Radius = 10;

    public void Cast(Vector3 pos)
    {
        GameObject effectGameObject = Instantiate(Effect);
        effectGameObject.transform.position += pos;
    }
}
