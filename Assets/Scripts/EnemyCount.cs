using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyAmounttext;

    void Start()
    {
    //zzzzzzzzzzzzzzzzzzzzzzzzz
    }
    void Update()
    {
        enemyAmounttext.text = "Enemies = " + GameManager.instance.enemyAmount;
        GameManager.instance.enemyAmount = GameObject.FindGameObjectsWithTag("EnemyBlue").Length + GameObject.FindGameObjectsWithTag("EnemyRed").Length;
    }
}
