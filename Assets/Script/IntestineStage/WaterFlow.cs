using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public float iDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 4)
        {
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(iDir, 0), ForceMode2D.Impulse);
        }
    }
}