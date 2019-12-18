using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTileMap : SingletonMono<CreateTileMap>
{
    //public Tilemap BackGround;
    public Tilemap PlayGround;

    public List<Tile> Tiles;

    MapData m_MapData;

    public EnumDictionary<TileType, Tile> TileTypeDictionary;
    public enum TileType
    {
        //Map
        Brick, Item,
        //Monster
        Flower, Goomba, Koopa
    }

    private void Awake()
    {
        m_MapData = MapData.Instance;
        MapData.Instance.FindMapList();
        MapData.Instance.LoadMapData(m_MapData.MapNameList[0]);
      

        //PlayGround.SetTile(new Vector3Int(0, 0, 0), Tiles[0]);
        //PlayGround.SetTile(new Vector3Int(0, 1, 0), Tiles[1]);
        //PlayGround.SetTile(new Vector3Int(1, 1, 0), Tiles[0]);
        //this.gameObject.AddComponent<TilemapCollider2D>();
    }

    private void Start()
    {
        //CreateMap();
        //this.gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        //this.gameObject.AddComponent<TilemapCollider2D>();
        //this.gameObject.AddComponent<CompositeCollider2D>();
    }

    public void CreateMap()
    {
        if (m_MapData.TileMatrix != null)
        {
            //Row
            for (int i_Cloum = 0; i_Cloum < m_MapData.TileMatrix.Count; i_Cloum++)
            {
                //column
                for (int i_row = 0; i_row < m_MapData.TileMatrix[0].Length; i_row++)
                {
                    PlayGround.SetTile(new Vector3Int(i_row, i_Cloum, 0), Tiles[0]);
                }
            }
        }
       
    }

}
