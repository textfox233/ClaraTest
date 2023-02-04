using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusShift : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform = null;
    [SerializeField] private float PlayerModifier = 1.0f;
    [SerializeField] private float DoorwayModifier = 1.0f;
    [SerializeField] private float RoomModifier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FocusPlayer()
    {
        // change zoom
        GetComponent<CameraFollow2D>().DistModifier = PlayerModifier;

        // change target
        GetComponent<CameraFollow2D>().Target = PlayerTransform;
    }

    public void FocusDoorway()
    {
        // change zoom
        GetComponent<CameraFollow2D>().DistModifier = DoorwayModifier;

        // change target
        GetComponent<CameraFollow2D>().Target = PlayerTransform;
    }

    public void FocusRoom(Transform room)
    {
        // change zoom
        GetComponent<CameraFollow2D>().DistModifier = RoomModifier;

        // change target
        GetComponent<CameraFollow2D>().Target = room;
    }
}