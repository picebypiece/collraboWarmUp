using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 : TileObject의 기본이 되는 최상위 클래스
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
    /// <summary>
    /// TileObject의 애니메이션을 담은 배열
    /// </summary>
    [SerializeField]
    protected AnimationClip[] m_Animations;
    /// <summary>
    /// TileObject가 가지고 있을 아이탬을 모아놓은 Queue
    /// </summary>
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
    /// <summary>
    /// 인스턴스 생성 중 Awake로 기초적인 컴포넌트나 기본적으로 가지고있어야 할 값들을 준비
    /// </summary>
    virtual public void Awake()
    {
        RenderSetting();
        m_PoketQueue = new Queue<SpawnerType.ItemType>();
        SettingPos = this.transform.position;
    }
    #endregion

    // Private Method
    #region Private Method

    /// <summary>
    /// Render가 연결이 되어있지 않다면 내 인스턴스에서 찾아서 연결함
    /// </summary>
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
    /// <summary>
    /// TileObject가 반응을 보여야 할때 사용할 메소드
    /// </summary>
    abstract public void ActionCall();

    /// <summary>
    /// 초기화 해야할 내용을 작성
    /// </summary>
    /// <param name="_row">행</param>
    /// <param name="_Cloum">렬</param>
    virtual public void Initialized(int _row, int _Cloum)
    {
        this.Vector2Pos = new TilePos(_row, _Cloum);
    }

   


    #endregion

}
