using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public float healthAmount;
    public float lastHealtAmount;
    public int HealthPoints;
    public bool canTakeDamage;

    public GameObject[] hearts;
    public Sprite[] heathSprites;

    public Color colorAlpha;

    void Start()
    {
        canTakeDamage = true;
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;
        lastHealtAmount = healthAmount;
        hearthControlerSprite();
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
            if(lastHealtAmount > healthAmount)
                StartCoroutine(takeDamage());

            lastHealtAmount = healthAmount;

            hearthControlerSprite();
            
        }

        if (healthAmount <= 0)
        {
            Debug.Log("You die");
        }
    }

    public void hearthControlerSprite()
    {
        for (int i = 2; i <= 11; i++)
        {
            if (healthAmount < i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[0];

            else if (healthAmount == i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[1];

            else if (healthAmount > i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[2];
        }
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        colorAlpha.a = 0.4f;
        yield return new WaitForSeconds(1.5f);
        colorAlpha.a = 1f;
        canTakeDamage = true;
    }
}
