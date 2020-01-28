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
    [SerializeField]
    protected float DelayActiveFalseValue;
    WaitForSeconds DelayActiveFalse;

    private Rigidbody2D playerRigidbody = null;
    private float jumpForce; // 점프 힘
    private float runSpeed;  // 달리는 속도
    private float counterForce;   // 역중력 힘
    private Vector2 counterJumpForce;   // 역중력 방향

    private bool action = true;
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isBoxHit = false;
    private bool ignoreMoveForce = false;
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
    private void Update()
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
            if (!playerInput.jumpBtnDownPush && Vector2.Dot(playerRigidbody.velocity, Vector2.up) > 0/*playerRigidbody.velocity.y >= 0f*/)

                playerRigidbody.AddForce(counterJumpForce * playerRigidbody.mass);
        }
    }
    private void OnDisable()
    {
        playerAnimCtrl.AnimEndEvent -= AnimEndCall;
    }
    #endregion

    // Private Method
    #region Private Method

    private void InitData()
    {
        playerRigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        if (playerAnimCtrl != null)
            playerAnimCtrl.SetMarioSize(MarioSize.Child);

        playerAnimCtrl.AnimEndEvent += AnimEndCall;

        jumpForce = 220f;
        runSpeed = 1.5f;
        counterForce = 50f;
        counterJumpForce = Vector2.down * counterForce;
        action = true;
        isGrounded = false;
        isJumping = false;

        DelayActiveFalse = new WaitForSeconds(DelayActiveFalseValue);
    }

    /// <summary>
    /// 움직이기
    /// </summary>
    private void Move()
    {
        if (!ignoreMoveForce)
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
                playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Run, false, 1f);
                return;
            }
            Vector2 movePos = playerInput.move * Vector2.right * runSpeed * Time.fixedDeltaTime;
            playerRigidbody.position = playerRigidbody.position + movePos;
            playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Run, true, playerInput.move * 5f);
        }
        else if(ignoreMoveForce&& Common.GameState != GameState.End)
        {
            playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Run, false, 1f);
        }
    }

    /// <summary>
    /// 점프 
    /// </summary>
    /// <param name="doForce">AddForce 하는지?</param>
    private void Jump(bool doForce)
    {
        isGrounded = false;
        isJumping = true;
        playerAnimCtrl.PlayAnim( PlayerAnimCtrl.AnimKind.Jump,true);

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
    private void AnimEndCall(PlayerAnimCtrl.AnimKind eventAnim)
    {
        switch (eventAnim)
        {
            case PlayerAnimCtrl.AnimKind.Growth:
                action = true;
                SetIgnoreCollision(false, Common.layerEnemy);
                break;
            case PlayerAnimCtrl.AnimKind.Flag:
                break;
            case PlayerAnimCtrl.AnimKind.Hit:
                action = true;
                StartCoroutine(Invincibility());
                break;
        }
    }
    /// <summary>
    /// 점프가 가능하도록 초기화
    /// </summary>
    private void InitJump()
    {
        playerAnimCtrl.PlayAnim( PlayerAnimCtrl.AnimKind.Jump,false);
        isGrounded = true;
        isJumping = false;
    }

    private IEnumerator Invincibility()
    {
        int count = 0;
        while(count < 5)
        {
            yield return new WaitForSeconds(0.15f);
            playerAnimCtrl.SetAlpha(0);
            yield return new WaitForSeconds(0.15f);
            playerAnimCtrl.SetAlpha(1);
            count++;
        }
        SetIgnoreCollision(false, Common.layerEnemy);
    }

    /// <summary>
    /// Player Delay SetActive false
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySetActiveFalseGameObject()
    {
        yield return DelayActiveFalse;
        this.gameObject.SetActive(false);
    }

    #endregion
    // Public Method
    #region Public Method
    /// <summary>
    /// 게임 끝에 행동할 에니메이션 코루틴
    /// </summary>
    public IEnumerator GotoTargetMove(Vector3 _Targetposition)
    {
        while (true)
        {
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, _Targetposition, Time.deltaTime);
            yield return null;
        }
    }

    public void DirectDeath()
    {
        action = false;
        //음...
    }

    public void Growth()
    {
        action = false;
        SetIgnoreCollision(true,Common.layerEnemy);
        playerAnimCtrl.PlayAnim( PlayerAnimCtrl.AnimKind.Growth);
    }
    public void PlayerStop()
    {
        ignoreMoveForce = true;
        playerRigidbody.velocity = Vector2.zero;
    }
    #endregion
}
