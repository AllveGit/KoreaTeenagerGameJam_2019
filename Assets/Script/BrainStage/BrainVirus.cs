using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainVirus : Virus
{
    bool bScaleUp = false;
    float fScale = 0.6f;
    PlayerBody player = null;
    bool isMove = false;
    List<Vector2> path;
    int nowPath = 0;
    Animator animator = null;
    Rigidbody2D rb2d = null;
    float speed = 1.0f;
    Vector3 velocityPos = new Vector3(0, 0);
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHead").GetComponent<PlayerBody>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
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

        if (dis < 8 && VirusScale > player.Player.scale)
        {
            isMove = true;
            path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
            nowPath = path.Count - 1;
            animator.SetBool("IsAngry", true);
        }
        if(isMove)
        {
            time += Time.deltaTime;
            if (time > 1.0f)
            {
                path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
                nowPath = path.Count - 1;
                time = 0.0f;
            }
            if (nowPath < 0)
            {
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, path[nowPath], Time.fixedDeltaTime);

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
}
