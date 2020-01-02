using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :

public class FlagObjectControl : TileObject
{
    // Variable
    #region Variable

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {

    }
    public override void Start()
    {

    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("FlagObject Collision Enter");
    }

    public override void ActionCall()
    {
        //throw new System.NotImplementedException();
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    #endregion



}
