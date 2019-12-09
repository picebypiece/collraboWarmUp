//using System.Collections;
//using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


// 작성일자 : 2019-12-09-PM-5-17
// 작성자   : 김세중
// 간단설명 : CSV파싱을 위한 클래스
// Save 클래스와 Load 클래스가 내부에서 분리되어 있음

public class CSVParser : IDisposable
{
    // Variable
    #region Variable
    /// <summary>
    /// 가져올 주소
    /// </summary>
    private string m_DataPath = null;
    #endregion

    // Property
    #region Property

    /// <summary>
        /// DataPath Property
        /// </summary>
    public string DataPath
    {
        get { return m_DataPath;  }
        set { m_DataPath = value; }
    }

    /// <summary>
    /// CSVParser 사용 후 제거를 위해 호출
    /// </summary>
    public void Dispose()
    {
        m_DataPath = null;
    }

    #endregion

    // Private Method
    #region Private Method

    #endregion

    // Public Method
    #region Public Method

    #endregion

    public class Save<T> : CSVParser, IDisposable
    {
        // Variable
        #region Variable
        
        //SteamWriter
        StreamWriter sWriter;

        //인덱스 갯수
        int indexCounter;

        //인덱스 설정 유무 확인
        protected bool isIndexSet = false;

        #endregion

        // Private Method
        #region Private Method

        /// <summary>
        /// CSVParser Save initializing
        /// </summary>
        Save()
        {
            indexCounter = 0;
        }

        #endregion

        // Public Method
        #region Public Method

        /// <summary>
        /// "StreamWriter.Close()" Wrapping, IndexSet return to false
        /// </summary>
        public void CloseWriter()
        {
            isIndexSet = false;
            sWriter.Close();
        }

        /// <summary>
        /// Create Write File(Txt) To Attributes
        /// </summary>
        /// <param name="_DataName">File Name(.Txt)</param>
        /// <param name="_attributes">attribute parameter</param>
        /// <param name="_address">FileAddress</param>
        /// <param name="_fileMode">StreamWriter start with Path and FileMode [Open(Can not found file, Create) or Create]</param>
        public void WriterOn(string _DataName, string[] _attributes, string _address, FileMode _fileMode)
        {
            //속성 설정 중
            isIndexSet = true;
            //속성값 의 수
            indexCounter = _attributes.Length;

            //데이터이름(확장자 포함)을 데이터 경로와 합쳐서 저장하는 변수
            StringBuilder f_StringBuilder = new StringBuilder(_address);
            f_StringBuilder.Append(_DataName);
            f_StringBuilder.Append(".csv");

            //데이터 경로 담기
            DataPath = f_StringBuilder.ToString();

            //사용 후 정리
            f_StringBuilder.Clear();

            //StreamWriter start with Path and FileMode Open(Can not found file, Create) or Create
            sWriter = new StreamWriter(new FileStream(DataPath, _fileMode));

            for (int i_index = 0; i_index < indexCounter; i_index++)
            {
                f_StringBuilder.Append("\"");
                f_StringBuilder.Append(_attributes[i_index]);
                f_StringBuilder.Append("\"");
                //string Tuple = "\"" + _attributes[i_index] + "\"";
                string Tuple = f_StringBuilder.ToString();

                //사용 후 정리
                f_StringBuilder.Clear();
                //작성
                sWriter.Write(Tuple);

                //마지막 인덱스에 ','를 넣지 않기 위한 작업
                if (!(i_index == indexCounter - 1))
                    sWriter.Write(',');
                else
                    sWriter.WriteLine();
            }
        }

        /// <summary>
        /// 원하는 자료형 배열을 가져와 txt 작성
        /// </summary>
        /// <param name="_inputData">Write to Data</param>
        public void Writer(T[] _inputData)
        {
            //인덱스가 준비가 되지 않았다면
            if (!isIndexSet)
            {
#if UNITY_EDITOR
                //withUnity Erro Log
                Debug.LogError("<color=red><b>CSVPaserError</b></color> :  속성(index)을 설정하지 않고 작성을 하려고 하고 있습니다.");
#endif
                return;
            }

            for (int i_index = 0; i_index < _inputData.Length; i_index++)
            {
                if (i_index == _inputData.Length - 1)
                {
                    sWriter.Write(_inputData[i_index].ToString());
                    sWriter.WriteLine();
                }
                else
                {
                    sWriter.Write(_inputData[i_index].ToString());
                    sWriter.Write(',');
                }
                // else if (_inputData[i_index].GetType() != Type.GetType("string"))
                //{
                //    sWriter.Write(_inputData[i_index].ToString());
                //    sWriter.Write(',');
                //}
            }
        }

        #endregion
    }

    public class Load
    {
        CSVParser Parser;
        StreamReader sReader;
        protected bool isCommaFind = false;
        int? commaCount = null;

        public Load(CSVParser _instance)
        {
            Parser = _instance;
            commaCount = 0;
        }
        public Load()
        {
            Parser = new CSVParser();
            commaCount = 0;
        }

        public void CloseLoader()
        {
            sReader.Close();
        }

        public int ReadComma(string _DataName, string _address)
        {
            isCommaFind = true;
            string Line;
            //데이터이름(확장자 포함)을 데이터 경로와 합쳐서 저장하는 변수
            Parser.DataPath = _address + _DataName;

            //StreamWriter start with Path and FileMode Open(Can not found file, Create)OpenOrCreate
            sReader = new StreamReader(new FileStream(Parser.DataPath, FileMode.Open));

            Line = sReader.ReadLine();

            MatchCollection matches = Regex.Matches(Line, ",");

            commaCount = matches.Count;
            return (int)commaCount;
        }

        public int Reader(ref string[] _inputData)
        {
            string lineParse;

            if (!isCommaFind)
            {
                Debug.Log("<color=red><b>CSVPaserError</b></color> : 쉼표를 구분하지 않고 읽으려하고 있습니다. ReadComma 부터 실행하세요");
            }

            lineParse = sReader.ReadLine();
            if (lineParse == null)
            {
                return 0;
            }
            _inputData = lineParse.Split(',');
            return 1;
        }
    }
}

