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
        Tile tile = enemyManager.GetTileOfEnemy(this);
        if(tile != null){
            tile.enemy = null;
        }

        EnemySpawn.instance.RemoveEnemy(this.gameObject);
        StopCoroutine(MoveRoutine());
    }

    public void TryMove(){
        enemyManager.MoveEnemyToNewPosition(this);
    }

    public void Move(Vector3 position){
        transform.transform.localPosition = position;
    }

    private IEnumerator MoveRoutine(){
        while(true){
            yield return new WaitForSeconds(1);

            TryMove();
        }
    }
}
