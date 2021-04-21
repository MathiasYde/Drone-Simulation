using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementResponse : MonoBehaviour {
    private DroneController controller;
    private Vector3 velocity;
    public float amplitude = 0.001f;
    public float frequency = 0.5f;

    public float rotationMultiplier = 30.0f;
    public float rotationSpeedMultiplier = 1.0f;
    public float audioVolumeSpeedMultiplier = 1.0f;
    private Quaternion desiredRotation;

    private AudioSource audioSource;

    private void Start() {
        controller = controller ?? GetComponent<DroneController>();
        controller = controller ?? transform.parent.GetComponent<DroneController>();

        audioSource = audioSource ?? GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    private void Update() {
        velocity = controller.velocity;

        desiredRotation = Quaternion.Euler(velocity.y * rotationMultiplier, 0, -velocity.x * rotationMultiplier);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, Time.deltaTime * rotationSpeedMultiplier);

        transform.localPosition += new Vector3(0f, Mathf.Sin(Time.realtimeSinceStartup * frequency) * amplitude, 0.0f);

        audioSource.volume = Mathf.Lerp(audioSource.volume, velocity.normalized.magnitude, Time.deltaTime * audioVolumeSpeedMultiplier);
    }

}
