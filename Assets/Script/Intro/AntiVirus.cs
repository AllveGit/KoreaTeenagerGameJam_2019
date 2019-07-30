using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirus : MonoBehaviour
{
    float fSpeed = 0.1f;
    float fAccel = 3;
    private GameObject m_Player;

    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("PlayerHead");
    }

    void FixedUpdate()
    {
        Vector3 vDir = m_Player.transform.position - this.transform.position;

        float fDist = vDir.magnitude;

        if(fDist < 5f)
        {
            fSpeed += fAccel * Time.fixedDeltaTime;
            fAccel += 1 * Time.fixedDeltaTime;

            transform.position += vDir * Time.fixedDeltaTime * fSpeed; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.layer == 8 || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
