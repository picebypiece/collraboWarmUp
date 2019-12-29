using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-27-PM-1-07
// 작성자   : 김세중
// 간단설명 :

public class ItemSpawner : Spawner<SpawnerType.ItemType, GameObject>, IRegist_Dictionary
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

    #endregion
    public override void Add_Dictionary()
    {
        
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.ItemType, GameObject>();
    }
}
