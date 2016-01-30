using UnityEngine;
using System.Collections;

public class LightningSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
		enemy.Kill(true);
	}
}
