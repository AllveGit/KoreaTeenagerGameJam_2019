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
            if (Vector2.Distance(transform.position, head.position) < 0.2f) return;

            Vector3 moveVector = Vector3.SmoothDamp(transform.position, head.position,
               ref movementVelocity, overTime) - transform.position;
            transform.position += moveVector * head.GetComponent<PlayerHead>().timeScale;

            Vector3 direction = head.position - transform.position;
            direction.z = 0;

            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            List<Transform> bodyList = head.GetComponent<PlayerHead>().bodys;
            if (Vector2.Distance(transform.position, bodyList[myOrder - 1].position) < 0.2f) return;

            Vector3 moveVector = Vector3.SmoothDamp(transform.position, bodyList[myOrder - 1].position,
                ref movementVelocity, overTime) - transform.position;
            transform.position += moveVector * head.GetComponent<PlayerHead>().timeScale;

            Vector3 direction = bodyList[myOrder - 1].position - transform.position;
            direction.z = 0;

            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, myOrder + 1);
    }
}
