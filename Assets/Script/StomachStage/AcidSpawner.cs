using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    public GameObject Acid;

    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            Instantiate(Acid, this.transform.position, Quaternion.identity, this.transform);
        }
        StartCoroutine(Spawning());
    }


    IEnumerator Spawning()
    {
        while (true)
        {

            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 50; i++)
            {
                Instantiate(Acid, this.transform.position, Quaternion.identity, this.transform);
            }


        }
    }
}
