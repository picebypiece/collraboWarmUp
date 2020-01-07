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


public class GameInputManager : SingletonMono<GameInputManager>
{
    //싱글톤 패턴으로 하나만 사용됨으로 지정
    public static SOInputKey keyMap;
    public enum InputEventType { Push, Pushed, UP, LAST }
    
    #region Variable
    //MappingKey, (key, Event)
    Dictionary<InputKeyName, Action[]> keyMapper;
    public float hAxisValue
    {
        get; private set;
    }
    public float vAxisValue
    {
        get; private set;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    void Awake()
    {
        DontDestroyOnLoad(this);
        InitInputKeyData();
    }


    void Update()
    {
        InputEventType isKeyEvent = InputEventType.LAST;

        for (int i = 0; i < (int)InputKeyName.Last; i++, isKeyEvent = InputEventType.LAST)
        {
            if (Input.GetKeyDown(keyMap.allKeys[i]))
            {
                keyMapper[(InputKeyName)i][(int)InputEventType.Push]?.Invoke();
                isKeyEvent = InputEventType.Push;
            }
            else if (Input.GetKey(keyMap.allKeys[i]))
            {
                keyMapper[(InputKeyName)i][(int)InputEventType.Pushed]?.Invoke();
                isKeyEvent = InputEventType.Pushed;
            }
            else if (Input.GetKeyUp(keyMap.allKeys[i]))
            {
                keyMapper[(InputKeyName)i][(int)InputEventType.UP]?.Invoke();
                isKeyEvent = InputEventType.UP;
            }
            if (isKeyEvent != InputEventType.LAST && ((InputKeyName)i).isGameArrowKey())
                UpdateAxis((InputKeyName)i, isKeyEvent);
        }
    }
    #endregion

    #region Private Method

    void InitInputKeyData()
    {
        if(keyMap == null)
        {
            keyMap = Resources.Load<SOInputKey>(GameData.GameDataScriptableObjectPath);
        }
        keyMapper = new Dictionary<InputKeyName, Action[]>();
        var keys = keyMap.allKeys;
        for (int i = 0; i < (int)InputKeyName.Last; i++)
        {
            keyMapper.Add((InputKeyName)i, new Action[(int)InputEventType.LAST]);
        }
    }

    public void UpdateAxis(InputKeyName keyName, InputEventType type)
    {
        switch (type)
        {
            case InputEventType.Push:
                return;
            case InputEventType.Pushed:
                switch (keyName)
                {
                    case InputKeyName.GameUpKey:
                        vAxisValue += keyMap.SensetiveV * Time.deltaTime;
                        break;
                    case InputKeyName.GameDownKey:
                        vAxisValue -= keyMap.SensetiveV * Time.deltaTime;
                        break;
                    case InputKeyName.GameRightKey:
                        hAxisValue += keyMap.SensetiveH * Time.deltaTime;
                        break;
                    case InputKeyName.GameLeftKey:
                        hAxisValue -= keyMap.SensetiveH * Time.deltaTime;
                        break;
                }
                //Debug.Log($"xHorizontal = {hAxisValue} key info : {keyName.ToString()} {type.ToString()}");
                break;
            case InputEventType.UP:
                switch (keyName)
                {
                    case InputKeyName.GameUpKey:
                    case InputKeyName.GameDownKey:
                        vAxisValue = 0;
                        break;
                    case InputKeyName.GameRightKey:
                    case InputKeyName.GameLeftKey:
                        hAxisValue = 0;
                        break;
                }
                break;
        }
        vAxisValue = Mathf.Clamp(vAxisValue, -1, 1);
        hAxisValue = Mathf.Clamp(hAxisValue, -1, 1);
    }
    #endregion

    #region Public Method

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
        keyMapper[keyName][(int)eventType] += action;
        return true;
    }

    public bool Desubscribe(InputKeyName keyName, InputEventType eventType, Action action)
    {
        keyMapper[keyName][(int)eventType] -= action;
        return true;
    }
    #endregion
}