using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Spawn(Vector3 position)
    {
        transform.localPosition = position;
        StartCoroutine(MoveRoutine());

    }

    public void Kill()
    {
        EnemySpawn.instance.RemoveEnemy(this.gameObject);
        StopCoroutine(MoveRoutine());
    }

    public void Move(){
        enemyManager.MoveEnemyToNewPosition(this);
    }

    private IEnumerator MoveRoutine(){
        while(true){
            yield return new WaitForSeconds(1);

            Move();
        }
    }
}
