using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-06-PM-2-43
// 작성자   : 김세중
// 간단설명 :

public class DeathLineController : MonoBehaviour
{
    // Variable
    #region Variable

    [Header("Ray Setting Info")]
    Ray[] m_DeathRay;
    RaycastHit2D[] m_DeathRayHit;
    [SerializeField]
    float[] RayDistance;
    [SerializeField]
    Transform[] m_OriginTransfrom;

    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_DeathRay = new Ray[2];

        //m_DeathRay[0].origin = m_OriginTransfrom[0].position; (Update때 마다 위치변경됨)
        m_DeathRay[0].direction = m_OriginTransfrom[0].up;

        // m_DeathRay[1].origin = m_OriginTransfrom[1].position; (Update때 마다 위치변경됨)
        m_DeathRay[1].direction = m_OriginTransfrom[0].right;
    }

    private void Update()
    {
        m_DeathRay[0].origin = m_OriginTransfrom[0].position;
        m_DeathRay[1].origin = m_OriginTransfrom[0].position;
        ActiveFalseRayMethod(m_DeathRay[0].origin, m_DeathRay[0].direction, RayDistance[0]);
        ActiveFalseRayMethod(m_DeathRay[1].origin, m_DeathRay[1].direction, RayDistance[1]);
    }
    #endregion

    // Private Method
    #region Private Method
    void ActiveFalseRayMethod(Vector3 _origin, Vector3 _dir, float _distance)
    {
#if UNITY_EDITOR
        Debug.DrawRay(_origin, _dir * _distance, Color.cyan, 0.05f);
#endif
        m_DeathRayHit = Physics2D.RaycastAll(_origin, _dir, _distance);
        if (m_DeathRayHit != null)
        {
            foreach (var Object in m_DeathRayHit)
            {
                if (!Object.collider.CompareTag(Common.tagGround) && !Object.collider.CompareTag(Common.tagCamera))
                {
                    Object.collider.gameObject.SetActive(false);
                }
            }
        }
        m_DeathRayHit = null;
    }
    #endregion

    // Public Method
    #region Public Method

    #endregion
}
