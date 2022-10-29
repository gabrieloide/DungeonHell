using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panelPauseBackground;
    public bool IsPaused;

    private void Start()
    {
        IsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !GameObject.Find("Player").GetComponent<PlayerLife>().inOver)
        {
            if (IsPaused && !GameObject.Find("Player").GetComponent<PlayerLife>().inOver)
            {
                Resume();
            }
            else if(!IsPaused && !GameObject.Find("Player").GetComponent<PlayerLife>().inOver)
            {
                Pause();
                panelPause.SetActive(true);
                panel1.SetActive(true);
                panel2.SetActive(false);
                panel3.SetActive(false);
            }
        }
    }

    public void Pause()
    {   
        panelPauseBackground.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void Resume()
    {
        panelPause.SetActive(false);
        panelPauseBackground.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }
}
