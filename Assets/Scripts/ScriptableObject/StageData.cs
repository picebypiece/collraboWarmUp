using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 작성일자 : 2019-12-29-PM-11-17
// 작성자   : 최태욱
// 간단설명 : 게임에서 사용되는 데이터들을 저장하고 이벤트를 켜주는 클래스

public class StageData : ScriptableObject
{
    // Variable
    #region Variable
    int score = 0;
    int life = 0;
    int coin = 0;

    string stageName = "";
    float time = 0;

    Dictionary<string, UnityAction> updateEvent;
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
                InvokeUpdateEvent(GameData.GDScore);
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
                InvokeUpdateEvent(GameData.GDLife);
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
                InvokeUpdateEvent(GameData.GDCoin);
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
                InvokeUpdateEvent(GameData.GDTime);
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
    void DumyFunction()
    {
        // 이벤트 함수 추가용 임시 함수
    }

    void InitData()
    {
        if (updateEvent == null)
        {
            updateEvent = new Dictionary<string, UnityAction>(GameData.GDStrings.Length);
            for (int i = 0; i < GameData.GDStrings.Length; i++)
            {
                updateEvent.Add(GameData.GDStrings[i], DumyFunction);
            }
        }
        // 스테이지 이름 가져와서 세팅
        // InvokeUpdateEvent(StageName);

        // 각 데이터 값 초기화
    }

    void InvokeUpdateEvent(string datakind)
    {
        try
        {
            updateEvent[datakind].Invoke();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    #endregion

    // Public Method
    #region Public Method
    /// <param name="action">Update Function</param>
    /// <param name="datakind"> GameDefine GameData string </param>
    public bool SubscribeUpdate(UnityAction action, string datakind)
    {
        if(updateEvent.ContainsKey(datakind))
        {
            updateEvent[datakind] += action;
            return true;
        }
        return false;
    }

    /// <param name="action">Update Function</param>
    /// <param name="datakind"> GameDefine GameData string </param>
    public bool DesubscribeUpdate(UnityAction action, string datakind)
    {
        if (updateEvent.ContainsKey(datakind))
        {
            updateEvent[datakind] -= action;
            return true;
        }
        return false;
    }

    public string GetDataToString(string dataKey)
    {
        string retval = null;
        switch (dataKey)
        {
            case GameData.GDCoin:
                retval = coin.ToString();
                break;
            case GameData.GDLife:
                retval = life.ToString();
                break;
            case GameData.GDScore:
                retval = score.ToString();
                break;
            case GameData.GDTime:
                retval = time.ToString();
                break;
            case GameData.GDStageName:
                retval = stageName.ToString();
                break;
            default:
                break;
        }

        return retval;
    }
    #endregion
}
