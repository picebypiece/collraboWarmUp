using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-24-PM-4-22
// 작성자   : 배형영
// 간단설명 :

public class ChildMario : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    GameObject m_TopBody;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        m_TopBody.SetActive(false);
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    #endregion
}
