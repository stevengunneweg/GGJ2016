using UnityEngine;
using System.Collections;

public class Tile {

    public int X { get; private set; }
    public int Y { get; private set; }
    public Enemy enemy;
    public int Score = 9999;

    public Tile(int x, int y){
        X = x;
        Y = y;
    }

    public bool HasEnemy(){
        return enemy != null;
    }
}
