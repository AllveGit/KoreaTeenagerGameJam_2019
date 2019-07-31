using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainVirus : Virus
{
    bool bAngry = false;
    bool bScaleUp = false;
    float fScale = 0.6f;
    PlayerBody player = null;
    bool isMove = false;
    bool isHomingMove = false;
    List<Vector2> path;
    int nowPath = 0;
    Animator animator = null;
    Rigidbody2D rb2d = null;
    float speed = 1.0f;
    Vector3 velocityPos = new Vector3(0, 0);
    float time = 0.0f;

    Vector3 m_vDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHead").GetComponent<PlayerBody>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        transform.localScale *= base.VirusScale;
    }
    

    private void FixedUpdate()
    {
        if (!bScaleUp)
        {
            fScale -= Time.fixedDeltaTime;

            if (fScale < 0.5)
            {
                bScaleUp = true;
                fScale = 0.5f;
            }
        }

        else
        {
            fScale += Time.fixedDeltaTime;

            if (fScale > 0.6f)
            {
                bScaleUp = false;
                fScale = 0.6f;
            }
        }

        transform.localScale = new Vector3(fScale, fScale, 1);

        float dis = Vector3.Distance(player.transform.position, transform.position);

        if(dis < 8)
        {
            if(!isHomingMove)
            {
                m_vDir = player.transform.position - this.transform.position;
                m_vDir.Normalize();
            }

            isHomingMove = true;
        }

        else if (dis < 15 && VirusScale > player.Player.scale && isMove == false)
        {
            isMove = true;
            path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
            nowPath = path.Count - 1;
        }

        else
        {
            isHomingMove = false;
        }

        animator.SetBool("IsAngry", isHomingMove);

        if (isHomingMove)
        {
            //Vector3 vDir = player.transform.position - this.transform.position;
            //vDir.Normalize();

            //float rad = Mathf.Deg2Rad * 1.3f;
            //Vector3 vDir2 = new Vector3(m_vDir.x * Mathf.Cos(rad) - Mathf.Sin(rad) * m_vDir.y, Mathf.Sin(rad) * m_vDir.x + Mathf.Cos(rad) * m_vDir.y, 0);
            //vDir2.Normalize();

            //if (m_vDir.x * vDir.x + m_vDir.y * vDir.y >= m_vDir.x * vDir2.x + m_vDir.y * vDir2.y)
            //{
            //    m_vDir = vDir;
            //}

            //else
            //{
            //    if (player.transform.position.x > this.transform.position.x)
            //    {
            //        Vector3 vDir3 = new Vector3(m_vDir.x * Mathf.Cos(rad) + m_vDir.y * Mathf.Sin(rad), 
            //            m_vDir.x * -Mathf.Sin(rad) + m_vDir.y * Mathf.Cos(rad), 0);
            //        vDir3.Normalize();
            //        m_vDir = vDir3;
            //    }

            //    else
            //    {
            //        m_vDir = vDir2;
            //    }
            //}

            this.transform.position += m_vDir * Time.deltaTime * 3;
        }

        else if(isMove)
        {
            time += Time.deltaTime;
            if (time > 3.0f)
            {
                path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
                nowPath = path.Count - 1;
                time = 0.0f;
            }
            if (nowPath < 0)
            {
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, path[nowPath], Time.fixedDeltaTime * 2.3f);

            if (Vector2.Distance(transform.position, path[nowPath]) < 0.1f)
                nowPath -= 1;
        }
    }

    IEnumerator PlayerMove()
    {
        while(isMove)
        {
            velocityPos = (transform.position - player.transform.position).normalized;

            float dot = Vector3.Dot(velocityPos, transform.up);

            if(dot > 0.7f)
            {
                transform.Rotate(new Vector3(0, 0, 1), -20.0f);
            }
            else if(dot < -0.7f)
            {
                transform.Rotate(new Vector3(0, 0, 1), 20.0f);
            }
            else
            {

            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (isHomingMove)
            {
                isHomingMove = false;
            }
        }
    }
}
