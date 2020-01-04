using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-04-AM-12-51
// 작성자   : 김세중
// 간단설명 :

public class InvisibleBoxControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;

    public struct AnimID
    {
        public int
            Hit;
    }
    AnimID m_AnimID;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        base.Awake();
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
    public override void ActionCall()
    {
        if (m_PoketQueue.Count != 0)
        {
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position + new Vector3(0, 0.16f, 0));
            RenderAnimator.SetTrigger(m_AnimID.Hit);
        }
    }
    #endregion

}
