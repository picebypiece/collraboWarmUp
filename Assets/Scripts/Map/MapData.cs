using System;
using System.Collections.Generic;
//if You What Debug..
//using UnityEngine;

// 작성일자 : 2019-12-09-PM-4-46
// 작성자   : 김세중 
// 간단설명 : 데이터를 읽고 이를 유니티에 타일맵으로 만들어 줌

public class MapData :SingletonManager<MapData>, IDisposable
{
    // Variable
    #region Variable
    
    string[] MapDataBuffer;

    List<string[]> m_TileMatrix;
    List<string> m_MapNameList;

    FileFinder m_fileFinder;

    #endregion

    // Property
    #region Property
    /// <summary>
    /// 찾은 맵의 정보를 담은 List
    /// </summary>
    public List<string> MapNameList
    {
        get => m_MapNameList;
        set => m_MapNameList = value;
    }
    public List<string[]> TileMatrix
    {
        get => m_TileMatrix;
        set => m_TileMatrix = value;
    }
    #endregion

    // MonoBehaviour
    #region MonoBehaviour

    #endregion

    // Private Method
    #region Private Method
    MapData()
    {
        m_fileFinder = new FileFinder();
        MapNameList = new List<string>();
        m_TileMatrix = new List<string[]>();
    }
    #endregion

    // Public Method
    #region Public Method

    /// <summary>
    /// MapList가 담긴 파일 위치를 찾아 읽어오기
    /// </summary>
    public void FindMapList()
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapDataPath, ".csv",ref m_MapNameList);

        ////Debug
        //for (int i = 0; i < MapList.Count; ++i)
        //{
        //    Debug.Log(m_MapNameList[i]);
        //}
    }
    public void FindMapList(ref List<string> _MapNameList)
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapDataPath, ".csv", ref _MapNameList);

        ////Debug
        //for (int i = 0; i < _MapNameList.Count; ++i)
        //{
        //    Debug.Log(_MapNameList[i]);
        //}
    }

    /// <summary>
    /// 맵데이터 가져오기
    /// </summary>
    /// <param name="_mapName">Load Map name</param>
    public void LoadMapData(string _mapName)
    {
        //CSVParser.Load LoadMapTool = new CSVParser.Load();
        using (CSVParser.Load LoadMapTool = new CSVParser.Load())
        {
            //속성의 갯수만큼 스트링 배열의 크기를 정해 동적할당
            MapDataBuffer = new string[LoadMapTool.ReadComma(_mapName, FilePath.ExternalMapDataPath)];

            while (true)
            {
                //읽어온게 false(Reader를 실패했거나 더이상 가져올 수 없을떄)라면 While 탈출
                if (LoadMapTool.Reader(ref MapDataBuffer) != true)
                {
                    break;
                }

                m_TileMatrix.Add(MapDataBuffer);

                ////Debug
                //for (int i = 0; i < MapDataBuffer.Length; i++)
                //{
                //    Debug.Log(MapDataBuffer[i]);
                //}
            }

            //Debug.Log(m_TileMatrix);
            m_TileMatrix.Reverse();
            //Debug.Log(m_TileMatrix);

            LoadMapTool.CloseLoader();
        }
    }

    public void Dispose()
    {
        m_fileFinder = null;
        m_MapNameList.Clear();
        m_MapNameList = null;
        //TileTypeDictionary.Clear();
        //TileTypeDictionary = null;
        //MapDataBuffer = null;
    }
    #endregion

}
