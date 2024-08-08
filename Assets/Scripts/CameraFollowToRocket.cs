using UnityEngine;

public class CameraFollowToRocket : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    [SerializeField] Vector3 followOffset;


    private void LateUpdate()
    {
        transform.position = rocket.transform.position + followOffset;
    }
}
