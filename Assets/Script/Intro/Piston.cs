using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Vector2 TargetPos;
    public float fSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Dir = TargetPos - (Vector2)transform.position;
        Dir.Normalize();

        (Vector2)transform.position += Dir * Time.deltaTime * fSpeed;
    }
}
