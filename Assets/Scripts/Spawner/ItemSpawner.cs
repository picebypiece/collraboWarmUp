using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2019-12-27-PM-1-07
// 작성자   : 김세중
// 간단설명 :

public class ItemSpawner : Spawner<SpawnerType.ItemType, GameObject>, IRegist_Dictionary
{
    // Variable
    #region Variable
    [SerializeField]
    private Dictionary<SpawnerType.ItemType, List<GameObject>> m_PoolDictionary;
    //public List<GameObject> m_tempPoolList;
    #endregion

    // Property
    #region Property
    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        //m_tempPoolList = new List<GameObject>();
        m_PoolDictionary = new Dictionary<SpawnerType.ItemType, List<GameObject>>();
    }
    private void Start()
    {
        PoolInit(3, SpawnerType.ItemType.PopCoin);
        PoolInit(1, SpawnerType.ItemType.Mushroom);
        int temp = m_PoolDictionary.Count;
    }
    #endregion

    // Private Method
    #region Private Method
    private void PoolInit(int _CreateNum, SpawnerType.ItemType _ItemType)
    {
        GameObject f_gameObject;
        List<GameObject> m_tempPoolList = new List<GameObject>();
        for (int i = 0; i < _CreateNum; i++)
        {
            CompareEnumTypeDictionary.TryGetValue(_ItemType,out f_gameObject);

            m_tempPoolList.Add(Instantiate(f_gameObject, this.transform));
            m_tempPoolList[i].SetActive(false);
        }
        m_PoolDictionary.Add(_ItemType, m_tempPoolList);

    }
    #endregion

    // Public Method
    #region Public Method

    public override void Instantiate(GameObject _GameObject, Vector3 _StandardPos, int _row, int _Cloum, Transform _ParentTransform)
    {
        Instantiate<GameObject>(_GameObject, new Vector3(_StandardPos.x + (0.16f * _row), _StandardPos.y + (0.16f * _Cloum), 0), Quaternion.identity, _ParentTransform);
        SpawnObjects.Add(_GameObject);
    }

    public override void Add_Dictionary()
    {
        int Itemindex = 0;
        CompareEnumTypeDictionary.Add(SpawnerType.ItemType.Coin, SpawnObjectList[Itemindex++]);
        CompareEnumTypeDictionary.Add(SpawnerType.ItemType.Mushroom, SpawnObjectList[Itemindex++]);
    }

    public void Contain_Dictionary()
    {
        Add_Dictionary();
    }

    public void Dictionary_Init()
    {
        CompareEnumTypeDictionary = new EnumDictionary<SpawnerType.ItemType, GameObject>();
    }
    #endregion
    
}
