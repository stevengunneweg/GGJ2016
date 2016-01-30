using UnityEngine;
using System.Collections;

public abstract class BaseSpellEffect : MonoBehaviour {
	
	public abstract void ApplyEffectToEnemy(Enemy enemy);
}
