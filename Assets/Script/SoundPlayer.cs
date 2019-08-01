using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip m_Sound;

    private void Awake()
    {
        SoundManager.instance.PlayMusic(m_Sound);
    }
}
