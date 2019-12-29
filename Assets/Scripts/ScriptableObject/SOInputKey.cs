using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 키입력 저장하는 스크립터블 오브젝트
/// </summary>
[CreateAssetMenu]
public class SOInputKey : ScriptableObject
{
    /// <summary>
    /// 인풋매니저에서 맵핑키 반복을 위해서 사용
    /// 키값이 추가될시 리스트에도 추가
    /// </summary>
    public string[] allKeys;
    //기본 방향키 UI조작, 기본 키 입력
    public string ArrowUpKey =      "Up"; 
    public string ArrowDownKey =    "Down";
    public string ArrowRightKey =   "Right";
    public string ArrowLeftKey =    "Left";
    public string EscapeKey =       "escape"; 

    //인게임에서 사용되는 키입력
    public string GameUpKey = "Up";
    public string GameDownKey = "Down";
    public string GameRightKey ="Right";
    public string GameLeftKey = "Left";
    public string JumpKey =  "z";
    public string DashKey = "x";

    public void Awake()
    {
        allKeys = new string[]
        {
            ArrowUpKey, ArrowDownKey, ArrowRightKey, ArrowLeftKey, EscapeKey,
            GameUpKey, GameDownKey, GameRightKey, GameLeftKey, JumpKey, DashKey
        };
    }

    public enum InputKeyName
    {
        ArrowUpKey,
        ArrowDownKey,
        ArrowRightKey,
        ArrowLeftKey,
        EscapeKey,
        GameUpKey,
        GameDownKey,
        GameRightKey,
        GameLeftKey,
        JumpKey,
        DashKey,
        Last
    }
}
