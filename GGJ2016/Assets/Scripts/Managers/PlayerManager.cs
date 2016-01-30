using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    private float _experience =0;
    private float _expRate = 1;
    private float _expBenchmark = 100;

    private int _currentLevel = 1;

    private Temple _temple;

	// Use this for initialization
	void Start () {
        instance = this;
        _temple = GameObject.Find("Prophet_Temple").GetComponent<Temple>();

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
        _currentLevel++;
        Debug.Log("LevelUp: " + _currentLevel);
        _temple.RaiseTemple();
        _experience = 0;
        SetBenchMark();
    }
    public void LevelDown()
    {
        _currentLevel--;
        Debug.Log("LevelDown: " + _currentLevel);
        if (_currentLevel <= 0)
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
        if (_experience >= 0)
        {
            _experience -= _expRate;
            if (_experience < 0)
                LevelDown();
        }
    }
    void SetBenchMark()
    {
        _expBenchmark = 100*_currentLevel;
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
