using UnityEngine;
using System.Collections;

public class EarthSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
        foreach(Rigidbody body in GetComponentsInChildren<Rigidbody>()){
            body.AddForce(new Vector3(0, 1, 0), ForceMode.Acceleration);
        }
		enemy.Kill(true);
	}
}
