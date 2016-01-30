using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    private const int WIDTH = 17;
    private const int HEIGHT = 17;
    private const float TEMPLE_TILE_SIZE = 2.19f;

    private Tile[,] tiles;
    private EnemySpawn enemySpawn;

    private void Start(){
        enemySpawn = FindObjectOfType<EnemySpawn>();

        tiles = new Tile[WIDTH,HEIGHT];

        for(int y = 0; y < HEIGHT; y++){
            for(int x = 0; x < WIDTH; x++){
                tiles[x, y] = new Tile();
            }
        }

        //StartCoroutine(SpawnEnemies());
    }

    public Vector3 GetNewEnemyPosition(Enemy enemy){
        return Vector3.zero;
    }

    public IEnumerator SpawnEnemies(){
        while(true){
            yield return new WaitForSeconds(1);

            int amount = Random.Range(1, 4);

            for(int i = 0; i < amount; i++){
                Enemy enemy = EnemySpawn.instance.CreateEnemy();

                bool hasEnemy = true;
                while(hasEnemy){
                    Vector2 tile = RandomStartTile();
                    Debug.Log(tile);
                    if(tiles[(int)tile.x, (int)tile.y].HasEnemy() == false){
                        tiles[(int)tile.x, (int)tile.y].enemy = enemy;
                        enemy.transform.position = GetWorldLocationOfTile((int)tile.x, (int)tile.y);
                        hasEnemy = false;
                    }
                }
            }
        }

    }

    private Vector3 GetWorldLocationOfTile(int x, int y){
        return new Vector3(x * TEMPLE_TILE_SIZE - (TEMPLE_TILE_SIZE * (WIDTH/2)), 0, y * TEMPLE_TILE_SIZE - (TEMPLE_TILE_SIZE * (HEIGHT/2)));
    }

    private Vector2 RandomStartTile(){
        int x = 0;
        int y = 0;

        switch((int)(Random.value * 4)){
            case 0:
                x = OuterRim;
                y = Random.Range(0, OuterRim);
                break;
            case 1:
                x = Random.Range(0, OuterRim);
                y = OuterRim;
                break;
            case 2:
                x = 0;
                y = Random.Range(0, OuterRim);
                break;
            case 3:
                x = Random.Range(0, OuterRim);
                y = 0;
                break;
        }

        return new Vector2(x, y);

    }

    private int OuterRim {
        get {
            return WIDTH-1;
        }
    }


}
