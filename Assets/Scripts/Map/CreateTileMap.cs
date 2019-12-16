using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTileMap : MonoBehaviour
{
    //public Tilemap BackGround;
    public Tilemap PlayGround;

    public List<Tile> Tiles;

    public EnumDictionary<TileType, GameObject> TileTypeDictionary;
    public enum TileType
    {
        //Map
        Brick, Item,
        //Monster
        Flower, Goomba, Koopa
    }

    private void Awake()
    {
        
        //PlayGround.SetTile(new Vector3Int(0, 0, 0), Tiles[0]);
        //PlayGround.SetTile(new Vector3Int(0, 1, 0), Tiles[1]);
        //PlayGround.SetTile(new Vector3Int(1, 1, 0), Tiles[0]);
        //this.gameObject.AddComponent<TilemapCollider2D>();
    }


}
