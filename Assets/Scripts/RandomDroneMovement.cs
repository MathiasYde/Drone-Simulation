using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDroneMovement : MonoBehaviour {
    public Vector3 amplitude = Vector3.one / 1000;
    public Vector3 frequency = Vector3.one;
    public Vector3 offset = Vector3.zero;

    public float minrange = -2.0f;
    public float maxrange = 2.0f;

    private void Start() {
        offset.x = Random.Range(minrange, maxrange);
        offset.y = Random.Range(minrange, maxrange);
        offset.z = Random.Range(minrange, maxrange);
    }

    private void Update() {
        Vector3 pos = Vector3.zero;

        pos.x += Mathf.Sin(Time.realtimeSinceStartup * offset.x * frequency.x) * amplitude.x;
        pos.y += Mathf.Sin(Time.realtimeSinceStartup * offset.y * frequency.y) * amplitude.y;
        pos.z += Mathf.Sin(Time.realtimeSinceStartup * offset.z * frequency.z) * amplitude.z;

        transform.localPosition += pos;
    }

}
