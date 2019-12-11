using UnityEngine;
using System.Collections.Generic;

// 작성일자 : 2019-12-11-PM-5-16
// 작성자   : 김세중
// 간단설명 : 접근한 경로내에 파일이름을 알아올 수 있음

public class FileFinder
{
    // Public Method
    #region Public Method
    /// <summary>
    /// 파일 주소를 통해 해당 폴더에 특정 이름이 포함되어있는지 확인하는 함수
    /// </summary>
    /// <param name="_FileAddress">파일 주소</param>
    /// <param name="_FileName">파일이름(확장자포함)</param>
    /// <returns>탐색 성공시 True , 실패 False </returns>
    public bool FileNameCatcher(string _FileAddress, string _FileName)
    {
        //FileInfo 및 DirectoryInfo 을 이용하여
        // 파일, 폴더 또는 드라이브의 이름을 나타내는 문자열을 생성자에 전달하여 이러한 클래스의 인스턴스를 만들 수 있음
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_FileAddress);
        foreach (System.IO.FileInfo File in di.GetFiles())
        {
            //파일이름(확장자포함)가 탐색할 파일 이름과 같으면
            if ((File.Name.Substring(0, File.Name.Length).CompareTo(_FileName) == 0))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 특정 확장자를 포함한 파일 주소를 통해 폴더의 이름들을 List<string>으로 넘겨주는 함수
    /// </summary>
    /// <param name="_FileAddress">폴더 주소</param>
    /// <param name="_Extension">확장자</param>
    /// <param name="_GetFileName">파일 이름들이 들어올 ref 인자</param>
    public void FileName2List(string _FileAddress, string _Extension, ref List<string> _GetFileName)
    {
        //FileInfo 및 DirectoryInfo 을 이용하여
        // 파일, 폴더 또는 드라이브의 이름을 나타내는 문자열을 생성자에 전달하여 이러한 클래스의 인스턴스를 만들 수 있음
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_FileAddress);

        foreach (System.IO.FileInfo File in di.GetFiles())
        {
            //파일안의 확장자 탐색 같으면 0 다르면 1
            if (File.Extension.ToLower().CompareTo(_Extension) == 0)
            {
                // 확장자 빼고 이름으로만
                string FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);

                //파일 이름을 찾았다면
                if (FileNameOnly != null)
                {
                    //참조 인자에 넘겨줌
                    _GetFileName.Add(FileNameOnly);
                }
#if UNITY_EDITOR
                else
                {
                    Debug.LogWarning("파일이름을 받아 올 수 없었습니다.");
                }
#endif
            }
        }
    }

    /// <summary>
    /// 확장자 없이 파일 내에 들어있는 데이터의 이름을 List<string>으로 넘겨주는 함수
    /// </summary>
    /// <param name="_FileAddress">폴더 주소</param>
    /// <param name="_GetFileName">파일 이름들이 들어올 ref 인자</param>
    public void FileName2List(string _FileAddress, ref List<string> _GetFileName)
    {
        //FileInfo 및 DirectoryInfo 을 이용하여
        // 파일, 폴더 또는 드라이브의 이름을 나타내는 문자열을 생성자에 전달하여 이러한 클래스의 인스턴스를 만들 수 있음
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_FileAddress);

        foreach (System.IO.FileInfo File in di.GetFiles())
        {

            //이름+경로까지 포함
            string FullFileName = File.FullName;

            //파일 이름을 찾았다면
            if (FullFileName != null)
            {
                //참조 인자에 넘겨줌
                _GetFileName.Add(FullFileName);
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogWarning("파일이름을 받아 올 수 없었습니다.");
            }
#endif
        }
    }
    #endregion
}
