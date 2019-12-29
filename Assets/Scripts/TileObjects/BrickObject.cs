using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
public class BrickObject : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Rigidbody2D my_rigid;
    [SerializeField]
    Vector3 StandardForce;
    [SerializeField]
    Vector3 SettingPos;

    IEnumerator MoveUpDown;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        SettingPos = this.transform.position;
        MoveUpDown = HitMove();
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
        StartCoroutine(MoveUpDown);

    }
    #endregion

    // Public Method
    #region Public Method

    /// <summary>
        /// 렌더링쪽으로 옮겨서 랜더만 옮길껏 2@@@@@@@@@!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <returns></returns>
    IEnumerator HitMove()
    {
        Vector3 f_movePos = new Vector3(0, 0.04f, 0);

        while (true)
        {
            while (this.transform.position.y < SettingPos.y + 0.04f)
            {
                this.transform.position += f_movePos;
                Debug.Log("업");
                yield return new WaitForSeconds(0.15f);
            }
            while (SettingPos.y < this.transform.position.y)
            {
                this.transform.position -= f_movePos;
                Debug.Log("다운");
                yield return new WaitForSeconds(0.15f);
            }
            Debug.Log("끝");
            StopCoroutine(MoveUpDown);
            Debug.Log(SettingPos.y);
            this.transform.position = new Vector3(SettingPos.x, (float)SettingPos.y, SettingPos.z);
            Debug.Log(this.transform.position + "And" + SettingPos);
            yield return null;
        }

    }
    #endregion


}
