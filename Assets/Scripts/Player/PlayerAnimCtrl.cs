using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-2-56
// 작성자   : 배형영
// 간단설명 : 마리오 애니메이션 컨트롤러

public class PlayerAnimCtrl : MonoBehaviour
{
    public enum TriggerAnim
    {
        Death,
        Growth,
        Hit,
        Jump,
        Flag,
        Run,
    }
    public enum BoolAnim
    {
        Jump,
        Flag,
    }
    public enum MultiplierAnim
    {
        Run,
    }
    // Variable
    #region Variable

    public const string paramNameDeath = "Death";
    public const string paramNameGrowth = "Growth";
    public const string paramNameHit = "Hit";

    public const string paramNameJump = "Jump";
    public const string paramNameFlag = "Flag";

    public const string paramNameRun = "Run";
    public const string paramNameRunSpeed = "RunSpeed";

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


    //public delegate void AnimEnd(EventAnim eventAnim);
    //public event AnimEnd AnimEndEvent;

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
    private void Awake()
    {
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    public void HitEnd()
    {
        SetMarioSize(MarioSize.Child);
        //AnimEndEvent?.Invoke(EventAnim.Hit);
    }
    public void GrowthEnd()
    {
        SetMarioSize(MarioSize.Adult);
        //AnimEndEvent?.Invoke(EventAnim.Growth);
    }
    public void PlayAnim(TriggerAnim anim)
    {
        switch (anim)
        {
            case TriggerAnim.Death:
                cntAnimator.SetTrigger(paramNameDeath);
                break;
            case TriggerAnim.Growth:
                cntAnimator.SetTrigger(paramNameGrowth);
                break;
            case TriggerAnim.Hit:
                cntAnimator.SetTrigger(paramNameHit);
                break;
        }
    }
    public void PlayAnim(BoolAnim anim, bool value)
    {
        switch (anim)
        {
            case BoolAnim.Jump:
                cntAnimator.SetBool(paramNameJump, value);
                break;
            case BoolAnim.Flag:
                cntAnimator.SetBool(paramNameFlag, value);
                break;
        }
    }
    public void PlayAnim(MultiplierAnim anim, float value)
    {
        switch (anim)
        {
            case MultiplierAnim.Run:
                //if (cntAnimator.GetBool(paramNameRun) != run)
                //{
                //    cntAnimator.SetBool(paramNameRun, run);
                //}
                cntAnimator.SetFloat(paramNameRunSpeed, value);
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
    public void PlayFlag(bool play)
    {
        cntAnimator.SetBool(paramNameFlag, play);
    }
    public void FlipSprite(bool flip)
    {
        cntRenderer.flipX = flip;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="run">true : 달림 , false : 멈춤</param>
    public void PlayRun(bool run, float speed)
    {
        if(cntAnimator.GetBool(paramNameRun) != run)
        {
            cntAnimator.SetBool(paramNameRun, run);
        }
        cntAnimator.SetFloat(paramNameRunSpeed, speed);
    }
    
    public void SetFlipX(bool val)
    {
        if (cntRenderer.flipX != val)
            cntRenderer.flipX = val;
    }
    #endregion
}
