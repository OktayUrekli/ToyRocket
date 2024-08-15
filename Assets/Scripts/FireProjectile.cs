using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;

    DetectCollision detectCollision;

    private void Start()
    {
        detectCollision=gameObject.GetComponent<DetectCollision>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& detectCollision.projectileCount>0) 
        {
            detectCollision.projectileCount--;
            detectCollision.UpdateProjectileCount();
            Instantiate(projectilePrefab,firePoint.position, firePoint.transform.rotation);
        }
    }
}
