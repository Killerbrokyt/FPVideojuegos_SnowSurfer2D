using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float bootsSpeed = 35f;
    [SerializeField] private ParticleSystem snowEffect;

    SurfaceEffector2D surfaceEffector2D;

    float baseSpeed;
    
    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector2D.speed; // Store the initial speed of the SurfaceEffector2D
    }
    

    // Update is called once per frame
    void Update()
    {
        PlayerTorque();     
        BoostPlayer();
    }

    /// <summary>
    /// Applies torque to the player based on the horizontal input from the Move action.
    /// </summary>
    void PlayerTorque()
    {
        moveInput = moveAction.ReadValue<Vector2>(); 
        if (moveInput.x < 0)
        {
            rb.AddTorque(torqueAmount);
        }
        else if (moveInput.x > 0)
        {
            rb.AddTorque(-torqueAmount);
        }
        
    }

    void BoostPlayer()
    {
        //Increase the player's speed when the up arrow key is pressed
        //Surface Efector speed is increased to bootsSpeed
        if (moveInput.y > 0)
        {     
            surfaceEffector2D.speed = bootsSpeed; 
        }
        else
        {         
            surfaceEffector2D.speed = baseSpeed; // Return to normal speed
        }
    }

    // Detects when the player collides with the floor and plays the snow effect
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {            
            snowEffect.Play();            
        }
    }

    // Detects when the player exits the collision with the floor and stops the snow effect
    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {            
            snowEffect.Stop();
        }
    }


}
