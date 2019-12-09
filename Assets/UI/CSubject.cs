using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CSubject : MonoBehaviour
    {
        private List<CObserver> m_ObserverList;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Subscribe(CObserver Observer)
        {
            if (null == Observer)
                return;

            //if (null != m_ObserverList.Find(Observer))
            //    return;

            //m_ObserverList.Add(Observer);

        }

        public void UnSubscribe(CObserver Observer)
        {
            //if (null == Observer)
            //    return;

            //m_ObserverList.Remove(Observer);
        }

        public void Notify(uint _iMessage)
        {
            //for (size_t i = 0; i < m_ObserverList.Count; ++i)
            //    m_ObserverList[i].Update(_iMessage);
        }
    }
}


