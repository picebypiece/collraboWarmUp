using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
// 작성일자 : 2019-12-13-PM-4-46
// 작성자   : 김세중
// 간단설명 : 타일만들때 사용할 메소드 소유
public class CreateTileMap : SingletonMono<CreateTileMap>
{

    // Variable
    #region Variable

    IRegist_Dictionary[] m_Dictionary_Register;

    [SerializeField]
    EnemySpawner m_EnemySpawner;
    [SerializeField]
    ItemSpawner m_ItemSpawner;
    [SerializeField]
    PlayerSpawner m_PlayerSpawner;
    [SerializeField]
    TileSpawner m_TileSpawner;
    [SerializeField]
    ObjectTileSpawner m_ObjectTileSpawner;

    [SerializeField]
    List<Transform> m_SpawnersTransform;

    public enum SpawnType
    {
        Default,

        Player,Tile, ObjectTile, Enemy, Item,

        //항상 마지막에 사용할 Enum
        EndSpawnType
    }
    Tile m_Tile;
    GameObject m_GameObject;
    Vector3 m_StandardVector3Pos = new Vector3(0.08f, 0.08f, 0);

    [SerializeField]
    private GameObject m_BackGround;
    BackGroundRenderControl m_BackGroundRenderController;
    int background_Counter;

    [SerializeField]
    private Tilemap
    m_TileLayer,
    m_GameObjectLayer,
    m_ForegroundLayer;

    private MapData m_MapData;
    #endregion

    // Property
    #region Property
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_Dictionary_Register = new IRegist_Dictionary[]
        {
            m_EnemySpawner,m_ItemSpawner,m_ObjectTileSpawner,m_PlayerSpawner,m_TileSpawner
        };

        foreach (IRegist_Dictionary Regist in m_Dictionary_Register)
        {
            Regist.Dictionary_Init();
            Regist.Contain_Dictionary();
        }


        background_Counter = 0;

        m_BackGroundRenderController = m_BackGround.GetComponent<BackGroundRenderControl>();

        m_MapData = MapData.Instance;

