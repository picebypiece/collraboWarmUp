using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-2-56
// 작성자   : 배형영
// 간단설명 : 마리오 애니메이션 컨트롤러

public class PlayerAnimCtrl : MonoBehaviour
{
    // Variable
    #region Variable

    public const string paramNameJump = "Jump";
    public const string paramNameRun = "Run";
    public const string paramNameRunSpeed = "RunSpeed";
    public const string paramNameGrowth = "Growth";
    public const string paramNameFlag = "Flag";
    public const string paramNameDeath = "Death";


    private float speedCorrectionValue = 5f;
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

    private GrowthAnimState animState = null;
    #endregion

    // Property
    #region Property
    public bool Adult
    {
        get; private set;
    }
    public bool FlipX
    {
        get { return cntRenderer.flipX; }
        set
        {
            if(cntRenderer.flipX != value)
                cntRenderer.flipX = value;
        }
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
    
    /// <summary>
    /// true면 어른
    /// </summary>
    /// <param name="isAdult"></param>
    public void SetState(bool isAdult)
    {
        this.Adult = isAdult;
        if (Adult)
        {
            childAnim.gameObject.SetActive(false);
            cntAnimator = AdultAnim;
            cntRenderer = AdultRenderer;
            AdultAnim.gameObject.SetActive(true);
        }
        else
        {
            AdultAnim.gameObject.SetActive(false);
            cntAnimator = childAnim;
            cntRenderer = childRenderer;
            childAnim.gameObject.SetActive(true);
        }
        if(animState == null)
        {
            animState = cntAnimator.GetBehaviour<GrowthAnimState>();
            animState.GrowthEndEvent += AnimEnd;
        }
    }
    public void PlayGrowth()
    {
        cntAnimator.SetTrigger(paramNameGrowth);
    }

    public void PlayFlag()
    {

    }
    public void PlayDeath()
    {

    }
    public void AnimEnd()
    {
        //Debug.Log(onStateInfo.StateInfo.);
        //switch(onStateInfo.StateInfo.)

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

    #endregion
}
