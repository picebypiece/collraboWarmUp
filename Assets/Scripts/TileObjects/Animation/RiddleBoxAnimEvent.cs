using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-PM-4-04
// 작성자   : 김세중
// 간단설명 :

public class RiddleBoxAnimEvent : MonoBehaviour
{
    // Variable
    // Variable
    #region Variable
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GameObject m_RiddleBox;
    RiddleBoxControl m_TileObjectController;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_TileObjectController = m_RiddleBox.GetComponent<RiddleBoxControl>();
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public void ItemCheck()
    {
        if (m_TileObjectController.PoketQueue.Count == 0)
        {
            m_TileObjectController.SetEmptyBox();
        }
    }
    #endregion
}
