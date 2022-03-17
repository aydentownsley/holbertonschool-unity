using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 15.0f;

    // Rotates any gameobject script is applied to at "speed"
    void Update()
    {
        transform.RotateAround(new Vector3(2, 0, 45), Vector3.up, speed * Time.deltaTime);
    }
}
