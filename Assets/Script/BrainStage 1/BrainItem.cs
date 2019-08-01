using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainItem : MonoBehaviour
{
    BrainCounter counter;
    public GameObject PopupText;

    // Start is called before the first frame update
    void Awake()
    {
        counter = FindObjectOfType<BrainCounter>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameObject Temp = Instantiate(PopupText, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Finish").transform) as GameObject;

            Vector2 ScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);

            Temp.transform.position = ScreenPos;
            counter.iBrainItemCnt++;

            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.SizeUp();

            Destroy(this.gameObject);
        }
    }

    public void EatItem()
    {

    }
}
