using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovement PlayerColor;
    public Image ColorRed, ColorBlue;

    public Text enemyRemaining;
    void Update()
    {
        enemyRemaining.text = GameManager.instance.enemyRemaining.ToString() + "/100";
        //Change the type of the projectile on the screen
        if (PlayerColor.PlayerCurrentColor == PlayerColorState.PlayerRed)
        {
            ColorRed.gameObject.SetActive(true);
        }
        else
        {
            ColorRed.gameObject.SetActive(false);
        }
        if (PlayerColor.PlayerCurrentColor == PlayerColorState.PlayerBlue)
        {
            ColorBlue.gameObject.SetActive(true);
        }
        else
        {
            ColorBlue.gameObject.SetActive(false);
        }
    }
}
