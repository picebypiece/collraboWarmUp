using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 작성일자 : 2020-01-16
// 작성자   : 최태욱
// 간단설명 : 타이틀 UI

namespace UI
{
    public class UITitle : MonoBehaviour
    {
        public Button btnOption = null;
        public Button btnGameStart = null;
        public Button btnExit = null;

        // Variable
        #region Variable

        #endregion

        // Property
        #region Property

        #endregion

        // MonoBehaviour
        #region MonoBehaviour
        private void Awake()
        {
            //타이틀 버튼에 함수 등록
            btnExit.onClick.AddListener(ExitButton);
            btnGameStart.onClick.AddListener(GameStart);
            btnOption.onClick.AddListener(GoOption);
        }
        #endregion

        // Private Method
        #region Private Method

        #endregion

        // Public Method
        #region Public Method
        public void GameStart()
        {
            SceneLoader.Instance.LoadScene(SceneName.Stage);
        }

        public void GoOption()
        {
            //UIManager.Instance.LoadUI<GameObject>()
        }

        public void ExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
#endregion
    }
}