using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float speed;
    float nextAngle = 90;
    public bool rotate = false;

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            transform.Rotate(0, 0, speed);

    }
}
