using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Transform TargetPos;
    public float fSpeed;
    bool bPistolEnd = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bPistolEnd)
        {
            Vector3 Dir = TargetPos.position - this.transform.position;
            float fDist = Dir.magnitude;
            Dir.Normalize();

            if (fDist < 1f)
            {
                this.transform.position = TargetPos.position;
                bPistolEnd = true; 
            }

            else
                this.transform.position += Dir * Time.deltaTime * fSpeed;
        }
    }
}
