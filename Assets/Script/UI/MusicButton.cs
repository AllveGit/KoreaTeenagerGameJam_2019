using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite IdleSprite;
    public Sprite OverSprite;
    public Sprite IdleSprite2;
    public Sprite OverSprite2;
    bool bScaleup = false;
    float fScale = 1f;

    public void OnEnter()
    {
        if (!SoundManager.instance.mute)
        {
            GetComponent<Image>().sprite = OverSprite;
        }

        else
        {
            GetComponent<Image>().sprite = OverSprite2;
        }

        bScaleup = true;
    }

    public void OnExit()
    {
        if (!SoundManager.instance.mute)
        {
            GetComponent<Image>().sprite = IdleSprite;
        }

        else
        {
            GetComponent<Image>().sprite = IdleSprite2;
        }

        bScaleup = false;
    }

    private void FixedUpdate()
    {
        if (bScaleup)
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

    public void SoundMute()
    {
        SoundManager.instance.mute = !SoundManager.instance.mute;
    }
}
