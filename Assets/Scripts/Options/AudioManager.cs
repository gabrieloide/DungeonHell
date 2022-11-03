using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Space]
    public AudioClip musicMainMenu;
    public AudioClip musicGame;
    [Space]
    public AudioClip buttonClick;
    public AudioClip playerShoot;
    public AudioClip playerDash;
    public AudioClip playerHurt;
    public AudioClip changeColor;
    public AudioClip enemyHurt;
    public AudioClip acornExplode;
    public AudioClip gameOver;
    public AudioClip buff;
    public AudioClip treeFalling;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        musicSource.clip = musicMainMenu;
        musicSource.Play(0);
    }

    public void PlaySoundButton()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void PlaySoundPlayerShoot()
    {
        sfxSource.PlayOneShot(playerShoot);
    }

    public void PlaySoundPlayerDash()
    {
        sfxSource.PlayOneShot(playerDash);
    }

    public void PlaySoundPlayerHurt()
    {
        sfxSource.PlayOneShot(playerHurt);
    }

    public void PlaySoundChangeColor()
    {
        sfxSource.PlayOneShot(changeColor);
    }

    public void PlaySoundEnemyHurt()
    {
        sfxSource.PlayOneShot(enemyHurt);
    }

    public void PlaySoundAcornExplode()
    {
        sfxSource.PlayOneShot(acornExplode);
    }

    public void PlaySoundGameOver()
    {
        sfxSource.PlayOneShot(gameOver);
    }
    public void PlaySoundBuff()
    {
        sfxSource.PlayOneShot(buff);
    }
    public void PlaySoundTreeFalling()
    {
        sfxSource.PlayOneShot(treeFalling);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            musicSource.clip = musicMainMenu;
            musicSource.Play(0);
        }
        else if(SceneManager.GetActiveScene().name == "Pre-game")
        {
            musicSource.clip = musicGame;
            musicSource.Play(0);
        }
    }
}
