using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthBetweenScene : MonoBehaviour
{
    public float healthPlayer;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        healthPlayer = FindObjectOfType<PlayerLife>().healthAmount;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            healthPlayer = 10;
    }
}
