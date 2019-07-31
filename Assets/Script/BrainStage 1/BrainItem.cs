using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainItem : MonoBehaviour
{
    BrainCounter counter;

    // Start is called before the first frame update
    void Awake()
    {
        counter = FindObjectOfType<BrainCounter>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            counter.iBrainItemCnt++;
            Destroy(this.gameObject);
        }
    }
}
