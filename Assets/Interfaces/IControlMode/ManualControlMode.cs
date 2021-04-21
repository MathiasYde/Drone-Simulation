using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControlMode : MonoBehaviour, IControlMode {
    private float desiredRotation = 0.0f;
    private Vector3 desiredPosition;

    private DroneController controller;

    private void Awake() {
        controller ??= GetComponent<DroneController>();
        controller ??= transform.parent.GetComponent<DroneController>();
    }

    private void Start() {
        desiredPosition = transform.position;
    }

    public void Move(Vector2 direction) {
        desiredPosition += direction.plane();
    }

    public void Elevate(float elevation) {
        desiredPosition += new Vector3(0f, elevation, 0f);
    }

    public void Rotate(float rotation) {
        desiredRotation += rotation;
    }

    private void Update() {
        transform.rotation = Quaternion.Euler(0f, Mathf.Lerp(transform.rotation.y, desiredRotation, Time.deltaTime * controller.rotateSpeed), 0f);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * controller.moveSpeed);
    }
}
