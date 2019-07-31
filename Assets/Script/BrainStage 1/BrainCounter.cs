using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainCounter : MonoBehaviour
{
    public int iBrainItemCnt = 0;
    float ChangeTime = 2f;

    void Start()
    {
        iBrainItemCnt = 0;
    }

    void FixedUpdate()
    {
        if(iBrainItemCnt >= 25)
        {
            ChangeTime -= Time.deltaTime;
            if(ChangeTime <= 0f)
            {
                SceneManager.LoadScene(8);
            }
            FindObjectOfType<FadeManager>().BeginFade(1);
        }
    }
}
