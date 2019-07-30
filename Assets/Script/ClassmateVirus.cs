using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassmateVirus : Player
{
    public Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        Head = bodys[0].GetComponent<PlayerHead>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Head.PlayerMove(targetPos);
    }
    
}
