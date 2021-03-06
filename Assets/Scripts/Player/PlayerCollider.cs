using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-PM-5-56
// 작성자   : 배형영
// 간단설명 :

public partial class PlayerAction
{
    // Variable
    #region Variable

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, overlapBoxSize);
    }
    #endregion

    // Private Method
    #region Private Method


    private void CheckGround()
    {
        //Vector2 vector2 = new Vector2(transform.position.x, transform.position.y + 0.015f);
        //RaycastHit2D hit = Physics2D.Raycast(vector2, transform.TransformDirection(Vector2.down), 0.03f/*, LayerMask.GetMask(Common.layerEnvirments)*/);
        //Debug.DrawRay(vector2, transform.TransformDirection(Vector2.down) * 0.03f, Color.red);

        Collider2D hit = Physics2D.OverlapBox(transform.position, overlapBoxSize, 0, overlapCheckLayer.value);

        if (hit != null)
        {
            isBoxHit = false;
            if (!isGrounded/* && playerRigidbody.velocity == Vector2.zero*/)
            {
                InitJump();
            }
        }
        else
        {
            Jump(false);
        }
    }
    /// <summary>
    /// 충돌무시 레이어 설정
    /// </summary>
    /// <param name="val"></param>
    private void SetIgnoreCollision(bool val, params string[] LayerName)
    {
        int player = LayerMask.NameToLayer(Common.layerPlayer);
        for (int i = 0; i < LayerName.Length; ++i)
        {
            Physics2D.IgnoreLayerCollision(player, LayerMask.NameToLayer(LayerName[i]), val);
        }
    }

    /// <summary>
    /// 적한테 맞았을때
    /// </summary>
    private void Hit()
    {
        action = false;
        switch (playerAnimCtrl.marioSize)
        {
            case MarioSize.Child:
                SetIgnoreCollision(true, Common.layerEnemy, Common.layerEnvirments);
                playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Death);
                Jump(true);
                StartCoroutine(DelaySetActiveFalseGameObject());
                break;
            case MarioSize.Adult:
                SetIgnoreCollision(true, Common.layerEnemy);
                playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Hit);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint = collision.contacts[0];
        Vector2 normal = contactPoint.normal;

        switch (contactPoint.collider.tag)
        {
            // 벽돌
            case Common.tagEnvirments:
                if (normal.y < 0 && !isBoxHit)
                {
                    isBoxHit = true;
                    TileObject tileObject = contactPoint.collider.GetComponent(typeof(TileObject)) as TileObject;
                    tileObject?.ActionCall();
                }
                //if (normal.x != 0 && normal.y > 0)
                //{
                //    ignoreMoveForce = true;
                //}
                //else
                //    ignoreMoveForce = false;
                break;
            case Common.tagEnemy:
                {
                    if (normal.y > 0)
                    {
                        Enemy enemy = contactPoint.collider.GetComponent(typeof(Enemy)) as Enemy;
                        enemy?.Hit(true, transform.position - contactPoint.collider.transform.position);
                        Jump(true);
                    }
                    else
                    {
                        // 마리오 죽음
                        Hit();
                    }
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case Common.tagItem:
                SpawnerType.ItemType t_ItemType = collision.gameObject.GetComponent<Item>().Get_ItemKind;
                switch (t_ItemType)
                {
                    case SpawnerType.ItemType.Coin:
                        break;
                    case SpawnerType.ItemType.GrowthMushroom:
                        switch (playerAnimCtrl.marioSize)
                        {
                            case MarioSize.Child:
                                action = false;
                                SetIgnoreCollision(true, Common.layerEnemy);
                                playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Growth);
                                break;
                            case MarioSize.Adult:
                                break;
                        }
                        break;
                    case SpawnerType.ItemType.PopCoin:
                        break;
                    case SpawnerType.ItemType.Flag:
                        PlayerStop();
                        break;
                    case SpawnerType.ItemType.CalseEnter:
                        this.gameObject.SetActive(false);
                        Common.GameState = GameState.Reset;
                        break;
                    default:
                        break;
                }
                //if (t_ItemType == SpawnerType.ItemType.GrowthMushroom)
                //{
                //    switch (playerAnimCtrl.marioSize)
                //    {
                //        case MarioSize.Child:
                //            action = false;
                //            SetIgnoreCollision(true, Common.layerEnemy);
                //            playerAnimCtrl.PlayAnim(PlayerAnimCtrl.AnimKind.Growth);
                //            break;
                //        case MarioSize.Adult:
                //            break;
                //    }
                //}
                //else if (t_ItemType == SpawnerType.ItemType.Flag)
                //{
                //    PlayerStop();
                //}
                //else if (t_ItemType == SpawnerType.ItemType.CalseEnter)
                //{
                //    this.gameObject.SetActive(false);
                //}
                break;
        }
    }
    #endregion

    // Public Method
    #region Public Method
   
    #endregion
}
