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
    [SerializeField]
    Tilemap m_Tilemap;
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
    override public void Instantiate(Tile _Tile, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform)
    {
        m_Tilemap.SetTile(new Vector3Int(_row, _Cloum, 0), _Tile);
        SpawnObjects.Add(_Tile);
    }

    public override void Add_Dictionary()
    {
        int Tileindex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.TileType.Ground, SpawnObjectList[Tileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.TileType.Stair, SpawnObjectList[Tileindex++]);
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
