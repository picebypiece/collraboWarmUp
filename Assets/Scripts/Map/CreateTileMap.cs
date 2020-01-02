using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
// �ۼ����� : 2019-12-13-PM-4-46
// �ۼ���   : �輼��
// ���ܼ��� : Ÿ�ϸ��鶧 ����� �޼ҵ� ����
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

        //�׻� �������� ����� Enum
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

        //Map�̸��� �޾� � �������� �������� �غ�.
        MapData.Instance.FindMapList();
        MapData.Instance.FindMapInfo();
        //����� ���� �̸��� ���� �����͸� ������ �ε� ��.
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
    /// ��������Ʈ�� �ʿ��� ��ŭ ���������ִ� �޼ҵ�
    /// </summary>
    /// <param name="_MaxRow">2d Ÿ���� �ִ� "��"��</param>
    /// <param name="_Nomal">������ �Ǵ� BackGround �������ǿ� �ʿ��� Ÿ���� ����</param>
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
    /// Ÿ�� ��Ʈ������ Tile�̸��� ���Ͽ� ������Ʈ�� ��������
    /// </summary>
    /// <param name="_compareTileString">���� String</param>
    /// <param name="_spawnType">���� Ÿ��</param>
    /// <param name="_i_row">��</param>
    /// <param name="_i_Cloum">��</param>
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
                Debug.LogWarning("�ʵ����Ϳ��� <color=yellow><b>�������� ����</b></color> Ÿ�ϰ��� ����Ǿ����ϴ�.");
#endif
                break;
        }
    }

    #endregion

    // Public Method
    #region Public Method
    /// <summary>
    /// �� ���� �޼ҵ�
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
    /// Ÿ�ϳ��� �� �������� �������ִ� �޼ҵ�
    /// </summary>
    /// <param name="_compareTileString">String Tile �� </param>
    /// <param name="_row">��</param>
    /// <param name="_cloum">��</param>
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
