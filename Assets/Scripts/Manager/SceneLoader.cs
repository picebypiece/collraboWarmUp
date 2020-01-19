using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 작성일자 : 2020-01-11-PM-10-48
// 작성자  : 최태욱
// 간단설명 : 씬 로드 관리

public class SceneLoader : SingletonMono<SceneLoader>
{

    // Variable
    #region Variable

    #endregion

    // Property
    #region Property
    public Scene PrevScene { get; private set; }
    public Scene CurrentScene { get; private set; }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    void Awake()
    {
        CurrentScene = PrevScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += SceneLoaded;
        DontDestroyOnLoad(this);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    #endregion

    // Private Method
    #region Private Method

    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PrevScene = CurrentScene;
        CurrentScene = scene;
    }
    #endregion

    // Public Method
    #region Public Method

    public void LoadScene(string SceneName, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(SceneName, sceneMode);
    }

    
    #endregion
}

