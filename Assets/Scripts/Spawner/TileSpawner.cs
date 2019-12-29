using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// 작성일자 : 2019-12-27-PM-12-48
// 작성자   : 김세중
// 간단설명 :

public class TileSpawner : Spawner<SpawnerType.TileType, Tile>,IRegist_Dictionary
{
    // Variable
    #region Variable

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    
    #endregion

    // Private Method
    #region Private Method
    
    #endregion

    // Public Method
    #region Public Method

    #endregion
    public override void Add_Dictionary()
    {
        int Tileindex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.TileType.Ground, SpawnObjectList[Tileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.TileType.Stair, SpawnObjectList[Tileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.TileType.FlagBody, SpawnObjectList[Tileindex++]);
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.TileType, Tile>();
    }
}
