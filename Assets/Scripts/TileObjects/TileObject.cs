using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ۼ����� : 2019-12-22-PM-7-58
// �ۼ���   : �輼��
// ���ܼ��� :
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
