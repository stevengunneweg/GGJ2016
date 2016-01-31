using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class PlayerManager : MonoBehaviour {

    public static bool FreeMode = false;
    public static PlayerManager instance;

    private float _experience = 0;
    private float _expRate = 4;
    private float _expBenchmark = 10;
	private int _maxLevel = 8;

    public int CurrentLevel {get; private set;}

    private Temple _temple;

	// Use this for initialization
	void Start () {
        CurrentLevel = 3;

        instance = this;
        _temple = FindObjectOfType<Temple>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
            AddExperience();
        if (Input.GetKey(KeyCode.KeypadMinus))
            LowerExperience();
    }
	void LevelUp()
    {
        Sound sound = new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "LevelUp");
        Debug.Log("LevelUp: " + CurrentLevel);
		StartCoroutine(LevelTransition(true));
    }
    public void LevelDown()
	{
		Sound sound = new Sound (transform.root.gameObject.GetComponent<AudioSource> (), "SFX/" + "LevelDown");
        Debug.Log("LevelDown: " + CurrentLevel);
		StartCoroutine(LevelTransition(false));
    }
    public void AddExperience()
    {
        _experience += _expRate;
        if (_experience >= _expBenchmark)
            LevelUp();

    }
    public void LowerExperience()
    {
        LevelDown();
    }
    void SetBenchMark()
    {
        _expBenchmark = 10*CurrentLevel;
		if (CurrentLevel == 4) {
			_expBenchmark = 8 * _expRate;
		} else if (CurrentLevel == 3) {
			_expBenchmark = 4 * _expRate;
		} else if (CurrentLevel == 2) {
			_expBenchmark = 2 * _expRate;
		}
	}
	void GameOver() {
		Debug.Log("GAMEOVER!!!!!");
		Application.LoadLevel("LoseScene");
	}
	void GameWon() {
		Debug.Log("YOU WON THE GAME!!");
		Application.LoadLevel("WinScene");
	}
	public float PercentageAmount
    {
       get { return _experience / _expBenchmark; }
	}

	public IEnumerator LevelTransition(bool raise) {
		
		EnemyManager emgr = GameObject.FindObjectOfType<EnemyManager>();
		emgr.PauseSpawning();

		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
		foreach(Enemy enemy in enemies) {
			enemy.Pause();
		}
       
        _experience -= _expBenchmark;
		if (_experience < 0) {
			_experience = 0;
		}
        SetBenchMark();
		
		if (raise) {

            yield return new WaitForSeconds(3);
			CurrentLevel++;
			_temple.RaiseTemple();
			FindObjectOfType<EnemyManager>().WhipeEnemies();
			if (CurrentLevel >= _maxLevel) {
				yield return new WaitForSeconds(2);
				GameWon();
			}

		} else {

            yield return new WaitForSeconds(2);

            try {
                Enemy highestBoy = enemies.OrderByDescending(item => item.transform.position.y).FirstOrDefault();
                if(highestBoy != null)
                    highestBoy.Stampede();
            }finally{
                
            }

            yield return new WaitForSeconds(1f);
			
			CurrentLevel--;
			_temple.LowerTemple();
			FindObjectOfType<EnemyManager>().WhipeEnemies();
			if (CurrentLevel <= 0) {
				yield return new WaitForSeconds(2);
				GameOver();
			}
		}

		emgr.ContinueSpawning();
	}
}
