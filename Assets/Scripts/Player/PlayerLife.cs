using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        } 
    }
    public int HealthPoints = 5;
}
