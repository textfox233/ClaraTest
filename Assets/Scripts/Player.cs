using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform GroundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float superJumpModifier;
    [SerializeField] private float moveSpeed;

    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidBody;
    private int superJumpsRemaining;

    private Transform CurrentRoom;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        superJumpsRemaining = 0;
    }

    // Update is called once per frame - keep input checks here (risk missing input in fixed update)
    void Update()
    {
        // Check if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }


        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called every physics update
    private void FixedUpdate()
    {
        // Sideways movement
        rigidBody.velocity = new Vector3(horizontalInput * moveSpeed, rigidBody.velocity.y, 0);

        // should jump be possible? overlapping with anything?
        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            //return;
        }

        // Jumping movement
        else if (jumpKeyPressed)
        {
            float jumpForce = jumpHeight;
            if (superJumpsRemaining > 0) 
            {
                jumpForce *= superJumpModifier;
                superJumpsRemaining--;
            }
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        jumpKeyPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // destroy the object if it's a coin
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }
}
