using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource, SfxSource;
    [Header("---")]
    public AudioClip simpleButtonSound;
    public AudioClip  backButtonSound;
    public AudioClip backgroundMusic;

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play(); 
    }

    public void PlaySfxClip(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
}
