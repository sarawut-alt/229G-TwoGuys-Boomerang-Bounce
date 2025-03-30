using UnityEngine;

public class MagnusEffect : MonoBehaviour
{   
    private Rigidbody rb;
    public Vector3 angularVelocity;
    
    public float lifetime = 1f;
    
    public float projectileVelocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
      Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        ApplyMagnusForce();
    }
    // Apply Magnus force to the rigidbody
    void ApplyMagnusForce()
    {
        
        Vector3 magnusForce = Vector3.Cross(rb.linearVelocity, rb.angularVelocity);
        rb.AddForce(magnusForce);
    }

    public void SetInitial(Vector3 direction)
    {
        rb.linearVelocity = direction * projectileVelocity;
        rb.angularVelocity = angularVelocity;
        
        
        /*
        //get the camera direction
        Vector3 cameradirection = mainCamera.transform.forward;
        cameradirection.y = 0;
        cameradirection.Normalize();
        //set initial velocity
        rb.linearVelocity = cameradirection * projectileVelocity;
        rb.angularVelocity = angularVelocity;
        */
    }
    
}
