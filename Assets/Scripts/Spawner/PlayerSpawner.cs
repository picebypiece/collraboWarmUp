using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-27-PM-1-06
// 작성자   : 김세중
// 간단설명 :


public class PlayerSpawner : Spawner<SpawnerType.PlayerType, GameObject>,IRegist_Dictionary
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
        int playerIndex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.PlayerType.Player, SpawnObjectList[playerIndex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.PlayerType.Mario, SpawnObjectList[playerIndex++]);
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.PlayerType, GameObject>();
    }
}
