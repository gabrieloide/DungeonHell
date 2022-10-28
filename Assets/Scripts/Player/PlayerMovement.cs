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
    public float speedSlowOnClick;
    public GameObject Weapon;
    bool walking = false;

    Animator animator;

    string horizontal = "Horizontal";
    string vertical = "Vertical";
    string isMoving = "isMoving";

    bool ChangeColor = false;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        walking = false;
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

        //Slow speed shooting
        if (Input.GetMouseButtonDown(0))
        {
            speed -= speedSlowOnClick;
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed += speedSlowOnClick;
        }
    }
    void FixedUpdate()
    {
        //Movement of Player
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            rigidBody2D.velocity = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical)).normalized * speed;
            walking = true;

        }
        else
        {
            rigidBody2D.velocity = Vector2.zero;
        }
        animator.SetBool(isMoving, walking);
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        Vector3.Normalize(transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyRed"))
        {
            Death();
        }
    }
}
