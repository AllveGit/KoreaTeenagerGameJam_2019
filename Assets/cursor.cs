using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursor : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.visible = false;
        this.transform.position = Input.mousePosition;
    }
}
