using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private int damage = 200;

    private void OnTriggerEnter2D(Collider2D collider)
    {
            Health2 health = collider.GetComponent<Health2>();
            health.Damage(damage);
    }
    
}