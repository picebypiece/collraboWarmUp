using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
public class BrickObjectControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_RenderAnimator;
    public struct AnimID
    {
        public int
            Hit;
    }
    public AnimID m_AnimID;
    #endregion

    // Property
    #region Property
    public Animator RenderAnimator
    {
        get => m_RenderAnimator;
        set => m_RenderAnimator = value;
    }

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        base.Awake();
        m_PoketQueue = new Queue<SpawnerType.ItemType>();
        AnimIDInit();
    }
    #endregion

    // Private Method
    #region Private Method
    void AnimIDInit()
    {
        m_AnimID.Hit = Animator.StringToHash("Hit");
    }
    #endregion

    // Public Method
    #region Public Method
    void PoketCheck()
    {
        if (m_PoketQueue.Count != 0)
        {
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    //m_Animations[0]
                    break;
                case SpawnerType.ItemType.PopCoin:
                    ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
                    m_RenderAnimator.SetTrigger(m_AnimID.Hit);
                    break;
                default:
                    break;
            }
        }
    }
    public override void ActionCall()
    {
        if (m_PoketQueue.Count != 0)
        {
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    Debug.Log(m_Animations[0].length);
                    break;
                case SpawnerType.ItemType.PopCoin:
                    ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
                    break;
                default:
                    break;
            }
        }
        m_RenderAnimator.SetTrigger(m_AnimID.Hit);
    }
    public void ReSetTriggerHit()
    {
        RenderAnimator.ResetTrigger(m_AnimID.Hit);
    }
    #endregion


}
