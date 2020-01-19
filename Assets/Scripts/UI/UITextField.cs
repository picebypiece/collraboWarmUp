using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
// 작성일자 : 2019-12-16-PM-10-17
// 작성자   : 최태욱
// 간단설명 : string 형식의 문자열을 출력하는 UI


namespace UI
{
    public class UITextField : MonoBehaviour
    {
        //특정상황에서만 업데이트 할건지, 이벤트로 업데이트 할건지
        public enum UpdateType { Frame, Event }
        // Variable
        #region Variable
        public string dataKey = null;   //데이터를 가져올 키
        public UpdateType updateTytpe = UpdateType.Event;

        public TextMeshProUGUI UIText;

        public string iniText = "";
        public string formatText = "{0}";

        public UnityEvent<string> onUpdate;
        #endregion

        // Property
        #region Property

        #endregion

        // MonoBehaviour
        #region MonoBehaviour
        private void Awake()
        {
            UIText.text = iniText;
            if (dataKey == null)
            {
                Debug.LogFormat("UI_ {0} Test Componont is null", gameObject.name);
                return; 
            }
            // TO-DO
            // 키값을 통해서 데이터, 이벤트 가져오기
            // 데이터가 없을경우
            // 프레임 업데이트일 경우 예외처리

            switch (updateTytpe)
            {
                case UpdateType.Frame:
                    StartCoroutine(FramUpdateData());
                    break;
                case UpdateType.Event:
                    if(GameManger.StageData.SubscribeUpdate(UpdateData, dataKey) == false)
                    {
                        Debug.LogFormat("UI_ {0} obj wrong datakey", gameObject.name);
                    }
                    break;
            }
        }

        private void OnEnable()
        {
            if (updateTytpe == UpdateType.Frame) StartCoroutine(FramUpdateData());
        }

        private void OnDisable()
        {
            if(updateTytpe == UpdateType.Frame) StopAllCoroutines();
        }
        #endregion

        // Private Method
        #region Private Method

        IEnumerator FramUpdateData()
        {
            while(true)
            {
                yield return new WaitForEndOfFrame();
                UpdateData();
            }
        }
        #endregion

        // Public Method
        #region Public Method
        void UpdateData()
        {
            var data = GameManger.StageData.GetDataToString(dataKey);
            if(formatText != null)
            {
                UIText.text = string.Format(formatText, data);
            }
            onUpdate.Invoke(data);
        }
        #endregion
    }
}