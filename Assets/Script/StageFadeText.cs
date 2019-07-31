using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageFadeText : MonoBehaviour
{
    public bool bEnabled = false;
    public bool bAlphaEnd = false;
    public float iAlpha = 0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (bAlphaEnd)
        {
            iAlpha -= Time.fixedDeltaTime;

            if (iAlpha < 0)
            {
                iAlpha = 0;
                Destroy(this.gameObject);
            }
        }

        else if(bEnabled)
        {
            iAlpha += Time.fixedDeltaTime;

            if(iAlpha > 1)
            {
                iAlpha = 1;
                bAlphaEnd = true;
            }
        }

        GetComponent<Image>().color = new Color(1, 1, 1, iAlpha);
    }
}
