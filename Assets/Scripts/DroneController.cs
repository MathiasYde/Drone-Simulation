using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    public float height { get; private set; }

    void Update() {
        (bool success, RaycastHit hit) = Raycast();
        if (success) {
            height = hit.distance;
        }


    }

    (bool, RaycastHit) Raycast() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
            return (true, hit);
        }
        return (false, hit);
    }
}
