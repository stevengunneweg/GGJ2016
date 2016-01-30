using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
        enemyManager = FindObjectOfType<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Spawn(Vector3 position)
    {
        transform.localPosition = position;
        StartCoroutine(MoveRoutine());

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

    public void Move(Vector3 position){
        Vector3 airPosition = transform.localPosition + (position - transform.localPosition) / 3;
        airPosition += new Vector3(0, 2.0f, 0);
        LeanTween.moveLocal(gameObject, airPosition, 0.10f).setEase(LeanTweenType.easeOutExpo).onComplete = delegate {
            LeanTween.moveLocal(gameObject, position, 0.15f).setEase(LeanTweenType.easeInCubic);
        };
    }

    private IEnumerator MoveRoutine(){
        while(true){
            yield return new WaitForSeconds(1);

            TryMove();
        }
    }
}
