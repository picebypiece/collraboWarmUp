//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;
// 작성일자 : 2019-12-18-PM-5-08
// 작성자   : 배형영
// 간단설명 :

public class EnemySpawner : Spawner<SpawnerType.EnemyType, GameObject, Transform>, IRegist_Dictionary
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
    public override void Instantiate(GameObject _GameObject, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform)
    {
        GameObject f_gameObject =  Instantiate<GameObject>(_GameObject, new Vector3(_StandardPos.x + (0.16f * _row), _StandardPos.y + (0.16f * _Cloum), 0), Quaternion.identity, _ParentTransform);

        Enemy f_Enemy = f_gameObject.GetComponent<Enemy>();

        EnemyDirection(f_Enemy, _row, _Cloum);
        f_Enemy.Property_SpriteRenderer.enabled = false;
        f_Enemy.enabled = false;
        SpawnObjects.Add(f_gameObject);
    }


    public void EnemyDirection(Enemy _Enemy,int _row, int _cloum)
    {
        string[] tempstring = MapData.Instance.TileMatrixInfo[_cloum];
        
        Enemy.Direction f_Direction;
        if (Enum.TryParse<Enemy.Direction>(tempstring[_row], out f_Direction))
        {
            _Enemy.Init(f_Direction);
        }
    }

    public override void Add_Dictionary()
    {
        int EnemyIndex = 0;
        SpawnerType.EnemyType f_EnemyType = SpawnerType.EnemyType.Goomba;
        for (int i_Type = 0; i_Type < SpawnObjectList.Count; i_Type++)
        {
            CompareEnumTypeDictionary.Add(f_EnemyType++, SpawnObjectList[EnemyIndex++]);
        }
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


