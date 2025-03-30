
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController2 : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    InputAction movementAction;
    InputAction jumpAction;
    [SerializeField] private Camera mainCamera2;
    private bool isGrounded = true;
    private Rigidbody rb;
    float gravity = -9.81f;
    private float cooldownTime = 1.5f; // Cooldown time for firing projectiles
    private float nextFireTime = 0f; // Time when the player can fire again

    [SerializeField] private GameObject projectilePrefab;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        if (mainCamera2 == null)
    {
        Debug.LogError("Player 2 Camera not assigned! Please assign Camera 2 in the inspector.");
    }

         movementAction = InputSystem.actions.FindAction("Move2");
         jumpAction = InputSystem.actions.FindAction("Jump2");
          
        
    }

    
    void LateUpdate()
    {
        
        Movement();
        Jump();

        if(Input.GetKeyDown(KeyCode.Keypad0))    
        {
            FireProjectile();
        }
        
        
    }
    void Movement()
    {
        Vector2 input = movementAction.ReadValue<Vector2>();
        // Get camera forward and right vectors
        Vector3 cameraForward = mainCamera2.transform.forward;
        Vector3 cameraRight = mainCamera2.transform.right;
        
        // Project vectors onto the horizontal plane by setting Y to 0
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction relative to camera
        Vector3 moveDirection = cameraRight * input.x + cameraForward * input.y;

        // Apply movement
        rb.AddForce(moveDirection * movementSpeed);
    }

    void Jump()
    {
        if (jumpAction.ReadValue<float>() > 0 && isGrounded)
        {   
            //use use newton's 2nd law to calculate the jump force
            
            /*float acceleration = -2 * gravity;
            Vector3 force = new Vector3(0, acceleration * rb.mass,0);
            rb.AddForce(force);
            */     

            
            Vector3 jumpForce = new Vector3(0, Mathf.Sqrt(-2 * gravity * jumpHeight), 0);//calc velo to reach jumphight
            rb.AddForce(jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
        }
    }
    void FireProjectile()
    {
        if (Time.time >= nextFireTime)
        {   Vector3 cameraForward = mainCamera2.transform.forward;
            Vector3 cameraRight = mainCamera2.transform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
          //spawn position in front of player
            Vector3 spawnPosition = transform.position + cameraForward * 2f;

            //cal shoot direction
            Vector3 shootDirection = (cameraForward + cameraRight * 0.5f).normalized;

        
           GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        
        
            MagnusEffect magnusEffect = projectile.GetComponent<MagnusEffect>();
            if (magnusEffect != null)
            {
             magnusEffect.SetInitial(shootDirection);
            }
            
            
            nextFireTime = Time.time + cooldownTime;
        }
    }
    

    //check if the player is on the ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
