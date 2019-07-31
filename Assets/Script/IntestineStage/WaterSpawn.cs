using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    public GameObject ObjectSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 40; i++)
        {
            Instantiate(ObjectSpawn, transform.position, Quaternion.identity, null);
        }

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);

            for (int i = 0; i < 40; i++)
            {
                Instantiate(ObjectSpawn, transform.position, Quaternion.identity, null);
            }
        }
    }
}
