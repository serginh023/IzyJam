using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float speed;
    float nextAngle = 90;
    public bool rotate = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, nextAngle % 360), In(speed) * Time.deltaTime);
            transform.Rotate(0, 0, speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(0, Vector3.up), speed * Time.deltaTime);

        //if (transform.rotation.eulerAngles.z >= nextAngle)
            //nextAngle += 90;


    }

    public static float In(float k)
    {
        return k * k;
    }

    public static float Out(float k)
    {
        if (k < (1f / 2.75f))
        {
            return 7.5625f * k * k;
        }
        else if (k < (2f / 2.75f))
        {
            return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
        }
        else if (k < (2.5f / 2.75f))
        {
            return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
        }
        else
        {
            return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
        }
    }
}
