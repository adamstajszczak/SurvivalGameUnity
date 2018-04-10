using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public int health = 100;



    private void dead()
    {
        Destroy(gameObject);
    }

    void ApplyDamage(int TheDammage)
    {
        health -= TheDammage;
        if (health <= 0)
        {
            dead();
        }
    }
}
