using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
abstract public class TileObject : MonoBehaviour
{
    // Variable
    #region Variable
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    abstract public void Awake();

    abstract public void Start();

    abstract public void OnCollisionEnter2D(Collision2D col);


    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    abstract public void MoveCall();
    #endregion

}
