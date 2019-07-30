using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassmateVirus : PlayerHead
{
    public Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        Vector3 pos = targetPos;

        pos.z = 0;
        if (Vector3.Distance(transform.position, pos) < 0.5f) return;

        transform.position = Vector3.MoveTowards(transform.position, pos,
            Time.fixedDeltaTime * speed * player.timeScale);

        Vector3 direction = pos - transform.position;
        direction.z = 0;

        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
