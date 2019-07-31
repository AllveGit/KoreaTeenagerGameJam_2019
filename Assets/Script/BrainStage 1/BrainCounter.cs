using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrainCounter : MonoBehaviour
{
    public int iBrainItemCnt = 0;
    float ChangeTime = 2f;
    GameObject TargetText;

    void Start()
    {
        iBrainItemCnt = 0;
        TargetText = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(2).gameObject;
    }

    void FixedUpdate()
    {
        TargetText.GetComponent<Text>().text = iBrainItemCnt.ToString() + " / " + "25";

        if (iBrainItemCnt >= 25)
        {
            ChangeTime -= Time.deltaTime;
            if(ChangeTime <= 0f)
            {
                SceneManager.LoadScene(9);
            }
            FindObjectOfType<FadeManager>().BeginFade(1);
        }
    }
}
