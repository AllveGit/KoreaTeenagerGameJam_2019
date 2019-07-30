using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private int myOrder;
    private Transform head;
    private Vector3 movementVelocity = new Vector3(0, 0, 0);
    [SerializeField]
    private Player player = null;

    [Range(0.0f, 1.0f)]
    public float overTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        head = player.head;

        List<Transform> bodyList = player.bodys;
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
        BodyMove();
    }

    private void BodyMove()
    {
        List<Transform> bodyList = player.bodys;
        if (Vector2.Distance(transform.position, bodyList[myOrder - 1].position) < 0.15f * (player.scale)) return;

        Vector3 moveVector = Vector3.SmoothDamp(transform.position, bodyList[myOrder - 1].position,
            ref movementVelocity, overTime * player.scale) - transform.position;
        transform.position += moveVector * player.timeScale;

        Vector3 direction = bodyList[myOrder - 1].position - transform.position;
        direction.z = 0;

        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.position = new Vector3(transform.position.x, transform.position.y, myOrder + 1);
    }
}
