using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// 작성일자 : 2019-12-27-PM-12-48
// 작성자   : 김세중
// 간단설명 :

public class TileSpawner : Spawner<SpawnerType.TileType, Tile, Tilemap>,IRegist_Dictionary
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
    override public void Instantiate(Tile _Tile, Vector3 _StandardPos, int _row, int _Cloum, Tilemap _Tilemap)
    {
        _Tilemap.SetTile(new Vector3Int(_row, _Cloum, 0), _Tile);
        SpawnObjects.Add(_Tile);
    }

    public override void Add_Dictionary()
    {
        int Tileindex = 0;
        SpawnerType.TileType f_TileType = SpawnerType.TileType.Ground;
        for (int i_Type = 0; i_Type < SpawnObjectList.Count; i_Type++)
        {
            CompareEnumTypeDictionary.Add(f_TileType++, SpawnObjectList[Tileindex++]);
        }
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.TileType, Tile>();
    }
    #endregion

}
