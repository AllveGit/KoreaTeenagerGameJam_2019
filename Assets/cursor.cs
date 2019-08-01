using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursor : MonoBehaviour
{
    public Sprite IdleSprite;
    public Sprite PushSprite;

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.visible = false;
        this.transform.position = Input.mousePosition;

        if (Input.GetMouseButton(0))
            GetComponent<Image>().sprite = PushSprite;

        else
            GetComponent<Image>().sprite = IdleSprite;
    }
}
