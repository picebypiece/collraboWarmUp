using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속받으면 싱글톤이 된다. Monobehaviour이 있는 버전
public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static object SingleMonolock = new object();
    private static bool IsQuit = false;

    public static T Instance
    {
        get
        {
            // 종료상태 검사
            if (IsQuit)
                return null;

            lock (SingleMonolock)
            {
                if (_instance == null)
                {
                    // 해당 오브젝트 찾기
                    T[] objs = FindObjectsOfType<T>();

                    if (objs.Length > 0)
                        _instance = objs[0];

                    // 하나 더 존재하면 안된다.
                    if (objs.Length > 1)
                        Debug.LogError(string.Format($" 씬에 {typeof(T).Name}이 하나 더 존재합니다."));

                    // 없을경우 생성한다.
                    if (_instance == null)
                    {
                        string goName = typeof(T).ToString();
                        GameObject go = GameObject.Find(goName);
                        if (go == null)
                            go = new GameObject(goName);
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }
    // 에디터 상에서 강제종료시 문제발생 예방
    protected virtual void OnApplicationQuit()
    {
        IsQuit = true;
    }
}
