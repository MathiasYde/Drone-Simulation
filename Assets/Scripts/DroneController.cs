using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float elevationSpeed = 10.0f;
    public float flipSpeed = 2.5f;

    public float movementSmoothing = 0.05f;

    public float heightElevationThredshold = 0.5f;

    public Vector3 destination { get; private set; } // World space
    public Vector3 velocity { get; private set; }
    public float height { get; private set; }
    public float rotation { get; private set; }
    public Vector3 direction { get; private set; }
    public bool isFlipped { get; private set; }

    private float elevation;
    

    private void Start() {
        destination = (destination != Vector3.zero) ? destination : transform.position;
    }

    private void Update() {
        destination += direction * moveSpeed * Time.deltaTime;
        destination += Vector3.up * elevation * elevationSpeed * Time.deltaTime;

        // Dumb workaround
        Vector3 _vel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref _vel, movementSmoothing);
        velocity = _vel;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(
                transform.rotation.x,// + ((isFlipped) ? 180f : 0f),
                transform.rotation.y,
                transform.rotation.z
            ),
            Time.deltaTime * flipSpeed
        );
        transform.Rotate(0f, rotation * rotateSpeed * Time.deltaTime, 0f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(destination, 0.25f);
    }

    public void Elevate(float elevation) { this.elevation = elevation; }
    public void Move(Vector2 direction) { this.direction = direction.normalized.plane(); }
    public void Rotate(float rotation) { this.rotation = rotation; }
    public void Flip() { isFlipped = !isFlipped; }


    //(bool, RaycastHit) Raycast() {
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity)) {
    //        Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
    //        return (true, hit);
    //    }
    //    return (false, hit);
    //}
}
