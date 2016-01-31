using System;
using UnityEngine;

public class Element : ScriptableObject {

    public string Name;
    public Sprite Image;
    public float Cooldown;
    private float currentCooldown = 0;
    public bool Free = false;

    public void StartCooldown()
    {
        if (Available)
            currentCooldown = Cooldown;
    }
    public void Update()
    {
        if (!Available)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }
    }
    public bool Available {
        get { return Free? true : currentCooldown == 0; }
    }
    public float CurrentCooldown
    {
        get { return currentCooldown; }
    }
    public void ResetCoolDown()
    {
        currentCooldown = 0;
    }

}

