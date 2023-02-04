using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusShift : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform = null;
    [SerializeField] private Transform RoomManager = null;

    private int FocusIndex = 0;     // which game object to focus

    private int min, max = 0;

    // Start is called before the first frame update
    void Start()
    {
        max = RoomManager.transform.childCount;
        Debug.Log(max);
    }

    // Update is called once per frame
    void Update()
    {
        // change focus target
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FocusIndex--;

            // clamp to min value
            if (FocusIndex < min) { FocusIndex = min; }

            Debug.Log(FocusIndex);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            FocusIndex++;

            // clamp to max value
            if (FocusIndex > max) { FocusIndex = max; }

            Debug.Log(FocusIndex);
        }

        // determine focus
        switch (FocusIndex)
        {
            case 0:
                {
                    // change focus
                    GetComponent<CameraFollow2D>().Target = PlayerTransform;
                    break;
                }
            default:
                {
                    // change focus
                    GetComponent<CameraFollow2D>().Target = RoomManager.GetChild(FocusIndex - 1);
                    break;
                }
        }


    }
}