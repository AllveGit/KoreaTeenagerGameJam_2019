using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource EffectSource;

    float PrevMusicValue = -1;
    float PrevEffectValue = -1;

    public static SoundManager instance = null;

    public bool mute = false;

    private void Awake()
    {
        if (instance == null) instance = this;

        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (EffectSource.volume != 0)
            PrevEffectValue = EffectSource.volume;

        if (MusicSource.volume != 0)
            PrevMusicValue = MusicSource.volume;


        if(mute)
        {
            EffectSource.volume = 0;
            MusicSource.volume = 0;
        }
        else
        {
            EffectSource.volume = PrevEffectValue;
            MusicSource.volume = PrevMusicValue;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.Stop();
        MusicSource.clip = clip;
        MusicSource.Play();
        MusicSource.loop = true;
    }

    public void PlayEffect(AudioClip clip)
    {
        EffectSource.clip = clip;
        EffectSource.Play();
        EffectSource.loop = false;
    }

    public void SetEffectVolume(float percent)
    {
        if(!mute)
            EffectSource.volume = percent;

        else
            EffectSource.volume = 0;
    }

    public void SetBGVolume(float percent)
    {
        if (!mute)
            MusicSource.volume = percent;

        else
            MusicSource.volume = 0;
    }
}
