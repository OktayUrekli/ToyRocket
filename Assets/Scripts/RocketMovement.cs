using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rocketRB;
    AudioSource rocketAS;

    [SerializeField] float thrustingPower;
    [SerializeField] float rotationSpeed;



    [SerializeField] AudioClip motorSFX;

    [SerializeField] ParticleSystem mainMotorVFX,leftRotMotorVFX,rightRotMotorVFX;



    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAS = GetComponent<AudioSource>();
        rocketAS.clip=motorSFX;
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

            if (!rocketAS.isPlaying)
            {
                rocketAS.Play();
            }

            rocketRB.AddRelativeForce(transform.up*thrustingPower*Time.deltaTime,ForceMode.VelocityChange);
            mainMotorVFX.Play();
            gameObject.GetComponent<DetectCollision>().fuelAmount-=0.1f;
            gameObject.GetComponent<DetectCollision>().UpdateFuelBar();
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
        else if (Input.GetKey(KeyCode.D)) // saða rotasyon
        {
            rocketRB.freezeRotation = true;
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
            leftRotMotorVFX.Play();
            rocketRB.freezeRotation = false;
        }
    }
}
