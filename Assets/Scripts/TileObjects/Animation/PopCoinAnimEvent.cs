using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-02-PM-8-40
// 작성자   : 김세중
// 간단설명 :

public class PopCoinAnimEvent : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GameObject m_PopCoin;
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
    public void AnimDisable()
    {
        m_PopCoin.SetActive(false);
    }
    #endregion
}
