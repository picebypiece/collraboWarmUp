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
    [SerializeField]
    private ItemSpawner m_ItemSpawner;

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

    override public void Instantiate(GameObject _GameObject,Vector3 _StandardPos,int _row, int _Cloum,Transform _ParentTransform)
    {
       GameObject tempgameobvj =  Instantiate<GameObject>(_GameObject, new Vector3(_StandardPos.x + (0.16f * _row), _StandardPos.y + (0.16f * _Cloum), 0), Quaternion.identity, _ParentTransform);

        var _tempTileObject = tempgameobvj.GetComponent<TileObject>();

        if(_tempTileObject != null)
        {
            _tempTileObject.Vector2Pos = new TilePos(_row, _Cloum);
            _tempTileObject.Initialized();
        }
        SpawnObjects.Add(tempgameobvj);
    }

    public override void Add_Dictionary()
    {
        int ObjectTileindex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.Flag, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.Brick, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.RiddleBox, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeBodyLeft, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeBodyRight, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeDoorLeft, SpawnObjectList[ObjectTileindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ObjectTileType.PipeDoorRight, SpawnObjectList[ObjectTileindex++]);
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
