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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHead").GetComponent<PlayerBody>();
        animator = GetComponent<Animator>();
    }
    

    private void FixedUpdate()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);

        if (dis < 8 && VirusScale > player.Player.scale)
        {
            isMove = true;
            //path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
            //nowPath = path.Count - 1;
            //animator.SetBool("IsAngry", true);
        }
        if(isMove)
        {
            Vector3 targetVec3 = player.transform.position - transform.position;

            targetVec3 = targetVec3.normalized;

            float rot_z = Mathf.Atan2(targetVec3.y, targetVec3.x) * Mathf.Rad2Deg;

            if(rot_z - 90 > -90 && rot_z - 90 < 90)
            {
                Quaternion qRot = Quaternion.Euler(0, 0, 30);
                Vector3 direction = qRot * transform.up;

                transform.position += direction;
            }
            else
            {
                Quaternion qRot = Quaternion.Euler(0, 0, -30);
                Vector3 direction = qRot * transform.up;

                transform.position += direction;
            }


            //if (Vector2.Distance(transform.position, path[nowPath]) < 0.3f)
            //    nowPath -= 1;
            //if (nowPath < 0)
            //{
            //    path = AstarManager.Instance.AstarPathFinder(transform.position, player.transform.position);
            //    nowPath = path.Count - 1;
            //}
        }
    }
}
