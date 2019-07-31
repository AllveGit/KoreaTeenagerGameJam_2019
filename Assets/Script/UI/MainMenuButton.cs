using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public Sprite IdleSprite;
    public Sprite OverSprite;
    bool bScaleup = false;
    float fScale = 1f;

    public void OnEnter()
    {
        GetComponent<Image>().sprite = OverSprite;
        bScaleup = true;
    }

    public void OnExit()
    {
        GetComponent<Image>().sprite = IdleSprite;
        bScaleup = false;
    }

    private void FixedUpdate()
    {
        if(bScaleup)
        {
            fScale += Time.deltaTime;

            if (fScale > 1.2f)
                fScale = 1.2f;
        }

        else
        {
            fScale -= Time.deltaTime;

            if (fScale < 1f)
                fScale = 1f;
        }

        GetComponent<Image>().transform.localScale = new Vector3(fScale, fScale, 1f);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(0);
    }
}
