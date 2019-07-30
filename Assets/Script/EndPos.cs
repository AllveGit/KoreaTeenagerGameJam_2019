using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameObject.Find("FadeManager").GetComponent<Fade>().Dir = 1;
            StartCoroutine(GameObject.Find("FadeManager").GetComponent<Fade>().Fading());
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().timeScale = 0f;
        }
    }
}
