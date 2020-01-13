using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-2-56
// 작성자   : 배형영
// 간단설명 : 마리오 애니메이션 컨트롤러

public class PlayerAnimCtrl : MonoBehaviour
{
    public enum AnimKind
    {
        Death,
        Growth,
        Hit,
        Jump,
        Flag,
        Run,
    }
    // Variable
    #region Variable

    public static int paramIDDeath      =    Animator.StringToHash("Death");
    public static int paramIDGrowth     =    Animator.StringToHash("Growth");
    public static int paramIDHit        =    Animator.StringToHash("Hit");
    public static int paramIDJump       =    Animator.StringToHash("Jump");
    public static int paramIDFlag       =    Animator.StringToHash("Flag");
    public static int paramIDRun        =    Animator.StringToHash("Run");
    public static int paramIDRunSpeed   =    Animator.StringToHash("RunSpeed");

    private Animator cntAnimator = null;
    private SpriteRenderer cntRenderer = null;

    [Header("Animator")]
    [SerializeField]
    private Animator childAnim = null;
    [SerializeField]
    private Animator AdultAnim = null;

    [Header("SpriteRenderer")]
    [SerializeField]
    private SpriteRenderer childRenderer = null;
    [SerializeField]
    private SpriteRenderer AdultRenderer = null;


    public delegate void AnimEnd(AnimKind eventAnim);
    public event AnimEnd AnimEndEvent;


    #endregion

    // Property
    #region Property
    public MarioSize marioSize
    {
        get; private set;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    public void HitEnd()
    {
        SetMarioSize(MarioSize.Child);
        AnimEndEvent?.Invoke(AnimKind.Hit);
    }
    public void GrowthEnd()
    {
        SetMarioSize(MarioSize.Adult);
        AnimEndEvent?.Invoke(AnimKind.Growth);
    }
    public void PlayAnim(AnimKind anim)
    {
        switch (anim)
        {
            case AnimKind.Death:
                cntAnimator.SetTrigger(paramIDDeath);
                break;
            case AnimKind.Growth:
                cntAnimator.SetTrigger(paramIDGrowth);
                break;
            case AnimKind.Hit:
                cntAnimator.SetTrigger(paramIDHit);
                break;
        }
    }
    public void PlayAnim(AnimKind anim, bool value)
    {
        switch (anim)
        {
            case AnimKind.Jump:
                cntAnimator.SetBool(paramIDJump, value);
                break;
            case AnimKind.Flag:
                cntAnimator.SetBool(paramIDFlag, value);
                break;
        }
    }
    public void PlayAnim(AnimKind anim, bool bvalue, float fvalue)
    {
        switch (anim)
        {
            case AnimKind.Run:
                if (cntAnimator.GetBool(paramIDRun) != bvalue)
                {
                    cntAnimator.SetBool(paramIDRun, bvalue);
                }
                cntAnimator.SetFloat(paramIDRunSpeed, fvalue);
                break;
        }
    }
    /// <summary>
    /// true면 어른
    /// </summary>
    /// <param name="isAdult"></param>
    public void SetMarioSize(MarioSize size)
    {
        this.marioSize = size;
        switch (marioSize)
        {
            case MarioSize.Child:
                AdultAnim.gameObject.SetActive(false);
                cntAnimator = childAnim;
                cntRenderer = childRenderer;
                childAnim.gameObject.SetActive(true);
                break;
            case MarioSize.Adult:
                childAnim.gameObject.SetActive(false);
                cntAnimator = AdultAnim;
                cntRenderer = AdultRenderer;
                AdultAnim.gameObject.SetActive(true);
                break;
        }
    }


    public void FlipSprite(bool flip)
    {
        cntRenderer.flipX = flip;
    }
    
    public void SetFlipX(bool val)
    {
        if (cntRenderer.flipX != val)
            cntRenderer.flipX = val;
    }
    public void SetAlpha(float val)
    {
        Color color = cntRenderer.color;
        cntRenderer.color = new Color(color.r, color.g, color.b, val);
    }
    #endregion
}
