using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartVirus : Virus
{
    GameObject m_Player;
    bool bMoving = false;
    bool bScaleUp = false;
    float fScale = 1.1f;
    float time = 0.0f;
    List<Vector2> path;
    int nowPath = 0;
    [SerializeField]
    private float speed = 2.0f;

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

        if (fDist < 10f && bMoving == false)
        {
            bMoving = true;
            path = AstarManager.Instance.AstarPathFinder(transform.position, m_Player.transform.position);
            nowPath = path.Count - 1;
        }

        if (bMoving)
        {
            time += Time.deltaTime;
            if (time > 1.0f)
            {
                path = AstarManager.Instance.AstarPathFinder(transform.position, m_Player.transform.position);
                nowPath = path.Count - 1;
                time = 0.0f;
            }
            if (nowPath < 0)
            {
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, path[nowPath], speed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, path[nowPath]) < 0.1f)
                nowPath -= 1;
        }
    }
}
