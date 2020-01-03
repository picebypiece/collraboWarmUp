using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-03-PM-3-44
// 작성자   : 배형영
// 간단설명 :

public class GameCamera : SingletonMono<GameCamera>
{

    public enum CameraKind
    {
        PlayerCamera,
    }
    [System.Serializable]
    public class CameraData
    {
        public CameraKind kind;
        public GameObject cameraObject;
        private Camera camera;
        public Camera Camera
        {
            get { return camera; }
        }

        public void MappingCamera()
        {
            this.camera = cameraObject.GetComponent(typeof(Camera)) as Camera;
            if(camera == null)
            {
#if UNITY_EDITOR
                Debug.LogError(string.Format($"할당된 카메라오브젝트 {this.cameraObject.name}에 Camera 컴포넌트가 없습니다."));
#endif
            }
        }
    }

    // Variable
    #region Variable
    [SerializeField]
    private CameraData[] cameraDatas = null;


    private EnumDictionary<CameraKind, CameraData> dicCameras = null;
    private EnumDictionary<CameraKind, GameObject> dicCameraObjs = null;

    #endregion

    // Property
    #region Property
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Init();
    }
    #endregion

    // Private Method
    #region Private Method
    private void Init()
    {
        if(cameraDatas != null)
        {
            dicCameras = new EnumDictionary<CameraKind, CameraData>();
            for (int i = 0; i < cameraDatas.Length; i++)
            {
                if(!dicCameras.ContainsKey(cameraDatas[i].kind))
                {
                    dicCameras.Add(cameraDatas[i].kind, cameraDatas[i]);
                    cameraDatas[i].MappingCamera();
                }
            }
            CreateCamera();
        }
    }
    private void CreateCamera()
    {
        dicCameraObjs = new EnumDictionary<CameraKind, GameObject>();
        foreach (var cam in dicCameras)
        {
            var c = Instantiate<GameObject>(cam.Value.cameraObject, transform);
            c.SetActive(false);

            if (!dicCameraObjs.ContainsKey(cam.Key))
            {
                dicCameraObjs.Add(cam.Key, c);
            }
        }
    }
    #endregion

    // Public Method
    #region Public Method
    public void SetActiveCamera(CameraKind kind)
    {
        var obj = GetCameraObject(kind);
        if(obj != null)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return;
            }
        }
        var data = GetCameraData(kind);
        if(data == null)
        {
#if UNITY_EDITOR
            Debug.LogError(string.Format($"{kind.ToString()} 해당 카메라종류가 발견되지 않았습니다."));
#endif
        }
        else
        {
            var c = Instantiate<GameObject>(data.cameraObject, transform);
            c.SetActive(true);

            if (!dicCameraObjs.ContainsKey(data.kind))
            {
                dicCameraObjs.Add(data.kind, c);
            }
        }

    }


    public CameraData GetCameraData(CameraKind kind)
    {
        if(this.dicCameras.ContainsKey(kind))
        {
            return dicCameras[kind];
        }
        return null;
    }
    public Camera GetCamera(CameraKind kind)
    {
        if (this.dicCameras.ContainsKey(kind))
        {
            return dicCameras[kind].Camera;
        }
        return null;
    }
    public GameObject GetCameraObject(CameraKind kind)
    {
        if (this.dicCameraObjs.ContainsKey(kind))
        {
            return dicCameraObjs[kind];
        }
        return null;
    }
    public T GetCameraObjectComponent<T>(CameraKind kind) where T : class
    {
        if (this.dicCameraObjs.ContainsKey(kind))
        {
            return dicCameraObjs[kind].GetComponent(typeof(T)) as T;
        }
        return null;
    }
    #endregion
}
