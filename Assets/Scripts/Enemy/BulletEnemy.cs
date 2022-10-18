using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletEnemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public bool color; //true= Red False= Blue

    Vector2 direction;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        direction = target.position - transform.position;
        Destroy(gameObject, 5);

    }

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Red Bullet
        if (color == true)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerMovement>().PlayerCurrentColor == PlayerColorState.PlayerRed)
            {
                if (collision.GetComponent<PlayerLife>().canTakeDamage)
                {
                    collision.GetComponent<PlayerLife>().healthAmount -= 1;
                }
                Destroy(gameObject);
            }
        }
        //Blue Bullet
        if (color == false)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerMovement>().PlayerCurrentColor == PlayerColorState.PlayerBlue)
            {
                collision.GetComponent<PlayerLife>().healthAmount -= 1;
                Destroy(gameObject);
            }
        }
        

    }

}
