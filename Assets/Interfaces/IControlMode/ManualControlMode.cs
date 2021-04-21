using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControlMode : MonoBehaviour, IControlMode {
    public void Move(Vector2 direction) {
        Debug.Log($"Moving {direction}");
    }
}
