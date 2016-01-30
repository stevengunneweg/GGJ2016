using System;
using UnityEngine;

public class Element : ScriptableObject {

    public string Name;
    public Sprite Image;
    public float Cooldown;
    private float currentCooldown = 0;

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
            Debug.Log(name + " Cooldown: " + currentCooldown);
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }
    }
    public bool Available {
        get { return currentCooldown == 0; }
    }
    public float CurrentCooldown
    {
        get { return currentCooldown; }
    }

}

