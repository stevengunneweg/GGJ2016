using UnityEngine;
using System.Collections;

public class WindSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
		enemy.Kill(true);
	}
}
