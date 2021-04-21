using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlMode {
    void Move(Vector2 direction);
    void Elevate(float elevation);
    void Rotate(float rotation);
}
