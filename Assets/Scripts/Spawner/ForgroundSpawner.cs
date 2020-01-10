using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// 작성일자 : 2020-01-03-PM-6-39
// 작성자   : 김세중
// 간단설명 :

public class ForgroundSpawner : Spawner<SpawnerType.ForegroundType, Tile, Tilemap>, IRegist_Dictionary
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
    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.ForegroundType, Tile>();
    }

    public override void Instantiate(Tile _Tile, Vector3 _StandardPos, int _row, int _Cloum, Tilemap _TilemapTransform)
    {
        _TilemapTransform.SetTile(new Vector3Int(_row, _Cloum, 0), _Tile);
        SpawnObjects.Add(_Tile);
    }

    public override void Add_Dictionary()
    {
        int Tileindex = 0;
        SpawnerType.ForegroundType f_ForegroundType = SpawnerType.ForegroundType.FlagBody;
        for (int i_Type = 0; i_Type < SpawnObjectList.Count; i_Type++)
        {
            CompareEnumTypeDictionary.Add(f_ForegroundType++, SpawnObjectList[Tileindex++]);
        }
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.FlagBody, SpawnObjectList[Tileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.FlagTop, SpawnObjectList[Tileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.CalseFlag, SpawnObjectList[Tileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.CalseTop, SpawnObjectList[Tileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.Calse, SpawnObjectList[Tileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ForegroundType.CalseDoor, SpawnObjectList[Tileindex++]);
    }

    #endregion

}
