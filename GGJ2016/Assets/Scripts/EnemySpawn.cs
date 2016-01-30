using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;

    public static EnemySpawn instance;

    public List<GameObject> ActiveEnemies = new List<GameObject>();
    private List<GameObject> _deactive_Enemies = new List<GameObject>();

    private Transform _deactiveParent;
    private Transform _activeParent;
    // Use this for initialization
    void Awake()
    {
        instance = this;
        _deactiveParent = transform.Find("Deactive");
        _activeParent = transform.Find("Active");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            CreateEnemy();
        if (Input.GetKeyDown(KeyCode.K))
            RemoveEnemy(ActiveEnemies[ActiveEnemies.Count-1]);
        if (Input.GetKeyDown(KeyCode.L))
            RemoveAll();
    }
    public Enemy CreateEnemy()
    {
        GameObject enemy;
        if (_deactive_Enemies.Count == 0)
        {
            enemy = Instantiate(enemyPrefab);
            ActiveEnemies.Add(enemy);
        }
        else
        {
            enemy = _deactive_Enemies[_deactive_Enemies.Count - 1];
            _deactive_Enemies.Remove(enemy);
            ActiveEnemies.Add(enemy);
        }
        enemy.SetActive(true);
        enemy.transform.SetParent(_activeParent);

        return enemy.GetComponent<Enemy>();

    }
    public void RemoveEnemy(GameObject enemy)
    {
        _deactive_Enemies.Add(enemy);
        ActiveEnemies.Remove(enemy);
        enemy.transform.position = Vector3.zero;
        enemy.SetActive(false);
        enemy.transform.SetParent(_deactiveParent);
    }
    void RemoveAll()
    {
        foreach (GameObject enemy in ActiveEnemies)
        {
            _deactive_Enemies.Add(enemy);
            enemy.transform.position = Vector3.zero;
            enemy.SetActive(false);
            enemy.transform.SetParent(_deactiveParent);
        }
        ActiveEnemies.Clear();
    }

}
