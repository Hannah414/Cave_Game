using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player2 player = collider.GetComponent<Player2>();

        if(player)
        {
            player.sword++;
            Destroy(this.gameObject);
        }
    }

}
