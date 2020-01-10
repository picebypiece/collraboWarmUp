using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-02-PM-8-30
// 작성자   : 김세중
// 간단설명 :

public class PopCoin : Item
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

    private void Start()
    {
        m_SOGameData.Coin++;
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    protected override void doAwake()
    {
    }
    #endregion
}
