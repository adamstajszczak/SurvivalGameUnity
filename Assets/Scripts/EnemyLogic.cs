using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public int health = 100;

    private void Update()
    {
        if (health <= 0)
        {
            dead();
        }
    }

    private void dead()
    {
        Destroy(gameObject);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
    }
}
