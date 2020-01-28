using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-11-AM-3-20
// 작성자   : 김세중
// 간단설명 :

public class Flag : Item
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    GameObject m_player;

    [SerializeField]
    PlayerAnimCtrl m_playerAnimCtrl;
    [SerializeField]
    PlayerAction m_PlayerAction;
    #endregion

    // Property
    #region Property
    public PlayerAction PlayerAction
    {
        get => m_PlayerAction;
        set => m_PlayerAction = value;
    }
    public PlayerAnimCtrl playerAnimCtrl
    {
        get => m_playerAnimCtrl;
        set => m_playerAnimCtrl = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Start()
    {
        m_player = GameObject.Find(Common.PlayerName);
       
        m_playerAnimCtrl = m_player.GetComponent<PlayerAnimCtrl>();
        m_PlayerAction = m_player.GetComponent<PlayerAction>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Common.tagPlayer))
        {
            m_Animator.SetTrigger("EndGame");
        }
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
   
    #endregion
}
