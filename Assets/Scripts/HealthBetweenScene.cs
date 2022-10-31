using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthBetweenScene : MonoBehaviour
{
    public float healthPlayer;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            healthPlayer = 10;

        healthPlayer = FindObjectOfType<PlayerLife>().healthAmount;
    }
}
