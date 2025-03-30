
using UnityEngine;

public class CameraFollower2 : MonoBehaviour
{
    Vector3 offset;
    public float rotationSpeed;
    public GameObject player;

    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    
    void LateUpdate()
    { 
        
        if (player == null) return;
        // Move camera to follow player
        transform.position = player.transform.position + offset;
        HandleRotation();
        
        
    }


    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.U))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotationSpeed * Time.deltaTime);
            offset = transform.position - player.transform.position;
        }
        if (Input.GetKey(KeyCode.O))
        {
            transform.RotateAround(player.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            offset = transform.position - player.transform.position;
        }
    }
}
