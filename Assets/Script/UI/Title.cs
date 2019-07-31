using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    bool bUp = false;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //if(!bUp)
        //{
        //    RectTransform MyTransform = GetComponent<RectTransform>();

        //    MyTransform.localPosition -= new Vector3(0,1,0) * Time.deltaTime * 30;

        //    if (MyTransform.localPosition.y <= -150)
        //    {
        //        MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, -150, 0);
        //        bUp = true;
        //    }
        //}

        //else
        //{
        //    RectTransform MyTransform = GetComponent<RectTransform>();

        //    MyTransform.position += new Vector3(0, 1, 0) * Time.deltaTime * 30;

        //    if (MyTransform.position.y >= -80)
        //    {
        //        MyTransform.position = new Vector3(MyTransform.localPosition.x ,-80, 0);
        //        bUp = false;
        //    }
        //}

        transform.Translate(new Vector3(0, Mathf.Cos(Time.time * 5) * 5, 0));
    }
}
