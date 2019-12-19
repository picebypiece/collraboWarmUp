using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        #endregion

        // Property
        #region Property

        #endregion

        // MonoBehaviour
        #region MonoBehaviour
        private void Awake()
        {
           // TO-DO
           // 키값을 통해서 데이터, 이벤트 가져오기
           // 데이터가 없을경우
           // 프레임 업데이트일 경우 예외처리
        }
        #endregion

        // Private Method
        #region Private Method

        #endregion

        // Public Method
        #region Public Method

        #endregion
    }
}