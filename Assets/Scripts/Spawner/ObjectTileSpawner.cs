using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 작성일자 : 2019-12-27-PM-12-57
// 작성자   : 김세중
// 간단설명 : GameObject형 Tile을 Spawn해줌


public class ObjectTileSpawner : Spawner<SpawnerType.ObjectTileType, GameObject>,IRegist_Dictionary
{
    // Variable
    #region Variable
    private MapData m_MapData;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_MapData = MapData.Instance;
    }

    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    override public void Instantiate(GameObject _GameObject, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform)
    {
        GameObject f_tempObject = Instantiate<GameObject>(_GameObject, new Vector3(_StandardPos.x + (0.16f * _row), _StandardPos.y + (0.16f * _Cloum), 0), Quaternion.identity, _ParentTransform);

        var f_tempTileObject = f_tempObject.GetComponent<TileObject>();

        if (f_tempTileObject != null)
        {
            f_tempTileObject.Initialized(_row, _Cloum);
        }
       
        SpawnObjects.Add(f_tempObject);
    }

    public override void Add_Dictionary()
    {
        int ObjectTileindex = 0;
        SpawnerType.ObjectTileType f_ObjectTileType = SpawnerType.ObjectTileType.Flag; 
        for (int i_Type = 0; i_Type < SpawnObjectList.Count; i_Type++)
        {
            CompareEnumTypeDictionary.Add(f_ObjectTileType++, SpawnObjectList[ObjectTileindex++]);
        }

        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.Flag, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.Brick, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.RiddleBox, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeBodyLeft, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeBodyRight, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeDoorLeft, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeDoorRight, SpawnObjectList[ObjectTileindex++]);
        //CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.InvisibleBox, SpawnObjectList[ObjectTileindex++]);
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.ObjectTileType, GameObject>();
    }
    #endregion

}
