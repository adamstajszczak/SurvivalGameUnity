using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

  public int health = 100;

    void ApplyDamage(int TheDammage)
    {
        health -= TheDammage;
        if (health <= 0)
        {
            dead();
        }
    }
    
    private void dead()
    {
        RespawnMenu.playerIsDead = true;
        Debug.Log("PlayerDied!");
    }
}
