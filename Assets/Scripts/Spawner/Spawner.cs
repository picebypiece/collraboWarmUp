using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-27-AM-11-33
// 작성자   : 김세중
// 간단설명 : Spawner 클래스 제작시 상속 받아 사용

abstract public class Spawner<TEnum, TSpawnType> : MonoBehaviour where TEnum : struct
{
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

    abstract public void Instantiate(TSpawnType _GameObject, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform);

    //abstract void MapInfoSet(GameObject _gameObject, string _compareTileString, int _row, int _cloum)
    //{
    //    //string[] tempRow = m_MapData.TileMatrixInfo[_i_Cloum];
    //    //MapInfoSet(m_GameObject, tempRow[_i_row], _i_row, _i_Cloum);

    //    int f_parserNum;
    //    SpawnerType.ItemType f_ItemType; //= SpawnerType.ItemType.PopCoin;
    //    if (int.TryParse(_compareTileString, out f_parserNum))
    //    {
    //        for (int i_coin = 0; i_coin < f_parserNum; i_coin++)
    //        {
    //            _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(SpawnerType.ItemType.PopCoin);
    //        }
    //    }
    //    else
    //    {
    //        if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
    //        {
    //            _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
    //        }
    //    }
    //    //if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
    //    //{
    //    //    _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
    //    //}
    //    //else
    //    //{
    //    //    int f_parserNum;

    //    //    bool isNum = int.TryParse(_compareTileString, out f_parserNum);

    //    //    if (isNum == true)
    //    //    {
    //    //        for (int i_coin = 0; i_coin < f_parserNum; i_coin++)
    //    //        {
    //    //            _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(SpawnerType.ItemType.PopCoin);
    //    //        }
    //    //    }
    //    //}
    //}
}
