using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject m_Player;
    public float CamSpeed;
    public float smoothTime = 0.01f;

    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("PlayerHead");
    }

    void LateUpdate()
    {
        Vector3 Dir = m_Player.transform.position - this.transform.position;
        float fDist = Dir.magnitude;


        Vector3 curDir = new Vector3(0,0,0);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, m_Player.transform.position, ref curDir, smoothTime);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }
}
