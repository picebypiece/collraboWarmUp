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
    Vector3 MoveForce;

    IEnumerator MoveUpDown;
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
        MoveUpDown = HitMove();
    }

    public override void Start()
    {
        Debug.Log(PoketQueue.Peek().ToString());
        // throw new System.NotImplementedException();
    }
    #endregion

    // Private Method
    #region Private Method
    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("BrickObject Collision Enter");
        //if (col.gameObject.layer.Equals(8) && col.gameObject.transform.position.y < this.transform.position.y)
        //{
        //    RenderAnimator.SetTrigger("Hit");
        //}
    }
    #endregion

    // Public Method
    #region Public Method

    public override void ActionCall()
    {
        RenderAnimator.SetTrigger("Hit");
    }
    //public override void TileInfoSet()
    //{
    //    string[] tempstring = MapData.Instance.TileMatrixInfo[m_Vector2Pos.y];
    //   // tempstring[m_Vector2Pos.x];
    //}
    /// <summary>
    /// 렌더링쪽으로 옮겨서 랜더만 옮길껏 2@@@@@@@@@!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    /// </summary>
    /// <returns></returns>
    IEnumerator HitMove()
    {
        while (true)
        {
            while (this.transform.position.y < SettingPos.y + 0.04f)
            {
                this.transform.position += MoveForce;
                yield return new WaitForSeconds(0.15f);
            }
            while (SettingPos.y < this.transform.position.y)
            {
                this.transform.position -= MoveForce;
                yield return new WaitForSeconds(0.15f);
            }
            StopCoroutine(MoveUpDown);
            this.transform.position = new Vector3(SettingPos.x, (float)SettingPos.y, SettingPos.z);
            yield return null;
        }
    }


    #endregion


}
