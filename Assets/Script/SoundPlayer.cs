using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip m_Sound;

    private void Start()
    {
        SoundManager.instance.PlayMusic(m_Sound);
    }
}
