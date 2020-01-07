using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-11-PM-4-26
// 작성자   : 배형영
// 간단설명 : 조작에 따른 액션 처리 

public partial class PlayerAction : MonoBehaviour
{

    // Variable
    #region Variable
    [SerializeField]
    private PlayerInput playerInput = null;
    [SerializeField]
    private PlayerAnimCtrl playerAnimCtrl = null;
    [SerializeField]
    private LayerMask overlapCheckLayer;
    [SerializeField]
    private Vector2 overlapBoxSize;

    private Rigidbody2D playerRigidbody = null;
    private float jumpForce; // 점프 힘
    private float runSpeed;  // 달리는 속도
    private float counterForce;   // 역중력 힘
    private Vector2 counterJumpForce;   // 역중력 방향

    private bool action = true;
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isBoxHit = false;
    private int layerMask;


    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        InitData();
    }
    private void FixedUpdate()
    {
        if (!action)
            return;
        Move();
        CheckGround();

        
        if (playerInput.jumpBtnDown)
        {
            if (isGrounded)
            {
                Jump(true);
            }
        }
        if (isJumping)
        {
            if (!playerInput.jumpBtnDown && Vector2.Dot(playerRigidbody.velocity, Vector2.up) > 0/*playerRigidbody.velocity.y >= 0f*/)

                playerRigidbody.AddForce(counterJumpForce * playerRigidbody.mass);
        }
    }
    private void OnDisable()
    {
        //playerAnimCtrl.AnimEndEvent -= AnimEndCall;
    }
    #endregion

    // Private Method
    #region Private Method

    private void InitData()
    {
        playerRigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        if (playerAnimCtrl != null)
            playerAnimCtrl.SetMarioSize(MarioSize.Child);

        //playerAnimCtrl.AnimEndEvent += AnimEndCall;

        jumpForce = 200f;
        runSpeed = 1.5f;
        counterForce = 50f;
        counterJumpForce = Vector2.down * counterForce;
        action = true;
        isGrounded = false;
        isJumping = false;

    }
    /// <summary>
    /// 움직이기
    /// </summary>
    private void Move()
    {

        if (playerInput.move > 0)
        {
            playerAnimCtrl.SetFlipX(false);
        }
        else if (playerInput.move < 0)
        {
            playerAnimCtrl.SetFlipX(true);
        }
        else
        {
            playerAnimCtrl.PlayRun(false, 1f);
            return;
        }
        Vector2 movePos = playerInput.move * Vector2.right * runSpeed * Time.fixedDeltaTime;
            playerRigidbody.position = playerRigidbody.position + movePos;
        playerAnimCtrl.PlayRun(true, playerInput.move * 5f);
    }

    /// <summary>
    /// 점프 
    /// </summary>
    /// <param name="doForce">AddForce 하는지?</param>
    private void Jump(bool doForce)
    {
        isGrounded = false;
        isJumping = true;
        //playerAnimCtrl.PlayJump(true);

        if (doForce)
        {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce) * playerRigidbody.mass);
        }
    }
    /// <summary>
    /// 애니메이션 끝났을때 호출
    /// </summary>
    /// <param name="eventAnim"></param>
    //private void AnimEndCall(PlayerAnimCtrl.EventAnim eventAnim)
    //{
    //    switch (eventAnim)
    //    {
    //        case PlayerAnimCtrl.EventAnim.Growth:
    //            action = true;
    //            SetIgnoreCollision(false, Common.layerEnemy) ;
    //            break;
    //        case PlayerAnimCtrl.EventAnim.Flag:
    //            break;
    //        case PlayerAnimCtrl.EventAnim.Hit:
    //            action = true;
    //            SetIgnoreCollision(false, Common.layerEnemy);
    //            break;
    //    }
    //}
    /// <summary>
    /// 점프가 가능하도록 초기화
    /// </summary>
    private void InitJump()
    {
        //playerAnimCtrl.PlayJump(false);
        isGrounded = true;
        isJumping = false;
    }
    #endregion

    // Public Method
    #region Public Method

    public void DirectDeath()
    {
        action = false;
        //음...
    }

    public void Growth()
    {
        action = false;
        SetIgnoreCollision(true,Common.layerEnemy);
        //playerAnimCtrl.PlayGrowth();
    }
    #endregion
}
