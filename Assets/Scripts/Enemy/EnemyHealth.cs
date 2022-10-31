using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float healtAmount;
    public float lasthealtAmount;
    public bool canTakeDamage;
    public static EnemyHealth instance;
    public bool kamikaze;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(kamikaze && collision.CompareTag("Player") && collision.GetComponent<PlayerLife>().canTakeDamage)
        {
            collision.GetComponent<PlayerLife>().healthAmount -= 1;
            Destroy(gameObject);
        }
    }

    public IEnumerator takeDamage()
    {
        canTakeDamage = false;
        //animator.SetTrigger("Hit");
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
    }

}
