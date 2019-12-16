using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-11-PM-4-26
// 작성자   : 배형영
// 간단설명 : 조작에 따른 액션 처리 

public class PlayerAction : MonoBehaviour
{
    private enum MarioSize
    {
        Child = 0,
        Adult
    }

    // Variable
    #region Variable
    [SerializeField]
    private PlayerInput playerInput = null;
    [SerializeField]
    private PlayerAnimCtrl playerAnimCtrl = null;
    private Rigidbody2D playerRigidbody = null;
    //private BoxCollider2D playerColider = null;

    [SerializeField]
    private float jumpForce = 200f;
    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float counterForce = 50f;
    private Vector2 counterJumpForce;

    private bool action = true;
    private bool isGrounded = false;
    private bool isJumping = false;
    
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        playerRigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        if (playerAnimCtrl != null)
            playerAnimCtrl.SetState(false);

        counterJumpForce = Vector2.down * counterForce;
        playerAnimCtrl.AnimEndEvent += AnimEndCall;
        playerAnimCtrl.AdultToChildEvent += AdultToChildCall;
    }
    private void FixedUpdate()
    {
        if (!action)
            return;
        Move();

        if (playerInput.jumpBtnDown)
        {
            if (isGrounded)
            {
                Jump();
            }
        }
        if (isJumping)
        {
            if(!playerInput.jumpBtnDown && Vector2.Dot(playerRigidbody.velocity, Vector2.up) > 0/*playerRigidbody.velocity.y >= 0f*/)
            
            playerRigidbody.AddForce(counterJumpForce * playerRigidbody.mass);
        }
    }
    private void OnDisable()
    {
        playerAnimCtrl.AnimEndEvent -= AnimEndCall;
        playerAnimCtrl.AdultToChildEvent -= AdultToChildCall;
    }
    #endregion

    // Private Method
    #region Private Method
    private void Move()
    {

        if (playerInput.move > 0)
        {
            playerAnimCtrl.FlipX = false;
        }
        else if (playerInput.move < 0)
        {
            playerAnimCtrl.FlipX = true;
        }
        else
        {
            playerAnimCtrl.PlayRun(false, 1f);
            return;
        }
        Vector2 movePos = playerInput.move * Vector2.right * runSpeed * Time.deltaTime;
            playerRigidbody.position = playerRigidbody.position + movePos;

        playerAnimCtrl.PlayRun(true, playerInput.move * 5f);
    }
    private void Jump()
    {
        isGrounded = false;
        isJumping = true;
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(0, jumpForce) * playerRigidbody.mass);
        playerAnimCtrl.PlayJump(true);
    }

    private void SetAction(bool doPlay)
    {
        // 캐릭터 멈추기 // 무적
        action = doPlay;
        playerRigidbody.simulated = doPlay;

    }
    private void AnimEndCall(PlayerAnimCtrl.EventAnim eventAnim)
    {
        switch (eventAnim)
        {
            case PlayerAnimCtrl.EventAnim.Growth:

                SetAction(true);
                break;
            case PlayerAnimCtrl.EventAnim.Flag:
                break;
            case PlayerAnimCtrl.EventAnim.Death:
                break;
        }
    }
    // 무적효과
    private void AdultToChildCall()
    {
        StartCoroutine(Invincibility());
    }
    private IEnumerator Invincibility()
    {
        // 무적 시작
        yield return new WaitForSeconds(2f);
    }
    #endregion

    // Public Method
    #region Public Method


    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerAnimCtrl.PlayJump(false);
        isGrounded = true;
        isJumping = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetAction(false);
        playerAnimCtrl.PlayGrowth();
    }
    #endregion
}
