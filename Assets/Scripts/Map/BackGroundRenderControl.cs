using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 작성일자 : 2019-12-24-PM-7-56
// 작성자   : 김세중
// 간단설명 : 백그라운드를 랜덤으로 보여줄 클래스

public class BackGroundRenderControl : MonoBehaviour
{
    // Variable
    #region Variable
    struct BackGroundSheet
    {
        public int OverWorld;
                //underWorld;
    }
    BackGroundSheet m_BackgroundSheet;

    Vector3 m_StartPos = new Vector3(3.84f, 1.2f, 0);

    [SerializeField]
    Sprite[] m_BackgroundImages;
    [SerializeField]
    SpriteRenderer m_spriteRnderer;
    #endregion

    // Property
    #region Property
    public Vector3 StartPos
    {
        get => m_StartPos;
        set => m_StartPos = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        //m_spriteRnderer = GetComponent<SpriteRenderer>();
        m_BackgroundSheet.OverWorld = 3;
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    public void Background_Roulette(int _backgroundSheet_Select)
    {
        m_spriteRnderer.sprite = m_BackgroundImages[Random.Range(0, _backgroundSheet_Select)];
        //m_spriteRnderer.sprite = m_BackgroundImages[1];
    }
    #endregion
}
