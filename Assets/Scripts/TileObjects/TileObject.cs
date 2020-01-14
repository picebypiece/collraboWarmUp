using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// �ۼ����� : 2019-12-22-PM-7-58
// �ۼ���   : �輼��
// ���ܼ��� : TileObject�� �⺻�� �Ǵ� �ֻ��� Ŭ����
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
    /// TileObject�� �ִϸ��̼��� ���� �迭
    /// </summary>
    [SerializeField]
    protected AnimationClip[] m_Animations;
    /// <summary>
    /// TileObject�� ������ ���� �������� ��Ƴ��� Queue
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
    /// �ν��Ͻ� ���� �� Awake�� �������� ������Ʈ�� �⺻������ �������־�� �� ������ �غ�
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
    /// Render�� ������ �Ǿ����� �ʴٸ� �� �ν��Ͻ����� ã�Ƽ� ������
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
    /// TileObject�� ������ ������ �Ҷ� ����� �޼ҵ�
    /// </summary>
    abstract public void ActionCall();

    /// <summary>
    /// �ʱ�ȭ �ؾ��� ������ �ۼ�
    /// </summary>
    /// <param name="_row">��</param>
    /// <param name="_Cloum">��</param>
    virtual public void Initialized(int _row, int _Cloum)
    {
        this.Vector2Pos = new TilePos(_row, _Cloum);
    }

   


    #endregion

}
