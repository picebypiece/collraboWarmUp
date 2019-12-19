using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-18-PM-5-08
// 작성자   : 배형영
// 간단설명 :

public class EnemySpawner : SingletonMono<EnemySpawner>
{
    public enum EnemyKind
    {
        Goomba,
        KoopaTroopa,
        Flower,
    }
    [System.Serializable]
    private struct Enemys
    {
        EnemyKind kind;
        GameObject prefab;
    }

    // Variable
    #region Variable
    [SerializeField]
    private Enemys[] enemyPrefabs = null;
    //private EnumDictionary<EnemyKind,GameObject> 
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
    public bool SpawnEnemy(EnemyKind enemyKind, Vector2 pos, Enemy.Direction direction)
    {


        return true;
    }
    #endregion
}
