using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
public class BrickObjectControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    [SerializeField]
    Vector3 SettingPos;
    [SerializeField]

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        m_PoketQueue = new Queue<SpawnerType.ItemType>();
        SettingPos = this.transform.position;
    }

    //public override void Start()
    //{
    //    //Debug.Log(PoketQueue.Peek().ToString());
    //    // throw new System.NotImplementedException();
    //}
    #endregion

    // Private Method
    #region Private Method
    //public override void OnCollisionEnter2D(Collision2D col)
    //{
    //    Debug.Log("BrickObject Collision Enter");
    //    //if (col.gameObject.layer.Equals(8) && col.gameObject.transform.position.y < this.transform.position.y)
    //    //{
    //    //    RenderAnimator.SetTrigger("Hit");
    //    //}
    //}
    #endregion

    // Public Method
    #region Public Method

    public override void ActionCall()
    {
        base.ActionCall();
        RenderAnimator.SetTrigger("Hit");
    }
    #endregion


}
