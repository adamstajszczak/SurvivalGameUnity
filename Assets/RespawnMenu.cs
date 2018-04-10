using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RespawnMenu : MonoBehaviour {
	
	public  static bool playerIsDead = false;

	// Use this for initialization
	void Start () {
 
	}
 
	// Update is called once per frame
	void Update () 
	{
		if (playerIsDead) 
		{
			//Fix the View
			FirstPersonController s = GetComponent<FirstPersonController>();
			s.enabled = false;

			//Disable Shootingscript
			GameObject.Find("Melee").SetActive(false);
		}
	}

	void OnGUI()
	{
		if (playerIsDead)
		{
			if(GUI.Button(new Rect((float)(Screen.width*0.5-50),(float) (Screen.height*0.5-20),100,40), "Respawn"))
			{
				respawnPlayer();
			}
			if(GUI.Button(new Rect((float)(Screen.width*0.5-50),(float) (Screen.height*0.5-90),100,40), "Menu"))
			{
				Debug.Log("Return to Menu");
			}
		}
	}

	void respawnPlayer()
	{
		Debug.Log ("The Player should respawn");
	}
}
