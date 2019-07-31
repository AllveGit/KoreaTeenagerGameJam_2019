using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public static MainGame instance = null;
    public float playerScale = 1.0f;
    public int playerBodyCount = 2;


    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(instance);
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
