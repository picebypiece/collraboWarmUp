using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �ۼ����� : 2019-01-03
// �ۼ���   : ������
// ���ܼ��� : ���º����� �����ϴ� ��ư Ŭ����

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
            //System Manager���� enum���� �����ϴ°��


            //���⼭ �ٷ� ó���ϴ� ���
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