using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

    }

    public void Kill()
    {
        EnemySpawn.instance.RemoveEnemy(this.gameObject);
    }
}
