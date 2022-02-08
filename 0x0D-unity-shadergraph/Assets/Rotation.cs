using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float degreesPerSecond = 20;

    private void Update()
    {
        transform.Rotate(new Vector3(degreesPerSecond, 0, 0) * Time.deltaTime);
    }
}
