using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainVirus : Virus
{
    PlayerBody player = null;
    bool isMove = false;
    List<Vector2> path;
    int nowPath = 0;
    Animator animator = null;
    Rigidbody2D rb2d = null;
    float speed = 1.0f;
    Vector3 velocityPos = new Vector3(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHead").GetComponent<PlayerBody>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
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
            if (nowPath < 0)
            {
                path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
                nowPath = path.Count - 1;
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
