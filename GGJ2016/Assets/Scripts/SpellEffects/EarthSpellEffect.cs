using UnityEngine;
using System.Collections;

public class EarthSpellEffect : BaseSpellEffect {
	public override void ApplyEffectToEnemy(Enemy enemy) {
		enemy.Kill();
	}
}
