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
    public float move { get; private set; }
    public bool jumpBtnDown { get; private set; }
    public bool jumpBtnUp { get; private set; }
    public bool jumpBtnDownPush { get; private set; }
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour


    private void Start()
    {
        GameInputManager.Instance.Subscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Push, JumpDown);
        GameInputManager.Instance.Subscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Pushed, JumpDownStay);
        GameInputManager.Instance.Subscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.UP, JumpUp);
    }

    private void OnDisable()
    {
        //OutControl();
        if (GameInputManager.Instance != null)
        {
            GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Push, JumpDown);
            GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Pushed, JumpDownStay);
            GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.UP, JumpUp);
        }
    }

    private void Update()
    {
        //TODO : 게임오버시 리턴시킴
        //if()
        //{
        //    move = 0;
        //    jump = false;
        //    return;
        //}

        move = GameInputManager.Instance.hAxisValue;
    }
    #endregion

    // Private Method
    #region Private Method
    void JumpDown()
    {
        jumpBtnDown = true;
        jumpBtnDownPush = true;
        jumpBtnUp = false;
    }
    void JumpDownStay()
    {
        jumpBtnDown = false;
        jumpBtnDownPush = true;
        jumpBtnUp = false;
    }

    void JumpUp()
    {
        jumpBtnDown = false;
        jumpBtnDownPush = false;
        jumpBtnUp = true;
    }
    #endregion

    // Public Method
    #region Public Method
    //public void OutControl()
    //{
    //    if (GameInputManager.Instance != null)
    //    {
    //        GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Push, JumpDown);
    //        GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.Pushed, JumpDownStay);
    //        GameInputManager.Instance.Desubscribe(SOInputKey.InputKeyName.JumpKey, GameInputManager.InputEventType.UP, JumpUp);
    //    }
    //}
    #endregion
}
