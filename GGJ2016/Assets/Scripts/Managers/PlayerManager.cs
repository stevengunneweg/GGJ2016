using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    private float _experience =0;
    private float _expRate = 1;
    private float _expBenchmark = 100;

    public int CurrentLevel {get; private set;}

    private Temple _temple;

	// Use this for initialization
	void Start () {
        CurrentLevel = 4;

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
        CurrentLevel++;
        Debug.Log("LevelUp: " + CurrentLevel);
        _temple.RaiseTemple();
        _experience = 0;
        SetBenchMark();
        FindObjectOfType<EnemyManager>().WhipeEnemies();
    }
    public void LevelDown()
    {
        CurrentLevel--;
        Debug.Log("LevelDown: " + CurrentLevel);
        if (CurrentLevel <= 0)
            GameOver();
        else {
            _temple.LowerTemple();
            _experience = 0;
            SetBenchMark();
        }
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
        if (_experience >= 0)
        {
            _experience -= _expRate;
            if (_experience < 0)
                LevelDown();
        }
    }
    void SetBenchMark()
    {
        _expBenchmark = 100*CurrentLevel;
    }
    void GameOver()
    {
        Debug.Log("GAMEOVER!!!!!");
    }
    public float PercentageAmount
    {
       get { return _experience / _expBenchmark; }
    }
}
