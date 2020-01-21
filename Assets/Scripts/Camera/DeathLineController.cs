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
    float[] m_RayDistance;
    [SerializeField]
    Transform[] m_OriginTransfrom;

    #endregion

    // Property
    #region Property
    public float[] RayDistance
    {
        get => m_RayDistance;
        set => m_RayDistance = value;
    }
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
        ActiveFalseRayMethod(m_DeathRay[0].origin, m_DeathRay[0].direction, m_RayDistance[0]);
        ActiveFalseRayMethod(m_DeathRay[1].origin, m_DeathRay[1].direction, m_RayDistance[1]);
    }
    #endregion

    // Private Method
    #region Private Method
    /// <summary>
    /// 비활성화 Ray를 사용하기 위한 메소드
    /// </summary>
    /// <param name="_origin">기준 좌표</param>
    /// <param name="_dir">방향</param>
    /// <param name="_distance">거리</param>
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
                    if (Object.collider.CompareTag(Common.tagPlayer))
                    {
                        Object.collider.gameObject.transform.parent.gameObject.SetActive(false);
                    }
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
