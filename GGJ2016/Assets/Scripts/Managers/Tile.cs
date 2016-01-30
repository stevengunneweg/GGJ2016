using UnityEngine;
using System.Collections;

public class Tile {

    public Enemy enemy;

    public bool HasEnemy(){
        return enemy != null;
    }
}
