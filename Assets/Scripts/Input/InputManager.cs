using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.Linq;


// 작성일자 : 2019-12-20-PM-12-20
// 작성자   : 최태욱
// 간단설명 : 사용자의 키보드 입력을 관리하는 매니저


public class InputManager : SingletonMono<InputManager>
{
    public enum InputEventType { Push, Pushed, UP, LAST }

    class keyEvent
    {
        public string key;
        public Action[] events;
    }
    #region Variable
    //MappingKey, (key, Event)
    Dictionary<string, keyEvent> keyMap;
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        var keyList = keyMap.Values.ToList();
        for (int i = 0; i < keyList.Count ; i++)
        {
            if(Input.GetKeyDown(keyList[i].key))
            {
                keyList[i].events[(int)InputEventType.Push]?.Invoke();
            }
            else if(Input.GetKey(keyList[i].key))
            {
                keyList[i].events[(int)InputEventType.Pushed]?.Invoke();
            }
            else if(Input.GetKeyUp(keyList[i].key))
            {
                keyList[i].events[(int)InputEventType.UP]?.Invoke();
            }
        }    
    }
    #endregion

    void InitInputKeyData()
    {
        keyMap = new Dictionary<string, keyEvent>();
        
        var mapkeyList = SDInputKeyMapper.allMapKeys;
        
        for (int i = 0; i < mapkeyList.Length; i++)
        {
            var mkey = PlayerPrefs.GetString(mapkeyList[i]);
            var events = new Action[(int)InputEventType.LAST];
            keyMap.Add(mapkeyList[i], new keyEvent {key = mkey, events = events} );
        }
    }


    public bool SetKeyData(KeyCode key, string mappingKey)
    {
        return SetKeyData(key.ToString(), mappingKey);
    }

    public bool SetKeyData(string key, string mappingKey)
    {
        //TODO 맵핑 키값의 입력 키를 변경
        if (keyMap.ContainsKey(mappingKey) == false) return false;

        keyMap[mappingKey].key = key ;
        return true;
    }

    /// <summary>
    /// 인풋 이벤트를 수신합니다.
    /// 사용하지 않게될때 구독해제 해주어야 합니다.
    /// </summary>
    /// <param name="mappingKey">InputKeyMapper클래스 참고 </param>
    /// <param name="eventType">이벤트 발생 타입</param>
    /// <returns>없는 맵핑키이면 false 반환</returns>
    public bool Subscribe(string mappingKey, InputEventType eventType, Action action)
    {
        if (keyMap.ContainsKey(mappingKey) == false) return false;
        keyMap[mappingKey].events[(int)eventType] += action;
        return true;
    }

    public bool Desubscribe(string mappingKey, InputEventType eventType, Action action)
    {
        if (keyMap.ContainsKey(mappingKey) == false) return false;
        keyMap[mappingKey].events[(int)eventType] -= action;
        return true;
    }
}