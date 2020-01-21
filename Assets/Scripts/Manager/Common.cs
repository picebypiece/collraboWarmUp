using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-19-PM-3-57
// 작성자   : 배형영
// 간단설명 : 공용 클래스나, 메소드, enum등을 선원해놓는곳 

public static class Common
{
    // Variable
    #region Variable

    // 태그
    public const string tagEnvirments = "Envirments";
    public const string tagGround = "Ground";
    public const string tagEnemy = "Enemy";
    public const string tagItem = "Item";
    public const string tagPlayer = "Player";
    public const string tagCamera = "Camera";

    // 레이어
    public const string layerPlayer = "Player";
    public const string layerEnemy = "Enemy";
    public const string layerEnvirments = "Envirments";

    //계층구조 내 오브젝트 이름
    public const string TileGrideName = "Grid";
    #endregion

    // Property
    #region Property

    #endregion

    // Public Method
    #region Public Method

    #endregion
}

public class SceneName
{
    public const string Title = "SceneTitle";
    public const string Stage = "SceneStage";
    public const string Option = "SceneOption";
    public const string StageUI = "StageUI";
}


[System.Serializable]
public struct TilePos
{
    public int row, colum;
    public TilePos(int r, int c)
    {
        row = r;
        colum = c;
    }
}

/// <summary>
/// 딕셔너리 등록시 필요할 메소드들을 한번에 정의 한 인터페이스
/// </summary>
public interface IRegist_Dictionary
{
    /// <summary>
    /// 딕셔너리 초기화
    /// </summary>
    void Dictionary_Init();
    /// <summary>
    /// 딕셔너리 추가
    /// </summary>
    void Contain_Dictionary();
}


/// <summary>
/// Spawner의 Type 모음
/// </summary>
namespace SpawnerType
{
    public enum TileType
    {
        Ground, Stair, PipeBodyLeft, PipeBodyRight
    }
    public enum ForegroundType
    {
        FlagBody, FlagTop, CalseFlag, CalseTop, Calse, CalseDoor
    }
    public enum ObjectTileType
    {
        Brick, RiddleBox, PipeDoorLeft, PipeDoorRight, InvisibleBox
    }
    public enum ItemType
    {
        Coin, GrowthMushroom, PopCoin, Flag, CalseEnter
    }
    public enum PlayerType
    {
        Player, Mario
    }
    public enum EnemyType
    {
        Goomba,
        KoopaTroopa
    }
}

public enum MarioSize
{
    Child = 0,
    Adult
}

public class GameData
{
    public const string GameDataScriptableObjectPath = "ScriptableObject/SOInputKeyMap";

    public const string GDCoin = "GameDataCoin";
    public const string GDTime = "GameDataTime";
    public const string GDLife = "GameDataLife";
    public const string GDScore = "GameDataScore";
    public const string GDStageName = "GameDataStageName";

    //새 데이터 추가시 아래 배열에도 추가
    public static readonly string[] GDStrings = { GDCoin, GDTime, GDLife, GDScore, GDStageName };
}