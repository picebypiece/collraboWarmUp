using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-02-PM-4-48
// 작성자   : 배형영
// 간단설명 :

public abstract class Item : MonoBehaviour
{
    // Variable
    #region Variable
    [Header("Item")]
    [SerializeField]
    protected ItemKind itemKind;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    #endregion

    // Private Method
    #region Private Method

    private void Awake()
    {
        doAwake();
    }
    #endregion

    // Protected Method
    #region Protected Method
    protected virtual void doAwake()
    {

    }
    #endregion

    // Public Method
    #region Public Method

    #endregion
}
