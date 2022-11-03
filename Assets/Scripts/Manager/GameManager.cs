using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerAlive;
    [SerializeField] PlayerMovement player; 

    [Header("LevelStats")]
    public int enemyAmount;
    public int wavesRemaining;
    public Text textWavesRemaining;
    public GameObject ChangeScene;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void Start()
    {
        playerAlive = true;
        //player.Death += PlayerHurt; //Aqui se llama el delegado para que se ejecute la accion correspondiente

    }
    private void Update()
    {
        enemyAmount = GameObject.FindGameObjectsWithTag("EnemyBlue").Length + GameObject.FindGameObjectsWithTag("EnemyRed").Length;

        wavesRemaining = FindObjectOfType<EnemySpawn>().waves;

        textWavesRemaining.text = "Waves Remaining: " + wavesRemaining.ToString();

        if (!playerAlive)
        {
            StartCoroutine(ShowGameOverScreen());   
        }
        if (enemyAmount == 0 && wavesRemaining == 0)
        {
            ChangeScene.SetActive(true);
        }
    }

    public void GameFinish()
    {
        GameObject.Find("Player").GetComponent<PlayerLife>().inOver = true;
        AudioManager.instance.PlaySoundTreeFalling();
        StartCoroutine(GoCredits());
    }

    public void PlayerHurt()
    {
        PlayerLife.instance.HealthPoints -= 1;
        if (PlayerLife.instance.HealthPoints == 0)
        {
            player.gameObject.SetActive(false);
            playerAlive = false;
        }
    }
    public IEnumerator ShowGameOverScreen()
    {
        FindObjectOfType<UIManager>().animator.SetBool("LevelFinished",true);
        yield return new WaitForSeconds(4);
        FindObjectOfType<UIManager>().GameOverScreen();
    }

    IEnumerator GoCredits()
    {
        yield return new WaitForSeconds(16);
        SceneManagerLoad.instance.credits();
    }
}
