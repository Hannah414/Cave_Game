// ATTACK RANGE

// if attack range is triggered 
    //check for health script
        //get health 
        //apply damage
    //else
        //apply damage to object


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange2 : MonoBehaviour
{
    public int damage = 10;
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
           
            if (collider.GetComponent<Health2>() != null)
            {
                Health2 health = collider.GetComponent<Health2>();
                health.Damage(damage);
            }
            else
            {
                if (collider.GetComponent<HittableObjects>() != null)
                {
                HittableObjects objects = collider.GetComponent<HittableObjects>();
                objects.Damage(damage);
                }
            }
    }
}
