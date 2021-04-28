using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    [SerializeField] private Transform model;

    public string grabblableTag = "Grabbable";
    public GameObject grabbedItem;

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
    public void Grab() {
        if (grabbedItem != null) {
            grabbedItem.transform.SetParent(null);
            if (grabbedItem.TryGetComponent(out Rigidbody rb)) {
                rb.isKinematic = false;
            }
            grabbedItem = null;
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.5f);
        foreach (Collider collider in colliders) {
            if (collider.transform.tag.Contains(grabblableTag)) {
                grabbedItem = collider.transform.gameObject;
                collider.transform.SetParent(transform);
                collider.transform.localPosition = -Vector3.up;
                
                if (collider.TryGetComponent(out Rigidbody rb)) {
                    rb.isKinematic = true;
                }

                break;
            }
        }
    }
}
