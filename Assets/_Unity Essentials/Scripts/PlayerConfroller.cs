using System;
using UnityEngine;
using UnityEngine.InputSystem; 

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    private Rigidbody rb; // Reference to player's Rigidbody.

    private PlayerControis controls;
    private Vector2 moveInput;

    private void OnEnable()
    {
       controls = new PlayerControis();
       controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    
    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        moveInput = controls.Playre.Move.ReadValue<Vector2>();
        
        // Move player based on vertical input.
        //float moveVertical = Input.GetAxis("Vertical");
        //위 기존 방식 대신 아래로 변경
        float moveVertical = moveInput.y;
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        
        // Rotate player based on horizontal input.
        //float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        //위 기존 방식 대신 아래로 변경
        float turn = moveInput.x * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}