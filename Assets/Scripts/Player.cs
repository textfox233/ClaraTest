using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform GroundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float superJumpModifier;
    [SerializeField] private float moveSpeed;

    private bool interactKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidBody;
    private int superJumpsRemaining;

    private Transform CurrentRoom;

    // timer to handle interactions - While active script will look for interactions
    private float timer = 0.0f;
    private float interactTimer = .1f; // time in seconds

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
            interactKeyPressed = true;
        }


        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called every physics update
    private void FixedUpdate()
    {
        // Sideways movement
        rigidBody.velocity = new Vector3(horizontalInput * moveSpeed, rigidBody.velocity.y, 0);


        timer += Time.deltaTime;

        // Check if we have reached beyond half a second.
        if (timer > interactTimer)
        {
            // Remove the recorded 2 seconds.
            timer = timer - interactTimer;
        
            Debug.Log("Times Up");

            // time's up, interaction lost
            interactKeyPressed = false;
        }
    }

    // Collision Events //

    private void OnTriggerEnter(Collider other)
    {
        // destroy the object if it's a coin
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnCollisionStay triggered: " + other.name);

        if (other.tag == "Stairs")
        {
            Debug.Log("Stairs here");

            // Stairs movement
            if (interactKeyPressed)
            {
                Debug.Log("Going upstairs");

                // teleport upstairs
                Vector3 NewPos = Vector3.zero;
                NewPos.y = 3.0f;

                Debug.Log("Current Position: " + transform.position);
                Debug.Log("NewPos: " + NewPos);

                // up or down?
                if (other.GetComponent<Stairs>().IsUp())
                {
                    transform.position += NewPos;
                }
                else 
                {
                    transform.position -= NewPos;
                }

                Debug.Log("New Position: " + transform.position);

                interactKeyPressed = false;
            }
        }
    }
}
