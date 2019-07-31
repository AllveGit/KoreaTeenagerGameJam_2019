using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeWaterSpawner : MonoBehaviour
{
    public GameObject WaterUnit;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 150; i++)
        {
            Instantiate(WaterUnit, transform.position, Quaternion.identity, null);
        }
    }
}
