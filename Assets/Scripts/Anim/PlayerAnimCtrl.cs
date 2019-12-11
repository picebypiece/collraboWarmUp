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

    private const string paramNameJump = "Jump";
    private const string paramNameRun = "Run";


    private float speedCorrectionValue = 5f;
    private Animator cntAnimator = null;

    [Header("Animator")]
    [SerializeField]
    private Animator childAnim = null;
    [SerializeField]
    private Animator AdultAnim = null;
    #endregion

    // Property
    #region Property
    public bool Adult
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
            AdultAnim.gameObject.SetActive(true);
        }
        else
        {
            AdultAnim.gameObject.SetActive(false);
            cntAnimator = childAnim;
            childAnim.gameObject.SetActive(true);
        }
    }
    public void PlayGrowth()
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="run">true : 달림 , false : 멈춤</param>
    public void PlayRun(bool run)
    {
    }

    public void PlayJump(bool jump)
    {
        cntAnimator.SetBool(paramNameJump, jump);
    }

    #endregion
}
