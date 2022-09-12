using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColorState
{
    PlayerRed,
    PlayerBlue
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerColorState PlayerCurrentColor = PlayerColorState.PlayerBlue;
    public delegate void Delegate();
    public Delegate Death;

    Rigidbody2D rigidBody2D;
    public float speed;

    string horizontal = "Horizontal";
    string vertical = "Vertical";

    bool ChangeColor = false;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        switch (PlayerCurrentColor)
        {
            case PlayerColorState.PlayerBlue:

                break;
        }

        //Change the type of the projectile that you can fire
        if (Input.GetMouseButtonDown(1) && ChangeColor == false)
        {
            PlayerCurrentColor = PlayerColorState.PlayerRed;
            ChangeColor = true;
        }
        else if (Input.GetMouseButtonDown(1) && ChangeColor == true)
        {
            ChangeColor = false;
            PlayerCurrentColor = PlayerColorState.PlayerBlue;
        }
    }
    void FixedUpdate()
    {
        //Movement of Player
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            rigidBody2D.velocity = new Vector2(speed * Input.GetAxisRaw(horizontal), rigidBody2D.velocity.y);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
        }
        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            rigidBody2D.velocity = new Vector2( rigidBody2D.velocity.x,speed * Input.GetAxisRaw(vertical));
        }
        else
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyRed"))
        {
            Death();
        }
    }
}
