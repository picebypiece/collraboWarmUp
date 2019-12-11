using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-3-20
// 작성자   : 배형영
// 간단설명 : 플레이어 인풋 이벤트 처리 담당

public class PlayerInput : MonoBehaviour
{
    // Variable
    #region Variable
    private string moveAxisName = "Horizontal";
    private string jumpButtonName = "Jump";

    public float move { get; private set; }
    public bool jumpBtnDown { get; private set; }
    public bool jumpBtnUp { get; private set; }
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void Update()
    {
        //TODO : 게임오버시 리턴시킴
        //if()
        //{
        //    move = 0;
        //    jump = false;
        //    return;
        //}

        move = Input.GetAxis(moveAxisName);
        jumpBtnDown = Input.GetButtonDown(jumpButtonName);
        jumpBtnUp = Input.GetButtonUp(jumpButtonName);
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public void JumpEnd()
    {
        jumpBtnDown = false;
    }
    #endregion
}
