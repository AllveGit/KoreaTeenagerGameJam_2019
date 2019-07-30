using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public List<Transform> bodys = new List<Transform>();
    Vector3 moveVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pos);

        mousePos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, 0.1f);
    }
}
