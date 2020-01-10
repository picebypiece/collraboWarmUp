using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// 작성일자 : 2019-12-27-AM-11-33
// 작성자   : 김세중
// 간단설명 : Spawner 클래스 제작시 상속 받아 사용

abstract public class Spawner<TEnum, TSpawnType, TSpawnPos> : SingletonMono<Spawner<TEnum, TSpawnType, TSpawnPos>> where TEnum : struct
{
    [SerializeField]
    protected CreateTileMap m_CreateTileMap;
    [SerializeField]
    protected List<TSpawnType> SpawnObjectList;
    [SerializeField]
    protected List<TSpawnType> SpawnObjects;
    [SerializeField]
    protected EnumDictionary<TEnum, TSpawnType> CompareEnumTypeDictionary;
    public EnumDictionary<TEnum, TSpawnType> Get_CompareEnumTypeDictionary
    {
        get => CompareEnumTypeDictionary;
    }

    abstract public void Add_Dictionary();
    virtual public void Instantiate(TSpawnType _GameObject, Vector3 _StandardPos, int _row, int _Cloum, TSpawnPos _ParentTransform)
    { }

    /// <summary>
    /// Spawner에서 따로 빼 관리할것 (수정대상)
    /// </summary>
    /// <param name="_Count"></param>
    /// <param name="_ItemType"></param>
    /// <param name="_SetPosition"></param>
    virtual public void Pooling(int _Count, SpawnerType.ItemType _ItemType, Vector3 _SetPosition)
    { }
}
