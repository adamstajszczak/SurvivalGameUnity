using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitching : MonoBehaviour {

    public GameObject weapon01;
    public GameObject weapon02;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            SwapWeapons();
	}

    private void SwapWeapons()
    {
        if (weapon01.active == true)
        {
            weapon01.SetActiveRecursively(false);
#pragma warning disable CS0618 // Type or member is obsolete
            weapon02.SetActiveRecursively(true);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            weapon02.SetActiveRecursively(false);
            weapon01.SetActiveRecursively(true);
        }
    }
}
