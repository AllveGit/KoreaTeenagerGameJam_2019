using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : Virus
{
    private int myOrder;
    private Vector3 movementVelocity = new Vector3(0, 0, 0);
    [SerializeField]
    private Player player = null;

    [Range(0.0f, 1.0f)]
    public float overTime = 0.035f;

    private SpriteRenderer spRenderer = null;

    public Player Player { get => player; set => player = value; }


    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        if(Player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        List<Transform> bodyList = Player.bodys;
        for (int i = 0; i < bodyList.Count; i++)
        {
            if (gameObject == bodyList[i].gameObject)
            {
                myOrder = i;
            }
        }
        if (myOrder != 0)
            BodyMove();
    }

    public void PlayerMove(Vector3 targetPos)
    {
        targetPos.z = 0;
        if (Vector3.Distance(transform.position, targetPos) < 0.5f) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPos,
            Time.fixedDeltaTime * Player.speed * Player.timeScale);

        Vector3 direction = targetPos - transform.position;
        direction.z = 0;

        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void BodyMove()
    {
        List<Transform> bodyList = Player.bodys;
        if (Vector2.Distance(transform.position, bodyList[myOrder - 1].position) < 0.15f * (Player.scale)) return;
           
        Vector3 moveVector = Vector3.SmoothDamp(transform.position, bodyList[myOrder - 1].position,
            ref movementVelocity, overTime * Player.scale) - transform.position;
        transform.position += moveVector * Player.timeScale;

        Vector3 direction = bodyList[myOrder - 1].position - transform.position;
        direction.z = 0;

        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.position = new Vector3(transform.position.x, transform.position.y, myOrder + 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && Player.IsDie == false)
        {
            Player.IsDie = true;
            Player.timeScale = 0.0f;
            Player.StartCoroutine(Player.PlayerDie());
        }
    }
}
