using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ۼ����� : 2019-12-22-PM-7-58
// �ۼ���   : �輼��
// ���ܼ��� :
public class BrickObject : TileObject
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
        //throw new System.NotImplementedException();
    }

    public override void Start()
    {
        // throw new System.NotImplementedException();
    }
    #endregion

    // Private Method
    #region Private Method
    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("BrickObject Collision Enter");
    }
    #endregion

    // Public Method
    #region Public Method

    #endregion


}
