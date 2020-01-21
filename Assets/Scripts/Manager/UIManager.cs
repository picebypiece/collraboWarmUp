using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �ۼ����� : 2020-01-13-PM-8-39
// �ۼ���   : ���¿�
// ���ܼ��� : UI�� �ε�� �ӽ� ������

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
    /// ���� �ε� �ɶ� ������ ���� ui ����
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
    /// ĳ�̵Ǿ��ִ� ������Ʈ�� ������ �ش������Ʈ�� ���� ��
    /// </summary>
    public T LoadUI<T>(string name) where T : MonoBehaviour
    {
        GameObject uiObj = null;
        T retObj = null;
        if (cacheDic.TryGetValue(name, out uiObj))
        {
            // ������Ʈ�� �� �� ���� ������ ���ŵǾ� GameObject���� nulll�� ���
            if (uiObj == null)
            {   //�����Ѵ�
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
    /// ĳ�̽� ��Ȱ��ȭ��
    /// ������Ʈ �� CachedString ���ڿ��� ����
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
            uiObj.name = name;  //ĳ�� ǥ������
            cacheDic.Remove(name);
            return true;
        }
        return false;
    }
    #endregion
}
