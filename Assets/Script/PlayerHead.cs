using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public List<Transform> bodys = new List<Transform>();
    Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField]
    private float speed = 3.0f;

    public float timeScale = 1.0f;

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
        Vector3 pos = Input.mousePosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pos);

        mousePos.z = 0;
        if (Vector3.Distance(transform.position, mousePos) < 1.0f) return;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.fixedDeltaTime * speed);

        Vector3 direction = mousePos - transform.position;
        direction.z = 0;

        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
