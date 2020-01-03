using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 작성일자 : 2019-12-22-PM-7-58
// 작성자   : 김세중
// 간단설명 :
public class RiddleBoxControl : TileObject
{
    // Variable
    #region Variable
    [SerializeField]
    Animator RenderAnimator;
    [SerializeField]
    Vector3 SettingPos;

    List<int> AnimID;



    //IEnumerator MoveUpDown;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    public override void Awake()
    {
        AnimID = new List<int>();
        m_PoketQueue = new Queue<SpawnerType.ItemType>();
        SettingPos = this.transform.position;
        //MoveUpDown = HitMove();

        AnimID.Add(Animator.StringToHash("PopTrigger"));
        AnimID.Add(Animator.StringToHash("EmptyTrigger"));

    }

    //public override void OnCollisionEnter2D(Collision2D col)
    //{
    //    Debug.Log("RiddleBoxControl Collision Enter");

    //    //if (col.gameObject.layer.Equals(8)&& col.gameObject.transform.position.y < this.transform.position.y)
    //    //{
    //    //    RenderAnimator.SetTrigger("PopTrigger");
    //    //}
    //}

    //public override void Start()
    //{
    //    //throw new System.NotImplementedException();
    //}

    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public override void ActionCall()
    {
        //base.ActionCall();
        if (m_PoketQueue.Count != 0)
        {
            ItemSpawner.Instance.Pooling(1, m_PoketQueue.Dequeue(), this.transform.position+ new Vector3(0, 0.16f, 0));
         
            RenderAnimator.SetTrigger(AnimID[0]);
        }
    }

    public void SetEmptyBox()
    {
        RenderAnimator.SetTrigger(AnimID[1]);
    }
    //IEnumerator HitMove()
    //{
    //    while (true)
    //    {
    //        while (this.transform.position.y < SettingPos.y + 0.04f)
    //        {
    //            this.transform.position += MoveForce;
    //            yield return new WaitForSeconds(0.15f);
    //        }
    //        while (SettingPos.y < this.transform.position.y)
    //        {
    //            this.transform.position -= MoveForce;
    //            yield return new WaitForSeconds(0.15f);
    //        }
    //        StopCoroutine(MoveUpDown);
    //        this.transform.position = new Vector3(SettingPos.x, (float)SettingPos.y, SettingPos.z);
    //        yield return null;
    //    }
    //}

    #endregion

   

}
