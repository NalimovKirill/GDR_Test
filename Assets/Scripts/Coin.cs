using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        float animationSpeed = Random.Range(0.2f, 1f);

        _animator = GetComponent<Animator>();

        _animator.speed = animationSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out MoveToClick player))
        {
            
            Destroy(this.gameObject);
            Events.SendCoinCollected();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "SafeZone")
        {
            Destroy(this.gameObject);
        }
    }
}
