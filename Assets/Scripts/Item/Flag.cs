using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-11-AM-3-20
// 작성자   : 김세중
// 간단설명 :

public class Flag : Item
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_Animator;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Common.tagPlayer))
        {
            m_Animator.SetTrigger("EndGame");
        }
    }
    //private void OnCollisionEnter2D(Collider2D _Collider)
    //{
    //    if (_Collider.CompareTag(Common.tagPlayer))
    //    {
    //        m_Animator.SetTrigger("EndGame");
    //    }
    //}
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    #endregion
}
