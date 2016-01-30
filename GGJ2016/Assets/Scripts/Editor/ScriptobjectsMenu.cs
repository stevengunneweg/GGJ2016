using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuItems : MonoBehaviour {

    [MenuItem("Assets/Create/Element")]
    public static void CreateElementAsset ()
    {
        ScriptableObjectUtility.CreateAsset<Element> ();
    }

    [MenuItem("Assets/Create/Spell")]
    public static void CreateSpellAsset ()
    {
        ScriptableObjectUtility.CreateAsset<Spell> ();
    }
}
