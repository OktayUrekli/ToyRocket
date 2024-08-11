using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    AudioSource playerAudioSource;

    [SerializeField] ParticleSystem crashObstacleVFX;
    [SerializeField] AudioClip collectProcejtile, collectFuel,collectFood,crashSFX;


    
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            playerAudioSource.PlayOneShot(collectProcejtile);
            
        }
        if (other.gameObject.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);
            playerAudioSource.PlayOneShot(collectFuel);
        }
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            playerAudioSource.PlayOneShot(collectFood);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            crashObstacleVFX.Play();
            playerAudioSource.PlayOneShot(crashSFX);
        }
    }
}
