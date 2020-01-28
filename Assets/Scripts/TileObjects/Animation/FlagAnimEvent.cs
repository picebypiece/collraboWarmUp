using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-27-PM-4-14
// 작성자   : 김세중
// 간단설명 :

public class FlagAnimEvent : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GameObject m_Flag;
    Flag m_FlagControl;


    [SerializeField]
    GameObject m_player;
    [SerializeField]
    GameObject m_CalseDoor;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_FlagControl = m_Flag.GetComponent<Flag>();
    }
    private void Start()
    {
        m_CalseDoor = GameObject.Find(Common.CalseDoorName);
        
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public void EndofFlagMove()
    {
        Common.GameState = GameState.End;
        //마리오 에니메이션 동작
        m_FlagControl.playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Run, true, 1f);
        //playerAction 에서 GotoMove 코루틴 호출로 player 동작
        StartCoroutine(m_FlagControl.PlayerAction.GotoTargetMove(m_CalseDoor.gameObject.transform.position));

    }
    #endregion
}
