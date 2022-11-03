using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public float startHealtAmount;
    public float healthAmount;
    public float lastHealtAmount;
    public int HealthPoints;
    public bool canTakeDamage;
    public float invulnerabilityTime;
    [Space]
    public GameObject panelGameOver;
    public GameObject panelBackground;
    public GameObject panelHUD;
    public bool inOver;

    public GameObject[] hearts;
    public Sprite[] heathSprites;

    Animator animator;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            healthAmount = FindObjectOfType<HealthBetweenScene>().healthPlayer;
            startHealtAmount = FindObjectOfType<HealthBetweenScene>().healthPlayer;
        }

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
            GameOver();
            healthAmount = startHealtAmount;
        }
        if (inOver)
        {
            canTakeDamage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRed") && gameObject.GetComponent<PlayerMovement>().PlayerCurrentColor == PlayerColorState.PlayerRed && canTakeDamage)
        {
            healthAmount -= 1;
        }
        if (collision.CompareTag("EnemyBlue") && gameObject.GetComponent<PlayerMovement>().PlayerCurrentColor == PlayerColorState.PlayerBlue && canTakeDamage)
        {
            healthAmount -= 1;
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
        AudioManager.instance.PlaySoundGameOver();
        inOver = true;
        panelGameOver.SetActive(true);
        panelBackground.SetActive(true);
        panelHUD.SetActive(false);
        FindObjectOfType<MenuPause>().Pause();
    }

    IEnumerator takeDamage()
    {
        AudioManager.instance.PlaySoundPlayerHurt();
        canTakeDamage = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
    }
}
