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
    public bool change = false;
    public bool move = true;
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
        CheckDirection();
    }
    
    private void CheckDirection()
    {
        var hit = Physics2D.RaycastAll(transform.position, moveDirections[(int)nowDir], 0.1f);
        Debug.DrawRay(transform.position, moveDirections[(int)nowDir] * 0.1f, Color.red);
        for (int i = 0; i < hit.Length; i++)
        {
            if(hit[i].transform != this.transform && (hit[i].collider.CompareTag(Common.tagGround) || hit[i].collider.CompareTag(Common.tagEnemy)))
            {
                if (nowDir == Direction.Left)
                    nowDir = Direction.Right;
                else
                    nowDir = Direction.Left;
            }
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
        //colGoomba.enabled = true;
        //animator.enabled = true;
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
