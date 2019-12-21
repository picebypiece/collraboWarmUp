using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class CreateTileMap : SingletonMono<CreateTileMap>
{
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

    MapData m_MapData;

    private void Awake()
    {
        m_MapData = MapData.Instance;
        TileGameObjectDictionary = new EnumDictionary<TileType, GameObject>();
        TileDictionary = new EnumDictionary<TileType, Tile>();

        ADD_Dictionary();
        MapData.Instance.FindMapList();
        MapData.Instance.LoadMapData(m_MapData.MapNameList[0]);

    }

    private void Start()
    {
        CreateMap();
    }

    public enum TileType
    {
        //default
        Default,
        //Map
        Ground, Brick, RiddleBox,
        //Monster
        Flower, Goomba, Koopa
    }

    /// <summary>
    /// 맵 생성 메소드
    /// </summary>
    public void CreateMap()
    {
        if (m_MapData.TileMatrix != null)
        {
            int MaxRow = m_MapData.TileMatrix[0].Length;
            //Row
            for (int i_Cloum = 0; i_Cloum < m_MapData.TileMatrix.Count; i_Cloum++)
            {
                //column
                for (int i_row = 0; i_row < MaxRow; i_row++)
                {
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

    /// <summary>
    /// Dictionary ADD 메소드
    /// </summary>
    void ADD_Dictionary()
    {
        TileGameObjectDictionary.Add(TileType.RiddleBox, GameObjects[0]);
        TileGameObjectDictionary.Add(TileType.Brick, GameObjects[1]);
        TileDictionary.Add(TileType.Ground, Tiles[0]);
    }

    /// <summary>
    /// 타일 메트릭스와 Tile이름을 비교하여 오브젝트를 생성해줌
    /// </summary>
    /// <param name="_compareTileString">비교할 String</param>
    /// <param name="_i_row">행</param>
    /// <param name="_i_Cloum">렬</param>
    void CompareTileName2TileMatrix(string _compareTileString,int _i_row, int _i_Cloum)
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
            else if(TileDictionary.TryGetValue(f_TileType, out f_tile))
            {
                m_TileLayer.SetTile(new Vector3Int(_i_row, _i_Cloum, 0), f_tile);
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
}
