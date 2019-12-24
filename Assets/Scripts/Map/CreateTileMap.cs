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
    public enum TileType
    {
        //default
        Default, Player,
        //BackGround
        Overworld1,Overworld2,OverWorld3,
        //Item
        Flag,FlagBody,FlagTop,Mushroom,
        //Map
        Ground, Brick, RiddleBox, Stair, PipeBodyLeft, PipeBodyRight, PipeDoorLeft, PipeDoorRight,
        //Monster
        Flower, Goomba, Koopa,KoopaTroopa
    }

    [SerializeField]
    private GameObject m_BackGround;
    BackGroundRenderControl m_BackGroundRenderController;
    int background_Counter;

    [SerializeField]
    private Tilemap
    m_TileLayer,
    m_GameObjectLayer,
    m_ForegroundLayer;

    [SerializeField]
    private List<Tile> Tiles;
    [SerializeField]
    private List<GameObject> GameObjects;
    [SerializeField]
    private List<Tile> Foregrounds;

    private EnumDictionary<TileType, GameObject> TileGameObjectDictionary;
    private EnumDictionary<TileType, Tile> TileDictionary;

    private MapData m_MapData;
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        background_Counter = 0;
        m_BackGroundRenderController = m_BackGround.GetComponent<BackGroundRenderControl>();
        m_MapData = MapData.Instance;
        TileGameObjectDictionary = new EnumDictionary<TileType, GameObject>();
        TileDictionary = new EnumDictionary<TileType, Tile>();

        ADD_Dictionary();

        //Map이름을 받아 어떤 맵파일을 가져올지 준비.
        MapData.Instance.FindMapList();
        //사용할 맵의 이름에 따른 데이터를 가져와 로드 함.
        MapData.Instance.LoadMapData(m_MapData.MapNameList[0]);
        
    }

    private void Start()
    {
        CreateMap();
    }
    #endregion

    // Private Method
    #region Private Method
    /// <summary>
    /// Dictionary ADD 메소드
    /// </summary>
    void ADD_Dictionary()
    {
        TileGameObjectDictionary.Add(TileType.RiddleBox, GameObjects[0]);
        TileGameObjectDictionary.Add(TileType.Brick, GameObjects[1]);
        TileGameObjectDictionary.Add(TileType.Flag, GameObjects[2]);
        TileGameObjectDictionary.Add(TileType.Goomba, GameObjects[3]);
        TileGameObjectDictionary.Add(TileType.KoopaTroopa, GameObjects[4]);
        TileGameObjectDictionary.Add(TileType.Player, GameObjects[5]);

        TileDictionary.Add(TileType.Ground, Tiles[0]);
        TileDictionary.Add(TileType.Stair, Tiles[1]);
        TileDictionary.Add(TileType.PipeBodyLeft, Tiles[2]);
        TileDictionary.Add(TileType.PipeBodyRight, Tiles[3]);
        TileDictionary.Add(TileType.PipeDoorLeft, Tiles[4]);
        TileDictionary.Add(TileType.PipeDoorRight, Tiles[5]);
        TileDictionary.Add(TileType.FlagBody, Tiles[6]);
    }

    /// <summary>
    /// 타일 메트릭스와 Tile이름을 비교하여 오브젝트를 생성해줌
    /// </summary>
    /// <param name="_compareTileString">비교할 String</param>
    /// <param name="_i_row">행</param>
    /// <param name="_i_Cloum">렬</param>
    void CompareTileName2TileMatrix(string _compareTileString, int _i_row, int _i_Cloum)
    {
        TileType f_TileType;
        if (Enum.TryParse<TileType>(_compareTileString, out f_TileType))
        {
            GameObject f_GameObject;
            Tile f_tile;
            Vector3 f_StandardVector3Pos = new Vector3(0.08f, 0.08f, 0);

            //게임오브젝트 선 비교
            if (TileGameObjectDictionary.TryGetValue(f_TileType, out f_GameObject))
            {
                Instantiate<GameObject>(f_GameObject, new Vector3(f_StandardVector3Pos.x + (0.16f * _i_row), f_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
            }

            //타일 후 비교
            if (TileDictionary.TryGetValue(f_TileType, out f_tile))
            {
                switch (f_TileType)
                {
                    case TileType.Default:
                        break;
                    case TileType.Flag:
                        //Instantiate<GameObject>(GameObjects[2], new Vector3(f_StandardVector3Pos.x + (0.16f * _i_row), f_StandardVector3Pos.y + (0.16f * _i_Cloum), 0), Quaternion.identity, m_GameObjectLayer.transform);
                        m_ForegroundLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), Tiles[6]);
                        break;
                    case TileType.FlagBody:
                        m_ForegroundLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), Tiles[6]);
                        break;
                    #region Save Case code
                    //case TileType.FlagTop:
                    //    break;
                    //case TileType.Mushroom:
                    //    break;
                    //case TileType.Ground:
                    //    break;
                    //case TileType.Brick:
                    //    break;
                    //case TileType.RiddleBox:
                    //    break;
                    //case TileType.Stair:
                    //    break;
                    //case TileType.PipeBodyLeft:
                    //    break;
                    //case TileType.PipeBodyRight:
                    //    break;
                    //case TileType.PipeDoorLeft:
                    //    break;
                    //case TileType.PipeDoorRight:
                    //    break;
                    //case TileType.Flower:
                    //    break;
                    //case TileType.Goomba:
                    //    break;
                    //case TileType.Koopa:
                    //    break;
                    //case TileType.KoopaTroopa:
                    //    break;
                    #endregion
                    default:
                        m_TileLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), f_tile);
                        break;
                }
            }
            
        }
        //예외 및 디버그 확인
        else
        {
#if UNITY_EDITOR
            if (f_TileType == TileType.Default)
            {
                Debug.Log("빈타일 생성");
            }
            else
            {
                Debug.LogWarning("맵데이터에서 <color=yellow><b>정의하지 않은</b></color> 타일값이 도출되었습니다.");
            }
#endif
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
        
            for (int i_Cloum = 0; i_Cloum < m_MapData.TileMatrix.Count; i_Cloum++)
            {
                for (int i_row = 0; i_row < MaxRow; i_row++)
                {
                    if (i_row % 50 == 0&&i_Cloum==0)
                    {
                        Instantiate<GameObject>(m_BackGround, new Vector3(m_BackGroundRenderController.StartPos.x + (7.68f * background_Counter++), m_BackGroundRenderController.StartPos.y, m_BackGroundRenderController.StartPos.z), Quaternion.identity);
                        m_BackGroundRenderController.Background_Roulette(2);
                    }
                    string[] tempRow = m_MapData.TileMatrix[i_Cloum];

                    CompareTileName2TileMatrix(tempRow[i_row], i_row, i_Cloum);
                }
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
