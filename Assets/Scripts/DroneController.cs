using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    private IControlMode controlMode;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;

    public Vector3 velocity { get; private set; }

    public float height { get; private set; }

    // for new input system
    private float rotation = 0.0f;
    private float elevation = 0.0f;

    private void Awake() {
        controlMode = controlMode ?? GetComponent<IControlMode>();
    }

    private void Update() {
        (bool success, RaycastHit hit) = Raycast();
        if (success) {
            height = hit.distance;
        }

        controlMode.Move(velocity * Time.deltaTime);
        controlMode.Rotate(rotation);
        controlMode.Elevate(elevation);
    }

    public void Elevate(float elevation) {
        this.elevation = elevation;
    }

    public void Move(Vector2 direction) {
        velocity = direction.normalized;
    }

    public void Rotate(float rotation) {
        this.rotation = rotation;
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
