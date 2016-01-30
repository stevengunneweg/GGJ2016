using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class EnemyManager : MonoBehaviour {
    public GameObject tile;

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
                tiles[x, y] = new Tile(x, y);
            }
        }

        int centerX = (int)Math.Floor(WIDTH/2.0f);
        int centerY = (int)Math.Floor(HEIGHT/2.0f);
        FloodTile(tiles[centerX, centerY], 0, new List<Tile>());

        //DebugDrawTiles();

        StartCoroutine(SpawnEnemies());
    }

    private void DebugDrawTiles(){
        foreach(Tile tile in Flatten(tiles)){
            GameObject go = Instantiate<GameObject>(this.tile);
            go.GetComponentInChildren<TextMesh>().text = tile.X + "," + tile.Y + ": " + tile.Score;
            go.transform.position = GetWorldLocationOfTile(tile.X, tile.Y);
        }
    }

    public void MoveEnemyToNewPosition(Enemy enemy){
        Tile tileOfEnemy = Flatten(tiles).FirstOrDefault(t => t.enemy == enemy);

        if(tileOfEnemy == null){
            throw new Exception("COULD NOT FIND TILE OF ENEMY");
        }

        Tile newTile = GetNewTilePosition(tileOfEnemy);

        if(newTile != null){
            tileOfEnemy.enemy = null;
            newTile.enemy = enemy;
            enemy.transform.position = GetWorldLocationOfTile(newTile.X, newTile.Y);
        }
    }

    private Tile GetNewTilePosition(Tile currentTile){
        // find neighbours
        List<Tile> neighbours = GetNeighborsOfTile(currentTile);

        Tile newTile = null;
        neighbours.Sort((x, y) => x.Score - y.Score);
        Debug.Log(neighbours.Count);
        foreach(Tile neighbour in neighbours){
            if(neighbour.HasEnemy() == false && currentTile.Score > neighbour.Score){
                newTile = neighbour;
            }
        }

        return newTile;
    }

    public IEnumerator SpawnEnemies(){
        while(true){

            int amount = UnityEngine.Random.Range(1, 1);

            for(int i = 0; i < amount; i++){
                Enemy enemy = EnemySpawn.instance.CreateEnemy();

                bool hasEnemy = true;
                while(hasEnemy){
                    Vector2 tile = RandomStartTile();
                    if(tiles[(int)tile.x, (int)tile.y].HasEnemy() == false){
                        tiles[(int)tile.x, (int)tile.y].enemy = enemy;
                        Vector3 position = GetWorldLocationOfTile((int)tile.x, (int)tile.y);
                        enemy.Spawn(position);
                        hasEnemy = false;
                    }
                }
            }

            yield return new WaitForSeconds(20);
        }

    }

    private Vector3 GetWorldLocationOfTile(int x, int y){
        return new Vector3(x * TEMPLE_TILE_SIZE - (TEMPLE_TILE_SIZE * (WIDTH/2)), 0, y * TEMPLE_TILE_SIZE - (TEMPLE_TILE_SIZE * (HEIGHT/2)));
    }

    private Vector2 RandomStartTile(){
        int x = 0;
        int y = 0;

        switch((int)(UnityEngine.Random.value * 4)){
            case 0:
                x = OuterRim;
                y = UnityEngine.Random.Range(0, OuterRim);
                break;
            case 1:
                x = UnityEngine.Random.Range(0, OuterRim);
                y = OuterRim;
                break;
            case 2:
                x = 0;
                y = UnityEngine.Random.Range(0, OuterRim);
                break;
            case 3:
                x = UnityEngine.Random.Range(0, OuterRim);
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

    public IEnumerable<T> Flatten<T>(T[,] map) {
        for (int row = 0; row < map.GetLength(0); row++) {
            for (int col = 0; col < map.GetLength(1); col++) {
                yield return map[row,col];
            }
        }
    }

    private void FloodTile(Tile tile, int score, List<Tile> doneTiles){
        List<Tile> neighbours = GetNeighborsOfTile(tile);

        if(tile.Score > score){
            tile.Score = score;
        } else {
            return;
        }

        tile.Score = score;
        doneTiles.Add(tile);

        foreach(Tile neighbourTile in neighbours){
                
            FloodTile(neighbourTile, score+1, doneTiles);
        }
    }

    private List<Tile> GetNeighborsOfTile(Tile tile) {
        List<Tile> neighbours = new List<Tile>();

        if(tile.X > 0) // left
            neighbours.Add(tiles[tile.X - 1, tile.Y]);

        if(tile.X < WIDTH - 1) // right
            neighbours.Add(tiles[tile.X + 1, tile.Y]);

        if(tile.Y > 0) // down
            neighbours.Add(tiles[tile.X, tile.Y - 1]);

        if(tile.Y < HEIGHT - 1) // up
            neighbours.Add(tiles[tile.X, tile.Y + 1]);

        return neighbours;
    }
}
