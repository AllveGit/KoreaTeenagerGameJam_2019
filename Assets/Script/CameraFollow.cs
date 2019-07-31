using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3.5f;

    [SerializeField]
    private bool isWater = false;

    public bool bIntro = true;
    public bool bShowStage = false;
    private bool bZoomIn = false;
    public float CameraSize;
    public float CameraOriginSize;

    public GameObject StageEffect;

    private GameObject player;

    public Texture2D DirectingTexture;
    private float Alpha = 0;

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
        CameraOriginSize = Camera.main.orthographicSize;

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

        if(isWater)
        {
            Player obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
            theCamera.orthographicSize *= obj.StageScale;
            CameraOriginSize *= obj.StageScale;
        }
    }

    void Update()
    {
        if (bIntro)
        { 
            float fDist = CameraSize - Camera.main.orthographicSize;
            if (fDist < 0.1f)
            {
                if (!bShowStage)
                {
                    StageEffect.GetComponent<StageFadeText>().bEnabled = true;
                    bShowStage = true;
                }

                Camera.main.orthographicSize = CameraSize;
                StartCoroutine(ZoomIn());
            }

            else
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CameraSize, 0.1f);
            }
        }

        else
        {
            float fDist = Camera.main.orthographicSize - CameraOriginSize;
            if (fDist < 0.1f)
            {
                Camera.main.orthographicSize = CameraOriginSize;
            }
            else
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CameraOriginSize, 0.1f);
            }

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
    }

    void OnGUI()
    {
        Director Ang = FindObjectOfType<Director>();

        if (Ang && Ang.GetDirecting())
        {
            Alpha += Time.deltaTime;

            if (Alpha > 1)
                Alpha = 1;
        }

        else
        {
            Alpha -= Time.deltaTime;

            if (Alpha < 0)
                Alpha = 0;
        }

        int drawDepth = -1000;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, Alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, 100), DirectingTexture);
        GUI.DrawTexture(new Rect(0, Screen.height - 100, Screen.width, Screen.height), DirectingTexture);
    }


    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;
        minBounds = newBounds.bounds.min;
        maxBounds = newBounds.bounds.max;
        FindBound = true;
    }

    IEnumerator ZoomIn()
    {
        if (!bZoomIn)
        {
            bZoomIn = true;
            yield return new WaitForSeconds(2f);
            bIntro = false;
        }
    }
}
