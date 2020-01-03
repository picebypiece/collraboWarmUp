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


public interface IRegist_Dictionary
{
    void Dictionary_Init();
    void Contain_Dictionary();
}
namespace SpawnerType
{
    public enum TileType
    {
        Ground, Stair, FlagBody
    }
    public enum ObjectTileType
    {
        Flag, Brick, RiddleBox, PipeBodyLeft, PipeBodyRight, PipeDoorLeft, PipeDoorRight,
    }
    public enum ItemType
    {
        Coin, Mushroom, Flower, PopCoin
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

public enum ItemKind
{
    Coin,
    GrowthMushroom,
    LifeMushroom,
}

public enum MarioSize
{
    Child = 0,
    Adult
}