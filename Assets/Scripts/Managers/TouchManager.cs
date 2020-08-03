using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public delegate void TouchEventHandler();
    public static event TouchEventHandler TouchEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Ended)
            {
                if (TouchEvent != null)
                    TouchEvent();
            }
        }
    }
}
