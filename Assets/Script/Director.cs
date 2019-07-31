using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    CameraFollow camera = null;
    GameObject player = null;
    bool bDirecting;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraFollow>();      
        player = GameObject.FindGameObjectWithTag("PlayerHead");
        bDirecting = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Zoom()
    {
        float time = 0.0f;

        player.GetComponent<PlayerBody>().Player.timeScale = 0.0f;

        while(time < 3.0f)
        {
            time += 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        camera.Player = player.gameObject;
        player.GetComponent<PlayerBody>().Player.timeScale = 1.0f;
        bDirecting = false;
    }

    public bool GetDirecting() { return bDirecting; }
}
