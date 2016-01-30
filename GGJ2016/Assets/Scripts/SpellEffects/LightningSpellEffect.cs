using UnityEngine;
using System.Collections;

public class LightningSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
		enemy.Stun(2.0f);
	}
}
