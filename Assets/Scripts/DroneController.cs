using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    private IControlMode controlMode;
    public float speed = 10.0f;

    public float height { get; private set; }

    void Update() {
        (bool success, RaycastHit hit) = Raycast();
        if (success) {
            height = hit.distance;
        }


    }

    void Move(Vector2 direction) {
        direction = direction.normalized;
        direction *= speed;
        direction *= Time.deltaTime;
        controlMode.Move(direction);
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
