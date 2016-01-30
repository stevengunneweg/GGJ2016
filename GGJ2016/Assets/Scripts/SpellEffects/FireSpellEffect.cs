using UnityEngine;
using System.Collections;

public class FireSpellEffect : BaseSpellEffect {
    public override void ApplyEffectToEnemy(Enemy enemy)
    {
        enemy.Kill();
    }
}
