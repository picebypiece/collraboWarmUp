using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEngine;
#endif

// 작성일자 : 2019-12-09-PM-4-46
// 작성자   : 김세중 
// 간단설명 : 데이터를 읽고 이를 유니티에 타일맵으로 만들어 줌

public class MapData :SingletonManager<MapData>, IDisposable
{
    // Variable
#region Variable
    
    string[] MapDataBuffer;
    private List<string> m_MapNameList;
    private List<string> m_MapInfoList;

    private List<string[]> m_TileMatrix;
    private List<string[]> m_TileMatrixInfo;

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
    public List<string> MapInfoList
    {
        get => m_MapInfoList;
        set => m_MapInfoList = value;
    }
    /// <summary>
    /// 맵전체 타일을 가지고 있는 리스트
    /// </summary>
    public List<string[]> TileMatrix
    {
        get => m_TileMatrix;
        set => m_TileMatrix = value;
    }
    public List<string[]> TileMatrixInfo
    {
        get => m_TileMatrixInfo;
        set => m_TileMatrixInfo = value;
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
        m_MapInfoList = new List<string>();
        m_TileMatrix = new List<string[]>();
        m_TileMatrixInfo = new List<string[]>();
    }
#endregion

    // Public Method
#region Public Method

    /// <summary>
    /// MapList가 담긴 파일 위치를 찾아 읽어오기 (MapDataClass's MapNameList으로 가져올것)
    /// </summary>
    public void FindMapList()
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapDataPath, ".csv",ref m_MapNameList);

#if UNITY_EDITOR
        //Debug 
        for (int i = 0; i < m_MapNameList.Count; ++i)
        {
            Debug.Log(m_MapNameList[i]);
        }
        Debug.Log("맵이름 읽어오기 <b><color=Green>Complete</color></b>");
#endif
    }

    /// <summary>
    /// MapList가 담긴 파일 위치를 찾아 읽어오기(인자값에 List<string>으로 MapList 가져올것)
    /// </summary>
    /// <param name="_MapNameList"></param>
    public void FindMapList(ref List<string> _MapNameList)
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapDataPath, ".csv", ref _MapNameList);
 #if UNITY_EDITOR
        //Debug
        for (int i = 0; i < _MapNameList.Count; ++i)
        {
            Debug.Log(_MapNameList[i]);
        }
        Debug.Log("맵이름 읽어오기 <b><color=Green>Complete</color></b>");
#endif
    }

    public void FindMapInfo()
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapInfoPath, ".csv", ref m_MapInfoList);
#if UNITY_EDITOR
        //Debug 
        for (int i = 0; i < m_MapInfoList.Count; ++i)
        {
            Debug.Log(m_MapInfoList[i]);
        }
        Debug.Log("맵정보 읽어오기 <b><color=Green>Complete</color></b>");
#endif
    }

    public void FindMapInfo(ref List<string> _MapInfoList)
    {
        m_fileFinder.FileName2List(FilePath.ExternalMapInfoPath, ".csv", ref _MapInfoList);
#if UNITY_EDITOR
        //Debug
        for (int i = 0; i < _MapInfoList.Count; ++i)
        {
            Debug.Log(_MapInfoList[i]);
        }
        Debug.Log("맵정보 읽어오기 <b><color=Green>Complete</color></b>");
#endif
    }

    /// <summary>
    /// 맵데이터 가져오기
    /// </summary>
    /// <param name="_mapName">Load Map name</param>
    public void LoadMapData(string _mapName,string _Extension,string _FilePath,List<string[]> _Matrix)
    {
        //CSVParser.Load LoadMapTool = new CSVParser.Load();
        using (CSVParser.Load LoadMapTool = new CSVParser.Load())
        {
            //속성의 갯수만큼 스트링 배열의 크기를 정해 동적할당
            MapDataBuffer = new string[LoadMapTool.ReadComma(_mapName, _FilePath, _Extension)];

            while (true)
            {
                //읽어온게 false(Reader를 실패했거나 더이상 가져올 수 없을떄)라면 While 탈출
                if (LoadMapTool.Reader(ref MapDataBuffer) != true)
                {
                    break;
                }

                _Matrix.Add(MapDataBuffer);
                //m_TileMatrix.Add(MapDataBuffer);

#if UNITY_EDITOR
                //Debug
                //for (int i = 0; i < MapDataBuffer.Length; i++)
                //{
                //    Debug.Log(MapDataBuffer[i]);
                //}
#endif
            }

            //Debug.Log(m_TileMatrix);
            _Matrix.Reverse();
            //Debug.Log(m_TileMatrix);

            LoadMapTool.CloseLoader();
        }
    }

    public void Dispose()
    {
        m_fileFinder = null;
        m_MapNameList.Clear();
    }
#endregion

}
