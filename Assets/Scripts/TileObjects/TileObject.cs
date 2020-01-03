using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
abstract public class TileObject : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    protected Queue<SpawnerType.ItemType> m_PoketQueue;
    [SerializeField]
    protected TilePos m_Vector2Pos;
    #endregion

    // Property 
    #region Property
    public Queue<SpawnerType.ItemType> PoketQueue
    {
        get => m_PoketQueue;
        set => m_PoketQueue = value;
    }
    public TilePos Vector2Pos
    {
        get => m_Vector2Pos;
        set => m_Vector2Pos = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    abstract public void Awake();

    abstract public void Start();

    abstract public void OnCollisionEnter2D(Collision2D col);

    public void Initialized()
    {
        TileInfoSet();
    }
    virtual public void TileInfoSet()
    {
        string[] tempstring = MapData.Instance.TileMatrixInfo[m_Vector2Pos.colum];
        
        int f_parserNum;
        SpawnerType.ItemType f_ItemType;

        if (int.TryParse(tempstring[m_Vector2Pos.row], out f_parserNum))
        {
            for (int i_coin = 0; i_coin < f_parserNum; i_coin++)
            {
                this.GetComponent<TileObject>().PoketQueue.Enqueue(SpawnerType.ItemType.PopCoin);
            }
        }
        else
        {
            if (Enum.TryParse<SpawnerType.ItemType>(tempstring[m_Vector2Pos.row], out f_ItemType))
            {
                this.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
            }
         }
        //if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
        //{
        //    _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
        //}
        //else
        //{
        //    int f_parserNum;

        //    bool isNum = int.TryParse(_compareTileString, out f_parserNum);

        //    if (isNum == true)
        //    {
        //        for (int i_coin = 0; i_coin < f_parserNum; i_coin++)
        //        {
        //            _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(SpawnerType.ItemType.PopCoin);
        //        }
        //    }
        //}
    }
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
