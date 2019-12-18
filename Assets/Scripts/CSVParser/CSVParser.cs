using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


// 작성일자 : 2019-12-09-PM-5-17
// 작성자   : 김세중
// 간단설명 : CSV파싱을 위한 클래스
// Save 클래스와 Load 클래스가 내부에서 분리되어 있음

abstract class CSVParser
{
    // Variable
    #region Variable
    /// <summary>
    /// 가져올 주소
    /// </summary>
    /// 
    private string m_DataPath = null;
    #endregion

    // Property
    #region Property

    /// <summary>
    /// DataPath Property
    /// </summary>
    protected string DataPath
    {
        get { return m_DataPath;  }
        set { m_DataPath = value; }
    }
    #endregion

    //Private Method
    #region Method
    protected virtual void Dispose(bool _disposing)
    {
#if UNITY_EDITOR
        Debug.Log($"{this.ToString()}DisposStarting");
#endif
        if (_disposing)
        {
            m_DataPath = null;
        }
    }
    #endregion

    /// <summary>
    /// CSV 데이터 작성시 사용
    /// WriterOn 메소드를 이용해 속성값을 설정하고,
    /// Writer 메소드를 사용하여 내용을 작성 그리고
    /// CloseWriter 메소드를 사용하여 마무리.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Save<T> : CSVParser, IDisposable
    {
        // Variable
        #region Variable

        //SteamWriter
        StreamWriter sWriter;
        //인덱스 갯수
        int? indexCounter;
        //인덱스 설정 유무 확인
        protected bool? isIndexSet;

        #endregion

        // Public Method
        #region Public Method

        /// <summary>
        /// CSVParser Save initializing
        /// </summary>
        public Save()
        {
            indexCounter = 0;
            isIndexSet = false;
        }
        ~Save()
        {
            Dispose(false);
        }
        
        /// <summary>
        /// "StreamWriter.Close()" Wrapping, IndexSet return to false
        /// </summary>
        public void CloseWriter()
        {
            //StreamWriter.close in Dispose Method
            //https://stackoverflow.com/questions/7524903/should-i-call-close-or-dispose-for-stream-objects
            sWriter.Close();
        }

        /// <summary>
        /// Create Write File(Txt) To Attributes
        /// </summary>
        /// <param name="_DataName">File Name(.Txt)</param>
        /// <param name="_attributes">attribute parameter</param>
        /// <param name="_address">FileAddress</param>
        /// <param name="_fileMode">FileMode Select [CreateNew, Create]</param>
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
                //string Tuple = "\"" + _attributes[i_index] + "\"";
                f_StringBuilder.Append("\"");
                f_StringBuilder.Append(_attributes[i_index]);
                f_StringBuilder.Append("\"");
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
            if (!isIndexSet==null && !isIndexSet == false)
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

        /// <summary>
        /// Saver Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            CloseWriter();
            isIndexSet = null;
            indexCounter = null;
            // 종료자를 호출하지 않도록 요청 Why? : Dispose 를 활용하여 이미 한번 호출 하였기 때문에 중복 호출방지를 위해
            //https://docs.microsoft.com/ko-kr/dotnet/api/system.gc.suppressfinalize?view=netframework-4.8
            GC.SuppressFinalize(this);
        }

#endregion
    }

    /// <summary>
    /// CSV 데이터 읽기에 사용
    /// ReadComma 메소드를 호출하여 데이터 경로와 이름을 지정,
    /// Reader를 호출해 한 줄씩 원하는만큼 반복문을 사용하여 false가 반환될때 전부 읽어옴 그리고
    /// CloseLoader를 호출하여 마무리.
    /// </summary>
    public class Load : CSVParser, IDisposable
    {
        // Variable
        #region Variable

        //StreamReader
        StreamReader sReader;
        //콤마(",")를 구분했는지 확인하는 변수
        protected bool? isCommaFind;
        //콤마(",")의 갯수를 샘해줄 변수
        int? commaCount;

        #endregion

        // Public Method
        #region Public Method

        /// <summary>
        /// CSVParser Load initializing
        /// </summary>
        public Load()
        {
            isCommaFind = false;
            commaCount = 0;
        }
        ~Load()
        {
            Dispose(false);
        }

        /// <summary>
        ///  Loader close
        /// </summary>
        public void CloseLoader()
        {
            sReader.Close();
        }

        /// <summary>
        /// Get How Many Attreibute know
        /// </summary>
        /// <param name="_DataName">File Data name</param>
        /// <param name="_address">File Data address</param>
        /// <returns></returns>
        public int ReadComma(string _DataName, string _address)
        {
            //속성값을 읽었음을 알림
            isCommaFind = true;

            //읽을 라인 한줄
            string Line;

            //데이터이름(확장자 포함)을 데이터 경로와 합쳐서 저장하는 변수
            StringBuilder f_StringBuilder = new StringBuilder(_address);
            f_StringBuilder.Append(_DataName);
            f_StringBuilder.Append(".csv");

            ////데이터 경로 담기
            //DataPath = f_StringBuilder.ToString();

            //f_StringBuilder = null;

            ////StreamWriter start with Path and FileMode Open(Can not found file, Create)OpenOrCreate
            //sReader = new StreamReader(new FileStream(DataPath, FileMode.Open));
            sReader = new StreamReader(new FileStream(f_StringBuilder.ToString(), FileMode.Open));
            if (sReader == null)
            {
#if UNITY_EDITOR
                //withUnity Erro Log
                Debug.LogError("<color=red><b>CSVPaserError</b></color> :  가져올 데이터가 없거나 경로가 잘못 되었습니다.");
#endif
            }

            Line = sReader.ReadLine();

            //','의 갯수가 몇개인지 알아내기
            MatchCollection matches = Regex.Matches(Line, ",");
            //속성의 갯수을 알아냄
            commaCount = matches.Count;
            //속성 수를 반환
            return (int)commaCount;
        }

        /// <summary>
        /// 데이터 값을 한줄씩 읽어올 수 있음
        /// </summary>
        /// <param name="_GetData">GetData with String Array</param>
        /// <returns>성공여부 반환</returns>
        public bool Reader(ref string[] _GetData)
        {
            //콤마를 찾았는지 못찾았는지 확인
            if (!isCommaFind == null && !isCommaFind == false)
            {
#if UNITY_EDITOR
                Debug.Log("<color=red><b>CSVPaserError</b></color> : 쉼표를 구분하지 않고 읽으려하고 있습니다. ReadComma 부터 실행하세요");
#endif
                return false;
            }

            //한줄 읽은 것 담는 변수
            string lineParse;

            //한줄 읽은것을 담음
            lineParse = sReader.ReadLine();

            //읽어왔는데 null 이면 탈출
            if (lineParse == null)
            {
                return false;
            }

            //읽은것을 ','를 기준으로 나눠서 String 배열에 넣어줌
            _GetData = lineParse.Split(',');
            return true;
        }

        /// <summary>
        /// Loader Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            CloseLoader();
            sReader = null;
            commaCount = null;
            isCommaFind = null;
            // 종료자를 호출하지 않도록 요청 Why? : Dispose 를 활용하여 이미 한번 호출 하였기 때문에 중복 호출방지를 위해
            //https://docs.microsoft.com/ko-kr/dotnet/api/system.gc.suppressfinalize?view=netframework-4.8
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

