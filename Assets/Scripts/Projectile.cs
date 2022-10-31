using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileColor
{
    ProjectileRed,
    ProjectileBlue
}

public class Projectile : MonoBehaviour
{
    public ProjectileColor projectileColor = ProjectileColor.ProjectileBlue;
    public float speed;
    public float destroyTime;
    Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    public void LaunchProjectile(Vector2 direction)
    {
        rigidBody2D.velocity = direction * speed;
        Destroy(gameObject, destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (projectileColor)
        {
            case ProjectileColor.ProjectileRed:
                if (collision.GetComponent<EnemyHealth>().kamikaze || collision.CompareTag("EnemyRed") && collision.GetComponent<EnemyHealth>().canTakeDamage)
                {
                    collision.GetComponent<EnemyHealth>().healtAmount -= FindObjectOfType<PlayerShooting>().damage;
                    Destroy(gameObject);
                }
                
                else if (collision.gameObject.CompareTag("Player"))
                {
                    return;
                }

                break;
            case ProjectileColor.ProjectileBlue:
                if (collision.GetComponent<EnemyHealth>().kamikaze || collision.CompareTag("EnemyBlue") && collision.GetComponent<EnemyHealth>().canTakeDamage)
                {
                    collision.GetComponent<EnemyHealth>().healtAmount -= FindObjectOfType<PlayerShooting>().damage;
                    Destroy(gameObject);
                }
                else if (collision.CompareTag("Player"))
                {
                    return;
                }
                break;
        }
    }
}
