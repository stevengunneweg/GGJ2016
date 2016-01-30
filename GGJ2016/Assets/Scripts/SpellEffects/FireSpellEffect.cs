using UnityEngine;
using System.Collections;

public class FireSpellEffect : BaseSpellEffect {
	private GameObject enemyBurn;
	public GameObject enemyBurnPrefab;

    public override void ApplyEffectToEnemy(Enemy enemy)
    {
		Debug.Log("ADDING BURN");
		enemyBurn = Instantiate(enemyBurnPrefab);
		enemyBurn.transform.SetParent(enemy.transform, false);

		StartCoroutine(SetEnemyOnFire(enemy));
    }

	private IEnumerator SetEnemyOnFire(Enemy enemy) {
		yield return new WaitForSeconds(3);
		enemy.Kill();
	}
}
