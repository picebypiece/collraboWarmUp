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

    [Header("Spawners")]
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
    ForgroundSpawner m_ForgroundSpawner;

    /// <summary>
    /// 맵의 최대 행렬 갯수를 담은 구조체
    /// </summary>
    [System.Serializable]
    public struct MaxMapprocession
    {
        public int 
            Row, Colum;
    }
    public MaxMapprocession m_MaxMapprocession;

    /// <summary>
    /// 0,0 좌표에 해당하는 벡터 값
    /// </summary>
    Vector3 m_StandardVector3Pos = new Vector3(0.08f, 0.08f, 0);

    /// <summary>
    /// Spawn 순서 :
    /// Player, Tile, ForegroundType, ObjectTile, Enemy, Item
    /// </summary>
    public enum SpawnType
    {
        Default,

        Player, Tile, ForegroundType, ObjectTile, Enemy, Item,

        //항상 마지막에 사용할 Enum
        EndSpawnType
    }

    [System.Serializable]
    public struct TileMapLayerName
    {
        public int
            TileLayer,
            GameObjectActively,
            GameObjectTile,
            ForgoroundLayer;
    }
    public TileMapLayerName TileLayerName;

    [SerializeField]
    private GameObject m_BackGround;
    BackGroundRenderControl m_BackGroundRenderController;
    int background_Counter;

    [SerializeField]
    private Tilemap[] m_TileMapLayer;

    private MapData m_MapData;

    //Map을 만들때 필요한 변수
    Tile m_Tile;
    GameObject m_GameObject;
    #endregion

    // Property
    #region Property
    public Tilemap[] TileMapLayer
    {
        get => m_TileMapLayer;
        set => m_TileMapLayer = value;
    }

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        Common.GameState = GameState.Awake;

        //스포너들의 IRegist_Dictionary 등록
        m_Dictionary_Register = new IRegist_Dictionary[]
        {
            m_EnemySpawner,m_ItemSpawner,m_ObjectTileSpawner,m_PlayerSpawner,m_TileSpawner,m_ForgroundSpawner
        };

        //IRegist_Dictionary 메소드 호출
        foreach (IRegist_Dictionary Regist in m_Dictionary_Register)
        {
            Regist.Dictionary_Init();
            Regist.Contain_Dictionary();
        }

        //타일맵 레이어 이름을 int형 변수에 매칭
        TileLayerName.TileLayer = 0;
        TileLayerName.GameObjectActively = 1;
        TileLayerName.GameObjectTile = 2;
        TileLayerName.ForgoroundLayer = 3;

        //BackGround 갯수 초기화
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
        CreateTileMap.Instance.CreateMap();
        Common.GameState = GameState.Ing;
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
        int BackgroundCounter = (_MaxRow / _Nomal) + 1;

        for (int i_Counter = 0; i_Counter < BackgroundCounter; i_Counter++)
        {
            Instantiate<GameObject>(m_BackGround,
                new Vector3(m_BackGroundRenderController.StartPos.x + (7.68f * background_Counter++),
                m_BackGroundRenderController.StartPos.y, m_BackGroundRenderController.StartPos.z),
                Quaternion.identity);

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
            case SpawnType.ForegroundType:
                SpawnerType.ForegroundType f_foregroundType;
                if (Enum.TryParse<SpawnerType.ForegroundType>(_compareTileString, out f_foregroundType))
                {
                    m_ForgroundSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_foregroundType, out m_Tile);

                    //m_TileLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), m_Tile);
                    m_ForgroundSpawner.Instantiate(m_Tile, Vector3.zero, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.ForgoroundLayer]);
                }
                break;
            case SpawnType.Tile:
                SpawnerType.TileType f_TileType;
                if (Enum.TryParse<SpawnerType.TileType>(_compareTileString, out f_TileType))
                {
                    m_TileSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_TileType, out m_Tile);

                    //m_TileLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), m_Tile);
                    m_TileSpawner.Instantiate(m_Tile, Vector3.zero, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.TileLayer]);
                }
                break;
            case SpawnType.ObjectTile:
                SpawnerType.ObjectTileType f_objectType;
                if (Enum.TryParse<SpawnerType.ObjectTileType>(_compareTileString, out f_objectType))
                {
                    m_ObjectTileSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_objectType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_ObjectTileSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.GameObjectTile].transform);
                }
                break;
            case SpawnType.Enemy:
                SpawnerType.EnemyType f_EnemyType;
                if (Enum.TryParse<SpawnerType.EnemyType>(_compareTileString, out f_EnemyType))
                {
                    m_EnemySpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_EnemyType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_EnemySpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.GameObjectActively].transform);
                }
                break;
            case SpawnType.Item:
                SpawnerType.ItemType f_ItemType;
                if (Enum.TryParse<SpawnerType.ItemType>(_compareTileString, out f_ItemType))
                {
                    m_ItemSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_ItemType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_ItemSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.GameObjectActively].transform);

                }
                break;
            case SpawnType.Player:
                SpawnerType.PlayerType f_PlayerType;
                if (Enum.TryParse<SpawnerType.PlayerType>(_compareTileString, out f_PlayerType))
                {
                    m_PlayerSpawner.Get_CompareEnumTypeDictionary.TryGetValue(f_PlayerType, out m_GameObject);

                    //Instantiate<GameObject>(m_GameObject, new Vector3(m_StandardVector3Pos.x + (0.16f * _i_row), m_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                    m_PlayerSpawner.Instantiate(m_GameObject, m_StandardVector3Pos, _i_row, _i_Cloum, m_TileMapLayer[TileLayerName.GameObjectActively].transform);
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
    /// 행(Row) : 높이,
    /// 렬(colum) : 넓이
    /// </summary>
    public void CreateMap()
    {
        if (m_MapData.TileMatrix != null)
        {
            m_MaxMapprocession.Row = m_MapData.TileMatrix[0].Length;
            m_MaxMapprocession.Colum = m_MapData.TileMatrix.Count;

            BackGroundCreater(m_MaxMapprocession.Row, 50);

            SpawnType f_SpawnType = SpawnType.Default;
            ++f_SpawnType;

            while (f_SpawnType != SpawnType.EndSpawnType)
            {
                for (int i_Cloum = 0; i_Cloum < m_MaxMapprocession.Colum; i_Cloum++)
                {
                    for (int i_row = 0; i_row < m_MaxMapprocession.Row; i_row++)
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

  
    #endregion


}
