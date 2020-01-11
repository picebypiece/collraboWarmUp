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
    private void OnEnable()
    {
        SettingPos = this.transform.position;

        m_Animator.SetTrigger(m_AnimID.PopUp);
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

    // Private Method
    #region Private Method

    #endregion

    // Protected Method
    #region Protected Method
    protected override void doAwake()
    {
        m_AnimID.PopUp = Animator.StringToHash("Hit");
    }

   
    #endregion

    // Public Method
    #region Public Method
    public void ResetTriggerPopUp()
    {
        m_Animator.ResetTrigger(m_AnimID.PopUp);
    }

    #endregion
}
