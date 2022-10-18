using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProjectile : MonoBehaviour
{
    string change = "Change";
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger(change);
        }
    }
}
