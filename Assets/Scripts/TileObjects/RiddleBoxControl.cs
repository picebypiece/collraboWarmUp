using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 : 물음표 상자를 만들어 내는데 필요한 클래스
public class RiddleBoxControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    /// <summary>
    /// RiddleBox Animation ID Struct
    /// </summary>
    public struct AnimID
    {
        public int
            Pop, Empty;
    }
    AnimID m_AnimID;

    /// <summary>
    /// RiddleBox Animation Clip Struct
    /// </summary>
    public struct AnimClipName
    {
        public int
            popUp;
        public WaitForSeconds
            popUplength;
    }
    AnimClipName m_AnimClipName;

    //IEnumerator MoveUpDown;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        base.Awake();
        AnimInit();
    }
    #endregion

    // Private Method
    #region Private Method
    /// <summary>
    /// 애니메이션 관련 준비, 클립과 아이디를 초기화
    /// </summary>
    void AnimInit()
    {
        m_AnimID.Pop = Animator.StringToHash("PopTrigger");
        m_AnimID.Empty = Animator.StringToHash("EmptyTrigger");

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

    /// <summary>
    /// 아이템 생성 조건
    /// </summary>
    /// <returns></returns>
    IEnumerator ItemArriveCondition()
    {
        //주머니 큐가 비어있지 않다면,
        if (m_PoketQueue.Count != 0)
        {
            //Pop Trigger 동작
            RenderAnimator.SetTrigger(m_AnimID.Pop);
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
            RenderAnimator.SetTrigger(m_AnimID.Empty);
        }
    }

    public void SetEmptyBox()
    {
        RenderAnimator.SetTrigger(m_AnimID.Empty);
    }


    #endregion

   

}
