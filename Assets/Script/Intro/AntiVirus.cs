using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirus : MonoBehaviour
{
    bool bScaleUp = false;
    float fScale = 0.6f;
    float fSpeed = 5f;
    float Angle = 0f;
    Vector3 Dir = new Vector3(0,0,0);
    private GameObject m_Player;

    void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("PlayerHead");
        while(Dir.y == 0 || Dir.x == 0)
            Dir = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0);

        Angle = Random.Range(0f, 360f);
        transform.localEulerAngles = new Vector3(0, 0, Angle);
    }

    void FixedUpdate()
    {
        if(!bScaleUp)
        {
            fScale -= Time.fixedDeltaTime;

            if (fScale < 0.5f)
            {
                bScaleUp = true;
                fScale = 0.5f;
            }
        }

        else
        {
            fScale += Time.fixedDeltaTime;

            if (fScale > 0.6f)
            {
                bScaleUp = false;
                fScale = 0.6f;
            }
        }

        transform.localScale = new Vector3(fScale, fScale, 1);

        Vector3 vDir = m_Player.transform.position - this.transform.position;

        float fDist = vDir.magnitude;

        if (fDist < 2f)
        { 
            
            transform.position += vDir * Time.fixedDeltaTime * fSpeed;
        }

        else
            transform.position += Dir * Time.fixedDeltaTime * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Dir = -Dir;
        }

        if (collision.gameObject.layer == 8)
        {
            Player player = collision.GetComponent<PlayerBody>().Player;

            player.SizeUp();
            Destroy(gameObject);
        }
    }
}
