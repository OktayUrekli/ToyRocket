using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rocketRB;

    [SerializeField] float thrustingPower;
    [SerializeField] float rotationSpeed;

    [SerializeField] ParticleSystem mainMotorVFX,leftRotMotorVFX,rightRotMotorVFX;



    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrusting();
        Rotating();
    }

    void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space)) // rokete gaz verme 
        {
            rocketRB.AddRelativeForce(transform.up*thrustingPower*Time.deltaTime,ForceMode.VelocityChange);
            mainMotorVFX.Play();
        }
    }

    void Rotating()
    {
        if (Input.GetKey(KeyCode.A)) // sola rotasyon
        {
            rocketRB.freezeRotation = true;
            transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);
            rightRotMotorVFX.Play();
            rocketRB.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.D)) // sa�a rotasyon
        {
            rocketRB.freezeRotation = true;
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
            leftRotMotorVFX.Play();
            rocketRB.freezeRotation = false;
        }
    }
}
