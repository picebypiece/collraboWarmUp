using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-31-AM-12-11
// 작성자   : 배형영
// 간단설명 :

public class Coin : Item
{
    // Variable
    #region Variable
    [SerializeField]
    SOGameData m_SOGameData;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Common.tagPlayer))
        {
            // GetScore
            m_SOGameData.Coin++;
            gameObject.SetActive(false);
        }
    }


    #endregion

    // Private Method
    #region Private Method
    #endregion

    // Protected Method
    #region Protected Method
    protected override void doAwake()
    {
        
    }
    #endregion
    // Public Method
    #region Public Method

    #endregion
}
