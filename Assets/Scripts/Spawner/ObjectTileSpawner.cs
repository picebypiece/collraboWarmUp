using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 작성일자 : 2019-12-27-PM-12-57
// 작성자   : 김세중
// 간단설명 : GameObject형 Tile을 Spawn해줌


public class ObjectTileSpawner : Spawner<SpawnerType.ObjectTileType, GameObject, Transform>,IRegist_Dictionary
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

    /// <summary>
    /// ObjectTile를 생성시 작업
    /// Isntantiate를 통해서 자신의 객층구조상 위치(부모의 Transform)에 객체를 생성하며,
    /// 생성시 Renderer를 끄고, 필요한 기본정보를 작성 해줌
    /// </summary>
    /// <param name="_GameObject">만들 객체</param>
    /// <param name="_StandardPos">타일의 0,0값</param>
    /// <param name="_row">행</param>
    /// <param name="_Cloum">렬</param>
    /// <param name="_ParentTransform">부모의 Transform</param>
    override public void Instantiate(GameObject _GameObject, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform)
    {
        GameObject f_tempObject = Instantiate<GameObject>(_GameObject, new Vector3(_StandardPos.x + (0.16f * _row), _StandardPos.y + (0.16f * _Cloum), 0), Quaternion.identity, _ParentTransform);

        var f_tempTileObject = f_tempObject.GetComponent<TileObject>();

        f_tempTileObject.Renderer.enabled = false;

        if (f_tempTileObject != null)
        {
            f_tempTileObject.Initialized(_row, _Cloum);
        }
       
        SpawnObjects.Add(f_tempObject);
    }

    public override void Add_Dictionary()
    {
        int ObjectTileindex = 0;
        SpawnerType.ObjectTileType f_ObjectTileType = SpawnerType.ObjectTileType.Brick; 
        for (int i_Type = 0; i_Type < SpawnObjectList.Count; i_Type++)
        {
            CompareEnumTypeDictionary.Add(f_ObjectTileType++, SpawnObjectList[ObjectTileindex++]);
        }

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
