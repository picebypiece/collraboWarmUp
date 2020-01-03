using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-2-56
// 작성자   : 배형영
// 간단설명 : 마리오 애니메이션 컨트롤러

public class PlayerAnimCtrl : MonoBehaviour
{
    public enum EventAnim
    {
        Growth,
        Flag,
        Hit,
    }

    // Variable
    #region Variable

    public const string paramNameJump = "Jump";
    public const string paramNameRun = "Run";
    public const string paramNameRunSpeed = "RunSpeed";
    public const string paramNameGrowth = "Growth";
    public const string paramNameFlag = "Flag";
    public const string paramNameDeath = "Death";
    public const string paramNameHit = "Hit";

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
    

    public delegate void AnimEnd(EventAnim eventAnim);
    public event AnimEnd AnimEndEvent;

    #endregion

    // Property
    #region Property
    public MarioSize marioSize
    {
        get; private set;
    }
    //public bool FlipX
    //{
    //    get { return cntRenderer.flipX; }
    //    set
    //    {
    //        if(cntRenderer.flipX != value)
    //            cntRenderer.flipX = value;
    //    }
    //}
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    #endregion

    // Private Method
    #region Private Method

    private IEnumerator Growth()
    {
        cntAnimator.SetTrigger(paramNameGrowth);

        yield return new WaitForSeconds(cntAnimator.GetCurrentAnimatorStateInfo(0).length);
        SetMarioSize(MarioSize.Adult);
        AnimEndEvent?.Invoke(EventAnim.Growth);

    }
    private IEnumerator Hit()
    {
        cntAnimator.SetTrigger(paramNameHit);

        yield return new WaitForSeconds(cntAnimator.GetCurrentAnimatorStateInfo(0).length);
        SetMarioSize(MarioSize.Child);
        AnimEndEvent?.Invoke(EventAnim.Hit);

    }
    #endregion

    // Public Method
    #region Public Method

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
    public void PlayGrowth()
    {
        StartCoroutine(Growth());
    }

    public void PlayFlag(bool play)
    {
        cntAnimator.SetBool(paramNameFlag, play);
    }
    public void PlayHit()
    {
        StartCoroutine(Hit());
    }
    public void PlayDeath()
    {
        cntAnimator.SetTrigger(paramNameDeath);
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

    public void PlayJump(bool jump)
    {
        cntAnimator.SetBool(paramNameJump, jump);
    }
    public void SetFlipX(bool val)
    {
        if (cntRenderer.flipX != val)
            cntRenderer.flipX = val;
    }
    #endregion
}
