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
    protected EnumDictionary<TEnum, TSpawnType> CompareEnumTypeDictionary;
    public EnumDictionary<TEnum, TSpawnType> Get_CompareEnumTypeDictionary
    {
        get => CompareEnumTypeDictionary;
    }

    abstract public void Add_Dictionary();
}
