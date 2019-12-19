using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// 작성일자 : 2019-12-20-PM-12-20
// 작성자   : 최태욱
// 간단설명 : 사용자의 키보드 입력을 관리하는 매니저


public class InputManager : SingletonMono<InputManager>
{
    public enum InputEventType { Push, Pushed, UP }

    Dictionary<string, Event[]> keyAndEvent;
    Dictionary<string, string> keyCodeMapping;

    // Use this for initialization
    void Start()
    {
        // TO-DO Set Don't destory object


    }

    
    void Update()
    {
        // TODO 키입력 감지하여 인풋 이벤트 발생시킴
    }


    void InitInputKeyData()
    {
        // TODO setting KeyData in PlayerPrefab 
    }


    public void SetKeyData(KeyCode key, string mappingKey)
    {
        //TODO 맵핑 키값의 입력 키를 변경
    }

    public void SetKeyData(string key, string mappingKey)
    {
        //TODO 맵핑 키값의 입력 키를 변경
    }

    /// <summary>
    /// 인풋 이벤트를 수신합니다.
    /// 사용하지 않게될때 구독해제 해주어야 합니다.
    /// </summary>
    /// <param name="mappingKey">InputKeyMapper클래스 참고 </param>
    /// <param name="eventType">이벤트 발생 타입</param>
    /// <returns>없는 맵핑키이면 false 반환</returns>
    public bool Subscribe(string mappingKey, InputEventType eventType)
    {
        return true;
    }
}
