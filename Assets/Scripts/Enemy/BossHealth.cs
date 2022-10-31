using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    public GameObject finalAnimation;
    public GameObject SpawnObject;
    public float healthAmount;
    private float totalHealthAmount;
    private float lastHealtAmount;
    public float invulnerabilityTime;
    public bool canTakeDamage;
    private bool f1, f2, f3, f4; //fases para modificacion de ataques y sprite

    Animator animator;

    void Start()
    {
        lastHealtAmount = healthAmount;
        totalHealthAmount = healthAmount;
        canTakeDamage = true;
        f1 = true;
        f2 = true;
        f3 = true;
        f4 = true;

        animator = GetComponentInParent<Animator>();

        Debug.Log(totalHealthAmount / 5 * 4);
        Debug.Log(totalHealthAmount / 5 * 3);
        Debug.Log(totalHealthAmount / 5 * 2);
        Debug.Log(totalHealthAmount / 5);
    }

    void Update()
    {
        
        if (lastHealtAmount > healthAmount)
        {
            StartCoroutine(takeDamage());
            lastHealtAmount = healthAmount;
        }
    }
    private void FixedUpdate()
    {
        if (healthAmount <= 0)
        {
            finalAnimation.SetActive(true);
            SpawnObject.SetActive(false);
            GameManager.instance.GameFinish();
            Destroy(boss);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() && canTakeDamage)
        {
            healthAmount -= FindObjectOfType<PlayerShooting>().damage;
            Destroy(collision);
            StartCoroutine(takeDamage());
            
            if (healthAmount <= totalHealthAmount / 5 * 4 && f1)
            {
                f1 = false;
                HardAtacks(0.1f,1,0);
            }
            else if (healthAmount <= totalHealthAmount / 5 * 3 && f2)
            {
                f2 = false;
                HardAtacks(0.1f,2,1);
            }
            else if (healthAmount <= totalHealthAmount / 5 * 2 && f3)
            {
                f3 = false;
                HardAtacks(0.2f,2,0);
            }
            else if (healthAmount <= totalHealthAmount / 5 && f4)
            {
                f4 = false;
                HardAtacks(0.2f,2,1);
            }
        }
    }

    public void HardAtacks(float a, int b, int c) //a(fireRate) b(bulletAmount) c(spiralNumber)
    {
        //Shoot time
        gameObject.GetComponent<BossShoot>().changeAtackTime -= 1;
        gameObject.GetComponent<BossShoot>().timeBetweenAtacks -= 0.2f;
        //Atack 0
        gameObject.GetComponent<BossAtack0>().fireRate -= a;
        //Atack 1
        gameObject.GetComponent<BossAtack1>().fireRate -= a;
        gameObject.GetComponent<BossAtack1>().bulletsAmount += b;
        //Atack 2
        gameObject.GetComponent<BossAtack2>().spiralNumber += c;
    }

    IEnumerator takeDamage()
    {
        AudioManager.instance.PlaySoundEnemyHurt();
        canTakeDamage = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
    }
}
