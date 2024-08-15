using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    AudioSource playerAudioSource;
    
    [Header("Panels")]
    [SerializeField] GameObject levelFinishedPanel;
    [SerializeField] GameObject rocketCrashedPanel;
    [SerializeField] GameObject fuelOverPanel;

    [Header("SFX & VFX")]
    [SerializeField] ParticleSystem crashObstacleVFX;
    [SerializeField] AudioClip collectProcejtile, collectFuel,collectFood,crashSFX;
    
    [Header("UI Elements")]
    [SerializeField] Image fuelBar;
    [SerializeField] TextMeshProUGUI foodCountTxt,projectileCountTxt;

    [Header("Collectible objects counts")]
    public int projectileCount;
    public float fuelAmount;
    
    int foodCount;


    void Start()
    {
        PanelActiveFalse();
        FirstAssignment();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void PanelActiveFalse()
    {
        levelFinishedPanel.SetActive(false);
        rocketCrashedPanel.SetActive(false);
        fuelOverPanel.SetActive(false);
    }

    void FirstAssignment()
    {
        foodCount = 0;
        projectileCount = 0;
        fuelAmount = 100;

        foodCountTxt.text = foodCount.ToString();
        projectileCountTxt.text = projectileCount.ToString();
        fuelBar.fillAmount= fuelAmount/100f;
    }

    void UpdateFoodCount()
    {
        foodCountTxt.text = foodCount.ToString();
    }

    public void UpdateProjectileCount()
    {  
        projectileCountTxt.text = projectileCount.ToString();
    }

    public void UpdateFuelBar()
    {
        if (fuelAmount<=100 && fuelAmount > 0)
        {
            fuelBar.fillAmount = fuelAmount / 100f;
        }
        else if (fuelAmount>100)
        {
            fuelAmount = 100;
            fuelBar.fillAmount = fuelAmount / 100f;
        }
        else if (fuelAmount<=0)
        {
            Time.timeScale = 0;
            fuelOverPanel.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            projectileCount+=5;
            playerAudioSource.PlayOneShot(collectProcejtile);
            UpdateProjectileCount();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Fuel"))
        {
            fuelAmount += 20f;
            playerAudioSource.PlayOneShot(collectFuel);
            UpdateFuelBar();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Food"))
        {
            foodCount+=25;
            UpdateFoodCount();
            playerAudioSource.PlayOneShot(collectFood);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // crash paneli açýlacak
            crashObstacleVFX.Play();
            playerAudioSource.PlayOneShot(crashSFX);

            Time.timeScale = 0;
            rocketCrashedPanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            levelFinishedPanel.SetActive(true);
        }
    }
}
