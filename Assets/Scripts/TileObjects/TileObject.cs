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
    [Header("location")]
    [SerializeField]
    protected Vector3 SettingPos;
    [SerializeField]
    protected TilePos m_ProcessionVector2;

    [Space(1)]

    [Header("Graphic")]
    [SerializeField]
    protected Renderer m_Renderer;
    [SerializeField]
    protected AnimationClip[] m_Animations;
   
    [SerializeField]
    protected Queue<SpawnerType.ItemType> m_PoketQueue;
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
        get => m_ProcessionVector2;
        set => m_ProcessionVector2 = value;
    }
    public Renderer Renderer
    {
        get => m_Renderer;
        set => m_Renderer = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    virtual public void Awake()
    {
        RenderSetting();
        m_PoketQueue = new Queue<SpawnerType.ItemType>();
        SettingPos = this.transform.position;
    }

    //abstract public void Start();

    //abstract public void OnCollisionEnter2D(Collision2D col);

    virtual public void Initialized(int _row, int _Cloum)
    {
        this.Vector2Pos = new TilePos(_row, _Cloum);
        TileInfoSet();
    }
    virtual public void TileInfoSet()
    {
        string[] tempstring = MapData.Instance.TileMatrixInfo[m_ProcessionVector2.colum];
        
        int f_parserNum;

        if (int.TryParse(tempstring[m_ProcessionVector2.row], out f_parserNum))
        {
            for (int i_coin = 0; i_coin < f_parserNum; i_coin++)
            {
                this.GetComponent<TileObject>().PoketQueue.Enqueue(SpawnerType.ItemType.PopCoin);
            }
        }
        else
        {
            SpawnerType.ItemType f_ItemType;
            if (Enum.TryParse<SpawnerType.ItemType>(tempstring[m_ProcessionVector2.row], out f_ItemType))
            {
                this.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
            }
         }
      
    }
    #endregion

    // Private Method
    #region Private Method
    void RenderSetting()
    {
        if (m_Renderer == null)
        {
            m_Renderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        }
    }
    #endregion

    // Public Method
    #region Public Method
    //virtual protected void PoketCheck()
    //{
    //    if (m_PoketQueue.Count != 0)
    //    {
    //        switch (m_PoketQueue.Peek())
    //        {
    //            case SpawnerType.ItemType.Coin:
    //                break;
    //            case SpawnerType.ItemType.GrowthMushroom:
    //                //m_Animations[0]
    //                break;
    //            case SpawnerType.ItemType.PopCoin:
    //                ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
    abstract public void ActionCall();
    
    #endregion

}
