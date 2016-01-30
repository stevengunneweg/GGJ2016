using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	private float stunTimer;
	private Coroutine moveRoutine;

    private EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
	}
	
    public void Spawn(Vector3 position)
    {
        transform.localPosition = position;
		moveRoutine = StartCoroutine(MoveRoutine());

    }

	public void Stun(float time) {
		stunTimer = time;
		StopCoroutine(moveRoutine);
		moveRoutine = StartCoroutine(MoveRoutine());
	}

    public void Kill(bool gainExperience)
    {
        if(gainExperience){
            PlayerManager.instance.AddExperience();
        }

        Tile tile = enemyManager.GetTileOfEnemy(this);
        if(tile != null){
            tile.enemy = null;
        }

        StopAllCoroutines();
        EnemySpawn.instance.RemoveEnemy(this.gameObject);
    }

    public void TryMove(){
        enemyManager.MoveEnemyToNewPosition(this);
    }

    public void ForceMove(Vector3 position){
        StopCoroutine(moveRoutine);
        Move(position, delegate {
            StartCoroutine(MoveRoutine());
        });
    }

    public void Move(Vector3 position, Action callback = null){
        Vector3 airPosition = transform.localPosition + (position - transform.localPosition) / 3;
        airPosition += new Vector3(0, 2.0f, 0);
        LeanTween.moveLocal(gameObject, transform.localPosition + new Vector3(0, 0.05f, 0), 0.5f).onComplete = delegate {
            LeanTween.moveLocal(gameObject, airPosition, 0.10f).setEase(LeanTweenType.easeOutExpo).onComplete = delegate {
                LeanTween.moveLocal(gameObject, position, 0.15f).setEase(LeanTweenType.easeInCubic).onComplete = callback;
            };
        };

    }
    private IEnumerator Shake(float seconds, float amount){
        float time = 0;

        while(time < seconds){
            Vector3 ownPosition = transform.localPosition;

            yield return new WaitForSeconds(0.01f);

            transform.localPosition = ownPosition + (UnityEngine.Random.insideUnitSphere * amount);
            time += Time.deltaTime;
        }

    }

    private IEnumerator MoveRoutine(){
        while(true){
            if (stunTimer > 0) {
				stunTimer -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			} else {
				yield return new WaitForSeconds(2);
				StartCoroutine(Shake(0.5f, 0.035f));
				yield return new WaitForSeconds(0.4f);
				TryMove();
			}
        }
    }
}
