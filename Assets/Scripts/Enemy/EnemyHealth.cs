using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healtAmount;
    public float lasthealtAmount;
    public bool canTakeDamage;
    public static EnemyHealth instance;

    Animator animator;
    public float invulnerabilityTime;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        canTakeDamage = true;
        animator = GetComponent<Animator>();
        lasthealtAmount = healtAmount;
    }
    private void Update()
    {
        if(lasthealtAmount > healtAmount)
        {
            lasthealtAmount = healtAmount;
            StartCoroutine(takeDamage());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && canTakeDamage)
        {
            healtAmount -= 1;
            StartCoroutine(takeDamage());
        }
    }

    public IEnumerator takeDamage()
    {
        canTakeDamage = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
    }

}
