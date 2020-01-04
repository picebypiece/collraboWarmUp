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

    // 레이어
    public const string layerPlayer = "Player";
    public const string layerEnemy = "Enemy";
    public const string layerEnvirments = "Envirments";
    #endregion

    // Property
    #region Property

    #endregion

    // Public Method
    #region Public Method
        
    #endregion
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
public interface IRegist_Dictionary
{
    void Dictionary_Init();
    void Contain_Dictionary();
}
namespace SpawnerType
{
    public enum TileType
    {
        Ground, Stair
    }
    public enum ForegroundType
    {
        FlagBody, FlagTop, CalseFlag, CalseTop, Calse, CalseDoor
    }
    public enum ObjectTileType
    {
        Flag, Brick, RiddleBox, PipeBodyLeft, PipeBodyRight, PipeDoorLeft, PipeDoorRight,
    }
    public enum ItemType
    {
        Coin, GrowthMushroom, LifeMushroom, Flower, PopCoin
    }         
    public enum PlayerType
    {
        Player, Mario
    }
    public enum EnemyType
    {
        Goomba,
        KoopaTroopa,
        Flower,
    }
}

public enum MarioSize
{
    Child = 0,
    Adult
}

public class GameData
{
    public const string GDCoin = "GameDataCoin";
    public const string GDTime = "GameDataTime";
    public const string GDLife = "GameDataLife";
    public const string GDScore = "GameDataScore";
    public const string GDStageName = "GameDataStageName";

    //새 데이터 추가시 아래 배열에도 추가
    public static readonly string[] GDStrings = { GDCoin, GDTime, GDLife, GDScore, GDStageName };
}