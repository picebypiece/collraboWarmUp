using System;
using System.Reflection;

// 상속받으면 싱글톤이 된다. Monobehaviour이 없는버전
public class SingletonManager<T> where T : class
{
    private static volatile T _instance;
    // volatile
    // CPU는 최적화를 위해 이미 캐싱한 변수에 대해서는 메모리까지 다녀오지 않는다
    // 멀티스레드 상황에서 메모리에 접근하지 않고 사용시 문제발생가능성이 생기므로 무조건 메모리에 접근하여 가져오도록 명시

    private static readonly object Singlelock = new object();

    public static T Instance
    {
        get
        {
            lock(Singlelock)
            {
                if(_instance == null)
                {
                    CreateInstance();
                }
                return _instance;
            }
        }
    }

    private static void CreateInstance()
    {
        lock(Singlelock)
        {
            if(_instance == null)
            {
                Type t = typeof(T);

                //현재 Type에 대해 정의된 모든 public 생성자를 반환
                ConstructorInfo[] infos = t.GetConstructors();
                
                // public 생성자가 있으면 안됨.
                if(infos.Length > 0)
                {
                    throw new InvalidOperationException(String.Format($"{t.Name}은 public 생성자가 존재합니다.\n SingletonManager // CreateInstance 에러!"));
                }

                // CreateInstance는 new 생성자보단 퍼포먼스가 좋진않지만
                // 제네릭 형태인 지금은 클래스 타입을 알수 없고 new 제약조건도 없으므로
                // Activator.CreateInstance를 사용하자
                // 퍼포먼스도 치명적이진 않다.
                _instance = (T)Activator.CreateInstance(t, true);

                //true : public 또는 public이 아닌 매개 변수가 없는 생성자
                //false : 매개 변수가 없는 생성자만
            }
        }
    }
}
