using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static SOInputKey;
/// <summary>
/// 키입력 저장하는 스크립터블 오브젝트
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/InputKey")]
public class SOInputKey : ScriptableObject
{
    /// <summary>
    /// 인풋매니저에서 맵핑키 반복을 위해서 사용
    /// 키값이 추가될시 리스트에도 추가
    /// </summary>
    public string[] allKeys;
    public string   escapeKey = "escape";

    //인게임에서 사용되는 키입력
    public string GameUpKey = "up";
    public string GameDownKey = "down";
    public string GameRightKey = "right";
    public string GameLeftKey = "left";
    public string JumpKey = "z";
    public string DashKey = "x";
    public string GameHorizontal = "Horizontal";    //수평 가속도 입력
    public string GameVertical = "Vertical";        //수직 가속도 입력

    public float SensetiveH = 5f;
    public float SensetiveV = 5f;

    public void OnEnable()
    {
        allKeys = new string[]
        {
            escapeKey, GameUpKey, GameDownKey, GameRightKey, GameLeftKey, JumpKey, DashKey
        };
    }

    public enum InputKeyName
    {
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

public static class InputKeyNameExtension
{
    public static bool isGameArrowKey(this InputKeyName s)
    {
        return (s == InputKeyName.GameDownKey || s == InputKeyName.GameUpKey ||
                s == InputKeyName.GameLeftKey || s == InputKeyName.GameRightKey);
    }
}
