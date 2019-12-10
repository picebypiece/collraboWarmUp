using System.Text;
using UnityEngine;

// 작성일자 : 2019-12-10-PM-5-48
// 작성자   : 김세중
// 간단설명 : 유니티에서 제공되는 파일 경로를 간단하게 정의해둔것
static public class FilePath
{

    static public readonly string OutMapDataPath = Application.streamingAssetsPath + "/Map/";
    
    
    //delegate string AddressMaker(string _personaladdress);
    //AddressMaker address = (string Address) =>
    //{
    //    StringBuilder f_StringBuilder = new StringBuilder();
    //    for (int i = 0; i < _Pathbundle.Length; i++)
    //    {
    //        f_StringBuilder.Append(_Pathbundle[i]);
    //    }

    //    return f_StringBuilder.ToString();
    //}
    //static public readonly string OutMapDataPath = Application.streamingAssetsPath + "/Map/";

//    static public string AddressMake(string[] _Pathbundle)
//    {
//        StringBuilder f_StringBuilder = new StringBuilder();

//        for (int i = 0; i < _Pathbundle.Length; i++)
//        {   
//            f_StringBuilder.Append(_Pathbundle[i]);
//        }

//        return f_StringBuilder.ToString();
//    }
}
