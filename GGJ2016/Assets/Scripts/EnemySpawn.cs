using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;

    public static EnemySpawn instance;

    void Awake()
    {
        instance = this;
    }

    public Enemy CreateEnemy() {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.SetParent(transform, false);
        return enemy.GetComponent<Enemy>();

    }

    public void RemoveEnemy(GameObject enemy){
        Destroy(enemy);
    }

}
