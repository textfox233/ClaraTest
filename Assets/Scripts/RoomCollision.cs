using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    [SerializeField] bool isDoorway = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log( transform.name + ": Triggered" );

        //GetComponent<CameraFollow2D>().Target = PlayerTransform;

        // get the camera to focus on this room
        transform.parent.GetComponent<RoomManager>().CameraRef.GetComponent<CameraFollow2D>().Target = transform;
    }
}
