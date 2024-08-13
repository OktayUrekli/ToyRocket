using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioMixer myAudioMixer;
    [SerializeField] Slider musicSlider,SfxSlider;

    private void Start()
    {

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    public void SetVolume()
    {
        float musicvolume = musicSlider.value;
        myAudioMixer.SetFloat("Music", Mathf.Log10(musicvolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicvolume);

        float sfxVolume=SfxSlider.value;
        myAudioMixer.SetFloat("Sfx", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        SetVolume();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
