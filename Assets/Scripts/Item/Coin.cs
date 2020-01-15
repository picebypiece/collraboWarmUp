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
    StageData m_GameData;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
<<<<<<< HEAD
    private void Awake()
    {
        m_GameData = GameManger.StageData;
    }

    #endregion

    // Private Method
    #region Private Method
=======
>>>>>>> 0aaee1d7b6814c95a29362b4b1d2dc6a1d5f2cf5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Common.tagPlayer))
        {
            // GetScore
            m_GameData.Coin++;
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
