using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;

    int iCurNum = 1;

    float CutTime = 3f;

    private void Awake()
    {
        Image1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Image2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Image3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Image4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < iCurNum; i++)
        {
            float Alpha;

            switch (i)
            {
                case 0:
                    Alpha = Image1.GetComponent<SpriteRenderer>().color.a;
                    Alpha += Time.deltaTime * 2f;

                    if (Alpha > 1)
                        Alpha = 1;
                    Image1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha);
                    break;
                case 1:
                    Alpha = Image2.GetComponent<SpriteRenderer>().color.a;
                    Alpha += Time.deltaTime * 2f;

                    if (Alpha > 1)
                        Alpha = 1;
                    Image2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha);
                    break;
                case 2:
                    Alpha = Image3.GetComponent<SpriteRenderer>().color.a;
                    Alpha += Time.deltaTime * 2f;

                    if (Alpha > 1)
                        Alpha = 1;
                    Image3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha);
                    break;
                case 3:
                    Alpha = Image4.GetComponent<SpriteRenderer>().color.a;
                    Alpha += Time.deltaTime * 2f;

                    if (Alpha > 1)
                        Alpha = 1;
                    Image4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha);
                    break;
            }
        }

        CutTime -= Time.deltaTime;

        if(CutTime <= 0f)
        {
            ++iCurNum;

            if (iCurNum > 4)
                iCurNum = 4;
            CutTime = 3f;
        }

        if(iCurNum >= 4)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
