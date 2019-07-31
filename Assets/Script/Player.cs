using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> bodys = new List<Transform>();

    public float timeScale = 1.0f;

    public float scale = 1.0f;

    [SerializeField]
    private float stageScale = 1.0f;

    private PlayerBody head = null;

    public PlayerBody Head { get => head; set => head = value; }
    public bool IsDie { get => isDie; set => isDie = value; }
    public float StageScale { get => stageScale; set => stageScale = value; }

    private bool isDie = false;

    public float speed = 3.0f;

    [SerializeField]
    private GameObject body = null;

    private int sizeUpCount = 0;

    private float angle = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Head = bodys[0].GetComponent<PlayerBody>();
        scale *= stageScale;
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

        float h = Input.GetAxis("Horizontal");
        angle += h * Time.fixedDeltaTime * 100;
        
        //Head.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        
        Vector3 targetPos = Head.transform.position + direction * 10;
        targetPos = Vector3.MoveTowards(Head.transform.position, targetPos, Time.fixedDeltaTime * scale * speed);
        //Head.transform.position = targetPos;
        Head.PlayerMove(mouse);
    }

    public IEnumerator PlayerDie()
    {
        float time = 0.0f;
        while(time < 1.0f)
        {
            for (int i = 0; i < bodys.Count; i++)
            {
                SpriteRenderer spRenderer = bodys[i].GetComponent<SpriteRenderer>();

                spRenderer.color -= new Color(0, 0, 0, 0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

    public void SizeUp()
    {
        scale += 0.05f;

        sizeUpCount++;

        if (sizeUpCount % 2 == 0)
        {
            GameObject obj = Instantiate(body, transform);

            bodys.Add(obj.transform);
            var temp = bodys[bodys.Count - 1];
            bodys[bodys.Count - 1].position = bodys[bodys.Count - 2].position;
            bodys[bodys.Count - 1] = bodys[bodys.Count - 2];
            bodys[bodys.Count - 2] = temp;
        }
    }
}
