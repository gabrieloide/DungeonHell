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
        if (Input.GetKey(KeyCode.W) && !Dash)
        {
            direction.y = 1;
            direction.x = 0;
        }
        if (Input.GetKey(KeyCode.A) && !Dash)
        {
            direction.x = - 1;
            direction.y = 0;
        }
        if (Input.GetKey(KeyCode.S) && !Dash)
        {
            direction.y = -1;
            direction.x = 0;
        }
        if (Input.GetKey(KeyCode.D) && !Dash)
        {
            direction.x = 1;
            direction.y = 0;
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

    private void FixedUpdate()
    {
        
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
