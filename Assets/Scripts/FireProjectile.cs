using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioClip fireSFX;

    CollectProjectile bullet;

    private void Start()
    {
        bullet = GetComponent<CollectProjectile>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& bullet.BulletCount>0) 
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        bullet.BulletCount--;
        bullet.UpdateBulletCountText();
        gameObject.GetComponent<AudioSource>().PlayOneShot(fireSFX);
        Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
    }

    
}
