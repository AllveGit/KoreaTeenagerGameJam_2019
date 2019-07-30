using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> bodys = new List<Transform>();

    public float timeScale = 1.0f;

    public float scale = 1.0f;

    private PlayerHead head = null;

    public PlayerHead Head { get => head; set => head = value; }

    // Start is called before the first frame update
    void Start()
    {
        Head = bodys[0].GetComponent<PlayerHead>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void FixedUpdate()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        Head.PlayerMove(mouse);
    }

}
