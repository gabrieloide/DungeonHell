using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject finalAnimation;
    public GameObject SpawnObject;
    public float healthAmount;
    private float totalHealthAmount;
    private float lastHealtAmount;
    public float invulnerabilityTime;
    public bool canTakeDamage;
    private bool f1, f2, f3, f4; //fases para modificacion de ataques y sprite
    [Space]
    public float fireRateUp;
    public int bulletAmountAtack1;
    public int spiralNumberAtack2;

    Animator animator;
    public string bossState = "NewBossState";

    void Start()
    {
        lastHealtAmount = healthAmount;
        totalHealthAmount = healthAmount;
        canTakeDamage = true;
        f1 = false;
        f2 = false;
        f3 = false;
        f4 = false;

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() && canTakeDamage)
        {
            healthAmount -= FindObjectOfType<PlayerShooting>().damage;
            Destroy(collision.gameObject);
            
            if (healthAmount <= totalHealthAmount / 5 * 4 && !f1)
            {
                f1 = true;
                HardAtacks(fireRateUp, bulletAmountAtack1, spiralNumberAtack2-1);
                animator.SetBool("f1", true);
                animator.SetBool("f2", false);
                animator.SetBool("f3", false);
                animator.SetBool("f4", false);
                animator.SetTrigger("newBossState");
                HardAtacks(0.1f,1,0);
            }
            else if (healthAmount <= totalHealthAmount / 5 * 3 && !f2)
            {
                f2 = true;
                HardAtacks(fireRateUp, bulletAmountAtack1, spiralNumberAtack2);
                f2 = false;
                animator.SetBool("f1", false);
                animator.SetBool("f2", true);
                animator.SetBool("f3", false);
                animator.SetBool("f4", false);
                animator.SetTrigger("newBossState");
                HardAtacks(0.1f,2,1);
            }
            else if (healthAmount <= totalHealthAmount / 5 * 2 && !f3)
            {
                f3 = true;
                HardAtacks(fireRateUp, bulletAmountAtack1, spiralNumberAtack2);
                f3 = false;
                animator.SetBool("f1", false);
                animator.SetBool("f2", false);
                animator.SetBool("f3", true);
                animator.SetBool("f4", false);
                animator.SetTrigger("newBossState");
                HardAtacks(0.2f,2,0);
            }
            else if (healthAmount <= totalHealthAmount / 5 && !f4)
            {
                f4 = true;
                HardAtacks(fireRateUp, bulletAmountAtack1, spiralNumberAtack2);
                f4 = false;
                animator.SetBool("f1", false);
                animator.SetBool("f2", false);
                animator.SetBool("f3", false);
                animator.SetBool("f4", true);
                animator.SetTrigger("newBossState");
                HardAtacks(0.2f,2,1);
            }
        }
    }

    public void HardAtacks(float a, int b, int c) //a(fireRate) b(bulletAmount) c(spiralNumber)
    {
        //Shoot time
        gameObject.GetComponent<BossShoot>().changeAtackTime -= 1.25f;
        gameObject.GetComponent<BossShoot>().timeBetweenAtacks -= 0.3f;
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
