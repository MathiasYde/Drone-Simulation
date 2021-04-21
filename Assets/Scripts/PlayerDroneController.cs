using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneController : MonoBehaviour {
    private Controls controls;
    private DroneController controller;

    private void Awake() {
        controls = new Controls();
        controller = controller ?? GetComponent<DroneController>();
    }

    private void Start() {
        controls.Main.Move.performed += ctx => controller.Move(ctx.ReadValue<Vector2>());
        controls.Main.Move.canceled += ctx => controller.Move(Vector2.zero);
        controls.Main.Elevate.performed += ctx => controller.Elevate(ctx.ReadValue<float>());
        controls.Main.Elevate.canceled += ctx => controller.Elevate(0f);

        controls.Main.Rotate.performed += ctx => controller.Rotate(ctx.ReadValue<float>());
        controls.Main.Rotate.canceled += ctx => controller.Rotate(0f);
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}
