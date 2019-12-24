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

    [SerializeField]
    private float jumpForce = 200f; // 점프 힘
    [SerializeField]
    private float runSpeed = 1.5f;  // 달리는 속도

    [SerializeField]
    private float counterForce = 50f;   // 역중력 힘
    private Vector2 counterJumpForce;   // 역중력 방향

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
    
    private void AnimEndCall(PlayerAnimCtrl.EventAnim eventAnim)
    {
        switch (eventAnim)
        {
            case PlayerAnimCtrl.EventAnim.Growth:
                action = true;
                SetIgnoreEnemy(false);
                break;
            case PlayerAnimCtrl.EventAnim.Flag:
                break;
            case PlayerAnimCtrl.EventAnim.Hit:
                break;
            case PlayerAnimCtrl.EventAnim.Death:
                break;
        }
    }
    private void Hit()
    {

    }
    private void SetIgnoreEnemy(bool val)
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(Common.layerPlayer), LayerMask.NameToLayer(Common.layerEnemy), val);
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
        var dir = collision.contacts[0].normal;
        switch (collision.collider.tag)
        {
            // 벽돌
            //case Common.tagEnvirments:
            //    if (dir.y < 0 )
            //    {
            //        // 벽돌
            //    }
            //    break;
            case Common.tagEnemy:
                {
                    
                    if(dir.y > 0)
                    {
                        Enemy enemy = collision.collider.GetComponent(typeof(Enemy)) as Enemy;
                        enemy?.Death();
                        Jump();
                    }
                    else
                    {
                        // 마리오 죽음
                        Hit();
                    }
                }
                break;
            default:
                if (dir.y > 0)
                {
                    playerAnimCtrl.PlayJump(false);
                    isGrounded = true;
                    isJumping = false;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case Common.tagItem:
                action = false;
                SetIgnoreEnemy(true);
                playerAnimCtrl.PlayGrowth();

                break;
        }
    }
    #endregion
}
