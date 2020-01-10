using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-02-PM-4-50
// 작성자   : 배형영
// 간단설명 :

public class Mushroom : Item
{
    // Variable
    #region Variable

    [SerializeField]
    Collider2D m_Collider;
    [SerializeField]
    Rigidbody2D m_Rigidbody2D;
    [SerializeField]
    Vector2 SettingPos;
    [SerializeField]
    Vector3 MoveForce;
    [SerializeField]
    Animator m_Animator;

    struct AnimID
    {
        public int
            PopUp;
    }
    AnimID m_AnimID;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    //private void Start()
    //{
    //    SettingPos = this.transform.position;

    //    m_Animator.SetTrigger(m_AnimID.PopUp);
    //}
    private void OnEnable()
    {
        SettingPos = this.transform.position;

        m_Animator.SetTrigger(m_AnimID.PopUp);
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Protected Method
    #region Protected Method
    protected override void doAwake()
    {
        m_AnimID.PopUp = Animator.StringToHash("Hit");
    }
    //public void SetTrigger(int _AnimID)
    //{
    //    m_Animator.ResetTrigger(_AnimID);
    //}
    public void ResetTriggerPopUp()
    {
        m_Animator.ResetTrigger(m_AnimID.PopUp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Common.tagPlayer))
        {
            // GetScore
            gameObject.SetActive(false);
        }
    }
    #endregion

    // Public Method
    #region Public Method

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
