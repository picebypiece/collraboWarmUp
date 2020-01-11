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
    public struct AnimClipName
    {
        public int
            popUp;
        public WaitForSeconds
            popUplength;
    }
    AnimClipName m_AnimClipName;
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

        m_AnimClipName.popUp = 0;
        m_AnimClipName.popUplength = new WaitForSeconds(m_Animations[m_AnimClipName.popUp].length);
    }
    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        StartCoroutine(ItemArriveCondition());
    }

    IEnumerator ItemArriveCondition()
    {
        //주머니 큐가 비어있지 않다면,
        if (m_PoketQueue.Count != 0)
        {
            //Anim Hit Trigger 동작
            RenderAnimator.SetTrigger(m_AnimID.Hit);
            //큐의 Out 값 분류
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    yield return m_AnimClipName.popUplength;
                    break;
                case SpawnerType.ItemType.PopCoin:
                    break;
                default:
                    break;
            }
            //ItemPool에서 Pooling 호출
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
        }
        //주머니 큐가 비어있다면
        if (m_PoketQueue.Count == 0)
        {
            //빈상자 Trigger 동작
            //  RenderAnimator.SetTrigger(m_AnimID.Empty);
        }
    }
    #endregion

}
