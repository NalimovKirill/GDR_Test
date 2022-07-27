using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }

        

        if (collision.gameObject.TryGetComponent(out MoveToClick player))
        {
            Destroy(player.gameObject);

            Events.SendPlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "SafeZone")
        {
            Destroy(gameObject);
        }
    }
}