        //Map이름을 받아 어떤 맵파일을 가져올지 준비.
        MapData.Instance.FindMapList();
        MapData.Instance.FindMapInfo();
        //사용할 맵의 이름에 따른 데이터를 가져와 로드 함.
        MapData.Instance.LoadMapData(m_MapData.MapNameList[0], ".csv", FilePath.ExternalMapDataPath, m_MapData.TileMatrix);
        MapData.Instance.LoadMapData(m_MapData.MapInfoList[0], ".csv", FilePath.ExternalMapInfoPath, m_MapData.TileMatrixInfo);
    }

    private void Start()
    {
        CreateMap();
    }
    #endregion

    // Private Method
    #region Private Method

    /// <summary>
    /// 배경오브젝트를 필요한 만큼 생성시켜주는 메소드
    /// </summary>
    /// <param name="_MaxRow">2d 타일의 최대 "행"값</param>
    /// <param name="_Nomal">기준이 되는 BackGround 생성조건에 필요한 타일의 갯수</param>
    void BackGroundCreater(int _MaxRow, int _Nomal)
    {
        int BackgroundCounter = _MaxRow / _Nomal;

        for (int i_Counter = 0; i_Counter < BackgroundCounter; i_Counter++)
        {
            Instantiate<GameObject>(m_BackGround, new Vector3(m_BackGroundRenderController.StartPos.x + (7.68f * background_Counter++), m_BackGroundRenderController.StartPos.y, m_BackGroundRenderController.StartPos.z), Quaternion.identity);
            m_BackGroundRenderController.Background_Roulette(m_BackGroundRenderController.m_BackgroundSheet.OverWorld);
        }
    }

    /// <summary>
    /// 타일 메트릭스와 Tile이름을 비교하여 오브젝트를 생성해줌
    /// </summary>
    /// <param name="_compareTileString">비교할 String</param>
    /// <param name="_spawnType">생성 타입</param>
    /// <param name="_i_row">행</param>
    /// <param name="_i_Cloum">렬</param>
    void CompareTileName2TileMatrix(string _compareTileString, SpawnType _spawnType, int _i_row, int _i_Cloum)
    {
        switch (_spawnType)
        {
            case SpawnType.Tile:
                SpawnerType.TileType f_TileType;
                if (Enum.TryParse<SpawnerType.TileType>(_compareTileString, out f_TileType))
                {
                    m_TileSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_TileType, out m_Tile);

                    //m_TileLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), m_Tile);
                    m_TileSpawner.Instantiate(m_Tile, Vector3.zero, _i_row, _i_Cloum, null);
                }
                break;
            case SpawnType.ObjectTile:
                SpawnerType.ObjectTileType f_objectType;
                if (Enum.TryParse<SpawnerType.ObjectTileType>(_compareTileString, out f_objectType))
                {
                    m_ObjectTileSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_objectType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_ObjectTileSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_GameObjectLayer.transform);
                }
                break;
            case SpawnType.Enemy:
                SpawnerType.EnemyType f_EnemyType;
                if (Enum.TryParse<SpawnerType.EnemyType>(_compareTileString, out f_EnemyType))
                {
                    m_EnemySpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_EnemyType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_EnemySpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_GameObjectLayer.transform);
                }
                break;
            case SpawnType.Item:
                SpawnerType.ItemType f_ItemType;
                if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
                {
                    m_ItemSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_ItemType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_ItemSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_GameObjectLayer.transform);
                }
                break;
            case SpawnType.Player:
                SpawnerType.PlayerType f_PlayerType;
                if (Enum.TryParse<SpawnerType.PlayerType>(_compareTileString, out f_PlayerType))
                {
                    m_PlayerSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_PlayerType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_PlayerSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_GameObjectLayer.transform);
                }
                break;
            default:
#if UNITY_EDITOR
                Debug.LogWarning("맵데이터에서 <color=yellow><b>정의하지 않은</b></color> 타일값이 도출되었습니다.");
#endif
                break;
        }
    }

    #endregion

    // Public Method
    #region Public Method
    /// <summary>
    /// 맵 생성 메소드
    /// </summary>
    public void CreateMap()
    {
        if (m_MapData.TileMatrix != null)
        {
            int MaxRow = m_MapData.TileMatrix[0].Length;
            BackGroundCreater(MaxRow, 50);

            SpawnType f_SpawnType = SpawnType.Default;
            ++f_SpawnType;

            while (f_SpawnType != SpawnType.EndSpawnType)
            {
                for (int i_Cloum = 0; i_Cloum < m_MapData.TileMatrix.Count; i_Cloum++)
                {
                    for (int i_row = 0; i_row < MaxRow; i_row++)
                    {
                        string[] tempRow = m_MapData.TileMatrix[i_Cloum];

                        CompareTileName2TileMatrix(tempRow[i_row], f_SpawnType, i_row, i_Cloum);

                    }
                }
                ++f_SpawnType;
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Map Tile Matrix is <b><color=red>Empty</color></b>");
#endif
        }
    }

    /// <summary>
    /// 타일내에 들어갈 정보값을 저장해주는 메소드
    /// </summary>
    /// <param name="_compareTileString">String Tile 값 </param>
    /// <param name="_row">행</param>
    /// <param name="_cloum">렬</param>
    void MapInfoSet(GameObject _gameObject, string _compareTileString, int _row, int _cloum)
    {
        SpawnerType.ItemType f_ItemType;
        if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
        {
            _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
        }
        else
        {
            int f_parserNum;

            bool isNum = int.TryParse(_compareTileString, out f_parserNum);

            if (isNum == true)
            {
                //for
                _gameObject.GetComponent<TileObject>().PoketQueue.Enqueue(f_ItemType);
            }
        }
    }
    #endregion


}
