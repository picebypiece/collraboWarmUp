using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-18-PM-5-08
// 작성자   : 배형영
// 간단설명 :

public class EnemySpawner : Spawner<SpawnerType.EnemyType, GameObject>, IRegist_Dictionary
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
    //public bool SpawnEnemy(EnemyType enemyKind, Vector2 pos, Enemy.Direction direction)
    //{

    //    return true;
    //}

    public override void Add_Dictionary()
    {
        int EnemyIndex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.EnemyType.Goomba, SpawnObjectList[EnemyIndex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.EnemyType.KoopaTroopa, SpawnObjectList[EnemyIndex++]);
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.EnemyType, GameObject>();
    }

    #endregion
}


