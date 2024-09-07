using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioClip fireSFX;

    DetectCollision detectCollision;

    private void Start()
    {
        detectCollision=gameObject.GetComponent<DetectCollision>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& detectCollision.projectileCount>0) 
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(fireSFX);

            detectCollision.projectileCount--;
            detectCollision.UpdateProjectileCount();
            Instantiate(projectilePrefab,firePoint.position, firePoint.transform.rotation);
        }
    }
}
