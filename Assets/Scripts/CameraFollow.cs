using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour  {
   
    public Transform Drone;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public 

    // LateUpdate er det samme som update den gør det bare efter update.
    void LateUpdate()
    {
        Vector3 desiredPosition = Drone.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}

