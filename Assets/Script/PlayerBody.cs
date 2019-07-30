using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private int myOrder;
    private Transform head;
    private Vector3 movementVelocity = new Vector3(0, 0, 0);

    [Range(0.0f, 1.0f)]
    public float overTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("PlayerHead").transform;

        List<Transform> bodyList = head.GetComponent<PlayerHead>().bodys;
        for(int i = 0; i < bodyList.Count; i++)
        {
            if(gameObject == bodyList[i].gameObject)
            {
                myOrder = i;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(myOrder == 0)
        {
            if (Vector2.Distance(transform.position, head.position) < 0.3f) return;

            transform.position = Vector3.SmoothDamp(transform.position, head.position,
                ref movementVelocity, overTime);

            //transform.LookAt(head.transform.position);
        }
        else
        {
            List<Transform> bodyList = head.GetComponent<PlayerHead>().bodys;
            if (Vector2.Distance(transform.position, bodyList[myOrder - 1].position) < 0.3f) return;

            transform.position = Vector3.SmoothDamp(transform.position, bodyList[myOrder - 1].position,
                ref movementVelocity, overTime);

            //transform.LookAt(head.transform.position);
        }
    }
}
