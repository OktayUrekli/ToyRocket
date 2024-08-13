using UnityEngine;

public class MenuCanvasMainManager : MonoBehaviour
{
    AudioSource canvasAS;

    [SerializeField] AudioClip simpleButtonSound, backButtonSound;
    [SerializeField] GameObject[] panels;

    void Start()
    {
        canvasAS = GetComponent<AudioSource>();
        StartingPanelAcitivationFalse();
    }

    void StartingPanelAcitivationFalse()
    {
        foreach (var panel in panels) { panel.SetActive(false);  }
    }

    
    void Update()
    {
        
    }

    public void ClickSimpleButtonSound()
    {
        canvasAS.PlayOneShot(simpleButtonSound);
    }

    public void ClickbackButtonSound()
    {
        canvasAS.PlayOneShot(backButtonSound);
    }
}
