using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
public class RiddleBoxControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    
    public struct AnimID
    {
        public int
            Pop, Empty;
    }
    AnimID m_AnimID;

    public struct AnimClipName
    {
        public int
            popUp;
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
    void AnimInit()
    {
        m_AnimID.Pop = Animator.StringToHash("PopTrigger");
        m_AnimID.Empty = Animator.StringToHash("EmptyTrigger");

        m_AnimClipName.popUp = 0;
    }
    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        StartCoroutine(this.ItemArriveCondition());
        //if (m_PoketQueue.Count != 0)
        //{
        //    switch (m_PoketQueue.Peek())
        //    {
        //        case SpawnerType.ItemType.Coin:
        //            break;
        //        case SpawnerType.ItemType.GrowthMushroom:
        //            Debug.Log(m_Animations[0].length);
        //            break;
        //        case SpawnerType.ItemType.PopCoin:
        //            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
        //            RenderAnimator.SetTrigger(m_AnimID.Pop);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        
        //if (m_PoketQueue.Count != 0)
        //{
        //    ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position/*+ new Vector3(0, 0.16f, 0)*/);
         
        //    RenderAnimator.SetTrigger(m_AnimID.Pop);
        //}
    }

    /// <summary>
    /// 아이템 출력 조건
    /// </summary>
    /// <returns></returns>
    IEnumerator ItemArriveCondition()
    {
        if (m_PoketQueue.Count != 0)
        {
            RenderAnimator.SetTrigger(m_AnimID.Pop);
            switch (m_PoketQueue.Peek())
            {
                case SpawnerType.ItemType.Coin:
                    break;
                case SpawnerType.ItemType.GrowthMushroom:
                    yield return new WaitForSeconds(m_Animations[m_AnimClipName.popUp].length);
                    break;
                case SpawnerType.ItemType.PopCoin:
                    break;
                default:
                    break;
            }
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position /*+ new Vector3(0, 0.16f, 0)*/);
        }
        if(m_PoketQueue.Count == 0)
        {
            RenderAnimator.SetTrigger(m_AnimID.Empty);
        }
        yield return null;
    }

    public void SetEmptyBox()
    {
        RenderAnimator.SetTrigger(m_AnimID.Empty);
    }

    //IEnumerator HitMove()
    //{
    //    while (true)
    //    {
    //        while (this.transform.position.y < SettingPos.y + 0.04f)
    //        {
    //            this.transform.position += MoveForce;
    //            yield return new WaitForSeconds(0.15f);
    //        }
    //        while (SettingPos.y < this.transform.position.y)
    //        {
    //            this.transform.position -= MoveForce;
    //            yield return new WaitForSeconds(0.15f);
    //        }
    //        StopCoroutine(MoveUpDown);
    //        this.transform.position = new Vector3(SettingPos.x, (float)SettingPos.y, SettingPos.z);
    //        yield return null;
    //    }
    //}

    #endregion

   

}
