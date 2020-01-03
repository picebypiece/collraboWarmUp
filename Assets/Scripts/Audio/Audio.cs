using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-AM-2-29
// 작성자   : 배형영
// 간단설명 :

public class Audio
{
    public AudioFiles audioFile;
    public AudioClip audioClip;

}
[System.Serializable]
public class SoundVolume
{
    public float bgm = 1.0f;
    public float se = 1.0f;

    public bool mute = false;

    public void Reset()
    {
        bgm = 1.0f;
        se = 1.0f;
        mute = false;
    }
}
public enum AudioFiles
{
    
}

