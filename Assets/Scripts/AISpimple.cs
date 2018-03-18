using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpimple : MonoBehaviour {

    public float distance;
    public Transform Target;
    public float lookAtDistance = 25.0f;
    public float attackRange = 15.0f;
    public float moveSpeed = 5.0f;
    public float damping = 6.0f;

    

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance(Target.position, transform.position);

        if (distance < lookAtDistance)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            LookAt();
        }
        if (distance > lookAtDistance)
            GetComponent<Renderer>().material.color = Color.green;
        if (distance < attackRange)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Attack();
        }
	}

    private void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void Attack()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

}
