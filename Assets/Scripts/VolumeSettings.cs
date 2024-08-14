using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer myAudioMixer;
    [SerializeField] Slider musicSlider, sfxSlider;


    private void Start()
    {

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }


    public void SetMusicVolume()
    {
        float musicvolume = musicSlider.value;
        myAudioMixer.SetFloat("Music", Mathf.Log10(musicvolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicvolume);
    }

    public void SetSFXVolume()
    {
        float sfxVolume = sfxSlider.value;
        myAudioMixer.SetFloat("Sfx", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        SetSFXVolume();
        SetMusicVolume();
    }
}
