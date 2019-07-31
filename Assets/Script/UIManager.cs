using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject RetryButton;
    public GameObject MainMenuButton;
    public GameObject DieObject;
    private Player player = null;
    public static UIManager instance = null;
    public bool IsEnd = false;

    private void Awake()
    {
        if (instance == null) instance = this;

        else Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
        IsEnd = false;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Player m_pPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            if (m_pPlayer && m_pPlayer.IsDie && IsEnd == false)
            {
                DieObject.SetActive(true);
                Vector3 fScale = DieObject.GetComponent<RectTransform>().localScale;
                fScale += new Vector3(1, 1, 0) * Time.deltaTime * 15;

                if (fScale.x > 4f)
                {
                    fScale = new Vector3(4, 4, 4);

                    RetryButton.SetActive(true);
                    MainMenuButton.SetActive(true);
                    IsEnd = true;
                }

                DieObject.GetComponent<RectTransform>().localScale = fScale;
            }
        }
    }

    public void CloseWindow()
    {
        DieObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        RetryButton.SetActive(false);
        MainMenuButton.SetActive(false);
        DieObject.SetActive(false);
    }
}
