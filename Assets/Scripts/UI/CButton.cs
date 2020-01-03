using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 작성일자 : 2019-01-03
// 작성자   : 박정우
// 간단설명 : 상태변경을 전달하는 버튼 클래스

namespace UI
{
    public class CButton : MonoBehaviour
    {
        public enum BUTTON_TYPE { NONE , START, STAGE_START , OPTION , END , APPLY};
        #region Variable
        public BUTTON_TYPE m_eType = BUTTON_TYPE.NONE;

        #endregion

        // Property
        #region Property

        #endregion

        // MonoBehaviour
        #region MonoBehaviour

        #endregion

        // Private Method
        #region Private Method

        #endregion

        // Public Method
        #region Public Method
        public void OnClick(BUTTON_TYPE eType)
        {
            //System Manager한태 enum값을 전달하는경우


            //여기서 바로 처리하는 경우
            switch (eType)
            {
                case BUTTON_TYPE.START:
                    Application.LoadLevel((string)"MainScene");
                    break;
            }

        }
        #endregion
    }
}