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

        AnimIDInit();
    }
    #endregion

    // Private Method
    #region Private Method
    void AnimIDInit()
    {
        m_AnimID.Pop = Animator.StringToHash("PopTrigger");
        m_AnimID.Empty = Animator.StringToHash("EmptyTrigger");
    }
    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        //base.ActionCall();
        if (m_PoketQueue.Count != 0)
        {
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position+ new Vector3(0, 0.16f, 0));
         
            RenderAnimator.SetTrigger(m_AnimID.Pop);
        }
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
