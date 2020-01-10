using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-06-PM-2-43
// 작성자   : 김세중
// 간단설명 :

public class DeathLineColliderController : MonoBehaviour
{
    // Variable
    #region Variable

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Common.tagGround))
        {
            collision.gameObject.SetActive(false);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.collider.CompareTag(Common.tagGround))
    //    {
    //        collision.gameObject.SetActive(false);
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
