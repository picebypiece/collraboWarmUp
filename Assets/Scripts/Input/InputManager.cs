using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.Linq;
using static SOInputKey;


// 작성일자 : 2019-12-20-PM-12-20
// 작성자   : 최태욱
// 간단설명 : 사용자의 키보드 입력을 관리하는 매니저


public class InputManager : SingletonMono<InputManager>
{
    public SOInputKey keyMap;
    public enum InputEventType { Push, Pushed, UP, LAST }
    
    #region Variable
    //MappingKey, (key, Event)
    Dictionary<string, Action[]> keyMapper;
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        var keyList = keyMapper.Keys.ToList();
        for (int i = 0; i < keyList.Count; i++)
        {
            if(Input.GetKeyDown(keyList[i]))
            {
                keyMapper[keyList[i]][(int)InputEventType.Push]?.Invoke();
            }
            else if(Input.GetKey(keyList[i]))
            {
                keyMapper[keyList[i]][(int)InputEventType.Pushed]?.Invoke();
            }
            else if(Input.GetKeyUp(keyList[i]))
            {
                keyMapper[keyList[i]][(int)InputEventType.UP]?.Invoke();
            }
        }    
    }
    #endregion

    void InitInputKeyData()
    {
        keyMapper = new Dictionary<string, Action[]>();
        var keys = keyMap.allKeys;
        for (int i = 0; i < keys.Length; i++)
        {
            keyMapper.Add(keys[i], new Action[(int)InputEventType.LAST]);
        }
    }


    public bool SetKeyData(KeyCode key, SOInputKey.InputKeyName keyName)
    {
        return SetKeyData(key.ToString(), keyName);
    }

    public bool SetKeyData(string key, SOInputKey.InputKeyName keyName)
    {
        //TODO 맵핑 키값의 입력 키를 변경
        keyMap.allKeys[(int)keyName] = key;
        return true;
    }

    /// <summary>
    /// 인풋 이벤트를 수신합니다.
    /// 사용하지 않게될때 구독해제 해주어야 합니다.
    /// </summary>
    /// <param name="mappingKey">InputKeyMapper클래스 참고 </param>
    /// <param name="eventType">이벤트 발생 타입</param>
    /// <returns>없는 맵핑키이면 false 반환</returns>
    public bool Subscribe(InputKeyName keyName, InputEventType eventType, Action action)
    {
        keyMapper[keyMap.allKeys[(int)keyName]][(int)eventType] += action;
        return true;
    }

    public bool Desubscribe(InputKeyName keyName, InputEventType eventType, Action action)
    {
        keyMapper[keyMap.allKeys[(int)keyName]][(int)eventType] -= action;
        return true;
    }
}