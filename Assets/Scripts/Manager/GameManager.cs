using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerAlive;
    [SerializeField] PlayerMovement player;
    public int enemyRemaining;
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
        player.Death += PlayerHurt; //Aqui se llama el delegado para que se ejecute la accion correspondiente

    }
    private void Update()
    {
        if (!playerAlive)
        {
            StartCoroutine(ShowGameOverScreen());   
        }
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
}
