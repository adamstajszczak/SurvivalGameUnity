using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour
{
    public int damage = 50;
    public float distance;
    public float maxDistance = 1.5F;
    public Transform system;

    

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Lewy klawisz myszy wywoluje Attack animation
            GetComponent<Animation>().Play("Attack");
           
        }

        //if (mace.GetComponent<Animation>().isPlaying == false)
        //{
        //    mace.GetComponent<Animation>().CrossFade("Idle");
        //}

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    mace.GetComponent<Animation>().CrossFade("Sprint");
        //}

        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    mace.GetComponent<Animation>().CrossFade("Idle");
        //}
    }

    public void attackDamage()
    {
        //Funkcja Attack

        RaycastHit hit;

        if (Physics.Raycast(system.transform.position, system.transform.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;
            if (distance < maxDistance)
            {
                hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}