using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
        EnemyManager manager = FindObjectOfType<EnemyManager>();
        Tile tileOfEnemy = manager.GetTileOfEnemy(enemy);
        List<Tile> neighbours = manager.GetNeighborsOfTile(tileOfEnemy);
        neighbours.RemoveAll(t => t.Score <= tileOfEnemy.Score);
        neighbours.Sort((x, y) => y.Score - x.Score);

        foreach(Tile neighbour in neighbours){
            if(neighbour.HasEnemy() == false){
                enemy.ForceMove(manager.GetWorldLocationOfTile(neighbour.X, neighbour.Y));
                tileOfEnemy.enemy = null;
                neighbour.enemy = enemy;
                return;
            }
        }
	}
}
