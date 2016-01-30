using UnityEngine;
using System.Collections;

public class FireSpellEffect : BaseSpellEffect {
	private GameObject enemyBurn;
	public GameObject enemyBurnPrefab;

    public override void ApplyEffectToEnemy(Enemy enemy)
    {
		enemyBurn = Instantiate(enemyBurnPrefab);
		enemyBurn.transform.SetParent(enemy.transform, false);

		enemy.StartCoroutine(SetEnemyOnFire(enemy));
    }

	private IEnumerator SetEnemyOnFire(Enemy enemy) {
		yield return new WaitForSeconds(3);
		enemy.Kill(true);
	}
}
