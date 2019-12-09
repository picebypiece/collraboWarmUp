using System.Collections;
using UnityEngine;
using UnityEditor;

public class CustomScriptTemplates : UnityEditor.AssetModificationProcessor
{
    // 가져온 에셋 제외 / 에셋을 생성할때 호출 (meta파일 생성)
    static void OnWillCreateAsset(string path)
    {
        // Assets/폴더/스크립트이름.cs.meta 이런식으로 들어온다.
        path = path.Replace(".meta", "");   // meta때기

        // .cs 찾기 아니면 리턴
        int index = path.LastIndexOf(".");  
        if (index < 0)
            return;
        string file = path.Substring(index);
        if (file != ".cs")
            return;

        // 유니티 에셋 데이터베이스 상의 주소를 실제 주소로 변경
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;

        // 중복검사
        if (!System.IO.File.Exists(path))
            return;

        // 스크립트 내용
        string fileContent = System.IO.File.ReadAllText(path);

        // 키워드 대체
        // 작성날짜
        fileContent = fileContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy/MM/dd/tt/h/mm", System.Globalization.CultureInfo.CreateSpecificCulture("ko-KR")));
        // 작성자
        DeveloperInformation information = AssetDatabase.LoadAssetAtPath<DeveloperInformation>("Assets/Editor/DeveloperInformation.asset");
        if (information)
        {
            fileContent = fileContent.Replace("#AUTHOR#", information.DeveloperName);
        }
        else
        {
            Debug.LogError("Failed to load DeveloperInformation");
        }

        // 대체가 끝나면 다시 파일에 쓰기
        System.IO.File.WriteAllText(path, fileContent);

        // 마무리
        AssetDatabase.Refresh();
    }
}
