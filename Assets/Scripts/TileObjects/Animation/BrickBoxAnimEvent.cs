using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-29-PM-10-40
// 작성자   : 김세중
// 간단설명 : 벽돌 블럭을 위한 AnimationEvent를 작성

public class BrickBoxAnimEvent : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public void EndHit()
    {
        RenderAnimator.ResetTrigger("Hit");
    }
    #endregion
}
