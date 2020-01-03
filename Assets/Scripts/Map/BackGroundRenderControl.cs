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
    public struct BackGroundSheet
    {
        public int Worldinex;
        public int OverWorld;
                //underWorld;
    }
    public BackGroundSheet m_BackgroundSheet;

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
        BackgroundSheet_init();
    }
    #endregion

    // Private Method
    #region Private Method
    void BackgroundSheet_init()
    {
        // 백그라운드의 index 번호
        m_BackgroundSheet.OverWorld = 2;

        //전체 백그라운드 수
        m_BackgroundSheet.Worldinex = (m_BackgroundSheet.OverWorld);
    }
    #endregion

    // Public Method
    #region Public Method
    public void Background_Roulette(int _backgroundSheet_Select)
    {
        m_spriteRnderer.sprite = m_BackgroundImages[Random.Range(m_BackgroundSheet.Worldinex - _backgroundSheet_Select, _backgroundSheet_Select)];
        //m_spriteRnderer.sprite = m_BackgroundImages[1];
    }
    #endregion
}
