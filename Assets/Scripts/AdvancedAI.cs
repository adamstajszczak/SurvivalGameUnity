using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AdvancedAI : MonoBehaviour {
	public float distance;
	public Transform Target;
	public float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	public float damping = 6.0f;
	public float attackReapatTime = 1f;

	public float TheDammage = 40f; 
	
	private float attackTime;
	
	public CharacterController controller;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;

	public void Start()
	{
		attackTime = Time.time;
	}

    

	// Update is called once per frame
	public void Update () {
		distance = Vector3.Distance(Target.position, transform.position);

		if (distance < lookAtDistance)
		{
			LookAt();
		}
		if (distance > lookAtDistance)
			GetComponent<Renderer>().material.color = Color.green;
		if (distance < attackRange)
		{
			attack();
		}
		
		else if (distance < chaseRange)
		{
			chase();
		}
	}

	public void LookAt()
	{
		GetComponent<Renderer>().material.color = Color.yellow;
		Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	public void chase()
	{
		GetComponent<Renderer>().material.color = Color.red;

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	public void attack()
	{
		if (Time.time > attackTime)
		{
			Target.SendMessage("ApplyDamage", TheDammage);
			Debug.Log("The enemy has attacked");
			attackTime = Time.time + attackReapatTime;
		}
	}

	public void ApplyDamage()
	{
		chaseRange += 20;
		moveSpeed += 3;
		lookAtDistance += 30;
	}
}
