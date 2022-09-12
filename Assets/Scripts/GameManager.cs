using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        player.Death += PlayerDeath; //Aqui se llama el delegado para que se ejecute la accion correspondiente


    }
    public void PlayerDeath()
    {
        Debug.Log("Died");
    }
}
