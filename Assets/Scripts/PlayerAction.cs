using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-11-PM-4-26
// 작성자   : 배형영
// 간단설명 : 조작에 따른 액션 처리 

public class PlayerAction : MonoBehaviour
{
    // Variable
    #region Variable
    [SerializeField]
    private PlayerInput playerInput = null;
    [SerializeField]
    private PlayerAnimCtrl playerAnimCtrl = null;
    private Rigidbody2D playerRigidbody = null;

    [SerializeField]
    private float jumpForce = 250f;
    private bool isGrounded = false;
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
    }
    private void FixedUpdate()
    {
        if (playerInput.jumpBtnDown)
        {
            if (isGrounded)
            {
                Debug.Log("GG");
                Jump();
            }
            
        }
        else if (playerInput.jumpBtnUp && playerRigidbody.velocity.y > 0f)
        {
            Debug.Log("gkgksdlkg");
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;

        }
    }
    #endregion

    // Private Method
    #region Private Method
    private void Move()
    {
        
    }
    private void Jump()
    {
        isGrounded = false;
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(0, jumpForce));
        playerAnimCtrl.PlayJump(true);
    }
    #endregion

    // Public Method
    #region Public Method

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        Debug.Log(collision.transform.name);
        playerAnimCtrl.PlayJump(false);
    }
    #endregion
}
