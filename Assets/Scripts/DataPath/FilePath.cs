using System.Text;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-5-48
// 작성자   : 김세중
// 간단설명 : 유니티에서 제공되는 파일 경로를 간단하게 정의해둔것
static public class FilePath
{
    /// <summary>
    /// 외부 맵 데이터 폴더 경로
    /// </summary>
    static public readonly string ExternalMapDataPath = string.Format($"{Application.streamingAssetsPath}/Map/");
    static public readonly string ExternalMapInfoPath = string.Format($"{Application.streamingAssetsPath}/MapInfo/");

}
