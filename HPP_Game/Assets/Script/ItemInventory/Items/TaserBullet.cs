using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserBullet : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") return;
        print("Hit");
        if (collision.gameObject.tag == "Enemy")
        {
            ParticleSystem particle =
                PoolManager.Instance.GetPool("TaserParticle", transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            particle.Play();
            PoolManager.Instance.RemovePool(particle.gameObject, 1);
        }
        PoolManager.Instance.RemovePool(gameObject);
    }
}
