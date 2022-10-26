using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb2D;
    private bool Dash;
    private bool canDash;
    public float speed;
    public float dashTime;
    public float dashColdown;

    void Start()
    {
        canDash = true;
        Dash = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Dash direction
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = - 1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }
        else
        {
            direction.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(DashTime());
        }
        if (Dash)
        {
            rb2D.velocity = direction;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
    IEnumerator DashTime()
    {
        canDash = false;
        Dash = true;
        yield return new WaitForSeconds(dashTime);
        Dash = false;
        yield return new WaitForSeconds(dashColdown);
        canDash = true;
    }
}
