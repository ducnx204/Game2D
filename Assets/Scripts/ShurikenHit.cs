using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenHit : MonoBehaviour
{
    public float dame;

    ShurikenPlayer shurikenPlayer;

    public GameObject shurikenExplosion;


    private void Awake()
    {
        shurikenPlayer = GetComponentInParent<ShurikenPlayer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // d?ng phi tiêu và t?o hi?u ?ng n?
            shurikenPlayer.removeShuriken();
            Instantiate(shurikenExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            // tr? máu khi va ch?m
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                // l?y component t? EnemyHealth
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(dame);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // d?ng phi tiêu và t?o hi?u ?ng n?
            shurikenPlayer.removeShuriken();
            Instantiate(shurikenExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            // tr? máu khi va ch?m
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                // l?y component t? EnemyHealth
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDame(dame);
            }
        }
    }
}
