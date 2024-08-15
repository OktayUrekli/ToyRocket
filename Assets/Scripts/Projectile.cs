using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileForce;

    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(gameObject.transform.up*projectileForce,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
