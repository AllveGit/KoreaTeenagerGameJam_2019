using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public int Dir;
    FadeManager m_Fade;

    void Start()
    {
        m_Fade = FindObjectOfType<FadeManager>();
        StartCoroutine(Fading());
    }

    public IEnumerator Fading()
    {
        float FadeTime = m_Fade.BeginFade(Dir);
        yield return new WaitForSeconds(FadeTime);
    }
}
