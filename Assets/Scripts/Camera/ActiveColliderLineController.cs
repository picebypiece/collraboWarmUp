using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작성일자 : 2020-01-06-PM-4-30
// 작성자   : 김세중
// 간단설명 :

public class ActiveColliderLineController : MonoBehaviour
{
    // Variable
    #region Variable

    [Header("Ray Setting Info")]
    Ray[] m_Ray;
    RaycastHit2D[] m_RayHit;
    [SerializeField]
    Transform[] m_OriginTransfrom;
    [Space(1)]
    [SerializeField]
    Camera m_Camera;
    [SerializeField]
    float[] m_RayDistance;

    #endregion

    // Property
    #region Property
    public float[] RayDistance
    {
        get => m_RayDistance;
        set => m_RayDistance = value;
    }
    #endregion

    // Property
    #region Property

    #endregion

    // MonoBehaviour
    #region MonoBehaviour
    private void Awake()
    {
        m_Ray = new Ray[1];

        //m_DeathRay[0].origin = m_OriginTransfrom[0].position; (Update때 마다 위치변경됨)
        m_Ray[0].direction = m_OriginTransfrom[0].up;

    }

    private void Update()
    {
        m_Ray[0].origin = m_OriginTransfrom[0].position;
         ActiveTrueRayMethod(m_Ray[0].origin, m_Ray[0].direction, m_RayDistance[0]);
    }
    #endregion

    // Private Method
    #region Private Method
    void ActiveTrueRayMethod(Vector3 _origin, Vector3 _dir, float _distance)
    {
#if UNITY_EDITOR
        Debug.DrawRay(_origin, _dir * _distance, Color.yellow, 0.05f);
#endif
        m_RayHit = Physics2D.RaycastAll(_origin, _dir, _distance);
        if (m_RayHit != null)
        {
            foreach (var Object in m_RayHit)
            {
                Collider2D f_Collider2D = Object.collider;
                if (!f_Collider2D.CompareTag(Common.tagGround) && !f_Collider2D.CompareTag(Common.tagCamera))
                {
                     GameObject f_GameObject = f_Collider2D.gameObject;

                    if (f_GameObject.CompareTag(Common.tagEnvirments))
                    {
                        f_GameObject.GetComponent<TileObject>().Renderer.enabled = true;
                    }
                    else if (f_GameObject.CompareTag(Common.tagEnemy))
                    {
                        f_GameObject.GetComponent<Enemy>().Property_SpriteRenderer.enabled = true;
                        f_GameObject.GetComponent<Enemy>().enabled = true;
                    }
                }
            }
        }
        m_RayHit = null;
    }
    #endregion

    // Public Method
    #region Public Method
    
    #endregion



}
