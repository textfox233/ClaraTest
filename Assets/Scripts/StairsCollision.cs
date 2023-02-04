using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCollision : MonoBehaviour
{
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
        Debug.Log(transform.name + ": Triggered");

        //// if it's not a doorway, point the camera at it's parent (the room)
        //if (!isDoorway)
        //{
        //    GetCameraFocus().FocusRoom(transform.parent);
        //}
        //// otherwise point the camera at the player
        //else
        //{
        //    GetCameraFocus().FocusDoorway();
        //}
    }
}
