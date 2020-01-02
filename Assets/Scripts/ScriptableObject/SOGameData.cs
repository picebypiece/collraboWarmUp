using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 작성일자 : 2019-12-29-PM-11-17
// 작성자   : 최태욱
// 간단설명 : 게임에서 사용되는 데이터들을 저장하고 

[CreateAssetMenu(menuName = "ScriptableObject/GameData")]
public class SOGameData : ScriptableObject
{
    public enum GameDataKind
    {
        Score, Life, Coin, Time, StageName, Last
    }
    // Variable
    #region Variable
    int score = 0;
    int life = 0;
    int coin = 0;

    string stageName = "";
    float time = 0;

    Dictionary<int, UnityAction> updateEvent;
    #endregion

    // Property
    #region Property
    public int Score
    {
        get { return score; }
        set
        {
            if (value != score)
            {
                score = value;
                InvokeUpdateEvent(GameDataKind.Score);
            }
        }
    }
    public int Life
    {
        get { return life; }
        set
        {
            if (value != life)
            {
                life = value;
                InvokeUpdateEvent(GameDataKind.Life);
            }
        }
    }
    public int Coin
    {
        get { return coin; }
        set
        {
            if (value != coin)
            {
                coin = value;
                InvokeUpdateEvent(GameDataKind.Coin);
            }
        }
    }
    public float Time
    {
        get { return time; }
        set
        {
            if (value != time)
            {
                time = value;
                InvokeUpdateEvent(GameDataKind.Time);
            }
        }
    }
    public string StageName
    {
        get { return stageName; }
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void Awake()
    {
        InitData();
    }

    #endregion

    // Private Method
    #region Private Method

    void InitData()
    {
        // 스테이지 이름 가져와서 세팅
        InvokeUpdateEvent(GameDataKind.StageName);

        // 각 데이터 값 초기화
    }

    void InvokeUpdateEvent(GameDataKind datakind)
    {
        try
        {
            updateEvent[(int)datakind].Invoke();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    #endregion

    // Public Method
    #region Public Method
    public void SubscribeUpdate(UnityAction action, GameDataKind datakind)
    {
        updateEvent[(int)datakind] += action;
    }

    public void DesubscribeUpdate(UnityAction action, GameDataKind datakind)
    {
        updateEvent[(int)datakind] -= action;
    }
    #endregion
}
