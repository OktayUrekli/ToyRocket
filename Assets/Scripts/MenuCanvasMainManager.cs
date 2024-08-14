using UnityEngine;

public class MenuCanvasMainManager : MonoBehaviour
{

    AudioManager audioManager;

    [SerializeField] GameObject[] panels;

    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        StartingPanelAcitivationFalse();
    }

    void StartingPanelAcitivationFalse()
    {
        foreach (var panel in panels) { panel.SetActive(false);  }
    }

    public void ClickSimpleButtonSound()
    {
        audioManager.PlaySfxClip(audioManager.simpleButtonSound);
    }

    public void ClickbackButtonSound()
    {
        audioManager.PlaySfxClip(audioManager.backButtonSound);
    }
}
