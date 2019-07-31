using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public List<Transform> bodys = new List<Transform>();

    public float timeScale = 1.0f;

    public float scale = 1.0f;

    float fAccel = 0;

    [SerializeField]
    private float stageScale = 1.0f;

    private PlayerBody head = null;

    public PlayerBody Head { get => head; set => head = value; }
    public bool IsDie { get => isDie; set => isDie = value; }
    public float StageScale { get => stageScale; set => stageScale = value; }

    private bool isDie = false;

    public float speed = 0.0f;

    [SerializeField]
    private GameObject body = null;
    

    private int sizeUpCount = 0;

    private float angle = 0.0f;

    public AudioClip audio = null;

    public AudioClip dieAudio = null;

    private void Awake()
    {
        if (gameObject.tag != "Player") return;

        for (int i = 0; i < MainGame.instance.playerBodyCount; i++)
        {
            bodys.Add(Instantiate(body, transform).transform);
        }

        var obj = bodys[1];
        bodys[1] = bodys[bodys.Count - 1];
        bodys[bodys.Count - 1] = obj;

        Head = bodys[0].GetComponent<PlayerBody>();

        scale = MainGame.instance.playerScale;

        scale *= stageScale;

        if(UIManager.instance)
            UIManager.instance.IsEnd = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       
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

        //angle = transform.localEulerAngles.z;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        angle += h * Time.fixedDeltaTime * 300;

        speed += v * Time.fixedDeltaTime * fAccel;

        if (speed > 9)
            speed = 9;

        if (v == 0)
        {
            speed -= 10 * Time.fixedDeltaTime;
            fAccel = 0;
        }

        else
        {
            fAccel += Time.fixedDeltaTime * 8;
        }

        if (speed < 0)
            speed = 0;

        bodys[0].transform.localEulerAngles = new Vector3(0, 0, -angle);

        if (angle < 0)
            angle = 360 + angle;

        else if (angle > 360)
            angle = angle - 360;


        Vector3 movePos = Head.transform.position + Head.transform.up * Time.deltaTime * timeScale * speed;
        Head.rb2d.MovePosition(movePos);
        //Head.PlayerMove(mouse);
    }

    public IEnumerator PlayerDie()
    {
        float time = 0.0f;
        SoundManager.instance.PlayEffect(dieAudio);
        while(time < 2.0f)
        {
            for (int i = 0; i < bodys.Count; i++)
            {
                SpriteRenderer spRenderer = bodys[i].GetComponent<SpriteRenderer>();

                spRenderer.color -= new Color(0, 0, 0, 0.05f);
            }
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

    public void SizeUp()
    {
        scale += 0.02f;

        sizeUpCount++;

        if (audio)
            SoundManager.instance.PlayEffect(audio);
        if (sizeUpCount % 10 == 0)
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
