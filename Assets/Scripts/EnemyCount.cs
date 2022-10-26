using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyAmounttext;
    public int enemyAmountnumber;

    void Start()
    {
    }

    void Update()
    {
        enemyAmounttext.text = "Enemies = " + enemyAmountnumber;
        enemyAmountnumber = GameObject.FindGameObjectsWithTag("EnemyBlue").Length + GameObject.FindGameObjectsWithTag("EnemyRed").Length;
    }
}
