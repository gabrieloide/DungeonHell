using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Space]
    public AudioClip music;
    [Space]
    public AudioClip buttonClick;
    public AudioClip playerShoot;
    public AudioClip playerDash;
    public AudioClip playerHurt;
    public AudioClip changeColor;
    public AudioClip enemyHurt;

    private void Start()
    {
        musicSource.clip = music;
        //musicSource.Play(0);
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


}
