using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPos : MonoBehaviour
{
    bool bChangeScene = false;
    public int SceneNum = 0;
    private float ChangeTime = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (bChangeScene)
        {
            ChangeTime -= Time.deltaTime;

            if (ChangeTime <= 0)
            {
                ChangeTime = 0;
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                MainGame.instance.playerScale = player.scale;
                MainGame.instance.playerBodyCount = player.bodys.Count;
                SceneManager.LoadScene(SceneNum);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameObject.Find("FadeManager").GetComponent<Fade>().Dir = 1;
            StartCoroutine(GameObject.Find("FadeManager").GetComponent<Fade>().Fading());
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().timeScale = 0f;
            bChangeScene = true;
        }
    }
}
