using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBetweenScene : MonoBehaviour
{
    public float healthPlayer;

    void Update()
    {
        if (!GameObject.Find("Player").GetComponent<PlayerLife>().inOver)
        {
            healthPlayer = FindObjectOfType<PlayerLife>().healthAmount;

        }
    }
}
