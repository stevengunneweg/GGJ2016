using System.Collections;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {
    public float seconds;

    public void Start(){
        StartCoroutine(DestroyAfterSeconds());
    }

    public IEnumerator DestroyRoutine(){
        yield return new WaitForSeconds(seconds);
        Destroy(GameObject);
    }
}