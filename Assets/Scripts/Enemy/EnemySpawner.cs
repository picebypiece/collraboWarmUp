using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-18-PM-5-08
// 작성자   : 배형영
// 간단설명 :

public class EnemySpawner : SingletonMono<EnemySpawner>
{
    public enum EnemyKind
    {
        Goomba,
        KoopaTroopa,
        Flower,
    }
    EnemyKind m_EnemyKind;

    // Variable
    #region Variable

    private EnumDictionary<EnemyKind, CreateTileMap.TileType> EnemyCompareTileTypeDictionary;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    //private void Awake()
    //{
    //    CreateTileMap.TileType f_TileType;
    //    EnemyCompareTileTypeDictionary.Add(EnemyKind.Goomba, CreateTileMap.TileType.Goomba);
    //    EnemyCompareTileTypeDictionary.TryGetValue(EnemyKind.Goomba, out f_TileType);
    //    CreateTileMap.Instance.TileGameObjectDictionary.Add(f_TileType, CreateTileMap.Instance.MonsterGameObjects[3]);
    //}
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public bool SpawnEnemy(EnemyKind enemyKind, Vector2 pos, Enemy.Direction direction)
    {

        return true;
    }

    public void Add_Dictionary()
    {
        CreateTileMap.TileType f_TileType;
        EnemyCompareTileTypeDictionary = new EnumDictionary<EnemyKind, CreateTileMap.TileType>();
        EnemyCompareTileTypeDictionary.Add(EnemyKind.Goomba, CreateTileMap.TileType.Goomba);
        EnemyCompareTileTypeDictionary.TryGetValue(EnemyKind.Goomba, out f_TileType);
        CreateTileMap.Instance.TileGameObjectDictionary.Add(f_TileType, CreateTileMap.Instance.MonsterGameObjects[3]);
    }
    #endregion
}


