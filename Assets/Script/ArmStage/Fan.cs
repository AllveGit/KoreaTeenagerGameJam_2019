using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private float Angle = 0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Angle += Time.fixedDeltaTime * 50;

        if (Angle > 360)
            Angle = 0;

        transform.localEulerAngles = new Vector3(0, 0, Angle);
    }
}
