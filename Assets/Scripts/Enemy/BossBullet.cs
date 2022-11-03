using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    private Vector2 moveDirection;
    public float speed;

    private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
 
    void FixedUpdate()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void setMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerLife>().canTakeDamage)
            {
                collision.GetComponent<PlayerLife>().healthAmount -= 1;
            }

            Destroy(gameObject);
        }
    }
}
