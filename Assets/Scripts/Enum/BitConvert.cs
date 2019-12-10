using System.Collections;
using System.Collections.Generic;
using System;

// 작성일자 : 2019-12-10-PM-4-47
// 작성자   : Devcat
// 간단설명 : 포인터 사용으로 박싱&언박싱 해결

public class BitConvert
{
    //================================================================================================================================
    // Enum <==> Int
    //================================================================================================================================
    struct Shell<T>
        where T : struct
    {
        public int IntValue;
        public T Enum;
    }
    //--------------------------------------------------------------------------------------------------------------------------------
    public static int Enum32ToInt<T>(T e)
        where T : struct
    {
        Shell<T> s;
        s.Enum = e;
        unsafe
        {
            int* pi = &s.IntValue;
            pi += 1;
            return *pi;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------
    public static T IntToEnum32<T>(int value)
        where T : struct
    {
        var s = new Shell<T>();
        unsafe
        {
            int* pi = &s.IntValue;
            pi += 1;
            *pi = value;
        }
        return s.Enum;
    }
}
