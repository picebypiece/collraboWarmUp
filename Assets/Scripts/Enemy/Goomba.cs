using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-16-PM-6-22
// 작성자   : 배형영
// 간단설명 :

public class Goomba : Enemy
{
    // Variable
    #region Variable
    [Header("Goomba")]
    [SerializeField]
    private Sprite spDeath = null;

    private Rigidbody2D rbGoomba = null;
    private BoxCollider2D colGoomba = null;
    private float deathForce = 100f;
    private bool change = false;
    private bool move = true;
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
        rbGoomba.MovePosition((Vector2)transform.position + (moveDirections[(int)nowDir] * moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!change && (collision.collider.tag == Common.tagEnvirments || collision.collider.tag == Common.tagEnemy))
        {
            if (nowDir == Direction.Left)
                nowDir = Direction.Right;
            else
                nowDir = Direction.Left;
            change = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (change && (collision.collider.tag == Common.tagEnvirments || collision.collider.tag == Common.tagEnemy))
        {
            change = false;
        }
    }
    #endregion

    // Protected Method
    #region Protected Method
    protected override void DoAwake() {
        rbGoomba = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        colGoomba = GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
    }
    protected override void Death()
    {
        move = false;
        colGoomba.enabled = false;
        animator.enabled = false;

        rbGoomba.AddForce(Vector2.up * deathForce, ForceMode2D.Force);
    }
    #endregion

    // Public Method
    #region Public Method
    public override void Init(Direction direction)
    {
        nowDir = direction;
        colGoomba.enabled = true;
        animator.enabled = true;
    }

    /// <summary>
    /// 데미지 입었을때
    /// </summary>
    public override void Hit(bool isTrample, Vector2 hitNormal)
    {
        if(isTrample)
        {
            spriteRenderer.sprite = spDeath;
        }
        else // 벽돌위에서 맞았을때
        {
            spriteRenderer.flipY = true;
        }
        Death();
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }
    
    #endregion

}
