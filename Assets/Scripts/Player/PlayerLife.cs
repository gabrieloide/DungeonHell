using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public float healthAmount;
    public float lastHealtAmount;
    public int HealthPoints;
    public bool canTakeDamage;
    public GameObject[] hearts;

    public Color colorAlpha;

    void Start()
    {
        canTakeDamage = true;
        lastHealtAmount = healthAmount;
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;

        if(lastHealtAmount != healthAmount)
        {
            lastHealtAmount = healthAmount;
            StartCoroutine(takeDamage());
        }

        if (healthAmount <= 0)
        {
            Debug.Log("You die");
        }

        //Heart controler
        if(healthAmount < 5)
        {
            hearts[4].SetActive(false);
        }
        else
        {
            hearts[4].SetActive(true);
        }

        if(healthAmount < 4)
        {
            hearts[3].SetActive(false);
        }
        else
        {
            hearts[3].SetActive(true);
        }

        if(healthAmount < 3)
        {
            hearts[2].SetActive(false);
        }
        else
        {
            hearts[2].SetActive(true);
        }

        if(healthAmount < 2)
        {
            hearts[1].SetActive(false);
        }
        else
        {
            hearts[1].SetActive(true);
        }

        if(healthAmount < 1)
        {
            hearts[0].SetActive(false);
        }
        else
        {
            hearts[0].SetActive(true);
        }
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        colorAlpha.a = 0.4f;
        yield return new WaitForSeconds(2f);
        colorAlpha.a = 1f;
        canTakeDamage = true;
    }
}
