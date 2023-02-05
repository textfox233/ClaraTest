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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( transform.name + ": Triggered" );

        // if it's not a doorway, point the camera at itself (the room volume)
        if (!isDoorway)
        {
            GetCameraFocus().FocusRoom(transform);
        }
        // otherwise point the camera at the player
        else
        {
            GetCameraFocus().FocusDoorway();
        }
    }

    private FocusShift GetCameraFocus()
    {
        return transform.parent.GetComponent<Room>().CameraRef.GetComponent<FocusShift>();
    }
}
