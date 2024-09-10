using UnityEngine;

public class ProjectileMoveForward : MonoBehaviour
{
    [SerializeField] float projectileForce;

    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(gameObject.transform.up*projectileForce,ForceMode.Impulse);
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
