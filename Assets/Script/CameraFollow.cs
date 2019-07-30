using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3.5f;

    private GameObject player;

    private BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private BoxCollider2D CollBox;

    Vector3 TargetPos;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    private bool FindBound;

    private static bool CameraExists;

    public GameObject Player { get => player; set => player = value; }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Director");
        if(player == null)
            Player = GameObject.FindGameObjectWithTag("PlayerHead");
        else
        {
            Director director = player.GetComponent<Director>();
            director.StartCoroutine(director.Zoom());
        }

        if (boundBox == null)
        {
            boundBox = GameObject.FindGameObjectWithTag("MapBound").GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
            FindBound = true;
        }

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
        FindBound = false;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        if (boundBox == null)
        {
            boundBox = GameObject.FindGameObjectWithTag("MapBound").GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
            FindBound = true;
        }

        if ((transform.position.x < minBounds.x + halfWidth || transform.position.x > maxBounds.x - halfWidth ||
            transform.position.y < minBounds.y + halfHeight || transform.position.y > maxBounds.y - halfHeight) && FindBound)
        {
            TargetPos = new Vector3(boundBox.bounds.center.x, boundBox.bounds.center.y, -10);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
        }

        else
        {
            FindBound = false;

            TargetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * MoveSpeed);

            float ClampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float ClampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

            transform.position = new Vector3(ClampedX, ClampedY, -10);
        }
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;
        minBounds = newBounds.bounds.min;
        maxBounds = newBounds.bounds.max;
        FindBound = true;
    }
}
