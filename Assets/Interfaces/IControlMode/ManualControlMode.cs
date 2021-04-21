﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControlMode : MonoBehaviour, IControlMode {
    public void Move(Vector2 direction) {
        transform.position += direction.plane();
    }
}
