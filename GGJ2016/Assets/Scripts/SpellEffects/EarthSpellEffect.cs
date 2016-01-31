using UnityEngine;
using System.Collections;

public class EarthSpellEffect : BaseSpellEffect {
    public GameObject rock;
    Vector3 targetLocation;
    void Start()
    {
        targetLocation = transform.position;
        StartCoroutine(MoveRock());
        Camera.main.transform.parent.GetComponent<CameraShaker>().Shake(0.15f, 0.20f);

        rock.transform.parent.Rotate(new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5)));
    }
	public override void ApplyEffectToEnemy(Enemy enemy) {

        FindObjectOfType<Player>().PlayEarth();

        foreach(Rigidbody body in GetComponentsInChildren<Rigidbody>()){
            body.AddForce(new Vector3(0, 1, 0), ForceMode.Acceleration);
        }
		enemy.Kill(true);
        this.transform.position = targetLocation = enemy.transform.position;
        StopCoroutine(MoveRock());
        StartCoroutine(MoveRock());
    }

    private IEnumerator MoveRock()
    {
        LeanTween.move(rock, targetLocation + new Vector3(0, 2f, 0), 0.1f);
        yield return new WaitForSeconds(1);
        LeanTween.move(rock, targetLocation + new Vector3(0, -5,0), 0.8f);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
