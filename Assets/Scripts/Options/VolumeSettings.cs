using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public Slider global;
    public Slider sfx;
    public Slider music;
    public AudioMixer mixer;

    void Start()
    {
        global.value = PlayerPrefs.GetFloat("Global", 0f);
        sfx.value = PlayerPrefs.GetFloat("SFX", 0f);
        music.value = PlayerPrefs.GetFloat("Music", 0f);
    }
    
    private void Awake()
    {   
        global.onValueChanged.AddListener(ChangeGlobal);
        sfx.onValueChanged.AddListener(ChangeSFX);
        music.onValueChanged.AddListener(ChangeMusic);
    }

    public void ChangeGlobal(float v)
    {
        mixer.SetFloat("VolMaster", v);
        PlayerPrefs.SetFloat("Global", global.value);
    }

    public void ChangeSFX(float v)
    {
        mixer.SetFloat("VolSFX", v);
        PlayerPrefs.SetFloat("SFX", sfx.value);
    }

    public void ChangeMusic(float v)
    {
        mixer.SetFloat("VolMusic", v);
        PlayerPrefs.SetFloat("Music", music.value);
    }
}
