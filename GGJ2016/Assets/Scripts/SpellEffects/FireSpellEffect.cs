using UnityEngine;
using System.Collections;

public class FireSpellEffect : BaseSpellEffect {
	private GameObject enemyBurn;
	public GameObject enemyBurnPrefab;
    private ParticleSystem fireBlast_partcileSys;
    public GameObject fireball;

    void Start()
    {
        fireBlast_partcileSys = this.GetComponent<ParticleSystem>();
        LeanTween.move(fireball, this.transform.position, 0.8f).onComplete += BallHit;
    }

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
    private void BallHit()
    {
        Camera.main.transform.parent.GetComponent<CameraShaker>().Shake(0.20f, 0.25f);

        fireBlast_partcileSys.Play();
           Destroy(fireball);
        StartCoroutine(KillSelf());
    }
    private IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
