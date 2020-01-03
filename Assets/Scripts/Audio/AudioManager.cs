using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-AM-1-58
// 작성자   : 배형영
// 간단설명 :

public class AudioManager : SingletonMono<AudioManager>
{

    // Variable
    #region Variable
    public SoundVolume volume = new SoundVolume();

    private AudioClip[] seClips;
    private AudioClip[] bgmClips;

    private Dictionary<string, int> seIndexes = new Dictionary<string, int>();
    private Dictionary<string, int> bgmIndexes = new Dictionary<string, int>();

    const int cNumChannel = 16;
    private AudioSource bgmSource;
    private AudioSource[] seSources = new AudioSource[cNumChannel];

    Queue<int> seRequestQueue = new Queue<int>();
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void Awake()
    {

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;

        for (int i = 0; i < seSources.Length; i++)
        {
            seSources[i] = gameObject.AddComponent<AudioSource>();
        }

        seClips = Resources.LoadAll<AudioClip>("Audio / SE");
        bgmClips = Resources.LoadAll<AudioClip>("Audio / BGM");

        for (int i = 0; i < seClips.Length; ++i)
        {
            seIndexes[seClips[i].name] = i;
        }

        for (int i = 0; i < bgmClips.Length; ++i)
        {
            bgmIndexes[bgmClips[i].name] = i;
        }
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
        

    #endregion
}
