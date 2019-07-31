using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 4)
        {
            Destroy(collision.gameObject);
        }
    }
}
