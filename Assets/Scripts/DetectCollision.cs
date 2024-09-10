using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    AudioSource playerAudioSource;

    [Header("UI Elements")]
    [SerializeField] GameObject levelFinishedPanel;
    [SerializeField] GameObject rocketCrashedPanel;    

    [Header("SFX & VFX")]
    [SerializeField] ParticleSystem crashObstacleVFX;
    [SerializeField] AudioClip collectProcejtile, collectFuel,collectFood,crashSFX,finishLevelSFX;


    void Start()
    {
        PanelActiveFalse();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void PanelActiveFalse()
    {
        levelFinishedPanel.SetActive(false);
        rocketCrashedPanel.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Projectile"))
        {
            gameObject.GetComponent<CollectProjectile>().BulletCount += 5;
            gameObject.GetComponent<CollectProjectile>().UpdateBulletCountText();

            playerAudioSource.PlayOneShot(collectProcejtile);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Fuel"))
        {
            gameObject.GetComponent<FuelManager>().FuelAmount+=20;
            gameObject.GetComponent<FuelManager>().UpdateFuelBar();

            playerAudioSource.PlayOneShot(collectFuel);
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Food"))
        {
            gameObject.GetComponent<FoodManager>().FoodCount += 5;
            gameObject.GetComponent<FoodManager>().UpdateFoodCountText();
            
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

            // Time.timeScale = 0;
            rocketCrashedPanel.SetActive(true);

            gameObject.GetComponent<RocketMovement>().enabled = false;
            gameObject.GetComponent<DetectCollision>().enabled = false;
            gameObject.GetComponent<FireProjectile>().enabled = false;

        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            playerAudioSource.PlayOneShot(finishLevelSFX);

            // Time.timeScale = 0;
            levelFinishedPanel.SetActive(true);

            gameObject.GetComponent<RocketMovement>().enabled = false;
            gameObject.GetComponent<DetectCollision>().enabled = false;
            gameObject.GetComponent<FireProjectile>().enabled = false;

        }
    }

}
