using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 작성일자 : 2020-01-13-PM-8-39
// 작성자   : 최태욱
// 간단설명 : UI들 로드및 임시 저장담당

public class UIManager : SingletonMono<UIManager>
{
    const string UIAssetPath = "Prefabs/UI/";
    const string CachedString = "(CashedObj)";
    // Variable
    #region Variable
    Dictionary<string, GameObject> cacheDic;
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        DontDestroyOnLoad(this);
        cacheDic = new Dictionary<string, GameObject>();
        SceneManager.sceneLoaded += UISceneLoadedEvent;
    }
    #endregion

    #region Private Method

    /// <summary>
    /// 씬이 로드 될때 종류에 따라서 ui 정렬
    /// </summary>
    void UISceneLoadedEvent(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case SceneName.Title:

                break;
            case SceneName.Stage:
                SceneLoader.Instance.LoadScene(SceneName.StageUI, LoadSceneMode.Additive);
                break;
            default:
                break;
        }
    }

    #endregion

    #region Public Method

    /// <summary>
    /// 캐싱되어있는 오브젝트가 있으면 해당오브젝트를 먼저 줌
    /// </summary>
    public T LoadUI<T>(string name) where T : MonoBehaviour
    {
        GameObject uiObj = null;
        T retObj = null;
        if (cacheDic.TryGetValue(name, out uiObj))
        {
            // 오브젝트가 알 수 없는 이유로 제거되어 GameObject값이 nulll인 경우
            if (uiObj == null)
            {   //제거한다
                cacheDic.Remove(name);
            }
            else
            {
                retObj = uiObj.GetComponent<T>();
                return retObj;
            }
        }
        retObj = Resources.Load<T>($"{UIAssetPath}{name}");
        return retObj;
    }

    /// <summary>
    /// 캐싱시 비활성화됨
    /// 오브젝트 명에 CachedString 문자열이 붙음
    /// </summary>
    public void CachingUI(GameObject obj)
    {
        if (cacheDic.ContainsKey(obj.name) == false)
        {
            cacheDic.Add(obj.name, obj);
            obj.name = $"{obj.name}{CachedString}";
        }
        obj.SetActive(false);
    }

    public bool UnCachedUI(string name)
    {
        GameObject uiObj = null;
        if (cacheDic.TryGetValue(name, out uiObj))
        {
            uiObj.name = name;  //캐싱 표시제거
            cacheDic.Remove(name);
            return true;
        }
        return false;
    }
    #endregion
}
