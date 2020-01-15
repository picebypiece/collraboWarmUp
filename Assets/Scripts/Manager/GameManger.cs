using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-18-PM-5-01
// 작성자   : 배형영
// 간단설명 :

public class GameManger : SingletonMono<GameManger>
{
    
    // Variable
    #region Variable
    public StageData stageData = null;


    #endregion

    // Property
    #region Property
    static public StageData StageData
    {
        get
        {
            return Instance.stageData;
        }
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        stageData = new StageData();
    }
    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method
    #endregion
}
