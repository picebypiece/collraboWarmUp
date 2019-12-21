using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-12-PM-8-33
// 작성자   : 최태욱
// 간단설명 : 게임에 사용하는 키의 종류

public static class SDInputKeyMapper 
{
    /// <summary>
    /// 인풋매니저에서 맵핑키 반복을 위해서 사용
    /// 키값이 추가될시 리스트에도 추가
    /// </summary>
    public static string[] allMapKeys =
    {
        ArrowUp, ArrowDown, ArrowRight, ArrowLeft, Escape, 
        GameUp, GameDown, GameRight, GameLeft, Jump, Dash
    };
    //기본 방향키 UI조작, 기본 키 입력
    public static string ArrowUp = "INPUT_MAPPING_ARROW_UP";
    public static string ArrowDown = "INPUT_MAPPING_ARROW_DOWN";
    public static string ArrowRight = "INPUT_MAPPING_ARROW_RIGHT";
    public static string ArrowLeft = "INPUT_MAPPING_ARROW_LEFT";
    public static string Escape = "INPUT_MAPPING_Escape";


    //인게임에서 사용되는 키입력
    public static string GameUp = "INPUT_MAPPING_GAME_UP";
    public static string GameDown = "INPUT_MAPPING_GAME_DOWN";
    public static string GameRight = "INPUT_MAPPING_GAME_RIGHT";
    public static string GameLeft = "INPUT_MAPPING_GAME_LEFT";
    public static string Jump = "INPUT_MAPPING_JUMP";
    public static string Dash = "INPUT_MAPPING_DASH";
}
