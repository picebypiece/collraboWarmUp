using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-18-PM-2-28
// 작성자   : 배형영
// 간단설명 : 최상위 적 스크립트

public abstract class Enemy : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }
    // Variable
    #region Variable
    [Header("Enemy")]
    [SerializeField]
    protected float moveSpeed = 0f;
    [SerializeField]
    protected float DelayActiveFalseValue;
    WaitForSeconds DelayActiveFalse;
    [SerializeField]
    protected SpriteRenderer spriteRenderer = null;
    [SerializeField]
    protected Animator animator = null;
    [SerializeField]
    protected Direction nowDir = Direction.Left;
    protected Vector2[] moveDirections =
    {
        Vector2.left,
        Vector2.right
    };
    #endregion

    // Property
    #region Property

    public SpriteRenderer Property_SpriteRenderer
    {
        get => spriteRenderer;
        set => spriteRenderer = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        DoAwake();
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Protected Method
    #region Protected Method
    protected virtual void DoAwake() 
    {
        DelayActiveFalse = new WaitForSeconds(DelayActiveFalseValue);
    }
    protected abstract void Death();

    protected IEnumerator DelayFalseGameObject()
    {
        yield return DelayActiveFalse;
        this.gameObject.SetActive(false);
    }
    #endregion

    // Public Method
    #region Public Method
    public abstract void Init(Direction direction);
    public abstract void Hit(bool isTrample, Vector2 hit);
    public abstract void Stop();
    #endregion
}
