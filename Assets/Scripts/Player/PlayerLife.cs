using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public float startHealtAmount;
    public float healthAmount;
    public float lastHealtAmount;
    public int HealthPoints;
    public bool canTakeDamage;
    [Space]
    public GameObject panelGameOver;
    public GameObject panelBackground;
    public bool inOver;

    public GameObject[] hearts;
    public Sprite[] heathSprites;

    public float invulnerabilityTime;

    Animator animator;

    public Color colorAlpha;

    void Start()
    {
        healthAmount = FindObjectOfType<HealthBetweenScene>().healthPlayer;
        startHealtAmount = FindObjectOfType<HealthBetweenScene>().healthPlayer;
        inOver = false;

        canTakeDamage = true;
        lastHealtAmount = healthAmount;
        hearthControlerSprite();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (!instance)
        {
            instance = this;
        }
    }
    void Update()
    {
        if(lastHealtAmount != healthAmount)
        {
            if(lastHealtAmount > healthAmount)
            {
                StartCoroutine(takeDamage());
            }

            lastHealtAmount = healthAmount;

            hearthControlerSprite();   
        }

        if (healthAmount <= 0)
        {
            inOver = true;
            GameOver();
            healthAmount = startHealtAmount;
        }
    }

    public void hearthControlerSprite()
    {
        for (int i = 2; i <= 11; i++)
        {
            if (healthAmount < i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[0]; //Empty

            else if (healthAmount == i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[1]; //Mid

            else if (healthAmount > i - 2)
                hearts[i / 2 - 1].GetComponent<Image>().sprite = heathSprites[2]; //Full
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        panelBackground.SetActive(true);
        FindObjectOfType<MenuPause>().Pause();
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
    }
}
