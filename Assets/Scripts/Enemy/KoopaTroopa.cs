using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-26-PM-6-15
// 작성자   : 배형영
// 간단설명 :

public class KoopaTroopa : Enemy
{
    private enum State
    {
        Normal,
        Hide,
        HideMove,
    }
    // Variable
    #region Variable

    [Header("KoopaTroopa")]
    [SerializeField]
    private Sprite spHit = null;

    private Rigidbody2D rbKoopaTroopa = null;
    private BoxCollider2D colKoopaTroopa = null;
    private float deathForce = 100f;
    private bool change = false;
    private bool move = true;
    private float hideMoveSpeed = 1.8f;

    private State state = State.Normal;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    private void FixedUpdate()
    {
        if (move)
        {
            Move();
        }
    }
    #endregion

    // Private Method
    #region Private Method

    private void Move()
    {
        rbKoopaTroopa.MovePosition((Vector2)transform.position + (moveDirections[(int)nowDir] * moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var col = collision.collider;
        if (state == State.HideMove)
        {
            if(col.CompareTag(Common.tagEnemy))
            {
                var enemy = collision.collider.GetComponent(typeof(Enemy)) as Enemy;
                enemy?.Hit(false, Vector2.zero);
                return;
            }
        }
        if (!change && (col.CompareTag(Common.tagEnvirments) || col.CompareTag(Common.tagEnemy)))
        {
            if (nowDir == Direction.Left)
                SetDirection(Direction.Right);
            else
                SetDirection(Direction.Left);
            change = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (change && (collision.collider.CompareTag(Common.tagEnvirments) || collision.collider.CompareTag(Common.tagEnemy)))
        {
            change = false;
        }
    }
    private void SetState(Vector2 hit)
    {
        switch (state)
        {
            case State.Normal:
                move = false;
                animator.enabled = false;
                spriteRenderer.sprite = this.spHit;
                state = State.Hide;
                break;
            case State.Hide:
                if(hit.x > 0)
                {
                    SetDirection(Direction.Left);
                }
                else
                {
                    SetDirection(Direction.Right);
                }
                this.moveSpeed = hideMoveSpeed;
                move = true;
                state = State.HideMove;
                break;
            case State.HideMove:
                move = false;

                state = State.Hide;
                break;
        }
    }
    private void SetDirection(Direction direction)
    {
        nowDir = direction;
        if(direction == Direction.Right)
        {
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;

    }
    #endregion

    // Protected Method
    #region Protected Method
    protected override void DoAwake()
    {
        rbKoopaTroopa = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        colKoopaTroopa = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
    }
    protected override void Death()
    {
        move = false;
        colKoopaTroopa.enabled = false;
        animator.enabled = false;

        rbKoopaTroopa.AddForce(Vector2.up * deathForce, ForceMode2D.Force);
    }
    #endregion

    // Public Method
    #region Public Method

    public override void Hit(bool isTrample, Vector2 hit)
    {
        if (isTrample)
        {
            SetState(hit);
        }
        else
        {
            spriteRenderer.flipY = true;
            Death();
        }
    }

    public override void Init(Direction direction)
    {
        SetDirection(direction);
        state = State.Normal;
        colKoopaTroopa.enabled = true;
        animator.enabled = true;
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
