using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
abstract public class TileObject : MonoBehaviour
{
    // Variable
    #region Variable
    Queue<SpawnerType.ItemType> m_PoketQueue;
    #endregion

    // Property
    #region Property
    public Queue<SpawnerType.ItemType> PoketQueue
    {
        get => m_PoketQueue;
        set => m_PoketQueue = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    abstract public void Awake();

    abstract public void Start();

    abstract public void OnCollisionEnter2D(Collision2D col);


    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    virtual public void ActionCall()
    { }
    #endregion

}
