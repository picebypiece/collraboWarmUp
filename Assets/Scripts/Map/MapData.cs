using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-09-PM-4-46
// 작성자   : 김세중 
// 간단설명 : 데이터를 읽고 이를 유니티에 타일맵으로 만들어 줌

public class MapData : MonoBehaviour
{
    // Variable
    #region Variable

    enum TileType
    {
        //Map
        Brick,Item,
        //Monster
        Flower, Goomba, Koopa
    }

    EnumDictionary<TileType, Tile> TileTypeDictionary;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    public void LoadMapData()
    {
        CSVParser.Load LoadMapTool = new CSVParser.Load();
        //LoadMapTool.ReadComma();
    }

    #endregion
}
