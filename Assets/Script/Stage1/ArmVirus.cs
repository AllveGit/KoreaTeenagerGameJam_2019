using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmVirus : MonoBehaviour
{
    GameObject m_Player;
    bool bMoving = false;
    bool bScaleUp = false;
    float fScale = 1.1f;

    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("PlayerHead");
    }

    void FixedUpdate()
    {
        if (!bScaleUp)
        {
            fScale -= Time.fixedDeltaTime;

            if (fScale < 1f)
            {
                bScaleUp = true;
                fScale = 1f;
            }
        }

        else
        {
            fScale += Time.fixedDeltaTime;

            if (fScale > 1.1f)
            {
                bScaleUp = false;
                fScale = 1.1f;
            }
        }

        transform.localScale = new Vector3(fScale, fScale, 1);

        Vector3 vDir = m_Player.transform.position - this.transform.position;

        float fDist = vDir.magnitude;

        if(fDist < 5f)
        {
            bMoving = true;
        }

        if(bMoving)
        {

        }
    }
}
