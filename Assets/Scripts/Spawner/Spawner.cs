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
    /// <summary>
    /// Spawn에 사용할 SpawnType 담은 리스트
    /// </summary>
    [SerializeField]
    protected List<TSpawnType> SpawnObjectList;
    /// <summary>
    /// 실제 Spawn 된 오브젝트들을 담은 리스트
    /// </summary>
    [SerializeField]
    protected List<TSpawnType> SpawnObjects;
    /// <summary>
    /// Enum Key , SpawnType Value로 만들어진 Dictionary 
    /// </summary>
    [SerializeField]
    protected EnumDictionary<TEnum, TSpawnType> CompareEnumTypeDictionary;

    public EnumDictionary<TEnum, TSpawnType> Get_CompareEnumTypeDictionary
    {
        get => CompareEnumTypeDictionary;
    }

    /// <summary>
    /// EnumDictionary으로 Key / Value 설정하는 메소드
    /// </summary>
    abstract public void Add_Dictionary();

    /// <summary>
    /// Spawner에서 Instantiate 하면서 추가 작업도 함께 할수 있도록 정의한 메소드
    /// </summary>
    /// <param name="_SpawnType">스포너가 사용할 타입에 맞는 인자</param>
    /// <param name="_StandardPos">Tile의 0,0값 Vector3으로 변환한것</param>
    /// <param name="_row">행</param>
    /// <param name="_Cloum">렬</param>
    /// <param name="_ParentTransform">부모 Trasform</param>
    virtual public void Instantiate(TSpawnType _SpawnType, Vector3 _StandardPos, int _row, int _Cloum, TSpawnPos _ParentTransform)
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
