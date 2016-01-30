using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;
    private List<GameObject> _active_Enemies = new List<GameObject>();
    private List<GameObject> _deactive_Enemies = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            CreateEnemy();
        if (Input.GetKeyDown(KeyCode.D))
            RemoveEnemy(_active_Enemies[_active_Enemies.Count-1]);
        if (Input.GetKeyDown(KeyCode.W))
            RemoveAll();
    }
    void CreateEnemy()
    {
        GameObject enemy;
        if (_deactive_Enemies.Count == 0)
        {
            enemy = Instantiate(enemyPrefab);
            _active_Enemies.Add(enemy);
        }
        else
        {
            enemy = _deactive_Enemies[_deactive_Enemies.Count - 1];
            _deactive_Enemies.Remove(enemy);
            _active_Enemies.Add(enemy);
        }
        enemy.SetActive(true);
        enemy.transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

    }
    void RemoveEnemy(GameObject enemy)
    {
        _deactive_Enemies.Add(enemy);
        _active_Enemies.Remove(enemy);
        enemy.transform.position = Vector3.zero;
        enemy.SetActive(false);
    }
    void RemoveAll()
    {
        foreach (GameObject enemy in _active_Enemies)
        {
            _deactive_Enemies.Add(enemy);
            enemy.transform.position = Vector3.zero;
            enemy.SetActive(false);
        }
        _active_Enemies.Clear();
    }

}
